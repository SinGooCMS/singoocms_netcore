using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SinGooCMS.Application;
using SinGooCMS.Utility;

namespace SinGooCMS.Platform.OAuth
{
    /*
     * 注意，这个是快捷登录，与Oauth有区别
     * Oauth2.0 说明文档
     * https://doc.open.alipay.com/docs/doc.htm?spm=a219a.7629140.0.0.XJDqg4&treeId=193&articleId=105656&docType=1
     * 这个快捷登录会比较简单,申请也更方便
     * 申请地址
     * https://b.alipay.com/order/productDetail.htm?productId=2015090914994961
     * 但有个条件是，必须企业用户才能申请（只有企业类型的支付宝账户允许申请该类产品）
     */
    public class AlipayAuthController : OAuthPageBase
    {
        public AlipayAuthController()
        {
            base.config = OAuthConfig.GetOAuthConfig("AlipayExp");
        }

        public IActionResult UserAuthRequest()
        {
            if (config == null)
                return new ContentResult() { Content = "您尚未配置支付宝快捷登录的API信息" };
            else
            {
                //string strLink = string.Format("partner={0}&_input_charset={1}&service={2}&target_service={3}&return_url={4}&exter_invoke_ip={5}",
                //    config.OAuthAppId, "utf-8", "alipay.auth.authorize", "user.auth.quick.login", config.ReturnUri, IPUtils.GetIP());

                string strLink = string.Format("_input_charset={0}&exter_invoke_ip={1}&partner={2}&return_url={3}&service={4}&target_service={5}",
                    "utf-8", IPUtils.GetIP(), base.config.OAuthAppId, config.ReturnUri, "alipay.auth.authorize", "user.auth.quick.login");

                /*
                 * 签名结果
                 * 注意：strLink参数需要排序从小到大 原示例里用到了类型 SortedDictionary
                 */
                string mysign = AlipayMD5.Sign(strLink, base.config.OAuthAppKey, "utf-8");

                strLink += "&sign=" + mysign + "&sign_type=MD5";

                string send_url = "https://mapi.alipay.com/gateway.do?" + strLink;
                Context.Log.LogDebug("发起所有者验证：" + send_url);//写入日志
                return new RedirectResult(send_url);
            }
        }

        public IActionResult AuthServerGrant()
        {
            /*
             * 返回值如：http://www.ue.net.cn/Include/ThirdLogin/alipay/return_url.aspx?
             * is_success=T&notify_id=RqPnCoPT3K9%252Fvwbh3InYzfHVJnsAXx47glUDgzAAXdqKLUBxzxXLJF8jNg%252BY8Dm56Ps3
             * &token=20170516dc13a31c01ba44b09df31ebe53486X86&user_id=2088102597366867
             * &sign=6865fa45c871d482912324404478a81a&sign_type=MD5
             */

            string isSuccess = WebUtils.GetQueryString("is_success");
            string notifyID = WebUtils.GetQueryString("notify_id");
            string token = WebUtils.GetQueryString("token"); //授权令牌
            string userID = WebUtils.GetQueryString("user_id"); //支付宝用户号
            string sign = WebUtils.GetQueryString("sign");
            string signType = WebUtils.GetQueryString("sign_type");

            if (string.Compare(isSuccess, "T") == 0)
            {
                //注意：strLink参数需要排序从小到大 原示例里用到了类型 SortedDictionary
                string strLink = string.Format("is_success={0}&notify_id={1}&token={2}&user_id={3}", isSuccess, notifyID, token, userID);
                bool isSign = AlipayMD5.Verify(strLink, sign, config.OAuthAppKey, "utf-8");

                string responseTxt = "false";
                if (notifyID != null && notifyID != "")
                {
                    string veryfy_url = string.Format("https://mapi.alipay.com/gateway.do?service=notify_verify&partner={0}&notify_id={1}",
                        base.config.OAuthAppId, notifyID);
                    responseTxt = NetWorkUtils.HttpGet(veryfy_url);
                }

                if (responseTxt == "true" && isSign)//验证成功
                {
                    return base.ToLogin("alipay", "alipay:" + userID, string.Empty, string.Empty, string.Empty);
                }
                else
                    return new ContentResult() { Content = "验证失败" };
            }
            else
                return new ContentResult() { Content = "验证失败" };
        }

        public IActionResult GetProtectedRes()
        {
            throw new NotImplementedException();
        }
    }
}
