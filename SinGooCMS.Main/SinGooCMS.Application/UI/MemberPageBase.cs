using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.MVCBase.Filter;
using SinGooCMS.MVCBase;
using Microsoft.AspNetCore.Mvc;

namespace SinGooCMS.Application
{
    /// <summary>
    /// 会员基础类
    /// </summary>
    [TypeFilter(typeof(MemberFilterAttribute))]
    public class MemberPageBase : CMSPageBase
    {
        public new IUser User { get; set; }
        public IUserGroupRepository UserGroupRepository { get; set; }
        public IUserLevelRepository UserLevelRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public MemberPageBase() : base("")
        {
            //
        }
    }
}
