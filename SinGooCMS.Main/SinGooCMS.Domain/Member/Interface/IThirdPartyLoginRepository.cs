//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 11:10:40
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    public interface IThirdPartyLoginRepository : IRepositoryBase<ThirdPartyLoginInfo>
    {
        /// <summary>
        /// 是否已经绑定会员
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <returns></returns>
        Task<bool> ExistsBindUser(string uniqueID);
        /// <summary>
        /// 根据第三方授权后获取绑定会员信息（以此来获取会员信息）
        /// </summary>
        /// <param name="uniqueID"></param>
        /// <returns></returns>
        Task<ThirdPartyLoginInfo> GetByUniqueID(string uniqueID);

        /// <summary>
        /// 会员绑定了哪些第三方登录
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        Task<IEnumerable<ThirdPartyLoginInfo>> GetByUser(int userID);
        /// <summary>
        /// 会员绑定了哪些第三方登录
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<IEnumerable<ThirdPartyLoginInfo>> GetByUser(string userName);
    }
}