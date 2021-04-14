using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Utility;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.ADMger
{
    public class FriendLinkController : ManagerPageBase
    {
        const string MODULECODE = "FriendLink";
        private readonly ILinksRepository linksRepository;

        public FriendLinkController(ILinksRepository _linksRepository)
        {
            this.linksRepository = _linksRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await linksRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            if (await linksRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除链接[" + delEntity.LinkName + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await linksRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除链接成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort()
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await linksRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("设置友链排序成功");
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
            return View("ADMger/FriendLink.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await linksRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<LinksInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.LinkName.Contains(searchKey);
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

        public async Task<string> Edit(bool isModify)
        {
            var entity = isModify
                ? await linksRepository.FindAsync(OpID)
                : new LinksInfo();

            entity.LinkName = WebUtils.GetFormString("TextBox1");
            entity.LinkUrl = WebUtils.GetFormString("TextBox2");
            entity.LinkImage = WebUtils.GetFormString("TextBox3");
            entity.LinkFlash = string.Empty;
            entity.Sort = WebUtils.GetFormVal<int>("TextBox4", 999);
            entity.IsAudit = true;
            entity.Lang = Context.CurrLang;

            if (!string.IsNullOrEmpty(entity.LinkImage))
                entity.LinkType = "图片链接";
            else if (!string.IsNullOrEmpty(entity.LinkFlash))
                entity.LinkType = "flash链接";
            else
                entity.LinkType = "文字链接";

            if (string.IsNullOrEmpty(entity.LinkName) || string.IsNullOrEmpty(entity.LinkUrl))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.AutoTimeStamp = System.DateTime.Now;
                if (await linksRepository.AddAsync(entity) > 0)
                {
                    await LogService.AddEvent("添加友链[" + entity.LinkName + "]成功");
                    return OperateResult.successJson;
                }
            }
            if (isModify && await linksRepository.UpdateAsync(entity))
            {
                await LogService.AddEvent("修改友链[" + entity.LinkName + "]成功");
                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Edit()
        {
            ViewBag.InitData = (await linksRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("ADMger/ModifyFriendLink.cshtml");
        }

        #endregion

        #endregion
    }
}
