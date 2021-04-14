using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform.OAuth
{
    /*
     * 微信OAuth2.0文档地址：https://open.weixin.qq.com/cgi-bin/showdocument?action=dir_list&t=resource/res_list&verify=1&id=open1419316505&token=&lang=zh_CN
     */

    public class WeixinAuthController : OAuthPageBase
    {
        public WeixinAuthController()
        {
            base.config = OAuthConfig.GetOAuthConfig("Weixin");
        }

        public IActionResult UserAuthRequest()
        {
            /*
             * 若提示“该链接无法访问”，请检查参数是否填写错误，
             * 如redirect_uri的域名与审核时填写的授权域名不一致或scope不为snsapi_login。
             */

            if (config == null)
                return new ContentResult() { Content = "您尚未配置微信的API信息！" };
            else
            {
                SessionUtils.SetSession("oauth_state", base.state);
                string send_url = "https://open.weixin.qq.com/connect/qrconnect?appid=" + config.OAuthAppId + "&redirect_uri=" + HttpUtility.UrlEncode(config.ReturnUri) + "&response_type=code&scope=snsapi_login&state=" + SessionUtils.GetSession("oauth_state") + "#wechat_redirect";
                Context.Log.LogDebug("发起所有者验证：" + send_url);//写入日志
                return new RedirectResult(send_url); //调用后会返回
            }
        }

        public IActionResult AuthServerGrant()
        {
            //取得返回参数
            string quaryState = WebUtils.GetQueryString("state");
            base.Code = WebUtils.GetQueryString("code");

            if (!SessionUtils.ContainKey("oauth_state") || quaryState != SessionUtils.GetSession("oauth_state"))
                return new ContentResult() { Content = "state未初始化！" };
            else
            {
                //获取Access Token
                var dict = GetAccessToken(base.Code); //调用后会返回

                if (dict == null || !dict.ContainsKey("access_token"))
                    return new ContentResult() { Content = "出错了，无法获取Access Token，请检查App Key是否正确！" };
                else
                {
                    //储存获取数据用到的信息
                    SessionUtils.SetSession("oauth_name", "weixin");
                    SessionUtils.SetSession("oauth_access_token", dict["access_token"].ToString());
                    SessionUtils.SetSession("oauth_openid", dict["openid"].ToString());  //授权用户唯一标识

                    Context.Log.LogDebug("Access Token Data：" + dict.ToJson()); //记录获得的数据
                    return new RedirectResult("/weixinauth/GetProtectedRes");
                }
            }
        }

        public IActionResult GetProtectedRes()
        {
            if (!SessionUtils.ContainKey("oauth_name") || !SessionUtils.ContainKey("oauth_access_token") || !SessionUtils.ContainKey("oauth_openid"))
                return new ContentResult() { Content = "出错啦，Access Token已过期或不存在！" };
            else
            {
                string oauth_name = SessionUtils.GetSession("oauth_name");
                base.AccessToken = SessionUtils.GetSession("oauth_access_token");
                string oauth_openid = SessionUtils.GetSession("oauth_openid");

                Context.Log.LogDebug("AccessToken：" + base.AccessToken + " OpenID：" + oauth_openid);

                var jd = GetUserInfo(AccessToken, oauth_openid); //OpenID是唯一的值
                if (jd == null)
                    return new ContentResult() { Content = "出错啦，无法获取授权用户信息！" };
                else
                {
                    return base.ToLogin("weixin", "weixin:" + jd["openid"].ToString(), jd["nickname"].ToString(), (jd["sex"].ToString() == "1" ? "男" : "女"), jd["headimgurl"].ToString());
                }
            }
        }

        #region Helper

        /// <summary>
        /// 通过code获取access_token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private Dictionary<string, object> GetAccessToken(string code)
        {
            string send_url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + config.OAuthAppId + "&secret=" + config.OAuthAppKey + "&code=" + code + "&grant_type=authorization_code";
            /* 正确返回
            { 
                "access_token":"ACCESS_TOKEN", 
                "expires_in":7200, 
                "refresh_token":"REFRESH_TOKEN",
                "openid":"OPENID", 
                "scope":"SCOPE",
                "unionid": "o6_bmasdasdsad6_2sgVt7hMZOPfL"
            }
            */
            string result = NetWorkUtils.HttpGet(send_url);
            if (result.Contains("access_token") && result.Contains("openid")) //access_token有效期为 2个小时
                return result.JsonToObject<Dictionary<string, object>>();

            return null;
        }

        /// <summary>
        /// 刷新access_token有效期
        /// </summary>
        /// <param name="refresh_token"></param>
        /// <returns></returns>
        public Dictionary<string, object> RefreshAccessToken(string refresh_token)
        {
            string send_url = "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid=" + config.OAuthAppId + "&grant_type=refresh_token&refresh_token=" + refresh_token;
            /* 正确返回
             { 
                "access_token":"ACCESS_TOKEN", 
                "expires_in":7200, 
                "refresh_token":"REFRESH_TOKEN", 
                "openid":"OPENID", 
                "scope":"SCOPE" 
             }
             */
            string result = NetWorkUtils.HttpGet(send_url);
            if (result.Contains("access_token") && result.Contains("openid"))
                return result.JsonToObject<Dictionary<string, object>>();

            return null;
        }
        /// <summary>
        /// 获取个人信息
        /// https://open.weixin.qq.com/cgi-bin/showdocument?action=dir_list&t=resource/res_list&verify=1&id=open1419316518&lang=zh_CN
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="open_id"></param>
        /// <returns></returns>
        public static JObject GetUserInfo(string access_token, string open_id)
        {
            /*正确返回的数据             
            { 
                "openid":"OPENID",
                "nickname":"NICKNAME",
                "sex":1,
                "province":"PROVINCE",
                "city":"CITY",
                "country":"COUNTRY",
                "headimgurl": "http://wx.qlogo.cn/mmopen/g3MonUZtNHkdmzicIlibx6iaFqAc56vxLSUfpb6n5WKSYVY0ChQKkiaJSgQ1dZuTOgvLLrhJbERQQ4eMsv84eavHiaiceqxibJxCfHe/0",
                "privilege":[
                    "PRIVILEGE1", 
                    "PRIVILEGE2"
                ],
                "unionid": " o6_bmasdasdsad6_2sgVt7hMZOPfL"
            }             
            */

            string send_url = "https://api.weixin.qq.com/sns/userinfo?access_token=" + access_token + "&openid=" + open_id;

            //发送并接受返回值
            string result = NetWorkUtils.HttpGet(send_url);
            if (result.Contains("openid") && result.Contains("nickname"))
                return JObject.Parse(result);

            return null;
        }
        #endregion
    }
}
