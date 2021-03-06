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
    /// 内容模型
    /// </summary>
    [Serializable]
    [Table("cms_ContModel")]
    public partial class ContModelInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ContModelInfo() 
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
        /// 模型名称
        /// </summary>
        public System.String ModelName { get; set; } = string.Empty;
        
        /// <summary>
        /// 副表表名
        /// </summary>
        public System.String TableName { get; set; } = string.Empty;
        
        /// <summary>
        /// 描述
        /// </summary>
        public System.String ModelDesc { get; set; } = string.Empty;
        
        /// <summary>
        /// 是否启用
        /// </summary>
        public System.Boolean IsUsing { get; set; } = true;
        
        /// <summary>
        /// 创建人
        /// </summary>
        public System.String Creator { get; set; } = string.Empty;
        
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