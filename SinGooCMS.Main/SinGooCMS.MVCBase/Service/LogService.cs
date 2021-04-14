using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;

namespace SinGooCMS.MVCBase.Services
{
    /// <summary>
    /// 事件日志
    /// </summary>
    public class LogService : ILogService
    {
        private readonly IVisitorRepository visitorRepository;
        private readonly IEventLogRepository eventLogRepository;
        private readonly IManager manager;

        public LogService(
            IVisitorRepository _visitorRepository,
            IEventLogRepository _eventLogRepository,
            IManager _manager
            )
        {
            this.visitorRepository = _visitorRepository;
            this.eventLogRepository = _eventLogRepository;
            this.manager = _manager;
        }

        #region 登录日志

        public async Task AddLoginLog(UserType userType, string userName, bool isLogin = true)
        {
            string msg = string.Format("登录{0}{1}", userType == UserType.Manager ? "管理平台" : "会员平台", isLogin ? "成功" : "失败");
            await AddEvent(userType, userName, msg, EventType.Login, isLogin);
        }

        public async Task ClearLoginFail(string userName, UserType userType = UserType.User) =>
           await eventLogRepository.ClearLoginFail(userName, userType);

        #endregion

        #region 管理事件

        public async Task AddEvent(string managerMsg, EventType eventType = EventType.Manage) =>
            await AddEvent(UserType.Manager, manager.AccountName, managerMsg, eventType);

        public async Task AddEvent(UserType userType, string userName, string msg, EventType eventType, bool? islogined = false)
        {
            var eventLog = new EventLogInfo()
            {
                UserType = userType.ToString(),
                UserName = userName,
                IPAddress = IPUtils.GetIP(),
                IPArea = IPUtils.GetIPAreaStr().Replace("[本机地址 CZ88.NET]", "本机地址").Replace("本机地址 CZ88.NET", "本机地址"),
                EventInfo = msg,
                EventType = (short)eventType,
                LoginFailCount = 0,
                Lang = SinGooBase.CurrLang,
                AutoTimeStamp = DateTime.Now
            };

            if (eventType == EventType.Login && islogined == false)
            {
                //记录一次登录失败的记录，若上次也是登录失败，则登录失败次数+1
                var lastLoginLog = await eventLogRepository.GetLatestLoginLog(userName, userType);
                eventLog.LoginFailCount = lastLoginLog == null ? (short)1 : (short)(lastLoginLog.LoginFailCount + 1);
            }

            await eventLogRepository.AddAsync(eventLog);
        }

        #endregion

        #region 错误日志

        public async Task AddErrLog(string msg, string stackTrace)
        {
            var visitor = STATClient.GetVisitorInfo();
            if (visitor != null)
            {
                visitor.ErrMessage = msg;
                visitor.StackTrace = stackTrace;

                await visitorRepository.AddAsync(visitor);
            }
        }

        #endregion    

        /// <summary>
        /// 记录访客信息
        /// </summary>
        public async Task SaveVisitorInfo()
        {
            var visitor = STATClient.GetVisitorInfo();
            if (visitor != null)
                await visitorRepository.AddAsync(visitor);
        }
    }
}
