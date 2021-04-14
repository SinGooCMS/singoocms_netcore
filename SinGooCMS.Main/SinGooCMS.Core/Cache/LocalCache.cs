using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using SinGooCMS.Utility;

namespace SinGooCMS.Cache
{
    public class LocalCache : ICache
    {
        private static IMemoryCache cache;

        static LocalCache()
        {
            cache = new MemoryCache(new MemoryCacheOptions() { });
        }

        #region Get

        public T Get<T>(string key)
        {
            return cache.Get<T>(key);
        }

        public IList<string> GetAllKeys()
        {
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var entries = cache.GetType().GetField("_entries", flags).GetValue(cache);
            var cacheItems = entries as IDictionary;
            var keys = new List<string>();
            if (cacheItems == null) return keys;
            foreach (DictionaryEntry cacheItem in cacheItems)
            {
                keys.Add(cacheItem.Key.ToString());
            }
            return keys;
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

            TimeSpan offset = new TimeSpan(0, 0, expireSeconds);

            var option = new MemoryCacheEntryOptions();
            switch (priority)
            {
                case 3:
                    option.Priority = CacheItemPriority.NeverRemove;
                    break;
                case 2:
                    option.Priority = CacheItemPriority.High;
                    break;
                case 1:
                    option.Priority = CacheItemPriority.Normal;
                    break;
                default:
                    option.Priority = CacheItemPriority.Low;
                    break;
            }

            cache.Set(key, t,
                isSliding
                    ? option.SetSlidingExpiration(offset)
                    : option.SetAbsoluteExpiration(offset));
        }

        #endregion

        #region Delete

        public void Del(string key) =>
            cache.Remove(key);

        public void DelByPattern(string pattern)
        {
            var cacheNum = GetAllKeys();
            Regex regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            List<string> list = new List<string>();
            foreach (var item in cacheNum)
            {
                if (regex.IsMatch(item))
                {
                    list.Add(item);
                }
            }

            foreach (string str in list)
            {
                cache.Remove(str);
            }
        }

        public int ClearAll()
        {
            var cacheNum = GetAllKeys();
            foreach (var item in cacheNum)
                cache.Remove(item);

            return cacheNum.Count;
        }

        #endregion
    }
}
