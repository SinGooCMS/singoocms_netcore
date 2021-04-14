using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform
{
    public class CommentController : UIPageBase
    {
        private readonly IContentRepository contentRepository;
        private readonly ICommentRepository commentRepository;
        private readonly IUser user;

        public CommentController(IContentRepository _contentRepository, ICommentRepository _commentRepository, IUser _user)
        {
            this.contentRepository = _contentRepository;
            this.commentRepository = _commentRepository;
            this.user = _user;
        }

        #region 发表评论

        [HttpPost]
        public async Task<string> Save()
        {
            if (string.Compare(Context.ValidateCode, WebUtils.GetFormString("checkcode"), true) != 0)
                return OperateResult.FailJson("ValidateCodeIncorrect", "验证码不正确！");

            var cont = await contentRepository.FindAsync(WebUtils.GetFormVal<int>("contid"));
            if (cont == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除！");

            string comment = WebUtils.GetFormString("comment");
            if (string.IsNullOrEmpty(comment))
                return OperateResult.FailJson("CMS_CommentContentRequire", "评论内容不为空！");

            return (await commentRepository.Send(comment, cont.AutoID, user.LoginUser.Value)).ToOperateResultJson();
        }

        #endregion

        #region 获取分页列表

        [HttpGet]
        public async Task<string> List()
        {
            int contId = WebUtils.GetQueryVal<int>("contid", 0); //内容Id
            var pageModel = await commentRepository.GetPagerList(contId, pager.PageIndex, pager.PageSize);

            string dataJson = pageModel.PagerData.ToJson();
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            pager.UrlPattern = string.Format("singoo.loadComment({0},$page)", contId);
            string pagerJson = (new MVCPager(pager.UrlPattern, pageModel.TotalRecord, pager.PageIndex, pager.PageSize)).PagerJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":" + pagerJson + "}}";
        }

        #endregion

        #region 分页组件

        [HttpGet]
        public async Task<IActionResult> PageBar()
        {
            int contId = WebUtils.GetQueryVal<int>("contid", 0); //内容Id
            var cmtPager = new Pager(await commentRepository.GetCountAsync(p => p.ContID.Equals(contId)), 10)
            {
                PageIndex = WebUtils.GetQueryVal<int>("pageindex", 1)
            };
            ViewBag.CMTPager = cmtPager;
            return View("inc/_cmtpager.cshtml");
        }

        #endregion
    }
}
