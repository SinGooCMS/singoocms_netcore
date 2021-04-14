using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.MVCBase.Extension
{
    public static class PartialExtension
    {
        /// <summary>
        /// 异步加载部分视图，part视图都放在inc目录下
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="partialViewName"></param>
        /// <returns></returns>
        public static async Task<IHtmlContent> ParseAsync(this IHtmlHelper htmlHelper, string partialViewName)
        {
            return await htmlHelper.PartialAsync(FileUtils.Combine(TemplateDir, partialViewName));
        }

        #region 显示默认的 页头、页尾、分页组件

        public static async Task<IHtmlContent> ShowHeader(this IHtmlHelper htmlHelper, string partialViewName = "")
        {
            if (partialViewName.IsNullOrEmpty())
                partialViewName = "inc/_header.cshtml";

            return await htmlHelper.PartialAsync(TemplateDir.TrimEnd('/') + "/" + partialViewName);
        }

        public static async Task<IHtmlContent> ShowPager(this IHtmlHelper htmlHelper, string partialViewName = "")
        {
            if (partialViewName.IsNullOrEmpty())
                partialViewName = "inc/_pager.cshtml";

            return await htmlHelper.PartialAsync(TemplateDir.TrimEnd('/') + "/" + partialViewName);
        }

        public static async Task<IHtmlContent> ShowFooter(this IHtmlHelper htmlHelper, string partialViewName = "")
        {
            if (partialViewName.IsNullOrEmpty())
                partialViewName = "inc/_footer.cshtml";

            return await htmlHelper.PartialAsync(TemplateDir.TrimEnd('/') + "/" + partialViewName);
        }

        #endregion

        /// <summary>
        /// 模板目录
        /// </summary>
        public static string TemplateDir
        {
            get
            {
                var template = PageUtils._cacheStore.CacheDefaultSiteTmpl;
                if (template != null)
                    return template.TemplatePath.EndsWith("/")
                        ? template.TemplatePath
                        : template.TemplatePath + "/";

                return "/views/templates/html/";

            }
        }
    }
}
