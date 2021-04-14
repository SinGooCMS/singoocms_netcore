using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain;
using SinGooCMS.MVCBase.Filter;
using SinGooCMS.Utility;
using SinGooCMS.MVCBase;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Application
{
    /// <summary>
    /// 后端管理基础类
    /// </summary>
    //[ManagerFilter]
    [TypeFilter(typeof(ManagerFilterAttribute))]
    public class ManagerPageBase : CMSPageBase
    {
        public IManager Manager { get; set; }
        public IAccountRepository AccountRepository { get; set; }

        public ManagerPageBase() : base($"/views/platform/h5/")
        {
            //
        }

        #region 获取管理菜单

        /// <summary>
        /// 获取当前帐号的菜单项
        /// </summary>
        /// <returns></returns>
        public async Task<DataTable> GetAccountMenu()
        {
            //菜单
            var dict = Context.Cache.Get<Dictionary<int, DataTable>>(CacheKey.CKEY_ACCOUNTMENU);
            if (dict != null && dict.ContainsKey(Manager.AccountID))
                return dict[Manager.AccountID];
            else
            {
                if (dict == null)
                    dict = new Dictionary<int, DataTable>();

                if (dict.Keys.Contains(Manager.AccountID))
                    dict[Manager.AccountID] = await AccountRepository.GetMenu(Manager.LoginAccount);
                else
                    dict.Add(Manager.AccountID, await AccountRepository.GetMenu(Manager.LoginAccount));

                Context.Cache.Insert(CacheKey.CKEY_ACCOUNTMENU, dict);
                return dict[Manager.AccountID];
            }
        }

        #endregion

        #region 页面功能相关

        /// <summary>
        /// 获取id:sort集合
        /// </summary>
        /// <param name="idKey"></param>
        /// <param name="sortKey"></param>
        /// <returns></returns>
        public Dictionary<int, int> GetSortDict(string idKey = "AutoID", string sortKey = "txtSort")
        {
            var dictIDAndSort = new Dictionary<int, int>();
            var arrId = (List<string>)WebUtils.GetFormVals<string>(idKey);
            var arrSort = (List<string>)WebUtils.GetFormVals<string>(sortKey);
            if (arrId != null && arrId.Count > 0)
            {
                for (var i = 0; i < arrId.Count; i++)
                    dictIDAndSort.Add(arrId[i].ToInt(), arrSort[i].ToInt());                
            }

            return dictIDAndSort;
        }

        #endregion        

        #region 后台专有属性

        protected new Pager pager = new Pager()
        {
            PageIndex = WebUtils.GetQueryVal<int>("page", 1),
            PageSize = WebUtils.GetQueryVal<int>("pagesize", 20)
        };

        protected string DataUrl => Context.DataUrl;
        protected int OpID => Context.OpID;
        protected string ParamAction => Context.ParamAction;
        protected bool IsAdd => ParamAction == OperationType.Add;
        protected bool IsEdit => ParamAction == OperationType.Modify;

        #endregion
    }
}
