using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;
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
    public class DataDictController : ManagerPageBase
    {
        const string MODULECODE = "DataDictionary";
        private readonly IDictsRepository dictsRepository;

        public DataDictController(IDictsRepository _dictsRepository)
        {
            this.dictsRepository = _dictsRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await dictsRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            var result = await dictsRepository.DelDict(delEntity);
            if (result.ret == ResultType.Success)
            {
                await LogService.AddEvent("删除字典[" + delEntity.DictName + "]成功");
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
            if (dictIDAndSort.Count > 0 && await dictsRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("设置字典排序成功");
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
            return View("ConfMger/DataDict.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await dictsRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<DictsInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.DictName.Contains(searchKey) || p.DictDesc.Contains(searchKey);
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
            DictsInfo entity = new DictsInfo();
            if (isModify)
                entity = await dictsRepository.FindAsync(OpID);

            entity.DictName = WebUtils.GetFormString("TextBox1");
            entity.DictDesc = WebUtils.GetFormString("TextBox2");
            entity.IsUsing = true;//CheckBox3.Checked;

            if (string.IsNullOrEmpty(entity.DictName))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.Sort = dictsRepository.MaxSort.Value + 1;
                entity.AutoTimeStamp = DateTime.Now;

                var result = await dictsRepository.AddDict(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("添加字典[" + entity.DictName + "]成功");

                return result.ToOperateResultJson();
            }
            if (isModify)
            {
                var result = await dictsRepository.UpdateDict(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("修改字典[" + entity.DictName + "]成功");

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
            ViewBag.InitData = (await dictsRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("ConfMger/ModifyDict.cshtml");
        }

        #endregion

        #endregion
    }
}