using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SinGooCMS.Domain.Interface
{
    public interface ILogService : IDependency
    {
        #region 登录事件

        /// <summary>
        /// 添加登录事件
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="userName"></param>
        /// <param name="isLogin"></param>
        Task AddLoginLog(UserType userType, string userName, bool isLogin = true);
        /// <summary>
        /// 清除用户登录失败的记录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        Task ClearLoginFail(string userName, UserType userType = UserType.User);

        #endregion

        #region 管理事件

        /// <summary>
        /// 添加管理员操作事件
        /// </summary>
        /// <param name="managerMsg"></param>
        /// <param name="eventType"></param>
        Task AddEvent(string managerMsg, EventType eventType = EventType.Manage);

        /// <summary>
        /// 添加事件日志
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="userName"></param>
        /// <param name="msg"></param>
        /// <param name="eventType"></param>
        /// <param name="islogined"></param>
        Task AddEvent(UserType userType, string userName, string msg, EventType eventType, bool? islogined = false);

        #endregion

        #region 错误日志

        /// <summary>
        /// 添加错误日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="strStackTrace"></param>
        Task AddErrLog(string msg, string strStackTrace);

        #endregion

        /// <summary>
        /// 记录访客信息
        /// </summary>
        Task SaveVisitorInfo();

    }
}
