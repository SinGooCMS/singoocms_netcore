//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 11:10:38
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    public interface ICommentRepository : IRepositoryBase<CommentInfo>
    {
        /// <summary>
        /// 发布评论
        /// </summary>
        /// <param name="comment">评论内容</param>
        /// <param name="contId">文章内容ID</param>
        /// <param name="user">评论用户</param>
        /// <returns></returns>
        Task<Result> Send(string comment, int contId, UserInfo user);
        /// <summary>
        /// 读取文章所属的评论
        /// </summary>
        /// <param name="contID"></param>
        /// <param name="isAudit"></param>
        /// <returns></returns>
        Task<IEnumerable<CommentInfo>> GetComments(int contID, bool? isAudit = true);
        /// <summary>
        /// 读取会员所属的评论
        /// </summary>
        /// <param name="intUserID"></param>
        /// <param name="isAudit"></param>
        /// <returns></returns>
        Task<IEnumerable<CommentInfo>> GetUserComments(int userID, bool? isAudit = true);

        /// <summary>
        /// 最近的一条评论
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        Task<CommentInfo> GetLatestComment(int userID);
        /// <summary>
        /// 读取评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CommentInfo> GetComment(int id);

        /// <summary>
        /// 显示评论
        /// </summary>
        /// <param name="ids"></param>
        Task ShowComment(string ids);
        /// <summary>
        /// 隐藏评论
        /// </summary>
        /// <param name="ids"></param>
        Task HideComment(string ids);

        /// <summary>
        /// 是否灌水(默认是10秒)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> IsInfuseWater(int userId);

        /// <summary>
        /// 删除多项
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DelMutli(string ids);
        /// <summary>
        /// 删除留言及对此留言的所有回复
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        Task<bool> DelTopic(int subjectId);

        /// <summary>
        /// 分页(包含回复数量、点赞数，点踩数)
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="sort"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<PagerModel<IEnumerable<CommentInfo>>> GetPagerListWithReCount(string condition, string sort, int pageIndex, int pageSize);

        /// <summary>
        /// 分页(包含回复数量、点赞数，点踩数)
        /// </summary>
        /// <param name="contId">文章内容ID</param>
        /// <param name="pageIndex">页号</param>
        /// <param name="pageSize">每页记录数</param>
        /// <returns></returns>
        Task<PagerModel<IEnumerable<CommentInfo>>> GetPagerList(int contId, int pageIndex, int pageSize);

    }
}