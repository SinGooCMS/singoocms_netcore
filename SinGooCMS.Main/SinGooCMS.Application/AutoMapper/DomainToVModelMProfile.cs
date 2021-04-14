using System;
using AutoMapper;
using SinGooCMS.Application.ViewModels;
using SinGooCMS.Domain.Models;
using SinGooCMS.Control;

namespace SinGooCMS.Application.AutoMapper
{
    public class DomainToVModelMProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public DomainToVModelMProfile()
        {
            CreateMap<Result, OperateResult>();
            CreateMap<AccountInfo, AccountLoginViewModel>();
            CreateMap<BaseConfigInfo, Plugins.Email.MailConfig>().AfterMap((s, t) => t.FromDisplayName = s.SiteName);
            //CreateMap<BaseConfigInfo, Plugins.SMS.SMSConfig>();
            CreateMap<SettingInfo, IFieldControl>().AfterMap((s, t) =>
            {
                t.FieldName = s.KeyName;
                t.FieldAlias = s.KeyDesc;
                //t.FieldType = (FieldType)Enum.Parse(typeof(FieldType), s.ControlType);
                t.Settings = s.FieldSetting;
                t.EnableNull = true;
                t.FieldValue = s.KeyValue;
            });
            CreateMap<ContFieldInfo, IFieldControl>().AfterMap((s, t) =>
            {
                //t.FieldType = (FieldType)Enum.Parse(typeof(FieldType), s.FieldType);
                t.FieldValue = s.Value;
            });
            CreateMap<UserFieldInfo, IFieldControl>().AfterMap((s, t) =>
            {
                //t.FieldType = (FieldType)Enum.Parse(typeof(FieldType), s.FieldType);
                t.FieldValue = s.Value;
            });
        }
    }
}
