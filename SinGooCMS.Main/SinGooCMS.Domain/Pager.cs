using System;

namespace SinGooCMS.Domain
{
    /// <summary>
    /// 分页组件
    /// </summary>
    public class Pager
    {
        /// <summary>
        /// 分页组件
        /// </summary>
        /// <param name="totalRecord"></param>
        /// <param name="pageSize"></param>
        public Pager(int totalRecord, int pageSize = 10)
        {
            this.TotalRecord = totalRecord;
            this.PageSize = (pageSize < 1) ? 10 : pageSize;
            this.Calculate();
        }

        /// <summary>
        /// 分页组件
        /// </summary>
        /// <param name="pageSize"></param>
        public Pager(int pageSize = 10)
        {
            this.PageSize = (pageSize < 1) ? 10 : pageSize;
        }

        #region 分页方法

        /// <summary>
        /// 计算分页总数等
        /// </summary>
        public void Calculate()
        {
            if (this.TotalRecord > 0)
            {
                this.TotalPage = this.TotalRecord / this.PageSize;
                if ((this.TotalRecord % this.PageSize) > 0)
                {
                    this.TotalPage++;
                }
                if (this.TotalPage == 0)
                {
                    this.TotalPage = 1;
                }

                if (this.PageIndex < 1)
                {
                    this.PageIndex = 1;
                }
                else if (this.PageIndex > this.TotalPage)
                {
                    this.PageIndex = this.TotalPage;
                }
            }
        }
        /// <summary>
        /// 获取下标数组
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public int[] GetPages(int count)
        {
            int num = this.PageIndex / count;
            if ((this.PageIndex % count) == 0)
            {
                num--;
            }
            int num2 = (num * count) + 1;
            int num3 = Math.Min((num * count) + count, this.TotalPage);
            int[] numArray = new int[(num3 - num2) + 1];
            int index = 0;
            for (int i = num2; i <= num3; i++)
            {
                numArray[index] = i;
                index++;
            }

            this.PageBegin = num2;
            this.PageEnd = num3;

            return numArray;
        }
        /// <summary>
        /// 获取分页地址
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetUrl(int page)
        {
            if (page < 1)
            {
                page = 1;
            }
            else if (page > this.TotalPage)
            {
                page = this.TotalPage;
            }
            return this.GetPageUrl(page);
        }
        /// <summary>
        /// 获取分页地址
        /// </summary>
        /// <param name="getType"></param>
        /// <returns></returns>
        public string GetUrl(string getType)
        {
            string str = string.Empty;
            string str2 = getType.ToLower();
            if (str2 == null)
            {
                return str;
            }
            if (!(str2 == "first"))
            {
                if (str2 != "next")
                {
                    if (str2 == "prev")
                    {
                        return this.GetUrl((int)(this.PageIndex - 1));
                    }
                    if (str2 != "last")
                    {
                        return str;
                    }
                    return this.GetUrl(this.TotalRecord);
                }
            }
            else
            {
                return this.GetUrl(1);
            }
            return this.GetUrl((int)(this.PageIndex + 1));
        }
        /// <summary>
        /// 替换$page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private string GetPageUrl(int page)
        {
            return this.UrlPattern.Replace("$page", page.ToString());
        }

        #endregion        

        #region 公共属性

        /// <summary>
        /// 页开始记录数
        /// </summary>
        public int RecordBegin =>
            ((this.PageIndex - 1) * this.PageSize) + 1;

        /// <summary>
        /// 页结束记录数
        /// </summary>
        public int RecordEnd
        {
            get
            {
                int tempRecord = this.PageIndex * this.PageSize;
                return this.TotalRecord > tempRecord ? tempRecord : this.TotalRecord;
            }
        }

        /// <summary>
        /// 页号起始
        /// </summary>
        public int PageBegin { get; set; } = 1;

        /// <summary>
        /// 页号结束
        /// </summary>
        public int PageEnd { get; set; } = 0;

        /// <summary>
        /// 当前页号
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PageSize { get; set; } = 0;

        /// <summary>
        /// 记录总数
        /// </summary>
        public int TotalRecord { get; set; } = 0;

        /// <summary>
        /// 分页总数
        /// </summary>
        public int TotalPage { get; set; } = 1;

        /// <summary>
        /// url地址规则,一般用于替换$page
        /// </summary>
        public string UrlPattern { get; set; } = "";

        #endregion
    }
}

