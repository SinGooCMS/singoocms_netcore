using System;
using System.Threading.Tasks;
using SinGooCMS.Application.ViewModels;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Application.Interface;
using SinGooCMS.Utility;

namespace SinGooCMS.Application.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IAccountRepository accountRepository;
        private readonly ILogService logService;
        private readonly IManager manager;

        public ManagerService(
            IAccountRepository _accountRepository,
            ILogService _logService,
            IManager _manager)
        {
            this.accountRepository = _accountRepository;
            this.logService = _logService;
            this.manager = _manager;
        }

        public async Task<bool> Login(AccountLoginViewModel loginVM)
        {
            var account = await accountRepository.Login(loginVM.AccountName, loginVM.Password);
            if (account != null)
            {
                SessionUtils.SetSession("Account", account);
                await logService.AddLoginLog(UserType.Manager, loginVM.AccountName, true);
                return true;
            }
            else
            {
                await logService.AddLoginLog(UserType.Manager, loginVM.AccountName, false);
                return false;
            }
        }

        public async Task Logout()
        {
            if (manager.LoginAccount != null)
            {
                var accountName = manager.AccountName; //退出登录后，无法取到manager.AccountName的值
                accountRepository.Logout(manager.LoginAccount);
                await logService.AddEvent(UserType.Manager, accountName, "退出登录", EventType.Login, true);
            }
        }
    }
}
