using System;
using System.IO;
using SinGooCMS.Utility;
using SinGooCMS.Ado;
using SinGooCMS.Ado.Interface;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Infrastructure
{
    public class SiteBackup : ISiteBackup
    {
        private readonly ICMSContext context;
        private readonly string physicalFolder = SinGooBase.GetMapPath(SinGooBase.BackupFolder);
        readonly IDbMaintenance dbMaintenance = DbProvider.DbMaintenance;

        public SiteBackup(ICMSContext _context)
        {
            this.context = _context;
        }

        #region 数据库备份

        public Result CreateDBBack(string bakFileName = "")
        {
            /*
             * sqlserver 备份成 .bak
             * mysql 备份成 .sql
             * sqlite 是文件数据库,文件在App_Data目录下，直接copy一份就可以了
             */

            try
            {
                var dbType = EnumUtils.StringToEnum<DbType>(context.DbProviderName);
                string connstr = ConfigUtils.DefConnStr;
                string database = StringUtils.Cut(connstr, "database=", ";");
                string uid = StringUtils.Cut(connstr, "uid=", ";");
                string pwd = StringUtils.Cut(connstr, "pwd=", ";");

                if (bakFileName == "")
                {
                    if (dbType == DbType.SqlServer)
                        bakFileName = physicalFolder + StringUtils.GetNewFileName() + ".bak";
                    else if (dbType == DbType.MySql)
                        bakFileName = physicalFolder + StringUtils.GetNewFileName() + ".sql";
                    else if (dbType == DbType.Sqlite)
                        bakFileName = physicalFolder + StringUtils.GetNewFileName() + ".db";
                }
                else
                    bakFileName = physicalFolder + bakFileName; //自定义文件名就要考虑数据库类型了

                if (dbType == DbType.SqlServer)
                {
                    dbMaintenance.BackupDatabase("[" + database + "]", bakFileName);
                    return Result.success;
                }
                else if (dbType == DbType.MySql)
                {
                    dbMaintenance.BackupDatabase("[" + database + "]", bakFileName);
                    return Result.success;
                }
                else if (dbType == DbType.Sqlite)
                {
                    //File.Copy(Server.MapPath("/App_Data/singoocmsv1.5.db"), bakFileName);
                    return Result.success;
                }
            }
            catch (Exception ex)
            {
                return OperateResult.Fail("备份失败：" + ex.Message);
            }

            return Result.fail;
        }

        #endregion

        #region 目录备份

        /// <summary>
        /// 创建整站备份
        /// </summary>
        public Result CreateSiteBack(string zipFileName = "")
        {
            zipFileName = zipFileName == string.Empty
                ? FileUtils.Combine(physicalFolder, StringUtils.GetNewFileName() + "_site" + ".zip")
                : FileUtils.Combine(physicalFolder, zipFileName);

            return CreateFolderBackup(SinGooBase.GetMapPath(SinGooBase.BaseDir), zipFileName);
        }

        /// <summary>
        /// 创建当前模板备份
        /// </summary>
        /// <returns></returns>
        public Result CreateTmplateBack(string zipFileName = "")
        {
            zipFileName = zipFileName == string.Empty
                ? FileUtils.Combine(physicalFolder, StringUtils.GetNewFileName() + "_template" + ".zip")
                : FileUtils.Combine(physicalFolder, zipFileName);

            return CreateFolderBackup(SinGooBase.GetMapPath(context.ViewDir), zipFileName);
        }

        /// <summary>
        /// 创建上传文件备份
        /// </summary>
        /// <returns></returns>
        public Result CreateUploadBack(string zipFileName = "")
        {
            zipFileName = zipFileName == string.Empty
                ? FileUtils.Combine(physicalFolder, StringUtils.GetNewFileName() + "_upload" + ".zip")
                : FileUtils.Combine(physicalFolder, zipFileName);

            return CreateFolderBackup(SinGooBase.GetMapPath("/upload/"), zipFileName);
        }

        /// <summary>
        /// 创建备份文件
        /// </summary>
        /// <param name="dir">需要备份的目录(物理路径)</param>
        /// <param name="zipFileName">打包的文件名称</param>
        /// <returns></returns>
        private static Result CreateFolderBackup(string dir, string zipFileName)
        {
            try
            {
                ZipUtils.Zip(dir, zipFileName);
                return Result.success;
            }
            catch (Exception ex)
            {
                return OperateResult.Fail(ex.Message);
            }
        }

        #endregion        
    }
}
