using System;
using Microsoft.AspNetCore.Mvc.Filters;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.MVCBase.Filter
{
    public class MemberFilterAttribute : ActionFilterAttribute
    {
        private readonly IUser user;

        public MemberFilterAttribute(IUser _user)
        {
            this.user = _user;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (user.LoginUser?.Value == null)
                context.HttpContext.Response.Redirect("/user/login");
            else
                base.OnActionExecuting(context);
        }
    }
}
