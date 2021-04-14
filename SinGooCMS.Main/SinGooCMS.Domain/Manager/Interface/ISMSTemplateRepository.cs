//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 11:10:42
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    public interface ISMSTemplateRepository : IRepositoryBase<SMSTemplateInfo>
    {
        /// <summary>
        /// 读取短信模板
        /// </summary>
        /// <param name="tmplName"></param>
        /// <returns></returns>
        Task<SMSTemplateInfo> Get(string tmplName);
        /// <summary>
        /// 是否存在模板
        /// </summary>
        /// <param name="tmplName"></param>
        /// <param name="tmplID"></param>
        /// <returns></returns>
        Task<bool> Exists(string tmplName, int tmplID = 0);
    }
}