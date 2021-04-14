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

namespace SinGooCMS.Domain.Models
{
    /// <summary>
    /// 文件夹
    /// </summary>
    [Serializable]
    [Table("sys_Folder")]
    public partial class FolderInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public FolderInfo() 
        {
            //
        }
        
        #region 公共属性
        
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public System.Int32 AutoID { get; set; } = 0;
        
        /// <summary>
        /// 文件夹名称
        /// </summary>
        public System.String FolderName { get; set; } = string.Empty;
        
        /// <summary>
        /// 说明
        /// </summary>
        public System.String Remark { get; set; } = string.Empty;
        
        /// <summary>
        /// 排序号
        /// </summary>
        public System.Int32 Sort { get; set; } = 99999;
        
        /// <summary>
        /// 语种
        /// </summary>
        public System.String Lang { get; set; } = "zh-cn";
        
        /// <summary>
        /// 时间戳
        /// </summary>
        public System.DateTime? AutoTimeStamp { get; set; } = new DateTime(1900, 1, 1);
                
        #endregion

        /// <summary>
        /// 文件数量
        /// </summary>
        [NotMapped]
        public int FileCount { get; set; }
        
    }
}