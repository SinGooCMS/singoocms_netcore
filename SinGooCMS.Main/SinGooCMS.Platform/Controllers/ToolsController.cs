using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Application.Interface;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform
{
    /// <summary>
    /// 文件上传工具
    /// </summary>
    public class ToolsController : UIPageBase
    {
        private readonly IFileUploadService fileUploadService;
        private readonly IFolderRepository folderRepository;
        private readonly IFileUploadRepository fileUploadRepository;

        public ToolsController(IFileUploadService _fileUploadService, 
            IFolderRepository _folderRepository, 
            IFileUploadRepository _fileUploadRepository)
        {
            this.fileUploadService = _fileUploadService;
            this.folderRepository = _folderRepository;
            this.fileUploadRepository = _fileUploadRepository;
        }

        #region 文件上传

        [HttpPost]
        [Permission("FileMger", "Upload")]
        public async Task<string> UploaderByManager(IFormFile file)
        {
            int folderID = WebUtils.GetFormVal<int>("folderID", -1); //保存的文件夹
            return (await fileUploadService.UploadByManager(file, folderID)).ToString();
        }

        [HttpPost]
        public async Task<string> UploaderByUser(IFormFile file)
        {
            int folderID = WebUtils.GetFormVal<int>("folderID", -1); //保存的文件夹
            return (await fileUploadService.UploadByUser(file, folderID)).ToString();
        }

        /// <summary>
        /// 上传工具弹出窗
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Uploader()
        {
            ViewBag.SelectType = WebUtils.GetQueryVal<int>("selecttype") == 0 ? "single" : "mutile"; //选择的类型 单选、多选/single mutil
            ViewBag.UserType = ((UserType)WebUtils.GetQueryVal<int>("usertype", 1)).ToString(); //默认是管理员 user manager
            ViewBag.IsBat = WebUtils.GetQueryVal<int>("isbat") == 1; //是否批量上传
            ViewBag.Folders = await folderRepository.GetAllAsync();

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

            return base.ViewOrigin("/views/platform/h5/Tools/UploadTools.cshtml");
        }

        #endregion

        #region 获取上传文件信息

        /// <summary>
        /// 文件选择窗口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string FileData()
        {
            var pager = new Pager() { PageIndex = WebUtils.GetQueryVal<int>("pageindex", 1), PageSize = 15 };

            //搜索参数            
            int folder = WebUtils.GetQueryVal<int>("folder", -1);
            int nian = WebUtils.GetQueryVal<int>("nian", 1900);
            int yue = WebUtils.GetQueryVal<int>("yue", 0);
            int imgOnly = WebUtils.GetQueryVal<int>("imgonly");
            string searchTxt = WebUtils.GetQueryString("searchtxt");

            var query = fileUploadRepository.NoTrackQuery();
            if (folder != 0)
                query = query.Where(p => p.FolderID == folder);

            if (nian > 1900)
                query = query.Where(p => p.AutoTimeStamp.Value.Year == nian);
            if (yue > 0)
                query = query.Where(p => p.AutoTimeStamp.Value.Month == yue);

            if (!string.IsNullOrEmpty(searchTxt))
                query = query.Where(p => p.FileName.Contains(searchTxt));
            if (imgOnly == 1)
                query = query.Where(p => p.Thumb != "");

            query = query.OrderByDescending(p => p.AutoID); //最新上传的文件显示在前面
            var pageModel = query.PageModel(pager.PageIndex, pager.PageSize);

            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;

            var builder = new System.Text.StringBuilder();
            var lstFiles = pageModel.PagerData;
            if (lstFiles != null && lstFiles.Count() > 0)
            {
                foreach (var item in lstFiles)
                {
                    builder.Append("{\"AutoID\":\"" + item.AutoID + "\",\"FolderID\":\"" + item.FolderID + "\",\"FileName\":\"" + item.FileName + "\",\"VirtualFilePath\":\"" + item.VirtualFilePath + "\",\"Thumb\":\"" + item.Thumb + "\",\"OriginalPath\":\"" + item.OriginalPath + "\",\"FileSize\":\"" + item.FileSize + "\"},");
                }

                return "{\"pageindex\":" + pager.PageIndex + ",\"pagesize\":" + pager.PageSize + ",\"totalcount\":" + pager.TotalRecord + ",\"totalpage\":" + pager.TotalPage + ",\"data\":[" + builder.ToString().Trim(',') + "]}";
            }
            else
            {
                return "{\"pageindex\":" + pager.PageIndex + ",\"pagesize\":" + pager.PageSize + ",\"totalcount\":0,\"totalpage\":0,\"data\":{}}";
            }
        }

        #endregion
    }
}
