using System;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.UserMger
{
    public class AccDetailController : ManagerPageBase
    {
        const string MODULECODE = "AmountOrIntegralDetail";
        private readonly IAccountDetailRepository accountDetailRepository;

        public AccDetailController(IAccountDetailRepository _accountDetailRepository)
        {
            this.accountDetailRepository = _accountDetailRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await accountDetailRepository.FindAsync(OpID);
            if (delEntity != null && await accountDetailRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除会员[" + delEntity.UserName + "]的账户明细成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await accountDetailRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除账户明细成功");
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
            return View("UserMger/AccDetail.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            //数据
            base.sort = "OperateDate desc";
            var pageModel = await accountDetailRepository.GetPagerListAsync(GetCondition(), base.sort, pager.PageIndex, pager.PageSize);
            var lstNew = from item in pageModel.PagerData
                         select new
                         {
                             item.AutoID,
                             item.UserName,
                             item.OpType,
                             item.OpValue,
                             item.After,
                             item.OperateDate,
                             item.Remark,
                             OpValueExt = (item.OpType == 1 ? "+ " : "- ") + item.OpValue.ToString("f2") + (item.Unit == "Amount" ? " 元" : " 积分"),
                             AfterExt = item.After.ToString("f2") + (item.Unit == "Amount" ? " 元" : " 积分"),
                             RemarkExt = "【" + item.OperateDate + "】" + item.Remark
                         };

            string dataJson = lstNew.ToJson();
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;

            //分页
            string pagerJson = new MVCPager(pager).PagerJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":" + pagerJson + "}}";
        }
        private Expression<Func<Domain.Models.AccountDetailInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.UserName.Contains(searchKey);
            else
                return (p) => true;
        }

        #endregion

        #endregion        
    }
}