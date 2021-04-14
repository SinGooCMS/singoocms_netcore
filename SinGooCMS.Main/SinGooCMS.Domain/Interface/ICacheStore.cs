using SinGooCMS.Domain.Models;
using System.Collections.Generic;

namespace SinGooCMS.Domain.Interface
{
    public interface ICacheStore : IDependency
    {
        /// <summary>
        /// 缓存的配置信息
        /// </summary>
        BaseConfigInfo CacheBaseConfig { get; }
        /// <summary>
        /// 缓存的栏目信息
        /// </summary>
        IEnumerable<NodeInfo> CacheNodes { get; }
        /// <summary>
        /// 缓存的模板信息
        /// </summary>
        IEnumerable<SiteTemplateInfo> CacheSiteTmpls { get; }
        /// <summary>
        /// 缓存的当前正在使用的模板信息
        /// </summary>
        SiteTemplateInfo CacheDefaultSiteTmpl { get; }
        /// <summary>
        /// 缓存的模型信息
        /// </summary>
        IEnumerable<ContModelInfo> CacheContModels { get; }
        /// <summary>
        /// 缓存的用户组信息
        /// </summary>
        IEnumerable<UserGroupInfo> CacheUserGroup { get; }
        /// <summary>
        /// 缓存的字典信息
        /// </summary>
        IEnumerable<DictsInfo> CacheDicts { get; }
        /// <summary>
        /// 缓存的IP策略信息
        /// </summary>
        IEnumerable<IPStrategyInfo> CacheIPStrategies { get; }
        /// <summary>
        /// 缓存的软件版本信息
        /// </summary>
        VerInfo CacheVer { get; }
    }
}