using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SinGooCMS.Domain.Models;
using SinGooCMS.Cache;
using SinGooCMS.Ado;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Ado.Interface;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Infrastructure
{
    /// <summary>
    /// 缓存信息（统一放这里好管理）
    /// </summary>
    public class CacheStore : ICacheStore
    {
        private static readonly ICache cache = CacheProvider.Instance;
        private static readonly IDbAccess dbAccess = DbProvider.DbAccess;

        #region 基本配置

        public BaseConfigInfo CacheBaseConfig
        {
            get
            {
                var baseConfig = cache.Get<BaseConfigInfo>(CacheKey.CKEY_BASECONFIG);
                if (baseConfig == null)
                {
                    baseConfig = dbAccess.Find<BaseConfigInfo>(1);
                    var allSetting = dbAccess.GetList<SettingInfo>(1000, "IsUsing=1", "Sort asc");
                    var dict = new Dictionary<string, SettingInfo>();
                    foreach (var item in allSetting)
                        dict.Add(item.KeyName, item);

                    baseConfig.CustomSetting = dict; //自定义配置 读取 config["key"]
                    cache.Insert(CacheKey.CKEY_BASECONFIG, baseConfig);
                }

                return baseConfig;
            }

        }

        #endregion

        #region 栏目信息

        public IEnumerable<NodeInfo> CacheNodes
        {
            get
            {
                var _cacheNodes = cache.Get<IEnumerable<NodeInfo>>(CacheKey.CKEY_CMSNODE);
                if (_cacheNodes == null)
                {
                    string sql;
                    switch (ConfigUtils.ProviderName)
                    {
                        case "MySql":
                            sql = @"select *,
                                ifnull((select AutoID from cms_Node where ParentID=a.AutoID order by Sort asc,AutoID desc limit 0,1),0) as FirstChildID,
                                ifnull((select AutoID from cms_Content where NodeID=a.AutoID order by Sort asc,AutoID desc limit 0,1),0) as SingleContId
                                from cms_Node as a
                                order by Depth asc,Sort asc,AutoID asc";
                            break;
                        case "Sqlite":
                            sql = @"select *,
                                ifnull((select AutoID from cms_Node where ParentID = a.AutoID order by Sort asc, AutoID desc limit 1 offset 0),0) as FirstChildID,
                                ifnull((select AutoID from cms_Content where NodeID = a.AutoID order by Sort asc, AutoID desc limit 1 offset 0),0) as SingleContId
                                from cms_Node as a
                                order by Depth asc,Sort asc,AutoID asc";
                            break;
                        case "SqlServer":
                        default:
                            sql = @"select *,
                                isnull((select top 1 AutoID from cms_Node where ParentID = a.AutoID order by Sort asc, AutoID desc),0) as FirstChildID,
                                isnull((select top 1 AutoID from cms_Content where NodeID = a.AutoID order by Sort asc, AutoID desc),0) as SingleContId
                                from cms_Node as a
                                order by Depth asc,Sort asc,AutoID asc";
                            break;
                    }

                    _cacheNodes = dbAccess.GetList<NodeInfo>(sql);
                    if (_cacheNodes != null)
                    {
                        foreach (var item in _cacheNodes)
                        {
                            #region 栏目url

                            string url = string.Empty;
                            var browsetype = EnumUtils.StringToEnum<BrowseType>(CacheBaseConfig.BrowseType);
                            switch (browsetype)
                            {
                                case BrowseType.HtmlRewrite:
                                    url = "/article/" + item.NodeIdentifier + ".html"; //伪静态
                                    break;
                                case BrowseType.MvcDefault:
                                default:
                                    url = "/article/" + item.NodeIdentifier; //MVC原生态路由地址
                                    break;
                            }

                            if (item.CustomLink.Length > 0)
                                url = item.CustomLink; //自定义的链接优先

                            item.NodeUrl = url;

                            #endregion
                        }
                    }

                    cache.Insert(CacheKey.CKEY_CMSNODE, _cacheNodes);
                }

                return _cacheNodes;
            }
        }

        #endregion

        #region 模板信息

        public IEnumerable<SiteTemplateInfo> CacheSiteTmpls
        {
            get
            {
                var siteTmpls = cache.Get<IEnumerable<SiteTemplateInfo>>(CacheKey.CKEY_SITETEMPLATE);
                if (siteTmpls == null)
                {
                    siteTmpls = dbAccess.GetList<SiteTemplateInfo>(1000);
                    cache.Insert(CacheKey.CKEY_SITETEMPLATE, siteTmpls);
                }

                return siteTmpls;
            }
        }

        public SiteTemplateInfo CacheDefaultSiteTmpl =>
            CacheSiteTmpls?.Where(p => p.IsDefault).FirstOrDefault();

        #endregion

        #region 内容模型

        public IEnumerable<ContModelInfo> CacheContModels
        {
            get
            {
                var lstModel = cache.Get<IEnumerable<ContModelInfo>>(CacheKey.CKEY_CMSCONTMODEL);
                if (lstModel == null)
                {
                    lstModel = dbAccess.GetList<ContModelInfo>(1000, "", "Sort asc");
                    cache.Insert(CacheKey.CKEY_CMSCONTMODEL, lstModel);
                }

                return lstModel;
            }
        }

        #endregion

        #region 会员组

        public IEnumerable<UserGroupInfo> CacheUserGroup
        {
            get
            {
                var lstGroup = cache.Get<IEnumerable<UserGroupInfo>>(CacheKey.CKEY_USERGROUP);
                if (lstGroup == null)
                {
                    lstGroup = dbAccess.GetList<UserGroupInfo>(100, "", "Sort asc");
                    cache.Insert(CacheKey.CKEY_USERGROUP, lstGroup);
                }

                return lstGroup;
            }
        }

        #endregion

        #region 字典

        public IEnumerable<DictsInfo> CacheDicts
        {
            get
            {
                var dicts = cache.Get<IEnumerable<DictsInfo>>(CacheKey.CKEY_DICTS);
                if (dicts == null)
                {
                    dicts = dbAccess.GetList<DictsInfo>(1000);
                    if (dicts != null)
                    {
                        dicts.ForEach(p =>
                        {
                            //字典内容
                            p.Items = dbAccess.GetList<DictItemInfo>(1000, $"DictID={p.AutoID}", " Sort asc ");
                        });
                    }

                    cache.Insert(CacheKey.CKEY_DICTS, dicts);
                }

                return dicts;
            }
        }

        #endregion

        #region IP策略信息

        public IEnumerable<IPStrategyInfo> CacheIPStrategies
        {
            get
            {
                var ipstrategies = cache.Get<IEnumerable<IPStrategyInfo>>(CacheKey.CKEY_IPSTRATEGY);
                if (ipstrategies == null)
                {
                    ipstrategies = dbAccess.GetList<IPStrategyInfo>(1000);
                    cache.Insert(CacheKey.CKEY_IPSTRATEGY, ipstrategies);
                }

                return ipstrategies;
            }
        }

        #endregion

        #region 版本信息

        public VerInfo CacheVer
        {
            get
            {
                var ver = cache.Get<VerInfo>(CacheKey.CKEY_VER);
                if (ver == null)
                {
                    ver = dbAccess.Find<VerInfo>(1);
                    cache.Insert(CacheKey.CKEY_VER, ver);
                }

                return ver;
            }
        }

        #endregion
    }
}
