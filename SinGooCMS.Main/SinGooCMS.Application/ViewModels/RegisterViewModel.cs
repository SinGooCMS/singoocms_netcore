using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace SinGooCMS.Application.ViewModels
{
    public class RegisterViewModel : Profile
    {
        public RegType RegType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int GroupID { get; set; }
        public int LevelID { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string NickName { get; set; }
        public int Status { get; set; }
        public DateTime AutoTimeStamp { get; set; }
    }
}
