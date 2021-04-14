//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 10:35:45
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinGooCMS.Domain.Models
{
    /// <summary>
    /// 站点模板
    /// </summary>
    [Serializable]
    [Table("cms_SiteTemplate")]
    public partial class SiteTemplateInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SiteTemplateInfo() 
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
        /// 模板名称
        /// </summary>
        public System.String TemplateName { get; set; } = string.Empty;
        
        /// <summary>
        /// 预览图片
        /// </summary>
        public System.String ShowPic { get; set; } = string.Empty;
        
        /// <summary>
        /// 模板文件夹路径
        /// </summary>
        public System.String TemplatePath { get; set; } = string.Empty;
        
        /// <summary>
        /// 主页/首页
        /// </summary>
        public System.String HomePage { get; set; } = string.Empty;
        
        /// <summary>
        /// 描述
        /// </summary>
        public System.String TemplateDesc { get; set; } = string.Empty;
        
        /// <summary>
        /// 是否审核
        /// </summary>
        public System.Boolean IsAudit { get; set; } = false;
        
        /// <summary>
        /// 模板是否存在，即模板文件夹是否存在
        /// </summary>
        public System.Boolean IsExists { get; set; } = false;
        
        /// <summary>
        /// 模板制作人
        /// </summary>
        public System.String Author { get; set; } = string.Empty;
        
        /// <summary>
        /// 版权
        /// </summary>
        public System.String CopyRight { get; set; } = string.Empty;
        
        /// <summary>
        /// 是否默认模板，当前使用的模板
        /// </summary>
        public System.Boolean IsDefault { get; set; } = false;
        
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