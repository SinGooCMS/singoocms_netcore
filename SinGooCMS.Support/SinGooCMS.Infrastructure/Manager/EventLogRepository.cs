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
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;

namespace SinGooCMS.Infrastructure
{
    public class EventLogRepository : RespositoryBase<EventLogInfo>, IEventLogRepository
    {
        public EventLogRepository()
        {
            //
        }

        public async Task<EventLogInfo> GetLatestLoginLog(string userName, UserType userType = UserType.Manager) =>
           await NoTrackQuery()
            .Where(p => p.EventType == (short)EventType.Login && p.UserType == userType.ToString() && p.UserName == userName)
            .OrderByDescending(p => p.AutoID).FirstOrDefaultAsync();

        public async Task<EventLogInfo> GetLatestEventLog(string userName, UserType userType = UserType.Manager) =>
            await NoTrackQuery()
            .Where(p => p.UserType == userType.ToString() && p.UserName == userName)
            .OrderByDescending(p => p.AutoID).FirstOrDefaultAsync();

        public async Task ClearLoginFail(string userName, UserType userType = UserType.User)
        {
            await UpdateAsync("LoginFailCount=0", $"LoginFailCount>=5 and UserType='{userType.ToString()}' and UserName='{StringUtils.ChkSQL(userName)}'");
        }
    }
}