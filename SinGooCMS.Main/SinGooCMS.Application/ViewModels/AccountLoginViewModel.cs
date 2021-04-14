using AutoMapper;

namespace SinGooCMS.Application.ViewModels
{
    public class AccountLoginViewModel : Profile
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string ValidateCode { get; set; }
    }
}
