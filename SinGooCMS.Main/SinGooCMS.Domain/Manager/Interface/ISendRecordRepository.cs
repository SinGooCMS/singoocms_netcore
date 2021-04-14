//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     Author:16826375@qq.com http://www.singoo.top
//     生成时间为:2020-03-31 11:10:42
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SinGooCMS.Domain.Models;

namespace SinGooCMS.Domain.Interface
{
    public interface ISendRecordRepository : IRepositoryBase<SendRecordInfo>
    {
        /// <summary>
        /// 获取最后一条记录
        /// </summary>
        /// <param name="reciverMedia"></param>
        /// <returns></returns>
        Task<SendRecordInfo> GetLatest(string reciverMedia);

        /// <summary>
        /// 获取最后一条验证码记录
        /// </summary>
        /// <param name="reciverMedia"></param>
        /// <returns></returns>
        Task<SendRecordInfo> GetLatestCheckCode(string reciverMedia);
    }
}