using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.TemplateMger
{
    public class TemplateFileController : ManagerPageBase
    {
        const string MODULECODE = "TemplateMger";
        private readonly ISiteTemplateRepository siteTemplateRepository;

        public TemplateFileController(ISiteTemplateRepository _siteTemplateRepository)
        {
            this.siteTemplateRepository = _siteTemplateRepository;
        }

        /// <summary>
        /// 参数传过来的目录
        /// </summary>
        public string CurrFolder => WebUtils.GetQueryString("folder");
        /// <summary>
        /// 当前模板目录（包含模板目录）
        /// </summary>
        public string CurrTmplDir
        {
            get
            {
                var tmpl = siteTemplateRepository.FindAsync(OpID).GetAwaiter().GetResult();
                var tmplDir = tmpl?.TemplatePath ?? Context.TemplDir;

                string dir = (CurrFolder.Length == 0 || CurrFolder == "/")
                    ? tmplDir
                    : FileUtils.Combine(tmplDir, CurrFolder);

                return dir.EndsWith("/") ? dir : dir + "/";
            }
        }

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.DeleteTmplFile)]
        public async Task<string> Delete(IFormCollection form)
        {
            string jumpFolder = WebUtils.GetFormVal<string>("_CurrFolder", CurrFolder);
            string strFilePath = FileUtils.Combine(SinGooBase.GetMapPath(WebUtils.GetFormVal<string>("_CurrTmplDir")), WebUtils.GetFormString("filename"));
            if (System.IO.File.Exists(strFilePath))
            {
                System.IO.File.Delete(strFilePath);
                await LogService.AddEvent("删除模板文件:" + strFilePath + " 成功");
                return OperateResult.SuccessJson("OperationSuccess", "操作成功", $"/platform/TemplateFile/Index?opid={base.OpID}&folder={jumpFolder}");
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get显示视图

        [HttpGet]
        [Permission(MODULECODE, OperationType.ViewTmplFile)]
        public IActionResult Index()
        {
            var absolutePath = SinGooBase.GetMapPath(CurrTmplDir);
            if (!absolutePath.StartsWith(SinGooBase.GetMapPath(SinGooBase.TemplateBasePath)))
                throw new Exception(Context.GetCaption("AccessUnauthorized")); //只能访问模板目录

            ViewBag.ViewUp = CurrTmplDir != Context.TemplDir ? "block" : "none";
            var parentPath = CurrTmplDir.Replace(Context.TemplDir, "");
            ViewBag.ParentPath = parentPath == ""
                ? "/"
                : parentPath.TrimEnd('/').Substring(0, parentPath.TrimEnd('/').IndexOf("/") + 1);

            var dirParent = new DirectoryInfo(absolutePath); //当前根目录
            var dirChils = dirParent.GetDirectories(); //所属所有子目录
            var lstDir = new List<TmplDir>();
            dirChils.ForEach(item =>
            {
                lstDir.Add(new TmplDir()
                {
                    Folder = GetBaseFolder(),
                    Name = item.Name,
                    LastWriteTime = item.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss")
                });
            });

            ViewBag.Directories = lstDir; //所属所有子目录

            FileInfo[] files = dirParent.GetFiles("*"); //所属所有文件
            var lstFile = new List<TmplFile>();
            files.ForEach(item =>
            {
                lstFile.Add(new TmplFile()
                {
                    Folder = CurrTmplDir,
                    Name = item.Name,
                    Ext = item.Extension,
                    Ico = GetIcon(item.Extension.ToLower()),
                    FileLength = item.Length,
                    LastWriteTime = item.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss")
                });
            });

            ViewBag.Files = lstFile; //所属所有文件
            ViewBag.CurrFolder = CurrFolder;
            ViewBag.CurrTmplDir = CurrTmplDir;

            var dict = new Dictionary<string, string[]>
            {
                { "EditFileExt", arrEditFileExt },
                { "ImageFileExt", arrImageFileExt },
                { "OtherFileExt", arrOtherFileExt }
            };

            return View("TemplateMger/TemplateFileList.cshtml", dict);
        }

        #endregion

        #region Helper

        private string GetBaseFolder()
        {
            string folder = WebUtils.GetQueryString("folder");
            if (folder.Length == 0)
                return string.Empty;

            return (folder + "/");
        }

        //html文件
        private readonly string[] arrEditFileExt = { ".html", ".htm", ".cshtml", ".vml", ".css", ".js", ".txt", ".xml", ".json", ".xml", ".sql", ".xls" };
        //图片文件
        private readonly string[] arrImageFileExt = { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
        //其它文件
        private readonly string[] arrOtherFileExt = { ".zip", ".rar", ".doc", ".ppt", ".exe", ".pdf", ".mdb", ".psd", ".sitemap" };

        private string GetIcon(string strExt)
        {
            if (arrEditFileExt.Contains(strExt))
                return strExt.TrimStart('.') + ".gif";
            else if (arrImageFileExt.Contains(strExt))
                return strExt.TrimStart('.') + ".gif";
            else if (arrOtherFileExt.Contains(strExt))
                return strExt.TrimStart('.') + ".gif";

            return "other.gif";
        }

        #endregion
    }
}
