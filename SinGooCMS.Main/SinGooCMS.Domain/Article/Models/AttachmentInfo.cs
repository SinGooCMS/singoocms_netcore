//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 10:35:42
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinGooCMS.Domain.Models
{
    /// <summary>
    /// 附件
    /// </summary>
    [Serializable]
    [Table("cms_Attachment")]
    public partial class AttachmentInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public AttachmentInfo() 
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
        /// 文件路径
        /// </summary>
        public System.String FilePath { get; set; } = string.Empty;
        
        /// <summary>
        /// 缩略图（图片文件才有）
        /// </summary>
        public System.String ImgThumb { get; set; } = string.Empty;
        
        /// <summary>
        /// 备注说明
        /// </summary>
        public System.String Remark { get; set; } = string.Empty;
        
        /// <summary>
        /// 排序号
        /// </summary>
        public System.Int32 Sort { get; set; } = 99999;
        
        /// <summary>
        /// 时间戳
        /// </summary>
        public System.DateTime? AutoTimeStamp { get; set; } = new DateTime(1900, 1, 1);
                
        #endregion
        
    }
}