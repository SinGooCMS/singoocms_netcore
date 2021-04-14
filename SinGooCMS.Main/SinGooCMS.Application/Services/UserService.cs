using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using AutoMapper;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Application.ViewModels;
using SinGooCMS.Application.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Models;
using System.Threading.Tasks;

namespace SinGooCMS.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ICMSContext context;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly ILogService logService;
        private readonly IUser user;

        public UserService(
            ICMSContext _context,
            IMapper _mapper,
            IUserRepository _userRepository,
            ILogService _logService,
            IUser _user
            )
        {
            this.context = _context;
            this.mapper = _mapper;
            this.userRepository = _userRepository;
            this.logService = _logService;
            this.user = _user;
        }

        public async Task<Result> Register(RegisterViewModel regVM, Dictionary<string, UserFieldInfo> dicField)
        {
            var userInfo = mapper.Map<UserInfo>(regVM);
            return (await userRepository.Reg(userInfo, dicField)).OpResult;
        }

        public async Task<Result> Login(LoginViewModel loginVM)
        {
            var result = await userRepository.UserLogin(loginVM.UserName, loginVM.Password);
            await logService.AddLoginLog(UserType.User, loginVM.UserName, result.OpResult.ret == ResultType.Success);
            if (result.OpResult.ret == ResultType.Success)
            {
                int expire = 0;
                switch (context.SiteConfig.CookieTime) //如果为空时效为 "浏览器关闭即失效":
                {
                    case "一周": //系统默认为1周 单位：秒
                        expire = 7 * 24 * 60 * 60;
                        break;
                    case "一年":
                        expire = 365 * 24 * 60 * 60;
                        break;
                }

                CookieUtils.SetCookie("singoocms_uid", result.UserReturn.AutoID.ToString(), expire);
                CookieUtils.SetCookie("singoocms_username", HttpUtility.UrlEncode(result.UserReturn.UserName), expire);
                CookieUtils.SetCookie("singoocms_nickname", HttpUtility.UrlEncode(result.UserReturn.NickName), expire);
                CookieUtils.SetCookie("singoocms_pwd", HttpUtility.UrlEncode(SinGooBase.DesEncode(result.UserReturn.Password)), expire);

                //更新量后登录时间与次数
                result.UserReturn.LoginCount += 1;
                result.UserReturn.LastLoginIP = context.IP;
                result.UserReturn.LastLoginTime = DateTime.Now;

                await userRepository.UpdateAsync(result.UserReturn);
            }

            return result.OpResult;
        }

        public void Logout()
        {
            if (user.LoginUser.Value != null)
            {
                logService.AddEvent(UserType.User, user.UserName, "退出登录", EventType.Login, true);

                CookieUtils.RemoveCookie("singoocms_uid");
                CookieUtils.RemoveCookie("singoocms_username");
                CookieUtils.RemoveCookie("singoocms_nickname");
                CookieUtils.RemoveCookie("singoocms_pwd");
            }
        }
    }
}
