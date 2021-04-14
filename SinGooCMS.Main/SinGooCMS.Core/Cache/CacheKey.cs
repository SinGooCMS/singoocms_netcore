using System;

namespace SinGooCMS
{
    /// <summary>
    /// 固有缓存键
    /// </summary>
    public static class CacheKey
    {
        /// <summary>
        /// licence
        /// </summary>
        public const string CKEY_LICENCE = "SinGooCMS_CacheForLicence";
        /// <summary>
        /// 网站基本配置 缓存键
        /// </summary>
        public const string CKEY_BASECONFIG = "SinGooCMS_CacheForGetBaseConfig";
        /// <summary>
        /// 模板 缓存键
        /// </summary>
        public const string CKEY_SITETEMPLATE = "SinGooCMS_CacheForSiteTemplate";
        /// <summary>
        /// 栏目 缓存键
        /// </summary>
        public const string CKEY_CMSNODE = "SinGooCMS_CacheForGetCMSNode";
        /// <summary>
        /// 内容模型 缓存键
        /// </summary>
        public const string CKEY_CMSCONTMODEL = "SinGooCMS_CacheForGetContModel";
        /// <summary>
        /// 用户组 缓存键
        /// </summary>
        public const string CKEY_USERGROUP = "SinGooCMS_CacheForUserGroup";
        /// <summary>
        /// 字典 缓存键
        /// </summary>
        public const string CKEY_DICTS = "SinGooCMS_CacheForGetDicts";
        /// <summary>
        /// IP策略信息
        /// </summary>
        public const string CKEY_IPSTRATEGY = "SinGooCMS_CacheForIPStrategy";
        /// <summary>
        /// 管理员菜单 缓存键
        /// </summary>
        public const string CKEY_ACCOUNTMENU = "SinGooCMS_CacheForGetAccountMenuDT";
        /// <summary>
        /// 版本信息 缓存键
        /// </summary>
        public const string CKEY_VER = "SinGooCMS_CacheForVER";
    }
}
