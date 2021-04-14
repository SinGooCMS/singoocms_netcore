//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 10:35:49
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SinGooCMS.Utility;

namespace SinGooCMS.Domain.Models
{
    /// <summary>
    /// 上传文件信息
    /// </summary>
    [Serializable]
    [Table("sys_FileUpload")]
    public partial class FileUploadInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public FileUploadInfo()
        {
            //
        }

        #region 公共属性

        /// <summary>
        /// 自增主键
        /// </summary>
        [Key]
        public System.Int32 AutoID { get; set; } = 0;

        /// <summary>
        /// 文件夹ID
        /// </summary>
        public System.Int32 FolderID { get; set; } = -1;

        /// <summary>
        /// 文件名 如201704067483208.jpg
        /// </summary>
        public System.String FileName { get; set; } = string.Empty;

        /// <summary>
        /// 文件扩展名 如.jpg
        /// </summary>
        public System.String FileExt { get; set; } = string.Empty;

        /// <summary>
        /// 文件大小 字节
        /// </summary>
        public System.Int32 FileSize { get; set; } = 0;

        /// <summary>
        /// 保存在本地的虚拟路径
        /// </summary>
        public System.String LocalPath { get; set; } = string.Empty;

        /// <summary>
        /// 虚拟路径 如/Upload/2017/4/201704067483208.jpg，或者是oss路径
        /// </summary>
        public System.String VirtualFilePath { get; set; } = string.Empty;

        /// <summary>
        /// 缩略图路径 如/Upload/2017/4/201704067483208_thumb.jpg
        /// </summary>
        public System.String Thumb { get; set; } = string.Empty;

        /// <summary>
        /// 原文件名
        /// </summary>
        public System.String OriginalPath { get; set; } = string.Empty;

        /// <summary>
        /// 上传用户类型
        /// </summary>
        public System.String UserType { get; set; } = string.Empty;

        /// <summary>
        /// 上传用户名
        /// </summary>
        public System.String UserName { get; set; } = string.Empty;

        /// <summary>
        /// 下载次数
        /// </summary>
        public System.Int32 DownloadCount { get; set; } = 0;

        /// <summary>
        /// 自动时间戳
        /// </summary>
        public System.DateTime? AutoTimeStamp { get; set; } = new DateTime(1900, 1, 1);

        #endregion

        #region 自定义属性

        /// <summary>
        /// 不包含扩展名的文件名
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string BaseFileName => System.IO.Path.GetFileNameWithoutExtension(this.FileName);
        /// <summary>
        /// 缩略图文件名
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string ThumbFileName => this.FileName.Replace(this.FileExt, "_thumb" + this.FileExt);
        /// <summary>
        /// 缩略图文件全路径
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string ThumbFileFullPath => FileUtils.Combine(this.LocalPath, this.FileName.Replace(this.FileExt, "_thumb" + this.FileExt));
        /// <summary>
        /// 水印图文件名
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string WatermarkFileName => this.FileName.Replace(this.FileExt, "_watermark" + this.FileExt);
        /// <summary>
        /// 水印图文件全路径，包括目录
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public string WatermarkFileFullPath => FileUtils.Combine(this.LocalPath, this.FileName.Replace(this.FileExt, "_watermark" + this.FileExt));
        /// <summary>
        /// 文件长度字符串 如 12KB
        /// </summary>
        [NotMapped]
        public string FileSizeStr => SinGooCMS.Utility.FileUtils.GetFileSize(this.FileSize);

        #endregion

    }
}