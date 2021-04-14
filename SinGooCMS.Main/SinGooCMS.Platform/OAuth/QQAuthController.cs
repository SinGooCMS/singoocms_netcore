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
    public class QQAuthController : OAuthPageBase
    {
        public QQAuthController()
        {
            base.config = OAuthConfig.GetOAuthConfig("QQ");
        }

        public IActionResult UserAuthRequest()
        {
            if (config == null)
                return new ContentResult() { Content = "您尚未配置腾讯QQ的API信息！" };
            else
            {
                SessionUtils.SetSession("oauth_state", base.state);
                //string send_url = "https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id=" + config.OAuthAppId + "&state=" + state + "&redirect_uri=" + Server.UrlEncode(config.ReturnUri) + "&scope=get_user_info";
                string send_url = "https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id=" + config.OAuthAppId + "&state=" + SessionUtils.GetSession("oauth_state") + "&redirect_uri=" + HttpUtility.UrlEncode(config.ReturnUri); //不传值 scope 表示默认获取 get_user_info
                Context.Log.LogDebug("发起所有者验证：" + send_url);//写入日志
                return new RedirectResult(send_url);
            }
        }

        public IActionResult AuthServerGrant()
        {
            /*
                返回数据
                PC网站：http://你的域名?code=9A5F************************06AF&state=test
                WAP网站：http://你的域名?code=9A5F************************06AF&state=test
            */

            //取得返回参数
            string quaryState = WebUtils.GetQueryString("state");
            base.Code = WebUtils.GetQueryString("code"); //注意此code会在10分钟内过期。
            var oauth_state = SessionUtils.GetSession("oauth_state");

            if (string.IsNullOrEmpty(oauth_state))
                return new ContentResult() { Content = "state未初始化！" };
            else
            {
                //通过code获取Access Token                
                Dictionary<string, object> dict = GetAccessToken(base.Code);
                Context.Log.LogDebug("Access Token Data：" + dict.ToJson()); //记录获得的数据

                if (dict == null || !dict.ContainsKey("access_token"))
                    return new ContentResult() { Content = "出错了，无法获取Access Token，请检查App Key是否正确！" };
                else
                {
                    base.AccessToken = dict["access_token"].ToString();

                    //通过Access Token来获取用户的OpenID
                    Dictionary<string, object> dict2 = GetOpenID(base.AccessToken);
                    if (dict2 == null)
                        return new ContentResult() { Content = "出错啦，无法获取用户授权Openid！" };
                    else
                    {
                        //储存获取数据用到的信息
                        SessionUtils.SetSession("oauth_name", "qq");
                        SessionUtils.SetSession("oauth_access_token", base.AccessToken);
                        SessionUtils.SetSession("oauth_openid", dict2["openid"].ToString());

                        //第二步：跳转到指定页面
                        return new RedirectResult("/qqauth/GetProtectedRes");
                    }
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

                Dictionary<string, object> jd = GetUserInfo(AccessToken, oauth_openid);
                if (jd == null)
                    return new ContentResult() { Content = "出错啦，无法获取授权用户信息！" };
                else
                {
                    return base.ToLogin("qq", "qq:" + oauth_openid, jd["nickname"].ToString(), jd["gender"].ToString(), jd["figureurl_qq_2"].ToString());
                }
            }
        }

        #region Helper

        /// <summary>
        /// 取得临时的Access Token
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        private Dictionary<string, object> GetAccessToken(string code)
        {
            string send_url = "https://graph.qq.com/oauth2.0/token?grant_type=authorization_code&client_id=" + config.OAuthAppId + "&client_secret=" + config.OAuthAppKey + "&code=" + code + "&redirect_uri=" + HttpUtility.UrlEncode((config.ReturnUri));
            //发送并接受返回值 返回如下字符串：access_token=FE04************************CCE2&expires_in=7776000，有效期单位是 秒
            string result = SinGooCMS.Utility.NetWorkUtils.HttpGet(send_url);
            if (result.Contains("access_token")) //成功 
            {
                string[] parm = result.Split('&');
                string access_token = parm[0].Split('=')[1];    //取得access_token
                string expires_in = parm[1].Split('=')[1];      //Access Token的有效期，单位为秒 有效期默认是3个月 
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("access_token", access_token);
                dic.Add("expires_in", expires_in);
                return dic;
            }

            return null;
        }

        /// <summary>
        /// 取得用户openid 
        /// </summary>
        /// <param name="access_token">临时的Access Token</param>
        /// <returns>Dictionary</returns>
        private Dictionary<string, object> GetOpenID(string access_token)
        {
            /*
             * OpenID是此网站上或应用中唯一对应用户身份的标识，网站或应用可将此ID进行存储，便于用户下次登录时辨识其身份，
             * 或将其与用户在网站上或应用中的原有账号进行绑定。
             * 
             *  PC网站接入时，获取到用户OpenID，返回包如下：
                callback( {"client_id":"YOUR_APPID","openid":"YOUR_OPENID"} ); 

                WAP网站接入时，返回如下字符串：
                client_id=100222222&openid=1704************************878C
             */

            string send_url = "https://graph.qq.com/oauth2.0/me?access_token=" + access_token;
            //发送并接受返回值
            string result = SinGooCMS.Utility.NetWorkUtils.HttpGet(send_url);
            if (result.Contains("openid") && result.Contains("client_id"))
            {
                //取得文字出现
                int str_start = result.IndexOf('(') + 1;
                int str_last = result.LastIndexOf(')') - 1;
                //取得JSON字符串
                result = result.Substring(str_start, (str_last - str_start));
                //反序列化JSON
                return result.JsonToObject<Dictionary<string, object>>();
            }

            return null;
        }

        /// <summary>
        /// 获取登录用户自己的基本资料 API文档地址：http://wiki.open.qq.com/wiki/website/get_user_info
        /// </summary>
        /// <param name="access_token">临时的Access Token</param>
        /// <param name="open_id">用户openid</param>
        /// <returns>Dictionary</returns>
        public Dictionary<string, object> GetUserInfo(string access_token, string open_id)
        {
            string send_url = "https://graph.qq.com/user/get_user_info?access_token=" + access_token + "&oauth_consumer_key=" + config.OAuthAppId + "&openid=" + open_id + "&format=json";
            /*
             返回如下：
             {
                "ret":0,
                "msg":"",
                "nickname":"Peter",
                "figureurl":"http://qzapp.qlogo.cn/qzapp/111111/942FEA70050EEAFBD4DCE2C1FC775E56/30",
                "figureurl_1":"http://qzapp.qlogo.cn/qzapp/111111/942FEA70050EEAFBD4DCE2C1FC775E56/50",
                "figureurl_2":"http://qzapp.qlogo.cn/qzapp/111111/942FEA70050EEAFBD4DCE2C1FC775E56/100",
                "figureurl_qq_1":"http://q.qlogo.cn/qqapp/100312990/DE1931D5330620DBD07FB4A5422917B6/40",
                "figureurl_qq_2":"http://q.qlogo.cn/qqapp/100312990/DE1931D5330620DBD07FB4A5422917B6/100",
                "gender":"男",
                "is_yellow_vip":"1",
                "vip":"1",
                "yellow_vip_level":"7",
                "level":"7",
                "is_yellow_year_vip":"1"
             } 
             */
            string result = SinGooCMS.Utility.NetWorkUtils.HttpGet(send_url);
            if (result.Contains("nickname") && result.Contains("gender"))
                return result.JsonToObject<Dictionary<string, object>>();

            return null;
        }

        #endregion
    }
}
