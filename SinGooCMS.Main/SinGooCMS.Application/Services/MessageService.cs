using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using SinGooCMS.Application.Interface;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Plugins.Email;
using SinGooCMS.Plugins.SMS;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly ICacheStore cacheStore;
        private readonly ISendRecordRepository sendRecordRepository;
        private readonly IMessageRepository messageRepository;
        private readonly ISMSTemplateRepository sMSTemplateRepository;
        private readonly IMapper mapper;

        public MessageService(ICacheStore _cacheStore,
            ISendRecordRepository _sendRecordRepository,
            IMessageRepository _messageRepository,
            ISMSTemplateRepository _sMSTemplateRepository,
            IMapper _mapper)
        {
            this.cacheStore = _cacheStore;
            this.sendRecordRepository = _sendRecordRepository;
            this.messageRepository = _messageRepository;
            this.sMSTemplateRepository = _sMSTemplateRepository;
            this.mapper = _mapper;
        }

        #region 发送消息

        public async Task<Result> SendMail(string mailAddress, string title, string content, string validateCode = "")
        {
            var email = MailProvider.Instance;
            email.Config = mapper.Map<MailConfig>(cacheStore.CacheBaseConfig);
            var result = await email.SendEmailAsync(mailAddress, title, content);
            if (result.isSuccess)
                await sendRecordRepository.AddAsync(new SendRecordInfo()
                {
                    SenderType = SenderType.Mail.ToString(),
                    MsgType = validateCode == "" ? SenderMsgType.Common.ToString() : SenderMsgType.ValidateCode.ToString(),
                    MsgBody = content,
                    ValidateCode = validateCode,
                    ReciverMedia = mailAddress,
                    ReciverName = "",
                    Status = (byte)(result.isSuccess ? 1 : 0),
                    ReturnMsg = result.errMsg,
                    AutoTimeStamp = DateTime.Now
                });

            return result.isSuccess
                ? Result.success
                : OperateResult.Fail(result.errMsg);
        }

        public async Task<Result> SendSMS(string phoneNums, string tempCode, string tempParams, string validateCode = "")
        {
            var sms = SMSProvider.Create(cacheStore.CacheBaseConfig.SMSClass);
            if (cacheStore.CacheBaseConfig.SMSClass == "AliYunSMS")
                sms.Config = await LoadAliyunSMSConfig();
            else if (cacheStore.CacheBaseConfig.SMSClass == "QCloudSMS")
                sms.Config = await LoadQCloudSMSConfig();

            var result = await sms.SendMsgAsync(phoneNums, tempCode, tempParams);
            await sendRecordRepository.AddAsync(new SendRecordInfo()
            {
                SenderType = SenderType.SMS.ToString(),
                MsgType = validateCode == "" ? SenderMsgType.Common.ToString() : SenderMsgType.ValidateCode.ToString(),
                MsgBody = $"调用模板{tempCode}",
                ValidateCode = validateCode,
                ReciverMedia = phoneNums,
                ReciverName = "",
                Status = (byte)(result.isSuccess ? 1 : 0),
                ReturnMsg = result.errMsg,
                AutoTimeStamp = DateTime.Now
            });

            return result.isSuccess
                ? Result.success
                : OperateResult.Fail(result.errMsg);
        }

        public async Task<SMSConfig> LoadAliyunSMSConfig(string configPath = "/config/aliyunsms.config")
        {
            string xmlString = await FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath(configPath));
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            return new SMSConfig()
            {
                SMSUId = doc.SelectSingleNode("AliYunSMS/AccessKeyID").InnerText,
                SMSPwd = doc.SelectSingleNode("AliYunSMS/AccessKeySecret").InnerText,
                APPID = string.Empty,
                EndPoint = doc.SelectSingleNode("AliYunSMS/EndPoint").InnerText,
                SignName = doc.SelectSingleNode("AliYunSMS/SignName").InnerText,
                RegionId = doc.SelectSingleNode("AliYunSMS/RegionId").InnerText
            };
        }

        public async Task<SMSConfig> LoadQCloudSMSConfig(string configPath = "/config/qcloudsms.config")
        {
            string xmlString = await FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath(configPath));
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            return new SMSConfig()
            {
                SMSUId = doc.SelectSingleNode("QCloudSMS/SecretId").InnerText,
                SMSPwd = doc.SelectSingleNode("QCloudSMS/SecretKey").InnerText,
                APPID = doc.SelectSingleNode("QCloudSMS/APPID").InnerText,
                EndPoint = doc.SelectSingleNode("QCloudSMS/EndPoint").InnerText,
                SignName = doc.SelectSingleNode("QCloudSMS/SignName").InnerText,
                RegionId = doc.SelectSingleNode("QCloudSMS/RegionId").InnerText
            };
        }

        public async Task SaveAliyunSMSConfig(SMSConfig config, string configPath = "/config/aliyunsms.config")
        {
            string str = string.Format($"<AliYunSMS><AccessKeyID>{config.SMSUId}</AccessKeyID><AccessKeySecret>{config.SMSPwd}</AccessKeySecret><EndPoint>{config.EndPoint}</EndPoint><SignName>{config.SignName}</SignName><RegionId>{config.RegionId}</RegionId></AliYunSMS>");
            await File.WriteAllTextAsync(SinGooBase.GetMapPath(configPath), str);
        }

        public async Task SaveQCloudSMSConfig(SMSConfig config, string configPath = "/config/qcloudsms.config")
        {
            string str = string.Format($"<QCloudSMS><SecretId>{config.SMSUId}</SecretId><SecretKey>{config.SMSPwd}</SecretKey><AppID>{config.APPID}</AppID><EndPoint>{config.EndPoint}</EndPoint><SignName>{config.SignName}</SignName><RegionId>{config.RegionId}</RegionId></QCloudSMS>");
            await File.WriteAllTextAsync(SinGooBase.GetMapPath(configPath), str);
        }

        public async Task SendWelcome(string userName)
        {
            var setting = cacheStore.CacheBaseConfig.GetByKey("SendRegWelcome");
            await SendMsg(new List<UserInfo>() { new UserInfo() { UserName = userName } }, setting.KeyValue.Replace("${username}", userName));
        }

        public async Task SendMsg(IEnumerable<UserInfo> users, string content)
        {
            var lstReceiver = new List<string>();
            users.ForEach(item =>
            {
                lstReceiver.Add(item.UserName);
            });

            await messageRepository.SendMsg(lstReceiver, content);
        }

        #endregion

        #region 发送验证码

        public async Task<Result> SendMailVCode(string mailAddress, string code)
        {
            var setting = cacheStore.CacheBaseConfig.GetByKey("SendMailValidateCode");
            return await SendMail(mailAddress, setting.KeyDesc, setting.KeyValue.Replace("${code}", code), code);
        }

        public async Task<Result> SendSMSVCode(string phoneNums, string code)
        {
            //await SendSMS(phoneNums, "SendSMSValidateCode", "code:" + code, code);
            var tmpl = await sMSTemplateRepository.Get("VerifyCode");
            if (tmpl != null)
            {
                return await SendSMS(phoneNums, tmpl.TemplCode, tmpl.TemplKeys, code);
            }

            return Result.fail;
        }


        #endregion
    }
}
