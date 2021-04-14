using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using SinGooCMS.MVCBase;

namespace SinGooCMS.Application
{
    public class UIPageBase : CMSPageBase
    {
        /*
         * 系统约定
         * 1.url小写，浏览器不会区分大小写 如 /user/login
         * 2.get参数不带_，如 username，form参数带_，如 _username
         * 3.返回结果除基本数据类型外，都用 OperateResult 或者其 Json 表现形式。
         * 4.数据交互使用 Json 数据。如 object.ToJson的扩展方法。
         * 5.类、方法名首字母大写，字段，参数首字母小写。常量全大写字母。
         * 6.在Razor模板中注入，使用@inject
         * 7.调用cms @inject SinGooCMS.Domain.Interface.ICMSContent cms;
         * 8.调用上下文 @inject SinGooCMS.Domain.Interface.ICMSContext context;
         */
        public UIPageBase() : base("")
        {
            //
        }
    }
}
