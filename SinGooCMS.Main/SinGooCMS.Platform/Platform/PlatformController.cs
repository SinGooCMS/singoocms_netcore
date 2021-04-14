using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform
{
    public class PlatformController : ManagerPageBase
    {
        private readonly IAccountRepository accountRepository;
        private readonly IContentRepository contentRepository;
        private readonly IPublisher publisher;

        public PlatformController(
            IAccountRepository _accountRepository,
            IContentRepository _contentRepository,
            IPublisher _publisher
            )
        {
            this.accountRepository = _accountRepository;
            this.contentRepository = _contentRepository;
            this.publisher = _publisher;
        }

        [HttpGet]
        [Route("/platform/login.html")]
        [Route("/platform/login")]
        public IActionResult Login()
        {
            return new RedirectResult("/account/login.html");
        }

        #region 管理主页

        [HttpGet]
        public async Task<IActionResult> Main()
        {
            //菜单
            var builder = new StringBuilder();
            DataTable menuData = await base.GetAccountMenu();
            if (menuData != null)
            {
                #region 渲染菜单

                var drs = menuData.Rows;
                int i = 0;
                var dict = new Dictionary<string, string>();
                dict.Add("内容管理", "&#xe69a;");
                dict.Add("会员管理", "&#xe64a;");
                dict.Add("移动端", "&#xe653;");
                dict.Add("微信端", "&#xe653;");
                dict.Add("广告管理", "&#xe600;");
                dict.Add("系统配置", "&#xe614;");
                dict.Add("系统维护", "&#xe782;");

                string strCatalogName = string.Empty;
                string ico = dict["内容管理"];

                foreach (DataRow item in drs)
                {
                    if (strCatalogName != item["CatalogName"].ToString())
                    {
                        strCatalogName = item["CatalogName"].ToString();
                        if (dict.Keys.Contains(strCatalogName))
                            ico = dict[strCatalogName];

                        if (i == 0)
                            builder.Append($"<h3 class=\"on\"><i class=\"iconfont fl\">{ico}</i><em></em>{strCatalogName}</h3>");
                        else
                            builder.Append($"<h3><i class=\"iconfont fl\">{ico}</i><em></em>{strCatalogName}</h3>");
                        builder.Append("<ul>");
                    }

                    builder.Append($"<li><a href='/platform/{item["FilePath"]}'>{item["ModuleName"]}</a></li>");

                    int nextPoint = i + 1;
                    if (nextPoint <= drs.Count - 1 && drs[nextPoint] != null && drs[nextPoint]["CatalogName"].ToString() != strCatalogName)
                        builder.Append("</ul>");

                    i++;
                }

                #endregion
            }

            ViewBag.Menu = builder.ToString();
            return base.View("Main.cshtml");
        }

        #endregion                

        #region 管理桌面

        public async Task<IActionResult> Desktop()
        {
            //平台信息
            ViewBag.Ver = CacheStore.CacheVer;

            //最新的8条内容
            ViewBag.TopNewCont = await contentRepository.GetListAsync(8, $"Status={(int)ContStatus.Normal}", "AutoID desc");

            //空间容量
            var siteTotalCapacity = CacheStore.CacheBaseConfig.SiteCapacity / (1024.0f * 1024.0f);
            //已使用容量
            var siteUsedCapacity= FileUtils.GetDirectoryLength(SinGooBase.BaseDir) / (1024.0f * 1024.0f); //以M为单位

            //已经使用网站空间大小
            ViewBag.SiteSize = siteUsedCapacity; 
            //空间大小
            ViewBag.TotalSize = siteTotalCapacity;
            //剩余空间
            ViewBag.RemainSize = siteTotalCapacity - siteUsedCapacity;
            //已使用百分比
            ViewBag.UsePercent = (siteUsedCapacity / siteTotalCapacity) * 100;

            #region 快捷按钮

            var expButton = new string[] { "栏目设置", "文章列表", "会员列表", "移动端设置", "公众号配置", "广告管理", "基本配置", "文件管理" };
            var expButtonIco = new string[] { "&#xe601;", "&#xe69a;", "&#xe615;", "&#xe653;", "&#xe65d;", "&#xe600;", "&#xe606;", "&#xe68f;" };
            var expButtonUrl = new string[] { "/platform/Node/Index", "/platform/Content/Index", "/platform/UserMger/Index", "/platform/MobileSet/Index", "/platform/WeixinMger/WXConfig", "/platform/AdPlace/Index", "/platform/Config/Index", "/platform/Upfiles/Index" };
            var builder = new StringBuilder();
            var dtMenu = await base.GetAccountMenu();
            if (dtMenu != null && dtMenu.Rows.Count > 0)
            {
                for (int i = 0; i < expButton.Length; i++)
                {
                    var row = dtMenu.AsEnumerable().Where(p => p.Field<string>("ModuleName").ToString().Equals(expButton[i])).FirstOrDefault();
                    if (row != null)
                        builder.Append($"<div class=\"col-xs-12 col-sm-3 main-fast enable\"><a class='tab-a' href=\"{expButtonUrl[i]}\"><i class=\"iconfont\">{expButtonIco[i]}</i><div>{expButton[i]}</div></a></div>");
                    else
                        builder.Append($"<div class=\"col-xs-12 col-sm-3 main-fast\"><a title='没有权限' href=\"javascript:showtip('没有权限');\"><i class=\"iconfont\">{expButtonIco[i]}</i><div>{expButton[i]}</div></a></div>");
                }

            }

            ViewBag.ExpressButtonHtml = builder.ToString();

            #endregion

            return View("Desktop.cshtml");
        }

        #endregion

        #region 修改密码

        [HttpPost]
        [Permission("AccountMger", "SetAccountPwd")]
        public async Task<string> ChangePwd(IFormCollection form)
        {
            bool boolIsPwdChange = false;
            var accountNew = await accountRepository.FindAsync(Manager.AccountID);

            //原密码
            string strOldPwd = form["oldpwd"];
            //新密码
            string strNewPwd = form["newpwd1"];
            //确认新密码
            string strNewPwdConfirm = form["newpwd2"];
            //邮箱
            string strMail = form["email"];
            //手机
            string strMobile = form["mobile"];

            //输入了原密码，表示要修改密码
            if (!string.IsNullOrEmpty(strOldPwd))
            {
                strOldPwd = DEncryptUtils.SHA512Encrypt(strOldPwd);
                if (!Manager.LoginAccount.Password.Equals(strOldPwd))
                    return OperateResult.FailJson("User_OldPwdIncorrect", "原密码不正确！");
                else if (strNewPwd.Length < 6)
                    return OperateResult.FailJson("User_UserPwdLenNeed", "密码长度不少于6位");
                else if (strNewPwdConfirm != strNewPwd)
                    return OperateResult.FailJson("User_TwoPwdInputedNotEqual", "两次密码输入不一致！");
                else
                {
                    accountNew.Password = DEncryptUtils.SHA512Encrypt(strNewPwd);
                    boolIsPwdChange = true;
                }
            }

            accountNew.Email = strMail;
            accountNew.Mobile = strMobile;

            if (await accountRepository.UpdateAsync(accountNew))
            {
                if (boolIsPwdChange)
                {
                    //修改日志
                    await LogService.AddEvent("管理员修改帐户密码成功");
                    SessionUtils.DelSession("Account");
                    return OperateResult.SuccessJson("OperationSuccess", "操作成功", $"/include/jump.html?msg={HttpUtility.UrlEncode(Context.GetCaption("ChangePwd_Success"))}&redirecturl=/account/login");
                }
            }

            return OperateResult.failJson;
        }

        [HttpGet]
        public IActionResult ChangePwd()
        {
            return View("Tools/ChangePwd.cshtml");
        }

        #endregion

        #region 查看缓存

        [HttpPost]
        public string Delete(IFormCollection form)
        {
            Context.Cache.Del(form["opid"]);
            return new OperateResult(true, "OperationSuccess", "操作成功", "/platform/showcache", 1500).ToString();
        }

        [HttpPost]
        public string ClearCache(IFormCollection form)
        {
            Context.Cache.ClearAll();
            return new OperateResult(true, "OperationSuccess", "操作成功", "/platform/showcache", 1500).ToString();
        }

        [HttpPost]
        public string ClearPageCache(IFormCollection form)
        {
            publisher.Clear();
            return new OperateResult(true, "OperationSuccess", "操作成功", "/platform/showcache", 1500).ToString();
        }

        [HttpPost]
        public string ClearNodePageCache(IFormCollection form)
        {
            publisher.DeleteNodes();
            return new OperateResult(true, "OperationSuccess", "操作成功", "/platform/showcache", 1500).ToString();
        }

        [HttpPost]
        public string ClearContPageCache(IFormCollection form)
        {
            publisher.DeleteArticles();
            return new OperateResult(true, "OperationSuccess", "操作成功", "/platform/showcache", 1500).ToString();
        }

        [HttpPost]
        public string RemoveContPageCache(IFormCollection form)
        {
            string fileName = WebUtils.GetFormString("PageCacheFileName");
            string absoluteFilePath = FileUtils.Combine(SinGooBase.GetMapPath(SinGooBase.HtmlCacheFolder), fileName);
            if (System.IO.File.Exists(absoluteFilePath))
                System.IO.File.Delete(absoluteFilePath);

            return new OperateResult(true, "OperationSuccess", "操作成功", "/platform/showcache", 1500).ToString();
        }

        [HttpGet]
        public IActionResult ShowCache()
        {
            var lst = Context.Cache.GetAllKeys();
            ViewBag.Data = lst;
            ViewBag.Pager = new MVCPager("/platform/showcache", lst.Count, 1, 1000);
            return View("Tools/ShowCache.cshtml");
        }

        #endregion
    }
}
