using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Application.Interface
{
    /// <summary>
    /// 文件首先上传到本地，如果是图片还会创建缩略图
    /// 启用了水印，那么上传的图片会加上水印
    /// 启用了OSS，文件存储到本地后还会上传到阿里云存储空间
    /// </summary>
    public interface IFileUploadService : IDependency
    {
        /// <summary>
        /// 管理员上传文件
        /// </summary>
        /// <param name="postFile"></param>
        /// <param name="folderId"></param>
        /// <returns></returns>
        Task<Result> UploadByManager(IFormFile postFile, int folderId = -1);
        /// <summary>
        /// 会员上传文件
        /// </summary>
        /// <param name="postFile"></param>
        /// <param name="folderId"></param>
        /// <returns></returns>
        Task<Result> UploadByUser(IFormFile postFile, int folderId = -1);
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="postFile"></param>
        /// <param name="account"></param>
        /// <param name="user"></param>
        /// <param name="folderID"></param>
        /// <returns></returns>
        Task<Result> Upload(IFormFile postFile, AccountInfo account, UserInfo user, int folderID = -1);
    }
}
