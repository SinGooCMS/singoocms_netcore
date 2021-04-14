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

namespace SinGooCMS.Platform.ConfMger
{
    public class SettingCateController : ManagerPageBase
    {
        const string MODULECODE = "CustomSetting";
        private readonly ISettingCategoryRepository settingCategoryRepository;

        public SettingCateController(ISettingCategoryRepository _settingCategoryRepository)
        {
            this.settingCategoryRepository = _settingCategoryRepository;
        }

        #region 列表

        #region Post相关操作       

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await settingCategoryRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            var result = await settingCategoryRepository.DelSettingCate(delEntity);
            if (result.ret == ResultType.Success)
            {
                await LogService.AddEvent("删除自定义设置分类[" + delEntity.CateName + "]成功");
                return OperateResult.successLoadJson;
            }
            else
                return result.ToOperateResultJson();
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("ConfMger/CustomSettingCate.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await settingCategoryRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<SettingCategoryInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.CateName.Contains(searchKey) || p.CateDesc.Contains(searchKey);
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
            var entity = new SettingCategoryInfo();
            if (isModify)
                entity = await settingCategoryRepository.FindAsync(OpID);

            entity.CateName = WebUtils.GetFormVal<string>("TextBox1");
            entity.CateDesc = WebUtils.GetFormVal<string>("TextBox2");

            if (string.IsNullOrEmpty(entity.CateName) || string.IsNullOrEmpty(entity.CateDesc))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.AutoTimeStamp = DateTime.Now;
                var result = await settingCategoryRepository.AddSettingCate(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent($"添加自定义配置[{entity.CateName}]成功");

                return result.ToOperateResultJson();
            }
            if (isModify)
            {
                var result = await settingCategoryRepository.UpdateSettingCate(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent($"修改自定义配置[{entity.CateName}]成功");

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
            ViewBag.InitData = (await settingCategoryRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("ConfMger/ModifyCustomSettingCate.cshtml");
        }

        #endregion

        #endregion
    }
}