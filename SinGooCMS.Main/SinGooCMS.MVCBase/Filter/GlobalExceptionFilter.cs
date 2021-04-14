using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.MVCBase.Filter
{
    /// <summary>
    /// 全局异常日志
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ICMSContext cmsContext;
        public GlobalExceptionFilter(ICMSContext _cmsContext)
        {
            this.cmsContext = _cmsContext;
        }

        public void OnException(ExceptionContext context)
        {
            this.cmsContext.Log.LogError(context.Exception, "全局异常");
        }
    }
}
