using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform
{
    [Serializable]
    public class OAuthConfig
    {
        #region 公共属性
        /// <summary>
        /// 调用的唯一键
        /// </summary>
        public string OAuthKey { get; set; }

        /// <summary>
        /// 第三方登录认证名称
        /// </summary>
        public string OAuthName { get; set; }
        /// <summary>
        /// 展示的图片
        /// </summary>
        public string ShowImg { get; set; }
        /// <summary>
        /// APP ID
        /// </summary>
        public string OAuthAppId { get; set; }
        /// <summary>
        /// APP KEY
        /// </summary>
        public string OAuthAppKey { get; set; }
        /// <summary>
        /// 回传的URL
        /// </summary>
        public string ReturnUri { get; set; }
        /// <summary>
        /// 在线申请的地址
        /// </summary>
        public string ApplyUrl { get; set; }
        /// <summary>
        /// API地址
        /// </summary>
        public string APIUrl { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }
        #endregion

        #region 加载第三方登录配置

        /// <summary>
        /// 加载启用的
        /// </summary>
        /// <returns></returns>
        public static List<OAuthConfig> Load() => LoadAll().Where(p => p.IsEnabled).ToList();

        /// <summary>
        /// 加载
        /// </summary>
        /// <returns></returns>
        public static List<OAuthConfig> LoadAll()
        {
            try
            {
                string xmlString = System.IO.File.ReadAllText(SinGooBase.GetMapPath("/config/thirdlogin.config"));
                return xmlString.XmlToObject<List<OAuthConfig>>();
            }
            catch
            {
                return new List<OAuthConfig>();
            }
        }

        /// <summary>
        /// 获取第三方登录配置
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static OAuthConfig GetOAuthConfig(string key)
        {
            return LoadAll().Where(p => string.Compare(p.OAuthKey, key, true) == 0).FirstOrDefault(); //不区分大小写
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="config"></param>
        public static void Save(List<OAuthConfig> lstConfig)
        {
            System.IO.File.WriteAllText(SinGooBase.GetMapPath("/config/thirdlogin.config"), lstConfig.ToXml());
        }

        #endregion
    }
}
