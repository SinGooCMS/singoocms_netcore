using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.UserMger
{
    public class UserLevelController : ManagerPageBase
    {
        const string MODULECODE = "UserLevelMger";
        private readonly IUserLevelRepository userLevelRepository;

        public UserLevelController(IUserLevelRepository _userLevelRepository)
        {
            this.userLevelRepository = _userLevelRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await userLevelRepository.FindAsync(OpID);
            if (delEntity != null && await userLevelRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除会员等级[" + delEntity.LevelName + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs) && await userLevelRepository.DeleteAsync(strIDs))
            {
                await LogService.AddEvent("批量删除会员等级成功");
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
            return View("UserMger/UserLevel.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "Integral asc";
            var pageModel = await userLevelRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<UserLevelInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.LevelName.Contains(searchKey);
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
            var entity = new UserLevelInfo();
            if (isModify)
                entity = await userLevelRepository.FindAsync(OpID);

            entity.LevelName = WebUtils.GetFormString("TextBox1");
            entity.Integral = WebUtils.GetFormVal<int>("TextBox2");
            entity.Discount = 0.0d;
            entity.LevelDesc = WebUtils.GetFormString("TextBox4");
            entity.Sort = 999;

            if (string.IsNullOrEmpty(entity.LevelName))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                if (await userLevelRepository.AddAsync(entity) > 0)
                {
                    await LogService.AddEvent("添加用户等级[" + entity.LevelName + "]成功");
                    return OperateResult.successJson;
                }
            }
            if (isModify)
            {
                if (await userLevelRepository.UpdateAsync(entity))
                {
                    await LogService.AddEvent("修改用户等级[" + entity.LevelName + "]成功");
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
            ViewBag.InitData = (await userLevelRepository.FindAsync(OpID)).ToJson().ToMustacheJson();
            return View("UserMger/ModifyUserLevel.cshtml");
        }

        #endregion

        #endregion
    }
}