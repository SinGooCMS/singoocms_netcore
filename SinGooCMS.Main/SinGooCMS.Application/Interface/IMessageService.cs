using SinGooCMS.Domain.Models;
using SinGooCMS.Plugins.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinGooCMS.Application.Interface
{
    /// <summary>
    /// 消息服务
    /// </summary>
    public interface IMessageService : IDependency
    {
        #region 发送消息

        /// <summary>
        /// 发邮件
        /// </summary>
        /// <param name="mailAddress">多个邮件用英文状态逗号分隔</param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<Result> SendMail(string mailAddress, string title, string content, string validateCode = "");

        /// <summary>
        /// 发短信
        /// </summary>
        /// <param name="phoneNums">多个手机用英文状态逗号分隔</param>
        /// <param name="tempCode">模板代码</param>
        /// <param name="tempParams">参数 如 code:123456</param>
        /// <returns></returns>
        Task<Result> SendSMS(string phoneNums, string tempCode, string tempParams, string validateCode = "");

        /// <summary>
        /// 加载阿里云短信配置
        /// </summary>
        /// <param name="configPath"></param>
        /// <returns></returns>
        Task<SMSConfig> LoadAliyunSMSConfig(string configPath = "/config/aliyunsms.config");
        /// <summary>
        /// 保存阿里云短信配置
        /// </summary>
        /// <param name="config"></param>
        /// <param name="configPath"></param>
        /// <returns></returns>
        Task SaveAliyunSMSConfig(SMSConfig config, string configPath = "/config/aliyunsms.config");
        /// <summary>
        /// 加载腾讯云短信配置
        /// </summary>
        /// <param name="configPath"></param>
        /// <returns></returns>
        Task<SMSConfig> LoadQCloudSMSConfig(string configPath = "/config/qcloudsms.config");
        /// <summary>
        /// 保存腾讯云短信配置
        /// </summary>
        /// <param name="config"></param>
        /// <param name="configPath"></param>
        /// <returns></returns>
        Task SaveQCloudSMSConfig(SMSConfig config, string configPath = "/config/qcloudsms.config");

        /// <summary>
        /// 注册成功后，发送欢迎消息
        /// </summary>
        /// <param name="userName"></param>
        Task SendWelcome(string userName);

        /// <summary>
        /// 发送站内信
        /// </summary>
        /// <param name="users"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task SendMsg(IEnumerable<UserInfo> users, string content);

        #endregion

        #region 发送验证码

        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="phoneNum"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Result> SendSMSVCode(string phoneNum, string code);

        /// <summary>
        /// 发送邮件验证码
        /// </summary>
        /// <param name="mailAddress"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Result> SendMailVCode(string mailAddress, string code);

        #endregion
    }
}
