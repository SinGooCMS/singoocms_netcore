using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Utility;
using SinGooCMS.MVCBase.Filter;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform.TemplateMger
{
    public class TmplSelectorController : ManagerPageBase
    {
        const string MODULECODE = "TemplateMger";

        public TmplSelectorController()
        {
            //
        }

        /// <summary>
        /// 参数传过来的目录
        /// </summary>
        public string CurrFolder => WebUtils.GetQueryString("folder", string.Empty);
        /// <summary>
        /// 当前模板目录（包含模板目录）
        /// </summary>
        public string CurrTmplDir
        {
            get
            {
                string dir = (CurrFolder.Length == 0 || CurrFolder == "/") ? Context.TemplDir : FileUtils.Combine(Context.TemplDir, CurrFolder);
                return dir.EndsWith("/") ? dir : dir + "/";
            }
        }

        [HttpGet]
        [Permission(MODULECODE,OperationType.ViewTmplFile)]
        public IActionResult Index()
        {
            var tmplDir = WebUtils.GetQueryString("tmplDir");
            if (tmplDir.IsNullOrEmpty())
                tmplDir = CurrTmplDir;

            var absolutePath = SinGooBase.GetMapPath(tmplDir);

            if (!Directory.Exists(absolutePath))
                throw new Exception(Context.GetCaption("CMS_TmplDirNotExists")); //模板目录不存在

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
            ViewBag.ElementID = WebUtils.GetQueryString("elementid");
            return View("TemplateMger/TemplateFileListForSelect.cshtml");
        }

        #region Helper

        private string GetBaseFolder()
        {
            string queryString = WebUtils.GetQueryString("folder", string.Empty);
            if (queryString.Length == 0)
                return string.Empty;

            return (queryString + "/");
        }

        //html文件
        private string[] arrEditFileExt = { ".html", ".htm", ".cshtml", ".vml", ".css", ".js", ".txt", ".xml", ".json", ".xml", ".sql", ".xls" };
        //图片文件
        private string[] arrImageFileExt = { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
        //其它文件
        private string[] arrOtherFileExt = { ".zip", ".rar", ".doc", ".ppt", ".exe", ".pdf", ".mdb", ".psd", ".sitemap" };

        private string GetIcon(string strExt)
        {
            strExt = strExt.ToLower();

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

    #region 目录和文件
    public class TmplDir
    {
        /// <summary>
        /// 上级目录
        /// </summary>
        public string Folder { get; set; }
        /// <summary>
        /// 目录名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 最后写入时间
        /// </summary>
        public string LastWriteTime { get; set; }
    }
    public class TmplFile
    {
        /// <summary>
        /// 所属虚拟目录
        /// </summary>
        public string Folder { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 扩展名
        /// </summary>
        public string Ext { get; set; }
        /// <summary>
        /// 显示图标
        /// </summary>
        public string Ico { get; set; }
        /// <summary>
        /// 文件尺寸
        /// </summary>
        public long FileLength { get; set; }
        /// <summary>
        /// 最后写入时间
        /// </summary>
        public string LastWriteTime { get; set; }
    }
    #endregion
}
