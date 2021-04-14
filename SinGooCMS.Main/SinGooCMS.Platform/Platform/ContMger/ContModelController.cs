using System;
using System.Linq.Expressions;
using System.Text;
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

namespace SinGooCMS.Platform.ContMger
{
    public class ContModelController : ManagerPageBase
    {
        const string MODULECODE = "ContentModelMger";
        private readonly IContModelRepository contModelRepository;

        public ContModelController(IContModelRepository _contModelRepository)
        {
            this.contModelRepository = _contModelRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await contModelRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            var result = await contModelRepository.DeleteModel(delEntity);
            if (result.ret == ResultType.Success)
            {
                await LogService.AddEvent("删除内容模型[" + delEntity.ModelName + "]成功");
                return OperateResult.successLoadJson;
            }
            else
                return result.ToOperateResultJson();
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("ContMger/ContModelList.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await contModelRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<ContModelInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.ModelName.Contains(searchKey);
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
            var entity = new ContModelInfo();
            if (isModify)
                entity = await contModelRepository.FindAsync(OpID);

            string tableNamePart = WebUtils.GetFormString("TextBox2");
            entity.ModelName = WebUtils.GetFormString("TextBox1");
            entity.TableName = "cms_C_" + tableNamePart;
            entity.ModelDesc = WebUtils.GetFormString("TextBox3");

            if (string.IsNullOrEmpty(entity.ModelName) || string.IsNullOrEmpty(tableNamePart))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.IsUsing = true;
                entity.Creator = Manager.AccountName;
                entity.AutoTimeStamp = DateTime.Now;

                var result = await contModelRepository.AddModel(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("添加模型[" + entity.ModelName + "]成功");

                return result.ToOperateResultJson();
            }
            if (isModify)
            {
                if (await contModelRepository.UpdateAsync(entity))
                {
                    await LogService.AddEvent("修改模型[" + entity.ModelName + "]成功");
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
            ViewBag.InitData = (await contModelRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("ContMger/ModifyModel.cshtml");
        }

        #endregion

        #endregion
    }
}