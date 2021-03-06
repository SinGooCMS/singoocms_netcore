//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 10:35:47
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinGooCMS.Domain.Models
{
    /// <summary>
    /// 管理员帐户
    /// </summary>
    [Serializable]
    [Table("sys_Account")]
    public partial class AccountInfo
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public AccountInfo() 
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
        /// 账户名
        /// </summary>
        public System.String AccountName { get; set; } = string.Empty;
        
        /// <summary>
        /// 登录密码
        /// </summary>
        public System.String Password { get; set; } = string.Empty;
        
        /// <summary>
        /// 角色 如1,2,3 拥有多个角色用英文状态逗号分隔
        /// </summary>
        public System.String Roles { get; set; } = string.Empty;
        
        /// <summary>
        /// 邮箱
        /// </summary>
        public System.String Email { get; set; } = string.Empty;
        
        /// <summary>
        /// 手机号
        /// </summary>
        public System.String Mobile { get; set; } = string.Empty;
        
        /// <summary>
        /// 是否系统，superadmin和admin都是系统用户
        /// </summary>
        public System.Boolean IsSystem { get; set; } = false;
        
        /// <summary>
        /// 登录次数
        /// </summary>
        public System.Int32 LoginCount { get; set; } = 0;
        
        /// <summary>
        /// 最后登录IP
        /// </summary>
        public System.String LastLoginIP { get; set; } = string.Empty;
        
        /// <summary>
        /// 最后登录区域
        /// </summary>
        public System.String LastLoginArea { get; set; } = string.Empty;
        
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public System.DateTime? LastLoginTime { get; set; } = new DateTime(1900, 1, 1);
        
        /// <summary>
        /// 加入时间
        /// </summary>
        public System.DateTime? AutoTimeStamp { get; set; } = new DateTime(1900, 1, 1);

        #endregion

    }
}