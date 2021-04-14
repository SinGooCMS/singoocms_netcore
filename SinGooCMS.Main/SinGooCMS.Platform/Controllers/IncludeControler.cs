using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Net.Http.Headers;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Application;
using SinGooCMS.MVCBase;
using SinGooCMS.Utility;

namespace SinGooCMS.Platform
{
    public class IncludeController : UIPageBase
    {
        private readonly IUser user;
        private readonly IAdPlaceRepository adPlaceRepository;
        private readonly IFileUploadRepository fileUploadRepository;

        public IncludeController(IUser _user, IAdPlaceRepository _adPlaceRepository, IFileUploadRepository _fileUploadRepository)
        {
            this.user = _user;
            this.adPlaceRepository = _adPlaceRepository;
            this.fileUploadRepository = _fileUploadRepository;
        }

        #region 文件下载
        public async Task<IActionResult> Download()
        {
            /*
            * 文件下载，用流文件形式下载，不会直接打开
            * 使用：<a href="/include/download?file=$cms.DesEncode(${item.FileDownPath})" target="_blank" >下载</a>
            * ${item.FileDownPath} 是虚拟文件路径 如 "/Upload/2018/07/abc.zip"
            */

            bool downNeedLogin = ConfigUtils.GetAppSetting<bool>("DownNeedLogin");
            string strFileName = WebUtils.GetQueryString("file");

            try
            {
                //解码成明文的 虚拟路径
                strFileName = SinGooBase.DesDecode(strFileName);
            }
            catch
            {
                strFileName = string.Empty;
            }

            string strPhysicalPath = SinGooBase.GetMapPath(strFileName);
            if (System.IO.File.Exists(strPhysicalPath))
            {
                if (downNeedLogin && user.LoginUser?.Value == null)
                {
                    return new JumpUrlResult(Context.GetCaption("OperationNeedLogin"), $"/user/login?returnurl={WebUtils.GetAbsoluteUri()}");//需要登录
                }
                else
                {
                    var upFile = await fileUploadRepository.GetByFileName(strFileName);
                    if (upFile != null)
                    {
                        upFile.DownloadCount++; //下载次数+1
                        await fileUploadRepository.UpdateAsync(upFile);
                    }

                    //输出文件
                    FileInfo fileInfo = new FileInfo(strFileName);
                    var ext = fileInfo.Extension;
                    new FileExtensionContentTypeProvider().Mappings.TryGetValue(ext, out var contenttype);
                    return File(System.IO.File.ReadAllBytes(strPhysicalPath), contenttype ?? "application/octet-stream", fileInfo.Name);
                }

            }

            return new ContentResult
            {
                ContentType = "text/plain; charset=utf-8",
                Content = Context.GetCaption("CMS_FileNotExist")
            };
        }
        #endregion

        #region 生成广告

        public async Task<IActionResult> GenerateAD()
        {
            /*
             * 传入广告位ID：placeid ，读取广告位信息（广告位模板）+ 广告详情信息（具体的广告内容），最后呈现此广告
             * 调用 <script type="text/javascript" src="/include/generatead?placeid=1"></script>
             * 广告位读取模板的目的是为了模块化，便于维护。当然也可以直接写模板语法 #foreach() 输出广告 #end
             */

            var adPlace = await adPlaceRepository.FindWithItemsAsync(WebUtils.GetQueryVal<int>("placeid"));
            if (adPlace != null)
            {
                return View(adPlace.TemplateFile, adPlace);
            }

            return new EmptyResult();
        }
        #endregion

        #region 设置站点语种

        public async Task SetLang()
        {
            /*
             * 调用 /include/setlang?lang=en
             * 默认的语种是中文简体 zh-cn，不需要额外创建模板文件夹，模板所在路径 /Templates/html/
             * 除此之外的语种，需要另外创建文件夹，模板所在路径中如 /Templates/html/en
             * 多语种的配置：/config/language.config
             * 多语种的文字提示参照： /Include/Language/ 里的设置
             * 读取多语种的方法：WebUtils.GetCaption("key","en")，当前默认的：WebUtils.GetCaption("key")
             */

            string lang = WebUtils.GetQueryString("lang", "zh-cn");
            if (Language.Contain(lang))
            {
                //设置为站点语言
                CookieUtils.SetCookie("lang", lang);

                string strJumpUrl = WebUtils.GetQueryString("jumpurl");
                if (!string.IsNullOrEmpty(strJumpUrl))
                    Response.Redirect(strJumpUrl); //跳转地址
                else if (Request.Headers[HeaderNames.Referer].ToString() != "")
                    Response.Redirect(Request.Headers[HeaderNames.Referer]); //原地址，仅切换了语言，如繁体
                else
                    Response.Redirect("/");
            }
            else
            {
                Response.ContentType = "text/plain; charset=utf-8";
                await Response.WriteAsync(Context.GetCaption("CMS_NotExistLanguageSet")); //不存在此语种设置
            }
        }
        #endregion

        #region 输出验证码

        public IActionResult CheckCodeImg()
        {
            var iCode = CaptchaUtils.Create();
            CookieUtils.SetCookie("vcode", SinGooBase.DesEncode(iCode.CheckCodeString), 3600);
            return File(iCode.CheckCodeImg, @"image/png");
        }

        #endregion
    }
}