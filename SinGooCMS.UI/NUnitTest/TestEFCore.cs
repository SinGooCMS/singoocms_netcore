using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NUnit.Framework;
using SinGooCMS;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Models;

namespace NUnitTest
{
    public class TestEFCore
    {
        [Test]
        public async Task UpdateOrInsert()
        {
            //更新一定要有主键，否则更新变成了插入
            var model = new SinGooCMS.Domain.Models.TagsInfo() { 
                TagName=".net"
            };
            await IOCProvider.Get<SinGooCMS.Domain.Interface.ITagsRepository>().UpdateAsync(model);
        }
    }
}
