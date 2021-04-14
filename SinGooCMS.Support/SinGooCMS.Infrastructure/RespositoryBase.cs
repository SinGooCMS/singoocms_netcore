using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using SinGooCMS.Cache;
using SinGooCMS.Domain;
using SinGooCMS.Ado;
using SinGooCMS.Ado.Interface;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Infrastructure
{
    public class RespositoryBase<TEntity> : IRepositoryBase<TEntity>, IDisposable where TEntity : class, new()
    {
        protected readonly DataContext dbo;
        protected readonly DbSet<TEntity> dbSet;
        protected readonly string tableName;
        protected readonly string key;

        protected readonly ICache cache = CacheProvider.Instance;

        public RespositoryBase()
        {
            dbo = new DataContext();
            dbSet = dbo.Set<TEntity>();
            tableName = EntityAttrUtils.GetTableName(typeof(TEntity));
            key = EntityAttrUtils.GetKey(typeof(TEntity));
        }

        #region Ado

        public IDbAccess DbAccess => DbProvider.DbAccess;

        #endregion

        #region CRUD

        #region 查询

        public virtual IQueryable<TEntity> NoTrackQuery() =>
            dbSet.AsNoTracking();

        public virtual async Task<TEntity> FindAsync(object id) => await dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetListAsync(int topNum = 10, string condition = "", string sort = "Sort asc,AutoID desc") =>
            await DbAccess.GetListAsync<TEntity>(topNum, condition, sort);

        public async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await NoTrackQuery().ToListAsync();

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> condition)
        {
            return condition == null
                ? await NoTrackQuery().AnyAsync()
                : await NoTrackQuery().Where(condition).AnyAsync();
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> condition = null)
        {
            return condition == null
                ? await NoTrackQuery().CountAsync()
                : await NoTrackQuery().Where(condition).CountAsync();
        }

        public virtual async Task<int> GetCountAsync(string condition = null)
        {
            return condition == null
                ? await DbAccess.GetCountAsync(tableName, string.Empty)
                : await DbAccess.GetCountAsync(tableName, condition);
        }

        #endregion

        #region 分页

        public virtual async Task<PagerModel<IEnumerable<TEntity>>> GetPagerListAsync(Expression<Func<TEntity, bool>> condition, string sort, int pageIndex, int pageSize)
        {
            return new PagerModel<IEnumerable<TEntity>>()
            {
                PagerData = pageIndex > 1
                            ? await dbSet.AsQueryable().Where(condition).OrderByBatch(sort).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync()
                            : await dbSet.AsQueryable().Where(condition).OrderByBatch(sort).Take(pageSize).ToListAsync(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalRecord = await GetCountAsync(condition)
            };
        }

        public virtual async Task<PagerModel<IEnumerable<TEntity>>> GetPagerListAsync(string condition, string sort, int pageIndex, int pageSize, string filter = "*")
        {
            return new PagerModel<IEnumerable<TEntity>>()
            {
                PagerData = await DbAccess.GetPagerListAsync<TEntity>(condition, sort, pageIndex, pageSize, filter),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalRecord = await DbAccess.GetCountAsync(tableName, condition)
            };
        }

        public virtual async Task<PagerModel<DataTable>> GetPagerDTAsync(string condition, string sort, int pageIndex, int pageSize, string filter = "*")
        {
            return new PagerModel<DataTable>()
            {
                PagerData = DbAccess.GetPagerDT(tableName, condition, sort, pageIndex, pageSize, filter),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalRecord = await DbAccess.GetCountAsync(tableName, condition)
            };
        }

        #endregion

        public virtual async Task<int> AddAsync(TEntity t)
        {
            int result = 0;
            if (t != null)
            {
                await dbSet.AddAsync(t);
                result = await dbo.SaveChangesAsync();

                if (key == "AutoID")
                {
                    dbo.Entry(t);
                    result = (int)EntityAttrUtils.GetKeyValue(t); //返回主键ID
                }
            }

            return result;
        }

        public virtual async Task<bool> UpdateAsync(TEntity t)
        {
            if (t == null)
                return false;

            dbSet.Update(t);
            return await dbo.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                return false;

            dbSet.UpdateRange(entities);
            return await dbo.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> UpdateAsync(string setItem, string condition)
        {
            string sql = $"update {tableName} set " + setItem;
            if (!string.IsNullOrEmpty(condition))
                sql = sql + " where " + condition;

            return await DbAccess.ExecSQLAsync(sql);
        }

        public virtual async Task<bool> DeleteAsync(TEntity t)
        {
            if (t == null)
                return false;

            dbSet.Remove(t);
            return await dbo.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await DbAccess.ExecSQLAsync($"delete from {tableName} where {key}={id}");
        }

        public virtual async Task<bool> DeleteAsync(string ids)
        {
            return await DbAccess.ExecSQLAsync($"delete from {tableName} where {key} in ({StringUtils.ChkSQL(ids)})");
        }

        public virtual async Task<bool> DeleteAsync(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
            return await dbo.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteAllAsync() => await DbAccess.ExecSQLAsync($"delete from {tableName}");

        #endregion

        #region 排序相关

        public virtual Lazy<int> MaxSort =>
            new Lazy<int>(DbAccess.GetValue<int>($"select max(sort) from {tableName}"));

        public virtual async Task<bool> UpdateSortAsync(Dictionary<int, int> dicIDAndSort)
        {
            var builder = new StringBuilder();
            dicIDAndSort.ForEach(pair =>
            {
                builder.Append($"Update {tableName} SET Sort={pair.Value} Where {key}={pair.Key};");
            });

            return await DbAccess.ExecSQLAsync(builder.ToString());
        }

        public virtual async Task<bool> UpdateSortAsync(int id, int sortValue)
        {
            string sql = $"Update {tableName} SET Sort={sortValue} Where {key}={id}";
            return await DbAccess.ExecSQLAsync(sql);
        }

        #endregion

        ~RespositoryBase()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            dbo.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

