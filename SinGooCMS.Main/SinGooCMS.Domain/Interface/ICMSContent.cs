using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    public interface ICMSContent : IDependency
    {
        #region 栏目操作

        /// <summary>
        /// 读取直系子栏目
        /// </summary>
        /// <param name="parentID">上级栏目，0表示取顶级栏目</param>
        /// <param name="showOnMenu">是否主菜单，主菜单将显示在导航中</param>
        /// <returns></returns>
        IEnumerable<NodeInfo> GetChildNodes(int parentID, bool? showOnMenu = null);
        /// <summary>
        /// 读取直系子栏目
        /// </summary>
        /// <param name="parentIdentifier"></param>
        /// <param name="showOnMenu">是否主菜单，主菜单将显示在导航中</param>
        /// <returns></returns>
        IEnumerable<NodeInfo> GetChildNodes(string parentIdentifier = null, bool? showOnMenu = null);

        /// <summary>
        /// 读取所有子栏目（包括子栏目的子栏目）
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="showOnMenu">是否主菜单，主菜单将显示在导航中</param>
        /// <returns></returns>
        IEnumerable<NodeInfo> GetAllChildNodes(int parentID, bool? showOnMenu = null);
        /// <summary>
        /// 读取所有子栏目（包括子栏目的子栏目）
        /// </summary>
        /// <param name="parentIdentifier"></param>
        /// <param name="showOnMenu">是否主菜单，主菜单将显示在导航中</param>
        /// <returns></returns>
        IEnumerable<NodeInfo> GetAllChildNodes(string parentIdentifier = null, bool? showOnMenu = null);

        /// <summary>
        /// 读取指定的多个栏目
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IEnumerable<NodeInfo> GetNodes(string ids);
        /// <summary>
        /// 读取栏目分页信息
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="sort"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<PagerModel<IEnumerable<NodeInfo>>> GetNodes(string condition, string sort, int pageIndex, int pageSize);
        /// <summary>
        /// 读取栏目数量
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<int> GetNodeCount(string condition);

        /// <summary>
        /// 读取栏目导航
        /// </summary>
        /// <param name="nodeID"></param>
        /// <returns></returns>
        IEnumerable<NodeInfo> GetNodeNav(int nodeID);
        /// <summary>
        /// 读取栏目导航
        /// </summary>
        /// <param name="nodeIdentifier"></param>
        /// <returns></returns>
        IEnumerable<NodeInfo> GetNodeNav(string nodeIdentifier);

        /// <summary>
        /// 读取栏目（缓存的栏目）
        /// </summary>
        /// <param name="nodeID"></param>
        /// <returns></returns>
        NodeInfo GetNode(int nodeID);
        /// <summary>
        /// 读取栏目（缓存的栏目）
        /// </summary>
        /// <param name="nodeIdentifier"></param>
        /// <returns></returns>
        NodeInfo GetNode(string nodeIdentifier);

        #endregion

        #region 内容操作        

        #region 内容列表/分页相关

        /// <summary>
        /// 读取置顶内容
        /// </summary>
        /// <param name="topNum"></param>
        /// <returns></returns>
        Task<IEnumerable<ContentBaseInfo>> GetTops(int topNum = 10);
        /// <summary>
        /// 读取推荐内容
        /// </summary>
        /// <param name="topNum"></param>
        /// <returns></returns>
        Task<IEnumerable<ContentBaseInfo>> GetRecommends(int topNum = 10);
        /// <summary>
        /// 读取最新内容
        /// </summary>
        /// <param name="topNum"></param>
        /// <returns></returns>
        Task<IEnumerable<ContentBaseInfo>> GetNewests(int topNum = 10);

        /// <summary>
        /// 读取栏目的前N条文章内容（按排序号顺序）
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="getNum"></param>
        /// <returns></returns>
        Task<IEnumerable<ContentBaseInfo>> GetContents(int nodeId, int getNum);
        /// <summary>
        /// 读取栏目的前N条文章内容
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="condition"></param>
        /// <param name="sort"></param>
        /// <param name="getNum"></param>
        /// <returns></returns>
        Task<IEnumerable<ContentBaseInfo>> GetContents(int nodeId, string condition, string sort, int getNum);
        /// <summary>
        /// 读取分页内容信息
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<ContentBaseInfo>> GetContents(int nodeId, int pageIndex, int pageSize);
        /// <summary>
        /// 读取分页内容信息
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="condition"></param>
        /// <param name="sort"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<ContentBaseInfo>> GetContents(int nodeId, string condition, string sort, int pageIndex, int pageSize);

        /// <summary>
        /// 读取栏目的前N条文章内容（按排序号顺序）
        /// </summary>
        /// <param name="nodeIdentifier"></param>
        /// <param name="getNum"></param>
        /// <returns></returns>
        Task<IEnumerable<ContentBaseInfo>> GetContents(string nodeIdentifier, int getNum);
        /// <summary>
        /// 读取栏目的前N条文章内容
        /// </summary>
        /// <param name="nodeIdentifier"></param>
        /// <param name="condition"></param>
        /// <param name="sort"></param>
        /// <param name="getNum"></param>
        /// <returns></returns>
        Task<IEnumerable<ContentBaseInfo>> GetContents(string nodeIdentifier, string condition, string sort, int getNum);
        /// <summary>
        /// 读取分页内容信息
        /// </summary>
        /// <param name="nodeIdentifier"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<ContentBaseInfo>> GetContents(string nodeIdentifier, int pageIndex, int pageSize);
        /// <summary>
        /// 读取分页内容信息
        /// </summary>
        /// <param name="nodeIdentifier"></param>
        /// <param name="condition"></param>
        /// <param name="sort"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<ContentBaseInfo>> GetContents(string nodeIdentifier, string condition, string sort, int pageIndex, int pageSize);

        /// <summary>
        /// 读取内容记录数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<int> GetCount(string condition);

        #endregion

        Task<ContentInfo> GetContent(int contId);
        /// <summary>
        /// 读取栏目的单页文章
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        Task<ContentInfo> GetSingleCont(int nodeId);
        /// <summary>
        /// 读取栏目的单页文章
        /// </summary>
        /// <param name="nodeIdentifier"></param>
        /// <returns></returns>
        Task<ContentInfo> GetSingleCont(string nodeIdentifier);

        /// <summary>
        /// 上一篇
        /// </summary>
        /// <param name="contId"></param>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        Task<ContentBaseInfo> GetPrevContent(int contId, int nodeId = 0);
        /// <summary>
        /// 下一篇
        /// </summary>
        /// <param name="contId"></param>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        Task<ContentBaseInfo> GetNextContent(int contId, int nodeId = 0);

        /// <summary>
        /// 读取模型字段列表
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="contId"></param>
        /// <returns></returns>
        Task<IEnumerable<ContFieldInfo>> GetContentFields(int modelId, int contId = 0);

        /// <summary>
        /// 文章的评论数（已经审核可显示的）
        /// </summary>
        /// <param name="contId"></param>
        /// <returns></returns>
        Task<int> GetCommentCount(int contId);
        /// <summary>
        /// 读取评论信息
        /// </summary>
        /// <param name="contId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<PagerModel<IEnumerable<CommentInfo>>> GetComments(int contId, int pageIndex, int pageSize = 10);

        #endregion

        #region 广告标签等

        /// <summary>
        /// 读取所有广告位
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AdPlaceInfo>> GetAdPlaces();
        /// <summary>
        /// 读取广告位信息
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        Task<AdPlaceInfo> GetAdPlace(int placeId);

        /// <summary>
        /// 读取广告位所属的所有有效（审核的且在有效期内的）广告
        /// </summary>
        /// <param name="placeId"></param>
        /// <returns></returns>
        Task<IEnumerable<AdsInfo>> GetAds(int placeId);
        /// <summary>
        /// 读取广告信息
        /// </summary>
        /// <param name="adId"></param>
        /// <returns></returns>
        Task<AdsInfo> GetAd(int adId);

        /// <summary>
        /// 读取友情链接
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<LinksInfo>> GetFriendLinks();

        /// <summary>
        /// 读取标签列表
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TagsInfo>> GetTags();
        /// <summary>
        /// 读取标签
        /// </summary>
        /// <param name="intTagID"></param>
        /// <returns></returns>
        Task<TagsInfo> GetTag(int intTagID);

        /// <summary>
        /// 读取附件信息
        /// </summary>
        /// <param name="strAttachmentIDs"></param>
        /// <returns></returns>
        Task<IEnumerable<AttachmentInfo>> GetAttachments(string strAttachmentIDs);

        #endregion

        #region 字典

        /// <summary>
        /// 读取字典信息（缓存的）
        /// </summary>
        /// <param name="dictId"></param>
        /// <returns></returns>
        DictsInfo GetDict(int dictId);
        /// <summary>
        /// 读取字典信息（缓存的）
        /// </summary>
        /// <param name="dictName"></param>
        /// <returns></returns>
        DictsInfo GetDict(string dictName);

        /// <summary>
        /// 读取字典详情（缓存的）
        /// </summary>
        /// <param name="dictId"></param>
        /// <returns></returns>
        IEnumerable<DictItemInfo> GetDictItems(int dictId);
        /// <summary>
        /// 读取字典详情（缓存的）
        /// </summary>
        /// <param name="dictName"></param>
        /// <returns></returns>
        IEnumerable<DictItemInfo> GetDictItems(string dictName);

        #endregion       

        #region 会员

        /// <summary>
        /// 读取会员组字段列表
        /// </summary>
        /// <param name="userGroupID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        Task<IEnumerable<UserFieldInfo>> GetUserFields(int userGroupID, int userID = 0);

        #endregion

        #region 分页组件

        /// <summary>
        /// 分页组件
        /// </summary>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="pageIndex">当前页号</param>
        /// <param name="pageSize">分页记录数</param>
        /// <param name="urlPattern">将替换分页占位符$page</param>
        /// <returns></returns>
        Pager GetPager(int totalRecord, int pageIndex, int pageSize, string urlPattern);

        #endregion

        #region 字符串处理

        /// <summary>
        /// 截取部分文本
        /// </summary>
        /// <param name="strSource">源文本</param>
        /// <param name="intLength">截取长度</param>
        /// <param name="strAppend">附加内容，如...</param>
        /// <returns></returns>
        string Cut(string strSource, int intLength, string strAppend = "");

        /// <summary>
        /// 日期格式化
        /// </summary>
        /// <param name="date"></param>
        /// <param name="formatPattern"></param>
        /// <returns></returns>
        string FormatDate(string date, string formatPattern = "yyyy-MM-dd");

        /// <summary>
        /// 补0
        /// </summary>
        /// <param name="num"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        string FormatNum(int num, int length);

        #endregion

        #region 加密解密

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        string DesEncode(string strSource);
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        string DesDecode(string strSource);

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        string MD5Encode(string strSource);

        #endregion

        #region Helper

        string Query(string key);
        int QueryInt(string key, int defValue = 0);
        bool QueryBool(string key, bool defValue = false);
        float QueryFloat(string key, float defValue = 0);
        decimal QueryDecimal(string key, decimal defValue = 0);
        DateTime QueryDatetime(string key);

        /// <summary>
        /// 清除HTML格式
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        string RemoveHtml(string strSource);

        /// <summary>
        /// 获取单位是KB的文件长度
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        string GetFileSize(string length);

        #endregion  
    }
}