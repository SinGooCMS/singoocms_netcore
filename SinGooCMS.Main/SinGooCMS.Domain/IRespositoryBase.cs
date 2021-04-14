using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SinGooCMS.Domain
{
    public interface IRepositoryBase<TEntity> : IDisposable, IDependency where TEntity : class, new()
    {
        #region CRUD

        #region 查询

        /// <summary>
        /// 返回一个无跟踪的query
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> NoTrackQuery();

        /// <summary>
        /// 异步查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(object id);

        /// <summary>
        /// 异步查找多项
        /// </summary>
        /// <param name="topNum"></param>
        /// <param name="condition"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetListAsync(int topNum = 10, string condition = "", string sort = "Sort asc,AutoID desc");

        /// <summary>
        /// 读取所有
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// 异步查找行数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> condition = null);

        /// <summary>
        /// 异步查找行数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<int> GetCountAsync(string condition = null);

        #endregion

        #region 分页

        /// <summary>
        /// 异步查找分页数据
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="sort"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<PagerModel<IEnumerable<TEntity>>> GetPagerListAsync(Expression<Func<TEntity, bool>> condition, string sort, int pageIndex, int pageSize);

        /// <summary>
        /// 异步查找分页数据
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="sort"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<PagerModel<IEnumerable<TEntity>>> GetPagerListAsync(string condition, string sort, int pageIndex, int pageSize, string filter = "*");

        /// <summary>
        /// 异步查找分页数据
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="sort"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<PagerModel<DataTable>> GetPagerDTAsync(string condition, string sort, int pageIndex, int pageSize, string filter = "*");

        #endregion

        /// <summary>
        /// 异步增加并返回主键Key(主键必须是自增int类型)
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<int> AddAsync(TEntity t);

        /// <summary>
        /// 异步修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity t);

        /// <summary>
        /// 异步批量修改
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<bool> UpdateRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 异步批量修改
        /// </summary>
        /// <param name="setItem"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(string setItem, string condition);

        /// <summary>
        /// 异步删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity t);

        /// <summary>
        /// 异步删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 异步删除多项
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(string ids);

        /// <summary>
        /// 异步删除多项
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// 异步删除所有数据
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteAllAsync();

        #endregion

        #region 排序相关

        /// <summary>
        /// 最大排序号
        /// </summary>
        Lazy<int> MaxSort { get; }

        /// <summary>
        /// 批量更新排序号
        /// </summary>
        /// <param name="dicIDAndSort"></param>
        /// <returns></returns>
        Task<bool> UpdateSortAsync(Dictionary<int, int> dicIDAndSort);

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sortValue"></param>
        /// <returns></returns>
        Task<bool> UpdateSortAsync(int id, int sortValue);

        #endregion        
    }
}
