using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities.Menu;
using SinGooCMS.Application;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;
using SinGooCMS.Weixin;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.WeixinMger
{
    public class CustomMenuController : ManagerPageBase
    {
        const string MODULECODE = "CustomMenuMger";
        private readonly IWxMenuRepository wxMenuRepository;
        private readonly IAutoRlyRepository autoRlyRepository;

        public CustomMenuController(IWxMenuRepository _wxMenuRepository, IAutoRlyRepository _autoRlyRepository)
        {
            this.wxMenuRepository = _wxMenuRepository;
            this.autoRlyRepository = _autoRlyRepository;
        }

        #region 列表

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            var delEntity = await wxMenuRepository.FindAsync(OpID);
            if (delEntity == null)
                return OperateResult.FailJson("OperationDataNotFound", "操作对象不存在或者已删除");

            if (delEntity.ChildCount > 0)
                return OperateResult.FailJson("OperationChildObjectExists", "操作对象已存在下级对象");

            if (await wxMenuRepository.Del(OpID))
            {
                await LogService.AddEvent("删除微信菜单[" + delEntity.Name + "]成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE,OperationType.UpdateClient)]
        public async Task<string> LoadFromServer()
        {
            WXConfig config = await WXConfig.Load();
            var accessToken = CommonApi.GetToken(config.AppID, config.AppSecret);
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", accessToken.access_token);
            Context.Log.LogDebug("获取菜单url：" + url);
            string jsonForMenu = NetWorkUtils.HttpGet(url); //从服务器获取菜单信息
            Context.Log.LogDebug("微信菜单数据：" + jsonForMenu);
            var result = jsonForMenu.JsonToObject<GetMenuResultFull>();

            if (result != null)
            {
                if (result.errcode == ReturnCode.请求成功)
                {
                    #region 更新本地数据

                    await wxMenuRepository.EmptyLocal(); //清空本地数据
                                                         //第一层
                    int counterX = 1;
                    foreach (MenuFull_RootButton item in result.menu.button)
                    {
                        var wxMenu = new WxMenuInfo()
                        {
                            RootID = 0,
                            ParentID = 0,
                            Type = item.type ?? string.Empty,
                            Name = item.name,
                            EventKey = item.key ?? string.Empty,
                            Url = item.url ?? string.Empty,
                            ChildCount = 0,
                            ChildIDs = string.Empty,
                            Sort = counterX,
                            AutoTimeStamp = System.DateTime.Now
                        };
                        int newID = await wxMenuRepository.AddAsync(wxMenu);
                        if (newID > 0)
                        {
                            wxMenu.AutoID = newID;
                            wxMenu.RootID = newID;
                            counterX++;

                            if (item.sub_button != null && item.sub_button.Count > 0)
                            {
                                //第二层
                                wxMenu.ChildCount = (short)item.sub_button.Count;
                                int counterY = 1;
                                foreach (MenuFull_RootButton item_sub in item.sub_button)
                                {
                                    var wxMenu_sub = new WxMenuInfo()
                                    {
                                        RootID = newID,
                                        ParentID = newID,
                                        Type = item_sub.type ?? string.Empty,
                                        Name = item_sub.name,
                                        EventKey = item_sub.key ?? string.Empty,
                                        Url = item_sub.url ?? string.Empty,
                                        ChildCount = 0,
                                        ChildIDs = string.Empty,
                                        Sort = counterY,
                                        AutoTimeStamp = System.DateTime.Now
                                    };

                                    int newSubID = await wxMenuRepository.AddAsync(wxMenu_sub);
                                    if (newSubID > 0)
                                    {
                                        wxMenu.ChildIDs += newSubID + ",";
                                        counterY++;
                                    }
                                }
                            }

                            if (wxMenu.ChildIDs.EndsWith(","))
                                wxMenu.ChildIDs = wxMenu.ChildIDs.TrimEnd(',');

                            await wxMenuRepository.UpdateAsync(wxMenu);
                        }
                    }

                    #endregion

                    await LogService.AddEvent("从微信服务器加载微信菜单并更新到本地");
                    return OperateResult.successLoadJson; //网络上数据更新本地后，需要重新加载页面
                }
                else
                {
                    /*
                     * 显示没有菜单等各种错误
                     * {"errcode":46003,"errmsg":"menu no exist hint: [DIGqaA00053126]"}
                     */
                    return OperateResult.FailJson(result.errcode.ToString());
                }
            }

            return OperateResult.failJson;
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.UpdateServer)]
        public async Task<string> SaveToRemote()
        {
            WXConfig config = await WXConfig.Load();

            #region 提交到服务器
            /* json 数据如：
             * {"menu":{"button":[{"sub_button":[{"key":"1312","type":"click","name":"131关键字"},{"key":"singoocms2","type":"click","name":"singoocms"},{"key":"SubClickRoot_Music","type":"click","name":"返回音乐"},{"url":"http://weixin.senparc.com","type":"view","name":"Url跳转"}],"name":"二级菜单"},{"key":"OneClick","type":"click","name":"单击测试"},{"url":"http://www.ue.net.cn","type":"view","name":"关于我们"}]}}
             * post更新的数据
             * {"button":[{"sub_button":[{"key":"1312","type":"click","name":"131关键字"},{"key":"singoocms2","type":"click","name":"singoocms"},{"key":"SubClickRoot_Music","type":"click","name":"返回音乐"},{"url":"http://weixin.senparc.com","type":"view","name":"Url跳转"}],"name":"二级菜单"},{"key":"OneClick","type":"click","name":"单击测试"},{"url":"http://www.ue.net.cn","type":"view","name":"关于我们"}]}
             */

            //var accessToken = AccessTokenContainer.TryGetToken(SinGooCMS.Weixin.Config.AppID, SinGooCMS.Weixin.Config.AppSecret);
            var accessToken = CommonApi.GetToken(config.AppID, config.AppSecret);
            var lstMenu = await wxMenuRepository.GetListAsync(15, "", " RootID ASC,ParentID ASC,Sort ASC ");
            Dictionary<int, int> dictIDAndSort = GetSortDict();

            foreach (var item in lstMenu)
            {
                item.Sort = dictIDAndSort[item.AutoID];
            }

            //重新排序
            lstMenu = lstMenu.OrderBy(p => p.RootID).OrderBy(p => p.ParentID).OrderBy(p => p.Sort).ToList();
            if (await wxMenuRepository.UpdateSortAsync(dictIDAndSort))
            {
                await LogService.AddEvent("成功更新微信菜单到微信服务器");
            }

            //组织上传
            ButtonGroup bg = new ButtonGroup();
            foreach (var level1 in lstMenu)
            {
                if (level1.ParentID.Equals(0))
                {
                    if (level1.ChildCount > 0) //有子菜单
                    {
                        #region 包含二级菜单
                        var subButton = new SubButton()
                        {
                            name = level1.Name
                        };

                        var subMenu = lstMenu.Where(p => p.ParentID.Equals(level1.AutoID));
                        if (subMenu != null && subMenu.Count() > 0)
                        {
                            foreach (var item_sub in subMenu)
                            {
                                switch (item_sub.Type)
                                {
                                    case "click":
                                        subButton.sub_button.Add(new SingleClickButton()
                                        {
                                            name = item_sub.Name,
                                            key = item_sub.EventKey
                                        });
                                        break;
                                    case "view":
                                        subButton.sub_button.Add(new SingleViewButton()
                                        {
                                            name = item_sub.Name,
                                            url = item_sub.Url
                                        });
                                        break;
                                }
                            }
                        }

                        bg.button.Add(subButton);
                        #endregion
                    }
                    else
                    {
                        #region 只有一级菜单
                        switch (level1.Type)
                        {
                            case "click":
                                bg.button.Add(new SingleClickButton()
                                {
                                    name = level1.Name,
                                    key = level1.EventKey
                                });
                                break;
                            case "view":
                                bg.button.Add(new SingleViewButton()
                                {
                                    name = level1.Name,
                                    url = level1.Url
                                });
                                break;
                        }
                        #endregion
                    }
                }
            }

            var tjResult = CommonApi.CreateMenu(accessToken.access_token, bg);
            if (tjResult.errcode == ReturnCode.请求成功) //0表示提交成功了
            {
                await LogService.AddEvent("成功更新微信菜单到微信服务器");
                return OperateResult.successLoadJson;
            }
            else
                return OperateResult.FailJson(tjResult.errcode.ToString());

            #endregion
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            return View("WeixinMger/CustomMenu.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            //数据
            base.sort = "Sort asc,AutoID desc";
            var lst = await wxMenuRepository.GetListAsync(15, "", " RootID ASC,ParentID ASC,Sort ASC "); //菜单最多3 x 5＝15条记录
            var lstNew = from item in lst
                         select new
                         {
                             item.AutoID,
                             item.ParentID,
                             item.Type,
                             item.Name,
                             item.Url,
                             item.Sort,
                             NameExt = GetShowName(item.ParentID, item.ChildCount, item.Name),
                             TypeExt = item.Type == "click" ? "图文推送" : "地址跳转：" + item.Url
                         };

            string dataJson = lstNew.ToJson();

            //没有数据时，连续data字段都不输出
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":{}}}";
        }

        private string GetShowName(int parentId, int childCount, string name)
        {
            var builder = new StringBuilder();
            builder.Append(string.Format("<span class='CateLevel{0}'>", (parentId + 1)));
            builder.Append(string.Format("<ico style='cursor: pointer;' class='glyphicon glyphicon-minus-sign' {0} depth={1}></ico> ",
                (childCount.Equals(0) ? "canexpand='0'" : "canexpand='1'"), (childCount + 1).ToString()));
            builder.Append(parentId.Equals(0) ? "<b>" + name + "</b>" : "&nbsp;&nbsp;&nbsp;&nbsp;" + name);
            builder.Append("</span>");

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

        private async Task<string> Edit(bool isModify)
        {
            /*
             *  1、  最多创建3个一级菜单，一级菜单名称名字不多于4个汉字或8个字母。
                2、  每个一级菜单下的子菜单最多可创建5个，子菜单名称名字不多于8个汉字或16个字母。
                3、  在子菜单下设置动作，可在“发布消息”中编辑内容（文字中可输入600字或字符），或者在“跳转到网络”中添加链接地址。
             */

            WxMenuInfo entity = new WxMenuInfo();
            if (isModify)
                entity = await wxMenuRepository.FindAsync(OpID);

            entity.ParentID = WebUtils.GetFormVal<int>("parentmenu");
            entity.Name = WebUtils.GetFormString("menuname");
            entity.Type = WebUtils.GetFormString("menutype");
            entity.Url = WebUtils.GetFormString("TextBox4");

            //图文推送的信息
            AutoRlyInfo keyEntity = new AutoRlyInfo()
            {
                RlyType = "事件回复",
                MsgKey = StringUtils.GetRandomNumber(),
                MsgText = WebUtils.GetFormString("TextBox1"),
                MediaPath = WebUtils.GetFormString("TextBox2"),
                Description = WebUtils.GetFormString("TextBox3"),
                LinkUrl = WebUtils.GetFormString("TextBox4")
            };

            if (string.IsNullOrEmpty(entity.Name))
                return OperateResult.FailJson("菜单名称不能为空");
            else if (entity.ParentID == 0 && entity.Name.Length > 4)
                return OperateResult.FailJson("一级菜单文字长度不超过4个汉字");
            else if (entity.ParentID > 0 && entity.Name.Length > 8)
                return OperateResult.FailJson("二级菜单文字长度不超过8个汉字");
            else if (entity.Type == "click" && string.IsNullOrEmpty(keyEntity.MsgText))
                return OperateResult.FailJson("图文推送文本不能为空");
            else if (entity.Type == "click" && (keyEntity.MsgText.Length > 600 || keyEntity.Description.Length > 600))
                return OperateResult.FailJson("推送图文中的文本不能超过600汉字");
            else if (entity.Type == "view" && string.IsNullOrEmpty(keyEntity.LinkUrl))
                return OperateResult.FailJson("地址跳转的地址不能为空");
            else
            {
                //增加
                if (!isModify)
                {
                    entity.EventKey = string.Empty;
                    entity.Sort = wxMenuRepository.MaxSort.Value + 1;
                    entity.AutoTimeStamp = System.DateTime.Now;
                    WxMenuStatus statu = await wxMenuRepository.Add(entity, keyEntity);
                    if (statu == WxMenuStatus.增加成功)
                    {
                        await LogService.AddEvent("添加微信菜单[" + entity.Name + "]成功");
                        return OperateResult.successJson;
                    }
                    else
                        return OperateResult.FailJson(statu.ToString());

                }
                //修改
                if (isModify)
                {
                    WxMenuStatus status = await wxMenuRepository.Update(entity, keyEntity);
                    if (status == WxMenuStatus.修改成功)
                    {
                        await LogService.AddEvent("修改微信菜单[" + entity.Name + "]成功");
                        return OperateResult.successJson;
                    }
                    else
                        return OperateResult.FailJson(status.ToString());
                }
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<IActionResult> Edit()
        {
            /*
             * 微信菜单事件分为 click 和 view 即点击和跳转事件
             * 当类型是click是触发一个事件。当类型是view是直接打开一个网址
             */

            //第一级微信菜单（微信菜单最多二级）
            ViewBag.ParentMenu = await wxMenuRepository.GetListAsync(3, "ParentID=0", "Sort asc");

            //当前微信菜单
            var weixinMenu = await wxMenuRepository.FindAsync(OpID) ?? new WxMenuInfo();
            ViewBag.WeixinMenu = weixinMenu;

            //菜单事件关联
            ViewBag.WeixinKey = await autoRlyRepository.GetEventRly(weixinMenu.EventKey) ?? new AutoRlyInfo();

            return View("WeixinMger/ModifyCustomMenu.cshtml");
        }

        #endregion

        #endregion
    }
}
