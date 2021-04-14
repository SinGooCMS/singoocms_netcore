using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Application.Interface;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform
{
    public class MemberController : MemberPageBase
    {
        private readonly IUserFieldRepository userFieldRepository;
        private readonly IAccountDetailRepository accountDetailRepository;
        private readonly IUserService userService;
        private readonly ISendRecordRepository sendRecordRepository;

        public MemberController(
            IUserFieldRepository _userFieldRepository,
            IAccountDetailRepository _accountDetailRepository,
            IUserService _userService,
            ISendRecordRepository _sendRecordRepository)
        {
            this.userFieldRepository = _userFieldRepository;
            this.accountDetailRepository = _accountDetailRepository;
            this.userService = _userService;
            this.sendRecordRepository = _sendRecordRepository;
        }

        #region 会员中心

        public IActionResult InfoCenter()
        {
            return View("user/会员中心.cshtml");
        }

        #endregion

        #region 个人资料

        [HttpPost]
        public async Task<string> Profile(IFormCollection form)
        {
            //保存个人资料
            var user = await UserRepository.FindAsync(User.UserID);
            user.NickName = WebUtils.GetFormString("NickName");
            user.Gender = WebUtils.GetFormString("Gender");
            user.Birthday = WebUtils.GetFormVal<DateTime>("Birthday");
            string strHeaderPhoto = WebUtils.GetFormString("headerphoto");
            if (!string.IsNullOrEmpty(strHeaderPhoto))
                user.HeaderPhoto = strHeaderPhoto;

            if (await UserRepository.UpdateAsync(user))
                return OperateResult.successJson;
            else
                return OperateResult.FailJson(Context.GetCaption("Profile_UpdateFail"));
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userGroup = await UserGroupRepository.FindAsync(User.LoginUser.Value?.GroupID);
            ViewBag.Fields = await userFieldRepository.GetFieldsWithValue(userGroup.AutoID, User.UserID);

            return View("user/个人资料.cshtml");
        }

        #endregion

        #region 账户明细

        [HttpPost]
        public async Task<string> AccDetail(IFormCollection form)
        {
            string strIds = WebUtils.GetFormString("opid").TrimEnd(',');
            if (!string.IsNullOrEmpty(strIds))
            {
                switch (Context.ParamAction)
                {
                    case "delete": //删除明细
                        {
                            if (await accountDetailRepository.DeleteAsync(strIds))
                                return OperateResult.SuccessJson("OperationSuccess", "操作成功", "/member/accdetail");
                        }
                        break;
                }
            }

            return OperateResult.failJson;
        }

        [HttpGet]
        public async Task<IActionResult> AccDetail()
        {
            var totalCount = await accountDetailRepository.GetCountAsync(p => p.Unit == BalanceType.Amount.ToString() && p.UserID == User.UserID);
            var pager = new Pager(totalCount, 10)
            {
                UrlPattern = "/member/accdetail?page=$page"
            };

            ViewBag.Pager = pager;
            return View("user/账户明细.cshtml");
        }

        #endregion

        #region 积分明细

        [HttpPost]
        public async Task<string> Integral(IFormCollection form)
        {
            string strIds = WebUtils.GetFormString("opid").TrimEnd(',');
            if (!string.IsNullOrEmpty(strIds))
            {
                switch (Context.ParamAction)
                {
                    case "delete": //删除明细
                        {
                            if (await accountDetailRepository.DeleteAsync(strIds))
                                return OperateResult.SuccessJson("OperationSuccess", "操作成功！", "/member/integral");
                        }
                        break;
                }
            }

            return OperateResult.failJson;
        }

        [HttpGet]
        public async Task<IActionResult> Integral()
        {
            var totalCount = await accountDetailRepository.GetCountAsync(p => p.Unit == BalanceType.Integral.ToString() && p.UserID == User.UserID);
            var pager = new Pager(totalCount, 10)
            {
                UrlPattern = "/member/integral?page=$page"
            };

            ViewBag.Pager = pager;
            return View("user/我的积分.cshtml");
        }

        #endregion

        #region 修改密码

        [HttpPost]
        public async Task<string> ChangePwd(IFormCollection form)
        {
            #region 修改密码

            string strCurrPwd = WebUtils.GetFormString("_oldpwd"); //原密码
            string strNewPwd = WebUtils.GetFormString("_newpwd"); //新密码                
            string strNewPwdConfrim = WebUtils.GetFormString("_newpwdconfirm"); //确认新密码

            if (string.IsNullOrEmpty(strNewPwd))
                return OperateResult.FailJson("User_UserPwdLenNeed", "密码长度不少于6位");
            else if (!strNewPwd.Equals(strNewPwdConfrim))
                return OperateResult.FailJson("User_TwoPwdInputedNotEqual", "两次新密码输入不一致");
            else if (User.LoginUser.Value?.Password != UserRepository.GetEncodePwd(strCurrPwd))
                return OperateResult.FailJson("User_OldPwdIncorrect", "原密码不正确");
            else if (await UserRepository.UpdatePassword(User.UserID, UserRepository.GetEncodePwd(strNewPwd)))
            {
                userService.Logout();
                return OperateResult.SuccessJson("OperationSuccess", "密码修改成功,请重新登录", "/user/login");
            }
            else
                return OperateResult.FailJson("OperationFail", "密码修改失败");

            #endregion
        }

        [HttpGet]
        public IActionResult ChangePwd()
        {
            return View("user/修改密码.cshtml");
        }

        #endregion      

        #region 用户协议

        [HttpGet]
        public IActionResult Agreement()
        {
            return View("user/注册协议.cshtml");
        }

        #endregion

        #region 手机/邮箱绑定

        [HttpPost]
        public async Task<string> UserBind()
        {
            var result = OperateResult.fail;
            //类型
            string strType = WebUtils.GetFormString("type"); //bymobile,byemail
            //邮箱账号、手机号码
            string strParamVal = WebUtils.GetFormString("paramval");
            //验证码
            string strValidateCode = WebUtils.GetFormString("vcode"); //通过发送短信/邮件 获得的验证码

            var lastVCode = await sendRecordRepository.GetLatestCheckCode(strParamVal);
            if (lastVCode != null)
                strValidateCode = lastVCode.ValidateCode;

            if (string.Compare(strValidateCode, strValidateCode, true) != 0)
                return OperateResult.FailJson("ValidateCodeIncorrect", "验证码不正确！");

            if (!strParamVal.IsNullOrEmpty())
            {
                switch (strType)
                {
                    case "byemail":
                        {
                            if (await UserRepository.IsExistsEmail(strParamVal, User.UserID))
                                return OperateResult.FailJson("User_EmailExists", "邮箱地址已存在");
                            else if (await UserRepository.UpdateEmail(strParamVal, User.UserID))
                                return OperateResult.successJson;
                        }
                        break;
                    case "bymobile":
                        {
                            if (await UserRepository.IsExistsMobile(strParamVal, User.UserID))
                                return OperateResult.FailJson("User_MobileExists", "手机号码已存在");
                            else if (await UserRepository.UpdateMobile(strParamVal, User.UserID))
                                return OperateResult.successJson;
                        }
                        break;
                }
            }

            return result.ToString();
        }

        #endregion
    }
}
