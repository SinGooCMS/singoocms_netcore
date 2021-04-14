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
    public class VoteMgerController : ManagerPageBase
    {
        const string MODULECODE = "VoteMger";
        private readonly IVoteRepository voteRepository;

        public VoteMgerController(IVoteRepository _voteRepository)
        {
            this.voteRepository = _voteRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await voteRepository.FindAsync(OpID);
            if (delEntity != null && await voteRepository.DelVote(delEntity))
            {
                await LogService.AddEvent("删除投票调查[" + delEntity.Title + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await voteRepository.DelVotes(strIDs))
            {
                await LogService.AddEvent("批量删除投票调查成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort()
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await voteRepository.UpdateSortAsync(dictIDAndSort))
            {
                //写入日志
                await LogService.AddEvent("设置标题排序成功");
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
            return View("VoteMger/VoteList.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await voteRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<VoteInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.Title.Contains(searchKey);
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
            var entity = new VoteInfo();
            if (isModify)
                entity = await voteRepository.FindAsync(OpID);

            entity.Title = WebUtils.GetFormString("TextBox1");
            entity.IsMultiChoice = WebUtils.GetFormString("chkDuo") == "on";
            entity.IsAnonymous = WebUtils.GetFormString("chkAny") == "on";
            entity.IsAudit = WebUtils.GetFormString("chkClose") == "on";

            string strItems = Request.Form["voteitem_txt"].ToString();
            string strIds = Request.Form["voteitem_id"].ToString();
            if (string.IsNullOrEmpty(entity.Title))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");
            if (string.IsNullOrEmpty(strItems))
                return OperateResult.FailJson("Vote_OneVoteRequire","请输入至少一个投票选项");

            var lstItem = new List<VoteItemInfo>();
            var arrItems = strItems.Split(',');
            var arrIds = strIds.Split(',');
            for (var i = 0; i < arrItems.Length; i++)
            {
                if (arrItems[i].Trim().Length == 0)
                    continue;

                lstItem.Add(new VoteItemInfo()
                {
                    ItemID = (arrIds.Length > i && !arrIds[i].IsNullOrEmpty()) ? arrIds[i] : StringUtils.GetGUID(),
                    VoteOption = arrItems[i],
                    Sort = i + 1
                });
            }
            entity.Items = lstItem.ToJson();

            if (!isModify)
            {
                entity.Lang = Context.CurrLang;
                entity.Creator = Manager.AccountName;
                entity.AutoTimeStamp = DateTime.Now;

                if (await voteRepository.AddAsync(entity) > 0)
                {
                    await LogService.AddEvent("添加投票调查[" + entity.Title + "]成功");
                    return OperateResult.successJson;
                }
            }
            if (isModify)
            {
                if (await voteRepository.UpdateAsync(entity))
                {
                    await LogService.AddEvent("修改投票调查[" + entity.Title + "]成功");
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
            return View("VoteMger/ModifyVote.cshtml", (await voteRepository.GetVoteFull(OpID)) ?? new VoteInfo());
        }

        #endregion

        #endregion
    }
}