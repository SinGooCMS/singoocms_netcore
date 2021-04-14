using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.Common;
using System.Threading.Tasks;
using SinGooCMS.Ado;
using SinGooCMS.Ado.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility.Extension;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Infrastructure
{
    internal class Utils
    {
        static readonly IDbAccess dbAccess = DbProvider.DbAccess;

        static Utils() { }

        public static ICacheStore _cacheStore;

        #region 生成Field相关的原生SQL语句

        /// <summary>
        /// 创建添加记录SQL语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldList"></param>
        /// <returns></returns>
        public static string GenerateSqlOfInsert(string tableName, IEnumerable<IField> fieldList)
        {
            var builder = new StringBuilder($" insert into {tableName}( ");
            var builder1 = new StringBuilder();
            var builder2 = new StringBuilder();
            int counter = 0;
            fieldList.ForEach(item =>
            {
                builder1.Append(counter < fieldList.Count() - 1 ? (item.FieldName + ",") : item.FieldName);
                builder2.Append(counter < fieldList.Count() - 1 ? ("@" + item.FieldName + ",") : "@" + item.FieldName);
                counter++;
            });
            builder.Append(builder1.ToString());
            builder.Append(" ) Values ( ");
            builder.Append(builder2.ToString());
            builder.Append(")");
            return builder.ToString();
        }

        /// <summary>
        /// 创建更新SQL语句
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="fieldList"></param>
        /// <param name="keyName"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public static string GenerateSqlOfUpdate(string tableName, IEnumerable<IField> fieldList, string keyName, int keyValue)
        {
            int counter = 0;
            var builder = new StringBuilder($" update {tableName} set ");
            fieldList.ForEach(item =>
            {
                builder.Append(item.FieldName + "=@" + (counter < fieldList.Count() - 1 ? item.FieldName + "," : item.FieldName));
                counter++;
            });
            builder.Append($" where {keyName}={keyValue} ");
            return builder.ToString();
        }

        /// <summary>
        /// 生成自定义字段参数集合
        /// </summary>
        /// <param name="fieldList"></param>
        /// <returns></returns>
        public static DbParameter[] PrepareSqlParameters(IEnumerable<IField> fieldList)
        {
            var lst = new List<DbParameter>();
            fieldList.ForEach(item =>
            {
                lst.Add(dbAccess.MakeParam("@" + item.FieldName, item.Value));
            });
            return lst.ToArray();
        }

        #endregion

        #region 自定义字段

        /// <summary>
        /// 添加默认的字段
        /// </summary>
        /// <param name="modelID">模型ID或者会员组ID</param>
        /// <param name="ContentOrUserType">类型：Content/User</param>
        /// <returns></returns>
        public async static Task AddDefaultField(int modelID, string ContentOrUserType = "Content")
        {
            var lstSql = new List<string>();
            if (ContentOrUserType.Equals("Content"))
            {
                lstSql.Add($" delete from cms_ContField where ModelID={modelID}; ");
                lstSql.Add(string.Format(@"insert into cms_ContField(ModelID,FieldName,FieldType,DataType,[DataLength],FieldAlias,Tip,FieldDesc,DefaultValue,Setting,EnableNull,EnableSearch,IsUsing,IsSystem,Sort) 
                                           select {0},[FieldName],[FieldType],[DataType],[DataLength],[FieldAlias],[Tip],[FieldDesc],[DefaultValue],[Setting],[EnableNull],[EnableSearch],[IsUsing],[IsSystem],[Sort] from cms_BaseField where ModelType = 'Content'", modelID));
            }                
            else if (ContentOrUserType.Equals("User"))
            {
                lstSql.Add($" delete from cms_UserField where UserGroupID={modelID}; ");
                lstSql.Add(string.Format(@"insert into cms_UserField (UserGroupID, FieldName, FieldType, DataType,[DataLength], FieldAlias, Tip, FieldDesc, DefaultValue, Setting, EnableNull, IsUsing, IsSystem, Sort)  
                                           select {0}, FieldName, FieldType, DataType,[DataLength], FieldAlias, Tip, FieldDesc, DefaultValue, Setting, EnableNull, IsUsing, IsSystem, Sort from cms_BaseField where ModelType = 'User'", modelID));
            }
            
            await dbAccess.ExecTransAsync(lstSql);
        }

        /// <summary>
        /// 获取自定义字段的表信息
        /// </summary>
        /// <param name="contId">内容ID</param>
        /// <param name="tableName">副表表名</param>
        /// <param name="fields">字段列表</param>
        /// <returns></returns>
        public static DataTable GetContFieldTable(int contId, string tableName, IEnumerable<ContFieldInfo> fields)
        {
            var builder = new StringBuilder("select ");
            fields.ForEach(item =>
            {
                builder.Append((item.IsSystem ? "a." : "b.") + item.FieldName + ",");
            });
            builder.Append("b.ContID ");
            builder.Append($" from cms_Content a left join {tableName} b ");
            builder.Append($" on a.AutoID=b.ContID where a.AutoID={contId}");

            return dbAccess.GetDataTable(builder.ToString());
        }

        /// <summary>
        /// 获取自定义字段的表信息
        /// </summary>
        /// <param name="userId">内容ID</param>
        /// <param name="tableName">副表表名</param>
        /// <param name="fields">字段列表</param>
        /// <returns></returns>
        public static DataTable GetUserFieldTable(int userId, string tableName, IEnumerable<UserFieldInfo> fields)
        {
            var builder = new StringBuilder("select ");
            fields.ForEach(item =>
            {
                builder.Append((item.IsSystem ? "a." : "b.") + item.FieldName + ",");
            });
            builder.Append("b.UserID ");
            builder.Append($" from cms_User a left join {tableName} b ");
            builder.Append($" on a.AutoID=b.UserID where a.AutoID={userId}");

            return dbAccess.GetDataTable(builder.ToString());
        }

        /// <summary>
        /// 默认的不可缺少的内容副表字段
        /// </summary>
        /// <returns></returns>
        public static ContFieldInfo DefaultContFieldInfo =>
            new ContFieldInfo
            {
                FieldName = "ContID",
                FieldAlias = "内容ID",
                FieldType = FieldType.SingleText.ToString(),
                EnableNull = false,
                IsUsing = true,
                DefaultValue = "0"
            };

        /// <summary>
        /// 默认的不可缺少的会员副表字段
        /// </summary>
        public static UserFieldInfo DefaultUserFieldInfo =>
            new UserFieldInfo
            {
                FieldName = "UserID",
                FieldAlias = "会员ID",
                FieldType = FieldType.SingleText.ToString(),
                EnableNull = false,
                IsUsing = true,
                DefaultValue = "0"
            };

        #endregion        
    }
}
