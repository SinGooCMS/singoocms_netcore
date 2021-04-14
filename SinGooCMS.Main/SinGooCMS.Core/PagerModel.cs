using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SinGooCMS
{
    public class PagerModel<T> : List<T>
    {
        /// <summary>
        /// 分页数据
        /// </summary>
        public T PagerData { get; set; }
        /// <summary>
        /// 页号
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 分页记录数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecord { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage =>
            PageSize > 0
            ? TotalRecord % PageSize == 0 ? TotalRecord / PageSize : (1 + TotalRecord / PageSize)
            : 0;

        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPrevPage => PageIndex < 1;
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNextPage => TotalPage > PageIndex;

    }
}
