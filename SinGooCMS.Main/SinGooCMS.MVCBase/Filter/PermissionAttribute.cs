using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SinGooCMS.Ado;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.MVCBase.Filter
{
    /// <summary>
    /// 权限判断
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class PermissionAttribute : ActionFilterAttribute
    {
        /*
         * 权限判断说明：
         * 1）凡是HttpGet都按 OperationType.View(查看) 权限
         * 2）凡是操作都必须是Post方法，读取操作符 operationType
         * 3）判断账户所属的角色（一个或多个角色）是否拥有当前模块的操作
         */

        private readonly string moduleCode;
        private readonly string operationType;

        public PermissionAttribute(string _moduleCode, string _operationType = OperationType.View)
        {
            this.moduleCode = _moduleCode;
            this.operationType = _operationType;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var dbAccess = DbProvider.DbAccess;
            var module = dbAccess.GetModel<ModuleInfo>("select * from sys_Module where ModuleCode=@ModuleCode", new DbParameter[] { dbAccess.MakeParam("@ModuleCode", moduleCode) });

            //当前登录账号的角色
            var roles = SessionUtils.GetSession<AccountInfo>("Account")?.Roles; //账户可以有多个角色 如 "1,2,3"

            if (roles.IsNullOrEmpty())
                context.Result = new ContentResult() { Content = OperateResult.FailJson("NoLoginOrRoleNoSet", "未登录或者角色未设置") };
            else if (module == null)
                context.Result = new ContentResult() { Content = OperateResult.FailJson("ModuleNotFound", "未找到模块") };
            else
            {
                //超级管理员的角色ID                
                var superRoleID = dbAccess.GetValue<int>("select AutoID from sys_Role where RoleName=@SuperAdmin", new DbParameter[] { dbAccess.MakeParam("@SuperAdmin", "超级管理员") });
                if (roles.ToIntArray().Contains(superRoleID))
                    base.OnActionExecuting(context); //超级拥有最高权限，不判断权限
                else
                {
                    var purviews = dbAccess.GetList<PurviewInfo>(1000, $" ModuleID={module.AutoID} and RoleID in ({roles}) ");
                    if (purviews == null || !purviews.Where(p => p.OperateCode.Equals(operationType)).Any())
                        context.Result = new ContentResult() { Content = OperateResult.FailJson("AccessDenied", "权限不足，拒绝访问！") };
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
