using System;
using System.Text;
using SinGooCMS.Utility;

namespace SinGooCMS.Domain
{
    public class MVCPager : Pager
    {
        public MVCPager(Pager pager, string urlPattern = "h5.loadData($page)")
            : this(urlPattern, pager.TotalRecord, pager.PageIndex, pager.PageSize)
        {
            //
        }

        public MVCPager(int recordCount, int pageIndex = 1, int pageSize = 20, string urlPattern = "h5.loadData($page)")
            : this(urlPattern, recordCount, pageIndex, pageSize)
        {
            //
        }

        /// <summary>
        /// MVC分页控件
        /// </summary>
        /// <param name="urlPattern">分页地址</param>
        /// <param name="recordCount">总记录</param>
        /// <param name="pageIndex">当前页号</param>
        /// <param name="pageSize">每页记录数</param>
        public MVCPager(string urlPattern, int recordCount, int pageIndex = 1, int pageSize = 20)
        {
            base.UrlPattern = urlPattern; //分页规则 如 http://www.xx.com/article/news?page=$page
            base.TotalRecord = recordCount;
            base.PageIndex = pageIndex;
            base.PageSize = pageSize < 1 ? 10 : pageSize;
            base.Calculate();
        }

        #region 公共属性

        /// <summary>
        /// 分页模板
        /// </summary>
        public string TemplatePath
        {
            get;
            set;
        }

        string _FirstPageText = "首页"; //"&laquo;"; //<< "首页";
        public string FirstPageText
        {
            get
            {
                return _FirstPageText;
            }
            set
            {
                _FirstPageText = value;
            }
        }
        string _PrevPageText = "上一页"; //"&lsaquo;";//< "上一页";
        public string PrevPageText
        {
            get
            {
                return _PrevPageText;
            }
            set
            {
                _PrevPageText = value;
            }
        }
        string _NextPageText = "下一页"; //"&rsaquo;"; //>"下一页";
        public string NextPageText
        {
            get
            {
                return _NextPageText;
            }
            set
            {
                _NextPageText = value;
            }
        }
        string _EndPageText = "尾页";// "&raquo;"; //>>"尾页";
        public string EndPageText
        {
            get
            {
                return _EndPageText;
            }
            set
            {
                _EndPageText = value;
            }
        }
        /// <summary>
        /// 分割下标的html标签
        /// </summary>
        public string SplitTag
        {
            get;
            set;
        }
        private bool _IsEmptyHide = false;
        /// <summary>
        /// 是否数据不足时自动隐藏
        /// </summary>
        public bool IsEmptyHide
        {
            get
            {
                return _IsEmptyHide;
            }
            set
            {
                _IsEmptyHide = value;
            }
        }

        private bool _IsShowTotalPage = true;
        /// <summary>
        /// 是否显示左边总页数
        /// </summary>
        public bool IsShowTotalPage
        {
            get { return _IsShowTotalPage; }
            set { _IsShowTotalPage = value; }
        }

        private bool _IsShowPageSize = true;
        /// <summary>
        /// 是否显示分页记录数下列选择框
        /// </summary>
        public bool IsShowPageSize
        {
            get { return _IsShowPageSize; }
            set { _IsShowPageSize = value; }
        }

        private bool _IsShowTotalRecord = true;
        /// <summary>
        /// 是否显示总记录数
        /// </summary>
        public bool IsShowTotalRecord
        {
            get { return _IsShowTotalRecord; }
            set { _IsShowTotalRecord = value; }
        }
        #endregion        

        #region 输出MVC分页Json数据

        /// <summary>
        /// 输出分页Json数据
        /// </summary>
        /// <returns></returns>
        public string PagerJson()
        {
            /*
             {
		        "pageIndex": 1,
		        "pageSize": 20,
		        "totalRecord": 10,
		        "totalPage": 1,
		        "firstPageLink": "",
		        "prevPageLink": "",
		        "pagerNums": [],
		        "nextPageLink": "",
		        "endPageLink": ""
            }
            */

            var builder = new StringBuilder("{");
            builder.Append(string.Format("\"pageIndex\": {0},\"pageSize\": {1},\"totalRecord\": {2},\"totalPage\": {3},\"IsShowTotalPage\":{4},\"IsShowPageSize\":{5},\"IsShowTotalRecord\":{6},",
                PageIndex, PageSize, TotalRecord, TotalPage, IsShowTotalPage ? "true" : "false", IsShowPageSize ? "true" : "false", IsShowTotalRecord ? "true" : "false"));

            #region 显示首页，上一页

            if (this.PageIndex == 1)
                builder.Append(string.Format("\"firstPageLink\": \"<a class='firstPageLink disabled' disabled='disabled'>{0}</a>\",\"prevPageLink\": \"<a class='prevPageLink disabled' disabled='disabled'>{1}</a>\",", this.FirstPageText, this.PrevPageText));
            else
                builder.Append(string.Format("\"firstPageLink\": \"<a class='firstPageLink' title='首页' href='javascript:{0}\'>{1}</a>\",\"prevPageLink\": \"<a class='prevPageLink' title='上一页' href='javascript:javascript:{2}'>{3}</a>\",", GetUrl("first"), this.FirstPageText, GetUrl("prev"), this.PrevPageText));

            #endregion

            #region 显示下标

            StringBuilder sub = new StringBuilder();
            int counter = 1;
            //显示最多10页下标
            foreach (int item in GetPages(10))
            {
                counter = item;
                sub.Append(string.Format("{{\"url\":\"<a {0} href='javascript:{1}'>{2}</a>\"}},", (item == this.PageIndex ? "class='active'" : ""), GetUrl(item), item));

                counter++;
            }

            //页面没有完全显示，比如超过10页，当前只显示1-10。那用...表示还有更多页
            if (counter < TotalPage)
            {
                sub.Append(string.Format("{{\"url\":\"<a  href='javascript:{0}'>...</a>\"}}", GetUrl(counter)));
            }

            builder.Append(string.Format("\"pagerNums\":[{0}],", sub.ToString().TrimEnd(',')));

            #endregion

            #region  显示下一页，末页

            if (this.TotalPage <= 0 || this.PageIndex == this.TotalPage)
                builder.Append(string.Format("\"nextPageLink\": \"<a class='nextPageLink disabled' disabled='disabled'>{0}</a>\",\"endPageLink\": \"<a class='endPageLink disabled' disabled='disabled'>{1}</a>\"", this.NextPageText, this.EndPageText));
            else
                builder.Append(string.Format("\"nextPageLink\": \"<a class='nextPageLink' title='下一页' href='javascript:{0}'>{1}</a>\",\"endPageLink\": \"<a class='endPageLink' title='尾页' href='javascript:{2}'>{3}</a>\"", GetUrl("next"), this.NextPageText, GetUrl("last"), this.EndPageText));

            #endregion

            builder.Append("}");

            return builder.ToString();
        }

        /// <summary>
        /// 输出分页json到前端
        /// </summary>
        /// <param name="dataJson"></param>
        /// <returns></returns>
        public string Display(string dataJson)
        {
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":" + this.PagerJson() + "}}";
        }

        #endregion       

        #region 输出MVC分页HTML文本

        /// <summary>
        /// 输出分页html
        /// </summary>
        /// <param name="template">分页模板</param>
        /// <returns></returns>
        [Obsolete("已弃用")]
        public string PagerHtml(string template = "/views/platform/h5/inc/pagertemplate.html")
        {
            if ((this.TotalRecord == 0 || this.TotalPage == 1) && IsEmptyHide)
                return string.Empty; //没有内容或者仅一页时不显示

            #region 选择分页模板
            if (!string.IsNullOrEmpty(template))
                this.TemplatePath = template;

            string defaultTemplate = "<div class=\"com-pager clear-fix mt-20\"><table><tr><td>总记录：<span>${TotalRecord}</span>条，每页<span>${PageSize}</span>条，当前页：<span>${PageIndex}</span>/<span>${TotalPage}</span></td><td>${FirstPageLink}</td><td>${PrevPageLink}</td><td>${PagerNums}</td><td>${NextPageLink}</td><td>${EndPageLink}</td><td>跳转至：</td><td style=\"width:45px\">${JumpLink}</td></table></div>";
            if (!string.IsNullOrEmpty(this.TemplatePath))
            {
                //加载指定的模板
                defaultTemplate = System.IO.File.ReadAllText(SystemUtils.GetMapPath(this.TemplatePath), Encoding.UTF8);
            }

            defaultTemplate = defaultTemplate.Replace("${TotalRecord}", this.TotalRecord.ToString()).Replace("${PageSize}", PageSize.ToString()).Replace("${PageIndex}", PageIndex.ToString()).Replace("${TotalPage}", this.TotalPage.ToString());
            #endregion

            #region 显示首页，上一页

            if (this.PageIndex == 1)
            {
                defaultTemplate = defaultTemplate.Replace("${FirstPageLink}", "<a class='disabled' disabled='disabled'>" + this.FirstPageText + "</a>");
                defaultTemplate = defaultTemplate.Replace("${PrevPageLink}", "<a class='disabled' disabled='disabled'>" + this.PrevPageText + "</a>");
            }
            else
            {
                defaultTemplate = defaultTemplate.Replace("${FirstPageLink}", "<a title='首页' href=\"" + GetUrl("first") + "\">" + this.FirstPageText + "</a>");
                defaultTemplate = defaultTemplate.Replace("${PrevPageLink}", "<a title='上一页' href=\"" + GetUrl("prev") + "\">" + this.PrevPageText + "</a>");
            }
            #endregion

            #region 显示下标

            var builder = new StringBuilder();
            string showItem = string.Empty;
            int counter = 1;
            //显示最多10页下标
            foreach (int item in GetPages(10))
            {
                counter = item;
                showItem = item.ToString();

                if (!string.IsNullOrEmpty(this.SplitTag))
                    builder.Append("<" + SplitTag + " " + (item == this.PageIndex ? "class='active'" : "") + "><a href=\"" + GetUrl(item) + "\">" + showItem + "</a></" + this.SplitTag + ">");
                else
                    builder.Append("<a " + (item == this.PageIndex ? "class='active'" : "") + " href=\"" + GetUrl(item) + "\">" + showItem + "</a>");

                counter++;
            }

            //页面没有完全显示，比如超过10页，当前只显示1-10。那用...表示还有更多页
            if (counter < this.TotalPage)
            {
                if (!string.IsNullOrEmpty(this.SplitTag))
                    builder.Append("<" + SplitTag + "><a href=\"" + GetUrl(counter) + "\">...</a></" + this.SplitTag + ">");
                else
                    builder.Append("<a  href=\"" + GetUrl(counter) + "\">...</a>");
            }

            defaultTemplate = defaultTemplate.Replace("${PagerNums}", builder.ToString().Trim());

            #endregion

            #region  显示下一页，末页

            if (this.TotalPage <= 0 || this.PageIndex == this.TotalPage)
            {
                defaultTemplate = defaultTemplate.Replace("${NextPageLink}", "<a class='disabled' disabled='disabled'>" + this.NextPageText + "</a>");
                defaultTemplate = defaultTemplate.Replace("${EndPageLink}", "<a class='disabled' disabled='disabled'>" + this.EndPageText + "</a>");
            }
            else
            {
                defaultTemplate = defaultTemplate.Replace("${NextPageLink}", "<a title='下一页' href=\"" + GetUrl("next") + "\">" + this.NextPageText + "</a>");
                defaultTemplate = defaultTemplate.Replace("${EndPageLink}", "<a title='尾页' href=\"" + GetUrl("last") + "\">" + this.EndPageText + "</a>");
            }

            #endregion

            #region 显示跳转至
            defaultTemplate = defaultTemplate.Replace("${JumpLink}", "<input name=\"" + SinGooBase.Token + "\" type=\"text\" value=\"\" title=\"按回车跳转\" style=\"width:30px;\" />");
            #endregion

            return defaultTemplate;
        }

        #endregion
    }
}
