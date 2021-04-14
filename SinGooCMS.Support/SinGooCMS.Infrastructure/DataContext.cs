using Microsoft.EntityFrameworkCore;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;

namespace SinGooCMS.Infrastructure
{
    public class DataContext : DbContext
    {
        #region DbSets

        public DbSet<AccountDetailInfo> AccountDetail { get; set; }
        public DbSet<AccountInfo> Account { get; set; }
        public DbSet<AdPlaceInfo> AdPlace { get; set; }
        public DbSet<AdsInfo> Ads { get; set; }
        public DbSet<AttachmentInfo> Attachment { get; set; }
        public DbSet<AutoRlyInfo> AutoRly { get; set; }
        public DbSet<BaseConfigInfo> BaseConfig { get; set; }
        public DbSet<CatalogInfo> Catalog { get; set; }
        public DbSet<CommentActiveLogInfo> CommentActiveLog { get; set; }
        public DbSet<CommentInfo> Comment { get; set; }
        public DbSet<ContentInfo> Content { get; set; }
        public DbSet<ContFieldInfo> ContField { get; set; }
        public DbSet<ContModelInfo> ContModel { get; set; }
        public DbSet<DictItemInfo> DictItem { get; set; }
        public DbSet<DictsInfo> Dicts { get; set; }
        public DbSet<EventLogInfo> EventLog { get; set; }
        public DbSet<FeedbackInfo> Feedback { get; set; }
        public DbSet<FileUploadInfo> FileUpload { get; set; }
        public DbSet<FolderInfo> Folder { get; set; }
        public DbSet<IPStrategyInfo> IPStrategy { get; set; }
        public DbSet<LinksInfo> Links { get; set; }
        public DbSet<MessageInfo> Message { get; set; }
        public DbSet<ModuleInfo> Module { get; set; }
        public DbSet<NodeInfo> Node { get; set; }
        public DbSet<OperateInfo> Operate { get; set; }
        public DbSet<PurviewInfo> Purview { get; set; }
        public DbSet<RoleInfo> Role { get; set; }
        public DbSet<SettingCategoryInfo> SettingCategory { get; set; }
        public DbSet<SettingInfo> Setting { get; set; }
        public DbSet<SiteTemplateInfo> SiteTemplate { get; set; }
        public DbSet<SendRecordInfo> SMS { get; set; }
        public DbSet<SMSTemplateInfo> SMSTemplate { get; set; }
        public DbSet<TagsInfo> Tags { get; set; }
        public DbSet<ThirdPartyLoginInfo> ThirdPartyLogin { get; set; }
        public DbSet<UserFieldInfo> UserField { get; set; }
        public DbSet<UserGroupInfo> UserGroup { get; set; }
        public DbSet<UserInfo> User { get; set; }
        public DbSet<UserLevelInfo> UserLevel { get; set; }
        public DbSet<VerInfo> Ver { get; set; }
        public DbSet<VisitorInfo> Visitor { get; set; }
        public DbSet<VoteInfo> Vote { get; set; }
        public DbSet<VoteLogInfo> VoteLog { get; set; }
        public DbSet<WxMenuInfo> WxMenu { get; set; }

        #endregion

        /// <summary>
        /// 配置连接字符串，如果有需要可以重载切换连接
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbType = EnumUtils.StringToEnum<DbType>(ConfigUtils.ProviderName);
            switch (dbType)
            {
                case DbType.Sqlite:
                    options.UseSqlite(ConfigUtils.DefConnStr);
                    break;
                case DbType.MySql:
                    options.UseMySql(ConfigUtils.DefConnStr);
                    break;
                case DbType.SqlServer:
                default:
                    options.UseSqlServer(ConfigUtils.DefConnStr);
                    break;
            }

        }
    }
}
