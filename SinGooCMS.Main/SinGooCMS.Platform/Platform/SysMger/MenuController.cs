using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.SysMger
{
    public class MenuController : ManagerPageBase
    {
        const string MODULECODE = "MenuMger";
        private readonly ICatalogRepository catalogRepository;

        public MenuController(ICatalogRepository _catalogRepository)
        {
            this.catalogRepository = _catalogRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await catalogRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除！");

            var result = await catalogRepository.DelMenu(delEntity);
            if (result.ret == ResultType.Success)
            {
                await LogService.AddEvent("删除管理栏目[" + delEntity.CatalogName + "]成功");
                return OperateResult.successLoadJson;
            }
            else
                return result.ToOperateResultJson();
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort()
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await catalogRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("设置管理栏目排序成功");
                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("SysMger/Menu.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await catalogRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<CatalogInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.CatalogName.Contains(searchKey);
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
            var entity = new CatalogInfo();
            entity.CatalogCode = WebUtils.GetFormString("TextBox2");
            if (isModify)
                entity = await catalogRepository.FindAsync(OpID);

            entity.CatalogName = WebUtils.GetFormString("TextBox1");
            entity.Remark = WebUtils.GetFormString("TextBox3");

            if (string.IsNullOrEmpty(entity.CatalogName) || string.IsNullOrEmpty(entity.CatalogCode))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.AutoTimeStamp = DateTime.Now;
                entity.IsSystem = false;
                entity.Sort = catalogRepository.MaxSort.Value + 1;

                var result = await catalogRepository.AddMenu(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("添加栏目[" + entity.CatalogName + "]成功");

                return result.ToOperateResultJson();

            }
            if (isModify)
            {
                var result = await catalogRepository.UpdateMenu(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("修改栏目[" + entity.CatalogName + "]成功");

                return result.ToOperateResultJson();
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Edit()
        {
            ViewBag.InitData = (await catalogRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("SysMger/ModifyMenu.cshtml");
        }

        #endregion

        #endregion
    }
}