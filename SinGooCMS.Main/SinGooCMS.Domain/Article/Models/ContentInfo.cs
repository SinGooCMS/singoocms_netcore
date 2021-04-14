//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 10:35:43
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinGooCMS.Domain.Models
{
    /// <summary>
    /// 文章内容
    /// </summary>
    [Serializable]
    [Table("cms_Content")]
    public partial class ContentInfo : ContentBaseInfo
    {
        public ContentInfo()
        {
            //
        }

        #region 公共属性

        /// <summary>
        /// 栏目名称
        /// </summary>
        public System.String NodeName { get; set; } = string.Empty;        

        /// <summary>
        /// 栏目扩展
        /// </summary>
        public System.String NodeExts { get; set; } = string.Empty;       

        /// <summary>
        /// 作者
        /// </summary>
        public System.String Author { get; set; } = string.Empty;

        /// <summary>
        /// 编辑人
        /// </summary>
        public System.String Editor { get; set; } = string.Empty;

        /// <summary>
        /// 来源
        /// </summary>
        public System.String Source { get; set; } = string.Empty;

        /// <summary>
        /// 来源地址
        /// </summary>
        public System.String SourceUrl { get; set; } = string.Empty;

        /// <summary>
        /// 内容
        /// </summary>
        public System.String Content { get; set; } = string.Empty;

        /// <summary>
        /// 访问锁密码
        /// </summary>
        public System.String LockPassword { get; set; } = string.Empty;

        /// <summary>
        /// 附件
        /// </summary>
        public System.String Attachment { get; set; } = string.Empty;

        /// <summary>
        /// 标签
        /// </summary>
        public System.String TagKey { get; set; } = string.Empty;

        /// <summary>
        /// 相关内容
        /// </summary>
        public System.String RelateContent { get; set; } = string.Empty;

        /// <summary>
        /// 搜索引擎Key
        /// </summary>
        public System.String SeoKey { get; set; } = string.Empty;

        /// <summary>
        /// 搜索引擎描述
        /// </summary>
        public System.String SeoDescription { get; set; } = string.Empty;

        /// <summary>
        /// 视图模板
        /// </summary>
        public System.String TemplateFile { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public System.Int32 CustomRecommend { get; set; } = 0;

        /// <summary>
        /// 语种
        /// </summary>
        public System.String Lang { get; set; } = "zh-cn";        

        /// <summary>
        /// 录入者
        /// </summary>
        public System.String Inputer { get; set; } = string.Empty;

        #endregion
    }
}