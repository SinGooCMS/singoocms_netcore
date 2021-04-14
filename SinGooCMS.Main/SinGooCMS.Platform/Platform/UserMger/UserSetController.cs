using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.UserMger
{
    public class UserSetController : ManagerPageBase
    {
        const string MODULECODE = "UserSet";
        private IBaseConfigRepository baseConfigRepository;

        public UserSetController(IBaseConfigRepository _baseConfigRepository)
        {
            this.baseConfigRepository = _baseConfigRepository;
        }

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Modify)]
        public async Task<string> Index(IFormCollection form)
        {
            var config = Context.SiteConfig;
            if (config == null)
                config = new BaseConfigInfo();

            config.UserNameRule = WebUtils.GetFormString("TextBox2"); //会员名称规则 
            config.SysUserName = WebUtils.GetFormString("TextBox3"); //系统保留的会员名称
            config.RegAgreement = WebUtils.GetFormString("TextBox6"); //注册协议允许有标签
            config.RegGiveIntegral = WebUtils.GetFormVal<int>("TextBox7"); //注册赠送积分
            config.TgIntegral = WebUtils.GetFormVal<int>("TextBox8"); //推广积分
            config.VerifycodeForReg = WebUtils.GetFormString("CheckBox1") == "on";
            config.VerifycodeForLogin = WebUtils.GetFormString("CheckBox2") == "on";
            config.TryLoginTimes = WebUtils.GetFormVal<short>("TextBox9"); //登录尝试次数
            config.CookieTime = WebUtils.GetFormString("RadioButtonList10"); //登录状态保存时长
            config.FileCapacity = WebUtils.GetFormVal<int>("filespace") * 1024 * 1024;

            if (await baseConfigRepository.UpdateConfigAsync(config))
            {
                await LogService.AddEvent("更新会员配置成功");
                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("UserMger/UserSet.cshtml", Context.SiteConfig);
        }

        #endregion
    }
}
