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
    public class DictItemController : ManagerPageBase
    {
        const string MODULECODE = "DataDictionary";
        private IDictsRepository dictsRepository;
        private IDictItemRepository dictItemRepository;

        public DictItemController(IDictsRepository _dictsRepository, IDictItemRepository _dictItemRepository)
        {
            this.dictsRepository = _dictsRepository;
            this.dictItemRepository = _dictItemRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await dictItemRepository.FindAsync(OpID);
            if (delEntity != null && await dictItemRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除字典项[" + delEntity.KeyName + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort()
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await dictItemRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("设置字典项排序成功");
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
            ViewBag.DictId = WebUtils.GetQueryVal<int>("dictid");
            return View("ConfMger/DictItem.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await dictItemRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<DictItemInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.DictID == WebUtils.GetQueryVal<int>("dictid", 0) && p.KeyName.Contains(searchKey);
            else
                return (p) => p.DictID == WebUtils.GetQueryVal<int>("dictid", 0);
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
            //当前所属的字典
            var dictCurrent = await dictsRepository.FindAsync(WebUtils.GetFormVal<int>("_dictid"));

            var entity = new DictItemInfo();
            if (isModify)
                entity = await dictItemRepository.FindAsync(OpID);

            entity.DictID = dictCurrent.AutoID;
            entity.KeyName = WebUtils.GetFormString("TextBox1");
            entity.KeyValue = WebUtils.GetFormString("TextBox2");
            entity.IsUsing = true; //CheckBox3.Checked;

            if (string.IsNullOrEmpty(entity.KeyName) || string.IsNullOrEmpty(entity.KeyValue))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.Sort = dictItemRepository.MaxSort.Value + 1;
                entity.AutoTimeStamp = DateTime.Now;

                var result = await dictItemRepository.AddDictItemAsync(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("添加字典内容项[" + entity.KeyName + "]成功");

                return result.ToOperateResultJson();
            }
            if (isModify)
            {
                var result = await dictItemRepository.UpdateDictItemAsync(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("修改字典内容项[" + entity.KeyName + "]成功");

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
            ViewBag.Dict = await dictsRepository.FindAsync(WebUtils.GetQueryVal<int>("dictid")); //所属字典信息
            ViewBag.InitData = (await dictItemRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("ConfMger/ModifyDictItem.cshtml");
        }

        #endregion

        #endregion
    }
}