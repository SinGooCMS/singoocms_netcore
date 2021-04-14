using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SinGooCMS;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;

namespace NUnitTest.Article
{
    public class CommentTest
    {
        [Test]
        public async Task TestSend()
        {
            var user = await IOCProvider.Get<IUserRepository>().GetUserByName("16826375@qq.com");
            var result = await IOCProvider.Get<ICommentRepository>().Send("这是一条文章的评论", 2, user);
            Assert.AreEqual(true, result.ret == ResultType.Success);
        }

        [Test]
        public async Task TestActive()
        {
            var user = await IOCProvider.Get<IUserRepository>().GetUserByName("16826375@qq.com");
            var comment = await IOCProvider.Get<ICommentRepository>().FindAsync(1);

            //赞
            await IOCProvider.Get<ICommentActiveLogRepository>().Ding(user, comment);
            var comment1 = IOCProvider.Get<SinGooCMS.Domain.IRepositoryBase<CommentActiveLogInfo>>()
                .NoTrackQuery().Where(p => p.CommentID == 1 && p.UserName == "16826375@qq.com")
                .FirstOrDefault();
            Assert.AreEqual(true, comment1.IsZan);
            //踩
            await IOCProvider.Get<ICommentActiveLogRepository>().Cai(user, comment);
            var comment2 = IOCProvider.Get<SinGooCMS.Domain.IRepositoryBase<CommentActiveLogInfo>>()
                .NoTrackQuery().Where(p => p.CommentID == 1 && p.UserName == "16826375@qq.com")
                .FirstOrDefault();
            Assert.AreEqual(true, !comment2.IsZan);
        }
    }
}
