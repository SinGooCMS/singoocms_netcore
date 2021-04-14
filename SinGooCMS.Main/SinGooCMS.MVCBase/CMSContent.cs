using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.MVCBase
{
    /// <summary>
    /// CMS工具集合，主要用做视图工具
    /// </summary>
    public class CMSContent : ICMSContent
    {
        private readonly INodeRepository nodeRepository;
        private readonly IContentRepository contentRepository;
        private readonly IContFieldRepository contFieldRepository;
        private readonly ICommentRepository commentRepository;
        private readonly IAttachmentRepository attachmentRepository;
        private readonly ILinksRepository linksRepository;
        private readonly IAdPlaceRepository adPlaceRepository;
        private readonly IAdsRepository adsRepository;
        private readonly IDictsRepository dictsRepository;
        private readonly ITagsRepository tagsRepository;
        private readonly IUserFieldRepository userFieldRepository;

        public CMSContent(
            INodeRepository _nodeRepository,
            IContentRepository _contentRepository,
            IContFieldRepository _contFieldRepository,
            ICommentRepository _commentRepository,
            IAttachmentRepository _attachmentRepository,
            ILinksRepository _linksRepository,
            IAdPlaceRepository _adPlaceRepository,
            IAdsRepository _adsRepository,
            IDictsRepository _dictsRepository,
            ITagsRepository _tagsRepository,
            IUserFieldRepository _userFieldRepository
            )
        {
            this.nodeRepository = _nodeRepository;
            this.contentRepository = _contentRepository;
            this.contFieldRepository = _contFieldRepository;
            this.commentRepository = _commentRepository;
            this.attachmentRepository = _attachmentRepository;
            this.linksRepository = _linksRepository;
            this.adPlaceRepository = _adPlaceRepository;
            this.adsRepository = _adsRepository;
            this.dictsRepository = _dictsRepository;
            this.tagsRepository = _tagsRepository;
            this.userFieldRepository = _userFieldRepository;
        }

        #region 栏目操作

        public IEnumerable<NodeInfo> GetChildNodes(int parentID, bool? showOnMenu = null) =>
            nodeRepository.GetCacheChildNodes(parentID, showOnMenu);
        public IEnumerable<NodeInfo> GetChildNodes(string parentIdentifier = null, bool? showOnMenu = null) =>
            nodeRepository.GetCacheChildNodes(parentIdentifier, showOnMenu);

        public IEnumerable<NodeInfo> GetAllChildNodes(int parentID, bool? showOnMenu = null) =>
            nodeRepository.GetCacheAllChildNodes(parentID, showOnMenu);
        public IEnumerable<NodeInfo> GetAllChildNodes(string parentIdentifier = null, bool? showOnMenu = null) =>
            nodeRepository.GetCacheAllChildNodes(parentIdentifier, showOnMenu);

        public IEnumerable<NodeInfo> GetNodes(string ids) =>
            nodeRepository.GetCachedNodes(ids);

        public async Task<PagerModel<IEnumerable<NodeInfo>>> GetNodes(string condition, string sort, int pageIndex, int pageSize) =>
             await nodeRepository.GetPagerListAsync(condition, sort, pageIndex, pageSize);

        public async Task<int> GetNodeCount(string condition) => await nodeRepository.GetCountAsync(condition);

        public IEnumerable<NodeInfo> GetNodeNav(int nodeID)
        {
            var cacheNode = nodeRepository.GetCacheNode(nodeID);
            if (cacheNode != null)
            {
                return nodeRepository.GetNodeNavigate(cacheNode.ParentPath);
            }

            return null;
        }
        public IEnumerable<NodeInfo> GetNodeNav(string nodeIdentifier)
        {
            var cacheNode = nodeRepository.GetCacheNode(nodeIdentifier);
            if (cacheNode != null)
            {
                return nodeRepository.GetNodeNavigate(cacheNode.ParentPath);
            }

            return null;
        }

        public NodeInfo GetNode(int nodeID) => nodeRepository.GetCacheNodeFull(nodeID);
        public NodeInfo GetNode(string nodeIdentifier) => nodeRepository.GetCacheNodeFull(nodeIdentifier);

        #endregion

        #region 内容操作

        #region 内容分页相关

        public async Task<IEnumerable<ContentBaseInfo>> GetContents(int nodeId, int getNum = 10) =>
           await contentRepository.GetContentList(getNum, p => p.NodeID == nodeId);
        public async Task<IEnumerable<ContentBaseInfo>> GetContents(int nodeId, string condition, string sort, int getNum = 10) =>
           await GetContents(nodeId, condition, sort, 1, getNum);
        public async Task<IEnumerable<ContentBaseInfo>> GetContents(int nodeId, int pageIndex, int pageSize) =>
           await GetContents(nodeRepository.GetCacheNode(nodeId), string.Empty, string.Empty, pageIndex, pageSize);
        public async Task<IEnumerable<ContentBaseInfo>> GetContents(int nodeId, string condition, string sort, int pageIndex, int pageSize) =>
           await GetContents(nodeRepository.GetCacheNode(nodeId), condition, sort, pageIndex, pageSize);

        public async Task<IEnumerable<ContentBaseInfo>> GetContents(string nodeIdentifier, int getNum = 10)
        {
            var nodeId = nodeRepository.GetCacheNode(nodeIdentifier)?.AutoID ?? 0;
            return await contentRepository.GetContentList(getNum, p => p.NodeID == nodeId);
        }
        public async Task<IEnumerable<ContentBaseInfo>> GetContents(string nodeIdentifier, string condition, string sort, int getNum = 10) =>
           await GetContents(nodeIdentifier, condition, sort, 1, getNum);
        public async Task<IEnumerable<ContentBaseInfo>> GetContents(string nodeIdentifier, int pageIndex, int pageSize) =>
           await GetContents(nodeRepository.GetCacheNode(nodeIdentifier), string.Empty, string.Empty, pageIndex, pageSize);
        public async Task<IEnumerable<ContentBaseInfo>> GetContents(string nodeIdentifier, string condition, string sort, int pageIndex, int pageSize) =>
           await GetContents(nodeRepository.GetCacheNode(nodeIdentifier), condition, sort, pageIndex, pageSize);

        public async Task<IEnumerable<ContentBaseInfo>> GetTops(int topNum = 10) =>
            await contentRepository.GetContentList(topNum, p => p.IsTop);

        public async Task<IEnumerable<ContentBaseInfo>> GetRecommends(int topNum = 10) =>
            await contentRepository.GetContentList(topNum, p => p.IsRecommend);

        public async Task<IEnumerable<ContentBaseInfo>> GetNewests(int topNum = 10) =>
            await contentRepository.GetContentList(topNum, p => p.IsNew);

        private async Task<IEnumerable<ContentBaseInfo>> GetContents(NodeInfo node, string condition, string sort, int pageIndex, int pageSize) =>
            await contentRepository.GetContentList(node, condition, sort, pageIndex, pageSize, true);

        public async Task<int> GetCount(string condition) => await contentRepository.GetCountAsync(condition);

        #endregion

        public async Task<ContentInfo> GetContent(int contId) => await contentRepository.GetContentFull(contId);
        public async Task<ContentInfo> GetSingleCont(int nodeId) => await nodeRepository.GetSingleCont(nodeId);
        public async Task<ContentInfo> GetSingleCont(string nodeIdentifier) => await nodeRepository.GetSingleCont(nodeIdentifier);
        public async Task<ContentBaseInfo> GetPrevContent(int contId, int nodeId = 0) => await contentRepository.GetPrevCont(contId, nodeId);
        public async Task<ContentBaseInfo> GetNextContent(int contId, int nodeId = 0) => await contentRepository.GetNextCont(contId, nodeId);

        public async Task<IEnumerable<ContFieldInfo>> GetContentFields(int modelId, int contId = 0) =>
            await contFieldRepository.GetFieldsWithValue(modelId, contId);

        public async Task<int> GetCommentCount(int contId) =>
           await commentRepository.GetCountAsync(p => p.ContID == contId && p.IsAudit);
        public async Task<PagerModel<IEnumerable<CommentInfo>>> GetComments(int contId, int pageIndex, int pageSize = 10) =>
           await commentRepository.GetPagerList(contId, pageIndex, pageSize);

        #endregion

        #region 友情链接,广告

        public async Task<IEnumerable<AdPlaceInfo>> GetAdPlaces() =>
            await adPlaceRepository.GetListAsync(0, "", "Sort asc,AutoID desc");
        public async Task<AdPlaceInfo> GetAdPlace(int placeId) =>
           await adPlaceRepository.FindWithItemsAsync(placeId);

        public async Task<IEnumerable<AdsInfo>> GetAds(int placeId) =>
            await adsRepository.GetByPlaceID(placeId);
        public async Task<AdsInfo> GetAd(int adId) =>
            await adsRepository.FindAsync(adId);

        public async Task<IEnumerable<LinksInfo>> GetFriendLinks() => await linksRepository.GetListAsync();

        public async Task<IEnumerable<TagsInfo>> GetTags() => await tagsRepository.GetAllAsync();
        public async Task<TagsInfo> GetTag(int intTagID) => await tagsRepository.FindAsync(intTagID);

        public async Task<IEnumerable<AttachmentInfo>> GetAttachments(string strAttachmentIDs) =>
            await attachmentRepository.GetMutilAsync(strAttachmentIDs);

        #endregion

        #region 字典

        public DictsInfo GetDict(int dictId) => dictsRepository.GetCacheDict(dictId);
        public DictsInfo GetDict(string dictName) => dictsRepository.GetCacheDict(dictName);

        public IEnumerable<DictItemInfo> GetDictItems(int dictId) => this.GetDict(dictId)?.Items;
        public IEnumerable<DictItemInfo> GetDictItems(string dictName) => this.GetDict(dictName)?.Items;

        #endregion

        #region 会员

        public async Task<IEnumerable<UserFieldInfo>> GetUserFields(int userGroupID, int userID = 0) =>
            await userFieldRepository.GetFieldsWithValue(userGroupID, userID);

        #endregion

        #region 分页组件

        public Pager GetPager(int totalRecord, int pageIndex, int pageSize, string urlPattern)
        {
            if (pageSize < 1)
                pageSize = 10;

            if (pageIndex < 1)
                pageIndex = 1;

            var pager = new Pager(totalRecord, pageSize)
            {
                PageIndex = pageIndex,
                UrlPattern = urlPattern
            };

            pager.Calculate();
            return pager;
        }

        #endregion

        #region 字符串处理

        public string Cut(string strSource, int intLength, string strAppend = "") => StringUtils.Cut(strSource, intLength, strAppend);

        public string FormatDate(string date, string formatPattern = "yyyy-MM-dd") => date.ToDateTime().ToString(formatPattern);

        public string FormatNum(int num, int length)
        {
            string str = num.ToString();
            if (str.Length < length)
            {
                for (int i = 0; i < (length - str.Length); i++)
                {
                    str = "0" + str;
                }
            }
            return str;
        }

        #endregion

        #region 加密解密

        public string DesEncode(string strSource) => SinGooBase.DesEncode(strSource);
        public string DesDecode(string strSource) => SinGooBase.DesDecode(strSource);
        public string MD5Encode(string strSource) => DEncryptUtils.MD5Encrypt(strSource);

        #endregion

        #region helper

        public string Query(string key) => WebUtils.GetQueryString(key);
        public int QueryInt(string key, int defValue = 0) => WebUtils.GetQueryInt(key, defValue);
        public bool QueryBool(string key, bool defValue = false) => WebUtils.GetQueryBool(key, defValue);
        public float QueryFloat(string key, float defValue = 0) => WebUtils.GetQueryFloat(key, defValue);
        public decimal QueryDecimal(string key, decimal defValue = 0) => WebUtils.GetQueryDecimal(key, defValue);
        public DateTime QueryDatetime(string key) => WebUtils.GetQueryDatetime(key, new DateTime(1900, 1, 1));
        public string RemoveHtml(string strSource) => strSource.RemoveHtml();
        public string GetFileSize(string length) => FileUtils.GetFileSize(length.ToDecimal());

        #endregion
    }
}
