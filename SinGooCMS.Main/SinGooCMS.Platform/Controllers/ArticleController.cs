using System;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.MVCBase;
using SinGooCMS.MVCBase.Filter;
using SinGooCMS.Domain;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform
{
    [TypeFilter(typeof(StaticFileHandlerFilterAttribute))]
    public class ArticleController : UIPageBase
    {
        private readonly ICMSContent cms;
        private readonly INodeRepository nodeRepository;
        private readonly IContentRepository contentRepository;
        private readonly IUser user;

        public ArticleController(
            ICMSContent _cms,
            INodeRepository _nodeRepository,
            IContentRepository _contentRepository,
            IUser _user
            )
        {
            this.cms = _cms;
            this.nodeRepository = _nodeRepository;
            this.contentRepository = _contentRepository;
            this.user = _user;            
        }

        #region 文章信息

        [HttpGet]
        public async Task<IActionResult> Index(string UrlRewriteName, int? Id, int? PageIndex)
        {
            /*
             * 当有id有值时，读取的是内容详情
             * 否则读取的是栏目信息，UrlRewriteName 为栏目的标识 NodeIdentifier
             * 
             * 栏目综合页(/article/news) -> 栏目列表页(/article/new/1) -> 文章详情页(/article/detail/1)
             * 
             */

            if ((Id ?? 0) > 0)
                return await ViewDetail(await cms.GetContent(Id ?? 0));
            else
                return string.Compare(UrlRewriteName, "list", true) == 0
                    ? await ViewList(cms.GetNode(UrlRewriteName), PageIndex ?? 1)
                    : await ViewNode(cms.GetNode(UrlRewriteName), PageIndex ?? 1);
        }

        #endregion        

        #region 读取文章栏目和详情

        #region 栏目综合页

        private async Task<IActionResult> ViewNode(NodeInfo currNode, int pageIndex = 1) =>
            await ViewWithPager(currNode, "index", pageIndex);

        #endregion

        #region 栏目列表页

        private async Task<IActionResult> ViewList(NodeInfo currNode, int pageIndex = 1) =>
            await ViewWithPager(currNode, "list", pageIndex);

        private async Task<IActionResult> ViewWithPager(NodeInfo currNode, string type, int pageIndex = 1)
        {
            Func<Task<IActionResult>> ViewTemplate = async () =>
            {
                //搜索关键字
                ViewBag.seokey = !currNode.SeoKey.IsNullOrEmpty()
                                 ? currNode.SeoKey + "," + Context.SiteConfig.SEOKey
                                 : currNode.NodeName + "," + Context.SiteConfig.SEOKey;
                //搜索描述
                ViewBag.seodesc = !currNode.SeoDescription.IsNullOrEmpty()
                                 ? currNode.SeoDescription
                                 : Context.SiteConfig.SEODescription;

                #region 小应用

                /*
                * 小应用 
                * 1）查找当前栏目的上级栏目.
                */
                var parentNode = currNode.ParentNode;
                if (parentNode == null) parentNode = currNode; //没有上级，就是自己
                else if (Language.Contain(parentNode.NodeIdentifier)) parentNode = currNode; //上级栏目是多语种 多种语参见：/config/language.config
                ViewBag.parentnode = parentNode;

                /*
                 * 小应用 
                 * 2）获取栏目的单页文章。
                 * 当栏目拥有子栏目且没有任何文章时。默认显示第一个子栏目的文章
                 */
                var defCont = await cms.GetSingleCont(currNode.AutoID);
                if (defCont == null)
                {
                    //当前没有默认内容，查找第一个子栏目的默认文章
                    var childs = cms.GetChildNodes(currNode.AutoID);
                    defCont = childs != null && childs.Count() > 0 ? await cms.GetSingleCont(childs.Take(1).FirstOrDefault().AutoID) : null;
                }

                ViewBag.defcont = defCont;

                #endregion

                //分页栏
                var pager = cms.GetPager((await cms.GetCount($" NodeID in ({currNode.ChildList}) and Status={(int)ContStatus.Normal} ")), pageIndex, currNode.ItemPageSize, (Context.SiteConfig.BrowseType == BrowseType.HtmlRewrite.ToString() ? $"/article/{currNode.NodeIdentifier}/$page.html" : $"/article/{currNode.NodeIdentifier}/$page"));
                ViewBag.pager = new MVCPager(pager.UrlPattern, pager.TotalRecord, pager.PageIndex, (currNode.ItemPageSize < 1 ? Context.SiteConfig.GlobalPageSize : currNode.ItemPageSize));
                //视图模板
                string tmpl = type == "index" ? currNode.NodeSetting.TemplateOfNodeIndex : currNode.NodeSetting.TemplateOfNodeList;
                return ViewStatic(tmpl, currNode); //指定的模板，模板路径不会受客户端语种的影响
            };

            if (currNode != null)
            {
                ViewBag.currnode = currNode;

                //栏目要求会员登录才能浏览
                if (currNode.NodeSetting.NeedLogin)
                {
                    if (user.LoginUser.Value == null)
                        return new JumpUrlResult(Context.GetCaption("CMS_NodeNeedLoginToView"), $"/user/login?returnurl={currNode.NodeUrl}"); //需要登录
                    else if (!currNode.NodeSetting.EnableViewUGroups.ToIntArray().Contains(user.LoginUser.Value.GroupID))
                        return new ShowMsgResult(Context.GetCaption("CMS_TheUserGroupAccessDenied"));
                    else if (!currNode.NodeSetting.EnableViewULevel.ToIntArray().Contains(user.LoginUser.Value.LevelID))
                        return new ShowMsgResult(Context.GetCaption("CMS_TheUserLevelAccessDenied"));
                    else
                        return await ViewTemplate();
                }
                else
                    return await ViewTemplate();
            }
            else
            {
                return new ShowMsgResult(Context.GetCaption("CMS_NodeNotExist")); //栏目不存在
                //return Content(Context.GetCaption("CMS_NodeNotExist")); //栏目不存在
            }
        }

        #endregion        

        #region 文章详情页

        private async Task<IActionResult> ViewDetail(ContentInfo currCont)
        {
            /*
             * 关于自定义参数
             * 网址如 http://www.sintoo.top/article/detail/1?param=123
             * 获取方法 string param = WebUtils.GetQueryString("param");
             */

            if (currCont != null)
            {
                var currNode = cms.GetNode(currCont.NodeID);
                await contentRepository.UpdateHits(currCont.AutoID); //更新浏览量                

                //搜索关键字
                ViewBag.seokey = !string.IsNullOrEmpty(currCont.SeoKey)
                                ? currCont.SeoKey + "," + Context.SiteConfig.SEOKey
                                : currCont.Title + "," + Context.SiteConfig.SEOKey;
                //搜索描述
                ViewBag.seodesc = !string.IsNullOrEmpty(currCont.SeoDescription)
                                ? currCont.SeoDescription
                                : Context.SiteConfig.SEODescription;

                ViewBag.currnode = currNode; //全局GlobalFilterAttribute有定义ViewBag.CurrNode，不要冲突
                ViewBag.currcont = currCont;

                #region 小应用

                /*
                * 小应用 
                * 1）查找当前栏目的上级栏目.
                */
                var parentNode = currNode.ParentNode;
                if (parentNode == null) parentNode = currNode; //没有上级，就是自己
                else if (Language.Contain(parentNode.NodeIdentifier)) parentNode = currNode; //上级栏目是多语种 多种语参见：/config/language.config

                ViewBag.parentnode = parentNode;

                #endregion

                //所属的栏目要求会员登录才能浏览
                if (currNode != null && currNode.NodeSetting.NeedLogin)
                {
                    if (user.LoginUser.Value == null)
                        return new JumpUrlResult(Context.GetCaption("CMS_NodeNeedLoginToView"), $"/user/login?returnurl={currCont.ContentUrl}"); //需要登录
                    else if (!currNode.NodeSetting.EnableViewUGroups.ToIntArray().Contains(user.LoginUser.Value.GroupID))
                        return new ShowMsgResult(Context.GetCaption("CMS_TheUserGroupAccessDenied"));
                    else if (!currNode.NodeSetting.EnableViewULevel.ToIntArray().Contains(user.LoginUser.Value.LevelID))
                        return new ShowMsgResult(Context.GetCaption("CMS_TheUserLevelAccessDenied"));
                    else
                        return ViewStatic(currCont.TemplateFile, currCont);
                }
                else
                    return ViewStatic(currCont.TemplateFile, currCont);
            }
            else
            {
                return new ShowMsgResult(Context.GetCaption("CMS_ContentNotExist")); //内容不存在
                //return Content(Context.GetCaption("CMS_ContentNotExist"));
            }
        }

        #endregion

        #endregion

        #region 搜索列表页

        public async Task<IActionResult> Search()
        {
            var node = cms.GetNode(WebUtils.GetQueryVal<int>("nid")); //指定了搜索的栏目
            string strUrlPattern = "/article/search?key=" + searchKey.AsEncodeUrl();
            string strCondition = $" Title LIKE '%{StringUtils.ChkSQL(searchKey)}%' ";

            if (node != null)
            {
                strUrlPattern += "&nid=" + node.AutoID;
                strCondition += $" AND NodeID in ({node.ChildList}) ";
            }

            strUrlPattern += "&page=$page";
            base.pager.PageSize = ConfigUtils.GetAppSetting<int>("SearchPageSize", 10);
            var pager = cms.GetPager(await cms.GetCount(strCondition), base.pager.PageIndex, base.pager.PageSize, strUrlPattern);
            var searchConts = await cms.GetContents(0, strCondition, "Sort asc,AutoID desc", base.pager.PageIndex, base.pager.PageSize);
            ViewBag.currnode = node;
            ViewBag.searchkey = searchKey;
            ViewBag.pager = pager;

            return ViewStatic("搜索.cshtml", searchConts);
        }

        #endregion        
    }
}