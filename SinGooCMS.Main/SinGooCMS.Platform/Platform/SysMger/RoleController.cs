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
    public class RoleController : ManagerPageBase
    {
        const string MODULECODE = "RoleMger";
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository _roleRepository)
        {
            this.roleRepository = _roleRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await roleRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            if (delEntity.IsSystem)
                return OperateResult.FailJson("PLFM_SysRoleDeleteDenied", "系统角色不可删除");

            var result = await roleRepository.DelRole(OpID);
            if (result.ret == ResultType.Success)
            {
                await LogService.AddEvent("删除角色[" + delEntity.RoleName + "]成功");
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
            return View("SysMger/Role.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await roleRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<RoleInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.RoleName.Contains(searchKey);
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
            var entity = new RoleInfo();
            if (isModify)
                entity = await roleRepository.FindAsync(OpID);

            if (!isModify)
                entity.RoleName = WebUtils.GetFormString("TextBox1");

            entity.Remark = WebUtils.GetFormString("TextBox2");

            if (string.IsNullOrEmpty(entity.RoleName))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");
            else if (IsAdd && await roleRepository.ExistsName(entity.RoleName))
                return OperateResult.FailJson("OperationObjectExists", "操作对象已存在");
            else
            {
                if (!isModify)
                {
                    entity.IsSystem = false;
                    entity.Sort = roleRepository.MaxSort.Value + 1;
                    entity.AutoTimeStamp = System.DateTime.Now;

                    if (await roleRepository.AddAsync(entity) > 0)
                    {
                        await LogService.AddEvent("添加角色[" + entity.RoleName + "]成功");
                        return OperateResult.successJson;
                    }
                }
                if (isModify)
                {
                    if (await roleRepository.UpdateAsync(entity))
                    {
                        await LogService.AddEvent("修改角色[" + entity.RoleName + "]成功");
                        return OperateResult.successJson;
                    }
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
            ViewBag.InitData = (await roleRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("SysMger/ModifyRole.cshtml");
        }

        #endregion

        #endregion
    }
}