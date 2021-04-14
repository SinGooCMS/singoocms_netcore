using AutoMapper;

namespace SinGooCMS.Application.ViewModels
{
    public class LoginViewModel : Profile
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string ValidateCode { get; set; }
    }
}
