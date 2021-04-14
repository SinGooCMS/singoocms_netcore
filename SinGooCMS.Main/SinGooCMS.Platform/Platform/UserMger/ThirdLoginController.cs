using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Plugins;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.MVCBase.Filter;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform.UserMger
{
    public class ThirdLoginController : ManagerPageBase
    {
        const string MODULECODE = "ThirdLoginMger";

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.SetEnableOrClose)]
        public async Task<string> Index(IFormCollection form)
        {
            return await Switch();
        }

        private async Task<string> Switch()
        {
            string key = WebUtils.GetFormString("opid");
            var lstOauth = OAuthConfig.LoadAll();
            string strLogoEvent = string.Empty;

            if (lstOauth != null && lstOauth.Count() > 0)
            {
                foreach (OAuthConfig item in lstOauth)
                {
                    if (item.OAuthKey == key)
                    {
                        item.IsEnabled = !item.IsEnabled;
                        strLogoEvent = (item.IsEnabled ? "开启" : "关闭") + "第三方登录：" + item.OAuthName;

                        break;
                    }
                }

                OAuthConfig.Save(lstOauth);
                await LogService.AddEvent(strLogoEvent);
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("UserMger/ThirdLogin.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public string DataJson()
        {
            string dataJson = OAuthConfig.LoadAll().ToJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":{}}}";
        }

        #endregion

        #endregion

        #region 配置

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Configuration)]
        public async Task<string> Config(IFormCollection form)
        {
            var lstConfig = OAuthConfig.LoadAll();
            if (lstConfig != null)
            {
                string strLogoEvent = string.Empty;
                foreach (OAuthConfig item in lstConfig)
                {
                    if (item.OAuthKey == WebUtils.GetQueryString("key"))
                    {
                        item.OAuthAppId = WebUtils.GetFormString("TextBox1");
                        item.OAuthAppKey = WebUtils.GetFormString("TextBox2");
                        strLogoEvent = "配置第三方登录[" + item.OAuthName + "]参数";

                        break;
                    }
                }

                OAuthConfig.Save(lstConfig);
                await LogService.AddEvent(strLogoEvent);
                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Config()
        {
            ViewBag.InitData = "{\"result\":" + OAuthConfig.GetOAuthConfig(WebUtils.GetQueryString("key")).ToJson().TrimStart('[').TrimEnd(']') + "}";
            return View("UserMger/ThirdLoginConfig.cshtml");
        }

        #endregion

        #endregion
    }
}
