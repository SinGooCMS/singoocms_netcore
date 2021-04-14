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
    public class MessageMgerController : ManagerPageBase
    {
        const string MODULECODE = "MessageMger";
        private readonly IMessageRepository messageRepository;

        public MessageMgerController(IMessageRepository _messageRepository)
        {
            this.messageRepository = _messageRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await messageRepository.FindAsync(OpID);
            if (delEntity != null && await messageRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除站内消息[" + delEntity.MsgBody + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await messageRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除站内消息成功");
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
            return View("UserMger/MessageMger.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "AutoID desc";
            var pageModel = await messageRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<Domain.Models.MessageInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.Receiver.Contains(searchKey) || p.MsgBody.Contains(searchKey);
            else
                return (p) => true;
        }

        #endregion

        #endregion        
    }
}