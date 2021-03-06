//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 10:35:51
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinGooCMS.Domain.Models
{
    /// <summary>
    /// 来自客户的访问记录（网页浏览记录）
    /// </summary>
    [Serializable]
    [Table("sys_Visitor")]
    public partial class VisitorInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public VisitorInfo() 
        {
            //
        }
        
        #region 公共属性
        
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public System.Int32 AutoID { get; set; } = 0;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String IPAddress { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String OPSystem { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String CustomerLang { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String Navigator { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String Resolution { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String UserAgent { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean IsMobileDevice { get; set; } = false;
        
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean IsSupportActiveX { get; set; } = false;
        
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean IsSupportCookie { get; set; } = false;
        
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean IsSupportJavascript { get; set; } = false;
        
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean IsSupportJavaApplets { get; set; } = false;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String NETVer { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.Boolean IsCrawler { get; set; } = false;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String Engine { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String KeyWord { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String ApproachUrl { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String VPage { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String GETParameter { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String POSTParameter { get; set; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public System.String CookieParameter { get; set; } = string.Empty;
        
        /// <summary>
        /// 错误信息
        /// </summary>
        public System.String ErrMessage { get; set; } = string.Empty;
        
        /// <summary>
        /// 跟踪信息
        /// </summary>
        public System.String StackTrace { get; set; } = string.Empty;
        
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