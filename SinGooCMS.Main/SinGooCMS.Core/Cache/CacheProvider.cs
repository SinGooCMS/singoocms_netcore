using System;
using System.Reflection;
using SinGooCMS.Utility;

namespace SinGooCMS.Cache
{
    public class CacheProvider
    {
        /// <summary>
        /// 创建一个默认的缓存
        /// </summary>
        /// <returns></returns>
        public static ICache Instance => Create(ConfigUtils.GetAppSetting<string>("CacheType"));

        /// <summary>
        /// 创建一个指定的缓存
        /// </summary>
        /// <param name="smsClassName"></param>
        /// <returns></returns>
        private static ICache Create(string className)
        {
            Assembly tempAssembly = Assembly.LoadFrom(SinGooBase.GetMapPath("SinGooCMS.Core.dll"));
            Type type = tempAssembly.GetType("SinGooCMS.Cache." + className);
            return (ICache)(Activator.CreateInstance(type));
        }
    }
}
