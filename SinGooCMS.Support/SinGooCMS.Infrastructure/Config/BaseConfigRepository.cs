//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-04-03 15:48:55
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Infrastructure
{
    public class BaseConfigRepository : RespositoryBase<BaseConfigInfo>, IBaseConfigRepository
    {
        public BaseConfigRepository()
        {
            //
        }

        public async Task<bool> UpdateConfigAsync(BaseConfigInfo config)
        {
            if (await UpdateAsync(config))
            {
                //清除缓存
                cache.Del(CacheKey.CKEY_BASECONFIG);
                cache.Del(CacheKey.CKEY_VER);
                cache.Del(CacheKey.CKEY_CMSNODE);

                return true;
            }

            return false;
        }
    }
}