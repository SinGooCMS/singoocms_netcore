using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SinGooCMS.Application;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.NodeMger
{
    public class NodeMoveController : ManagerPageBase
    {
        const string MODULECODE = "NodeMger";
        private readonly INodeRepository nodeRepository;
        private readonly IPublisher publisher;

        public NodeMoveController(INodeRepository _nodeRepository, IPublisher _publisher)
        {
            this.nodeRepository = _nodeRepository;
            this.publisher = _publisher;
        }

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.NodeMove)]
        public async Task<string> Index(IFormCollection form)
        {
            var nodeSource = await nodeRepository.FindAsync(WebUtils.GetFormVal<int>("lbSourceNode"));
            var nodeTarget = await nodeRepository.FindAsync(WebUtils.GetFormVal<int>("lbTargetNode", -1));

            var result = await nodeRepository.NodeMove(nodeSource, nodeTarget);
            if (result.ret == ResultType.Success)
            {
                if (nodeTarget == null)
                    await LogService.AddEvent("移到栏目[" + nodeSource.NodeName + " #" + nodeSource.AutoID + "]为根栏目");
                else
                    await LogService.AddEvent("移到栏目[" + nodeSource.NodeName + "]为栏目[ID:" + nodeTarget.AutoID + "]的子栏目");

                //清除页面缓存
                publisher.DeleteNodes();
                publisher.DeleteArticles();

                string backUrl ="/platform/NodeMove/Index";
                return new OperateResult(true, "OperationSuccess", "操作成功", backUrl, 1500).ToString();
            }
            else
                return result.ToOperateResultJson();
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            var nodeNameList = nodeRepository.GetNodeTree();
            var lstSourceNode = new List<SelectListItem>();
            var lstTargetNode = new List<SelectListItem>
            {
                new SelectListItem() { Text = "作为根栏目", Value = "0" }
            };
            foreach (var item in nodeNameList)
            {
                lstSourceNode.Add(new SelectListItem() { Text = item.NodeName, Value = item.AutoID.ToString() });
                lstTargetNode.Add(new SelectListItem() { Text = item.NodeName, Value = item.AutoID.ToString() });
            }

            ViewBag.SourceItems = lstSourceNode;
            ViewBag.TargetItems = lstTargetNode;

            return View("NodeMger/NodeMove.cshtml");
        }

        #endregion
    }
}
