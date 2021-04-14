using System.ComponentModel;

namespace SinGooCMS
{
    /// <summary>
    /// 注册类型
    /// </summary>
    public enum RegType
    {
        [Description("普通注册")]
        Normal,
        [Description("手机注册")]
        ByMobile,
        [Description("邮箱注册")]
        ByEmail
    }
}
