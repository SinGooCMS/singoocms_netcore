using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;
using SinGooCMS.Application.ViewModels;

namespace SinGooCMS.Application.Interface
{
    public interface IManagerService : IDependency
    {
        Task<bool> Login(AccountLoginViewModel loginVM);
        Task Logout();
    }
}
