using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.SysMger
{
    public class SysMgerController : ManagerPageBase
    {
        const string MODULECODE = "BackupAndRestore";
        private readonly ISiteBackup siteBackup;

        public SysMgerController(ISiteBackup _siteBackup)
        {
            this.siteBackup = _siteBackup;
        }

        #region 数据备份

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.Delete)]
        public async Task<string> Delete()
        {
            string strBakFile = WebUtils.GetFormString("bakfile");
            try
            {
                if (System.IO.File.Exists(strBakFile))
                    System.IO.File.Delete(strBakFile);

                await LogService.AddEvent("删除备份文件[" + strBakFile + "]成功");
                return OperateResult.successLoadJson;
            }
            catch (Exception ex)
            {
                return OperateResult.Fail("删除失败：" + ex.Message).ToString();
            }
        }

        /// <summary>
        /// 创建数据库备份
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Permission(MODULECODE, OperationType.Backup)]
        public async Task<string> CreateDBBack()
        {
            if (Context.DbProviderName.ToLower() != DbType.SqlServer.ToString().ToLower())
                return OperateResult.FailJson("仅提供了MSSQLSERVER的在线备份功能");

            if (siteBackup.CreateDBBack().ret == ResultType.Success)
            {
                await LogService.AddEvent("创建数据库备份文件成功");
                return OperateResult.successLoadJson;
            }
            else
            {
                await LogService.AddEvent("创建数据库备份文件失败");
                return OperateResult.failJson;
            }
        }

        /// <summary>
        /// 创建整站备份
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Permission(MODULECODE, OperationType.Backup)]
        public async Task<string> CreateSiteBack()
        {
            if (siteBackup.CreateSiteBack().ret == ResultType.Success)
            {
                await LogService.AddEvent("创建整站备份成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        /// <summary>
        /// 创建当前模板备份
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Permission(MODULECODE, OperationType.Backup)]
        public async Task<string> CreateTempateBack()
        {
            if (siteBackup.CreateTmplateBack().ret == ResultType.Success)
            {
                await LogService.AddEvent("创建模板备份成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        /// <summary>
        /// 创建上传文件备份
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Permission(MODULECODE, OperationType.Backup)]
        public async Task<string> CreateUploadBack()
        {
            if (siteBackup.CreateUploadBack().ret == ResultType.Success)
            {
                await LogService.AddEvent("创建上传文件备份成功");
                return OperateResult.successLoadJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult DataBackup()
        {
            return View("SysMger/DataBackup.cshtml");
        }

        [HttpGet]
        [Permission(MODULECODE)]
        public string DataJson()
        {
            var lstBakFile = new List<DataBakFile>();
            var physicalPath = SinGooBase.GetMapPath(SinGooBase.BackupFolder);
            if (Directory.Exists(physicalPath))
            {
                int intCount = 1;
                var dir = new DirectoryInfo(physicalPath);
                foreach (FileInfo item in dir.GetFiles("*"))
                {
                    DataBakFile entity = new DataBakFile();
                    entity.AutoID = intCount;
                    entity.BakFileName = item.Name;
                    entity.BakFileType = DataBakFile.GetBakFileType(entity.BakFileName);
                    entity.VirtualPath = FileUtils.Combine(SinGooBase.BackupFolder, item.Name);
                    entity.EnCodeVPath = SinGooBase.DesEncode(entity.VirtualPath);
                    entity.BakFilePath = item.FullName;
                    entity.BakFileSize = FileUtils.GetFileSize(item.Length);
                    entity.UploadDate = item.LastWriteTime.ToString();
                    //从文件扩展属性中读取创建者
                    /*DSOFile.OleDocumentPropertiesClass fileDetail = new DSOFile.OleDocumentPropertiesClass();
                    fileDetail.Open(item.FullName,true,DSOFile.dsoFileOpenOptions.dsoOptionDefault);
                    entity.Uploader = fileDetail.SummaryProperties.Author; //摘要属性的作者*/
                    lstBakFile.Add(entity);

                    intCount++;
                }

                //按时间倒序排序
                //lstBakFile.Sort(delegate (DataBakFile parameterA, DataBakFile parameterB) { return parameterB.UploadDate.CompareTo(parameterA.UploadDate); });
                lstBakFile.Sort((x, y) => y.UploadDate.CompareTo(x.UploadDate));
            }

            //数据
            string dataJson = lstBakFile.ToJson();

            //没有数据时，连续data字段都不输出
            return "{\"result\":{" + (dataJson.Length > 2 ? "\"data\":" + dataJson + "," : "") + "\"pager\":{}}}";
        }

        #endregion        

        #endregion        
    }
}