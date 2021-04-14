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

namespace NUnitTest.User
{
    public class UserTest
    {
        readonly IUserGroupRepository userGroupRepository = IOCProvider.Get<IUserGroupRepository>();
        readonly IUserLevelRepository userLevelRepository = IOCProvider.Get<IUserLevelRepository>();
        readonly IUserRepository userRepository = IOCProvider.Get<IUserRepository>();

        //增加用户
        [Test]
        public async Task AddUser()
        {
            //创建会员组 不同的会员组拥有不同的属性/字段
            var result = await userGroupRepository.AddGroup("测试会员组", "cms_U_TestUserGroup");
            Assert.AreEqual(true, result.ret == ResultType.Success);

            if (result.ret == ResultType.Success)
            {
                var userGroup = await userGroupRepository.GetGroup("测试会员组");
                //读取最初级的会员等级
                var userLevel = await userLevelRepository.GetInitLevel();

                //创建会员
                var userResult = await userRepository.Reg(new UserInfo()
                {
                    UserName = "jsonlee",
                    GroupID = userGroup.AutoID,
                    LevelID = userLevel.AutoID,
                    Password = "123456",
                    Email = "",
                    Mobile = "",
                    Status = (int)UserStatus.Normal,
                    AutoTimeStamp = DateTime.Now
                });

                Assert.AreEqual(true, userResult.OpResult.ret == ResultType.Success);
            }
        }

        //更新用户
        [Test]
        public async Task UpdateUser()
        {
            var user = await userRepository.GetUserByName("jsonlee");
            user.UserName = "jsonlee333";
            var result = await userRepository.UpdateAsync(user);

            Assert.AreEqual(true, result);
        }

        //删除用户
        [Test]
        public async Task DeleteUser()
        {
            //删除会员
            var result1 = await userRepository.DelFullUserInfo("jsonlee333");
            Assert.AreEqual(true, result1);

            //删除会员组
            var userGroup = await userGroupRepository.GetGroup("测试会员组");
            var result2 = await userGroupRepository.DelGroup(userGroup);
            Assert.AreEqual(true, result2.ret == ResultType.Success);
        }
    }
}
