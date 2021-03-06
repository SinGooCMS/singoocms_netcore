//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 11:10:41
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    public interface IFolderRepository : IRepositoryBase<FolderInfo>
    {
        /// <summary>
        /// 删除文件夹后，原属文件的目录ID标记为-1
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> DelFolder(FolderInfo entity);
        /// <summary>
        /// 读取文件夹列表（包括所属文件数量）
        /// </summary>
        /// <param name="topNum"></param>
        /// <returns></returns>
        Task<IEnumerable<FolderInfo>> GetFolderListAsync(int topNum = 200);
        /// <summary>
        /// 文件夹下是否有文件
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        Task<bool> HasFiles(int folder);
    }
}