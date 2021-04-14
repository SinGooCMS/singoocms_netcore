using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Application;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform.API
{
    [ApiController]
    [Route("api/user/{action}")]
    public class UserController : UIPageBase
    {
        private readonly IUser user;
        public UserController(IUser _user)
        {
            this.user = _user;
        }

        [HttpGet]
        public string LoginUser()
        {
            return user.LoginUser.Value != null
                ? new { UserID = user.UserID, UserName = user.UserName, NickName = user.LoginUser.Value.NickName }.ToJson()
                : new { UserID = -1, UserName = "游客", NickName = "" }.ToJson();
        }
    }
}
