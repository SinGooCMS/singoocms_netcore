using System;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    /// <summary>
    /// 当前登录的管理员账户，存储在Session中 
    /// </summary>
    public interface IManager : IDependency
    {
        /// <summary>
        /// 当前登录的管理员
        /// </summary>
        AccountInfo LoginAccount { get; }

        /// <summary>
        /// 当前登录的管理员Id
        /// </summary>
        int AccountID { get; }

        /// <summary>
        /// 当前登录的管理员名称
        /// </summary>
        string AccountName { get; }
    }
}
