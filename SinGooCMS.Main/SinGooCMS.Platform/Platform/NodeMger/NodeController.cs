using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;
using SinGooCMS.MVCBase.Extension;

namespace SinGooCMS.Platform.NodeMger
{
    public class NodeController : ManagerPageBase
    {
        const string MODULECODE = "NodeMger";
        private readonly INodeRepository nodeRepository;
        private readonly IContModelRepository contModelRepository;
        private readonly IContFieldRepository contFieldRepository;
        private readonly IContentRepository contentRepository;
        private readonly IUserGroupRepository userGroupRepository;
        private readonly IUserLevelRepository userLevelRepository;
        private readonly IPublisher publisher;

        public NodeController(
            INodeRepository _nodeRepository,
            IContModelRepository _contModelRepository,
            IContFieldRepository _contFieldRepository,
            IContentRepository _contentRepository,
            IUserGroupRepository _userGroupRepository,
            IUserLevelRepository _userLevelRepository,
            IPublisher _publisher)
        {
            this.nodeRepository = _nodeRepository;
            this.contentRepository = _contentRepository;
            this.contFieldRepository = _contFieldRepository;
            this.contModelRepository = _contModelRepository;
            this.userGroupRepository = _userGroupRepository;
            this.userLevelRepository = _userLevelRepository;
            this.publisher = _publisher;
        }

        #region 首页

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("NodeMger/Index.cshtml");
        }

        #region 获取栏目树

        [HttpPost]
        [Permission(MODULECODE)]
        public string NodeTree()
        {
            int intParentID = WebUtils.GetFormVal<int>("id");
            var lstNode = nodeRepository.GetCacheChildNodes(intParentID);
            var builder = new StringBuilder();
            if (lstNode != null && lstNode.Count() > 0)
            {
                foreach (var item in lstNode)
                {
                    builder.Append("{id:'" + item.AutoID.ToString() + "',name:'" + item.NodeName + "',isParent:" + (item.ChildCount > 0 ? "true" : "false") + (item.ChildCount > 0 ? "" : ",'iconSkin':'leaf'") + ",'click':\"AppendVal(" + item.AutoID + ",'" + item.NodeName + "')\"},");
                }
            }

            return "[" + builder.ToString().TrimEnd(',') + "]";
        }

        #endregion

        #endregion

        NodeInfo nodeParent = null; //上级栏目

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await nodeRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            var result = await nodeRepository.DeleteNode(delEntity);
            if (result.ret == ResultType.Success)
            {
                //清除页面缓存
                foreach (var item in CacheStore.CacheNodes.Where(p => delEntity.ParentPath.ToIntArray().Contains(p.AutoID)))
                    publisher.Init(item).Delete();
                foreach (var item in CacheStore.CacheNodes.Where(p => delEntity.ChildList.ToIntArray().Contains(p.AutoID)))
                    publisher.Init(item).Delete();

                //写入日志
                await LogService.AddEvent("删除栏目[" + delEntity.NodeName + "]成功");
                return OperateResult.successLoadJson;
            }
            else
                return result.ToOperateResultJson();
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Import)]
        public async Task<string> ImportNode()
        {            
            if (Request.Form.Files == null)
                return OperateResult.FailJson("File_SelectTheUpFile", "请选择并上传文件");            
            else
            {
                var postFile = Request.Form.Files[0]; //上传的xml文件
                if (Path.GetExtension(postFile.FileName).ToLower() != ".xml")
                    return OperateResult.FailJson("File_FileExtFormatNotSupported", "文件格式不支持");

                //保存xml文件
                string xmlFileName = SinGooBase.GetMapPath(FileUtils.Combine(SinGooBase.ImportFolder, StringUtils.GetNewFileName() + ".xml"));
                postFile.SaveAs(xmlFileName);

                //读取并导入数据
                await nodeRepository.Import(await FileUtils.ReadFileContentAsync(xmlFileName), Context.CurrLang, Manager.AccountName);

                publisher.DeleteNodes();
                publisher.DeleteArticles();

                await LogService.AddEvent("从XML文件导入栏目成功");
                return OperateResult.successLoadJson;
            }
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Export)]
        public async Task<string> ExportNode()
        {
            var filePath = await nodeRepository.ExportReturnFilePath();
            if (!filePath.IsNullOrEmpty())
            {
                string url = "/Include/Download?file=" + SinGooBase.DesEncode(filePath);
                return OperateResult.SuccessJson("OperationSuccess", "操作成功", url);
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.Modify)]
        public async Task<string> SetSort()
        {
            Dictionary<int, int> dictIDAndSort = GetSortDict();
            if (dictIDAndSort.Count > 0 && await nodeRepository.UpdateNodeSort(dictIDAndSort))
            {
                publisher.DeleteNodes();
                await LogService.AddEvent("设置栏目排序成功");
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
            ViewBag.ParentID = WebUtils.GetQueryVal<int>("ParentID");
            return View("NodeMger/NodeList.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            nodeParent = await nodeRepository.FindAsync(WebUtils.GetQueryVal<int>("ParentID"));
            base.sort = "Depth asc,Sort asc,AutoID desc";
            var pageModel = await nodeRepository.GetPagerListAsync(GetCondition(), base.sort, pager.PageIndex, pager.PageSize);
            var lstNew = from item in pageModel.PagerData
                         select new
                         {
                             item.AutoID,
                             item.NodeName,
                             item.NodeIdentifier,
                             item.ModelID,
                             contModelRepository.GetCacheModel(item.ModelID)?.ModelName,
                             item.Sort
                         };

            var dataJson = lstNew.ToJson();

            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            string pagerJson = new MVCPager(pager).PagerJson();
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":" + pagerJson + "}}";
        }
        private string GetCondition()
        {
            var builder = new StringBuilder("1=1");

            if (nodeParent != null)
                builder.Append($" AND (AutoID={nodeParent.AutoID} OR ParentID={nodeParent.AutoID}) "); //仅列出下级的栏目
            else
                builder.Append(" And ParentID=0 ");

            if (!searchKey.IsNullOrEmpty())
                builder.Append($" AND NodeName like '%{StringUtils.ChkSQL(searchKey)}%' ");

            return builder.ToString();
        }

        #endregion

        #endregion

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

        [HttpPost]
        [Permission(MODULECODE)]
        private async Task<string> Edit(bool isModify)
        {
            var entity = new NodeInfo();
            if (isModify)
                entity = await nodeRepository.FindAsync(OpID);

            entity.NodeName = WebUtils.GetFormString("TextBox1");
            entity.NodeIdentifier = WebUtils.GetFormString("TextBox2");
            entity.ModelID = WebUtils.GetFormVal<int>("DropDownList4");
            entity.NodeBanner = WebUtils.GetFormString("TextBox3");
            entity.NodeImage = WebUtils.GetFormString("TextBox5");
            entity.SeoKey = WebUtils.GetFormString("TextBox6");
            entity.SeoDescription = WebUtils.GetFormString("TextBox7");
            entity.Remark = WebUtils.GetFormString("NodeDesc");
            entity.ItemPageSize = (short)WebUtils.GetFormVal<int>("TextBox9");
            entity.IsShowOnMenu = WebUtils.GetFormString("CheckBox10") == "on";
            entity.IsShowOnNav = WebUtils.GetFormString("CheckBox11") == "on";
            entity.IsTop = WebUtils.GetFormString("CheckBox12") == "on";
            entity.IsRecommend = WebUtils.GetFormString("CheckBox13") == "on";
            entity.CustomLink = WebUtils.GetFormString("TextBox14");
            entity.Lang = Context.CurrLang;
            entity.Creator = Manager.AccountName;
            entity.AutoTimeStamp = DateTime.Now;

            #region 选项

            entity.Setting = new NodeSetting()
            {
                EnableAddInParent = WebUtils.GetFormString("CheckBox15") == "on",
                AllowComment = WebUtils.GetFormString("CheckBox16") == "on",
                NeedLogin = WebUtils.GetFormString("CheckBox17") == "on",
                EnableViewUGroups = WebUtils.GetFormString("CheckBoxList18"),
                EnableViewULevel = WebUtils.GetFormString("CheckBoxList19"),
                TemplateOfNodeIndex = WebUtils.GetFormString("TextBox20"),
                TemplateOfNodeList = WebUtils.GetFormString("TextBox21"),
                TemplateOfNodeContent = WebUtils.GetFormString("TextBox22")
            }.ToJson();

            #endregion

            if (entity.NodeName.IsNullOrEmpty() || entity.NodeIdentifier.IsNullOrEmpty())
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");

            if (!isModify)
            {
                var result = await nodeRepository.AddNode(entity, await nodeRepository.FindAsync(WebUtils.GetFormVal<int>("DropDownList3")));
                var operateResult = result.OpResult.ToOperateResult();
                if (operateResult.ret == ResultType.Success)
                {
                    //清除页面缓存
                    publisher.DeleteNodes();
                    publisher.DeleteArticles();

                    operateResult.url = "TabControl:栏目设置";
                    await LogService.AddEvent("添加栏目[" + entity.NodeName + "]成功");
                }                
                
                return operateResult.ToString();
            }
            if (isModify)
            {
                var result = await nodeRepository.UpdateNode(entity);
                var operateResult = result.ToOperateResult();
                if (result.ret == ResultType.Success)
                {
                    //清除页面缓存
                    publisher.DeleteNodes();
                    publisher.DeleteArticles();

                    operateResult.url = "TabControl:栏目设置";
                    await LogService.AddEvent("修改栏目[" + entity.NodeName + "]成功");
                }

                return operateResult.ToString();
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Edit()
        {
            //上级栏目
            var parentNodes = nodeRepository.GetNodeTree();
            var parents = from item in parentNodes
                          select new NodeInfo
                          {
                              AutoID = item.AutoID,
                              ParentID = item.ParentID,
                              NodeName = item.NodeName
                          };

            ViewBag.ParentNodes = parents;

            //内容模型
            ViewBag.ContModels = await contModelRepository.GetListAsync(100, "IsUsing=1");
            //会员组
            ViewBag.UserGroup = await userGroupRepository.GetListAsync(100);
            //会员等级
            ViewBag.UserLevel = await userLevelRepository.GetListAsync(100, "", "Integral asc");

            var node = new NodeInfo(); //添加默认的栏目
            if (IsEdit)
                node = await nodeRepository.FindAsync(OpID); //当前的编辑栏目
            else if (IsAdd && OpID > 0)
                node = ChildNodeInit(await nodeRepository.FindAsync(OpID)); //添加子栏目的初始化数据

            return View("NodeMger/ModifyNode.cshtml", node);
        }

        #region 子栏目默认设置
        private NodeInfo ChildNodeInit(NodeInfo nodeParent)
        {
            return nodeParent == null
                ? new NodeInfo()
                : new NodeInfo()
                {
                    ModelID = nodeParent.ModelID,
                    ParentID = nodeParent.AutoID,
                    ItemPageSize = nodeParent.ItemPageSize,
                    Setting = nodeParent.Setting
                };
        }
        #endregion

        #endregion

        #endregion        
    }
}