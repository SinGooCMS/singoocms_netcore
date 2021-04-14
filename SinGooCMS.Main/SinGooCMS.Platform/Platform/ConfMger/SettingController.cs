using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using System.Threading.Tasks;
using SinGooCMS.Control;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.ConfMger
{
    public class SettingController : ManagerPageBase
    {
        const string MODULECODE = "CustomSetting";
        private readonly ISettingCategoryRepository settingCategoryRepository;
        private readonly ISettingRepository settingRepository;
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IDictItemRepository dictItemRepository;
        private readonly IMapper mapper;

        public SettingController(
            ISettingCategoryRepository _settingCategoryRepository,
            ISettingRepository _settingRepository,
            IAttachmentRepository _attachmentRepository,
            IDictItemRepository _dictItemRepository,
            IMapper _mapper)
        {
            this.settingCategoryRepository = _settingCategoryRepository;
            this.settingRepository = _settingRepository;
            this.attachmentRepository = _attachmentRepository;
            this.dictItemRepository = _dictItemRepository;
            this.mapper = _mapper;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await settingRepository.FindAsync(OpID);
            if (delEntity != null && await settingRepository.DeleteSettingAsync(delEntity))
            {
                await LogService.AddEvent("删除自定义设置[" + delEntity.KeyName + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort()
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await settingRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("设置自定义设置排序成功");
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
            ViewBag.CateID = WebUtils.GetQueryVal<int>("cateid");
            return View("ConfMger/CustomSetting.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await settingRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<SettingInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.CateID == WebUtils.GetQueryVal<int>("cateid", 0) && (p.KeyName.Contains(searchKey) || p.KeyDesc.Contains(searchKey));
            else
                return (p) => p.CateID == WebUtils.GetQueryVal<int>("cateid", 0);
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
            var entity = new SettingInfo();
            if (isModify)
                entity = await settingRepository.FindAsync(OpID);

            //赋值    
            entity.KeyName = WebUtils.GetFormString("TextBox1");            
            entity.KeyDesc = WebUtils.GetFormString("TextBox3");
            entity.DataLength = (short)WebUtils.GetFormVal<int>("ExtTextBox5", 50);
            entity.ControlType = WebUtils.GetFormString("DropDownList5", "SingleText");
            entity.DefaultValue = WebUtils.GetFormString("TextBox6");

            //字段配置
            FieldSetting set = new FieldSetting();
            set.ControlWidth = WebUtils.GetFormVal<int>("ExtTextBox1", 100);
            set.ControlHeight = WebUtils.GetFormVal<int>("ExtTextBox2", 30);
            set.TextMode = WebUtils.GetFormString("ExtRadioButtonList3", "Text");
            set.IsDateType = entity.ControlType.Equals(FieldType.DateTime.ToString());
            set.DateFormat = WebUtils.GetFormString("ExtTextBox4", "yyyy-MM-dd");
            switch ((FieldType)Enum.Parse(typeof(FieldType), entity.ControlType))
            {
                case FieldType.MultipleText:
                case FieldType.MultipleHtml:
                    entity.DataType = "ntext";
                    break;
                case FieldType.DateTime:
                    entity.DataType = "datetime";
                    break;
                default:
                    {
                        entity.DataType = "nvarchar";
                        entity.DataLength = (short)WebUtils.GetFormVal<int>("ExtTextBox5", 50);
                    }
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
                case "AjaxData":
                    set.DataSource = WebUtils.GetFormString("ExtTextBox11");
                    break;
            }

            entity.Setting = set.ToJson();
            entity.IsUsing = true;//CheckBox7.Checked;
            entity.IsSystem = WebUtils.GetFormString("CheckBox8") == "on";
            entity.Sort = WebUtils.GetFormVal<int>("TextBox9", 999);

            if (string.IsNullOrEmpty(entity.KeyName) || string.IsNullOrEmpty(entity.KeyDesc))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                entity.CateID = WebUtils.GetFormVal<int>("_CateID");
                entity.AutoTimeStamp = DateTime.Now;
                var result = await settingRepository.AddSettingAsync(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("添加自定义配置[" + entity.KeyDesc + "]成功");

                return result.ToOperateResultJson();
            }
            if (isModify)
            {
                var result = await settingRepository.UpdateSettingAsync(entity);
                if (result.ret == ResultType.Success)
                    await LogService.AddEvent("修改自定义配置[" + entity.KeyDesc + "]成功");

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
            string showGroup = "group1"; //不同类型组件显示的不同表单组
            string dataSource = "Text";
            string dataJson = "{}";
            ViewBag.CateID = WebUtils.GetQueryVal<int>("cateid");
            var setting = await settingRepository.FindAsync(OpID);
            if (setting != null)
            {
                ViewBag.CateID = setting.CateID;
                switch ((FieldType)Enum.Parse(typeof(FieldType), setting.ControlType))
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

                dataJson = setting.ToJson().TrimStart('[').TrimEnd(']');
            }

            string cateJson = (await settingCategoryRepository.GetAllAsync()).ToJson(); //所有自定义配置的分类
            string fieldTypeJson = EnumUtils.TransStrDict(typeof(FieldType)).ToJson(); //组件类型
            string textModeJson = EnumUtils.TransStrDict(typeof(TextMode)).ToJson();

            ViewBag.ShowGroup = showGroup;
            ViewBag.DataSource = dataSource;
            ViewBag.InitData = "{\"result\":{\"data\":" + dataJson + ",\"cate\":" + cateJson + ",\"fieldType\":" + fieldTypeJson + ",\"textmode\":" + textModeJson + "}}";

            return View("ConfMger/ModifyCustomSetting.cshtml");
        }

        #endregion

        #endregion

        #region 详情

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Modify)]
        public async Task<string> Detail(IFormCollection form)
        {
            var settingCate = await settingCategoryRepository.FindAsync(OpID);
            await settingRepository.UpdateSettingsAsync(await GetSettingsFromEdit(settingCate.AutoID));

            await LogService.AddEvent("修改配置分类[" + settingCate.CateDesc + "]成功");
            return OperateResult.successJson;
        }

        private async Task<IEnumerable<SettingInfo>> GetSettingsFromEdit(int cateId)
        {
            var lst = await settingRepository.GetSettingByCateID(cateId);
            foreach (var item in lst)
            {
                if (item.ControlType == FieldType.MultiPicture.ToString() || item.ControlType == FieldType.MultiFile.ToString())
                {
                    //多图多文件不能直接读取值。需要先存储到读取ID串 desc_Attachment file_Attachment
                    var fjDesc = (List<string>)WebUtils.GetFormVals<string>("desc_" + item.KeyName);
                    var fjFilePath = (List<string>)WebUtils.GetFormVals<string>("file_" + item.KeyName);
                    item.KeyValue = fjFilePath != null && fjFilePath.Count > 0
                        ? await attachmentRepository.AddRange(fjFilePath, fjDesc)
                        : string.Empty;
                }
                else
                    item.KeyValue = WebUtils.GetFormString(item.KeyName, string.Empty); //取值
            }

            return lst;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Detail()
        {
            var settingsList = await settingRepository.GetSettingByCateID(OpID);
            var fieldList = this.GetFieldList(settingsList);
            return View("ConfMger/SettingDetail.cshtml", fieldList);
        }
        private IEnumerable<IFieldControl> GetFieldList(IEnumerable<SettingInfo> settingsList)
        {
            var lst = new List<IFieldControl>();
            foreach (var item in settingsList)
            {
                if (item.IsUsing)
                {
                    var control = Htmler.Create(item.ControlType, new object[] { Context, attachmentRepository, dictItemRepository });
                    mapper.Map(item, control);
                    lst.Add(control);
                }
            }
            return lst;
        }

        #endregion

        #endregion
    }
}