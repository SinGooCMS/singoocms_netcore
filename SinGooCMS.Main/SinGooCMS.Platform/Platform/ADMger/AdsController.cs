using System;
using System.Text;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

namespace SinGooCMS.Platform.ADMger
{
    public class AdsController : ManagerPageBase
    {
        const string MODULECODE = "ADMger";
        private readonly IAdsRepository adsRepository;

        public AdsController(IAdsRepository _adsRepository)
        {
            this.adsRepository = _adsRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await adsRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            if (await adsRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除广告[" + delEntity.AdName + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await adsRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除广告成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort()
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await adsRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("设置广告排序成功");
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
            ViewBag.PlaceID = WebUtils.GetQueryString("PlaceID");
            return View("ADMger/Ads.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await adsRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;

            string dataJson = pageModel.PagerData.ToJson();
            //以下是json的部分需要替换成有意义的描述
            Func<int, string> GetEnumDesc = (adType) =>
            {
                return dataJson.Replace("\"AdType\":" + adType + "", "\"AdType\":\"" + EnumUtils.GetEnumDescription((AdsType)adType) + "\"");
            };
            foreach (var item in Enum.GetValues(typeof(AdsType)))
            {
                dataJson = GetEnumDesc((int)item); //把数字转成枚举的文字描述
            }

            dataJson = new Regex(@"(\d+):(\d+):(\d+)").Replace(dataJson, ""); //时间部分不要了
            dataJson = dataJson.Replace("\"IsAudit\":true", "\"IsAudit\":\"<span style='color:blue'>已审核</span>\"")
                .Replace("\"IsAudit\":false", "\"IsAudit\":\"未审核\"");

            return new MVCPager(pager).Display(dataJson);
        }
        private Expression<Func<AdsInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.PlaceID == WebUtils.GetQueryVal<int>("PlaceID", 0) && p.AdName.Contains(searchKey);
            else
                return (p) => p.PlaceID == WebUtils.GetQueryVal<int>("PlaceID", 0);
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
                ? await adsRepository.FindAsync(OpID)
                : new AdsInfo();

            //赋值
            entity.AdType = (byte)WebUtils.GetFormVal<int>("ddlADType");
            entity.AdName = WebUtils.GetFormString("TextBox1");
            entity.AdText = WebUtils.GetFormString("TextBox4");
            entity.AdMediaPath = WebUtils.GetFormString("TextBox6");
            entity.AdLink = WebUtils.GetFormString("TextBox2");
            entity.BeginDate = WebUtils.GetFormDatetime("timestart",DateTime.Now);
            entity.EndDate = WebUtils.GetFormDatetime("timeend",DateTime.Now.AddYears(10));
            entity.Sort = WebUtils.GetFormVal<int>("TextBox5");
            entity.IsAudit = WebUtils.GetFormString("isaudit") == "on";
            entity.Lang = Context.CurrLang;

            if (string.IsNullOrEmpty(entity.AdName))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");
            else if (entity.EndDate < entity.BeginDate)
                return OperateResult.FailJson("PLFM_EndDateMustGreatThenStart", "截止日期不能小于起始日期");
            else
            {
                if (!isModify)
                {
                    entity.PlaceID = WebUtils.GetFormVal<int>("_PlaceID");
                    entity.AutoTimeStamp = DateTime.Now;
                    if (await adsRepository.AddAsync(entity) > 0)
                    {
                        await LogService.AddEvent("添加广告[" + entity.AdName + "]成功");
                        return OperateResult.successJson;
                    }
                }
                if (isModify && await adsRepository.UpdateAsync(entity))
                {
                    await LogService.AddEvent("修改广告[" + entity.AdName + "]成功");
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
            ViewBag.PlaceID = WebUtils.GetQueryVal<int>("PlaceID");

            string dataJson = (await adsRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            ViewBag.InitData = new Regex(@" (\d+):(\d+):(\d+)").Replace(dataJson, "");

            return View("ADMger/ModifyAds.cshtml");
        }

        #endregion

        #endregion
    }
}