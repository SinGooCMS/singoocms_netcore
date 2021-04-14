using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SinGooCMS.Application.ViewModels;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Application.Interface
{
    public interface IUserService : IDependency
    {
        Task<Result> Register(RegisterViewModel regVM, Dictionary<string, UserFieldInfo> dicField);
        Task<Result> Login(LoginViewModel loginVM);
        void Logout();
    }
}
