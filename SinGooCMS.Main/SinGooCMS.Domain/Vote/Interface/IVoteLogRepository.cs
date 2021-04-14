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
    public interface IVoteLogRepository : IRepositoryBase<VoteLogInfo>
    {
        /// <summary>
        /// 投票
        /// </summary>
        /// <param name="voteInfo">投票信息</param>
        /// <param name="itemId">投票选项标识</param>
        /// <returns></returns>
        Task<Result> Vote(VoteInfo voteInfo, string itemId);

        /// <summary>
        /// 会员是否已经投过票
        /// </summary>
        /// <param name="voteId"></param>
        /// <param name="itemId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> HasUserVote(int voteId, string itemId, int userId);
        /// <summary>
        /// IP是否已经投过票
        /// </summary>
        /// <param name="voteId"></param>
        /// <param name="itemId"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        Task<bool> HasIpVote(int voteId, string itemId, string ip);
        /// <summary>
        /// 删除选项下的所有投票记录
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<bool> DelByItem(string itemId);
    }
}