using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Utility;

namespace SinGooCMS.Platform.OAuth
{
    public class OAuthPageBase : UIPageBase
    {
        //配置信息
        protected OAuthConfig config = null;

        /// <summary>
        /// 用来比对返回的字串是否相等
        /// </summary>
        protected string state = StringUtils.GetGUID();

        /// <summary>
        /// 所有者认证后返回的code
        /// </summary>
        protected string Code { get; set; }

        /// <summary>
        /// 用code去认证服务器取得的令牌
        /// </summary>
        protected string AccessToken { get; set; }

        /// <summary>
        /// 第三方会员登录
        /// </summary>
        /// <param name="source">来源 如 weixin</param>
        /// <param name="uid">唯一标识 如 weixin:525488</param>
        /// <param name="nickName">昵称</param>
        /// <param name="gender">性别</param>
        /// <param name="headerPhoto">头像图片</param>
        protected virtual IActionResult ToLogin(string source, string uid, string nickName, string gender, string headerPhoto)
        {
            //在这里写入一个cookie，在会员登录页面读取，如果无此cookie表示非法操作
            CookieUtils.SetCookie("thirdlogin", uid);

            string param = string.Format("source={0}&uid={1}&nickname={2}&gender={3}&headerphoto={4}&expire={5}",
                source, uid, nickName, gender, headerPhoto, DateTime.Now.AddHours(1).ToString("yyyy-MM-dd HH:mm:ss"));
            param = SinGooBase.DesEncode(param);
            return new RedirectResult("/user/thirdlogin?" + param); //跳转到会员绑定页 这个url 1小时 后过期
        }
    }
}
