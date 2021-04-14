//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-04-03 15:48:59
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Infrastructure
{
    public class SMSTemplateRepository : RespositoryBase<SMSTemplateInfo>, ISMSTemplateRepository
    {
        public SMSTemplateRepository()
        {
            //
        }

        public async Task<bool> Exists(string tmplName, int tmplID = 0) =>
            tmplID == 0
            ? await dbSet.Where(p => p.TemplName == tmplName).AnyAsync()
            : await dbSet.Where(p => p.TemplName == tmplName && p.AutoID != tmplID).AnyAsync();

        public async Task<SMSTemplateInfo> Get(string tmplName) =>
            await dbSet.Where(p => p.TemplName == tmplName).FirstOrDefaultAsync();
    }
}