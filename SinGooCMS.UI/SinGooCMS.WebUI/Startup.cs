using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Autofac;
using Senparc.CO2NET;
using Senparc.CO2NET.AspNet;
using Senparc.Weixin.Entities;
using Senparc.Weixin;
using Senparc.CO2NET.Cache;
using Senparc.CO2NET.Cache.Memcached;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin.RegisterServices;
using Senparc.Weixin.MP;
using SinGooCMS.Ado.Interface;
using SinGooCMS.Ado.DbAccess;
using SinGooCMS.Ado.DbMaintenance;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration _config)
        {
            Configuration = _config;
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DefaultModule>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStaticHttpContext();
            // 配置cookie策略
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
            });

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<MVCBase.Filter.GlobalExceptionFilter>();
                options.Filters.Add<MVCBase.Filter.GlobalFilterAttribute>();
                options.EnableEndpointRouting = false;
            })
            //.AddViewOptions((p)=>p.ViewEngines.Add(null))
            .AddRazorRuntimeCompilation() //不编译View视图
            .AddApplicationPart(typeof(Application.UIPageBase).Assembly)
            .AddApplicationPart(typeof(Platform.SinGooDefController).Assembly); //部分视图

            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));

            services.AddMemoryCache();
            /*
            services.AddDistributedMemoryCache();
            //session写入持久层（数据库）- 分布式
            services.AddDistributedSqlServerCache(option =>
            {
                option.ConnectionString = ConfigUtils.Configuration.GetConnectionString("DistributedCacheConnStr");
                option.DefaultSlidingExpiration = TimeSpan.FromSeconds(30 * 60);
                option.SchemaName = "dbo";
                option.TableName = "SqlserverCache";
            });*/

            services.AddSession(options =>
            {
                //session有效时长：30分钟
                options.IdleTimeout = TimeSpan.FromSeconds(30 * 60);
                options.Cookie.HttpOnly = true;
            });

            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "DataProtection"));

            //Automapper 注入
            services.AddAutoMapperSetup();
            services.AddResponseCompression();

            services.AddSenparcWeixinServices(Configuration); //Senparc.Weixin 注册（必须）
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            app.UseCookiePolicy();

            //显示错误信息
            app.UseStatusCodePagesWithRedirects("/error/{0}");
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    Exception ex = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;
                    string msg = ex == null ? string.Empty : ex.Message;

                    context.Response.ContentType = "text/html";
                    await context.Response.WriteAsync("<html lang=\"en\" ><head><meta charset=\"utf-8\" /></head><body>\r\n");
                    await context.Response.WriteAsync($"<div style='text-align:center'><img src='/include/error/warning.png'><br/>ERROR!<br>{System.Web.HttpUtility.HtmlEncode(msg)}<br>\r\n");
                    if (ex is FileNotFoundException)
                        await context.Response.WriteAsync("File error thrown!<br><br>\r\n");
                    await context.Response.WriteAsync("<a href=\"mailto:16826375@qq.com\">contact me and report this error!</a><br>http://www.singoo.top © 2020 SinGooCMS<br/>\r\n");
                    await context.Response.WriteAsync("</div></body></html>\r\n");
                    await context.Response.WriteAsync(new string(' ', 512));
                });
            });
            app.UseHsts();

            // 启动 CO2NET 全局注册，必须！
            // 关于 UseSenparcGlobal() 的更多用法见 CO2NET Demo：https://github.com/Senparc/Senparc.CO2NET/blob/master/Sample/Senparc.CO2NET.Sample.netcore3/Startup.cs
            var registerService = app.UseSenparcGlobal(env, senparcSetting.Value, globalRegister =>
            {
                #region CO2NET 全局配置

                globalRegister.RegisterTraceLog(ConfigTraceLog);//配置TraceLog

                #endregion
            }, true)
            //使用 Senparc.Weixin SDK
            .UseSenparcWeixin(senparcWeixinSetting.Value, weixinRegister =>
            {
                #region 微信相关配置

                #endregion
            });

            //允许访问的静态文件夹，除此之外直接访问是报错的，而且csthml是能直接访问，是受保护的文件
            string[] arrFolders = { "include", "upload", "views/templates", "views/platform/h5/inc" }; //允许可访问的静态文件夹
            foreach (var item in arrFolders)
            {
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new PhysicalFileProvider(FileUtils.Combine(Directory.GetCurrentDirectory(), item)),
                    RequestPath = "/" + item
                });
            }

            //静态类使用注入服务
            SinGooCMS.MVCBase.PageUtils._cacheStore = serviceProvider.GetService<ICacheStore>();

            app.UseStaticHttpContext();
            app.UseRouting();
            app.UseAuthorization(); //统一认证
            app.UseSession();
            app.UseResponseCompression();
            app.UseEndpoints(endpoints =>
            {
                #region URL路由配置

                /*
                 * cms默认的路由 栏目 article/栏目标识{.html?} 文章内容 article/detail/{id}{.html?} 
                 * {.html?}是指使用伪静态，不带.html使用mvc默认的路由
                 */
                endpoints.MapControllerRoute("ArticleDetailHtml", "article/detail/{Id}.html", new { controller = "Article", action = "Index" }); //伪静态
                endpoints.MapControllerRoute("ArticleDetail", "article/detail/{Id}", new { controller = "Article", action = "Index" });

                endpoints.MapControllerRoute("ArticleNodeHtml", "article/{UrlRewriteName}/{PageIndex}.html", new { controller = "Article", action = "Index" }, new { UrlRewriteName = @"((?!search|detail)[a-zA-Z0-9/-]+)" }); //伪静态
                endpoints.MapControllerRoute("ArticleNodeHtml", "article/{UrlRewriteName}.html", new { controller = "Article", action = "Index" }, new { UrlRewriteName = @"((?!search|detail)[a-zA-Z0-9/-]+)" }); //伪静态
                endpoints.MapControllerRoute("ArticleNode", "article/{UrlRewriteName}/{PageIndex?}", new { controller = "Article", action = "Index" }, new { UrlRewriteName = @"((?!search|detail)[a-zA-Z0-9/-]+)" });

                endpoints.MapControllerRoute("PlatformSchema", "platform/{controller}/{action}/{id?}"); //管理平台
                endpoints.MapControllerRoute("Default", "{controller}/{action}/{id?}", new { controller = "SinGooDef", action = "Index" });

                #endregion
            });

            // 启动 CO2NET 全局注册，必须！
            app.UseSenparcGlobal(env, senparcSetting.Value, register =>
            {
                register.ChangeDefaultCacheNamespace("CO2NETCache.netcore-3.1");

                //配置Memcached缓存（按需，独立）
                var memcachedConfigurationStr = senparcSetting.Value.Cache_Memcached_Configuration;
                var useMemcached = !string.IsNullOrEmpty(memcachedConfigurationStr) && memcachedConfigurationStr != "Memcached配置";

            });
        }

        /// <summary>
        /// 配置全局跟踪日志
        /// </summary>
        private void ConfigTraceLog()
        {
            //这里设为Debug状态时，/App_Data/SenparcTraceLog/目录下会生成日志文件记录所有的API请求日志，正式发布版本建议关闭

            //如果全局的IsDebug（Senparc.CO2NET.Config.IsDebug）为false，此处可以单独设置true，否则自动为true
            Senparc.CO2NET.Trace.SenparcTrace.SendCustomLog("系统日志", "系统启动");//只在Senparc.CO2NET.Config.IsDebug = true的情况下生效

            //全局自定义日志记录回调
            Senparc.CO2NET.Trace.SenparcTrace.OnLogFunc = () =>
            {
                //加入每次触发Log后需要执行的代码
            };

            Senparc.CO2NET.Trace.SenparcTrace.OnBaseExceptionFunc = ex =>
            {
                //加入每次触发BaseException后需要执行的代码
            };
        }
    }
}
