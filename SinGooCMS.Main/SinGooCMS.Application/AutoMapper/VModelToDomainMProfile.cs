using AutoMapper;
using SinGooCMS.Application.ViewModels;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Application.AutoMapper
{
    public class VModelToDomainMProfile : Profile
    {
        /// <summary>
        /// viewmodel->model
        /// </summary>
        public VModelToDomainMProfile()
        {
            CreateMap<OperateResult, Result>();
            CreateMap<AccountLoginViewModel, AccountInfo>();
            CreateMap<RegisterViewModel, UserInfo>();
        }
    }
}
