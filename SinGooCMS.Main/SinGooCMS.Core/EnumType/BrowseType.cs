using System.ComponentModel;

namespace SinGooCMS
{
    /// <summary>
    /// 浏览方式
    /// </summary>
    public enum BrowseType
    {
        [Description("MVC路由")]
        MvcDefault,
        [Description("伪静态")]
        HtmlRewrite
    }
}
