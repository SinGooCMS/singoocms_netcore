using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using NUnit.Framework;
using SinGooCMS;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Models;

namespace NUnitTest
{
    public class AutofacTest
    {
        /// <summary>
        /// autofac注入示例
        /// </summary>
        [Test]
        public void TestUsing()
        {
            //第3步：调用
            var primarykeyId = IOCProvider.Get<IRepositoryBase<LinksInfo>>().AddAsync(new LinksInfo()
            {
                LinkName = "test",
                LinkUrl = "http://www.singoo.top",
                LinkType = "text"
            }).GetAwaiter().GetResult(); //添加友情链接

            Assert.AreEqual(true, primarykeyId > 0);
        }
    }

    public class IOCProvider
    {
        public static T Get<T>()
        {
            /*
             * 第1步：注册
             * 被注入的接口都要继承自：IDependency
             */
            ContainerBuilder containerBuilder = new ContainerBuilder();
            var baseType = typeof(IDependency);
            containerBuilder.RegisterAssemblyTypes(
                    new Assembly[]
                    {
                        Assembly.GetExecutingAssembly(),
                        Assembly.Load("SinGooCMS.Domain"),
                        Assembly.Load("SinGooCMS.Infrastructure"),
                    }
                )
                .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                .AsImplementedInterfaces().PropertiesAutowired();

            var container = containerBuilder.Build();

            //第2步：解析出实例
            return container.Resolve<T>();
        }
    }
}
