using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;

namespace SinGooCMS.MVCBase.Filter
{
    /// <summary>
    /// 全局过滤器
    /// </summary>
    public class GlobalFilterAttribute : ActionFilterAttribute
    {
        private readonly ICMSContext cmsContext;
        public GlobalFilterAttribute(ICMSContext _cmsContext)
        {
            this.cmsContext = _cmsContext;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = ((Controller)context.Controller);

            //控制器名称
            controller.ViewBag.ControllerName = cmsContext.ControllerName;
            //方法名称
            controller.ViewBag.ActionName = cmsContext.ActionName;
            //当前使用的模板路径
            controller.ViewBag.mbpath = cmsContext.ViewDir;
            //当前栏目
            controller.ViewBag.CurrNode = cmsContext.CurrNode;
            //当前文章内容ID
            controller.ViewBag.CurrContId = cmsContext.CurrContId;
            //操作类型
            controller.ViewBag.ParamAction = WebUtils.GetQueryString("Action", OperationType.View); //为了区别控制器的Action，传参数的Action命名为 ParamAction
            //操作对象ID
            controller.ViewBag.OpID = WebUtils.GetQueryVal<int>("opid", -1);

            base.OnActionExecuting(context);
        }
    }
}
