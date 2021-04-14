using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Application;

namespace SinGooCMS.Platform
{
    [Obsolete("弃用！异常日志记录到/log目录下，事件日志在后台可查看")]
    public class LogController : UIPageBase
    {
        private readonly IVisitorRepository visitorRepository;
        public LogController(IVisitorRepository _visitorRepository)
        {
            this.visitorRepository = _visitorRepository;
        }

        #region 显示日志列表

        [HttpGet]
        public async Task<IActionResult> ShowLog()
        {
            base.sort = " AutoID desc ";
            var pageModel = await visitorRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.UrlPattern = "/log/showlog?page=$page";
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;

            ViewBag.Data = pageModel.PagerData;
            ViewBag.Pager = new MVCPager(pager); //new MVCPager(pager.UrlPattern, pager.TotalRecord, pager.PageIndex, pager.PageSize);

            //呈现模板
            return ViewOrigin("/views/log/showlog.cshtml");
        }

        private string GetCondition()
        {
            string strCondition = " 1=1 AND (ErrMessage is not null AND ErrMessage<>'') ";
            //日期开始
            DateTime dtStart = WebUtils.GetQueryDatetime("tstart", System.DateTime.Now.AddMonths(-1));
            //日期结束
            DateTime dtEnd = WebUtils.GetQueryDatetime("tend", System.DateTime.Now);

            if (dtStart > new DateTime(1900, 1, 1))
                strCondition += $" AND AutoTimeStamp>='{dtStart.ToString("yyyy-MM-dd")} 00:00:00' ";

            if (dtEnd > new DateTime(1900, 1, 1))
                strCondition += $" AND AutoTimeStamp<='{dtEnd.ToString("yyyy-MM-dd")} 23:59:59' ";

            string ip = WebUtils.GetQueryString("ip");
            strCondition += $" AND IPAddress like '%{ip}%' ";

            //关键字
            string key = WebUtils.GetQueryString("key");
            if (!string.IsNullOrEmpty(key))
                strCondition += $" AND ErrMessage like '%{key}%' AND StackTrace like '%{key}%' ";

            return strCondition;
        }

        #endregion

        #region 显示日志详情

        public async Task<IActionResult> ShowLogDetail()
        {
            ViewBag.Data = await visitorRepository.FindAsync(WebUtils.GetQueryVal<int>("opid"));
            return ViewOrigin("/views/log/showlogdetail.cshtml");
        }

        #endregion
    }
}
