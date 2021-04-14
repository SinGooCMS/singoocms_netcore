using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.ContMger
{
    public class TagsController : ManagerPageBase
    {
        const string MODULECODE = "TagsMger";
        private readonly ITagsRepository tagsRepository;

        public TagsController(ITagsRepository _tagsRepository)
        {
            this.tagsRepository = _tagsRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await tagsRepository.FindAsync(OpID);
            if (delEntity != null && await tagsRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除标签[" + delEntity.TagName + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await tagsRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除标签成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort()
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await tagsRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("设置标签排序成功");
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
            return View("ContMger/Tags.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await tagsRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<TagsInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.TagName.Contains(searchKey);
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
            var entity = new TagsInfo();
            if (isModify)
                entity = await tagsRepository.FindAsync(OpID);

            entity.TagName = WebUtils.GetFormString("TextBox1");
            entity.Sort = WebUtils.GetFormVal<int>("TextBox2", 999);
            entity.TagUrl = string.Empty;
            entity.IsTop = WebUtils.GetFormString("chkHot") == "on";
            entity.IsRecommend = WebUtils.GetFormString("chkRecommend") == "on";

            if (string.IsNullOrEmpty(entity.TagName))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.AutoTimeStamp = DateTime.Now;
                entity.Lang = Context.CurrLang;

                if (await tagsRepository.AddAsync(entity) > 0)
                {
                    await LogService.AddEvent("添加标签[" + entity.TagName + "]成功");
                    return OperateResult.successJson;
                }
            }

            if (isModify)
            {
                if (await tagsRepository.UpdateAsync(entity))
                {
                    await LogService.AddEvent("修改标签[" + entity.TagName + "]成功");
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
            ViewBag.InitData = (await tagsRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("ContMger/ModifyTags.cshtml");
        }

        #endregion

        #endregion
    }
}