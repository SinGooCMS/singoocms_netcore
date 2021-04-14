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
     * 微博API接口文档 http://open.weibo.com/wiki/微博API
     */
    public class SinaAuthController : OAuthPageBase
    {
        public SinaAuthController()
        {
            base.config = OAuthConfig.GetOAuthConfig("Weibo");
        }

        public IActionResult UserAuthRequest()
        {
            if (config == null)
                return new ContentResult() { Content = "您尚未配置新浪微博的API信息！" };
            else
            {
                SessionUtils.SetSession("oauth_state", base.state);
                string send_url = "https://api.weibo.com/oauth2/authorize?response_type=code&client_id=" + config.OAuthAppId + "&state=" + SessionUtils.GetSession("oauth_state") + "&redirect_uri=" + HttpUtility.UrlEncode(config.ReturnUri);
                Context.Log.LogDebug("发起所有者验证：" + send_url);//写入日志
                return new RedirectResult(send_url); //调用后会返回
            }
        }

        public IActionResult AuthServerGrant()
        {
            //取得返回参数
            string quaryState = WebUtils.GetQueryString("state");
            base.Code = WebUtils.GetQueryString("code");

            if (!SessionUtils.ContainKey("oauth_state") || !SessionUtils.ContainKey("oauth_state") || quaryState != SessionUtils.GetSession("oauth_state"))
                return new ContentResult() { Content = "state未初始化！" };
            else
            {
                //获取Access Token                
                Dictionary<string, object> dict = GetAccessToken(base.Code); //调用后会返回
                Context.Log.LogDebug("Access Token Data：" + dict.ToJson()); //记录获得的数据
                if (dict == null || !dict.ContainsKey("access_token"))
                    return new ContentResult() { Content = "出错了，无法获取Access Token，请检查App Key是否正确！" };
                else
                {
                    //储存获取数据用到的信息
                    SessionUtils.SetSession("oauth_name", "sina");
                    SessionUtils.SetSession("oauth_access_token", dict["access_token"].ToString());
                    SessionUtils.SetSession("oauth_uid", dict["uid"].ToString());

                    return new RedirectResult("/sinaauth/GetProtectedRes");
                }
            }
        }

        public IActionResult GetProtectedRes()
        {
            if (!SessionUtils.ContainKey("oauth_name") || !SessionUtils.ContainKey("oauth_access_token") || !SessionUtils.ContainKey("oauth_uid"))
                return new ContentResult() { Content = "出错啦，Access Token已过期或不存在！" };
            else
            {
                string oauth_name = SessionUtils.GetSession("oauth_name");
                base.AccessToken = SessionUtils.GetSession("oauth_access_token");
                string oauth_uid = SessionUtils.GetSession("oauth_uid");

                Context.Log.LogDebug("AccessToken：" + base.AccessToken + " UID：" + oauth_uid);

                var jd = GetUserInfo(AccessToken, oauth_uid);
                if (jd == null)
                    return new ContentResult() { Content = "出错啦，无法获取授权用户信息！" };
                else
                {
                    //jd["id"] 是用户UID 唯一的
                    string gender = "保密";
                    if (jd["gender"].ToString() == "m")
                        gender = "男";
                    else if (jd["gender"].ToString() == "f")
                        gender = "女";

                    //去登录
                    return base.ToLogin("sina", "sina:" + jd["id"].ToString(), jd["screen_name"].ToString(), gender, jd["profile_image_url"].ToString());
                }
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
            string send_url = "https://api.weibo.com/oauth2/access_token";
            string param = "grant_type=authorization_code&code=" + code + "&client_id=" + config.OAuthAppId + "&client_secret=" + config.OAuthAppKey + "&redirect_uri=" + HttpUtility.UrlEncode(config.ReturnUri);
            Context.Log.LogDebug("获取Access Token 地址：" + send_url + " 参数：" + param);

            /*
            返回数据
            {
                "access_token": "ACCESS_TOKEN",
                "expires_in": 1234,
                "remind_in":"798114",
                "uid":"12341234"
            }
            */
            string result = NetWorkUtils.HttpPost(send_url, param);
            if (result.Contains("access_token") && result.Contains("uid")) //成功
                return result.JsonToObject<Dictionary<string, object>>();

            return null;
        }

        /// <summary>
        /// 查询用户access_token的授权相关信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        private Dictionary<string, object> GetTokenInfo(string access_token)
        {
            string send_url = "https://api.weibo.com/oauth2/get_token_info";
            string param = "access_token=" + access_token;

            /*
             返回数据
              {
                   "uid": 1073880650,
                   "appkey": 1352222456,
                   "scope": null,
                   "create_at": 1352267591,
                   "expire_in": 157679471
             }
             */
            string result = NetWorkUtils.HttpPost(send_url, param);
            if (result.Contains("uid") && result.Contains("expire_in"))
                return result.JsonToObject<Dictionary<string, object>>();

            return null;
        }

        /// <summary>
        /// 获取登录用户自己的详细信息
        /// </summary>
        /// <param name="access_token">临时的Access Token</param>
        /// <param name="open_id">用户属性，以英文逗号分隔</param>
        /// <returns>JsonData</returns>
        private JObject GetUserInfo(string access_token, string open_id)
        {
            string send_url = "https://api.weibo.com/2/users/show.json?access_token=" + access_token + "&uid=" + open_id;

            /*
            返回数据
            {
                "id": 1404376560, //用户UID 这个应该是唯一的
                "screen_name": "zaku", //用户昵称
                "name": "zaku",
                "province": "11",
                "city": "5",
                "location": "北京 朝阳区",
                "description": "人生五十年，乃如梦如幻；有生斯有死，壮士复何憾。",
                "url": "http://blog.sina.com.cn/zaku",
                "profile_image_url": "http://tp1.sinaimg.cn/1404376560/50/0/1", //用户头像地址（中图），50×50像素
                "domain": "zaku",
                "gender": "m", //性别，m：男、f：女、n：未知
                "followers_count": 1204,
                "friends_count": 447,
                "statuses_count": 2908,
                "favourites_count": 0,
                "created_at": "Fri Aug 28 00:00:00 +0800 2009",
                "following": false,
                "allow_all_act_msg": false,
                "geo_enabled": true,
                "verified": false,
                "status": {
                    "created_at": "Tue May 24 18:04:53 +0800 2011",
                    "id": 11142488790,
                    "text": "我的相机到了。",
                    "source": "<a href="http://weibo.com" rel="nofollow">新浪微博</a>",
                    "favorited": false,
                    "truncated": false,
                    "in_reply_to_status_id": "",
                    "in_reply_to_user_id": "",
                    "in_reply_to_screen_name": "",
                    "geo": null,
                    "mid": "5610221544300749636",
                    "annotations": [],
                    "reposts_count": 5,
                    "comments_count": 8
                },
                "allow_all_comment": true,
                "avatar_large": "http://tp1.sinaimg.cn/1404376560/180/0/1",
                "verified_reason": "",
                "follow_me": false,
                "online_status": 0,
                "bi_followers_count": 215
            }
            */
            string result = NetWorkUtils.HttpGet(send_url);
            if (result.Contains("id") && result.Contains("screen_name"))
                return JObject.Parse(result);

            return null;
        }

        #endregion
    }
}
