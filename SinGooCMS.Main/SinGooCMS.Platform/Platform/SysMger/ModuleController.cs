using System;
using System.Text;
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
    public class ModuleController : ManagerPageBase
    {
        const string MODULECODE = "MenuMger";
        private readonly ICatalogRepository catalogRepository;
        private readonly IModuleRepository moduleRepository;
        private readonly IOperateRepository operateRepository;

        public ModuleController(ICatalogRepository _catalogRepository,
            IModuleRepository _moduleRepository,
            IOperateRepository _operateRepository)
        {
            this.catalogRepository = _catalogRepository;
            this.moduleRepository = _moduleRepository;
            this.operateRepository = _operateRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await moduleRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除！");

            var result = await moduleRepository.DelModule(delEntity);
            if (result.ret == ResultType.Success)
            {
                await LogService.AddEvent("删除模块[" + delEntity.ModuleName + "]成功");
                return OperateResult.successLoadJson;
            }

            return result.ToOperateResultJson();
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort()
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await moduleRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("设置管理模块排序成功");
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
            ViewBag.CatalogID = WebUtils.GetQueryVal<int>("cataid");
            return View("SysMger/Module.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await moduleRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private string GetCondition()
        {
            var builder = new StringBuilder();

            int catalogID = WebUtils.GetQueryVal<int>("cataid");
            if (catalogID > 0)
                builder.Append($" CatalogID={catalogID} ");

            if (searchKey.Length > 0)
                builder.Append($" AND ModuleName like '%{StringUtils.ChkSQL(searchKey)}%' ");

            return builder.ToString();
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
            var entity = new ModuleInfo();
            if (isModify)
                entity = await moduleRepository.FindAsync(OpID);

            entity.ModuleCode = WebUtils.GetFormString("TextBox2");
            entity.CatalogID = WebUtils.GetFormVal<int>("_cataid"); //传递过来的参数
            entity.ModuleName = WebUtils.GetFormString("TextBox1");
            entity.FilePath = WebUtils.GetFormString("TextBox3");
            entity.Remark = WebUtils.GetFormString("TextBox4");

            if (string.IsNullOrEmpty(entity.ModuleName) || string.IsNullOrEmpty(entity.FilePath))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.AutoTimeStamp = System.DateTime.Now;
                entity.IsSystem = false;
                entity.Sort = moduleRepository.MaxSort.Value + 1;

                var result = await moduleRepository.AddModule(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("添加模块[" + entity.ModuleName + "]成功");

                return result.ToOperateResultJson();
            }
            if (isModify)
            {
                var result = await moduleRepository.UpdateModule(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("修改模块[" + entity.ModuleName + "]成功");

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
            ViewBag.Catalog = await catalogRepository.FindAsync(WebUtils.GetQueryVal<int>("cataid"));
            ViewBag.InitData = (await moduleRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("SysMger/ModifyModule.cshtml");
        }

        #endregion

        #endregion        
    }
}