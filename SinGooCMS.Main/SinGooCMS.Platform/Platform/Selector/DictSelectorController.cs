using System;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.MVCBase.Filter;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform.Platform.Tools
{
    public class DictSelectorController : ManagerPageBase
    {
        const string MODULECODE = "DataDictionary";
        private readonly IDictsRepository dictsRepository;

        public DictSelectorController(IDictsRepository _dictsRepository)
        {
            this.dictsRepository = _dictsRepository;
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            ViewBag.SelectType = WebUtils.GetQueryString("type").ToLower();
            return View("/Selector/DictForSelect.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public async Task<string> DataJson()
        {
            var pageModel = await dictsRepository.GetPagerListAsync(GetCondition(), sort, pager.PageIndex, pager.PageSize);
            pager.TotalRecord = pageModel.TotalRecord;
            pager.TotalPage = pageModel.TotalPage;
            return new MVCPager(pager).Display(pageModel.PagerData.ToJson());
        }
        private Expression<Func<Domain.Models.DictsInfo, bool>> GetCondition()
        {
            if (!searchKey.IsNullOrEmpty())
                return (p) => p.DictName.Contains(searchKey);
            else
                return (p) => true;
        }
    }
}
