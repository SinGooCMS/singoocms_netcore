using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SinGooCMS;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;

namespace NUnitTest.Article
{
    public class NodeTest
    {
        readonly INodeRepository nodeRepository = IOCProvider.Get<INodeRepository>();
        readonly IContModelRepository contModelRepository = IOCProvider.Get<IContModelRepository>();

        //添加栏目
        [Test]
        public async Task TestAdd()
        {
            var parentNode = await nodeRepository.FindAsync(7);
            var result = await nodeRepository.AddNode(new NodeInfo()
            {
                NodeName = "测试栏目",
                NodeIdentifier = "testnode",
                ModelID = (await contModelRepository.FindAsync(1))?.AutoID ?? 0,
                AutoTimeStamp = DateTime.Now
            }, parentNode);

            Assert.AreEqual(true, result.NodeId > 0);
        }

        //更新栏目
        [Test]
        public async Task TestUpdate()
        {
            var node = nodeRepository.GetCacheNode("testnode");
            node.NodeIdentifier = "testnode2";
            var result = await nodeRepository.UpdateNode(node);

            Assert.AreEqual(true, result.ret == ResultType.Success);
        }

        //移动栏目
        [Test]
        public async Task TestNodeMove()
        {
            var node = nodeRepository.GetCacheNode("products");
            var result = await nodeRepository.NodeMove(node, nodeRepository.GetCacheNode(1));

            Assert.AreEqual(true, result.ret == ResultType.Success);
        }

        //导入栏目
        [Test]
        public async Task TestImportNode()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<?xml version=\"1.0\" encoding=\"utf - 8\" ?><NodeTemplate>");
            builder.Append("<Node NodeName=\"校园招聘\" NodeCode=\"schoolzp\" ModelName=\"普通文章\" IsMenu=\"1\" IndexTmpl=\"人才招聘.cshtml\" ListTmpl=\"人才招聘.cshtml\" DetailTmpl=\"人才招聘.cshtml\"></Node>");
            builder.Append("</NodeTemplate>");
            await nodeRepository.Import(builder.ToString(), "zh-cn", "admin");
        }

        //删除栏目
        [Test]
        public async Task TestDelete()
        {
            var node = nodeRepository.GetCacheNode("testnode2");
            var result = await nodeRepository.DeleteNode(node);

            Assert.AreEqual(true, result.ret == ResultType.Success);
        }
    }
}
