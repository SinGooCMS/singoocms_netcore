using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.SysMger
{
    public class VisitorLogController : ManagerPageBase
    {
        const string MODULECODE = "VisitorLogMger";
        public readonly IVisitorRepository visitorRepository;

        public VisitorLogController(IVisitorRepository _visitorRepository)
        {
            this.visitorRepository = _visitorRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await visitorRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("清空访问记录");
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
            return View("SysMger/VisitorLog.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "AutoID desc";
            var pageModel = await visitorRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<Domain.Models.VisitorInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.ApproachUrl.Contains(searchKey) || p.VPage.Contains(searchKey);
            else
                return (p) => true;
        }

        #endregion

        #endregion

        #region 详情        

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Detail()
        {
            ViewBag.InitData = (await visitorRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("SysMger/VisitDetail.cshtml");
        }

        #endregion

        #endregion
    }
}