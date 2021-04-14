using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
    public class UserMgerController : ManagerPageBase
    {
        const string MODULECODE = "UserMger";
        private readonly IUserRepository userRepository;
        private readonly IUserGroupRepository userGroupRepository;
        private readonly IUserLevelRepository userLevelRepository;
        private readonly IUserFieldRepository userFieldRepository;
        private readonly IAccountDetailRepository accountDetailRepository;
        private readonly IThirdPartyLoginRepository thirdPartyLoginRepository;
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IDictItemRepository dictItemRepository;
        private readonly IFileUploadRepository fileUploadRepository;
        private readonly IMapper mapper;

        int groupId = WebUtils.GetQueryVal<int>("GroupID");
        UserGroupInfo currGroup = new UserGroupInfo(); //当前会员组
        UserInfo currUser = new UserInfo(); //当前被编辑的会员
        IEnumerable<ThirdPartyLoginInfo> thLogins = new List<ThirdPartyLoginInfo>(); //当前会员的第三方登录信息
        IEnumerable<UserLevelInfo> lstUserLevel = null; //会员等级按积分数顺序
        IEnumerable<DictItemInfo> lstCerts = null; //会员证件类型
        IEnumerable<UserFieldInfo> fieldList = new List<UserFieldInfo>(); //会员扩展字段

        public UserMgerController(
            IUserRepository _userRepository,
            IUserGroupRepository _userGroupRepository,
            IUserLevelRepository _userLevelRepository,
            IUserFieldRepository _userFieldRepository,
            IAccountDetailRepository _accountDetailRepository,
            IThirdPartyLoginRepository _thirdPartyLoginRepository,
            IAttachmentRepository _attachmentRepository,
            IDictItemRepository _dictItemRepository,
            IFileUploadRepository _fileUploadRepository,
            IMapper _mapper
            )
        {
            this.userRepository = _userRepository;
            this.userGroupRepository = _userGroupRepository;
            this.userLevelRepository = _userLevelRepository;
            this.userFieldRepository = _userFieldRepository;
            this.accountDetailRepository = _accountDetailRepository;
            this.thirdPartyLoginRepository = _thirdPartyLoginRepository;
            this.attachmentRepository = _attachmentRepository;
            this.dictItemRepository = _dictItemRepository;
            this.fileUploadRepository = _fileUploadRepository;
            this.mapper = _mapper;

            lstUserLevel = userLevelRepository.NoTrackQuery().OrderBy(p => p.Integral).ToList();
            lstCerts = dictItemRepository.GetCacheItems("CertType");
        }

        #region 会员首页

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("UserMger/User.cshtml");
        }

        [HttpPost]
        [Permission(MODULECODE)]
        public async Task<string> UserGroupTree()
        {
            //会员分组没有层级结构
            //int groupID = WebUtils.GetFormVal<int>("id"); //zTree 读取会员分组
            var lstGroup = await userGroupRepository.GetAllAsync();
            var builder = new StringBuilder();
            if (lstGroup != null && lstGroup.Count() > 0)
            {
                foreach (var item in lstGroup)
                {
                    builder.Append("{id:'" + item.AutoID.ToString() + "',name:'" + item.GroupName + "',isParent:false,iconSkin:'leaf','click':\"AppendVal(" + item.AutoID + ",'" + item.GroupName + "')\"},");
                }
            }

            return "[" + builder.ToString().TrimEnd(',') + "]";
        }

        #endregion

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await userRepository.FindAsync(OpID);
            //删除会员主表，副表，账户明细等相关信息
            if (delEntity != null && await userRepository.DelFullUserInfo(OpID))
            {
                await LogService.AddEvent("删除会员[" + delEntity.UserName + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs))
            {
                userRepository.DeleteAll(strIDs);

                await LogService.AddEvent("批量删除会员[" + strIDs + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Export)]
        public string ExportToExcel()
        {
            string strIDs = WebUtils.GetFormString("chk");
            string condition = strIDs.Length > 0
                ? $" AutoID in ({strIDs})"
                : GetCondition();

            var dtExport = userRepository.GetExportUser(condition);
            if (dtExport != null && dtExport.Rows.Count > 0)
            {
                //保存xls文件
                string strFileName = FileUtils.Combine(SinGooBase.ExportFolder, StringUtils.GetRandomNumber() + ".xlsx");
                EPPlusUtils.Export(dtExport, SinGooBase.GetMapPath(strFileName));

                string url = "/Include/Download?file=" + SinGooBase.DesEncode(strFileName);
                return OperateResult.SuccessJson("OperationSuccess", "操作成功", url);
            }
            else
                return OperateResult.FailJson("NothingDataWasFound", "没有找到任何记录");
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult List()
        {
            ViewBag.GroupID = groupId; //只有点击左侧会员组时才会传递此参数
            return View("UserMger/UserList.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "LastLoginTime DESC,AutoID DESC";
            var pageModel = await userRepository.GetPagerListAsync(GetCondition(), base.sort, pager.PageIndex, pager.PageSize);
            var lstNew = from item in pageModel.PagerData
                         select new
                         {
                             item.AutoID,
                             item.GroupID,
                             item.LevelID,
                             item.UserName,
                             item.Email,
                             item.Mobile,
                             item.HeaderPhoto,
                             item.LoginCount,
                             item.LastLoginTime,
                             item.Status,
                             HeaderPhotoExt = string.IsNullOrEmpty(item.HeaderPhoto)
                                             ? "/Include/Images/userheader.png"
                                             : item.HeaderPhoto,
                             StatusExt = item.Status == (int)UserStatus.Normal
                                        ? "<span class='ok'>已审核</span>"
                                        : "未审核"
                         };

            string dataJson = lstNew.ToJson();
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;

            string pagerJson = new MVCPager(pager).PagerJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":" + pagerJson + "}}";
        }
        private string GetCondition()
        {
            var builder = new StringBuilder(" 1=1 ");

            if (groupId > 0)
                builder.Append(" AND GroupID=" + groupId);

            if (!string.IsNullOrEmpty(searchKey))
                builder.Append($" AND UserName like '%{StringUtils.ChkSQL(searchKey)}%' ");

            return builder.ToString();
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
            var entity = new UserInfo();
            if (isModify)
                entity = await userRepository.FindAsync(OpID);

            entity.UserName = WebUtils.GetFormString("TextBox1");
            entity.Password = WebUtils.GetFormString("TextBox4"); //原始密码
            entity.GroupID = WebUtils.GetFormVal<int>("_groupid");
            entity.LevelID = WebUtils.GetFormVal<int>("DropDownList3");
            entity.Email = WebUtils.GetFormString("TextBox5");
            entity.Mobile = WebUtils.GetFormString("TextBox6");
            entity.Amount = WebUtils.GetFormDecimal("TextBox10");
            entity.Integral = WebUtils.GetFormVal<int>("TextBox11");
            entity.CertType = WebUtils.GetFormString("DropDownList12");
            entity.CertNo = WebUtils.GetFormString("TextBox13");
            entity.Status = WebUtils.GetFormVal<byte>("isaudit");
            entity.FileSpace = WebUtils.GetFormVal<int>("FileSpace") * 1024 * 1024;//MB转成byte            

            var lstField = await userFieldRepository.GetFieldsWithValue(entity.GroupID, entity.AutoID);
            var fieldDicWithValues = new Dictionary<string, UserFieldInfo>();
            foreach (var field in lstField)
            {
                field.Value = System.Web.HttpUtility.HtmlDecode(WebUtils.GetFormString(field.FieldName));
                fieldDicWithValues.Add(field.FieldName, field);
            }

            //编辑状态下修改密码
            if (IsEdit && !entity.Password.IsNullOrEmpty() && entity.Password.Length < 6)
                return OperateResult.FailJson("User_UserPwdLenNeed", "密码长度不少于6位");

            if (!isModify)
            {
                var result = await userRepository.Reg(entity, fieldDicWithValues);
                var operateResult = result.OpResult.ToOperateResult();
                if (result.OpResult.ret == ResultType.Success)
                {
                    operateResult.url = "TabControl:会员列表";
                    await LogService.AddEvent("添加会员[" + entity.UserName + "]成功");
                }                    

                return operateResult.ToString();
            }
            if (isModify)
            {
                if (!entity.Password.IsNullOrEmpty())
                    entity.Password = userRepository.GetEncodePwd(entity.Password); //加密的密码串

                var result = await userRepository.Update(entity, fieldDicWithValues);
                var operateResult = result.ToOperateResult();
                if (result.ret == ResultType.Success)
                {
                    operateResult.url = "TabControl:会员列表";
                    await LogService.AddEvent("更新会员[" + entity.UserName + "]成功");
                }                    

                return operateResult.ToString();
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Edit()
        {
            //必须有会员组
            currGroup = groupId == 0
                                ? userGroupRepository.NoTrackQuery().FirstOrDefault()
                                : userGroupRepository.NoTrackQuery().Where(p => p.AutoID == groupId).FirstOrDefault();
            ViewBag.CurrGroup = currGroup;

            ViewBag.HasUploadTotal = 0m; //用户已经上传文件容量
            ViewBag.UserFileSpace = FileUtils.GetFileSize(Context.SiteConfig.FileCapacity, FileSizeUnit.MB).Replace("MB", ""); //用户可上传文件容量

            if (OpID > 0)
            {
                currUser = await userRepository.FindAsync(OpID);
                thLogins = await thirdPartyLoginRepository.GetByUser(OpID);

                ViewBag.HasUploadTotal = FileUtils.GetFileSize(await fileUploadRepository.GetUserUpTotalSize(currUser.UserName), FileSizeUnit.MB).Replace("MB", "");
                ViewBag.UserFileSpace = FileUtils.GetFileSize(currUser.FileSpace, FileSizeUnit.MB).Replace("MB", "");
            }

            ViewBag.CurrUser = currUser;
            ViewBag.ThLogins = thLogins;

            ViewBag.UserLevel = lstUserLevel;
            ViewBag.Certs = lstCerts;

            fieldList = await userFieldRepository.GetFieldsWithValue(currGroup.AutoID, OpID);
            ViewBag.FieldList = GetFieldList(fieldList);

            ViewBag.InitData = "{\"result\":" + (await userRepository.FindAsync(OpID)).ToJson().TrimStart('[').TrimEnd(']') + "}";
            return View("UserMger/ModifyUser.cshtml");
        }

        private IList<IFieldControl> GetFieldList(IEnumerable<UserFieldInfo> fields)
        {
            var lst = new List<IFieldControl>();
            foreach (var item in fields)
            {
                IFieldControl control = Htmler.Create(item.FieldType, new object[] { Context, attachmentRepository, dictItemRepository });
                mapper.Map(item, control);
                lst.Add(control);
            }
            return lst;
        }

        #endregion

        #endregion

        #region 充值

        [HttpPost]
        [Permission(MODULECODE, OperationType.Recharge)]
        public async Task<string> Recharge(IFormCollection form)
        {
            decimal decValue = WebUtils.GetFormDecimal("TextBox1");
            var user = await userRepository.FindAsync(WebUtils.GetFormVal<int>("_UserID"));

            if (user == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除！");

            switch (WebUtils.GetFormVal<string>("_Type"))
            {
                case "Amount":
                    await accountDetailRepository.AddAmount(user, decValue > 0 ? 1 : 0, (double)(Math.Abs(decValue)), "管理员[" + Manager.AccountName + "]对会员[" + user.UserName + "]账户进行金额充值");
                    break;
                case "Integral":
                    await accountDetailRepository.AddIntegral(user, decValue > 0 ? 1 : 0, (double)(Math.Abs(decValue)), "管理员[" + Manager.AccountName + "]对会员[" + user.UserName + "]账户进行积分充值");
                    break;
            }

            await LogService.AddEvent("管理员[" + Manager.AccountName + "]对会员[" + user.UserName + "]账户进行" + (WebUtils.GetQueryString("Type").Equals("Amount") ? "金额" : "积分") + "充值，充值数值为：" + decValue);
            return OperateResult.SuccessJson("OperationSuccess", "", "reload");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Recharge()
        {
            return View("UserMger/Recharge.cshtml");
        }

        #endregion
    }
}