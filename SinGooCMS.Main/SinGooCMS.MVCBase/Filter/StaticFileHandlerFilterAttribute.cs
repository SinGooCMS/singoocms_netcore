using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.MVCBase.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class StaticFileHandlerFilterAttribute : ActionFilterAttribute
    {
        private readonly ICMSContext cmsContext;
        private readonly ICacheStore cacheStore;
        private readonly IPublisher publisher;
        private readonly IContentRepository contentRepository;
        private readonly IUser user;

        public StaticFileHandlerFilterAttribute(
            ICMSContext _cmsContext,
            ICacheStore _cacheStore,
            IPublisher _publisher,
            IContentRepository _contentRepository,
            IUser _user
            )
        {
            this.cmsContext = _cmsContext;
            this.cacheStore = _cacheStore;
            this.publisher = _publisher;
            this.contentRepository = _contentRepository;
            this.user = _user;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (cmsContext.SiteConfig.IsCreateStaticHTML)
            {
                //以下参照Startup.cs里的路由配置
                string controllerName = context.RouteData.Values["controller"].ToString().ToLower();
                string actionName = context.RouteData.Values["action"].ToString().ToLower();
                //栏目
                string nodeCode = context.RouteData.Values.ContainsKey("UrlRewriteName") ? context.RouteData.Values["UrlRewriteName"].ToString() : "";
                var node = nodeCode == "" ? null : cacheStore.CacheNodes.Where(p => p.NodeIdentifier == nodeCode).FirstOrDefault();
                //文章ID
                int id = context.RouteData.Values.ContainsKey("Id") ? context.RouteData.Values["Id"].ToInt() : 0;
                int pageIndex = context.RouteData.Values.ContainsKey("PageIndex") ? context.RouteData.Values["PageIndex"].ToInt() : 0;
                //针对栏目和文章生成缓存页
                if (controllerName.ToLower() == "article" && actionName.ToLower() == "index")
                {
                    string filePath = "";
                    string absoluteDir = AbsolutePageCacheDir;

                    if (node != null)
                    {
                        if (pageIndex == 0)
                            filePath = FileUtils.Combine(absoluteDir, publisher.Init(node).NodeHtmlIndexFileName);
                        else
                        {
                            var temp = publisher.Init(node).NodeHtmlPageFileName;
                            if (temp != null && temp.Count > 0)
                            {
                                var currPageFilePath = publisher.Init(node).NodeHtmlPageFileName.Where(p => p.Item1 == pageIndex).FirstOrDefault();
                                if (currPageFilePath != null)
                                    filePath = FileUtils.Combine(absoluteDir, currPageFilePath.Item2);
                            }
                        }
                    }
                    else if (id > 0)
                    {
                        //文章的栏目
                        node = contentRepository.GetSelfNode(id).GetAwaiter().GetResult();
                        //文章信息
                        filePath = FileUtils.Combine(absoluteDir, publisher.Init(id).ArticelHtmlFileName);
                    }

                    //判断栏目是否需要登录
                    if (node != null && node.NodeSetting.NeedLogin)
                    {
                        if (user.LoginUser.Value == null)
                            context.Result= new JumpUrlResult(SinGooBase.GetCaption("CMS_NodeNeedLoginToView"), $"/user/login?returnurl={node.NodeUrl}"); //需要登录
                        else if (!node.NodeSetting.EnableViewUGroups.ToIntArray().Contains(user.LoginUser.Value.GroupID))
                            context.Result = new ShowMsgResult(SinGooBase.GetCaption("CMS_TheUserGroupAccessDenied"));
                        else if (!node.NodeSetting.EnableViewULevel.ToIntArray().Contains(user.LoginUser.Value.LevelID))
                            context.Result = new ShowMsgResult(SinGooBase.GetCaption("CMS_TheUserLevelAccessDenied"));
                    }
                    else
                    {
                        if (File.Exists(filePath))
                        {
                            //更新浏览量
                            if (id > 0) contentRepository.UpdateHits(id);
                            //如果存在，直接读取文件
                            using FileStream fs = File.Open(filePath, FileMode.Open);
                            using StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                            //通过contentresult返回文件内容
                            context.Result = new ContentResult
                            {
                                Content = sr.ReadToEnd(),
                                ContentType = "text/html"
                            };
                        }
                    }
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //按照规则生成静态文件名称
            string controllerName = context.RouteData.Values["controller"].ToString().ToLower();
            string actionName = context.RouteData.Values["action"].ToString().ToLower();
            string nodeCode = context.RouteData.Values.ContainsKey("UrlRewriteName") ? context.RouteData.Values["UrlRewriteName"].ToString() : "";
            var node = nodeCode == "" ? null : cacheStore.CacheNodes.Where(p => p.NodeIdentifier == nodeCode).FirstOrDefault();
            int id = context.RouteData.Values.ContainsKey("Id") ? context.RouteData.Values["Id"].ToInt() : 0;
            int pageIndex = context.RouteData.Values.ContainsKey("PageIndex") ? context.RouteData.Values["PageIndex"].ToInt() : 0;

            IActionResult actionResult = context.Result;
            if (actionResult is ViewResult)
            {
                ViewResult viewResult = actionResult as ViewResult;
                //下面的代码就是执行这个ViewResult，并把结果的html内容放到一个StringBuiler对象中
                var services = context.HttpContext.RequestServices;
                var executor = services.GetRequiredService<ViewResultExecutor>();
                var option = services.GetRequiredService<IOptions<MvcViewOptions>>();
                var result = executor.FindView(context, viewResult);
                result.EnsureSuccessful(originalLocations: null);
                var view = result.View;
                StringBuilder builder = new StringBuilder();

                using (var writer = new StringWriter(builder))
                {
                    var viewContext = new ViewContext(
                        context,
                        view,
                        viewResult.ViewData,
                        viewResult.TempData,
                        writer,
                        option.Value.HtmlHelperOptions);

                    view.RenderAsync(viewContext).GetAwaiter().GetResult();
                    //这句一定要调用，否则内容就会是空的
                    writer.Flush();
                }

                //写入文件
                string html = builder.ToString();
                //替换脏词
                if (cmsContext.SiteConfig.BadWords.Length > 0)
                {
                    foreach (var item in cmsContext.SiteConfig.BadWords.Split(','))
                    {
                        html = html.Replace(item, cmsContext.SiteConfig.BWReplaceWord);
                    }
                }
                //压缩html
                if (cmsContext.SiteConfig.IsCompressHtml)
                    html = StringUtils.Compress(html);

                if (cmsContext.SiteConfig.IsCreateStaticHTML)
                {
                    #region 写入静态文件

                    if (controllerName.ToLower() == "article" && actionName.ToLower() == "index")
                    {
                        string filePath = "";
                        string absoluteDir = AbsolutePageCacheDir;
                        if (!Directory.Exists(absoluteDir))
                            Directory.CreateDirectory(absoluteDir);

                        if (node != null)
                        {
                            if (pageIndex == 0)
                                filePath = FileUtils.Combine(absoluteDir, publisher.Init(node).NodeHtmlIndexFileName);
                            else
                            {
                                var temp = publisher.Init(node).NodeHtmlPageFileName;
                                if (temp != null && temp.Count > 0)
                                {
                                    var currPageFilePath = publisher.Init(node).NodeHtmlPageFileName.Where(p => p.Item1 == pageIndex).FirstOrDefault();
                                    if (currPageFilePath != null)
                                        filePath = FileUtils.Combine(absoluteDir, currPageFilePath.Item2);
                                }
                            }
                        }
                        else if (id > 0)
                        {
                            //文章信息
                            filePath = FileUtils.Combine(absoluteDir, publisher.Init(id).ArticelHtmlFileName);
                        }

                        if (!string.IsNullOrEmpty(filePath))
                        {
                            using FileStream fs = File.Open(filePath, FileMode.Create);
                            using StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                            sw.Write(html); //保存到文件
                        }
                    }

                    #endregion
                }

                context.Result = new ContentResult
                {
                    Content = html,
                    ContentType = "text/html"
                };
            }
        }

        private string AbsolutePageCacheDir
        {
            get
            {
                string absoluteDir = SinGooBase.GetMapPath(SinGooBase.HtmlCacheFolder);
                string customDir = cmsContext.ViewDir.Replace(cmsContext.TemplDir, ""); //区分客户端、语种
                if (customDir != "")
                    absoluteDir = SinGooBase.GetMapPath(SinGooBase.HtmlCacheFolder) + customDir;

                return absoluteDir;
            }
        }
    }
}
