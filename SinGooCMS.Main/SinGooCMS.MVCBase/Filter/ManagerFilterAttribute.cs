using System;
using Microsoft.AspNetCore.Mvc.Filters;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;

namespace SinGooCMS.MVCBase.Filter
{
    /// <summary>
    /// 生产环境一定要是Release发布版本
    /// </summary>
    public class ManagerFilterAttribute : ActionFilterAttribute
    {
        private readonly IAccountRepository accountRepository;
        public ManagerFilterAttribute(IAccountRepository _accountRepository)
        {
            this.accountRepository = _accountRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
/*
#if DEBUG
            //调试的时候不需要频繁的登录
            if (SessionUtils.GetSession<AccountInfo>("Account") == null)
                SessionUtils.SetSession<AccountInfo>("Account", accountRepository.GetAdmin().GetAwaiter().GetResult());

            base.OnActionExecuting(context);
#else*/
            if (SessionUtils.GetSession<AccountInfo>("Account") == null)
                context.HttpContext.Response.Redirect("/account/login.html");
            else
                base.OnActionExecuting(context);
//#endif
        }
    }
}
