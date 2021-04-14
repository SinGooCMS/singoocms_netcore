using System.ComponentModel;

namespace SinGooCMS
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public enum EventType
    {
        [Description("登录事件")]
        Login,
        [Description("管理事件")]
        Manage,
        [Description("系统事件")]
        System,
        [Description("用户事件")]
        UserOperate
    }
}
