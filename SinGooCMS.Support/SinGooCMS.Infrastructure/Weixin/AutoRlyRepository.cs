//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-04-03 15:49:00
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Infrastructure
{
    public class AutoRlyRepository : RespositoryBase<AutoRlyInfo>, IAutoRlyRepository
    {
        public AutoRlyRepository()
        {
            //
        }

        public async Task<AutoRlyInfo> GetFocusRly() => 
            await NoTrackQuery().Where(p => p.RlyType == "关注回复").FirstOrDefaultAsync();

        public async Task<AutoRlyInfo> GetDefaultRly() => 
            await NoTrackQuery().Where(p => p.RlyType == "默认回复").FirstOrDefaultAsync();

        public async Task<AutoRlyInfo> GetKeyRly(string strReqKey) => 
            await GetByKey("关键字回复", strReqKey);

        public async Task<AutoRlyInfo> GetEventRly(string strReqKey) => 
            await GetByKey("事件回复", strReqKey);

        public async Task<AutoRlyInfo> GetByKey(string keyType, string strMsgKey) =>
           await NoTrackQuery().Where(p => p.RlyType == keyType && p.MsgKey == strMsgKey).FirstOrDefaultAsync();

        public async Task<bool> DelEventKey(string strReqKey)
        {
            var reply = await NoTrackQuery().Where(p => p.RlyType == "事件回复" && p.MsgKey == strReqKey).FirstOrDefaultAsync();
            if (reply != null)
            {
                dbSet.Remove(reply);
                return await dbo.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}