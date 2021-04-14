using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.ContMger
{
    public class UpfilesController : ManagerPageBase
    {
        const string MODULECODE = "FileMger";
        private readonly IFolderRepository folderRepository;
        private readonly IFileUploadRepository fileUploadRepository;

        public UpfilesController(IFolderRepository _folderRepository, IFileUploadRepository _fileUploadRepository)
        {
            this.folderRepository = _folderRepository;
            this.fileUploadRepository = _fileUploadRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await fileUploadRepository.FindAsync(OpID);
            if (delEntity != null && await fileUploadRepository.DelBatAndFile(OpID.ToString()))
            {
                await LogService.AddEvent("删除上传文件[" + delEntity.VirtualFilePath + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs))
            {
                if (await fileUploadRepository.DelBatAndFile(strIDs))
                {
                    await LogService.AddEvent("批量删除上传文件成功");
                    return OperateResult.successLoadJson;
                }
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.MoveToFolder)]
        public async Task<string> MoveToFolder()
        {
            string strIDs = WebUtils.GetFormString("ids");
            int targetFolderId = WebUtils.GetFormVal<int>("folderid", -1);

            if (strIDs.IsNullOrEmpty())
                return OperateResult.FailJson("NothingSelected", "未选择任何项");

            if (!string.IsNullOrEmpty(strIDs) && await fileUploadRepository.MoveToFolder(strIDs, targetFolderId))
            {
                await LogService.AddEvent($"归档文件({strIDs})到文件夹({targetFolderId})");
                return OperateResult.SuccessJson("OperationSuccess", "操作成功", "/platform/Upfiles/Index");
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Index()
        {
            //文件夹
            ViewBag.Folders = await folderRepository.GetFolderListAsync();

            //年份 10年内
            var dictYear = new Dictionary<int, string>();
            dictYear.Add(1900, "全部");
            for (int i = System.DateTime.Now.Year; i > System.DateTime.Now.AddYears(-10).Year; i--)
                dictYear.Add(i, i.ToString() + "年");
            ViewBag.Years = dictYear;

            //月份
            var dictMonth = new Dictionary<int, string>();
            dictMonth.Add(0, "全部");
            for (int i = 1; i <= 12; i++)
                dictMonth.Add(i, i.ToString() + "月");
            ViewBag.Months = dictMonth;

            return View("ContMger/Upfiles.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            pager.PageSize = 20;
            int folder = WebUtils.GetQueryVal<int>("selFolder", 0); //文件夹            
            int nian = WebUtils.GetQueryVal<int>("nian", 1900); //年份            
            int yue = WebUtils.GetQueryVal<int>("yue", 0); //月份            
            int imgOnly = WebUtils.GetQueryVal<int>("imgonly"); //是否仅显示图片 =1

            var query = fileUploadRepository.NoTrackQuery();
            if (folder != 0)
                query = query.Where(p => p.FolderID == folder);

            if (nian > 1900)
                query = query.Where(p => p.AutoTimeStamp.Value.Year == nian);
            if (yue > 0)
                query = query.Where(p => p.AutoTimeStamp.Value.Month == yue);

            if (!string.IsNullOrEmpty(searchKey))
                query = query.Where(p => p.FileName.Contains(searchKey));
            if (imgOnly == 1)
                query = query.Where(p => p.Thumb != "");

            query = query.OrderByDescending(p => p.AutoID); //最新上传的文件显示在前面
            var pageModel = query.PageModel(pager.PageIndex, pager.PageSize);

            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;

            var lstNew = from item in pageModel.PagerData
                         select new
                         {
                             item.AutoID,
                             item.FileName,
                             item.FolderID,
                             item.VirtualFilePath,
                             item.OriginalPath,
                             ShowImg = ShowPreview(item.VirtualFilePath, item.Thumb),
                             item.FileSize,
                             item.FileSizeStr,
                             item.AutoTimeStamp
                         };

            string dataJson = lstNew.ToJson();

            string pagerJson = new MVCPager(pager).PagerJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":" + pagerJson + "}}";
        }

        /// <summary>
        /// 显示默认的预览图标
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <param name="thumb"></param>
        /// <returns></returns>
        private string ShowPreview(string virtualPath, string thumb)
        {
            if (virtualPath.IsImage())
                return "<img class='thumb' viewer='true' data-original='" + virtualPath + "' src='" + thumb + "' alt='' />";
            else
            {
                string strExt = System.IO.Path.GetExtension(virtualPath).ToLower();
                switch (strExt)
                {
                    case ".doc":
                        return $"<img class='thumb' data-original='/include/theme/{Context.SiteConfig.Theme}/images/imgico/doc.png' src='/include/theme/{Context.SiteConfig.Theme}/images/imgico/doc.png' alt='' />";
                    case ".pdf":
                        return $"<img class='thumb' data-original='/include/theme/{Context.SiteConfig.Theme}/images/imgico/pdf.png' src='/include/theme/{Context.SiteConfig.Theme}/images/imgico/pdf.png' alt='' />";
                    case ".rar":
                        return $"<img class='thumb' data-original='/include/theme/{Context.SiteConfig.Theme}/images/imgico/rar.png' src='/include/theme/{Context.SiteConfig.Theme}/images/imgico/rar.png' alt='' />";
                    case ".zip":
                        return $"<img class='thumb' data-original='/include/theme/{Context.SiteConfig.Theme}/images/imgico/zip.png' src='/include/theme/{Context.SiteConfig.Theme}/images/imgico/zip.png' alt='' />";
                    case ".txt":
                        return $"<img class='thumb' data-original='/include/theme/{Context.SiteConfig.Theme}/images/imgico/txt.png' src='/include/theme/{Context.SiteConfig.Theme}/images/imgico/txt.png' alt='' />";
                    default:
                        return $"<img class='thumb' data-original='/include/theme/{Context.SiteConfig.Theme}/images/imgico/file.png' src='/include/theme/{Context.SiteConfig.Theme}/images/imgico/file.png' alt='' />";
                }
            }
        }

        #endregion

        #endregion        
    }
}