using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.MVCBase.Filter
{
    /// <summary>
    /// 验证软件有效性
    /// </summary>
    internal class ValidateFilterAttribute : ActionFilterAttribute
    {
        private readonly IIPStrategyRepository iPStrategyRepository;
        private readonly ILogService logService;
        private readonly ICMSContext cmsContext;
        private readonly ICacheStore cacheStore;

        public ValidateFilterAttribute(
                IIPStrategyRepository _iPStrategyRepository,
                ILogService _logService,
                ICMSContext _cmsContext,
                ICacheStore _cacheStore
            )
        {
            this.iPStrategyRepository = _iPStrategyRepository;
            this.logService = _logService;
            this.cmsContext = _cmsContext;
            this.cacheStore = _cacheStore;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string ip = cmsContext.IP;

            #region 验证

            if (CheckIPStrategyDeny(ip))
                throw new Exception($"access denied from the IP:{ip}");
            else if (cmsContext.SiteConfig == null)
                throw new Exception("the base config uncompleted,config is null.");
            else if (!cmsContext.SiteConfig.AllowOutPost && !CheckIsCurrPost(context.HttpContext))
                throw new Exception("access denied when the post from outsite");            
            else
            {
                if (cmsContext.SiteConfig.VisitRec && cmsContext.ControllerName != "VisitorLog")
                    logService.SaveVisitorInfo();

                base.OnActionExecuting(context);
            }

            #endregion            
        }

        #region check各项参数        

        #region 访问IP是否被策略拒绝
        private bool CheckIPStrategyDeny(string ip)
        {
            if (ConfigUtils.GetAppSetting<bool>("OpenIPStrategy")
                && iPStrategyRepository.IsDeny(ip, cacheStore.CacheIPStrategies))
                return true; //开启是策略验证并且是拒绝的

            return false;
        }
        #endregion

        #region 判断是否本站post

        private bool CheckIsCurrPost(HttpContext context)
        {
            string referer = context.Request.Headers["Referer"];
            string host = context.Request.Headers["Host"];

            if (context.Request.Method == "POST")
            {
                if (referer.IsNullOrEmpty())
                    return false;
                else if (context.Request.Headers["User-Agent"].ToString() != "Shockwave Flash"
                    && context.Request.Headers["Script_Name"].ToString().IndexOf("Weixin") == -1
                    && !(referer.Substring(7, host.Length) == host || referer.Substring(8, host.Length) == host))
                    return false;
            }

            return true;
        }

        #endregion

        #endregion
    }
}
