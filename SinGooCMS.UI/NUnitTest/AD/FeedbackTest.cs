using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using NUnit.Framework;
using SinGooCMS;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using System.Threading.Tasks;

namespace NUnitTest.AD
{
    public class FeedbackTest
    {
        [Test]
        public void DeleteMore()
        {
            var result = IOCProvider.Get<IFeedbackRepository>().DelMutli("7,8").GetAwaiter().GetResult();
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task SendFeedback()
        {
            //ID=9 留言主题目
            var result = await IOCProvider.Get<IFeedbackRepository>().Send("这是一个测试留言", "jsonlee");
            Assert.AreEqual(true, result);            
        }
    }
}
