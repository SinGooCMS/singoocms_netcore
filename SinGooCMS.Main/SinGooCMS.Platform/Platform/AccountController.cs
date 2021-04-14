using System;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Application.ViewModels;
using SinGooCMS.Application;
using SinGooCMS.Application.Interface;

namespace SinGooCMS.Platform
{
    public class AccountController : UIPageBase
    {
        private readonly IManagerService managerService;
        private readonly IEventLogRepository eventLogRepository;
        private readonly IManager manager;

        public AccountController(IManagerService _managerService, IEventLogRepository _eventLogRepository, IManager _manager)
        {
            this.managerService = _managerService;
            this.eventLogRepository = _eventLogRepository;
            this.manager = _manager;
        }

        #region 管理员登入

        [HttpPost]
        public async Task<string> Login(IFormCollection form)
        {
            var model = new AccountLoginViewModel()
            {
                AccountName = WebUtils.GetFormString("_accountname"),
                Password = WebUtils.GetFormString("_accountpwd"),
                ValidateCode = WebUtils.GetFormString("_checkcode")
            };

            if (!ConfigUtils.GetAppSetting<bool>("EnableSuperAdmin") && string.Compare(model.AccountName, "superadmin", true) == 0)
                return OperateResult.FailJson("Login_SuperAdminLoginDenied", "本站配置已拒绝超级管理员登录");
            else if (string.Compare(Context.ValidateCode, model.ValidateCode, true) != 0)
                return OperateResult.FailJson("ValidateCodeIncorrect", "验证码不正确");
            else
            {
                var lastLoginLog = await eventLogRepository.GetLatestLoginLog(model.AccountName);
                if (lastLoginLog != null && (DateTime.Now - lastLoginLog.AutoTimeStamp).Value.TotalSeconds < 1)
                    return OperateResult.FailJson("Login_LoginTooFrequently", "登录频率太频繁");
                else if (lastLoginLog != null && lastLoginLog.LoginFailCount >= Context.SiteConfig.TryLoginTimes
                    && (DateTime.Now - lastLoginLog.AutoTimeStamp).Value.TotalMinutes < 5)
                    return OperateResult.FailJson("Login_LoginFailTooMany", "连续登录失败多次，5分钟内禁止登录"); //重置密码可以解除锁定
                else
                {
                    return await managerService.Login(model)
                        ? OperateResult.SuccessJson("Login_Success", "登录管理平台成功", "/platform/main")
                        : OperateResult.FailJson("Login_Fail", "登录失败，用户名或者密码错误");
                }
            }
        }

        [HttpGet]
        [Route("/account/login.html")]
        [Route("/account/login")]
        public IActionResult Login()
        {
            if (manager.LoginAccount != null)
                return Redirect("/platform/main"); //已登录

            return base.ViewOrigin("/views/platform/login.cshtml");
        }

        #endregion                

        #region 管理员登出

        [HttpGet]
        public IActionResult Logout()
        {
            managerService.Logout();
            return new MVCBase.JumpUrlResult(SinGooBase.GetCaption("UserHasLoginOut"), "/account/login");
        }

        #endregion
    }
}
