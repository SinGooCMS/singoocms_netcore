//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 11:10:41
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    public interface ISettingRepository : IRepositoryBase<SettingInfo>
    {
        #region 增/改/删

        /// <summary>
        /// 增加自定义设置
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        Task<Result> AddSettingAsync(SettingInfo setting);
        /// <summary>
        /// 更新自定义设置
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        Task<Result> UpdateSettingAsync(SettingInfo setting);
        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="settings"></param>
        Task<bool> UpdateSettingsAsync(IEnumerable<SettingInfo> settings);
        /// <summary>
        /// 删除自定义设置
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        Task<bool> DeleteSettingAsync(SettingInfo setting);

        #endregion

        /// <summary>
        /// 获取自定义配置项
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        Task<SettingInfo> GetSettingByName(string keyName);

        /// <summary>
        /// 获取缓存设置
        /// </summary>
        /// <param name="settingCateID"></param>
        /// <returns></returns>
        Task<IEnumerable<SettingInfo>> GetSettingByCateID(int settingCateID);

        /// <summary>
        /// 获取自定义设置字典
        /// </summary>
        /// <returns></returns>
        Task<Dictionary<string, SettingInfo>> GetSettingDictionary();       
    }
}