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

namespace NUnitTest.Manager
{
    public class AccountTest
    {
        readonly IModuleRepository moduleRepository = IOCProvider.Get<IModuleRepository>();
        readonly IRoleRepository roleRepository = IOCProvider.Get<IRoleRepository>();
        readonly IAccountRepository accountRepository = IOCProvider.Get<IAccountRepository>();
        readonly IPurviewRepository purviewRepository = IOCProvider.Get<IPurviewRepository>();

        //增加模块
        [Test]
        public async Task TestAddModule()
        {
            var result = await moduleRepository.AddModule(new ModuleInfo()
            {
                CatalogID = 5,
                ModuleName = "测试模块",
                ModuleCode = "testmodule",
                FilePath = "/tester/testmodule"
            });

            //AutoID:46
            Assert.AreEqual(true, result.ret == ResultType.Success);
        }

        //增加角色
        [Test]
        public async Task TestAddRole()
        {
            //AutoID : 5
            var roleID = await roleRepository.AddRole("测试角色");
            //给角色设置权限
            await roleRepository.SetPermissions(roleID, 46);
            Assert.AreEqual(true, roleID > 0);
        }

        //增加账户
        [Test]
        public async Task TestAddAccount()
        {
            var result = await accountRepository.AddAccount("jsonlee", "123456", "5");
            Assert.AreEqual(true, result.ret == ResultType.Success);
        }

        //判断权限
        [Test]
        public async Task TestPermission()
        {
            //判断是否有模块1的查看权限
            var operations = await purviewRepository.GetPurviews(5);
            var temp = operations.Where(p => p.ModuleID.Equals(1) && p.OperateCode.Equals("View")).FirstOrDefault();
            Assert.AreEqual(null, temp);

            //设置权限
            await roleRepository.SetPermissions(5, 1, "View");
            var temp2 = operations.Where(p => p.ModuleID.Equals(1) && p.OperateCode.Equals("View")).FirstOrDefault();
            Assert.AreEqual(true, temp2 != null);
        }

        //删除以上信息
        [Test]
        public async Task TestDelete()
        {
            //删除账号
            if ((await accountRepository.DelAccount(await accountRepository.FindAsync(4))).ret == ResultType.Success)
            {
                //删除角色
                if ((await roleRepository.DelRole(5)).ret == ResultType.Success)
                {
                    //删除模块
                    await moduleRepository.DelModule(await moduleRepository.FindAsync(46));
                }
            }
        }
    }
}
