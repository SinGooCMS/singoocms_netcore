using System;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    /// <summary>
    /// 当前登录的会员，存储在Cookie中
    /// </summary>
    public interface IUser : IDependency
    {
        /// <summary>
        /// 当前登录的会员
        /// </summary>
        Lazy<UserInfo> LoginUser { get; }

        /// <summary>
        /// 当前登录会员的Id
        /// </summary>
        int UserID { get; }

        /// <summary>
        /// 当前登录会员的名称
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// 当前登录的会员昵称
        /// </summary>
        string NickName { get; }

        /// <summary>
        /// 加密的密码串
        /// </summary>
        string EncodedPwd { get; }
    }
}
