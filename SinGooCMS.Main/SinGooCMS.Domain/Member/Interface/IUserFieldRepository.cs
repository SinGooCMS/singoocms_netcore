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
    public interface IUserFieldRepository : IRepositoryBase<UserFieldInfo>
    {
        /// <summary>
        /// 增加字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        Task<Result> AddField(UserGroupInfo group, UserFieldInfo field);
        /// <summary>
        /// 更新字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        Task<Result> UpdateField(UserGroupInfo group, UserFieldInfo field);
        /// <summary>
        /// 删除字段
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        Task<Result> DeleteField(UserFieldInfo field);
        /// <summary>
        /// 删除会员组所有字段
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        Task<bool> DeleteByModelID(int groupId);

        /// <summary>
        /// 读取用户字段信息
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        Task<UserFieldInfo> GetField(int groupID, string FieldName);

        /// <summary>
        /// 获取会员组所有字段
        /// </summary>
        /// <param name="groupID">会员组ID</param>
        /// <param name="isUsing">是否使用</param>
        /// <param name="isSystem">是否系统字段</param>
        /// <returns></returns>
        Task<IEnumerable<UserFieldInfo>> GetFields(int groupID, bool? isUsing = null, bool? isSystem = null);

        /// <summary>
        /// 获取会员组所有字段和值
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        Task<IEnumerable<UserFieldInfo>> GetFieldsWithValue(int groupId, int userID);

        /// <summary>
        /// 获取所有非系统的字段
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        Task<IEnumerable<UserFieldInfo>> GetNonSystemFields(int groupId);
        /// <summary>
        /// 设置字段是否可用
        /// </summary>
        /// <param name="fieldIds"></param>
        /// <param name="isUsing"></param>
        /// <returns></returns>
        Task<bool> SetEnabled(string fieldIds, bool isUsing = true);
    }
}