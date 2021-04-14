using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Models;
using SinGooCMS.Application;
using SinGooCMS.Utility;
using SinGooCMS.Control;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.ContMger
{
    public class ContentController : ManagerPageBase
    {
        const string MODULECODE = "ContentMger";
        private readonly INodeRepository nodeRepository;
        private readonly IContModelRepository contModelRepository;
        private readonly IContFieldRepository contFieldRepository;
        private readonly IContentRepository contentRepository;
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IDictItemRepository dictItemRepository;
        private readonly IMapper mapper;
        private readonly ICMSContent cms;
        private readonly IPublisher publisher;

        public ContentController(
            INodeRepository _nodeRepository,
            IContModelRepository _contModelRepository,
            IContFieldRepository _contFieldRepository,
            IContentRepository _contentRepository,
            IAttachmentRepository _attachmentRepository,
            IDictItemRepository _dictItemRepository,
            IMapper _mapper,
            ICMSContent _cms,
            IPublisher _publisher)
        {
            this.nodeRepository = _nodeRepository;
            this.contModelRepository = _contModelRepository;
            this.contFieldRepository = _contFieldRepository;
            this.contentRepository = _contentRepository;
            this.attachmentRepository = _attachmentRepository;
            this.dictItemRepository = _dictItemRepository;
            this.mapper = _mapper;
            this.cms = _cms;
            this.publisher = _publisher;
        }

        ContStatus ListType = EnumUtils.StringToEnum<ContStatus>(WebUtils.GetQueryString("ListType", "Normal")); //列表模式
        string SortType = WebUtils.GetQueryString("SortType", "default"); //排序方式
        string SortDirect = WebUtils.GetQueryString("SortDirect", "asc"); //排序方向

        #region 首页

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("ContMger/Index.cshtml", ListType);
        }

        #region 栏目树

        [HttpPost]
        [Permission(MODULECODE)]
        public async Task<string> NodeTree(IFormCollection form)
        {
            int status = WebUtils.GetFormVal<int>("status");
            var lstNode = nodeRepository.GetCacheChildNodes(WebUtils.GetFormVal<int>("id"));
            var builder = new StringBuilder();
            if (lstNode != null && lstNode.Count() > 0)
            {
                foreach (var item in lstNode)
                {
                    builder.Append("{id:'" + item.AutoID.ToString() + "',name:'" + item.NodeName + "',status:" + ((int)status).ToString() + ",contcount:'" + (await contentRepository.GetCountAsync(p => p.NodeID == item.AutoID && p.Status == status)) + "',isParent:" + (item.ChildCount > 0 ? "true" : "false") + (item.ChildCount > 0 ? "" : ",'iconSkin':'leaf'") + ",'click':\"AppendVal(" + item.AutoID + ",'" + item.NodeName + "')\"},");
                }
            }

            return "[" + builder.ToString().TrimEnd(',') + "]";
        }

        #endregion

        #endregion        

        int NodeID = WebUtils.GetQueryVal<int>("NodeID");
        NodeInfo CurrNode = null; //当前栏目       

        #region 列表

        #region Post相关操作

        #region 转移到新栏目

        [HttpPost]
        [Permission(MODULECODE, OperationType.MoveToNode)]
        public async Task<string> MoveToNode()
        {
            string strIDs = WebUtils.GetFormString("chk");
            if (string.IsNullOrEmpty(strIDs))
                return OperateResult.FailJson("NothingSelected", "没有选择任何项！");

            var targetNode = await nodeRepository.FindAsync(WebUtils.GetFormVal<int>("ddlMoveTo"));
            if (targetNode != null)
            {
                if (await contentRepository.MoveContent(strIDs, targetNode))
                {
                    foreach (var id in strIDs.ToIntArray())
                    {
                        //删除缓存页面
                        publisher.Init(id).Delete();
                    }

                    await LogService.AddEvent("移动内容(" + strIDs + ")到栏目[" + targetNode.NodeName + "]成功");
                    return OperateResult.successLoadJson;
                }
            }

            return OperateResult.failJson;
        }

        #endregion

        #region 各种删除

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await contentRepository.FindAsync(OpID);
            if (delEntity != null && await contentRepository.DelToRecycle(OpID.ToString()))
            {
                publisher.Init(delEntity.AutoID).Delete();  //删除缓存页面
                await LogService.AddEvent("移除内容[" + delEntity.Title + "]到回收站");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> DelThorough()
        {
            var delEntity = await contentRepository.FindAsync(OpID);
            if (delEntity != null)
            {
                await contentRepository.DelFromRecycle(OpID.ToString());
                publisher.Init(delEntity.AutoID).Delete(); //删除缓存页面

                await LogService.AddEvent("彻底删除内容[" + delEntity.Title + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> BatDelete()
        {
            string strIDs = WebUtils.GetFormString("ids");
            if (!string.IsNullOrEmpty(strIDs))
            {
                if (ListType.Equals(ContStatus.Recycle))
                {
                    await contentRepository.DelFromRecycle(strIDs); //从回收站里删除                      
                    await LogService.AddEvent("批量删除回收站里的内容");
                }
                else
                {
                    await contentRepository.DelToRecycle(strIDs);
                    await LogService.AddEvent("批量删除内容到回收站");
                }

                foreach (var id in strIDs.ToIntArray())
                {
                    //删除缓存页面
                    publisher.Init(id).Delete();
                }

                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> RecycleClear()
        {
            await contentRepository.ClearRecycle();
            await LogService.AddEvent("清空回收站");
            return OperateResult.successLoadJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Restore)]
        public async Task<string> Restore()
        {
            var cont = await contentRepository.FindAsync(OpID);
            if (cont == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除！");
            else
            {
                //设置正常状态
                if (await contentRepository.UpdateStatus(cont.AutoID.ToString(), ContStatus.Normal))
                {
                    publisher.Init(cont.AutoID).Delete(); //删除缓存页面

                    await LogService.AddEvent("还原内容[" + cont.Title + "]成功");
                    return OperateResult.successLoadJson;
                }
            }

            return OperateResult.failJson;
        }
        #endregion

        #region 置顶推荐最新

        [HttpPost]
        [Permission(MODULECODE, OperationType.SetTop)]
        public async Task<string> SetTop()
        {
            return await SetAttribute(ContMarkednessType.Top);
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.SetRecommend)]
        public async Task<string> SetRecommend()
        {
            return await SetAttribute(ContMarkednessType.Recommend);
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.SetNew)]
        public async Task<string> SetNew()
        {
            return await SetAttribute(ContMarkednessType.New);
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="attr"></param>
        /// <returns></returns>
        private async Task<string> SetAttribute(ContMarkednessType attr)
        {
            var cont = await contentRepository.FindAsync(OpID);
            if (cont == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除！");

            string logMsg = "";
            switch (attr)
            {
                case ContMarkednessType.Top:
                    cont.IsTop = !cont.IsTop;
                    logMsg = cont.IsTop ? "设置内容[" + cont.Title + "]为热门" : "取消内容[" + cont.Title + "]为热门";
                    break;
                case ContMarkednessType.Recommend:
                    cont.IsRecommend = !cont.IsRecommend;
                    logMsg = cont.IsRecommend ? "设置内容[" + cont.Title + "]为推荐" : "取消内容[" + cont.Title + "]为推荐";
                    break;
                case ContMarkednessType.New:
                    cont.IsNew = !cont.IsNew;
                    logMsg = cont.IsNew ? "设置内容[" + cont.Title + "]为最新" : "取消内容[" + cont.Title + "]为最新";
                    break;
            }

            //写入日志
            await LogService.AddEvent(logMsg);
            return await contentRepository.UpdateAsync(cont)
                ? OperateResult.successLoadJson
                : OperateResult.failJson;
        }
        #endregion

        #region 复制

        [HttpPost]
        [Permission(MODULECODE, OperationType.Add)]
        public async Task<string> ContentCopy()
        {
            var contSource = await contentRepository.FindAsync(OpID);
            if (contSource == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除！");

            if (await contentRepository.CopyToNewCont(contSource, Manager.AccountName) > 0)
            {
                await LogService.AddEvent($"复制内容[标题:{contSource.Title}]成功");
                return OperateResult.SuccessJson("PLFM_CopyContentOk", "复制内容成功，请在草稿箱中查看！");
            }

            return OperateResult.failJson;
        }

        #endregion

        #region 审核设置状态

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> AuditOk()
        {
            return await Audit(true);
        }
        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> AuditCancel()
        {
            return await Audit(false);
        }

        private async Task<string> Audit(bool flag)
        {
            string strIDs = WebUtils.GetFormString("chk");
            if (string.IsNullOrEmpty(strIDs))
                return OperateResult.FailJson("NothingSelected", "没有选择任何项");

            if (await contentRepository.UpdateStatus(strIDs, flag ? ContStatus.Normal : ContStatus.DraftBox))
            {
                publisher.Clear();
                await LogService.AddEvent(flag ? "批量审核文章[" + strIDs + "]成功" : "批量取消文章审核[" + strIDs + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }
        #endregion

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort()
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await contentRepository.UpdateSortAsync(dictIDAndSort))
            {
                publisher.Clear(); //删除缓存页面
                await LogService.AddEvent("设置文章排序成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        #endregion        

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult List()
        {
            ViewBag.ListType = ListType.ToString();
            ViewBag.NodeTree = nodeRepository.GetNodeTree(); //用于移动到
            ViewBag.NodeID = NodeID;

            return View("ContMger/ContentList.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            base.sort = "Sort asc,AutoID desc";
            if (SortType == "AddDate")
                base.sort = " AutoTimeStamp " + SortDirect;
            else if (SortType == "SortNumber")
                base.sort = " Sort " + SortDirect;
            else if (SortType == "Hit")
                base.sort = " Hit " + SortDirect;

            var pageModel = await contentRepository.GetContPagerListAsync(GetCondition(), base.sort, pager.PageIndex, pager.PageSize);
            var dataJson = pageModel.PagerData.ToJson();

            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;

            string pagerJson = new MVCPager(pager).PagerJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":" + pagerJson + "}}";
        }

        private string GetCondition()
        {
            CurrNode = nodeRepository.GetCacheNode(NodeID);
            var contStatus = EnumUtils.StringToEnum<ContStatus>(WebUtils.GetQueryString("DataJsonType", "Normal"));

            var builder = new StringBuilder("1=1");
            builder.Append(" AND Status=" + (int)contStatus); //审核状态
            if (NodeID > 0 && CurrNode != null)
                builder.Append(" AND NodeID in (" + CurrNode.ChildList + ") "); //列出所以下级栏目的内容            

            if (!string.IsNullOrEmpty(searchKey))
                builder.Append(" AND Title like '%" + StringUtils.ChkSQL(searchKey) + "%' ");

            return builder.ToString();
        }

        #endregion

        #endregion        

        ContentInfo contEdit = null; //文章信息
        ContModelInfo contModel = null; //文章的内容模型        
        IList<ContFieldInfo> fieldList = new List<ContFieldInfo>(); //文章的扩展字段

        #region 编辑

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Add)]
        public async Task<string> Add(IFormCollection form)
        {
            return await Edit(false);
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> Modify(IFormCollection form)
        {
            return await Edit(true);
        }

        private async Task<string> Edit(bool isModify)
        {
            var node = await nodeRepository.FindAsync(WebUtils.GetFormVal<int>("_nodeid"));
            var model = await contModelRepository.FindAsync(node?.ModelID ?? 0);

            if (node == null || model == null)
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            #region 增加/修改文章

            if (!isModify)
            {
                var result = await Add(node, model);
                var operateResult = result.OpResult.ToOperateResult();
                if (operateResult.ret == ResultType.Success)
                {
                    //删除缓存页面
                    publisher.Init(node.AutoID).Delete();
                    foreach (var item in CacheStore.CacheNodes.Where(p => node.ParentPath.ToIntArray().Contains(p.AutoID)))
                        publisher.Init(item).Delete();
                    foreach (var item in CacheStore.CacheNodes.Where(p => node.ChildList.ToIntArray().Contains(p.AutoID)))
                        publisher.Init(item).Delete();

                    operateResult.url = "TabControl:文章列表";
                    await LogService.AddEvent("添加内容[" + result.contReturn.Title + "]成功");
                }

                return operateResult.ToString();
            }

            if (isModify)
            {
                var contModify = await contentRepository.FindAsync(OpID);
                if (await Modify(contModify))
                {
                    //删除缓存页面
                    publisher.Init(contModify.AutoID).Delete();
                    publisher.Init(contModify.NodeID).Delete();
                    foreach (var item in CacheStore.CacheNodes.Where(p => node.ParentPath.ToIntArray().Contains(p.AutoID)))
                        publisher.Init(item).Delete();
                    foreach (var item in CacheStore.CacheNodes.Where(p => node.ChildList.ToIntArray().Contains(p.AutoID)))
                        publisher.Init(item).Delete();

                    await LogService.AddEvent("修改内容[" + contModify.Title + "]成功");
                    return OperateResult.SuccessJson("OperationSuccess", "操作成功", "TabControl:文章列表");
                }
            }

            #endregion

            return OperateResult.failJson;
        }

        #region 增加
        private async Task<(OperateResult OpResult, ContentInfo contReturn)> Add(NodeInfo node, ContModelInfo model)
        {
            var contAdd = new ContentInfo()
            {
                TemplateFile = WebUtils.GetFormString("TmplFile"), //指定的模板文件
                //LockPassword = WebUtils.GetFormString("lockpwd", string.Empty),
                Status = WebUtils.GetFormVal<byte>("isaudit"),
                Sort = WebUtils.GetFormVal<int>("Sort", 99999),
                Inputer = Manager.LoginAccount.AccountName
            };

            var fieldDicWithValues = await GetFieldDicWithValues(model.AutoID, contAdd.AutoID);
            int newContID = await contentRepository.AddContent(contAdd, node, model, fieldDicWithValues);
            contAdd.AutoID = newContID;

            return newContID > 0
                ? (OperateResult.success, contAdd)
                : (OperateResult.fail, contAdd);
        }

        private async Task<Dictionary<string, ContFieldInfo>> GetFieldDicWithValues(int modelId, int contId)
        {
            var dictionary = new Dictionary<string, ContFieldInfo>();
            var fieldList = await contFieldRepository.GetFieldsWithValue(modelId, contId); //文章内容正在使用的字段及其值
            foreach (var item in fieldList)
            {
                if (item.FieldType == FieldType.MultiPicture.ToString() || item.FieldType == FieldType.MultiFile.ToString())
                {
                    //多图多文件不能直接读取值。需要先存储到读取ID串 desc_Attachment file_Attachment
                    var fjDesc = (List<string>)WebUtils.GetFormVals<string>("desc_" + item.FieldName);
                    var fjFilePath = (List<string>)WebUtils.GetFormVals<string>("file_" + item.FieldName);
                    item.Value = fjFilePath != null && fjFilePath.Count > 0
                        ? await attachmentRepository.AddRange(fjFilePath, fjDesc)
                        : string.Empty;
                }
                else
                    item.Value = System.Web.HttpUtility.HtmlDecode(WebUtils.GetFormString(item.FieldName, string.Empty)); //取值

                dictionary.Add(item.FieldName, item);
            }

            return dictionary;
        }
        #endregion

        #region 修改

        private async Task<bool> Modify(ContentInfo contModify)
        {
            var fieldDicWithValues = await GetFieldDicWithValues(contModify.ModelID, contModify.AutoID);
            contModify.TemplateFile = WebUtils.GetFormString("TmplFile"); //更新模板文件
            contModify.LockPassword = WebUtils.GetFormString("lockpwd");
            contModify.Sort = WebUtils.GetFormVal<int>("Sort");
            contModify.Status = (byte)WebUtils.GetFormVal<int>("isaudit");
            return await contentRepository.UpdateContent(contModify, fieldDicWithValues);
        }

        #endregion

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Edit()
        {
            CurrNode = await nodeRepository.FindAsync(NodeID); //栏目
            contEdit = await contentRepository.FindAsync(OpID) ?? new ContentInfo();//内容

            //保证一定有栏目
            if (base.ParamAction == "Add" && NodeID == 0)
                CurrNode = nodeRepository.GetCacheDefultNode(); //添加内容时，没有选择栏目ID，默认第一个栏目
            else if (base.ParamAction == "Modify")
                CurrNode = await nodeRepository.FindAsync(contEdit.NodeID);

            contModel = contModelRepository.GetCacheModel(CurrNode.ModelID);//模型
            if (base.ParamAction == "Modify")
                contModel = contModelRepository.GetCacheModel(contEdit.ModelID); //已有的内容模型不变            

            //栏目导航
            var lstNodeNav = cms.GetNodeNav(CurrNode.AutoID);
            var builder = new StringBuilder();
            if (lstNodeNav != null && lstNodeNav.Count() > 0)
            {
                foreach (NodeInfo item in lstNodeNav)
                {
                    builder.Append(item.NodeName + " » "); //食品 » 饼干蛋糕
                }
            }
            builder.Append(CurrNode.NodeName);
            ViewBag.NodeNavigate = builder.ToString(); //栏目导航 

            var fieldList = await contFieldRepository.GetFieldsWithValue(contModel.AutoID, OpID);
            ViewBag.FieldList = GetFieldList(fieldList); //生成html控件
            ViewBag.CurrNode = CurrNode;
            return View("ContMger/ModifyCont.cshtml", contEdit);
        }

        private IList<IFieldControl> GetFieldList(IEnumerable<ContFieldInfo> fields)
        {
            var lst = new List<IFieldControl>();
            foreach (var item in fields)
            {
                IFieldControl control = Htmler.Create(item.FieldType, new object[] { Context, attachmentRepository, dictItemRepository });
                mapper.Map(item, control);
                lst.Add(control);
            }
            return lst;
        }
        #endregion

        #endregion
    }
}