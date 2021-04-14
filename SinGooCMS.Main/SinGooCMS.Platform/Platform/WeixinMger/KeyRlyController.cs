using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.WeixinMger
{
    public class KeyRlyController : ManagerPageBase
    {
        const string MODULECODE = "MsgkeyRlyMger";
        private readonly IAutoRlyRepository autoRlyRepository;

        public KeyRlyController(IAutoRlyRepository _autoRlyRepository)
        {
            this.autoRlyRepository = _autoRlyRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await autoRlyRepository.FindAsync(OpID);
            if (delEntity != null && await autoRlyRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除关键字自动回复[" + delEntity.MsgKey + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await autoRlyRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除关键字自动回复成功");
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
            return View("WeixinMger/MessageKeyRly.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "AutoID desc";
            var pageModel = await autoRlyRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<AutoRlyInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.RlyType != "关注回复" && p.RlyType != "默认回复" && p.MsgKey.Contains(searchKey);
            else
                return (p) => p.RlyType != "关注回复" && p.RlyType != "默认回复";
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
            AutoRlyInfo entity = new AutoRlyInfo();
            if (isModify)
                entity = await autoRlyRepository.FindAsync(OpID);

            //赋值
            entity.RlyType = "关键字回复";
            entity.MsgKey = WebUtils.GetFormString("TextBox5");
            entity.MsgText = WebUtils.GetFormString("TextBox1");
            entity.MediaPath = WebUtils.GetFormString("TextBox2");
            entity.Description = WebUtils.GetFormString("TextBox3");
            entity.LinkUrl = WebUtils.GetFormString("TextBox4");
            entity.AutoTimeStamp = System.DateTime.Now;

            if (string.IsNullOrEmpty(entity.MsgText))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                if (await autoRlyRepository.AddAsync(entity) > 0)
                {
                    await LogService.AddEvent("添加微信自动回复关键字[" + entity.MsgKey + "]成功");
                    return OperateResult.successJson;
                }
            }
            if (isModify)
            {
                if (await autoRlyRepository.UpdateAsync(entity))
                {
                    await LogService.AddEvent("修改微信自动回复关键字[" + entity.MsgKey + "]成功");
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
            ViewBag.InitData = (await autoRlyRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("WeixinMger/ModifyMessageKeyRly.cshtml");
        }

        #endregion

        #endregion
    }
}