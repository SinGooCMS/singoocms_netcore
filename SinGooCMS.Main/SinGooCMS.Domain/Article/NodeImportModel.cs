using System;
using System.Collections.Generic;

namespace SinGooCMS.Domain
{
    [Serializable]
    public class NodeImportModel
    {
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string NodeName { get; set; } = string.Empty;
        /// <summary>
        /// 栏目标识/代码
        /// </summary>
        public string NodeCode { get; set; } = string.Empty;
        /// <summary>
        /// 模型名称
        /// </summary>
        public string ModelName { get; set; } = string.Empty;
        /// <summary>
        /// 是否菜单
        /// </summary>
        public string IsMenu { get; set; } = "False";
        /// <summary>
        /// 栏目综合页（首页）模板文件
        /// </summary>
        public string IndexTmpl { get; set; } = string.Empty;
        /// <summary>
        /// 栏目列表页模板文件
        /// </summary>
        public string ListTmpl { get; set; } = string.Empty;
        /// <summary>
        /// 栏目详情（文章内容）模板文件
        /// </summary>
        public string DetailTmpl { get; set; } = string.Empty;

        /// <summary>
        /// 重写ToString() 返回栏目的xml格式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("<Node NodeName=\"{0}\" NodeCode=\"{1}\" ModelName=\"{2}\" IsMenu=\"{3}\" IndexTmpl=\"{4}\" ListTmpl=\"{5}\" DetailTmpl=\"{6}\">"
                , NodeName, NodeCode, ModelName, IsMenu, IndexTmpl, ListTmpl, DetailTmpl);
        }
    }
}

