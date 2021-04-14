using System.ComponentModel;

namespace SinGooCMS
{
    /// <summary>
    /// 内容状态
    /// </summary>
    public enum ContStatus
    {
        [Description("草稿箱")]
        DraftBox = 0,
        [Description("回收站")]
        Recycle = -1,
        [Description("正常")]
        Normal = 99
    }

    /// <summary>
    /// 内容醒目设置类型
    /// </summary>
    public enum ContMarkednessType
    {
        [Description("置顶")]
        Top,
        [Description("推荐")]
        Recommend,
        [Description("最新")]
        New
    }
}
