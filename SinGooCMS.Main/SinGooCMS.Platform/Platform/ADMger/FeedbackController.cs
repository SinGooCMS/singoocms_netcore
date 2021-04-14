using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SinGooCMS.Application;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain;
using SinGooCMS.Application.Interface;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.ADMger
{
    public class FeedbackController : ManagerPageBase
    {
        const string MODULECODE = "Feedback";
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IMessageService messageService;

        public FeedbackController(IFeedbackRepository _feedbackRepository, IMessageService _messageService)
        {
            this.feedbackRepository = _feedbackRepository;
            this.messageService = _messageService;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await feedbackRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            if (delEntity.ReplyID == 0 && await feedbackRepository.DelTopicAsync(delEntity.AutoID))
            {
                await LogService.AddEvent("删除留言[" + delEntity.Content + "]及其回复成功");
                return OperateResult.successLoadJson;
            }
            else if (delEntity.RootID > 0 && await feedbackRepository.DeleteAsync(delEntity.AutoID))
            {
                await LogService.AddEvent("删除留言回复[" + delEntity.Content + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await feedbackRepository.DelMutli(strIDs))
            {
                await LogService.AddEvent("批量删除留言成功");
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
            return View("ADMger/Feedback.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "AutoID desc";
            var pageModel = await feedbackRepository.GetPagerWithReplyCount(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> Reply(int id)
        {
            //读取留言的回复
            var dataJson = (await feedbackRepository.GetListAsync(1000, $" RootID={id} AND AutoID<>{id} ", "AutoID desc")).ToJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "" : "") + "}}";
        }
        private string GetCondition()
        {
            var builder = new StringBuilder(" ReplyID=0 ");
            if (searchKey.Length > 0)
                builder.Append($" AND (Title like '%{StringUtils.ChkSQL(searchKey)}%' or Content like '%{StringUtils.ChkSQL(searchKey)}%') ");

            return builder.ToString();
        }

        #endregion

        #endregion

        #region 编辑

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Add)]
        public async Task<string> EditAsync(IFormCollection form)
        {
            var feedback = await feedbackRepository.FindAsync(OpID);
            string content = HttpUtility.HtmlEncode(form["txtReply"]);

            if (string.IsNullOrEmpty(content))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            string title = "回复:" + feedback.Title;

            //回复留言
            if (await feedbackRepository.Send(content, Manager.AccountName, feedback, title, Manager.LoginAccount?.Email, Manager.LoginAccount?.Mobile))
            {
                //是否发送消息到邮箱
                string strEmail = WebUtils.GetFormString("txtMail");
                bool isSendMail = WebUtils.GetFormString("chkReply2Mail") == "on";
                string strSendMsg = $"来自【{Manager.AccountName}】的回复：<br/><div style='border-bottom:1px solid #ccc'>{content}</div><br/>{Context.SiteConfig.SiteName}({Context.SiteConfig.SiteDomain})";

                if (isSendMail && strEmail.IsEmail())
                    await messageService.SendMail(strEmail, title, strSendMsg);

                await LogService.AddEvent("回复留言[" + feedback.Title + "]成功");
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
            ViewBag.InitData = (await feedbackRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("ADMger/FeedbackDetail.cshtml");
        }

        #endregion

        #endregion
    }
}