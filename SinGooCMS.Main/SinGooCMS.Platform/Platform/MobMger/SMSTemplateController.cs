using System;
using System.Text;
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

namespace SinGooCMS.Platform.MobMger
{
    public class SMSTemplateController : ManagerPageBase
    {
        const string MODULECODE = "SMSTemplateMger";
        private readonly ISMSTemplateRepository sMSTemplateRepository;

        public SMSTemplateController(ISMSTemplateRepository _sMSTemplateRepository)
        {
            this.sMSTemplateRepository = _sMSTemplateRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await sMSTemplateRepository.FindAsync(OpID);
            if (delEntity != null && await sMSTemplateRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除短信模板[" + delEntity.TemplTitle + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await sMSTemplateRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除短信模板成功");
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
            return View("MobMger/SMSTemplate.cshtml");
        }
        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "AutoID desc";
            var pageModel = await sMSTemplateRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<SMSTemplateInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.TemplName.Contains(searchKey) || p.TemplTitle.Contains(searchKey);
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
            var entity = new SMSTemplateInfo();
            if (isModify)
                entity = await sMSTemplateRepository.FindAsync(OpID);

            entity.TemplName = WebUtils.GetFormString("TextBox1");
            entity.TemplTitle = WebUtils.GetFormString("TextBox2");
            entity.TemplCode = WebUtils.GetFormString("TextBox3");
            entity.TemplBody = WebUtils.GetFormString("TextBox4");
            entity.TemplKeys = WebUtils.GetFormString("TextBox5");

            if (string.IsNullOrEmpty(entity.TemplName) || string.IsNullOrEmpty(entity.TemplTitle) || string.IsNullOrEmpty(entity.TemplBody) || string.IsNullOrEmpty(entity.TemplKeys))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.AutoTimeStamp = DateTime.Now;
                if (await sMSTemplateRepository.AddAsync(entity) > 0)
                {
                    await LogService.AddEvent("添加短信模板[" + entity.TemplTitle + "]成功");
                    return OperateResult.successJson;
                }
            }
            if (isModify)
            {
                if (await sMSTemplateRepository.UpdateAsync(entity))
                {
                    await LogService.AddEvent("修改短信模板[" + entity.TemplTitle + "]成功");
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
            ViewBag.InitData = (await sMSTemplateRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("MobMger/ModifySMSTemplate.cshtml");
        }

        #endregion

        #endregion
    }
}