using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Ado.Interface;
using SinGooCMS.Ado;

namespace SinGooCMS.MVCBase
{
    /// <summary>
    /// 栏目、文章生成缓存页
    /// </summary>
    public class Publisher : IPublisher
    {
        private const string NodeHtmlIndexFileRule = "article-node-${NodeUrlRewriteName}.html";
        private const string NodeHtmlPageFileRule = "article-node-${NodeUrlRewriteName}-${page}.html";
        private const string ArticelHtmlFileRule = "article-detail-${id}.html";

        private NodeInfo nodeInfo;
        private int contId;

        private readonly IDbAccess dbAccess = DbProvider.DbAccess;
        
        public Publisher()
        {
            //
        }

        public IPublisher Init(NodeInfo _nodeInfo)
        {
            this.nodeInfo = _nodeInfo;
            this.NodeHtmlIndexFileName = NodeHtmlIndexFileRule.Replace("${NodeUrlRewriteName}", nodeInfo.NodeIdentifier);

            //栏目分页
            int totalCount = dbAccess.GetCount("cms_Content", " NodeID in (" + nodeInfo.ChildList + ") ");
            int totaPage = 1;
            if (nodeInfo.ItemPageSize > 0)
                totaPage = totalCount % nodeInfo.ItemPageSize == 0 ? totalCount / nodeInfo.ItemPageSize : (totalCount / nodeInfo.ItemPageSize + 1);

            if (totaPage > 1)
            {
                var lst = new List<Tuple<int, string>>();
                for (int i = 1; i <= totaPage; i++)
                {
                    lst.Add(new Tuple<int, string>(i, NodeHtmlPageFileRule.Replace("${NodeUrlRewriteName}", nodeInfo.NodeIdentifier).Replace("${page}", i.ToString())));
                }

                this.NodeHtmlPageFileName = lst;
            }

            return this;
        }

        public IPublisher Init(int _contId)
        {
            this.contId = _contId;
            this.ArticelHtmlFileName = ArticelHtmlFileRule.Replace("${id}", contId.ToString());
            return this;
        }

        public string NodeHtmlIndexFileName { get; set; }

        public IList<Tuple<int, string>> NodeHtmlPageFileName { get; set; }

        public string ArticelHtmlFileName { get; set; }

        #region 删除缓存页

        public void Clear()
        {
            var dir = SinGooBase.GetMapPath(SinGooBase.HtmlCacheFolder);
            DeleteDir(dir);
        }

        public void DeleteNodes()
        {
            var dir = SinGooBase.GetMapPath(SinGooBase.HtmlCacheFolder);
            DeleteDir(dir, "article-node");
        }

        public void DeleteArticles()
        {
            var dir = SinGooBase.GetMapPath(SinGooBase.HtmlCacheFolder);
            DeleteDir(dir, "article-detail");
        }

        /// <summary>
        /// 递归删除文件夹里的文件信息
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="specialFilePart"></param>
        private void DeleteDir(string dir, string specialFilePart = "")
        {
            if (Directory.Exists(dir))
            {
                var dirInfo = new DirectoryInfo(dir);
                foreach (var item in dirInfo.GetFileSystemInfos())
                {
                    if (File.Exists(item.FullName))
                    {
                        if (specialFilePart == "" ||
                            (specialFilePart != "" && item.Name.IndexOf(specialFilePart) != -1))
                            File.Delete(item.FullName);
                    }
                    else
                        DeleteDir(item.FullName);
                }
                //Directory.Delete(dir, true);
            }
        }

        public void Delete()
        {
            string absoluteDir = SinGooBase.GetMapPath(SinGooBase.HtmlCacheFolder);
            if (this.nodeInfo != null)
            {
                //删除栏目的html缓存
                if (File.Exists(FileUtils.Combine(absoluteDir, NodeHtmlIndexFileName)))
                    File.Delete(FileUtils.Combine(absoluteDir, NodeHtmlIndexFileName));

                //删除栏目分页的html缓存
                if (NodeHtmlPageFileName != null && NodeHtmlPageFileName.Count > 0)
                {
                    foreach (var item in NodeHtmlPageFileName)
                    {
                        if (File.Exists(FileUtils.Combine(absoluteDir, item.Item2)))
                            File.Delete(FileUtils.Combine(absoluteDir, item.Item2));
                    }
                }
            }
            else if (this.contId > 0)
            {
                //删除内容缓存页
                if (File.Exists(FileUtils.Combine(absoluteDir, ArticelHtmlFileName)))
                    File.Delete(FileUtils.Combine(absoluteDir, ArticelHtmlFileName));
            }
        }

        #endregion
    }
}
