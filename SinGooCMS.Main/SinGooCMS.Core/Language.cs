using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS
{
    /// <summary>
    /// 语种设置
    /// </summary>
    public class Language
    {
        public string LangName { get; set; }
        public string LangFullName { get; set; }
        public string Alias { get; set; }

        /// <summary>
        /// 判断是否包含某语种
        /// </summary>
        /// <param name="strLang"></param>
        /// <returns></returns>
        public static bool Contain(string strLang)
        {
            return GlobalLang.Value.Where(p => p.LangName.Equals(strLang)).Any();
        }
        /// <summary>
        /// 网站支持的语种
        /// </summary>
        public static Lazy<List<Language>> GlobalLang => new Lazy<List<Language>>(() =>
        {
            string xmlString = FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath("/config/language.config")).GetAwaiter().GetResult();
            if (xmlString.IsNullOrEmpty())
                throw new Exception("缺少语种设置，请检查文件[/config/language.config]是否存在");

            return xmlString.XmlToObject<List<Language>>();
        });
    }
}
