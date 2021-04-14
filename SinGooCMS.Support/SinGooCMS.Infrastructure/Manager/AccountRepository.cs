//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-04-03 15:48:53
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Infrastructure
{
    public class AccountRepository : RespositoryBase<AccountInfo>, IAccountRepository
    {
        public AccountRepository()
        {
            //
        }

        public async Task<Result> AddAccount(AccountInfo entity)
        {
            if (entity.Password.Trim().Length < 6)
                return OperateResult.Fail("User_UserPwdLenNeed", "密码长度不少于6位");

            if (await ExistsAccountName(entity.AccountName))
                return OperateResult.Fail("User_UserNameAlreadyExists", "账户/用户名已存在");

            return await AddAsync(entity) > 0
                ? Result.success
                : Result.fail;
        }

        public async Task<Result> AddAccount(string accountName, string password, string roles = "", string email = "", string phone = "")
        {
            return await AddAccount(new AccountInfo()
            {
                AccountName = accountName,
                Password = DEncryptUtils.SHA512Encrypt(password),
                Roles = roles,
                Email = email,
                Mobile = phone,
                AutoTimeStamp = DateTime.Now
            });
        }

        public async Task<Result> UpdateAccount(AccountInfo entity)
        {
            if (await ExistsAccountName(entity.AccountName, entity.AutoID))
                return OperateResult.Fail("User_UserNameAlreadyExists", "账户/用户名已存在");

            return await UpdateAsync(entity)
                ? Result.success
                : Result.fail;
        }

        public async Task<Result> DelAccount(AccountInfo entity)
        {
            if (entity.IsSystem)
                return OperateResult.Fail("PLFM_SysAccountDeleteDenied", "系统帐户不可删除");

            if (string.Compare(entity.AccountName, "superadmin", true) == 0)
                return OperateResult.Fail("PLFM_SuperAdminDeleteDenied", "超级管理员(superadmin)不可删除");

            return await DeleteAsync(entity)
                ? Result.success
                : Result.fail;
        }

        public async Task<AccountInfo> Login(string accountName, string password)
        {
            var account = await NoTrackQuery().Where(p => p.AccountName == accountName && p.Password == password).FirstOrDefaultAsync();
            if (account != null)
            {
                account.LoginCount++; //登录次数+1
                account.LastLoginIP = IPUtils.GetIP(); //记录IP
                account.LastLoginArea = IPUtils.GetIPAreaStr();
                account.LastLoginTime = System.DateTime.Now;
                await UpdateAsync(account);

                //菜单
                var dict = cache.Get<Dictionary<int, DataTable>>(CacheKey.CKEY_ACCOUNTMENU);
                if (dict == null)
                    dict = new Dictionary<int, DataTable>();

                if (dict.Keys.Contains(account.AutoID))
                    dict[account.AutoID] = await GetMenu(account);
                else
                    dict.Add(account.AutoID, await GetMenu(account));

                cache.Insert(CacheKey.CKEY_ACCOUNTMENU, dict);
                return account;
            }

            return null;
        }

        public void Logout(AccountInfo account)
        {
            SessionUtils.DelSession("Account");
            var dict = cache.Get<Dictionary<int, DataTable>>(CacheKey.CKEY_ACCOUNTMENU);
            if (dict != null && dict.ContainsKey(account.AutoID))
            {
                dict.Remove(account.AutoID);
                cache.Insert(CacheKey.CKEY_ACCOUNTMENU, dict);
            }
        }

        public async Task<AccountInfo> GetAdmin() =>
           await NoTrackQuery().Where(p => p.AccountName == "admin").FirstOrDefaultAsync();

        public async Task<AccountInfo> GetSuperAdmin() =>
          await NoTrackQuery().Where(p => p.AccountName == "superadmin").FirstOrDefaultAsync();

        public async Task<DataTable> GetMenu(AccountInfo account)
        {
            if (account == null)
                return null;

            string sql = "";
            //超级管理员
            var superAdmin = await dbo.Role.Where(p => p.RoleName.Equals("超级管理员")).FirstOrDefaultAsync(); //必定有
            if (superAdmin == null)
                throw new Exception("缺少超级管理员信息");

            if (account.Roles.ToIntArray().Contains(superAdmin.AutoID))
            {
                //拥有超管权限
                sql = @"SELECT a.AutoID AS CatalogID,a.CatalogName,a.CatalogCode,a.Sort AS CataSort, 
                        b.AutoID AS ModuleID,b.ModuleName,b.ModuleCode,b.FilePath,b.ImagePath,b.Sort 
                        FROM sys_Catalog a, sys_Module b 
                        WHERE b.CatalogID = a.AutoID 
                        ORDER BY a.Sort ASC, b.Sort ASC ";
            }
            else
            {
                sql = string.Format(@"SELECT a.AutoID AS CatalogID,a.CatalogName,a.CatalogCode,a.Sort AS CataSort, 
                    b.AutoID AS ModuleID,b.ModuleName,b.ModuleCode,b.FilePath,b.ImagePath,b.Sort 
                    FROM sys_Catalog a, sys_Module b, 
                    ( 
                        SELECT ModuleID FROM sys_Purview 
                        WHERE RoleID in ({0}) 
                        GROUP BY ModuleID 
                    ) c 
                    WHERE c.ModuleID = b.AutoID AND b.CatalogID = a.AutoID 
                    ORDER BY a.Sort ASC, b.Sort ASC ", account.Roles);
            }

            var dt = DbAccess.GetDataTable(sql);
            DataColumn dc = new DataColumn("Module", Type.GetType("System.String"));
            dt.Columns.Add(dc);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Module"] = SinGooBase.DesEncode(dr["ModuleID"].ToString()); //加密模块ID
                }
            }

            return dt;
        }

        #region helper

        /// <summary>
        /// 账户名是否存在
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        private async Task<bool> ExistsAccountName(string accountName, int accountID = 0)
        {
            return accountID == 0
                ? await NoTrackQuery().Where(p => p.AccountName.Equals(accountName)).AnyAsync()
                : await NoTrackQuery().Where(p => p.AccountName.Equals(accountName) && p.AutoID != accountID).AnyAsync();
        }

        #endregion
    }
}