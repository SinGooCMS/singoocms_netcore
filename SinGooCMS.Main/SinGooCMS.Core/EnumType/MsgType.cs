using System;
using System.ComponentModel;

namespace SinGooCMS
{
    /// <summary>
    /// 发送消息方类型
    /// </summary>
    public enum SenderType
    {
        [Description("邮箱")]
        Mail,
        [Description("短信")]
        SMS,
    }

    /// <summary>
    /// 发送消息类型
    /// </summary>
    public enum SenderMsgType
    {
        [Description("普通消息")]
        Common,
        [Description("验证码消息")]
        ValidateCode,
    }

    /// <summary>
    /// 消息信息
    /// </summary>
    public enum MsgType
    {
        [Description("系统消息")]
        SystemMsg,
        [Description("提醒消息")]
        RemindMsg,
        [Description("用户消息")]
        UserMsg
    }
}
