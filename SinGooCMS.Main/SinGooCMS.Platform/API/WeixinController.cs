using System;
using System.Collections.Generic;
using System.Linq;
using SinGooCMS.Application;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Utility;
using Microsoft.Extensions.Logging;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.Entities.Request;
using SinGooCMS.Weixin;
using SinGooCMS.Weixin.MP.MessageHandlers;
using Senparc.CO2NET.AspNet.HttpUtility;
using Senparc.Weixin.MP.MvcExtension;
using SinGooCMS.Domain.Interface;
using System.Threading.Tasks;

namespace SinGooCMS.Platform
{
    public class WeixinController : UIPageBase
    {
        private readonly IAutoRlyRepository autoRlyRepository;
        public WeixinController(IAutoRlyRepository _autoRlyRepository)
        {
            this.autoRlyRepository = _autoRlyRepository;
        }

        #region 微信平台提交的请求处理

        /// <summary>
        /// 收发微信端消息
        /// </summary>
        /// <param name="postModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Api(PostModel postModel)
        {
            WXConfig config = await WXConfig.Load();
            if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, config.Token))
            {
                return Content("参数错误！");
            }

            #region 打包 PostModel 信息

            postModel.Token = config.Token;//根据自己后台的设置保持一致
            postModel.EncodingAESKey = config.EncodingAESKey;//根据自己后台的设置保持一致
            postModel.AppId = config.AppID;//根据自己后台的设置保持一致（必须提供）

            #endregion

            //v4.2.2之后的版本，可以设置每个人上下文消息储存的最大数量，防止内存占用过多，如果该参数小于等于0，则不限制
            var maxRecordCount = 10;

            //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            var messageHandler = new CustomMessageHandler(Request.GetRequestMemoryStream(), postModel, maxRecordCount, true, autoRlyRepository, Context);

            /* 如果需要添加消息去重功能，只需打开OmitRepeatedMessage功能，SDK会自动处理。
             * 收到重复消息通常是因为微信服务器没有及时收到响应，会持续发送2-5条不等的相同内容的 RequestMessage */
            messageHandler.OmitRepeatedMessage = true;//默认已经是开启状态，此处仅作为演示，也可以设置为 false 在本次请求中停用此功能

            try
            {
                messageHandler.SaveRequestMessageLog();//记录 Request 日志（可选）

                messageHandler.Execute();//执行微信处理过程（关键）

                messageHandler.SaveResponseMessageLog();//记录 Response 日志（可选）

                return Content(messageHandler.ResponseDocument.ToString());//v0.7-
                //return new WeixinResult(messageHandler);//v0.8+
                //return new FixWeixinBugWeixinResult(messageHandler);//为了解决官方微信5.0软件换行bug暂时添加的方法，平时用下面一个方法即可
            }
            catch (Exception ex)
            {
                Context.Log.LogDebug("微信公众号 MessageHandler错误：{0}", ex.Message);
                return Content("");
            }
        }

        #endregion        

        #region 在对接微信公从号验证签名

        /// <summary>
        /// 对接公众号时验证参数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Api()
        {
            WXConfig config = await WXConfig.Load();
            string signature = WebUtils.GetQueryString("signature");
            string timestamp = WebUtils.GetQueryString("timestamp");
            string nonce = WebUtils.GetQueryString("nonce");
            string echostr = WebUtils.GetQueryString("echostr");

            Context.Log.LogInformation($"验证签名参数：'signature={signature},timestamp={timestamp},nonce={nonce},echostr={echostr}'");

            //get method - 仅在微信后台填写URL验证时触发
            if (CheckSignature.Check(signature, timestamp, nonce, config.Token))
            {
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + signature + ",token:" + config.Token + " " + CheckSignature.GetSignature(timestamp, nonce, config.Token) + "。" +
                            "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }

        #endregion
    }
}
