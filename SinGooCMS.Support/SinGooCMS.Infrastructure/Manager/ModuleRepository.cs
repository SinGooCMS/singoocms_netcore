//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-04-03 15:48:57
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Infrastructure
{
    public class ModuleRepository : RespositoryBase<ModuleInfo>, IModuleRepository
    {
        private readonly IOperateRepository operateRepository;
        public ModuleRepository(IOperateRepository _operateRepository)
        {
            this.operateRepository = _operateRepository;
        }

        #region 增/改/删除

        public async Task<Result> AddModule(ModuleInfo entity)
        {
            if (await ExistsCode(entity.ModuleCode))
                return OperateResult.Fail("Menu_ModuleCodeExists", "模块代号已存在");

            int newModuleID = await AddAsync(entity);
            if (newModuleID > 0)
            {
                //添加模块的默认操作符
                await operateRepository.AddDefaultOperate(newModuleID);

                cache.Del(CacheKey.CKEY_ACCOUNTMENU);
                return Result.success;
            }

            return Result.fail;
        }

        public async Task<Result> UpdateModule(ModuleInfo entity)
        {
            if (await ExistsCode(entity.ModuleCode, entity.AutoID))
                return OperateResult.Fail("Menu_ModuleCodeExists", "模块代号已存在");

            if (await UpdateAsync(entity))
            {
                cache.Del(CacheKey.CKEY_ACCOUNTMENU);
                return Result.success;
            }

            return Result.fail;
        }

        public async Task<Result> DelModule(ModuleInfo entity)
        {
            if (entity.IsSystem)
                return OperateResult.Fail("Menu_SysModuleDeleteDenied", "系统模块不可删除");

            //删除模块信息
            dbSet.Remove(entity);
            //删除所属的操作符
            dbo.Operate.RemoveRange(dbo.Operate.Where(p => p.ModuleID == entity.AutoID));
            if (await dbo.SaveChangesAsync() > 0)
            {
                cache.Del(CacheKey.CKEY_ACCOUNTMENU);
                return Result.success;
            }

            return Result.fail;
        }

        #endregion

        public async Task<ModuleInfo> GetModule(int moduleId)
        {
            var module = await FindAsync(moduleId);
            if (module != null)
            {
                module.Operations = await dbo.Operate.AsNoTracking().Where(p => p.ModuleID.Equals(moduleId)).ToListAsync();
            }

            return module;
        }

        public async Task<ModuleInfo> GetModule(string moduleCode)
        {
            var module = NoTrackQuery().Where(p => p.ModuleCode == moduleCode).FirstOrDefault();
            if (module != null)
            {
                module.Operations = await dbo.Operate.AsNoTracking().Where(p => p.ModuleID.Equals(module.AutoID)).ToListAsync();
            }

            return module;
        }

        public async Task<bool> ExistsCode(string moduleCode, int currModuleID = 0) =>
            currModuleID == 0
            ? await ExistsAsync(p => p.ModuleCode == moduleCode)
            : await ExistsAsync(p => p.ModuleCode == moduleCode && p.AutoID != currModuleID);

        public async Task<IEnumerable<ModuleInfo>> GetModules(int catalogID) =>
          await NoTrackQuery().Where(p => p.CatalogID == catalogID).ToListAsync();
    }
}