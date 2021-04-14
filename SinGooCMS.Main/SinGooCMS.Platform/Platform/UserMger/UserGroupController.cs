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
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.UserMger
{
    public class UserGroupController : ManagerPageBase
    {
        const string MODULECODE = "UserGroupMger";
        private readonly IUserGroupRepository userGroupRepository;
        private readonly IManager manager;

        public UserGroupController(IUserGroupRepository _userGroupRepository, IManager _manager)
        {
            this.userGroupRepository = _userGroupRepository;
            this.manager = _manager;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await userGroupRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            var result = await userGroupRepository.DelGroup(delEntity);
            if (result.ret == ResultType.Success)
            {
                await LogService.AddEvent("删除会员组[" + delEntity.GroupName + "]成功");
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
            return View("UserMger/UserGroup.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await userGroupRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<UserGroupInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.GroupName.Contains(searchKey);
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
            var entity = new UserGroupInfo();
            if (isModify)
                entity = await userGroupRepository.FindAsync(OpID);

            string tableNamePart = WebUtils.GetFormString("TextBox2");
            entity.GroupName = WebUtils.GetFormString("TextBox1");
            entity.TableName = "cms_U_" + tableNamePart;
            entity.GroupDesc = WebUtils.GetFormString("TextBox3");
            entity.Sort = 999;
            entity.Creator = manager.AccountName;

            if (string.IsNullOrEmpty(entity.GroupName) || string.IsNullOrEmpty(tableNamePart))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.AutoTimeStamp = DateTime.Now;
                var result = await userGroupRepository.AddGroup(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("添加用户组[" + entity.GroupName + "]成功");

                return result.ToOperateResultJson();
            }
            if (isModify)
            {
                if (await userGroupRepository.UpdateGroup(entity))
                {
                    await LogService.AddEvent("修改用户组[" + entity.GroupName + "]成功");
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
            ViewBag.InitData = (await userGroupRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("UserMger/ModifyUserGroup.cshtml");
        }

        #endregion

        #endregion
    }
}