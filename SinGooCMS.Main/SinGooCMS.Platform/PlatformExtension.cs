using System;
using System.Text;
using System.Web;

namespace SinGooCMS.Platform
{
    public static class PlatformExtension
    {
        /// <summary>
        /// 转化为前端Mustache模板的json格式
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string ToMustacheJson(this string json)
        {
            return "{\"result\":" + json.TrimStart('[').TrimEnd(']') + "}";
        }
    }    
}
