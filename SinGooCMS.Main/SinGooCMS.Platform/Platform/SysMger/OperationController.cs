using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.SysMger
{
    public class OperationController : ManagerPageBase
    {
        const string MODULECODE = "MenuMger";
        private readonly IModuleRepository moduleRepository;
        private readonly IOperateRepository operateRepository;
        private readonly IPurviewRepository purviewRepository;

        public OperationController(IModuleRepository _moduleRepository,
            IOperateRepository _operateRepository,
            IPurviewRepository _purviewRepository)
        {
            this.moduleRepository = _moduleRepository;
            this.operateRepository = _operateRepository;
            this.purviewRepository = _purviewRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.AddOperator)]
        public async Task<string> Add(IFormCollection form)
        {
            var module = await moduleRepository.FindAsync(WebUtils.GetFormVal<int>("_moduleid"));
            var entity = new OperateInfo()
            {
                ModuleID = module.AutoID,
                OperateName = WebUtils.GetFormString("TextBox1"),
                OperateCode = WebUtils.GetFormString("TextBox2"),
                AutoTimeStamp = DateTime.Now
            };

            if (string.IsNullOrEmpty(entity.OperateName) || string.IsNullOrEmpty(entity.OperateCode))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            var result = await operateRepository.AddOperation(entity);
            if (result.ret == ResultType.Success)
            {
                await LogService.AddEvent("添加模板[" + module.ModuleName + "]的操作符[" + entity.OperateName + "]成功");
                return OperateResult.successLoadJson;
            }
            else
                return result.ToOperateResultJson();
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.AddOperator)]
        public async Task<string> AddDefault(IFormCollection form)
        {
            var module = await moduleRepository.FindAsync(WebUtils.GetFormVal<int>("_moduleid"));
            var result = await operateRepository.AddDefaultOperate(module.AutoID);
            if (result.ret == ResultType.Success)
            {
                await LogService.AddEvent("添加模板[" + module.ModuleName + "]的默认操作符成功");
                return OperateResult.successLoadJson;
            }               

            return result.ToOperateResultJson();
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.DeleteOperator)]
        public async Task<string> Delete()
        {
            var delEntity = await operateRepository.FindAsync(OpID);
            if (delEntity != null && await operateRepository.DelOperation(delEntity))
            {
                var module = await moduleRepository.FindAsync(delEntity.ModuleID);
                await LogService.AddEvent($"删除模块[{module?.ModuleName ?? "已删除"}]的操作符[{delEntity.OperateName}]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE, OperationType.ViewOperator)]
        public async Task<IActionResult> Index()
        {
            return View("SysMger/SetOperation.cshtml", await moduleRepository.FindAsync(OpID));
        }

        [HttpGet]
        [Permission(MODULECODE, OperationType.ViewOperator)]
        public async Task<string> DataJson()
        {
            base.pager.PageSize = 5;
            var pageModel = await operateRepository.GetPagerListAsync((p) => p.ModuleID.Equals(OpID), "AutoID asc", pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }

        #endregion

        #endregion        
    }
}