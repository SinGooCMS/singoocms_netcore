using System;
using System.Linq.Expressions;
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
    public class AccountMgerController : ManagerPageBase
    {
        const string MODULECODE = "AccountMger";
        private readonly IAccountRepository accountRepository;

        public AccountMgerController(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await accountRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            if (Manager.LoginAccount.AutoID == delEntity.AutoID)
                return OperateResult.FailJson("PLFM_CurrAccountIsLoging", "当前帐户正在登录,不可删除");

            var result = await accountRepository.DelAccount(delEntity);
            if (result.ret == ResultType.Success)
            {
                await LogService.AddEvent("删除管理帐户[" + delEntity.AccountName + "]成功");
                return OperateResult.successLoadJson;
            }

            return result.ToOperateResultJson();
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("SysMger/AccountMger.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            sort = "LastLoginTime desc,AutoID desc";
            var pageModel = await accountRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<AccountInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.AccountName.Contains(searchKey);
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
            AccountInfo entity = new AccountInfo();
            if (isModify)
                entity = await accountRepository.FindAsync(OpID);

            string strPassword = WebUtils.GetFormString("TextBox2");
            entity.AccountName = WebUtils.GetFormString("TextBox1");
            entity.Email = WebUtils.GetFormString("TextBox3");
            entity.Mobile = WebUtils.GetFormString("TextBox4");
            entity.AutoTimeStamp = System.DateTime.Now;

            if (entity.AccountName.IsNullOrEmpty() || strPassword.IsNullOrEmpty())
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.Password = DEncryptUtils.SHA512Encrypt(strPassword);
                entity.IsSystem = false;

                var result = await accountRepository.AddAccount(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("添加角色[" + entity.AccountName + "]成功");

                return result.ToOperateResultJson();
            }
            if (isModify)
            {
                if (!string.IsNullOrEmpty(strPassword))
                    entity.Password = DEncryptUtils.SHA512Encrypt(strPassword);

                var result = await accountRepository.UpdateAccount(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("修改角色[" + entity.AccountName + "]成功");

                return result.ToOperateResultJson();
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Edit()
        {
            ViewBag.InitData = (await accountRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("SysMger/ModifyAccountMger.cshtml");
        }

        #endregion

        #endregion
    }
}