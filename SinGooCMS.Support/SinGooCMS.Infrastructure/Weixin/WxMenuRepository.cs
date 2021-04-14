//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-04-03 15:49:00
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Infrastructure
{
    public class WxMenuRepository : RespositoryBase<WxMenuInfo>, IWxMenuRepository
    {
        private readonly IAutoRlyRepository autoRlyRepository;
        public WxMenuRepository(IAutoRlyRepository _autoRlyRepository)
        {
            this.autoRlyRepository = _autoRlyRepository;
        }

        public async Task EmptyLocal()
        {
            //本地只是用做缓存，所以不需要保留数据，数据本源于微信服务器
            await DeleteAllAsync();
        }

        public async Task<WxMenuStatus> Add(WxMenuInfo entity, AutoRlyInfo eventKey)
        {
            if (entity.ParentID.Equals(0) && await GetCountAsync(p => p.ParentID == 0) >= 3)
                return WxMenuStatus.一级菜单个数不超过3个;
            else if (entity.ParentID > 0 && await GetCountAsync(p => p.ParentID == entity.ParentID) > 5)
                return WxMenuStatus.二级菜单个数不超过5个;
            else
            {
                if (entity.Type == "click" && eventKey != null)
                {
                    await autoRlyRepository.AddAsync(eventKey);
                    entity.EventKey = eventKey.MsgKey;
                }

                int newID = await AddAsync(entity);
                if (newID > 0)
                {
                    entity.AutoID = newID;
                    if (entity.ParentID.Equals(0))
                    {
                        //一级菜单
                        entity.RootID = newID;
                        await UpdateAsync(entity);
                    }
                    else
                    {
                        //二级菜单
                        WxMenuInfo parentMenu = await FindAsync(entity.ParentID);
                        entity.RootID = parentMenu.RootID;
                        parentMenu.ChildCount = (short)(parentMenu.ChildCount + 1);
                        parentMenu.ChildIDs = parentMenu.ChildIDs + "," + newID;

                        await UpdateAsync(entity);
                        await UpdateAsync(parentMenu);
                    }

                    return WxMenuStatus.增加成功;
                }
            }

            return WxMenuStatus.增加失败;
        }

        public async Task<WxMenuStatus> Update(WxMenuInfo entity, AutoRlyInfo eventKey)
        {
            //原菜单
            WxMenuInfo orginalMenu = await FindAsync(entity.AutoID);

            if (await UpdateAsync(entity))
            {
                //view用于url跳转
                if (entity.Type == "view" && !string.IsNullOrEmpty(orginalMenu.EventKey))
                    await autoRlyRepository.DelEventKey(orginalMenu.EventKey);//清除原来的事件，url跳转不需要点击事件
                else if (entity.Type == "click" && eventKey != null)
                {
                    entity.EventKey = eventKey.MsgKey;
                    //菜单原事件关键字
                    AutoRlyInfo originalKey = await autoRlyRepository.GetEventRly(orginalMenu.EventKey);
                    if (originalKey != null)
                    {
                        //原来的事件存在，则更新它
                        originalKey.MsgText = eventKey.MsgText;
                        originalKey.Description = eventKey.Description;
                        originalKey.MediaPath = eventKey.MediaPath;
                        originalKey.LinkUrl = eventKey.LinkUrl;
                        originalKey.AutoTimeStamp = System.DateTime.Now;
                        await autoRlyRepository.UpdateAsync(originalKey);
                    }
                    else
                    {
                        //原来没有事件，则新增加
                        await autoRlyRepository.AddAsync(eventKey);
                    }
                }

                return WxMenuStatus.修改成功;
            }

            return WxMenuStatus.修改失败;
        }

        public async Task<bool> Del(int id)
        {
            WxMenuInfo entity = await FindAsync(id);
            if (entity.ChildCount > 0)
                return false; //有子菜单不能删除

            if (await DeleteAsync(id))
            {
                //需要更新上级菜单
                if (entity.ParentID > 0)
                {
                    var parentMenu = await FindAsync(entity.ParentID);
                    parentMenu.ChildCount -= 1;
                    parentMenu.ChildIDs = parentMenu.ChildIDs.Replace("," + id, "");
                    await UpdateAsync(parentMenu);
                }

                //删除微信事件关键字
                if (!entity.EventKey.IsNullOrEmpty())
                    await autoRlyRepository.DelEventKey(entity.EventKey);

                return true;
            }

            return false;
        }
    }
}