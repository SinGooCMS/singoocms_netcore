using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Weixin
{
    public class WXConfig
    {
        #region 公共属性        

        /// <summary>
        /// 应用ID
        /// </summary>
        public string AppID { get; set; } = string.Empty;
        /// <summary>
        /// 应用密钥
        /// </summary>
        public string AppSecret { get; set; } = string.Empty;
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string URL { get; set; } = string.Empty;
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// 消息加解密密钥
        /// </summary>
        public string EncodingAESKey { get; set; } = string.Empty;
        /// <summary>
        /// 每一条消息上下文过期时间
        /// </summary>
        public int ExpireMinutes { get; set; } = 3;

        #endregion

        #region 加载和保存

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="configPath"></param>
        /// <returns></returns>
        public static async Task<WXConfig> Load(string configPath = "/config/weixin.config")
        {
            string xmlString = await FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath(configPath));
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            return new WXConfig()
            {
                AppID = doc.SelectSingleNode("WxConfig/AppID").InnerText,
                AppSecret = doc.SelectSingleNode("WxConfig/AppSecret").InnerText,
                URL = doc.SelectSingleNode("WxConfig/URL").InnerText,
                Token = doc.SelectSingleNode("WxConfig/Token").InnerText,
                EncodingAESKey = doc.SelectSingleNode("WxConfig/EncodingAESKey").InnerText,
                ExpireMinutes = doc.SelectSingleNode("WxConfig/ExpireMinutes").InnerText.ToInt()
            };
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="xmlConfig"></param>
        /// <param name="configPath"></param>
        /// <returns></returns>
        public static async Task Save(WXConfig xmlConfig, string configPath = "/config/weixin.config")
        {
            string str = string.Format("<WxConfig><AppID>{0}</AppID><AppSecret>{1}</AppSecret><URL>{2}</URL><Token>{3}</Token><EncodingAESKey>{4}</EncodingAESKey><ExpireMinutes>{5}</ExpireMinutes></WxConfig>",
                xmlConfig.AppID, xmlConfig.AppSecret, xmlConfig.URL, xmlConfig.Token, xmlConfig.EncodingAESKey, xmlConfig.ExpireMinutes);
            await FileUtils.WriteFileContentAsync(SinGooBase.GetMapPath(configPath), str);
        }

        #endregion
    }
}