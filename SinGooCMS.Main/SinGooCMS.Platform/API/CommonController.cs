using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SinGooCMS.Application;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Application.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform.API
{
    [Route("api/common/{action}")]
    [ApiController]
    public class CommonController : UIPageBase
    {
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IMessageService messageService;
        private readonly ISendRecordRepository sendRecordRepository;
        private readonly IUser user;

        public CommonController(
            IFeedbackRepository _feedbackRepository,
            IMessageService _messageService,
            ISendRecordRepository _sendRecordRepository,
            IUser _user)
        {
            this.feedbackRepository = _feedbackRepository;
            this.messageService = _messageService;
            this.sendRecordRepository = _sendRecordRepository;
            this.user = _user;
        }

        #region 保存留言信息

        [HttpPost]
        public async Task<string> SaveFeedback()
        {
            //验证码
            string checkCode = WebUtils.GetFormString("verifyCode");
            if (string.Compare(Context.ValidateCode, checkCode, true) != 0) //不区分大小写
                return OperateResult.FailJson("ValidateCodeIncorrect", "验证码不正确！");

            string title = WebUtils.GetFormString("title");
            string content = WebUtils.GetFormString("content");
            string userName = WebUtils.GetFormString("uname", user.UserName);
            string email = WebUtils.GetFormString("email");
            string phone = WebUtils.GetFormString("phone");

            if (content.IsNullOrEmpty() && userName.IsNullOrEmpty())
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            //如果标题为空，取内容部分作为标题
            if (title.IsNullOrEmpty())
                title = content.RemoveHtml().Substring(0, 15);

            if (await feedbackRepository.Send(content, userName, null, title, email, phone))
            {
                //同时发送邮件
                if (Context.SiteConfig["IsSendMailForLY"].ToBool())
                    await messageService.SendMail(Context.SiteConfig["ReciverEMail"], title, content);

                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region 发送验证码

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> SendCheckCode()
        {
            string receiverMedia = WebUtils.GetFormString("receiver"); //接收方
            string validateCode = WebUtils.GetFormString("vcode"); //网站验证码 防止盗发短信

            if (string.Compare(Context.ValidateCode, validateCode, true) != 0)
                return OperateResult.FailJson("ValidateCodeIncorrect", "验证码不正确！");
            else
            {
                if (receiverMedia.IsEmail())
                    return (await SendMailCodeAsync(receiverMedia)).ToString();
                else if (receiverMedia.IsMobile())
                    return (await SendMobildCodeAsync(receiverMedia)).ToString();
            }

            return OperateResult.failJson;
        }

        #region 发送手机验证码
        private async Task<OperateResult> SendMobildCodeAsync(string mobile)
        {
            //6位验证码
            string strCode = StringUtils.GetRandomNumber(6);
            bool canSend = true; //是否可发送短信标记

            //上一条手机发送的记录
            var sendLast = await sendRecordRepository.GetLatestCheckCode(mobile);
            if (sendLast != null)
            {
                //查找上一条记录发送的时间间隔
                TimeSpan timeSpan = System.DateTime.Now - sendLast.AutoTimeStamp.Value;
                if (timeSpan.TotalSeconds < 60)
                {
                    canSend = false; //默认间隔60秒 间隔时间太短,不允许发送
                    return new OperateResult(false, "fail", "发送间隔太短", "", 0, "", int.Parse((60 - timeSpan.TotalSeconds).ToString("f0")));
                }
            }

            #region 发送短信

            if (canSend)
            {
                var result = await messageService.SendSMSVCode(mobile, strCode);
                if (result.ret == ResultType.Success)
                {
                    //发送成功，开始60秒倒计时 
                    return new OperateResult(true, "success", "短信验证码发送成功，请注意查收！", "", 0, "", 60);
                }
                else
                {
                    return OperateResult.Fail(result.msg);
                }
            }

            #endregion

            return OperateResult.Fail("短信验证码发送失败");
        }
        #endregion

        #region 发送邮件验证码

        private async Task<OperateResult> SendMailCodeAsync(string email)
        {
            //6位验证码
            string strCode = StringUtils.GetRandomNumber(6);
            bool canSend = true; //是否可发送标记

            //上一条邮箱发送的记录
            var sendLast = await sendRecordRepository.GetLatestCheckCode(email);
            if (sendLast != null)
            {
                //查找上一条记录发送的时间间隔
                TimeSpan timeSpan = System.DateTime.Now - sendLast.AutoTimeStamp.Value;
                if (timeSpan.TotalSeconds < 60)
                {
                    canSend = false; //默认间隔60秒 间隔时间太短,不允许发送
                    return new OperateResult(false, "fail", "发送间隔太短", "", 0, "", int.Parse((60 - timeSpan.TotalSeconds).ToString("f0")));
                }
            }

            #region 发送邮件

            if (canSend)
            {
                var result = await messageService.SendMailVCode(email, strCode);
                if (result.ret == ResultType.Success)
                {
                    //发送成功，开始60秒倒计时 
                    return new OperateResult(true, "success", "邮箱验证码发送成功，请登录邮箱查收！", "", 0, "", 60);
                }
                else
                {
                    return OperateResult.Fail(result.msg);
                }
            }

            #endregion

            return OperateResult.Fail("邮箱验证码发送失败");
        }
        #endregion

        #endregion        
    }
}
