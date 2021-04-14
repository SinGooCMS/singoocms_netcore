using System.ComponentModel;

namespace SinGooCMS
{
    /// <summary>
    /// 客户端类型
    /// </summary>
    public enum ClientType
    {
        [Description("电脑端")]
        Pc,
        [Description("移动端")]
        Mobile,
        [Description("微信端")]
        Weixin
    }
}
