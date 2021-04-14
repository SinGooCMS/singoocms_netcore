using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Application;
using SinGooCMS.Utility;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Platform.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoteController : UIPageBase
    {
        private readonly IVoteRepository voteRepository;
        private readonly IVoteLogRepository voteLogRepository;
        private readonly IUser user;
        private readonly ICMSContext cMSContext;

        public VoteController(IVoteRepository _voteRepository,
            IVoteLogRepository _voteLogRepository,
            IUser _user,
            ICMSContext _cMSContext)
        {
            this.voteRepository = _voteRepository;
            this.voteLogRepository = _voteLogRepository;
            this.user = _user;
            this.cMSContext = _cMSContext;
        }

        /// <summary>
        /// 输出投票信息
        /// </summary>
        /// <param name="voteId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> Get(int voteId)
        {
            return (await voteRepository.GetVoteFull(voteId)).ToJson();
        }

        /// <summary>
        /// 投票
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> Post()
        {
            //投票信息
            var voteInfo = await voteRepository.FindAsync(WebUtils.GetFormVal<int>("voteId"));
            //投票选项ID
            string voteItemID = WebUtils.GetFormString("voteItemId");
            var result = await voteLogRepository.Vote(voteInfo, voteItemID);
            return result.ToOperateResultJson();
        }
    }
}
