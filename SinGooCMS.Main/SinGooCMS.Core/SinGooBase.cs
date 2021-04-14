using System;
using System.IO;
using System.Xml;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS
{
    /// <summary>
    /// 基础类
    /// </summary>
    [Serializable]
    public class SinGooBase
    {
        #region DES加解密

        /// <summary>
        /// 密钥
        /// </summary>
        const string DESKEY = "jsonlee-2021-01-25-16826375@qq.com-www.singoo.top";
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string DesEncode(string strSource) => DEncryptUtils.DESEncrypt(strSource, DESKEY);
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string DesDecode(string strSource) => DEncryptUtils.DESDecrypt(strSource, DESKEY);

        #endregion

        /// <summary>
        /// 是否http
        /// </summary>
        public static bool IsHttp => SinGooCMS.Utility.UtilsBase.HttpContext != null;

        /// <summary>
        /// token
        /// </summary>
        public static string Token =>
            System.Guid.NewGuid().ToString().Replace("-", "");

        /// <summary>
        /// 获取多语种提示 配置文件如/include/language/zh-cn.xml
        /// </summary>
        /// <param name="captionKey"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public static string GetCaption(string captionKey, string lang = null)
        {
            if (lang == null)
                lang = CurrLang;

            string xmlFilePath = GetMapPath($"/include/language/{lang}.xml");
            if (File.Exists(xmlFilePath))
            {
                var doc = new XmlDocument();
                doc.Load(xmlFilePath);

                var node = doc.SelectSingleNode($"root//data[@name='{captionKey}']");
                return node != null
                    ? node.InnerText.Trim() //有多语种定义
                    : captionKey; //没有定义，原样返回
            }

            return captionKey;
        }

        /// <summary>
        /// 系统当前使用的语种
        /// </summary>
        public static string CurrLang
        {
            get
            {
                if (!IsHttp) return "zh-cn";

                string strLang = CookieUtils.GetCookie("lang"); //"zh-cn"; //默认的
                if (strLang.IsNullOrEmpty())
                {
                    strLang = "zh-cn";
                    CookieUtils.SetCookie("lang", strLang);
                }

                return strLang;
            }
        }

        #region 各种目录        

        /// <summary>
        /// 取绝对路径
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public static string GetMapPath(string strPath) => SystemUtils.GetMapPath(strPath.Replace("~/", "/"));

        /// <summary>
        /// 运行目录
        /// </summary>
        public static string BaseDir =>
            AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// html页面缓存文件夹
        /// </summary>
        public static string HtmlCacheFolder
        {
            get
            {
                string folder = "/htmlcache/";
                var physicalFolder = GetMapPath(folder);
                if (!Directory.Exists(physicalFolder))
                    Directory.CreateDirectory(physicalFolder);

                return folder;
            }
        }

        /// <summary>
        /// 模板文件夹存放的目录
        /// </summary>
        public static string TemplateBasePath
        {
            get
            {
                string folder = $"/views/templates/";
                var physicalFolder = GetMapPath(folder);
                if (!Directory.Exists(physicalFolder))
                    Directory.CreateDirectory(physicalFolder);

                return folder;
            }
        }

        /// <summary>
        /// 下载的模板保存文件夹
        /// </summary>
        public static string TmplTempFolder
        {
            get
            {
                string folder = "/views/templates/tmpls/";
                var physicalFolder = GetMapPath(folder);
                if (!Directory.Exists(physicalFolder))
                    Directory.CreateDirectory(physicalFolder);

                return folder;
            }
        }

        /// <summary>
        /// 上传文件夹
        /// </summary>
        public static string UploadFolder
        {
            get
            {
                string folder = $"/upload/{DateTime.Now:yyyy}/{DateTime.Now:MM}/";
                var physicalFolder = GetMapPath(folder);
                if (!Directory.Exists(physicalFolder))
                    Directory.CreateDirectory(physicalFolder);

                return folder;
            }
        }

        /// <summary>
        /// 导入文件夹
        /// </summary>
        public static string ImportFolder
        {
            get
            {
                string folder = "/upload/import/";
                var physicalFolder = GetMapPath(folder);
                if (!Directory.Exists(physicalFolder))
                    Directory.CreateDirectory(physicalFolder);

                return folder;
            }
        }

        /// <summary>
        /// 导出文件夹
        /// </summary>
        public static string ExportFolder
        {
            get
            {
                string folder = "/upload/export/";
                var physicalFolder = GetMapPath(folder);
                if (!Directory.Exists(physicalFolder))
                    Directory.CreateDirectory(physicalFolder);

                return folder;
            }
        }

        /// <summary>
        /// 临时文件夹
        /// </summary>
        public static string TempFolder
        {
            get
            {
                string folder = "/upload/temp/";
                var physicalFolder = GetMapPath(folder);
                if (!Directory.Exists(physicalFolder))
                    Directory.CreateDirectory(physicalFolder);

                return folder;
            }
        }

        /// <summary>
        /// 备份文件夹
        /// </summary>
        public static string BackupFolder
        {
            get
            {
                string folder = "/upload/bakfiles/";
                var physicalFolder = GetMapPath(folder);
                if (!Directory.Exists(physicalFolder))
                    Directory.CreateDirectory(physicalFolder);

                return folder;
            }
        }

        /// <summary>
        /// 日志文件夹
        /// </summary>
        public static string LogFolder
        {
            get
            {
                string folder = "/log/";
                var physicalFolder = GetMapPath(folder);
                if (!Directory.Exists(physicalFolder))
                    Directory.CreateDirectory(physicalFolder);

                return folder;
            }
        }

        #endregion        
    }
}
