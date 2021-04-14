using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Application;
using SinGooCMS.Utility;

namespace SinGooCMS.Platform
{
    /*
     * 类似于phpinfo的探针
     * 把固有的变量输出以作参考
     */

    public class SinGooInfoController : UIPageBase
    {
        private readonly IUser user;
        public SinGooInfoController(IUser _user)
        {
            this.user = _user;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            IList<VarInfo> envParams = new List<VarInfo>() {
                new VarInfo() {VarName = "RuntimeInformation.OSDescription",VarVal = RuntimeInformation.OSDescription,Remark = "系统名称"},
                new VarInfo() {VarName = "RuntimeInformation.OSArchitecture",VarVal = RuntimeInformation.OSArchitecture.ToString(),Remark = " 系统架构"},
                new VarInfo() {VarName = "RuntimeInformation.FrameworkDescription",VarVal = RuntimeInformation.FrameworkDescription,Remark = " .NET框架"}
            };
            foreach (var item in HttpContext.Request.Headers)
            {
                envParams.Add(new VarInfo()
                {
                    VarName = $"Context.Request.Headers[\"{item.Key}\"]",
                    VarVal = item.Value,
                    Remark = item.Key
                });
            }
            ViewBag.EnvParams = envParams; //环境参数

            IList<VarInfo> cmsParams = new List<VarInfo>() {
                new VarInfo { VarName="CacheStore.CacheVer.SoftName",VarVal= CacheStore.CacheVer.SoftName,Remark="软件名称" },
                new VarInfo { VarName="CacheStore.CacheVer.Ver",VarVal= CacheStore.CacheVer.Ver,Remark="软件版本" },
                new VarInfo { VarName="CacheStore.CacheVer.VerCodeNum",VarVal= CacheStore.CacheVer.VerCodeNum.ToString(),Remark="软件版本号" },
                new VarInfo { VarName="Context.DbProviderName",VarVal= Context.DbProviderName,Remark="数据库类型" },
                new VarInfo { VarName="Context.SiteConfig.SiteName",VarVal= Context.SiteConfig.SiteName,Remark="站点名称" },
                new VarInfo { VarName="Context.SiteConfig.SiteDomain",VarVal= Context.SiteConfig.SiteDomain,Remark="站点网址" },
                new VarInfo { VarName="Context.SiteConfig.BrowseType",VarVal= Context.SiteConfig.BrowseType,Remark="浏览方式" },
                new VarInfo { VarName="Context.SiteConfig.SEOKey",VarVal= Context.SiteConfig.SEOKey,Remark="全局keywords" },
                new VarInfo { VarName="Context.SiteConfig.SEODescription",VarVal= Context.SiteConfig.SEODescription,Remark="全局description" },
                new VarInfo { VarName="Context.SiteConfig.ServMailSMTP",VarVal= Context.SiteConfig.ServMailSMTP,Remark="邮件服务器" },
                new VarInfo { VarName="Context.SiteConfig.SMSClass",VarVal= Context.SiteConfig.SMSClass,Remark="短信接口" },
                new VarInfo { VarName="Context.SiteConfig.EnabledMobile",VarVal= Context.SiteConfig.EnabledMobile?"是":"否",Remark="是否启用移动端" },
                new VarInfo { VarName="Context.SiteConfig.EnableFileUpload",VarVal= Context.SiteConfig.EnableFileUpload?"是":"否",Remark="是否允许上传文件" },
                new VarInfo { VarName="Context.ClientType",VarVal= Context.ClientType.ToString(),Remark="客户端" },
                new VarInfo { VarName="Context.CurrLang",VarVal= Context.CurrLang,Remark="语种" },
                new VarInfo { VarName="Context.TemplDir",VarVal= Context.TemplDir,Remark="当前模板目录" },
                new VarInfo { VarName="Context.ViewDir",VarVal= Context.ViewDir,Remark="当前视图目录" },

                new VarInfo { VarName="user.UserID",VarVal= user.UserID.ToString(),Remark="会员ID" },
                new VarInfo { VarName="user.UserName",VarVal= user.UserName,Remark="会员名称" },
                new VarInfo { VarName="user.NickName",VarVal= user.NickName,Remark="会员昵称" },

                new VarInfo { VarName="Context.UploadFolder",VarVal= SinGooBase.UploadFolder,Remark="上传文件夹" },
                new VarInfo { VarName="Context.BakFolder",VarVal= SinGooBase.BackupFolder,Remark="备份文件夹" },
                new VarInfo { VarName="Context.ImportFolder",VarVal=SinGooBase.ImportFolder,Remark="导入文件夹" },
                new VarInfo { VarName="Context.ExportFolder",VarVal=SinGooBase.ExportFolder,Remark="导出文件夹" },

                new VarInfo { VarName="Context.SiteConfig.AllowOutPost",VarVal=Context.SiteConfig.AllowOutPost?"是":"否",Remark="允许外部Post" },
                new VarInfo { VarName="Context.IP",VarVal=Context.IP,Remark="IP地址" },
                new VarInfo { VarName="ConfigUtils.GetAppSetting<bool>(\"OpenIPStrategy\")",VarVal=ConfigUtils.GetAppSetting<bool>("OpenIPStrategy")?"是":"否",Remark="是否启用IP策略" },

                new VarInfo { VarName="SinGooBase.Token",VarVal= SinGooBase.Token,Remark="Token" },
                new VarInfo { VarName="Context.AbsoluteUrl",VarVal=Context.AbsoluteUrl,Remark="全网址" },
                new VarInfo { VarName="Context.ControllerName",VarVal= Context.ControllerName,Remark="控制器名称" },
                new VarInfo { VarName="Context.ActionName",VarVal= Context.ActionName,Remark="方法名称" },

                new VarInfo { VarName="SinGooBase.GetMapPath(\"/singooweblicence.txt\")",VarVal= SinGooBase.GetMapPath("/singooweblicence.txt"),Remark="获取全路径" }
            };

            ViewBag.CMSParams = cmsParams; //cms系统参数

            watch.Stop();
            ViewBag.RunMilliseconds = watch.ElapsedMilliseconds;
            return ViewOrigin("/views/singooinfo/index.cshtml");
        }
    }

    public class VarInfo
    {
        public string VarName { get; set; }
        public string VarVal { get; set; }
        public string Remark { get; set; }
    }
}
