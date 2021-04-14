using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
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

namespace SinGooCMS.Platform.ADMger
{
    public class AdPlaceController : ManagerPageBase
    {
        const string MODULECODE = "ADMger";
        private readonly IAdPlaceRepository adPlaceRepository;

        public AdPlaceController(IAdPlaceRepository _adPlaceRepository)
        {
            adPlaceRepository = _adPlaceRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete(IFormCollection form)
        {
            var delEntity = await adPlaceRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            if (await adPlaceRepository.DelAdPlace(delEntity))
            {
                await LogService.AddEvent("删除广告位[" + delEntity.PlaceName + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete(IFormCollection form)
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await adPlaceRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除广告位成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort(IFormCollection form)
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await adPlaceRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("设置广告位排序成功");
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
            return View("ADMger/AdPlace.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await adPlaceRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }

        private Expression<Func<AdPlaceInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.PlaceName.Contains(searchKey);
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
            var entity = isModify
                ? await adPlaceRepository.FindAsync(OpID)
                : new AdPlaceInfo();

            //赋值
            entity.PlaceName = WebUtils.GetFormString("TextBox1");
            entity.Width = (short)WebUtils.GetFormVal<int>("TextBox2");
            entity.Height = (short)WebUtils.GetFormVal<int>("TextBox3");
            entity.Price = 0.0m; //WebUtils.GetDecimal(TextBox4.Text);
            entity.TemplateFile = WebUtils.GetFormString("TextBox5");
            entity.PlaceDesc = WebUtils.GetFormString("TextBox6");
            entity.Sort = WebUtils.GetFormVal<int>("TextBox7", 999);
            entity.Lang = Context.CurrLang;

            if (string.IsNullOrEmpty(entity.PlaceName))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (isModify && await adPlaceRepository.UpdateAsync(entity))
            {
                await LogService.AddEvent("修改广告位[" + entity.PlaceName + "]成功");
                return OperateResult.successJson;
            }
            if (!isModify)
            {
                entity.AutoTimeStamp = DateTime.Now;
                if (await adPlaceRepository.AddAsync(entity) > 0)
                {
                    await LogService.AddEvent("添加广告位[" + entity.PlaceName + "]成功");
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
            ViewBag.InitData = (await adPlaceRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("ADMger/ModifyAdPlace.cshtml");
        }

        #endregion

        #endregion
    }
}