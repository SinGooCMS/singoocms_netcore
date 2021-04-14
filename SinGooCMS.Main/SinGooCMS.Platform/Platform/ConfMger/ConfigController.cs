using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Plugins.Email;
using SinGooCMS.Application.Interface;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.ConfMger
{
    public class ConfigController : ManagerPageBase
    {
        private readonly IBaseConfigRepository baseConfigRepository;
        private readonly IMessageService messageService;
        private readonly IPublisher publisher;

        public ConfigController(IBaseConfigRepository _baseConfigRepository,
            IMessageService _messageService,
            IPublisher _publisher)
        {
            this.baseConfigRepository = _baseConfigRepository;
            this.messageService = _messageService;
            this.publisher = _publisher;
        }

        #region 基本配置

        #region Post相关操作

        [HttpPost]
        [Permission("BaseConfig", OperationType.Modify)]
        public async Task<string> Index(IFormCollection form)
        {
            var config = Context.SiteConfig ?? new BaseConfigInfo();

            //赋值
            config.SiteName = WebUtils.GetFormString("TextBox1");
            config.SiteDomain = WebUtils.GetFormString("TextBox2").TrimEnd('/');
            config.SiteLogo = WebUtils.GetFormString("TextBox4");
            config.SiteBanner = WebUtils.GetFormString("TextBox10");
            config.CopyRight = WebUtils.GetFormString("TextBox5");
            config.IcpNo = WebUtils.GetFormString("TextBox6");
            config.DefaultLang = WebUtils.GetFormString("showlang");
            config.BrowseType = WebUtils.GetFormString("DropDownList10");
            config.UrlRewriteExt = WebUtils.GetFormString("urlwriteext");
            config.GlobalPageSize = WebUtils.GetFormVal<short>("globalpagesize", 10);
            config.IsCreateStaticHTML = WebUtils.GetFormString("IsCreateStaticHTML") == "on";
            config.HtmlFileExt = WebUtils.GetFormString("htmlext");
            config.IsCompressHtml = WebUtils.GetFormString("IsCompressHtml") == "on";

            if (await baseConfigRepository.UpdateConfigAsync(config))
            {
                //清除缓存页
                publisher.Clear();

                //设置前端显示默认的语言                
                CookieUtils.SetCookie("lang", config.DefaultLang);

                await LogService.AddEvent("更新基本配置成功");
                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission("BaseConfig")]
        public IActionResult Index()
        {
            return View("ConfMger/BaseConfig.cshtml", CacheStore.CacheBaseConfig);
        }

        #endregion

        #endregion

        #region 邮件服务

        #region Post相关操作

        [HttpPost]
        [Permission("EmailService", OperationType.Modify)]
        public async Task<string> Mail(IFormCollection form)
        {
            var config = CacheStore.CacheBaseConfig ?? new BaseConfigInfo();

            //赋值
            config.ServMailAccount = WebUtils.GetFormString("TextBox1");
            config.ServMailUserName = WebUtils.GetFormString("TextBox2");
            string strMailUserPwd = WebUtils.GetFormString("TextBox3");
            if (!string.IsNullOrEmpty(strMailUserPwd))
                config.ServMailUserPwd = strMailUserPwd;
            config.ServMailSMTP = WebUtils.GetFormString("TextBox4");
            config.ServMailPort = WebUtils.GetFormVal<int>("TextBox5");
            config.ServMailIsSSL = WebUtils.GetFormString("CheckBox6") == "on";

            if (!string.IsNullOrEmpty(config.ServMailAccount) && !config.ServMailAccount.IsEmail())
                return OperateResult.FailJson("User_EmailFormatIncorrect", "邮箱地址格式不正确");
            else
            {
                if (await baseConfigRepository.UpdateConfigAsync(config))
                {
                    await LogService.AddEvent("更新邮件配置成功");
                    return OperateResult.successJson;
                }
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission("EmailService")]
        public async Task<string> SendTestMail()
        {
            var config = CacheStore.CacheBaseConfig;
            string reciver = WebUtils.GetFormString("txtReciver");
            if (reciver.IsEmail())
            {
                var result = await messageService.SendMail(reciver, config.SiteName + "的测试邮件", "这是一封测试邮件，如果您收到此邮件，表示邮件服务有效！");
                return result.ToOperateResultJson();
            }
            else
                return OperateResult.FailJson("User_EmailFormatIncorrect", "邮箱地址格式不正确");
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission("EmailService")]
        public IActionResult Mail()
        {
            var config = CacheStore.CacheBaseConfig;
            var dict = new Dictionary<string, string>();
            dict.Add("ServMailAccount", config.ServMailAccount);
            dict.Add("ServMailUserName", config.ServMailUserName);
            dict.Add("ServMailUserPwd", config.ServMailUserPwd);
            dict.Add("ServMailSMTP", config.ServMailSMTP);
            dict.Add("ServMailPort", config.ServMailPort.ToString());
            dict.Add("ServMailIsSSL", config.ServMailIsSSL.ToString());

            var dataJson = dict.ToJson();
            ViewBag.InitData = "{\"result\":{\"data\":" + dataJson + "}}";

            return View("ConfMger/MailConfig.cshtml");
        }

        #endregion

        #endregion

        #region 搜索优化

        #region Post相关操作

        [HttpPost]
        [Permission("GlobalSEO", OperationType.Modify)]
        public async Task<string> SiteSeo(IFormCollection form)
        {
            var config = CacheStore.CacheBaseConfig ?? new BaseConfigInfo();

            //赋值
            config.SEOKey = WebUtils.GetFormString("TextBox1");
            config.SEODescription = WebUtils.GetFormString("TextBox2");

            if (await baseConfigRepository.UpdateConfigAsync(config))
            {
                //清除缓存页
                publisher.Clear();

                await LogService.AddEvent("更新全局搜索优化配置成功");
                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission("GlobalSEO")]
        public IActionResult SiteSeo()
        {
            var config = CacheStore.CacheBaseConfig;
            var dict = new Dictionary<string, string>();
            dict.Add("SEOKey", config.SEOKey);
            dict.Add("SEODescription", config.SEODescription);

            var dataJson = dict.ToJson();
            ViewBag.InitData = "{\"result\":{\"data\":" + dataJson + "}}";

            return View("ConfMger/SiteSeo.cshtml");
        }

        #endregion

        #endregion

        #region 其它配置

        #region Post相关操作

        [HttpPost]
        [Permission("OtherConfig", OperationType.Modify)]
        public async Task<string> Other(IFormCollection form)
        {
            var config = CacheStore.CacheBaseConfig ?? new BaseConfigInfo();

            //赋值
            config.BadWords = WebUtils.GetFormString("badword");
            config.BWReplaceWord = WebUtils.GetFormString("bwreplaceword");
            config.DefaultHtmlEditor = WebUtils.GetFormString("TextBox6");
            config.STATLink = WebUtils.GetFormString("TextBox7");
            config.ReciverEMail = WebUtils.GetFormString("FeedbackRlyEmail");
            config.VisitRec = WebUtils.GetFormString("EnabledSaveCustomInfo") == "on";
            config.AllowOutPost = WebUtils.GetFormString("EnabledAllowOutPost") == "on";
            config.SiteCapacity = WebUtils.GetFormVal<long>("sitecapacity");

            if (await baseConfigRepository.UpdateConfigAsync(config))
            {
                //清除缓存页
                publisher.Clear();

                await LogService.AddEvent("更新其它配置成功");
                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission("OtherConfig")]
        public IActionResult Other()
        {
            var config = CacheStore.CacheBaseConfig;
            var dict = new Dictionary<string, object>();
            dict.Add("BadWords", config.BadWords);
            dict.Add("BWReplaceWord", config.BWReplaceWord);
            dict.Add("DefaultHtmlEditor", config.DefaultHtmlEditor);
            dict.Add("STATLink", config.STATLink);
            dict.Add("ReciverEMail", config.ReciverEMail);
            dict.Add("VisitRec", config.VisitRec);
            dict.Add("AllowOutPost", config.AllowOutPost);
            dict.Add("SiteCapacity", config.SiteCapacity);

            var dataJson = dict.ToJson();
            ViewBag.InitData = "{\"result\":{\"data\":" + dataJson + "}}";

            return View("ConfMger/ExtConfig.cshtml");
        }

        #endregion

        #endregion
    }
}
