//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 10:35:44
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinGooCMS.Domain.Models
{
    /// <summary>
    /// 友情链接信息
    /// </summary>
    [Serializable]
    [Table("cms_Links")]
    public partial class LinksInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public LinksInfo() 
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
        /// 链接名称
        /// </summary>
        public System.String LinkName { get; set; } = string.Empty;
        
        /// <summary>
        /// 链接网址
        /// </summary>
        public System.String LinkUrl { get; set; } = string.Empty;
        
        /// <summary>
        /// 链接类型（文本、图片、视频等）
        /// </summary>
        public System.String LinkType { get; set; } = string.Empty;
        
        /// <summary>
        /// 文本链接
        /// </summary>
        public System.String LinkText { get; set; } = string.Empty;
        
        /// <summary>
        /// 图片链接
        /// </summary>
        public System.String LinkImage { get; set; } = string.Empty;
        
        /// <summary>
        /// flash链接
        /// </summary>
        public System.String LinkFlash { get; set; } = string.Empty;
        
        /// <summary>
        /// 是否审核
        /// </summary>
        public System.Boolean IsAudit { get; set; } = false;
        
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
        
    }
}