using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Domain.Interface;
using SinGooCMS.MVCBase.Filter;
using SinGooCMS.Utility;
using SinGooCMS.Domain;
using SinGooCMS.Ado;
using SinGooCMS.Ado.Interface;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.MVCBase
{
    /// <summary>
    /// CMS基础类
    /// </summary>
    [TypeFilter(typeof(ValidateFilterAttribute))]
    public class CMSPageBase : Controller
    {
        public ICMSContext Context { get; set; }
        public ICacheStore CacheStore { get; set; }
        public ILogService LogService { get; set; }

        private readonly string customViewDir = "";
        public CMSPageBase(string _customViewDir)
        {
            this.customViewDir = _customViewDir;
        }

        #region MVC公共属性

        protected string AbsoluteUrl => Context.AbsoluteUrl;

        /// <summary>
        /// 控制器名称
        /// </summary>
        protected string ControllerName => Context.ControllerName;

        /// <summary>
        /// 方法名称
        /// </summary>
        protected string ActionName => Context.ActionName;

        protected bool IsPost =>
            Request.Method.Equals("POST");

        protected bool IsGet =>
            Request.Method.Equals("GET");

        #endregion        

        #region 分页相关        

        protected Pager pager = new Pager()
        {
            PageIndex = WebUtils.GetQueryVal<int>("page", 1),
            PageSize = WebUtils.GetQueryVal<int>("pagesize", 10)
        };

        protected string filter = "*";
        protected string condition = string.Empty;
        protected string searchKey = WebUtils.GetQueryString("key");
        protected string sort = "Sort asc,AutoID desc";

        #endregion

        #region 视图调用

        /// <summary>
        /// 不随客户端和语种变化的静态视图目录
        /// </summary>
        private string ViewStaticDir => Context.TemplDir;

        /// <summary>
        /// 显示模板，会根据客户端、语种设置在模板路径加前缀，如mobile/en/
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        protected new IActionResult View(string viewName, object model = null)
        {
            string viewPath = FileUtils.Combine(Context.ViewDir, viewName);
            if (!customViewDir.IsNullOrEmpty())
                viewPath = FileUtils.Combine(customViewDir, viewName);
#if DEBUG
            return base.View(viewPath, model);
#else
            if (!System.IO.File.Exists(SinGooBase.GetMapPath(viewPath)))
                return Content("cann't find the template file：" + viewPath);
            else
                return base.View(viewPath, model);
#endif
        }

        /// <summary>
        /// 原型显示模板 不受客户端多语种的设置影响，主要用在读取栏目的模板
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        protected IActionResult ViewStatic(string viewName, object model = null)
        {
            string viewPath = FileUtils.Combine(ViewStaticDir, viewName);
#if DEBUG
            return base.View(viewPath, model);
#else
            if (!System.IO.File.Exists(SinGooBase.GetMapPath(viewPath)))
                return Content("cann't find the template file：" + viewPath);
            else
                return base.View(viewPath, model);
#endif            
        }

        /// <summary>
        /// 原生的视图显示
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        protected IActionResult ViewOrigin(string viewName, object model = null)
        {
            return base.View(viewName, model);
        }

        #endregion
    }
}
