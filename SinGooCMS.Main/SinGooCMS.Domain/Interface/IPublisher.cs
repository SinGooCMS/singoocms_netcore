using System;
using System.Collections.Generic;
using System.Text;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    public interface IPublisher : IDependency
    {
        /// <summary>
        /// 初始化（栏目）
        /// </summary>
        /// <param name="nodeInfo"></param>
        IPublisher Init(NodeInfo nodeInfo);

        /// <summary>
        /// 初始化（内容）
        /// </summary>
        /// <param name="contId"></param>
        IPublisher Init(int contId);

        /// <summary>
        /// 栏目首页静态文件名称
        /// </summary>
        string NodeHtmlIndexFileName { get; set; }

        /// <summary>
        /// 栏目分页静态文件名称
        /// </summary>
        IList<Tuple<int, string>> NodeHtmlPageFileName { get; set; }

        /// <summary>
        /// 文章静态文件名称
        /// </summary>
        string ArticelHtmlFileName { get; set; }

        /// <summary>
        /// 清空缓存页
        /// </summary>
        void Clear();

        /// <summary>
        /// 删除所有栏目缓存页
        /// </summary>
        void DeleteNodes();

        /// <summary>
        /// 删除所有文章缓存页
        /// </summary>
        void DeleteArticles();

        /// <summary>
        /// 删除已存在的静态文件
        /// </summary>
        void Delete();
    }
}
