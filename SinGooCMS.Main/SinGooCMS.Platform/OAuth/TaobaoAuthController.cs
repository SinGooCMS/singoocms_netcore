using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform.OAuth
{
    /*
     * 淘宝API文档地址：http://open.taobao.com/docs/doc.htm?spm=a219a.7629140.0.0.svR8M3&treeId=1&articleId=102635&docType=1
     */

    public class TaobaoAuthController : OAuthPageBase
    {
        public TaobaoAuthController()
        {
            base.config = OAuthConfig.GetOAuthConfig("Taobao");
        }

        public IActionResult UserAuthRequest()
        {
            if (config == null)
                return new ContentResult() { Content = "您尚未配置淘宝的API信息！" };
            else
            {
                SessionUtils.SetSession("oauth_state", base.state);
                string send_url = "https://oauth.taobao.com/authorize?response_type=code&client_id=" + config.OAuthAppId + "&redirect_uri=" + HttpUtility.UrlEncode(config.ReturnUri) + "&state=" + SessionUtils.GetSession("oauth_state") + "&view=web";
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
                Dictionary<string, object> dict = GetAccessToken(base.Code); //调用后会返回

                if (dict == null || !dict.ContainsKey("access_token"))
                    return new ContentResult() { Content = "出错了，无法获取Access Token，请检查App Key是否正确！" };
                else
                {
                    //储存获取数据用到的信息
                    SessionUtils.SetSession("oauth_name", "taobao");
                    SessionUtils.SetSession("oauth_access_token", dict["access_token"].ToString());

                    if (dict.Keys.Contains("taobao_user_id"))
                        SessionUtils.SetSession("oauth_uid", dict["taobao_user_id"].ToString()); //淘宝帐号对应id 唯一的 taobao_user_id
                    else
                        SessionUtils.SetSession("oauth_uid", dict["taobao_open_uid"].ToString());

                    SessionUtils.SetSession("oauth_taobaonick", dict["taobao_user_nick"].ToString());

                    Context.Log.LogDebug("Access Token Data：" + dict.ToJson()); //记录获得的数据
                    return new RedirectResult("/taobaoauth/GetProtectedRes");
                }
            }
        }

        public IActionResult GetProtectedRes()
        {
            if (!SessionUtils.ContainKey("oauth_name") || !SessionUtils.ContainKey("oauth_access_token") || !SessionUtils.ContainKey("oauth_uid") || !SessionUtils.ContainKey("oauth_taobaonick"))
                return new ContentResult() { Content = "出错啦，Access Token已过期或不存在！" };
            else
            {
                string oauth_name = SessionUtils.GetSession("oauth_name");
                base.AccessToken = SessionUtils.GetSession("oauth_access_token");
                string oauth_uid = SessionUtils.GetSession("oauth_uid");
                string taobaoNick = SessionUtils.GetSession("oauth_taobaonick");

                Context.Log.LogDebug("AccessToken：" + base.AccessToken + " UID：" + oauth_uid);

                //淘宝很奇怪，似乎不需要再次读取会员信息了，既然已经得到了用户授权，那就直接去绑定会员吧
                return base.ToLogin("taobao", "taobao:" + oauth_uid, taobaoNick, "保密", "");
            }
        }

        #region Helper

        /// <summary>
        /// 取得Access Token
        /// </summary>
        /// <param name="code">临时Authorization Code，官方提示10分钟过期</param>
        /// <returns>Dictionary</returns>
        private Dictionary<string, object> GetAccessToken(string code)
        {
            string send_url = "https://oauth.taobao.com/token";
            string param = "grant_type=authorization_code&code=" + code + "&client_id=" + config.OAuthAppId + "&client_secret=" + config.OAuthAppKey + "&redirect_uri=" + HttpUtility.UrlEncode(config.ReturnUri) + "&view=web";
            Context.Log.LogDebug("获取Access Token 地址：" + send_url + " 参数：" + param);

            /*
            返回数据 2017-06-01实际获取的值 以此为准
             {
                "taobao_user_nick": "l01K8XLrVaFXDJ7SEo6IOF%2FnPElKH%2Bn1TQJQBl7bFdvCLQ%3D",
                "re_expires_in": 0,
                "expires_in": 7776000,
                "expire_time": 1504073428083,
                "taobao_open_uid": "AAGXNpDXAEOtWa-5Op3OBjrQ",
                "r1_expires_in": 7776000,
                "w2_valid": 1496299228083,
                "w2_expires_in": 1800,
                "w1_expires_in": 7776000,
                "r1_valid": 1504073428083,
                "r2_valid": 1496556628083,
                "w1_valid": 1504073428083,
                "token_type": "Bearer",
                "r2_expires_in": 259200,
                "refresh_token": "6200013bc6cb4f6ed2ce8ZZc73a24754b66c1c470fc1886259989478",
                "open_uid": "AAGXNpDXAEOtWa-5Op3OBjrQ",
                "refresh_token_valid_time": 1496297428083,
                "access_token": "620171350775537e4fbd5ZZbaf747c386dce9126c7d0182259989478"
            }
             * 其它的（很奇怪，两个不同账号，竟然会有不同的返回结果，字段不一样）
            {
                "taobao_user_nick": "%E8%91%AB%E8%8A%A6%E8%A1%97%E8%BF%94%E5%88%A9",
                "re_expires_in": 2592000,
                "expires_in": 86400,
                "expire_time": 1496389968986,
                "r1_expires_in": 86400,
                "w2_valid": 1496305368986,
                "w2_expires_in": 1800,
                "taobao_user_id": "3257970390",
                "w1_expires_in": 86400,
                "r1_valid": 1496389968986,
                "r2_valid": 1496389968986,
                "w1_valid": 1496389968986,
                "r2_expires_in": 86400,
                "token_type": "Bearer",
                "refresh_token": "6202702a32ZZa34d923f0c1e7debd46d74dcc3f25216a3b3257970390",
                "refresh_token_valid_time": 1498895568986,
                "access_token": "620220292ceg9227738d7933a4d056bf0a6b3ac46fab9e83257970390"
            }
            */
            string result = NetWorkUtils.HttpPost(send_url, param);
            if (result.Contains("access_token")) //成功
                return result.JsonToObject<Dictionary<string, object>>();

            return null;
        }

        /// <summary>
        /// 退出 并不是退出授权，而是清除本地淘宝的cookie
        /// </summary>
        /// <param name="appID"></param>
        private void LogOff(string appID)
        {
            Response.Redirect("https://oauth.taobao.com/logoff?client_id=" + appID + "&view=web");
        }
        #endregion
    }
}
