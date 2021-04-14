//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 11:10:39
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    public interface IContModelRepository : IRepositoryBase<ContModelInfo>
    {
        /// <summary>
        /// 创建内容模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result> AddModel(ContModelInfo model);
        /// <summary>
        /// 更新内容模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> UpdateModel(ContModelInfo model);
        /// <summary>
        /// 删除内容模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Result> DeleteModel(ContModelInfo model);        

        /// <summary>
        /// 读取内容模型
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        Task<ContModelInfo> GetModel(int modelID);
        /// <summary>
        /// 读取内容模型
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        Task<ContModelInfo> GetModel(string modelName);
        /// <summary>
        /// 读取内容模型列表
        /// </summary>
        /// <param name="isUsing"></param>
        /// <returns></returns>
        Task<IEnumerable<ContModelInfo>> GetModels(bool? isUsing = null);

        /// <summary>
        /// 读取缓存内容模型
        /// </summary>
        /// <param name="modelID"></param>
        /// <returns></returns>
        ContModelInfo GetCacheModel(int modelID);
        /// <summary>
        /// 读取缓存内容模型
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        ContModelInfo GetCacheModel(string modelName);
    }
}