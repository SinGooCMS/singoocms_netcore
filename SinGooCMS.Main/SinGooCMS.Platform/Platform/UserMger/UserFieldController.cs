using System;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Control;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.UserMger
{
    public class UserFieldController : ManagerPageBase
    {
        const string MODULECODE = "UserGroupMger";
        private readonly IUserFieldRepository userFieldRepository;
        private readonly IUserGroupRepository userGroupRepository;

        public UserFieldController(
            IUserFieldRepository _userFieldRepository,
            IUserGroupRepository _userGroupRepository)
        {
            this.userFieldRepository = _userFieldRepository;
            this.userGroupRepository = _userGroupRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.DeleteField)]
        public async Task<string> Delete()
        {
            var delEntity = await userFieldRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");
            else if (await userFieldRepository.DeleteAsync(delEntity))
            {
                await LogService.AddEvent("删除字段[" + delEntity.FieldName + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.ModifyField)]
        public async Task<string> SetSort()
        {
            var dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await userFieldRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("设置会员字段排序成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        #region 启用和停用

        [HttpPost]
        [Permission(MODULECODE, OperationType.SetEnabled)]
        public async Task<string> SetEnabled(string groupName)
        {
            return await Set(groupName, WebUtils.GetFormString("chk"), true);
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.SetUnEnabled)]
        public async Task<string> SetUnEnabled(string groupName)
        {
            return await Set(groupName, WebUtils.GetFormString("chk"), false);
        }

        private async Task<string> Set(string groupName, string ids, bool enabled)
        {
            if (string.IsNullOrEmpty(ids))
                return OperateResult.FailJson("NothingSelected", "没有选择任何项！");

            if (await userFieldRepository.SetEnabled(ids, enabled))
            {
                await LogService.AddEvent("批量" + (enabled ? "启用" : "停用") + "会员组[" + groupName + "]的字段");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE,OperationType.ViewField)]
        public IActionResult Index()
        {
            ViewBag.GroupID = WebUtils.GetQueryVal<int>("GroupID");
            return View("UserMger/UserFieldList.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE, OperationType.ViewField)]
        public async Task<string> DataJson()
        {
            var pageModel = await userFieldRepository.GetPagerListAsync(GetCondition(), base.sort, pager.PageIndex, pager.PageSize);
            var lstNew = from item in pageModel.PagerData
                         select new
                         {
                             item.AutoID,
                             item.FieldName,
                             item.FieldType,
                             FieldTypeExt = EnumUtils.GetEnumDescription(EnumUtils.StringToEnum<FieldType>(item.FieldType)),
                             item.DataType,
                             item.FieldAlias,
                             item.EnableNull,
                             item.IsUsing,
                             item.IsSystem,
                             item.Sort,
                             item.AutoTimeStamp
                         };

            string dataJson = lstNew.ToJson();
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;

            string pagerJson = new MVCPager(pager).PagerJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":" + pagerJson + "}}";
        }
        private string GetCondition()
        {
            var builder = new StringBuilder("1=1 AND IsUsing=1 AND UserGroupID=" + WebUtils.GetQueryVal<int>("GroupID"));

            if (WebUtils.GetQueryString("ckViewUnEnabled") == "on")
                builder.Replace("AND IsUsing=1", ""); //显示全部字段

            if (!string.IsNullOrEmpty(searchKey))
                builder.Append($" AND (FieldName like '%{StringUtils.ChkSQL(searchKey)}%' or FieldAlias like '%{StringUtils.ChkSQL(searchKey)}%') ");

            return builder.ToString();
        }

        #endregion

        #endregion

        #region 编辑

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.AddField)]
        public async Task<string> Add(IFormCollection form)
        {
            return await Edit(false);
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.ModifyField)]
        public async Task<string> Modify(IFormCollection form)
        {
            return await Edit(true);
        }

        private async Task<string> Edit(bool isModify)
        {
            var userGroup = await userGroupRepository.FindAsync(WebUtils.GetFormVal<int>("_groupid"));

            var entity = new UserFieldInfo();
            if (isModify)
                entity = await userFieldRepository.FindAsync(OpID);

            entity.UserGroupID = userGroup.AutoID;
            entity.FieldName = WebUtils.GetFormString("TextBox2");
            entity.FieldAlias = WebUtils.GetFormString("TextBox3");
            entity.Tip = string.Empty;
            entity.FieldType = WebUtils.GetFormString("DropDownList5");
            entity.DataLength = (short)WebUtils.GetFormVal<int>("ExtTextBox5", 50);
            entity.DefaultValue = WebUtils.GetFormString("TextBox6");

            //字段配置
            FieldSetting set = new FieldSetting();
            set.ControlWidth = WebUtils.GetFormVal<int>("ExtTextBox1", 100);
            set.ControlHeight = WebUtils.GetFormVal<int>("ExtTextBox2", 30);
            set.TextMode = WebUtils.GetFormString("ExtRadioButtonList3", "Text");
            set.IsDateType = entity.FieldType.Equals((int)FieldType.DateTime);
            set.DateFormat = WebUtils.GetFormString("ExtTextBox4", "yyyy-MM-dd");

            switch (EnumUtils.StringToEnum<FieldType>(entity.FieldType))
            {
                case FieldType.MultipleHtml:
                    entity.DataType = "ntext";
                    break;
                case FieldType.DateTime:
                    entity.DataType = "datetime";
                    break;
                default:
                    entity.DataType = "nvarchar";
                    break;
            }

            set.DataFrom = WebUtils.GetFormString("ExtDropDownList6");
            switch (set.DataFrom)
            {
                case "Text":
                    set.DataSource = WebUtils.GetFormString("ExtTextBox7");
                    break;
                case "DataDictionary":
                    set.DataSource = WebUtils.GetFormString("ExtTextBox8");
                    break;
                case "SQLQuery":
                    set.DataSource = WebUtils.GetFormString("ExtTextBox9");
                    break;
            }

            entity.Setting = set.ToJson();
            entity.IsUsing = WebUtils.GetFormString("CheckBox7") == "on";
            entity.EnableNull = WebUtils.GetFormString("CheckBox9") == "on";

            if (string.IsNullOrEmpty(entity.FieldName) || string.IsNullOrEmpty(entity.FieldAlias))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.Sort = 999;
                entity.AutoTimeStamp = System.DateTime.Now;
                entity.IsSystem = false; //人工添加都是非系统的

                var result = await userFieldRepository.AddField(userGroup, entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("添加会员组字段[" + entity.FieldName + "]成功");

                return result.ToOperateResultJson();
            }
            if (isModify)
            {
                var result = await userFieldRepository.UpdateField(userGroup, entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("修改会员组字段[" + entity.FieldName + "]成功");

                return result.ToOperateResultJson();
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE,OperationType.ViewField)]
        public async Task<IActionResult> Edit()
        {
            string showGroup = "group1"; //不同类型组件显示的不同表单组
            string dataSource = "Text"; //单选，复选，下拉列表等有item的控件数据来源
            string dataJson = "{}";

            ViewBag.GroupID = WebUtils.GetQueryVal<int>("GroupID");
            ViewBag.UserGroup = await userGroupRepository.FindAsync(ViewBag.GroupID);
            var field = await userFieldRepository.FindAsync(OpID);

            if (field != null)
            {
                switch (EnumUtils.StringToEnum<FieldType>(field.FieldType))
                {
                    case FieldType.SingleText:
                        showGroup = "group1"; //单文本
                        break;
                    case FieldType.MultipleText:
                        showGroup = "group2"; //多文本
                        break;
                    case FieldType.RadioButton:
                    case FieldType.CheckBox:
                    case FieldType.DropDownList:
                        showGroup = "group3"; //多控件组
                        break;
                    case FieldType.File:
                    case FieldType.Picture:
                        showGroup = "group4"; //单图单文本
                        break;
                    case FieldType.MultiPicture:
                    case FieldType.MultiFile:
                        showGroup = "group5"; //多图多文本
                        break;
                    case FieldType.DateTime:
                        showGroup = "group6"; //日期控件
                        break;
                    case FieldType.MultipleHtml:
                        showGroup = "group7"; //在线编辑器
                        break;
                }

                dataJson = field.ToJson().TrimStart('[').TrimEnd(']');
            }

            string groupJson = (await userGroupRepository.GetAllAsync()).ToJson(); //所有会员组
            string fieldTypeJson = EnumUtils.TransStrDict(typeof(FieldType)).ToJson(); //组件类型
            string textModeJson = EnumUtils.TransStrDict(typeof(TextMode)).ToJson();

            ViewBag.ShowGroup = showGroup;
            ViewBag.DataSource = dataSource;
            ViewBag.fileTypeStrJson = EnumUtils.TransStrDict(typeof(FieldType)).ToJson();
            ViewBag.InitData = "{\"result\":{\"data\":" + dataJson + ",\"groups\":" + groupJson + ",\"fieldType\":" + fieldTypeJson + ",\"textmode\":" + textModeJson + "}}";

            return View("UserMger/ModifyField.cshtml");
        }

        #endregion

        #endregion
    }
}