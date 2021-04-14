using System.ComponentModel;

namespace SinGooCMS.Control
{
    /// <summary>
    /// 文本框类型（html5新特性）
    /// </summary>
    public enum TextMode
    {
        [Description("普通")]
        Text,
        [Description("密码")]
        Password,
        [Description("邮件")]
        Email,
        [Description("链接")]
        Url,
        [Description("数字")]
        Number,
        [Description("范围")]
        Range,
        [Description("搜索")]
        Search,
        [Description("拾色器")]
        Color
    }
}
