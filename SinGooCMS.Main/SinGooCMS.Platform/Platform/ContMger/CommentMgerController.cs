using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Models;
using SinGooCMS.Application;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform
{
    public class CommentMgerController : ManagerPageBase
    {
        const string MODULECODE = "CommentMger";
        private readonly IContentRepository contentRepository;
        private readonly ICommentRepository commentRepository;

        public CommentMgerController(IContentRepository _contentRepository, ICommentRepository _commentRepository)
        {
            this.contentRepository = _contentRepository;
            this.commentRepository = _commentRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await commentRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");
            else if (delEntity.ReplyID == 0 && await commentRepository.DelTopic(OpID))
            {
                await LogService.AddEvent("删除评论[" + StringUtils.Cut(delEntity.Comment, 15, "...") + "]及其回复成功");
                return OperateResult.successLoadJson;
            }
            else if (delEntity.ReplyID != 0 && await commentRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除评论回复[" + StringUtils.Cut(delEntity.Comment, 15, "...") + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await commentRepository.DelMutli(strIDs))
            {
                await LogService.AddEvent("批量删除评论成功");
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
            return View("ContMger/CommentMger.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "AutoID desc";
            var pageModel = await commentRepository.GetPagerListWithReCount(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private string GetCondition()
        {
            return !searchKey.IsNullOrEmpty()
                ? $" Comment like '%{StringUtils.ChkSQL(searchKey)}%' "
                : "";
        }

        #endregion

        #endregion

        #region 编辑

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> Modify(IFormCollection form)
        {
            var entity = await commentRepository.FindAsync(OpID);
            entity.Comment = WebUtils.GetFormString("comment");
            entity.IsAudit = WebUtils.GetFormVal<int>("isaudit") == 1;
            if (await commentRepository.UpdateAsync(entity))
            {
                await LogService.AddEvent("修改评论[" + StringUtils.Cut(entity.Comment, 10, "...") + "]成功");
                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Edit()
        {
            var comment = await commentRepository.FindAsync(OpID);
            ViewBag.Cont = await contentRepository.FindAsync(comment?.ContID);
            ViewBag.InitData = comment.ToJson().ToMustacheJson();
            return View("ContMger/ModifyComment.cshtml");
        }

        #endregion

        #endregion
    }
}