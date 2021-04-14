using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Senparc.CO2NET.Helpers;
using Senparc.CO2NET.Utilities;
using Senparc.NeuChar.Agents;
using Senparc.NeuChar.Entities;
using Senparc.NeuChar.Entities.Request;
using Senparc.NeuChar.Helpers;
using Senparc.Weixin;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageHandlers;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;

namespace SinGooCMS.Weixin.MP.MessageHandlers
{
    public partial class CustomMessageHandler : MessageHandler<CustomMessageContext>
    {
        private readonly IAutoRlyRepository autoRlyRepository;
        private readonly ICMSContext context;

        private static WXConfig WxConfig => WXConfig.Load().GetAwaiter().GetResult();

        private string appId = Config.SenparcWeixinSetting.WeixinAppId = WxConfig.AppID;
        private string appSecret = Config.SenparcWeixinSetting.WeixinAppSecret = WxConfig.AppSecret;
        private string token = Config.SenparcWeixinSetting.Token = WxConfig.Token;
        private string encodingAESKey = Config.SenparcWeixinSetting.EncodingAESKey = WxConfig.EncodingAESKey;

        /// <summary>
        /// 为中间件提供生成当前类的委托
        /// </summary>
        public static Func<Stream, PostModel, int, CustomMessageHandler> GenerateMessageHandler =
            (stream, postModel, maxRecordCount) => new CustomMessageHandler(stream, postModel, maxRecordCount, false);

        public CustomMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0, bool onlyAllowEncryptMessage = false, IAutoRlyRepository _autoRlyRepository = null, ICMSContext _context = null)
            : base(inputStream, postModel, maxRecordCount, onlyAllowEncryptMessage)
        {
            this.autoRlyRepository = _autoRlyRepository;
            this.context = _context;

            GlobalMessageContext.ExpireMinutes = WxConfig.ExpireMinutes;
            OnlyAllowEncryptMessage = onlyAllowEncryptMessage;//是否只允许接收加密消息，默认为 false

            if (!string.IsNullOrEmpty(postModel.AppId))
            {
                appId = postModel.AppId;//通过第三方开放平台发送过来的请求
            }

            //在指定条件下，不使用消息去重
            base.OmitRepeatedMessageFunc = requestMessage =>
            {
                var textRequestMessage = requestMessage as RequestMessageText;
                if (textRequestMessage != null && textRequestMessage.Content == "容错")
                {
                    return false;
                }
                return true;
            };
        }


        /// <summary>
        /// 处理文字请求
        /// </summary>
        /// <param name="requestMessage">请求消息</param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnTextRequestAsync(RequestMessageText requestMessage)
        {
            var defaultResponseMessage = base.CreateResponseMessage<ResponseMessageText>();
            var key = requestMessage.Content;
            switch (key)
            {
                case "OPENID":
                    {
                        var openId = requestMessage.FromUserName;//获取OpenId
                        var userInfo = Senparc.Weixin.MP.AdvancedAPIs.UserApi.Info(appId, openId, Senparc.Weixin.Language.zh_CN);

                        defaultResponseMessage.Content = string.Format(
                            "您的OpenID为：{0}\r\n昵称：{1}\r\n性别：{2}\r\n地区（国家/省/市）：{3}/{4}/{5}\r\n关注时间：{6}\r\n关注状态：{7}",
                            requestMessage.FromUserName, userInfo.nickname, (WeixinSex)userInfo.sex, userInfo.country, userInfo.province, userInfo.city, DateTimeHelper.GetDateTimeFromXml(userInfo.subscribe_time), userInfo.subscribe);
                        return defaultResponseMessage;
                    }
                default:
                    {
                        AutoRlyInfo keyRly = await autoRlyRepository.GetKeyRly(key);
                        if (keyRly != null)
                            return await SendReplyMsg(requestMessage, requestMessage.Content);
                        else
                            return await SendDefaultMsg(requestMessage);
                    }
            }
        }

        private async Task<IResponseMessageBase> SendDefaultMsg(IRequestMessageBase requestMessage)
        {
            return await SendReplyMsg(requestMessage, string.Empty);
        }

        /// <summary>
        /// 发送默认的消息
        /// </summary>
        private async Task<IResponseMessageBase> SendReplyMsg(IRequestMessageBase requestMessage, string msgKey)
        {
            //默认回复
            var autoRly = await autoRlyRepository.GetDefaultRly();
            if (!string.IsNullOrEmpty(msgKey))
                autoRly = await autoRlyRepository.GetKeyRly(msgKey);

            switch (autoRly.MsgType)
            {
                case WeixinMsgType.Text:
                    var responseMessageText = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
                    responseMessageText.Content = autoRly.MsgText;
                    return responseMessageText;
                case WeixinMsgType.Image:
                    {
                        var responseMessageNews = CreateResponseMessage<ResponseMessageNews>();
                        responseMessageNews.Articles.Add(new Article()
                        {
                            Title = autoRly.MsgText,
                            Description = autoRly.Description,
                            PicUrl = GetUrlWithDomain(autoRly.MediaPath),
                            Url = autoRly.LinkUrl
                        });

                        return responseMessageNews;
                    }
            }

            return null;
        }

        /// <summary>
        /// 处理位置请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnLocationRequestAsync(RequestMessageLocation requestMessage)
        {
            /*
            var locationService = new LocationService();
            var responseMessage = locationService.GetResponseMessage(requestMessage as RequestMessageLocation);
            return responseMessage;*/

            return await SendDefaultMsg(requestMessage);
        }

        public override async Task<IResponseMessageBase> OnShortVideoRequestAsync(RequestMessageShortVideo requestMessage)
        {
            /*
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您刚才发送的是小视频";
            return responseMessage;*/

            return await SendDefaultMsg(requestMessage);
        }

        /// <summary>
        /// 处理图片请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnImageRequestAsync(RequestMessageImage requestMessage)
        {
            /*
            //一隔一返回News或Image格式
            if (base.GlobalMessageContext.GetMessageContext(requestMessage).RequestMessages.Count() % 2 == 0)
            {
                var responseMessage = CreateResponseMessage<ResponseMessageNews>();

                responseMessage.Articles.Add(new Article()
                {
                    Title = "您刚才发送了图片信息",
                    Description = "您发送的图片将会显示在边上",
                    PicUrl = requestMessage.PicUrl,
                    Url = "https://sdk.weixin.senparc.com"
                });
                responseMessage.Articles.Add(new Article()
                {
                    Title = "第二条",
                    Description = "第二条带连接的内容",
                    PicUrl = requestMessage.PicUrl,
                    Url = "https://sdk.weixin.senparc.com"
                });

                return responseMessage;
            }
            else
            {
                var responseMessage = CreateResponseMessage<ResponseMessageImage>();
                responseMessage.Image.MediaId = requestMessage.MediaId;
                return responseMessage;
            }*/

            return await SendDefaultMsg(requestMessage);
        }

        /// <summary>
        /// 处理语音请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnVoiceRequestAsync(RequestMessageVoice requestMessage)
        {
            /*
            var responseMessage = CreateResponseMessage<ResponseMessageMusic>();
            //上传缩略图
            //var accessToken = Containers.AccessTokenContainer.TryGetAccessToken(appId, appSecret);
            var uploadResult = Senparc.Weixin.MP.AdvancedAPIs.MediaApi.UploadTemporaryMedia(appId, UploadMediaFileType.image,
                                                         ServerUtility.ContentRootMapPath("~/Images/Logo.jpg"));

            //设置音乐信息
            responseMessage.Music.Title = "天籁之音";
            responseMessage.Music.Description = "播放您上传的语音";
            responseMessage.Music.MusicUrl = "https://sdk.weixin.senparc.com/Media/GetVoice?mediaId=" + requestMessage.MediaId;
            responseMessage.Music.HQMusicUrl = "https://sdk.weixin.senparc.com/Media/GetVoice?mediaId=" + requestMessage.MediaId;
            responseMessage.Music.ThumbMediaId = uploadResult.media_id;

            //推送一条客服消息
            try
            {
                CustomApi.SendText(appId, OpenId, "本次上传的音频MediaId：" + requestMessage.MediaId);

            }
            catch
            {
            }

            return responseMessage; */

            return await SendDefaultMsg(requestMessage);
        }
        /// <summary>
        /// 处理视频请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnVideoRequestAsync(RequestMessageVideo requestMessage)
        {
            /*
            var responseMessage = CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "您发送了一条视频信息，ID：" + requestMessage.MediaId;

            #region 上传素材并推送到客户端

            Task.Factory.StartNew(async () =>
            {
                //上传素材
                var dir = ServerUtility.ContentRootMapPath("~/App_Data/TempVideo/");
                var file = await MediaApi.GetAsync(appId, requestMessage.MediaId, dir);
                var uploadResult = await MediaApi.UploadTemporaryMediaAsync(appId, UploadMediaFileType.video, file, 50000);
                await CustomApi.SendVideoAsync(appId, base.WeixinOpenId, uploadResult.media_id, "这是您刚才发送的视频", "这是一条视频消息");
            }).ContinueWith(async task =>
            {
                if (task.Exception != null)
                {
                    WeixinTrace.Log("OnVideoRequest()储存Video过程发生错误：", task.Exception.Message);

                    var msg = string.Format("上传素材出错：{0}\r\n{1}",
                               task.Exception.Message,
                               task.Exception.InnerException != null
                                   ? task.Exception.InnerException.Message
                                   : null);
                    await CustomApi.SendTextAsync(appId, base.WeixinOpenId, msg);
                }
            });

            #endregion

            return responseMessage; */

            return await SendDefaultMsg(requestMessage);
        }


        /// <summary>
        /// 处理链接消息请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnLinkRequestAsync(RequestMessageLink requestMessage)
        {
            /*
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = string.Format(@"您发送了一条连接信息：
Title：{0}
Description:{1}
Url:{2}", requestMessage.Title, requestMessage.Description, requestMessage.Url);
            return responseMessage; */

            return await SendDefaultMsg(requestMessage);
        }

        public override async Task<IResponseMessageBase> OnFileRequestAsync(RequestMessageFile requestMessage)
        {
            /*
            var responseMessage = requestMessage.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = string.Format(@"您发送了一个文件：
文件名：{0}
说明:{1}
大小：{2}
MD5:{3}", requestMessage.Title, requestMessage.Description, requestMessage.FileTotalLen, requestMessage.FileMd5);
            return responseMessage; */

            return await SendDefaultMsg(requestMessage);
        }

        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            /* 所有没有被处理的消息会默认返回这里的结果，
            * 因此，如果想把整个微信请求委托出去（例如需要使用分布式或从其他服务器获取请求），
            * 只需要在这里统一发出委托请求，如：
            * var responseMessage = MessageAgent.RequestResponseMessage(agentUrl, agentToken, RequestDocument.ToString());
            * return responseMessage;
            */

            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "这条消息来自DefaultResponseMessage。";
            return responseMessage;
        }


        public override async Task<IResponseMessageBase> OnUnknownTypeRequestAsync(RequestMessageUnknownType requestMessage)
        {
            /*
             * 此方法用于应急处理SDK没有提供的消息类型，
             * 原始XML可以通过requestMessage.RequestDocument（或this.RequestDocument）获取到。
             * 如果不重写此方法，遇到未知的请求类型将会抛出异常（v14.8.3 之前的版本就是这么做的）
             */
            var msgType = Senparc.NeuChar.Helpers.MsgTypeHelper.GetRequestMsgTypeString(requestMessage.RequestDocument);
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "未知消息类型：" + msgType;

            WeixinTrace.SendCustomLog("未知请求消息类型", requestMessage.RequestDocument.ToString());//记录到日志中

            return responseMessage;
        }

        #region Helper        

        private string GetUrlWithDomain(string strPath)
        {
            if (!strPath.StartsWith("http://") && !strPath.StartsWith("https://"))
            {
                string strDomain = context.SiteConfig.SiteDomain;
                if (!strDomain.EndsWith("/"))
                    strDomain += "/";

                return strDomain + strPath.Replace("//", "/").TrimStart('/');
            }

            return string.Empty;
        }

        #endregion
    }
}
