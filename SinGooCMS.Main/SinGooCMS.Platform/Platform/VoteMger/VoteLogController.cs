using System;
using System.Collections.Generic;
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

namespace SinGooCMS.Platform.VoteMger
{
    public class VoteLogController : ManagerPageBase
    {
        const string MODULECODE = "VoteMger";
        private readonly IVoteLogRepository voteLogRepository;

        public VoteLogController(IVoteLogRepository _voteLogRepository)
        {
            this.voteLogRepository = _voteLogRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.DeleteLog)]
        public async Task<string> Delete()
        {
            var delEntity = await voteLogRepository.FindAsync(OpID);
            if (delEntity != null && await voteLogRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent($"删除投票记录[UserName:{delEntity.UserName},IPAddress:{delEntity.IpAddress}]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.DeleteLog)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await voteLogRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除投票记录成功");
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
            return View("VoteMger/VoteLogList.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "AutoID desc";
            var pageModel = await voteLogRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<VoteLogInfo, bool>> GetCondition()
        {
            var voteId = WebUtils.GetQueryVal<int>("VoteId");
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.VoteID == voteId && (p.IpAddress.Contains(searchKey) || p.UserName.Contains(searchKey));
            else
                return (p) => p.VoteID == voteId;
        }

        #endregion

        #endregion        
    }
}