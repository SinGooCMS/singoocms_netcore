using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinGooCMS.Cache
{
    public interface ICache
    {
        /// <summary>
        /// 读取缓存数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);
        /// <summary>
        /// 读取所有缓存的key
        /// </summary>
        /// <returns></returns>
        IList<string> GetAllKeys();

        /// <summary>
        /// 加入到缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <param name="priority">优化级</param>
        /// <param name="isSliding">是否弹性过期</param>
        void Insert<T>(string key, T t, int priority = 1, bool isSliding = true);

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        void Del(string key);
        /// <summary>
        /// 删除相似缓存
        /// </summary>
        /// <param name="pattern"></param>
        void DelByPattern(string pattern);
        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <returns></returns>
        int ClearAll();
    }
}
