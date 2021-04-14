using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.SysMger
{
    public class SysLogController : ManagerPageBase
    {
        const string MODULECODE = "SystemLogMger";
        private readonly IEventLogRepository eventLogRepository;

        public SysLogController(IEventLogRepository _eventLogRepository)
        {
            this.eventLogRepository = _eventLogRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await eventLogRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("删除管理日志成功");
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
            ViewBag.IsSuperAdmin = Manager.AccountName == "superadmin";
            return View("SysMger/SysLog.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "AutoID desc";
            var pageModel = await eventLogRepository.GetPagerListAsync(GetCondition(), base.sort, pager.PageIndex, pager.PageSize);
            var lst = pageModel?.PagerData;
            foreach (var item in lst)
            {
                item.IPAddress += ((item.IPArea == "未知地址或者获取地址失败" || item.IPArea == "") ? "" : " [" + item.IPArea + "]");
                item.EventInfo = "[" + EnumUtils.GetEnumDescription((EventType)item.EventType) + "] " + item.EventInfo;
            }
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            string pagerJson = new MVCPager(pager).PagerJson();
            string dataJson = lst.ToJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":" + pagerJson + "}}";
        }
        private Expression<Func<Domain.Models.EventLogInfo,bool>> GetCondition()
        {
            int eventType = WebUtils.GetQueryVal<int>("logtype", -1); //日志类型
            if (eventType == -1)
                return p => p.UserName.Contains(searchKey) || p.EventInfo.Contains(searchKey);
            else
                return p => p.EventType == eventType && (p.UserName.Contains(searchKey) || p.EventInfo.Contains(searchKey));
        }

        #endregion

        #endregion        
    }
}
