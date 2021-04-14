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
    public class ContentTest
    {
        readonly INodeRepository nodeRepository = IOCProvider.Get<INodeRepository>();
        readonly IContModelRepository contModelRepository = IOCProvider.Get<IContModelRepository>();
        readonly IContentRepository contentRepository = IOCProvider.Get<IContentRepository>();
        readonly IContFieldRepository contFieldRepository = IOCProvider.Get<IContFieldRepository>();

        /*
         * 文章内容 
         * 通过模型来组织内容
         * 通过模板来展示内容
         * 
         */
        [Test]
        public async Task TestAddSimpleContent()
        {
            //栏目
            var node = nodeRepository.GetCacheNode("products");
            //模型
            var model = await contModelRepository.FindAsync(node.ModelID);

            var content = new ContentInfo()
            {
                Title = "测试的",
                Status = (int)ContStatus.Normal
            };

            var result = await contentRepository.AddContent(content, node, model);
            Assert.AreEqual(true, result > 0);
        }

        [Test]
        public async Task TestAddContent()
        {
            //栏目
            var node = nodeRepository.GetCacheNode("products");
            //模型
            var model = await contModelRepository.FindAsync(node.ModelID);

            var content = new ContentInfo()
            {
                Status = (int)ContStatus.Normal
            };

            //字段集合
            var field = await contFieldRepository.GetField(model.AutoID, "Title");
            field.Value = "第二条测试记录";
            Dictionary<string, ContFieldInfo> dictFields = new Dictionary<string, ContFieldInfo>();
            dictFields.Add("Title", field);

            var result = await contentRepository.AddContent(content, node, model, dictFields);
            Assert.AreEqual(true, result > 0);
        }

        /// <summary>
        /// 更新内容不更新栏目信息
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task TestUpdate()
        {
            var contentInfo = await contentRepository.FindAsync(42);

            //字段集合
            var field = await contFieldRepository.GetField(contentInfo.ModelID, "Title");
            field.Value = "被修改的第二条测试记录";
            Dictionary<string, ContFieldInfo> dictFields = new Dictionary<string, ContFieldInfo>();
            dictFields.Add("Title", field);

            var result = await contentRepository.UpdateContent(contentInfo, dictFields);
            Assert.AreEqual(true, result);
        }

        //移动到栏目
        [Test]
        public async Task TestContMove()
        {
            var node = nodeRepository.GetCacheNode("news");
            var result = await contentRepository.MoveContent("42", node);

            Assert.AreEqual("新闻中心", (await contentRepository.GetContentFull(42)).NodeName);
        }

        //复制
        [Test]
        public async Task TestCopyCont()
        {
            var cont = await contentRepository.FindAsync(42);
            var newID = await contentRepository.CopyToNewCont(cont, "admin");
            Assert.AreEqual(true, newID > 0);
        }

        //删除内容
        [Test]
        public async Task TestDelete()
        {
            //删除到回收站
            //await contentRepository.DelToRecycle("42,43");
            //Assert.AreEqual((int)ContStatus.Recycle, (await contentRepository.FindAsync(42)).Status);

            //从回收站删除，同时在数据库也删除
            await contentRepository.DelFromRecycle("42,43");
            var model = await contentRepository.FindAsync(42);
            Assert.AreEqual(null, model);
        }
    }
}
