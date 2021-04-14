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
    /// 站内消息
    /// </summary>
    [Serializable]
    [Table("sys_Message")]
    public partial class MessageInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public MessageInfo()
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
        /// 接收方，用户名
        /// </summary>
        public System.String Receiver { get; set; } = string.Empty;

        /// <summary>
        /// 消息主体
        /// </summary>
        public System.String MsgBody { get; set; } = string.Empty;

        /// <summary>
        /// 是否已读
        /// </summary>
        public System.Boolean IsRead { get; set; } = false;

        /// <summary>
        /// 阅读时间
        /// </summary>
        public System.DateTime ReadTime { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// 是否已发送
        /// </summary>
        public System.Boolean HasSend { get; set; } = false;

        /// <summary>
        /// 发送时间
        /// </summary>
        public System.DateTime SendTime { get; set; } = new DateTime(1900, 1, 1);

        /// <summary>
        /// 语种
        /// </summary>
        public System.String Lang { get; set; } = "zh-cn";

        /// <summary>
        /// 接收时间
        /// </summary>
        public System.DateTime? AutoTimeStamp { get; set; } = new DateTime(1900, 1, 1);

        #endregion

    }
}