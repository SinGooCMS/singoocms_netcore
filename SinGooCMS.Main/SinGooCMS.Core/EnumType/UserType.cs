using System.ComponentModel;

namespace SinGooCMS
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        [Description("系统")]
        System,
        [Description("管理员")]
        Manager,
        [Description("会员")]
        User
    }

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus
    {
        [Description("待审核")]
        WaitAudit = 0,
        [Description("正常")]
        Normal = 99
    }
}
