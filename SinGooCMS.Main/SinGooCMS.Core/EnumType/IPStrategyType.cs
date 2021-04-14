using System;
using System.ComponentModel;

namespace SinGooCMS
{
    /// <summary>
    /// IP策略类型
    /// </summary>
    public enum IPStrategyType
    {
        [Description("拒绝访问")]
        DENY,
        [Description("允许访问")]
        ALLOW
    }
}
