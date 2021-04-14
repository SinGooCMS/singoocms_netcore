using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SinGooCMS.Utility;
using SinGooCMS.Plugins.SMS;
using SinGooCMS.Application;
using SinGooCMS.Application.Interface;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.MobMger
{
    public class SMSConfigController : ManagerPageBase
    {
        const string MODULECODE = "SMSConfig";
        private readonly IBaseConfigRepository baseConfigRepository;
        private readonly IMessageService messageService;

        public SMSConfigController(IBaseConfigRepository _baseConfigRepository, IMessageService _messageService)
        {
            this.baseConfigRepository = _baseConfigRepository;
            this.messageService = _messageService;
        }

        #region 短信配置

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Modify)]
        public async Task<string> Index(IFormCollection form)
        {
            var config = Context.SiteConfig;
            config.SMSClass = WebUtils.GetFormString("TextBox1");

            var smsConfig = new SMSConfig()
            {
                SMSUId = WebUtils.GetFormString("TextBox2"),
                SMSPwd = WebUtils.GetFormString("TextBox3"),
                APPID = WebUtils.GetFormString("TextBox4"),
                EndPoint = WebUtils.GetFormString("TextBox5"),
                SignName = WebUtils.GetFormString("TextBox6"),
                RegionId = WebUtils.GetFormString("TextBox7"),
            };

            if (await baseConfigRepository.UpdateConfigAsync(config))
            {
                if (config.SMSClass == "QcloudSMS")
                    await messageService.SaveAliyunSMSConfig(smsConfig);
                else
                    await messageService.SaveQCloudSMSConfig(smsConfig);

                await LogService.AddEvent("更新短信配置成功");
                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Index()
        {
            var smsConfig = Context.SiteConfig.SMSClass == "QcloudSMS"
                ? await messageService.LoadQCloudSMSConfig()
                : await messageService.LoadAliyunSMSConfig();

            return View("MobMger/SMSConfig.cshtml", smsConfig);
        }

        #endregion

        #endregion
    }
}
