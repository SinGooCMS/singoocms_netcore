//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 10:35:48
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinGooCMS.Domain.Models
{
    /// <summary>
    /// 字典项
    /// </summary>
    [Serializable]
    [Table("sys_DictItem")]
    public partial class DictItemInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DictItemInfo() 
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
        /// 字典ID
        /// </summary>
        public System.Int32 DictID { get; set; } = 0;
        
        /// <summary>
        /// key
        /// </summary>
        public System.String KeyName { get; set; } = string.Empty;
        
        /// <summary>
        /// value
        /// </summary>
        public System.String KeyValue { get; set; } = string.Empty;
        
        /// <summary>
        /// 排序号
        /// </summary>
        public System.Int32 Sort { get; set; } = 99999;
        
        /// <summary>
        /// 是否启用
        /// </summary>
        public System.Boolean IsUsing { get; set; } = false;
        
        /// <summary>
        /// 时间戳
        /// </summary>
        public System.DateTime? AutoTimeStamp { get; set; } = new DateTime(1900, 1, 1);
                
        #endregion
        
    }
}