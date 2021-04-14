using System;
using System.Text;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.SysMger
{
    public class PermissionController : ManagerPageBase
    {
        const string MODULECODE = "RoleMger";
        private readonly ICatalogRepository catalogRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IOperateRepository operateRepository;
        private readonly IPurviewRepository purviewRepository;

        public PermissionController(
            ICatalogRepository _catalogRepository,
            IRoleRepository _roleRepository,
            IOperateRepository _operateRepository,
            IPurviewRepository _purviewRepository)
        {
            this.catalogRepository = _catalogRepository;
            this.roleRepository = _roleRepository;
            this.operateRepository = _operateRepository;
            this.purviewRepository = _purviewRepository;
        }

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.SetRolePermission)]
        public async Task<string> Index(IFormCollection form)
        {
            var role = await roleRepository.FindAsync(OpID);
            //只能设置非超级管理员的权限
            if (role != null && role.RoleName != "超级管理员")
            {
                //1|Delete,1|Add,1|View,1|Modify
                //string strData = form["purviewcollect"];
                if (await purviewRepository.SavePurviews(role.AutoID, form["purviewcollect"]))
                {
                    await LogService.AddEvent("更新角色[" + role.RoleName + "]的权限设置成功");
                    return OperateResult.successJson;
                }
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE,OperationType.ViewRolePermission)]
        public async Task<IActionResult> Index()
        {
            ViewBag.Permission = await GetPurviewHtml();
            return View("SysMger/SetPurview.cshtml", await roleRepository.FindAsync(OpID));
        }

        /// <summary>
        /// 填充数据
        /// </summary>
        private async Task<string> GetPurviewHtml()
        {
            var lstCurrentRolePruview = await purviewRepository.GetPurviews(OpID); //OpID 是角色的ID            
            var lstCatalog = await catalogRepository.GetAllAsync();
            var builder = new StringBuilder();
            if (lstCatalog != null && lstCatalog.Count() > 0)
            {
                //添加模块及操作
                var dt = operateRepository.GetOperateRelation();
                foreach (var itemCatalog in lstCatalog)
                {
                    builder.Append("<div id=\"" + itemCatalog.CatalogCode + "\">");
                    builder.Append("<h1 class=\"titlebar2\">" + itemCatalog.CatalogName + "</h1>");

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string strModuleName = string.Empty;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (itemCatalog.AutoID == Convert.ToInt32(dt.Rows[i]["CatalogID"].ToString()))
                            {
                                #region 填充数据

                                bool boolHasPurview = false;
                                foreach (PurviewInfo item in lstCurrentRolePruview)
                                {
                                    if (item.ModuleID == Convert.ToInt32(dt.Rows[i]["AutoID"]) && item.OperateCode == dt.Rows[i]["OperateCode"].ToString())
                                    {
                                        boolHasPurview = true;
                                        break;
                                    }
                                }

                                //选择当前的模块权限设置
                                if (dt.Rows[i]["ModuleName"].ToString() != strModuleName)
                                {
                                    strModuleName = dt.Rows[i]["ModuleName"].ToString();
                                    builder.Append(" <table cellpadding=\"0\" cellspacing=\"0\" class=\"tablechild1\"><tr>"
                                              + "<td style=\"width: 20%; height: 22px\"><div class='clear-fix fl auth'><label><input type='checkbox' sname='s1' class=\"common-check\"><span></span></label><span class='fl'>" + strModuleName + "</span></div></td><td style=\"width: 80%\">");

                                }

                                //权限操作复选项
                                if (!string.IsNullOrEmpty(dt.Rows[i]["OperateName"].ToString()))
                                {
                                    builder.Append("<div class='clear-fix fl auth'><label><input class=\"common-check\" name=\"purviewcollect\" value=\"" + dt.Rows[i]["AutoID"].ToString() + "|" + dt.Rows[i]["OperateCode"].ToString() + "\" " + (boolHasPurview ? "checked='checked'" : "") + " type='checkbox'><span></span></label><span class='fl'>" + dt.Rows[i]["OperateName"].ToString() + "</span></div>");
                                }

                                if (i == dt.Rows.Count - 1 || strModuleName != dt.Rows[i + 1]["ModuleName"].ToString())
                                {
                                    builder.Append("</td></tr></table>");
                                }

                                #endregion
                            }
                        }
                    }

                    builder.Append("</div>");
                }
            }

            return builder.ToString();
        }

        #endregion
    }
}
