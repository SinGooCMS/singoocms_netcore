using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Utility;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.ContMger
{
    public class FolderController : ManagerPageBase
    {
        const string MODULECODE = "FolderMger";
        private readonly IFolderRepository folderRepository;

        public FolderController(IFolderRepository _folderRepository)
        {
            this.folderRepository = _folderRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await folderRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            if (await folderRepository.DelFolder(delEntity))
            {
                await LogService.AddEvent("删除文件夹[" + delEntity.FolderName + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!strIDs.IsNullOrEmpty() && await folderRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除文件夹成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort()
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await folderRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("更新文件夹排序成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("ContMger/Folder.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await folderRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<FolderInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.FolderName.Contains(searchKey);
            else
                return (p) => true;
        }

        #endregion

        #endregion

        #region 编辑

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Add)]
        public async Task<string> Add(IFormCollection form)
        {
            return await Edit(false);
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> Modify(IFormCollection form)
        {
            return await Edit(true);
        }

        private async Task<string> Edit(bool isModify)
        {
            FolderInfo entity = new FolderInfo();
            if (isModify)
                entity = await folderRepository.FindAsync(OpID);

            entity.FolderName = WebUtils.GetFormString("TextBox1");
            entity.Remark = WebUtils.GetFormString("TextBox2");

            if (string.IsNullOrEmpty(entity.FolderName))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.Sort = 999;
                entity.Lang = Context.CurrLang;
                entity.AutoTimeStamp = System.DateTime.Now;

                if (await folderRepository.AddAsync(entity) > 0)
                {
                    await LogService.AddEvent("添加文件夹[" + entity.FolderName + "]成功");
                    return OperateResult.successJson;
                }
            }

            if (isModify)
            {
                if (await folderRepository.UpdateAsync(entity))
                {
                    await LogService.AddEvent("修改文件夹[" + entity.FolderName + "]成功");
                    return OperateResult.successJson;
                }
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Edit()
        {
            ViewBag.InitData = (await folderRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("ContMger/ModifyFolder.cshtml");
        }

        #endregion

        #endregion
    }
}