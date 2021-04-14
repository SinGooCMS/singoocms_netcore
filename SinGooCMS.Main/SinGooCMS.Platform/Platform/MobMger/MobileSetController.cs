using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.MVCBase.Filter;


namespace SinGooCMS.Platform.MobMger
{
    public class MobileSetController : ManagerPageBase
    {
        const string MODULECODE = "MobileClientSet";
        private readonly ICMSContext context;
        private readonly IBaseConfigRepository baseConfigRepository;

        public MobileSetController(ICMSContext _context, IBaseConfigRepository _baseConfigRepository)
        {
            this.context = _context;
            this.baseConfigRepository = _baseConfigRepository;
        }

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Modify)]
        public async Task<string> Index(IFormCollection form)
        {
            var config = context.SiteConfig;
            config.EnabledMobile = WebUtils.GetFormString("ismobopen") == "on";

            if (await baseConfigRepository.UpdateConfigAsync(config))
            {
                await LogService.AddEvent(config.EnabledMobile ? "启用移动端网站" : "关闭移动端网站");
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
            ViewBag.InitData = "{\"result\":{\"data\":{\"EnabledMobile\":" + (context.SiteConfig.EnabledMobile ? "true" : "false") + "}}}";
            return View("MobMger/MobileSet.cshtml");
        }

        #endregion
    }
}
