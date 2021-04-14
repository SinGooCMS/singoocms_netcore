using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.SysMger
{
    public class RoleSetController : ManagerPageBase
    {
        const string MODULECODE = "AccountMger";
        private readonly IRoleRepository roleRepository;
        private readonly IAccountRepository accountRepository;

        public RoleSetController(IRoleRepository _roleRepository, IAccountRepository _accountRepository)
        {
            this.roleRepository = _roleRepository;
            this.accountRepository = _accountRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.SetAccountRole)]
        public async Task<string> Index(IFormCollection form)
        {
            return await SetAccountRoles();
        }

        /// <summary>
        /// 设置账户的角色
        /// </summary>
        /// <returns></returns>
        private async Task<string> SetAccountRoles()
        {
            var account =await accountRepository.FindAsync(OpID);
            account.Roles = WebUtils.GetFormString("chk");
            if (await accountRepository.UpdateAsync(account))
            {
                await LogService.AddEvent("设置帐户[" + account.AccountName + "]的角色成功");
                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("SysMger/SetRoles.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var account =await accountRepository.FindAsync(OpID);
            var roles = account == null ? "" : account.Roles;

            //数据
            base.sort = "Sort asc,AutoID desc";
            base.pager.PageSize = 5;

            var pageModel =await roleRepository.GetPagerDTAsync(GetCondition(), base.sort, pager.PageIndex,pager.PageSize);
            var dt = pageModel?.PagerData;
            dt.Columns.Add(new DataColumn("selected", typeof(Boolean)));
            foreach (DataRow dr in dt.Rows)
                dr["selected"] = roles.Split(',').Contains(dr["AutoID"].ToString());

            string dataJson = dt.ToJson();
            string pagerJson = new MVCPager(pager) { IsShowPageSize = false }.PagerJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":" + pagerJson + "}}";
        }
        private string GetCondition()
        {
            var builder = new StringBuilder("1=1");
            return builder.ToString();
        }

        #endregion

        #endregion        
    }
}