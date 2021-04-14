using System;
using System.Text;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using SinGooCMS.Domain.Models;
using Microsoft.Net.Http.Headers;
using SinGooCMS.Utility;

namespace SinGooCMS.MVCBase.Services
{
    /// <summary>
    /// 获取客户端信息
    /// </summary>
    internal class STATClient
    {
        public static VisitorInfo GetVisitorInfo()
        {
            var context = UtilsBase.HttpContext;
            if (context != null)
            {
                var info = new VisitorInfo();
                var headers = context.Request.Headers;
                info.IPAddress = IPUtils.GetIP();

                var agent = headers[HeaderNames.UserAgent];
                //UserAgent信息
                info.UserAgent = agent;
                //操作系统
                info.OPSystem = GetOPSystem(agent);
                //用户语言
                info.CustomerLang = headers[HeaderNames.AcceptLanguage];
                //浏览器
                info.Navigator = GetBrowser(agent);

                //是否搜索引擎爬虫
                info.IsCrawler = false;
                info.VPage = WebUtils.GetAbsoluteUri();

                var referer = context.Request.Headers[HeaderNames.Referer];
                if (!string.IsNullOrEmpty(referer))
                {
                    info.ApproachUrl = referer;
                    info.Engine = GetSearchEngine(referer);
                }
                else
                    info.ApproachUrl = "手动输入地址";

                info.CookieParameter = context.Request.Headers["Cookie"];
                info.GETParameter = context.Request.QueryString.ToString();
                info.POSTParameter = context.Request.HasFormContentType ? context.Request.Form.ToString() : string.Empty;
                info.ErrMessage = string.Empty;
                info.StackTrace = string.Empty;
                info.Lang = SinGooBase.CurrLang;
                info.AutoTimeStamp = DateTime.Now;

                return info;
            }

            return null;
        }

        #region Helper
        /// <summary>
        /// 获取操作系统信息
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string GetOPSystem(string strSource)
        {
            Dictionary<string, string> dictOS = new Dictionary<string, string>();
            dictOS.Add("Android", "Android 手机");
            dictOS.Add("iPhone", "iPhone 手机");
            dictOS.Add("Windows Phone", "Windows Phone 手机");
            dictOS.Add("BlackBerry", "黑莓手机");
            dictOS.Add("Windows NT 10", "Windows 10");
            dictOS.Add("Windows NT 6.2", "Windows 8");
            dictOS.Add("Windows NT 6.1", "Windows 7");
            dictOS.Add("Windows NT 6.0", "Windows Vista");
            dictOS.Add("Windows NT 5.2", "Win2003");
            dictOS.Add("Windows NT 5.0", "Win2000");
            dictOS.Add("Windows NT 5.1", "WinXP");
            dictOS.Add("Windows NT", "WinNT");
            dictOS.Add("iPad", "iPad");
            dictOS.Add("unix", "类Unix");
            dictOS.Add("Linux", "Linux");
            dictOS.Add("SunOS", "类Unix");
            dictOS.Add("BSD", "类Unix");
            dictOS.Add("Mac", "Mac OS");
            dictOS.Add("FreeBSD", "FreeBSD");
            dictOS.Add("Windows CE", "Windows CE");
            dictOS.Add("Other", "其它操作系统");

            foreach (KeyValuePair<string, string> item in dictOS)
            {
                if (strSource.ToUpper().IndexOf(item.Key.ToUpper()) != -1)
                    return item.Value;
            }

            return dictOS["Other"];
        }

        /// <summary>
        /// 获取浏览器信息
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string GetBrowser(string strSource)
        {
            Dictionary<string, string> dictBrowser = new Dictionary<string, string>();
            dictBrowser.Add("MicroMessenger", "微信客户端");
            dictBrowser.Add("TaoBrowser", "淘宝浏览器");
            dictBrowser.Add("LBBROWSER", "猎豹浏览器");
            dictBrowser.Add("QQBrowser", "QQ浏览器");
            dictBrowser.Add("360SE", "360浏览器");
            dictBrowser.Add("MetaSr", "搜狗浏览器");
            dictBrowser.Add("MSIE 10.0", "IE 10");
            dictBrowser.Add("MSIE 9.0", "IE 9");
            dictBrowser.Add("MSIE 8.0", "IE 8");
            dictBrowser.Add("MSIE 7.0", "IE 7");
            dictBrowser.Add("MSIE 6.0", "IE 6");
            dictBrowser.Add("Firefox", "火狐浏览器");
            dictBrowser.Add("Chrome", "谷歌浏览器");
            dictBrowser.Add("Netscape", "Netscape");
            dictBrowser.Add("Opera", "Opera");
            dictBrowser.Add("Navigator", "Navigator");
            dictBrowser.Add("Other", "其它浏览器");

            foreach (KeyValuePair<string, string> item in dictBrowser)
            {
                if (strSource.ToUpper().IndexOf(item.Key.ToUpper()) != -1)
                    return item.Value;
            }

            return dictBrowser["Other"];
        }

        /// <summary>
        /// 获取搜索引擎信息
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static string GetSearchEngine(string strSource)
        {
            Dictionary<string, string> dictSeo = new Dictionary<string, string>();
            dictSeo.Add("www.baidu.com", "百度");
            dictSeo.Add("m.sm.cn", "神马搜索");
            dictSeo.Add("www.sogou.com", "搜狗");
            dictSeo.Add("cn.bing.com", "必应中国");
            dictSeo.Add("www.bing.com", "Bing");
            dictSeo.Add("www.so.com", "360搜索");
            dictSeo.Add("www.google.com", "Google");
            dictSeo.Add("www.google.com.hk", "谷歌中国");

            foreach (KeyValuePair<string, string> item in dictSeo)
            {
                if (strSource.ToUpper().IndexOf(item.Key.ToUpper()) != -1)
                    return item.Value;
            }

            return string.Empty;
        }

        #endregion
    }
}
