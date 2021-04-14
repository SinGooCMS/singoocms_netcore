using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Application;
using SinGooCMS.Application.ViewModels;
using SinGooCMS.Application.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform
{
    public class UserController : UIPageBase
    {
        private readonly IUserRepository userRepository;
        private readonly IUserGroupRepository userGroupRepository;
        private readonly IUserLevelRepository userLevelRepository;
        private readonly IUserFieldRepository userFieldRepository;
        private readonly IAccountDetailRepository accountDetailRepository;
        private readonly IMessageService messageService;
        private readonly ISendRecordRepository sendRecordRepository;
        private readonly IUserService userService;
        private readonly IThirdPartyLoginRepository thirdPartyLoginRepository;

        public UserController(
                IUserRepository _userRepository,
                IUserGroupRepository _userGroupRepository,
                IUserLevelRepository _userLevelRepository,
                IUserFieldRepository _userFieldRepository,
                IAccountDetailRepository _accountDetailRepository,
                IMessageService _messageService,
                ISendRecordRepository _sendRecordRepository,
                IUserService _userService,
                IThirdPartyLoginRepository _thirdPartyLoginRepository
            )
        {
            this.userRepository = _userRepository;
            this.userGroupRepository = _userGroupRepository;
            this.userLevelRepository = _userLevelRepository;
            this.userFieldRepository = _userFieldRepository;
            this.accountDetailRepository = _accountDetailRepository;
            this.messageService = _messageService;
            this.sendRecordRepository = _sendRecordRepository;
            this.userService = _userService;
            this.thirdPartyLoginRepository = _thirdPartyLoginRepository;
        }

        #region 注册

        [HttpPost]
        public async Task<string> Register(IFormCollection form)
        {
            var result = OperateResult.fail;

            //注册类型
            var regType = EnumUtils.StringToEnum<RegType>(WebUtils.GetFormString("_regtype", "Normal"));
            //个人会员 or 企业会员
            var uGroup = userGroupRepository.GetCacheGroup(WebUtils.GetFormString("_usergroupname", "个人会员")) ?? userGroupRepository.GetCacheDefGroup();
            //会员等级
            var uLevel = await userLevelRepository.GetInitLevel(); //获取积分最小的项，即初始等级

            var viewModel = new RegisterViewModel()
            {
                RegType = regType,
                UserName = WebUtils.GetFormString("_regname"),
                Password = WebUtils.GetFormString("_regpwd"),
                GroupID = uGroup.AutoID,
                LevelID = uLevel.AutoID,
                Email = regType == RegType.ByEmail ? WebUtils.GetFormString("_regname") : WebUtils.GetFormString("_regemail"),
                Mobile = regType == RegType.ByMobile ? WebUtils.GetFormString("_regname") : WebUtils.GetFormString("_regmobile"),
                NickName = WebUtils.GetFormString("_nickname"),
                Status = (int)UserStatus.Normal, //默认为审核状态
                AutoTimeStamp = DateTime.Now
            };

            //服务端验证码
            string strValidateCode = string.Empty;
            double codeExpire = 0; //验证码有效期 15分钟内有效
            string receiverMedia = regType == RegType.ByEmail ? viewModel.Email : viewModel.Mobile;
            switch (regType)
            {
                case RegType.ByEmail:
                case RegType.ByMobile:
                    {
                        var emailCheck = await sendRecordRepository.GetLatestCheckCode(receiverMedia);
                        if (emailCheck != null)
                        {
                            strValidateCode = emailCheck.ValidateCode; //邮箱验证时这里的是邮箱的验证码
                            codeExpire = (System.DateTime.Now - emailCheck.AutoTimeStamp).Value.TotalMinutes;
                        }
                    }
                    break;
                case RegType.Normal:
                default:
                    strValidateCode = Context.ValidateCode; //普通验证码
                    break;
            }

            if (Context.SiteConfig.VerifycodeForReg && string.Compare(strValidateCode, WebUtils.GetFormString("_regyzm"), true) != 0) //不区分大小写
                return OperateResult.FailJson("ValidateCodeIncorrect", "验证码不正确！");
            else if (codeExpire != 0 && codeExpire > 15)
                return OperateResult.FailJson("ValidateCodeExpired", "验证码已过期！");
            else if (viewModel.Password != WebUtils.GetFormString("_regpwdagain"))
                return OperateResult.FailJson("User_TwoPwdInputedNotEqual", "两次密码输入不一致");
            else
            {
                var lstField = await userFieldRepository.GetFields(viewModel.GroupID);
                var fieldDicWithValues = new Dictionary<string, UserFieldInfo>();
                foreach (var field in lstField)
                {
                    field.Value = WebUtils.GetFormString(field.FieldName);
                    fieldDicWithValues.Add(field.FieldName, field);
                }

                var regResult = await userService.Register(viewModel, fieldDicWithValues);
                if (regResult.ret == ResultType.Success)
                {
                    #region 立即登录并跳转

                    await userRepository.UserLogin(viewModel.UserName, viewModel.Password); //自动登录
                    string strReturnUrl = HttpUtility.UrlDecode(WebUtils.GetFormString("_regreturnurl"));

                    return strReturnUrl.IsNullOrEmpty()
                        ? OperateResult.SuccessJson("Reg_Success", "注册成功", strReturnUrl)
                        : OperateResult.SuccessJson("Reg_Success", "注册成功", "/include/jump.html?msg" + HttpUtility.UrlEncode(Context.GetCaption("Reg_SuccessWillJumpMemberCenter")) + "&redirecturl=" + HttpUtility.UrlEncode("/member/infocenter"));

                    #endregion
                }
                else
                    return OperateResult.FailJson("Reg_Fail", "非常遗憾，注册失败！");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var uPersonGroup = userGroupRepository.GetCacheGroup("个人会员");
            ViewBag.UserModel = userFieldRepository.GetFields(uPersonGroup.AutoID, true);
            ViewBag.ReturnUrl = WebUtils.GetQueryString("returnurl");
            return View("user/注册.cshtml");
        }

        #endregion

        #region 登录

        [HttpPost]
        public async Task<string> Login(IFormCollection form)
        {
            bool boolIsRemeber = WebUtils.GetFormVal<int>("_loginremeber").Equals(1); //记住会员名称
            var viewModel = new LoginViewModel()
            {
                UserName = WebUtils.GetFormString("_loginname"),
                Password = WebUtils.GetFormString("_loginpwd"),
                ValidateCode = WebUtils.GetFormString("_loginyzm")
            };

            if (Context.SiteConfig.VerifycodeForLogin && string.Compare(Context.ValidateCode, viewModel.ValidateCode, true) != 0) //不区分大小写
                return OperateResult.FailJson("ValidateCodeIncorrect", "验证码不正确");

            var loginResult = await userService.Login(viewModel);
            if (loginResult.ret == ResultType.Success)
            {
                //记住会员名称
                if (boolIsRemeber)
                    CookieUtils.SetCookie("_remeberusername", viewModel.UserName, 3600 * 24 * 365);

                string returnUrl = WebUtils.GetFormString("_loginreturnurl");
                return !returnUrl.IsNullOrEmpty()
                    ? OperateResult.SuccessJson("Login_Success", "登录成功", returnUrl)
                    : OperateResult.SuccessJson("Login_Success", "登录成功", "/member/infocenter");
            }
            else
                return OperateResult.FailJson(loginResult.code, loginResult.msg);
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.ReturnUrl = Context.AbsoluteUrl.IndexOf("?returnurl=") == -1
                ? ""
                : Context.AbsoluteUrl.Substring(Context.AbsoluteUrl.IndexOf("?returnurl=") + "?returnurl=".Length);

            ViewBag.RemeberUserName = CookieUtils.GetCookie("_remeberusername"); //记住会员                
            ViewBag.Thirdlogin = OAuthConfig.Load();

            return View("user/登录.cshtml");
        }

        #endregion

        #region 登出

        [HttpGet]
        public IActionResult LogOut()
        {
            string loginUrl = "/user/login"; //退出登录，默认到登录页
            string toUrl = WebUtils.GetQueryString("tourl"); //指定了定向url           

            userService.Logout();

            return toUrl.IsNullOrEmpty()
                ? Redirect(loginUrl)
                : Redirect(toUrl);
        }

        #endregion        

        #region 第三方登录

        [HttpPost]
        public async Task<string> ThirdLogin(IFormCollection form)
        {
            #region 绑定到本地已有或者新创建的会员并登录

            //源数据
            string sourceFrom = WebUtils.GetFormString("_source", string.Empty);
            string uniqueID = WebUtils.GetFormString("_uniqueid", string.Empty);
            string gender = WebUtils.GetFormString("_gender", string.Empty);
            string nickName = WebUtils.GetFormString("_tlnickname", string.Empty);
            string headerPhoto = WebUtils.GetFormString("_headerphoto", string.Empty);

            //用户填写的用户信息，用于绑定已有的会员或者创建新会员
            string userName = WebUtils.GetFormString("_uname", string.Empty);
            string userPwd = WebUtils.GetFormString("_upwd", string.Empty);

            if (string.IsNullOrEmpty(uniqueID))
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");
            else if (!userRepository.IsValidUserName(userName))
                return OperateResult.FailJson("User_UserNameInvalid", "无效的用户名称");
            else if (userPwd.Length < 6)
                return OperateResult.FailJson("User_UserPwdLenNeed", "密码长度不少于6位");
            else
            {
                var existsUser = await userRepository.GetUserByName(userName);
                if (existsUser != null)
                {
                    #region 绑定已有会员

                    if (existsUser.Password == userRepository.GetEncodePwd(userPwd))
                        return BindLocalUserAndLogin(sourceFrom, uniqueID, existsUser).ToString();
                    else
                        return OperateResult.FailJson("Login_Fail", "登录失败，用户名称或者密码错误");

                    #endregion
                }
                else
                {
                    #region 会员不存在，重新注册一个新会员并绑定

                    //创建一个新的会员 
                    var uGroup = userGroupRepository.GetCacheGroup("个人会员");
                    var uLevel = await userLevelRepository.GetInitLevel();
                    var user = new UserInfo()
                    {
                        UserName = userName,
                        Password = userPwd, //前台已经加密了，所以这里不要加密
                        GroupID = uGroup.AutoID,
                        LevelID = uLevel.AutoID,
                        Email = string.Empty,
                        Mobile = string.Empty,
                        NickName = nickName,
                        Gender = gender,
                        HeaderPhoto = headerPhoto,
                        Status = (int)UserStatus.Normal, //默认为审核状态
                        AutoTimeStamp = DateTime.Now
                    };

                    Dictionary<string, UserFieldInfo> temp = new Dictionary<string, UserFieldInfo>
                    {
                        { "NickName", new UserFieldInfo() { FieldName = "NickName", Value = nickName } },
                        { "HeaderPhoto", new UserFieldInfo() { FieldName = "HeaderPhoto", Value = headerPhoto } }
                    };

                    var regResult = await userRepository.Reg(user, temp);
                    if (regResult.OpResult.ret == ResultType.Success)
                    {
                        user.AutoID = regResult.UserId;
                        return BindLocalUserAndLogin(sourceFrom, uniqueID, user).ToString();
                    }
                    else
                        return OperateResult.failJson;

                    #endregion
                }
            }

            #endregion
        }

        [HttpGet]
        public async Task<IActionResult> ThirdLogin()
        {
            /*
             * 用户使用第三方登录授权后，返回用户参数
             * /user/thirdlogin?source={0}&uid={1}&nickname={2}&gender={3}&headerphoto={4}&expire={5}
             * source 来源，如qq,weixin,taobao,sina,alipayexp等
             * uid 是第三方会员的唯一标识，一般由 来源:openid 组成，如taobao:3232973271 、 weixin:oIBb3vim3ErcW97i918DicW06YRg 、 qq:B7112B5CE9F8706466B09CF50F88D95A
             * nickname 昵称 headerphoto 头像 expire 有效时间1小时
             * 
             * 为防止恶意注册，在传参之前把uid写入cookie => CookieUtils.SetCookie("thirdlogin", uid);
             * 以上参数先加密再传输，使传输过程中不被泄露。获取参数先解密再读取
             */

            string thirdLogin = CookieUtils.GetCookie("thirdlogin");
            if (string.IsNullOrEmpty(thirdLogin))
            {
                return new MVCBase.JumpUrlResult(SinGooBase.GetMapPath("OperationUnauthorized"), "/");
            }
            else
            {
                #region 第三方授权后，使用已经绑定的本地会员登录

                #region 读取参数
                //传递的参数被加密，所以要先解密
                string source = string.Empty;
                string uniqueID = string.Empty;
                string gender = string.Empty;
                string headerPhoto = string.Empty;
                string nickName = string.Empty;
                string query = string.Empty;

                try
                {
                    query = Request.QueryString.ToUriComponent();
                    query = SinGooBase.DesDecode(query.TrimStart('?'));
                }
                catch
                {
                    query = string.Empty;
                }

                if (!string.IsNullOrEmpty(query))
                {
                    var dictParam = query.ToUrlDictionary();
                    source = dictParam["source"];
                    uniqueID = dictParam["uid"];
                    gender = dictParam["gender"];
                    headerPhoto = dictParam["headerphoto"];
                    nickName = dictParam["nickname"];
                }
                #endregion

                var tp = await thirdPartyLoginRepository.GetByUniqueID(uniqueID);
                if (tp != null)
                {
                    #region 已有此三方登录的记录，则登录已有会员

                    UserInfo user = await userRepository.GetUserByName(tp.BindUserName);
                    if (user != null)
                    {
                        //登录已经绑定的会员
                        if ((await userRepository.UserLogin(user.UserName, user.Password)).OpResult.ret == ResultType.Success)
                            return Redirect("/member/infocenter");  //返回到会员中心
                        else
                            return Redirect("/include/jump.cshtml?msg=" + HttpUtility.UrlEncode("登录失败，请联系管理员！") + "&redirecturl=/");
                    }
                    else
                    {
                        //绑定的会员被删除了，那么就删除现在的绑定信息，重新绑定
                        await thirdPartyLoginRepository.DeleteAsync(tp.AutoID);
                        Response.Redirect(Context.AbsoluteUrl);
                    }

                    #endregion
                }
                else
                {
                    //没有绑定过会员，需要绑定
                    ViewBag.Source = source;
                    ViewBag.UniqueID = uniqueID;
                    ViewBag.Gender = gender;
                    ViewBag.Nickname = nickName;
                    ViewBag.Headerphoto = headerPhoto;

                    return View("user/第三方会员绑定.cshtml");
                }
                #endregion
            }

            return null;
        }

        #region Helper

        /// <summary>
        /// 第三方账号绑定到本地会员
        /// </summary>
        /// <param name="sourceFrom"></param>
        /// <param name="uniqueID"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<OperateResult> BindLocalUserAndLogin(string sourceFrom, string uniqueID, UserInfo user)
        {
            //绑定这个会员到第三方接口
            ThirdPartyLoginInfo info = new ThirdPartyLoginInfo()
            {
                LoginFrom = sourceFrom,
                UniqueCert = uniqueID, //第三方账号唯一标识
                BindUserID = user.AutoID,
                BindUserName = user.UserName,
                AccessToken = string.Empty,
                RefreshToken = string.Empty,
                LoginTime = DateTime.Now
            };

            if (await thirdPartyLoginRepository.AddAsync(info) > 0)
            {
                if ((await userRepository.UserLogin(user.UserName, user.Password)).OpResult.ret == ResultType.Success)
                    return OperateResult.Success("绑定并登录成功", "", "/member/infocenter");
                else
                    return OperateResult.Fail("会员登录失败");
            }

            return OperateResult.Fail("会员绑定失败");
        }

        #endregion

        #endregion

        #region 找回密码

        #region 第一步，确认会员是否存在

        [HttpPost]
        public async Task<string> FindPwd(IFormCollection form)
        {
            UserInfo user = await userRepository.GetUserByName(WebUtils.GetFormString("_uname", string.Empty));
            return user == null
               ? OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除！")
               : OperateResult.SuccessJson("OperationSuccess", "操作成功", "/user/resetpwd?uid=" + SinGooBase.DesEncode(user.AutoID.ToString()));
        }

        [HttpGet]
        public IActionResult FindPwd()
        {
            return View("user/找回密码.cshtml");
        }

        #endregion

        #region 第二步，根据找回密码的方式，重置密码

        [HttpPost]
        public async Task<string> ResetPwd(IFormCollection form)
        {
            var user = await userRepository.GetUserByName(WebUtils.GetFormString("_uname", string.Empty));
            string strFindPwdType = WebUtils.GetFormString("_findpwdtype", string.Empty); //找回密码的类型：手机、邮箱

            //验证码将发送到手机或者邮箱
            string strParamVal = strFindPwdType.Equals("bymobile")
                ? user.Mobile
                : user.Email;

            string strNewPwd = WebUtils.GetFormString("_newpwd", string.Empty); //新密码   
            SendRecordInfo checkModel = await sendRecordRepository.GetLatestCheckCode(strParamVal);
            string checkCode = checkModel?.ValidateCode ?? string.Empty; //邮箱/手机 验证码 有效期是15分钟

            if (string.Compare(WebUtils.GetFormString("_checkcode"), checkCode, true) != 0)
                return OperateResult.FailJson("ValidateCodeIncorrect", "验证码不正确");
            else if ((DateTime.Now - checkModel.AutoTimeStamp).Value.TotalMinutes > 15)
                return OperateResult.FailJson("ValidateCodeExpired", "验证码已过期"); //验证码超时
            else if (strNewPwd.Length < 6)
                return OperateResult.FailJson("User_UserPwdLenNeed", "密码长度不少于6位");
            else
            {
                //重新设置密码 前端已经对密码加密了，所以这里不需要加密
                if (await userRepository.UpdatePassword(user.AutoID, strNewPwd))
                {
                    await LogService.ClearLoginFail(user.UserName); //清除登录失败次数
                    return OperateResult.SuccessJson("OperationSuccess", "操作成功", "/user/resetsuccess");
                }
                else
                    return OperateResult.failJson;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ResetPwd()
        {
            UserInfo user = new UserInfo();
            int userID = new int();
            try
            {
                userID = SinGooBase.DesDecode(WebUtils.GetQueryString("uid", string.Empty)).ToInt();
            }
            catch
            {
                userID = 0;
            }
            user = await userRepository.FindAsync(userID);

            ViewBag.CurrUser = user;
            ViewBag.UserEmail = string.IsNullOrEmpty(user.Email) ? Context.GetCaption("User_EmailNotExists") : user.Email.Mask();
            ViewBag.UserMobile = string.IsNullOrEmpty(user.Mobile) ? Context.GetCaption("User_MobileNotExists") : user.Mobile.Mask();

            return View("user/找回密码方式.cshtml");
        }

        #endregion

        #region 第三步，显示重置密码结果

        public IActionResult ResetSuccess()
        {
            return View("user/重置密码结果.cshtml");
        }

        #endregion

        #endregion
    }
}
