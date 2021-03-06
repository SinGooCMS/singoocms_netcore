//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-04-03 15:48:48
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Models;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Infrastructure
{
    public class CommentActiveLogRepository : RespositoryBase<CommentActiveLogInfo>, ICommentActiveLogRepository
    {
        public CommentActiveLogRepository()
        {
            //
        }

        public async Task<bool> Ding(UserInfo user, CommentInfo comment)
        {
            var cmtLog = new CommentActiveLogInfo()
            {
                UserID = user.AutoID,
                UserName = user.UserName,
                CommentID = comment.AutoID,
                IPAddress = IPUtils.GetIP(),
                IPArea = IPUtils.GetIPAreaStr().Replace("[本机地址 CZ88.NET]", "本机地址").Replace("本机地址 CZ88.NET", "本机地址"),
                IsZan = true,
                Lang = SinGooBase.CurrLang,
                AutoTimeStamp = System.DateTime.Now
            };

            //如果已有记录，更新（如踩变赞）
            var logInfo = await HasHit(user.AutoID, comment.AutoID);
            if (logInfo != null)
            {
                cmtLog.AutoID = logInfo.AutoID;
                return await UpdateAsync(cmtLog);
            }
            else
                return await AddAsync(cmtLog) > 0;
        }

        public async Task<bool> Cai(UserInfo user, CommentInfo comment)
        {
            var cmtLog = new CommentActiveLogInfo()
            {
                UserID = user.AutoID,
                UserName = user.UserName,
                CommentID = comment.AutoID,
                IPAddress = IPUtils.GetIP(),
                IPArea = IPUtils.GetIPAreaStr().Replace("[本机地址 CZ88.NET]", "本机地址").Replace("本机地址 CZ88.NET", "本机地址"),
                IsZan = false,
                Lang = SinGooBase.CurrLang,
                AutoTimeStamp = System.DateTime.Now
            };

            //如果已有记录，更新（如踩变赞）
            var logInfo = await HasHit(user.AutoID, comment.AutoID);
            if (logInfo != null)
            {
                cmtLog.AutoID = logInfo.AutoID;
                return await UpdateAsync(cmtLog);
            }
            else
                return await AddAsync(cmtLog) > 0;
        }

        public async Task<CommentActiveLogInfo> HasHit(int userId, int commentId) =>
            await NoTrackQuery().Where(p => p.UserID == userId && p.CommentID == commentId).FirstOrDefaultAsync();
    }
}