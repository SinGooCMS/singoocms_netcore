using System;

namespace SinGooCMS.Domain
{
    [Serializable]
    public class NodeSetting
    {
        #region 公共属性

        /// <summary>
        /// 栏目首页模板
        /// </summary>
        public string TemplateOfNodeIndex { get; set; } = string.Empty;
        /// <summary>
        /// 栏目列表模板
        /// </summary>
        public string TemplateOfNodeList { get; set; } = string.Empty;
        /// <summary>
        /// 栏目内容模板
        /// </summary>
        public string TemplateOfNodeContent { get; set; } = string.Empty;
        /// <summary>
        /// 是否生成静态页
        /// </summary>
        public bool IsCreateHtml { get; set; } = true;
        /// <summary>
        /// 是否生成静态栏目列表
        /// </summary>
        public bool IsCreateNodeListHtml { get; set; } = true;
        /// <summary>
        /// 是否生成栏目内容静态页
        /// </summary>
        public bool IsCreateNodeContentHtml { get; set; } = true;
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public bool AllowComment { get; set; } = true;
        /// <summary>
        /// 是否允许有子栏目的栏目添加内容
        /// </summary>
        public bool EnableAddInParent { get; set; } = true;
        /// <summary>
        /// 综合页地址规则
        /// </summary>
        public string PagePatternOfNodeIndex { get; set; } = string.Empty;
        /// <summary>
        /// 列表页地址规则
        /// </summary>
        public string PagePatternOfNodeList { get; set; } = string.Empty;
        /// <summary>
        /// 内容页地址规则
        /// </summary>
        public string PagePatternOfNodeContent { get; set; } = string.Empty;
        /// <summary>
        /// 是否需要登录浏览
        /// </summary>
        public bool NeedLogin { get; set; } = false;
        /// <summary>
        /// 允许访问会员组
        /// </summary>
        public string EnableViewUGroups { get; set; } = string.Empty;
        /// <summary>
        /// 允许访问会员等级
        /// </summary>
        public string EnableViewULevel { get; set; } = string.Empty;

        #endregion
    }
}

