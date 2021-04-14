using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using SinGooCMS.Cache.Redis;
using SinGooCMS.Utility;

namespace SinGooCMS.Cache
{
    public class RedisCache : ICache
    {
        readonly int dbNum = ConfigUtils.GetAppSetting<int>("DBNum");
        readonly RedisHelper redis;

        public RedisCache()
        {
            redis = new RedisHelper(dbNum);
        }

        #region Get

        public T Get<T>(string key)
        {
            if (!string.IsNullOrEmpty(key))
                return redis.StringGet<T>(key);

            return default;
        }

        public IList<string> GetAllKeys()
        {
            var lst = new List<string>();
            var keys = redis.KeyAll("*", dbNum);
            if (keys != null && keys.Count > 0)
            {
                foreach (var item in keys)
                    lst.Add(item.ToString());

                return lst;
            }

            return null;
        }

        #endregion

        #region Insert

        public void Insert<T>(string key, T t, int priority = 1, bool isSliding = true)
        {
            if (!ConfigUtils.GetAppSetting<bool>("EnableCache")) //是否启用缓存
                return;

            int expireSeconds = ConfigUtils.GetAppSetting<int>("ExpireSeconds");
            if (expireSeconds == 0)
                expireSeconds = 3600; // 默认1小时

            redis.StringSet<T>(key, t, new TimeSpan(0, 0, expireSeconds));
        }

        #endregion

        #region Delete

        public void Del(string key) =>
            redis.KeyDelete(key);

        public void DelByPattern(string pattern)
        {
            var keys = redis.KeyAll(pattern, dbNum);
            if (keys != null && keys.Count > 0)
            {
                foreach (var item in keys)
                    redis.KeyDelete(item.ToString());
            }
        }

        public int ClearAll()
        {
            DelByPattern("*");
            return GetAllKeys().Count;
        }

        #endregion        
    }
}
