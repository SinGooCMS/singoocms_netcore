//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 11:10:39
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    public interface ISiteTemplateRepository : IRepositoryBase<SiteTemplateInfo>
    {
        #region 增/改/除

        /// <summary>
        /// 异步增加模板
        /// </summary>
        /// <param name="tmplInfo"></param>
        /// <returns></returns>
        Task<int> AddTmplAsync(SiteTemplateInfo tmplInfo);
        /// <summary>
        /// 异步更新模板
        /// </summary>
        /// <param name="tmplInfo"></param>
        /// <returns></returns>
        Task<bool> UpdateTmplAsync(SiteTemplateInfo tmplInfo);
        /// <summary>
        /// 设置默认模板
        /// </summary>
        /// <param name="intTemplateID"></param>
        /// <returns></returns>
        Task<bool> SetDefaultTmpl(int intTemplateID);
        /// <summary>
        /// 异步删除模板
        /// </summary>
        /// <param name="tmplInfo"></param>
        /// <returns></returns>
        Task<bool> DeleteTmplAsync(SiteTemplateInfo tmplInfo);        

        #endregion

        /// <summary>
        /// 读取默认的模板
        /// </summary>
        /// <returns></returns>
        SiteTemplateInfo GetDefaultTmpl();        

        /// <summary>
        /// 从缓存中读取模板
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SiteTemplateInfo GetCacheTmpl(int id);

        /// <summary>
        /// 读取所有模板目录
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetTmplDirs();
    }
}