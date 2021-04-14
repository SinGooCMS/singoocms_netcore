using System;
using System.IO;
using System.Linq;
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

namespace SinGooCMS.Platform.TemplateMger
{
    public class TemplateController : ManagerPageBase
    {
        const string MODULECODE = "TemplateMger";
        private readonly ISiteTemplateRepository siteTemplateRepository;

        public TemplateController(ISiteTemplateRepository _siteTemplateRepository)
        {
            this.siteTemplateRepository = _siteTemplateRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await siteTemplateRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            if (Context.DefaultSiteTmpl.AutoID == delEntity.AutoID)
                return OperateResult.FailJson("CMS_CurrTmplIsUsing", "当前模板正在使用中");

            if (await siteTemplateRepository.DeleteTmplAsync(delEntity))
            {
                await LogService.AddEvent("删除模板[" + delEntity.TemplateName + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.SetDefTmpl)]
        public async Task<string> SetDefault()
        {
            var siteTemplate = await siteTemplateRepository.FindAsync(OpID);
            if (siteTemplate == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除！");

            if (!Directory.Exists(SinGooBase.GetMapPath(siteTemplate.TemplatePath)))
                return OperateResult.FailJson("CMS_TmplFolderNotExists", "模板文件不存在！");

            if (await siteTemplateRepository.SetDefaultTmpl(siteTemplate.AutoID))
            {
                await LogService.AddEvent("设置模板[" + siteTemplate.TemplateName + "]为当前默认使用的模板");
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
            return View("TemplateMger/TemplateList.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.pager.PageSize = 9;
            base.sort = "Sort asc,AutoID desc";
            var pageModel = await siteTemplateRepository.GetPagerListAsync(GetCondition(), base.sort, pager.PageIndex, pager.PageSize);
            var lstNew = from item in pageModel.PagerData
                         select new
                         {
                             item.AutoID,
                             item.TemplateName,
                             item.TemplatePath,
                             item.ShowPic,
                             item.IsDefault,
                             ShowPicExt = item.ShowPic.IsNullOrEmpty() ? "/Include/Images/nophoto.jpg" : item.ShowPic,
                             TemplateNameExt = StringUtils.Cut(item.TemplateName, 7)
                         };
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            string dataJson = lstNew.ToJson();
            string pagerJson = new MVCPager(pager) { IsShowPageSize = false }.PagerJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":" + pagerJson + "}}";
        }
        private Expression<Func<SiteTemplateInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.TemplateName.Contains(searchKey);
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
            var entity = new SiteTemplateInfo();
            if (isModify)
                entity = await siteTemplateRepository.FindAsync(OpID);

            entity.TemplateName = WebUtils.GetFormString("TextBox1");
            entity.TemplatePath = WebUtils.GetFormString("ddlTmplPath");
            entity.ShowPic = WebUtils.GetFormString("previmg");
            entity.HomePage = WebUtils.GetFormString("TextBox3");
            entity.TemplateDesc = WebUtils.GetFormString("TextBox4");
            entity.IsAudit = true;
            entity.Author = WebUtils.GetFormString("TextBox6");
            entity.CopyRight = "SinGooCMS";

            if (entity.TemplateName.IsNullOrEmpty() || entity.TemplatePath.IsNullOrEmpty())
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.AutoTimeStamp = DateTime.Now;
                if (await siteTemplateRepository.AddTmplAsync(entity) > 0)
                {
                    await LogService.AddEvent("添加模板[" + entity.TemplateName + "]成功");
                    return OperateResult.successJson;
                }
            }
            if (isModify)
            {
                if (await siteTemplateRepository.UpdateTmplAsync(entity))
                {
                    await LogService.AddEvent("修改模板[" + entity.TemplateName + "]成功");
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
            ViewBag.InitData = (await siteTemplateRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            ViewBag.TmplDirs = siteTemplateRepository.GetTmplDirs().ToJson();
            return View("TemplateMger/TemplateModify.cshtml");
        }

        #endregion

        #endregion
    }
}