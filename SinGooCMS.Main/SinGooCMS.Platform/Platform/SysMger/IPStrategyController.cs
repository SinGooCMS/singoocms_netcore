using System;
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

namespace SinGooCMS.Platform.SysMger
{
    public class IPStrategyController : ManagerPageBase
    {
        const string MODULECODE = "IPStrategyMger";
        private readonly IIPStrategyRepository iPStrategyRepository;

        public IPStrategyController(IIPStrategyRepository _iPStrategyRepository)
        {
            this.iPStrategyRepository = _iPStrategyRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await iPStrategyRepository.FindAsync(OpID);
            if (delEntity != null && await iPStrategyRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除IP策略[" + delEntity.IPAddress + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await iPStrategyRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除IP策略成功");
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
            return View("SysMger/IPStrategy.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "AutoID desc";
            var pageModel = await iPStrategyRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            var dataJson = pageModel.PagerData.ToJson();
            dataJson = dataJson.Replace("ALLOW", "允许访问").Replace("DENY", "拒绝访问");
            return new MVCPager(pager).Display(dataJson);
        }
        private Expression<Func<IPStrategyInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.IPAddress.Contains(searchKey);
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
            var entity = new IPStrategyInfo();
            if (isModify)
                entity = await iPStrategyRepository.FindAsync(OpID);

            string strIPStart = WebUtils.GetFormString("TextBox1");
            string strIPEnd = WebUtils.GetFormString("TextBox2");            

            //判断IP是否有效
            if (strIPStart.IsNullOrEmpty() && strIPEnd.IsNullOrEmpty())
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");
            else if ((!strIPStart.IsNullOrEmpty() && !strIPStart.IsIP()) || (!strIPEnd.IsNullOrEmpty() && !strIPEnd.IsIP()))
                return OperateResult.FailJson("PLFM_IPAddrInvalid", "不是有效的IP地址");
            else
            {
                if (!string.IsNullOrEmpty(strIPStart) && !string.IsNullOrEmpty(strIPEnd))
                    entity.IPAddress = strIPStart + "-" + strIPEnd;
                else if (!string.IsNullOrEmpty(strIPStart))
                    entity.IPAddress = strIPStart;
                else if (!string.IsNullOrEmpty(strIPEnd))
                    entity.IPAddress = strIPEnd;

                entity.Strategy = WebUtils.GetFormString("DropDownList3");

                if (!isModify)
                {
                    entity.AutoTimeStamp = System.DateTime.Now;
                    if (await iPStrategyRepository.AddAsync(entity) > 0)
                    {
                        await LogService.AddEvent("添加IP策略[" + entity.IPAddress + "]成功");
                        return OperateResult.successJson;
                    }
                }
                if (isModify)
                {
                    if (await iPStrategyRepository.UpdateAsync(entity))
                    {
                        await LogService.AddEvent("修改IP策略[" + entity.IPAddress + "]成功");
                        return OperateResult.successJson;
                    }
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
            ViewBag.InitData = (await iPStrategyRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("SysMger/ModifyIPStrategy.cshtml");
        }

        #endregion

        #endregion
    }
}