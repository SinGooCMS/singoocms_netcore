IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[weixin_WxMenu]') AND type in (N'U'))
DROP TABLE [weixin_WxMenu]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[weixin_AutoRly]') AND type in (N'U'))
DROP TABLE [weixin_AutoRly]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Visitor]') AND type in (N'U'))
DROP TABLE [sys_Visitor]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Ver]') AND type in (N'U'))
DROP TABLE [sys_Ver]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_SMSTemplate]') AND type in (N'U'))
DROP TABLE [sys_SMSTemplate]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_SettingCategory]') AND type in (N'U'))
DROP TABLE [sys_SettingCategory]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Setting]') AND type in (N'U'))
DROP TABLE [sys_Setting]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_SendRecord]') AND type in (N'U'))
DROP TABLE [sys_SendRecord]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Role]') AND type in (N'U'))
DROP TABLE [sys_Role]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Purview]') AND type in (N'U'))
DROP TABLE [sys_Purview]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Operate]') AND type in (N'U'))
DROP TABLE [sys_Operate]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Module]') AND type in (N'U'))
DROP TABLE [sys_Module]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Message]') AND type in (N'U'))
DROP TABLE [sys_Message]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_IPStrategy]') AND type in (N'U'))
DROP TABLE [sys_IPStrategy]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Folder]') AND type in (N'U'))
DROP TABLE [sys_Folder]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_FileUpload]') AND type in (N'U'))
DROP TABLE [sys_FileUpload]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_EventLog]') AND type in (N'U'))
DROP TABLE [sys_EventLog]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Dicts]') AND type in (N'U'))
DROP TABLE [sys_Dicts]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_DictItem]') AND type in (N'U'))
DROP TABLE [sys_DictItem]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Catalog]') AND type in (N'U'))
DROP TABLE [sys_Catalog]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_BaseConfig]') AND type in (N'U'))
DROP TABLE [sys_BaseConfig]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[sys_Account]') AND type in (N'U'))
DROP TABLE [sys_Account]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_VoteLog]') AND type in (N'U'))
DROP TABLE [cms_VoteLog]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_Vote]') AND type in (N'U'))
DROP TABLE [cms_Vote]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_UserLevel]') AND type in (N'U'))
DROP TABLE [cms_UserLevel]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_UserGroup]') AND type in (N'U'))
DROP TABLE [cms_UserGroup]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_UserField]') AND type in (N'U'))
DROP TABLE [cms_UserField]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_User]') AND type in (N'U'))
DROP TABLE [cms_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_U_Person]') AND type in (N'U'))
DROP TABLE [cms_U_Person]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_ThirdPartyLogin]') AND type in (N'U'))
DROP TABLE [cms_ThirdPartyLogin]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_Tags]') AND type in (N'U'))
DROP TABLE [cms_Tags]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_SiteTemplate]') AND type in (N'U'))
DROP TABLE [cms_SiteTemplate]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_Node]') AND type in (N'U'))
DROP TABLE [cms_Node]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_Links]') AND type in (N'U'))
DROP TABLE [cms_Links]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_Feedback]') AND type in (N'U'))
DROP TABLE [cms_Feedback]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_ContNodeExt]') AND type in (N'U'))
DROP TABLE [cms_ContNodeExt]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_ContModel]') AND type in (N'U'))
DROP TABLE [cms_ContModel]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_ContField]') AND type in (N'U'))
DROP TABLE [cms_ContField]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_Content]') AND type in (N'U'))
DROP TABLE [cms_Content]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_CommentActiveLog]') AND type in (N'U'))
DROP TABLE [cms_CommentActiveLog]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_Comment]') AND type in (N'U'))
DROP TABLE [cms_Comment]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_C_Product]') AND type in (N'U'))
DROP TABLE [cms_C_Product]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_C_Photo]') AND type in (N'U'))
DROP TABLE [cms_C_Photo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_C_FileDown]') AND type in (N'U'))
DROP TABLE [cms_C_FileDown]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_C_Common]') AND type in (N'U'))
DROP TABLE [cms_C_Common]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_BaseField]') AND type in (N'U'))
DROP TABLE [cms_BaseField]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_Attachment]') AND type in (N'U'))
DROP TABLE [cms_Attachment]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_Ads]') AND type in (N'U'))
DROP TABLE [cms_Ads]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_AdPlace]') AND type in (N'U'))
DROP TABLE [cms_AdPlace]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cms_AccountDetail]') AND type in (N'U'))
DROP TABLE [cms_AccountDetail]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_AccountDetail](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Unit] [char](10) NOT NULL,
	[Before] [float] NOT NULL,
	[OpValue] [float] NOT NULL,
	[OpType] [tinyint] NOT NULL,
	[After] [float] NOT NULL,
	[Remark] [nvarchar](1000) NULL,
	[Operator] [nvarchar](50) NULL,
	[OperateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_AdPlace](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[PlaceName] [nvarchar](50) NOT NULL,
	[Width] [smallint] NOT NULL,
	[Height] [smallint] NOT NULL,
	[Price] [decimal](12, 2) NULL,
	[TemplateFile] [nvarchar](255) NULL,
	[PlaceDesc] [nvarchar](1000) NULL,
	[Sort] [int] NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_Ads](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[PlaceID] [int] NOT NULL,
	[AdName] [nvarchar](50) NOT NULL,
	[AdType] [tinyint] NOT NULL,
	[AdLink] [nvarchar](100) NOT NULL,
	[BeginDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[AdText] [nvarchar](1000) NULL,
	[AdMediaPath] [nvarchar](100) NULL,
	[AdDesc] [nvarchar](100) NULL,
	[IsNewWin] [bit] NULL,
	[Hit] [int] NULL,
	[IsAudit] [bit] NULL,
	[Sort] [int] NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_Attachment](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[FilePath] [nvarchar](255) NOT NULL,
	[ImgThumb] [nvarchar](255) NOT NULL,
	[Remark] [nvarchar](2000) NOT NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_BaseField](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ModelID] [int] NOT NULL,
	[ModelType] [nvarchar](30) NOT NULL,
	[FieldName] [nvarchar](50) NOT NULL,
	[FieldType] [nvarchar](30) NOT NULL,
	[DataType] [nvarchar](20) NULL,
	[DataLength] [smallint] NULL,
	[FieldAlias] [nvarchar](100) NULL,
	[Tip] [nvarchar](255) NULL,
	[FieldDesc] [nvarchar](1000) NULL,
	[DefaultValue] [nvarchar](100) NULL,
	[Setting] [nvarchar](1000) NULL,
	[EnableNull] [bit] NULL,
	[EnableSearch] [bit] NULL,
	[IsUsing] [bit] NULL,
	[IsSystem] [bit] NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_Base__6B232965489AC854] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_C_Common](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ContID] [int] NOT NULL,
 CONSTRAINT [PK__cms_C_Co__6B23296544CA3770] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_C_FileDown](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ContID] [int] NOT NULL,
	[FileDownPath] [nvarchar](100) NULL,
	[test] [nvarchar](50) NULL,
 CONSTRAINT [PK__cms_C_Fi__6B2329653D2915A8] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_C_Photo](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ContID] [int] NOT NULL,
	[Gallery] [nvarchar](50) NULL,
 CONSTRAINT [PK__cms_C_Ph__6B232965395884C4] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_C_Product](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ContID] [int] NOT NULL,
	[ProPhotos] [nvarchar](255) NULL,
	[ProDocument] [ntext] NULL,
 CONSTRAINT [PK__cms_C_Pr__6B2329653587F3E0] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_Comment](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ContID] [int] NOT NULL,
	[ReplyID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](1000) NOT NULL,
	[IPAddress] [nvarchar](30) NOT NULL,
	[IPArea] [nvarchar](50) NOT NULL,
	[IsAudit] [bit] NOT NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_Comm__6B23296531B762FC] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_CommentActiveLog](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[CommentID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[IPAddress] [nvarchar](30) NOT NULL,
	[IPArea] [nvarchar](100) NOT NULL,
	[IsZan] [bit] NOT NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_Comm__6B2329652DE6D218] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_Content](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[NodeID] [int] NOT NULL,
	[NodeName] [nvarchar](255) NOT NULL,
	[ModelID] [int] NOT NULL,
	[NodeExts] [nvarchar](255) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[SubTitle] [nvarchar](255) NULL,
	[Summary] [nvarchar](500) NULL,
	[Author] [nvarchar](50) NULL,
	[Editor] [nvarchar](50) NULL,
	[Source] [nvarchar](50) NULL,
	[SourceUrl] [nvarchar](100) NULL,
	[Content] [ntext] NULL,
	[ContentImage] [nvarchar](100) NULL,
	[Attachment] [nvarchar](100) NULL,
	[TagKey] [nvarchar](255) NULL,
	[RelateContent] [nvarchar](100) NULL,
	[SeoKey] [nvarchar](255) NULL,
	[SeoDescription] [nvarchar](255) NULL,
	[Hit] [int] NULL,
	[TemplateFile] [nvarchar](100) NULL,
	[CustomRecommend] [int] NULL,
	[IsTop] [bit] NULL,
	[IsRecommend] [bit] NULL,
	[IsNew] [bit] NULL,
	[LockPassword] [nvarchar](50) NULL,
	[Lang] [nvarchar](20) NULL,
	[Inputer] [nvarchar](50) NULL,
	[Sort] [int] NULL,
	[Status] [smallint] NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_Content] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_ContField](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ModelID] [int] NOT NULL,
	[FieldName] [nvarchar](50) NOT NULL,
	[FieldType] [nvarchar](30) NOT NULL,
	[DataType] [nvarchar](30) NOT NULL,
	[DataLength] [smallint] NOT NULL,
	[FieldAlias] [nvarchar](100) NOT NULL,
	[Tip] [nvarchar](255) NULL,
	[FieldDesc] [nvarchar](1000) NULL,
	[DefaultValue] [nvarchar](100) NULL,
	[Setting] [nvarchar](1000) NULL,
	[EnableNull] [bit] NULL,
	[EnableSearch] [bit] NULL,
	[IsUsing] [bit] NULL,
	[IsSystem] [bit] NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_Cont__6B23296522751F6C] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_ContModel](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ModelName] [nvarchar](50) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[ModelDesc] [nvarchar](1000) NULL,
	[IsUsing] [bit] NULL,
	[Creator] [nvarchar](50) NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_Cont] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_ContNodeExt](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[NodeID] [int] NOT NULL,
	[ContID] [int] NOT NULL,
 CONSTRAINT [PK_CMS_CONTNODEEXT] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_Feedback](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[RootID] [int] NOT NULL,
	[ReplyID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Content] [nvarchar](1000) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[IPAddress] [nvarchar](100) NULL,
	[IPArea] [nvarchar](255) NULL,
	[Sort] [int] NULL,
	[IsAudit] [bit] NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_Feed__6B2329651332DBDC] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_Links](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[LinkName] [nvarchar](50) NOT NULL,
	[LinkUrl] [nvarchar](100) NOT NULL,
	[LinkType] [nvarchar](10) NOT NULL,
	[LinkText] [nvarchar](100) NULL,
	[LinkImage] [nvarchar](255) NULL,
	[LinkFlash] [nvarchar](100) NULL,
	[IsAudit] [bit] NULL,
	[Sort] [int] NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_Node](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[NodeName] [nvarchar](255) NOT NULL,
	[NodeIdentifier] [nvarchar](255) NOT NULL,
	[ModelID] [int] NOT NULL,
	[ParentID] [int] NOT NULL,
	[ParentPath] [nvarchar](255) NOT NULL,
	[Depth] [int] NOT NULL,
	[ChildList] [nvarchar](1000) NOT NULL,
	[NodeImage] [nvarchar](255) NULL,
	[NodeBanner] [nvarchar](255) NULL,
	[SeoKey] [nvarchar](255) NULL,
	[SeoDescription] [nvarchar](255) NULL,
	[ItemPageSize] [smallint] NULL,
	[CustomLink] [nvarchar](255) NULL,
	[Setting] [nvarchar](1000) NULL,
	[Remark] [nvarchar](1000) NULL,
	[IsShowOnMenu] [bit] NULL,
	[IsShowOnNav] [bit] NULL,
	[IsTop] [bit] NULL,
	[IsRecommend] [bit] NULL,
	[IsNew] [bit] NULL,
	[Creator] [nvarchar](50) NULL,
	[Sort] [int] NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_Node] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_SiteTemplate](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[TemplateName] [nvarchar](50) NOT NULL,
	[ShowPic] [nvarchar](255) NOT NULL,
	[TemplatePath] [nvarchar](100) NOT NULL,
	[HomePage] [nvarchar](50) NULL,
	[TemplateDesc] [nvarchar](1000) NULL,
	[IsAudit] [bit] NULL,
	[IsExists] [bit] NULL,
	[Author] [nvarchar](50) NULL,
	[CopyRight] [nvarchar](255) NULL,
	[IsDefault] [bit] NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_Tags](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](50) NOT NULL,
	[TagUrl] [nvarchar](255) NULL,
	[TagIndex] [int] NULL,
	[Remark] [nvarchar](1000) NULL,
	[IsTop] [bit] NULL,
	[IsRecommend] [bit] NULL,
	[Sort] [int] NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_ThirdPartyLogin](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[LoginFrom] [nvarchar](50) NOT NULL,
	[UniqueCert] [nvarchar](100) NOT NULL,
	[BindUserID] [int] NOT NULL,
	[BindUserName] [nvarchar](50) NOT NULL,
	[AccessToken] [nvarchar](50) NOT NULL,
	[RefreshToken] [nvarchar](50) NOT NULL,
	[LoginTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_U_Person](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_User](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[GroupID] [int] NOT NULL,
	[LevelID] [int] NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Mobile] [nvarchar](50) NOT NULL,
	[Amount] [decimal](12, 2) NULL,
	[Integral] [int] NULL,
	[FileSpace] [int] NULL,
	[CertType] [nvarchar](50) NULL,
	[CertNo] [nvarchar](50) NULL,
	[NickName] [nvarchar](50) NULL,
	[RealName] [nvarchar](50) NULL,
	[Gender] [nvarchar](8) NULL,
	[Birthday] [date] NULL,
	[HeaderPhoto] [nvarchar](255) NULL,
	[CreditLine] [decimal](12, 2) NULL,
	[Area] [nvarchar](255) NULL,
	[Country] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[County] [nvarchar](50) NULL,
	[Address] [nvarchar](255) NULL,
	[PostCode] [nvarchar](50) NULL,
	[TelePhone] [nvarchar](30) NULL,
	[PayPassword] [nvarchar](255) NULL,
	[Remark] [nvarchar](1000) NULL,
	[IsThirdLoginReg] [bit] NULL,
	[Status] [tinyint] NULL,
	[Sort] [int] NULL,
	[LoginCount] [int] NULL,
	[LastLoginTime] [datetime] NULL,
	[LastLoginIP] [nvarchar](30) NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_User__6B232965787EE5A0] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_UserField](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupID] [int] NOT NULL,
	[FieldName] [nvarchar](50) NOT NULL,
	[FieldType] [nvarchar](30) NOT NULL,
	[DataType] [nvarchar](30) NOT NULL,
	[DataLength] [smallint] NOT NULL,
	[FieldAlias] [nvarchar](100) NOT NULL,
	[Tip] [nvarchar](255) NULL,
	[FieldDesc] [nvarchar](1000) NULL,
	[DefaultValue] [nvarchar](100) NULL,
	[Setting] [nvarchar](1000) NULL,
	[EnableNull] [bit] NULL,
	[IsUsing] [bit] NULL,
	[IsSystem] [bit] NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_User__6B23296574AE54BC] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_UserGroup](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[GroupDesc] [nvarchar](1000) NULL,
	[Sort] [int] NULL,
	[Creator] [nvarchar](50) NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_User] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_UserLevel](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[LevelName] [nvarchar](50) NOT NULL,
	[Integral] [int] NOT NULL,
	[Discount] [float] NOT NULL,
	[LevelDesc] [nvarchar](1000) NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_Vote](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Items] [nvarchar](2000) NOT NULL,
	[IsMultiChoice] [bit] NOT NULL,
	[IsAnonymous] [bit] NOT NULL,
	[IsAudit] [bit] NULL,
	[Lang] [nvarchar](20) NULL,
	[Remark] [nvarchar](1000) NULL,
	[Sort] [int] NULL,
	[Creator] [nvarchar](50) NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_Vote__6B232965693CA210] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [cms_VoteLog](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[VoteID] [int] NOT NULL,
	[VoteItemID] [nvarchar](100) NOT NULL,
	[VoteItemOption] [nvarchar](500) NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[IpAddress] [nvarchar](30) NULL,
	[IpArea] [nvarchar](50) NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__cms_Vote__6B232965619B8048] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Account](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Roles] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[IsSystem] [bit] NULL,
	[LoginCount] [int] NULL,
	[LastLoginIP] [nvarchar](30) NULL,
	[LastLoginArea] [nvarchar](50) NULL,
	[LastLoginTime] [datetime] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_BaseConfig](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[SiteName] [nvarchar](100) NOT NULL,
	[SiteLogo] [nvarchar](255) NULL,
	[SiteBanner] [nvarchar](255) NULL,
	[SiteDomain] [nvarchar](100) NULL,
	[CopyRight] [nvarchar](100) NULL,
	[IcpNo] [nvarchar](100) NULL,
	[DefaultLang] [nvarchar](20) NULL,
	[EnabledMobile] [bit] NULL,
	[BrowseType] [nvarchar](20) NULL,
	[UrlRewriteExt] [nvarchar](5) NULL,
	[GlobalPageSize] [smallint] NULL,
	[IsCreateStaticHTML] [bit] NULL,
	[HtmlNodeFileRule] [nvarchar](100) NULL,
	[HtmlFileRule] [nvarchar](100) NULL,
	[HtmlFileExt] [nvarchar](50) NULL,
	[UserNameType] [nvarchar](20) NULL,
	[UserNameRule] [nvarchar](100) NULL,
	[SysUserName] [nvarchar](255) NULL,
	[CertType] [nvarchar](20) NULL,
	[RegAgreement] [ntext] NULL,
	[RegGiveIntegral] [int] NULL,
	[TgIntegral] [int] NULL,
	[TryLoginTimes] [smallint] NULL,
	[CookieTime] [nvarchar](20) NULL,
	[VerifycodeForReg] [bit] NULL,
	[VerifycodeForLogin] [bit] NULL,
	[VerifycodeForGetPwd] [bit] NULL,
	[GetPwdType] [nvarchar](20) NULL,
	[FileCapacity] [bigint] NULL,
	[ServMailAccount] [nvarchar](50) NULL,
	[ServMailUserName] [nvarchar](50) NULL,
	[ServMailUserPwd] [nvarchar](50) NULL,
	[ServMailSMTP] [nvarchar](50) NULL,
	[ServMailPort] [int] NULL,
	[ServMailIsSSL] [bit] NULL,
	[ReciverEMail] [nvarchar](50) NULL,
	[SMSClass] [nvarchar](50) NULL,
	[SMSUrl] [nvarchar](255) NULL,
	[SMSUId] [nvarchar](50) NULL,
	[SMSPwd] [nvarchar](50) NULL,
	[EnableFileUpload] [bit] NULL,
	[EnableAliyunOSS] [bit] NULL,
	[EnableUploadExt] [nvarchar](100) NULL,
	[UploadSizeLimit] [int] NULL,
	[UploadLimit] [int] NULL,
	[UploadSaveRule] [nvarchar](100) NULL,
	[UploadImgWidthLimit] [int] NULL,
	[UploadImgHeightLimit] [int] NULL,
	[ThumbSize] [nvarchar](30) NULL,
	[ThumbModel] [nvarchar](10) NULL,
	[WaterMarkPosition] [tinyint] NULL,
	[WaterMarkType] [nvarchar](10) NULL,
	[WaterMarkText] [nvarchar](100) NULL,
	[WaterMarkTextSize] [smallint] NULL,
	[WaterMarkTextFont] [nvarchar](30) NULL,
	[WaterMarkTextColor] [nvarchar](20) NULL,
	[WaterMarkImage] [nvarchar](100) NULL,
	[WaterMarkAlpha] [float] NULL,
	[AliyunOSSEnabled] [bit] NULL,
	[SEOKey] [nvarchar](255) NULL,
	[SEODescription] [nvarchar](255) NULL,
	[BadWords] [nvarchar](1000) NULL,
	[BWReplaceWord] [nvarchar](255) NULL,
	[SiteCapacity] [bigint] NULL,
	[VisitRec] [bit] NULL,
	[AllowOutPost] [bit] NULL,
	[IsCompressHtml] [bit] NULL,
	[Theme] [nvarchar](50) NULL,
	[DefaultHtmlEditor] [nvarchar](50) NOT NULL,
	[STATLink] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Catalog](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[CatalogName] [nvarchar](50) NOT NULL,
	[CatalogCode] [nvarchar](50) NOT NULL,
	[ImagePath] [nvarchar](100) NULL,
	[IsSystem] [bit] NULL,
	[Remark] [nvarchar](1000) NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_DictItem](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[DictID] [int] NOT NULL,
	[KeyName] [nvarchar](50) NOT NULL,
	[KeyValue] [nvarchar](100) NULL,
	[Sort] [int] NULL,
	[IsUsing] [bit] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Dicts](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[DictName] [nvarchar](50) NOT NULL,
	[DictDesc] [nvarchar](100) NOT NULL,
	[Sort] [int] NULL,
	[IsUsing] [bit] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_EventLog](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [char](30) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[IPAddress] [nvarchar](30) NOT NULL,
	[IPArea] [nvarchar](100) NOT NULL,
	[EventInfo] [nvarchar](2000) NOT NULL,
	[EventType] [smallint] NOT NULL,
	[LoginFailCount] [smallint] NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__sys_Even__6B23296546E78A0C] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_FileUpload](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[FolderID] [int] NOT NULL,
	[FileName] [nvarchar](100) NOT NULL,
	[FileExt] [nvarchar](10) NOT NULL,
	[FileSize] [int] NOT NULL,
	[LocalPath] [nvarchar](255) NULL,
	[VirtualFilePath] [nvarchar](255) NOT NULL,
	[Thumb] [nvarchar](255) NOT NULL,
	[OriginalPath] [nvarchar](255) NOT NULL,
	[UserType] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[DownloadCount] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__sys_File__6B2329654316F928] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Folder](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[FolderName] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](2000) NULL,
	[Sort] [int] NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_IPStrategy](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[IPAddress] [nvarchar](100) NOT NULL,
	[Strategy] [nvarchar](10) NOT NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__sys_IPSt__6B2329653B75D760] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Message](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[Receiver] [nvarchar](50) NOT NULL,
	[MsgBody] [nvarchar](1000) NOT NULL,
	[IsRead] [bit] NULL,
	[ReadTime] [datetime] NULL,
	[HasSend] [bit] NULL,
	[SendTime] [datetime] NULL,
	[Lang] [nvarchar](20) NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__sys_Mess__6B23296533D4B598] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Module](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[CatalogID] [int] NOT NULL,
	[ModuleName] [nvarchar](50) NOT NULL,
	[ModuleCode] [nvarchar](50) NOT NULL,
	[FilePath] [nvarchar](255) NOT NULL,
	[ImagePath] [nvarchar](255) NULL,
	[Remark] [nvarchar](1000) NULL,
	[IsSystem] [bit] NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Operate](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NOT NULL,
	[OperateName] [nvarchar](50) NOT NULL,
	[OperateCode] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Purview](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[ModuleID] [int] NOT NULL,
	[OperateCode] [nvarchar](50) NOT NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Role](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](1000) NULL,
	[IsSystem] [bit] NULL,
	[IsManager] [bit] NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_SendRecord](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[SenderType] [nvarchar](20) NOT NULL,
	[MsgType] [nvarchar](30) NOT NULL,
	[MsgBody] [nvarchar](2000) NOT NULL,
	[ValidateCode] [nvarchar](10) NULL,
	[ReciverName] [nvarchar](50) NULL,
	[ReciverMedia] [nvarchar](255) NULL,
	[Status] [tinyint] NULL,
	[ReturnMsg] [nvarchar](100) NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__sys_SMS__6B232965108B795B] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Setting](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[CateID] [int] NOT NULL,
	[KeyName] [nvarchar](50) NOT NULL,
	[KeyValue] [nvarchar](2000) NOT NULL,
	[KeyDesc] [nvarchar](255) NULL,
	[Tip] [nvarchar](100) NULL,
	[ControlType] [nvarchar](20) NULL,
	[DataType] [nvarchar](50) NULL,
	[DataLength] [smallint] NULL,
	[DefaultValue] [nvarchar](255) NULL,
	[Setting] [nvarchar](2000) NULL,
	[Sort] [int] NULL,
	[IsUsing] [bit] NULL,
	[IsSystem] [bit] NULL,
	[AutoTimeStamp] [datetime] NULL,
 CONSTRAINT [PK__sys_Sett__6B232965182C9B23] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_SettingCategory](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[CateName] [nvarchar](50) NOT NULL,
	[CateDesc] [nvarchar](100) NULL,
	[Sort] [int] NULL,
	[IsUsing] [bit] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_SMSTemplate](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[TemplName] [nvarchar](50) NOT NULL,
	[TemplTitle] [nvarchar](100) NOT NULL,
	[TemplCode] [nvarchar](50) NOT NULL,
	[TemplBody] [nvarchar](255) NOT NULL,
	[TemplKeys] [nvarchar](255) NOT NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Ver](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[SoftName] [nvarchar](50) NOT NULL,
	[LicTimeStart] [nvarchar](100) NOT NULL,
	[LicTimeEnd] [nvarchar](100) NOT NULL,
	[Ver] [nvarchar](10) NOT NULL,
	[VerCodeNum] [int] NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[Company] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[PostCode] [nvarchar](10) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Remark] [nvarchar](50) NULL,
	[LastUpdateTime] [datetime] NULL,
 CONSTRAINT [PK_sys_Ver] PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sys_Visitor](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[IPAddress] [nvarchar](50) NOT NULL,
	[OPSystem] [nvarchar](100) NULL,
	[CustomerLang] [nvarchar](100) NULL,
	[Navigator] [nvarchar](100) NULL,
	[Resolution] [nvarchar](100) NULL,
	[UserAgent] [nvarchar](255) NULL,
	[IsMobileDevice] [bit] NULL,
	[IsSupportActiveX] [bit] NULL,
	[IsSupportCookie] [bit] NULL,
	[IsSupportJavascript] [bit] NULL,
	[IsSupportJavaApplets] [bit] NULL,
	[NETVer] [nvarchar](100) NULL,
	[IsCrawler] [bit] NULL,
	[Engine] [nvarchar](100) NULL,
	[KeyWord] [nvarchar](255) NULL,
	[ApproachUrl] [nvarchar](1000) NULL,
	[VPage] [nvarchar](1000) NULL,
	[GETParameter] [nvarchar](2000) NULL,
	[POSTParameter] [text] NULL,
	[CookieParameter] [nvarchar](2000) NULL,
	[ErrMessage] [nvarchar](2000) NULL,
	[StackTrace] [ntext] NULL,
	[Lang] [nvarchar](10) NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [weixin_AutoRly](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[RlyType] [nvarchar](30) NOT NULL,
	[MsgKey] [nvarchar](50) NOT NULL,
	[MsgText] [nvarchar](2000) NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[MediaPath] [nvarchar](255) NULL,
	[LinkUrl] [nvarchar](255) NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [weixin_WxMenu](
	[AutoID] [int] IDENTITY(1,1) NOT NULL,
	[RootID] [int] NOT NULL,
	[ParentID] [int] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[EventKey] [nvarchar](50) NOT NULL,
	[Url] [nvarchar](255) NOT NULL,
	[ChildCount] [smallint] NOT NULL,
	[ChildIDs] [nvarchar](50) NOT NULL,
	[Sort] [int] NULL,
	[AutoTimeStamp] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [cms_BaseField] ON 

INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (1, 1, N'Content', N'Title', N'SingleText', N'nvarchar', 255, N'标题', N'请输入标题 (必填√)', N'内容标题', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 1, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (2, 1, N'Content', N'SubTitle', N'SingleText', N'nvarchar', 255, N'副标题', N'', N'内容副标题', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 2, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (3, 1, N'Content', N'Summary', N'MultipleText', N'nvarchar', 500, N'摘要', N'内容的简要描述', N'内容摘要', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 3, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (4, 1, N'Content', N'TagKey', N'SingleText', N'nvarchar', 50, N'标签', N'', N'标签', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 10, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (5, 1, N'Content', N'Author', N'SingleText', N'nvarchar', 50, N'作者', N'', N'作者', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 4, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (6, 1, N'Content', N'Editor', N'SingleText', N'nvarchar', 50, N'编辑', N'', N'编辑', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 5, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (7, 1, N'Content', N'Source', N'SingleText', N'nvarchar', 50, N'来源', N'', N'来源', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 6, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (8, 1, N'Content', N'SourceUrl', N'SingleText', N'nvarchar', 100, N'来源地址', N'', N'来源地址', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Url","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 7, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (10, 1, N'Content', N'Content', N'MultipleHtml', N'ntext', 50, N'正文内容', N'', N'正文内容', N'', N'{"ControlWidth":98,"ControlHeight":350,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 8, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (13, 1, N'Content', N'ContentImage', N'Picture', N'nvarchar', 255, N'图片地址', N'', N'图片地址', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 11, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (14, 1, N'Content', N'AutoTimeStamp', N'DateTime', N'datetime', 30, N'添加时间', N'', N'添加时间', N'', N'{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 21, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (16, 1, N'Content', N'Hit', N'SingleText', N'nvarchar', 10, N'点击率', N'', N'点击率', N'0', N'{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 18, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (17, 1, N'Content', N'Sort', N'SingleText', N'nvarchar', 10, N'排序号', N'', N'排序号', N'999', N'{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 19, CAST(N'2012-08-22T22:00:49.533' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (18, 1, N'Content', N'SeoKey', N'MultipleText', N'nvarchar', 255, N'搜索关键字', N'多个关键字用英文逗号(,)分隔', N'搜索关键字', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 12, CAST(N'2012-08-24T12:50:35.420' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (20, 1, N'Content', N'SeoDescription', N'MultipleText', N'nvarchar', 255, N'搜索描述', N'', N'搜索描述', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 13, CAST(N'2012-08-24T12:50:38.543' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (22, 1, N'Content', N'IsTop', N'CheckBox', N'nvarchar', 10, N'是否置顶', N'', N'是否置顶', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 15, CAST(N'2012-08-24T12:52:59.640' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (24, 1, N'Content', N'IsRecommend', N'CheckBox', N'nvarchar', 10, N'是否推荐', N'', N'是否推荐', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 1, 1, 16, CAST(N'2012-08-24T12:53:03.153' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (26, 1, N'Content', N'Attachment', N'MultiPicture', N'nvarchar', 100, N'附件', N'', N'附件', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 14, CAST(N'2014-04-07T15:37:01.763' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (28, 1, N'Content', N'IsNew', N'CheckBox', N'nvarchar', 10, N'是否最新', N'', N'是否最新', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 17, CAST(N'2012-08-24T12:53:03.000' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (52, 1, N'User', N'RealName', N'SingleText', N'nvarchar', 50, N'真实姓名', N'', N'真实姓名', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 1, CAST(N'2012-09-04T09:54:06.270' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (53, 1, N'User', N'Gender', N'RadioButton', N'nvarchar', 10, N'性别', N'', N'性别', N'男', N'{"ControlWidth":100,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"男,女"}', 1, 0, 1, 1, 2, CAST(N'2012-09-04T09:54:29.893' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (54, 1, N'User', N'Birthday', N'DateTime', N'datetime', 20, N'出生日期', N'', N'出生日期', N'', N'{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":true,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 3, CAST(N'2012-09-04T09:55:09.580' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (55, 1, N'User', N'NickName', N'SingleText', N'nvarchar', 50, N'昵称', N'', N'昵称', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 4, CAST(N'2012-09-04T09:55:37.300' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (56, 1, N'User', N'HeaderPhoto', N'Picture', N'nvarchar', 100, N'头像', N'', N'头像', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 5, CAST(N'2012-09-04T09:56:01.880' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (57, 1, N'User', N'CreditLine', N'SingleText', N'nvarchar', 20, N'信用度', N'', N'信用度', N'0', N'{"ControlWidth":100,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 6, CAST(N'2012-09-04T09:56:18.987' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (58, 1, N'User', N'Country', N'SingleText', N'nvarchar', 50, N'国家', N'', N'国家', N'中国', N'{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 7, CAST(N'2012-09-04T09:57:33.567' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (61, 1, N'User', N'Address', N'SingleText', N'nvarchar', 255, N'街道地址', N'', N'街道地址', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 15, CAST(N'2012-09-04T09:58:04.130' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (62, 1, N'User', N'PostCode', N'SingleText', N'nvarchar', 10, N'邮编', N'', N'邮编', N'', N'{"ControlWidth":100,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 16, CAST(N'2012-09-04T09:58:12.957' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (63, 1, N'User', N'TelePhone', N'SingleText', N'nvarchar', 30, N'家庭电话', N'', N'家庭电话', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 17, CAST(N'2012-09-04T09:58:24.783' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (64, 1, N'User', N'Remark', N'MultipleText', N'nvarchar', 1000, N'备注', N'', N'备注', N'', N'{"ControlWidth":300,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 18, CAST(N'2012-09-04T09:58:53.160' AS DateTime))
INSERT [cms_BaseField] ([AutoID], [ModelID], [ModelType], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (66, 1, N'Content', N'TemplateFile', N'TemplateFile', N'nvarchar', 100, N'模板文件', N'优先使用此模板', N'模板文件', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 15, CAST(N'2012-09-04T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [cms_BaseField] OFF
GO
SET IDENTITY_INSERT [cms_ContField] ON 

INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (1, 1, N'Title', N'SingleText', N'nvarchar', 255, N'标题', N'', N'内容标题', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 1, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (2, 1, N'SubTitle', N'SingleText', N'nvarchar', 255, N'副标题', N'', N'内容副标题', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 2, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (3, 1, N'Summary', N'MultipleText', N'nvarchar', 500, N'摘要', N'内容的简要描述', N'内容摘要', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 3, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (4, 1, N'TagKey', N'SingleText', N'nvarchar', 50, N'标签', N'', N'标签', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 10, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (5, 1, N'Author', N'SingleText', N'nvarchar', 50, N'作者', N'', N'作者', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 4, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (6, 1, N'Editor', N'SingleText', N'nvarchar', 50, N'编辑', N'', N'编辑', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 5, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (7, 1, N'Source', N'SingleText', N'nvarchar', 50, N'来源', N'', N'来源', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 6, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (8, 1, N'SourceUrl', N'SingleText', N'nvarchar', 100, N'来源地址', N'', N'来源地址', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Url","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 7, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (9, 1, N'Content', N'MultipleHtml', N'ntext', 50, N'正文内容', N'', N'正文内容', N'', N'{"ControlWidth":98,"ControlHeight":350,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 8, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (10, 1, N'ContentImage', N'Picture', N'nvarchar', 100, N'图片地址', N'', N'图片地址', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 11, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (11, 1, N'AutoTimeStamp', N'DateTime', N'datetime', 30, N'添加时间', N'', N'添加时间', N'', N'{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd HH:mm:ss","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 21, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (13, 1, N'Hit', N'SingleText', N'nvarchar', 10, N'点击率', N'', N'点击率', N'0', N'{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 18, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (14, 1, N'Sort', N'SingleText', N'nvarchar', 10, N'排序号', N'', N'排序号', N'999', N'{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 19, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (15, 1, N'SeoKey', N'MultipleText', N'nvarchar', 255, N'搜索关键字', N'多个关键字用英文逗号(,)分隔', N'搜索关键字', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 12, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (16, 1, N'SeoDescription', N'MultipleText', N'nvarchar', 255, N'搜索描述', N'', N'搜索描述', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 13, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (17, 1, N'IsTop', N'CheckBox', N'nvarchar', 10, N'是否置顶', N'', N'是否置顶', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 15, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (18, 1, N'IsRecommend', N'CheckBox', N'nvarchar', 10, N'是否推荐', N'', N'是否推荐', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 16, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (19, 1, N'Attachment', N'MultiPicture', N'nvarchar', 255, N'附件', N'', N'附件', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 14, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (20, 1, N'IsNew', N'CheckBox', N'nvarchar', 10, N'是否最新', N'', N'是否最新', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 17, CAST(N'2014-10-29T16:00:31.200' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (21, 2, N'Title', N'SingleText', N'nvarchar', 255, N'标题', N'请输入标题 (必填√)', N'内容标题', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 1, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (22, 2, N'SubTitle', N'SingleText', N'nvarchar', 255, N'副标题', N'', N'内容副标题', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 2, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (23, 2, N'Summary', N'MultipleText', N'nvarchar', 500, N'地址', N'', N'内容摘要', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 2, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (24, 2, N'TagKey', N'SingleText', N'nvarchar', 50, N'标签', N'', N'标签', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 10, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (25, 2, N'Author', N'SingleText', N'nvarchar', 50, N'作者', N'', N'作者', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 4, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (26, 2, N'Editor', N'SingleText', N'nvarchar', 50, N'编辑', N'', N'编辑', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 5, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (27, 2, N'Source', N'SingleText', N'nvarchar', 50, N'来源', N'', N'来源', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 6, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (28, 2, N'SourceUrl', N'SingleText', N'nvarchar', 100, N'来源地址', N'', N'来源地址', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Url","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 7, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (29, 2, N'Content', N'MultipleHtml', N'ntext', 50, N'正文内容', N'', N'正文内容', N'', N'{"ControlWidth":98,"ControlHeight":350,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 4, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (30, 2, N'ContentImage', N'Picture', N'nvarchar', 100, N'封面', N'', N'图片地址', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 3, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (31, 2, N'AutoTimeStamp', N'DateTime', N'datetime', 30, N'添加时间', N'', N'添加时间', N'', N'{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 21, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (33, 2, N'Hit', N'SingleText', N'nvarchar', 10, N'点击率', N'', N'点击率', N'0', N'{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 18, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (34, 2, N'Sort', N'SingleText', N'nvarchar', 10, N'排序号', N'', N'排序号', N'999', N'{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 19, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (35, 2, N'SeoKey', N'MultipleText', N'nvarchar', 255, N'搜索关键字', N'多个关键字用英文逗号(,)分隔', N'搜索关键字', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 12, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (36, 2, N'SeoDescription', N'MultipleText', N'nvarchar', 255, N'搜索描述', N'', N'搜索描述', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 13, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (37, 2, N'IsTop', N'CheckBox', N'nvarchar', 10, N'是否置顶', N'', N'是否置顶', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 15, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (38, 2, N'IsRecommend', N'CheckBox', N'nvarchar', 10, N'是否推荐', N'', N'是否推荐', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 16, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (39, 2, N'Attachment', N'MultiPicture', N'nvarchar', 100, N'附件', N'', N'附件', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 14, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (40, 2, N'IsNew', N'CheckBox', N'nvarchar', 10, N'是否最新', N'', N'是否最新', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 17, CAST(N'2014-10-29T16:05:57.357' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (41, 3, N'Title', N'SingleText', N'nvarchar', 255, N'标题', N'请输入标题 (必填√)', N'内容标题', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 1, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (42, 3, N'SubTitle', N'SingleText', N'nvarchar', 255, N'副标题', N'', N'内容副标题', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 2, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (43, 3, N'Summary', N'MultipleText', N'nvarchar', 500, N'摘要', N'内容的简要描述', N'内容摘要', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 3, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (44, 3, N'TagKey', N'SingleText', N'nvarchar', 50, N'标签', N'', N'标签', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 10, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (45, 3, N'Author', N'SingleText', N'nvarchar', 50, N'作者', N'', N'作者', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 4, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (46, 3, N'Editor', N'SingleText', N'nvarchar', 50, N'编辑', N'', N'编辑', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 5, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (47, 3, N'Source', N'SingleText', N'nvarchar', 50, N'来源', N'', N'来源', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 6, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (48, 3, N'SourceUrl', N'SingleText', N'nvarchar', 100, N'来源地址', N'', N'来源地址', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Url","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 7, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (49, 3, N'Content', N'MultipleHtml', N'ntext', 50, N'正文内容', N'', N'正文内容', N'', N'{"ControlWidth":98,"ControlHeight":350,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 8, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (50, 3, N'ContentImage', N'Picture', N'nvarchar', 100, N'图片地址', N'', N'图片地址', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 11, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (51, 3, N'AutoTimeStamp', N'DateTime', N'datetime', 30, N'添加时间', N'', N'添加时间', N'', N'{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 21, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (52, 3, N'TemplateFile', N'TemplateFile', N'nvarchar', 100, N'模板文件', N'', N'模板文件', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 15, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (53, 3, N'Hit', N'SingleText', N'nvarchar', 10, N'点击率', N'', N'点击率', N'0', N'{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 18, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (54, 3, N'Sort', N'SingleText', N'nvarchar', 10, N'排序号', N'', N'排序号', N'999', N'{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 19, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (55, 3, N'SeoKey', N'MultipleText', N'nvarchar', 255, N'搜索关键字', N'多个关键字用英文逗号(,)分隔', N'搜索关键字', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 12, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (56, 3, N'SeoDescription', N'MultipleText', N'nvarchar', 255, N'搜索描述', N'', N'搜索描述', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 13, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (57, 3, N'IsTop', N'DropDownList', N'nvarchar', 10, N'是否置顶', N'', N'是否置顶', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 15, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (58, 3, N'IsRecommend', N'DropDownList', N'nvarchar', 10, N'是否推荐', N'', N'是否推荐', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 16, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (59, 3, N'Attachment', N'DateTime', N'nvarchar', 100, N'附件', N'', N'附件', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 14, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (60, 3, N'IsNew', N'DropDownList', N'nvarchar', 10, N'是否最新', N'', N'是否最新', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 17, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (61, 4, N'Title', N'SingleText', N'nvarchar', 255, N'标题', N'请输入标题 (必填√)', N'内容标题', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 1, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (62, 4, N'SubTitle', N'SingleText', N'nvarchar', 255, N'副标题', N'', N'内容副标题', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 2, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (63, 4, N'Summary', N'MultipleText', N'nvarchar', 500, N'摘要', N'内容的简要描述', N'内容摘要', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 3, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (64, 4, N'TagKey', N'SingleText', N'nvarchar', 50, N'标签', N'', N'标签', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 10, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (65, 4, N'Author', N'SingleText', N'nvarchar', 50, N'作者', N'', N'作者', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 4, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (66, 4, N'Editor', N'SingleText', N'nvarchar', 50, N'编辑', N'', N'编辑', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 5, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (67, 4, N'Source', N'SingleText', N'nvarchar', 50, N'来源', N'', N'来源', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 6, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (68, 4, N'SourceUrl', N'SingleText', N'nvarchar', 100, N'来源地址', N'', N'来源地址', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Url","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 7, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (69, 4, N'Content', N'MultipleHtml', N'ntext', 50, N'正文内容', N'', N'正文内容', N'', N'{"ControlWidth":98,"ControlHeight":350,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 8, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (70, 4, N'ContentImage', N'File', N'nvarchar', 100, N'图片地址', N'', N'图片地址', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 11, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (71, 4, N'AutoTimeStamp', N'DateTime', N'datetime', 30, N'添加时间', N'', N'添加时间', N'', N'{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 21, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (73, 4, N'Hit', N'SingleText', N'nvarchar', 10, N'点击率', N'', N'点击率', N'0', N'{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 18, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (74, 4, N'Sort', N'SingleText', N'nvarchar', 10, N'排序号', N'', N'排序号', N'999', N'{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 19, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (75, 4, N'SeoKey', N'MultipleText', N'nvarchar', 255, N'搜索关键字', N'多个关键字用英文逗号(,)分隔', N'搜索关键字', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 12, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (76, 4, N'SeoDescription', N'MultipleText', N'nvarchar', 255, N'搜索描述', N'', N'搜索描述', N'', N'{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 13, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (77, 4, N'IsTop', N'DropDownList', N'nvarchar', 10, N'是否置顶', N'', N'是否置顶', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 15, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (78, 4, N'IsRecommend', N'DropDownList', N'nvarchar', 10, N'是否推荐', N'', N'是否推荐', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 16, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (79, 4, N'Attachment', N'DateTime', N'nvarchar', 255, N'附件', N'', N'附件', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 14, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (80, 4, N'IsNew', N'DropDownList', N'nvarchar', 10, N'是否最新', N'', N'是否最新', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 17, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (81, 3, N'ProPhotos', N'MultiPicture', N'nvarchar', 255, N'产品相册', N'', N'', N'', N'{"ControlWidth":98,"ControlHeight":200,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 0, 15, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (82, 3, N'ProDocument', N'MultipleHtml', N'ntext', 50, N'产品手册', N'', N'', N'', N'{"ControlWidth":98,"ControlHeight":200,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 0, 16, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (83, 4, N'FileDownPath', N'File', N'nvarchar', 100, N'文件路径', N'', N'', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 0, 10, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (84, 1, N'TemplateFile', N'TemplateFile', N'nvarchar', 100, N'模板文件', N'优先使用此模板', N'模板文件', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 15, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (85, 2, N'TemplateFile', N'TemplateFile', N'nvarchar', 100, N'模板文件', N'优先使用此模板', N'模板文件', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 15, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (86, 4, N'TemplateFile', N'TemplateFile', N'nvarchar', 100, N'模板文件', N'优先使用此模板', N'模板文件', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 15, CAST(N'2014-10-29T16:06:26.967' AS DateTime))
INSERT [cms_ContField] ([AutoID], [ModelID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [EnableSearch], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (87, 2, N'Gallery', N'MultiPicture', N'nvarchar', 50, N'相册', N'', N'', N'', N'{"ControlWidth":100,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 0, 5, CAST(N'2020-01-13T15:25:43.597' AS DateTime))
SET IDENTITY_INSERT [cms_ContField] OFF
GO
SET IDENTITY_INSERT [cms_ContModel] ON 

INSERT [cms_ContModel] ([AutoID], [ModelName], [TableName], [ModelDesc], [IsUsing], [Creator], [Sort], [AutoTimeStamp]) VALUES (1, N'普通文章', N'cms_C_Common', N'基本模型', 1, N'superadmin', 1, CAST(N'2014-10-29T16:00:31.203' AS DateTime))
INSERT [cms_ContModel] ([AutoID], [ModelName], [TableName], [ModelDesc], [IsUsing], [Creator], [Sort], [AutoTimeStamp]) VALUES (2, N'图片文章', N'cms_C_Photo', N'', 1, N'admin', 2, CAST(N'2014-10-29T16:05:57.343' AS DateTime))
INSERT [cms_ContModel] ([AutoID], [ModelName], [TableName], [ModelDesc], [IsUsing], [Creator], [Sort], [AutoTimeStamp]) VALUES (3, N'产品展示', N'cms_C_Product', N'', 1, N'admin', 3, CAST(N'2014-10-29T16:06:26.970' AS DateTime))
INSERT [cms_ContModel] ([AutoID], [ModelName], [TableName], [ModelDesc], [IsUsing], [Creator], [Sort], [AutoTimeStamp]) VALUES (4, N'文件下载', N'cms_C_FileDown', N'', 1, N'admin', 4, CAST(N'2014-10-29T16:06:45.547' AS DateTime))
SET IDENTITY_INSERT [cms_ContModel] OFF
GO
SET IDENTITY_INSERT [cms_Links] ON 

INSERT [cms_Links] ([AutoID], [LinkName], [LinkUrl], [LinkType], [LinkText], [LinkImage], [LinkFlash], [IsAudit], [Sort], [Lang], [AutoTimeStamp]) VALUES (1, N'SinGooCMS官网', N'http://www.singoo.top', N'文字链接', N'', N'', N'', 1, 1, N'zh-cn', CAST(N'2021-04-12T22:38:20.900' AS DateTime))
SET IDENTITY_INSERT [cms_Links] OFF
GO
SET IDENTITY_INSERT [cms_UserField] ON 

INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (1, 1, N'RealName', N'SingleText', N'nvarchar', 50, N'真实姓名', N'', N'真实姓名', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (2, 1, N'Gender', N'RadioButton', N'nvarchar', 50, N'性别', N'', N'性别', N'男', N'{"ControlWidth":100,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"男,女"}', 1, 1, 1, 2, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (3, 1, N'Birthday', N'DateTime', N'datetime', 50, N'出生日期', N'', N'出生日期', N'', N'{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":true,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 3, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (4, 1, N'NickName', N'SingleText', N'nvarchar', 50, N'昵称', N'', N'昵称', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 4, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (5, 1, N'HeaderPhoto', N'Picture', N'nvarchar', 50, N'头像', N'', N'头像', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 5, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (6, 1, N'CreditLine', N'SingleText', N'nvarchar', 50, N'信用度', N'', N'信用度', N'0', N'{"ControlWidth":100,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 6, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (7, 1, N'Country', N'SingleText', N'nvarchar', 50, N'国家', N'', N'国家', N'中国', N'{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 7, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (8, 1, N'Area', N'SingleText', N'nvarchar', 255, N'省市地区', N'', N'区域', N'', N'{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 8, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (9, 1, N'Address', N'SingleText', N'nvarchar', 255, N'街道地址', N'', N'街道地址', N'', N'{"ControlWidth":360,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 15, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (10, 1, N'PostCode', N'SingleText', N'nvarchar', 10, N'邮编', N'', N'邮编', N'', N'{"ControlWidth":100,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 16, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (11, 1, N'TelePhone', N'SingleText', N'nvarchar', 50, N'家庭电话', N'', N'家庭电话', N'', N'{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 17, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
INSERT [cms_UserField] ([AutoID], [UserGroupID], [FieldName], [FieldType], [DataType], [DataLength], [FieldAlias], [Tip], [FieldDesc], [DefaultValue], [Setting], [EnableNull], [IsUsing], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (12, 1, N'Remark', N'MultipleText', N'nvarchar', 1000, N'备注', N'', N'备注', N'', N'{"ControlWidth":300,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 18, CAST(N'2017-11-01T16:33:28.633' AS DateTime))
SET IDENTITY_INSERT [cms_UserField] OFF
GO
SET IDENTITY_INSERT [cms_UserGroup] ON 

INSERT [cms_UserGroup] ([AutoID], [GroupName], [TableName], [GroupDesc], [Sort], [Creator], [AutoTimeStamp]) VALUES (1, N'个人会员', N'cms_U_Person', N'个人会员组', 999, N'admin', CAST(N'2017-11-01T16:33:28.377' AS DateTime))
SET IDENTITY_INSERT [cms_UserGroup] OFF
GO
SET IDENTITY_INSERT [cms_UserLevel] ON 

INSERT [cms_UserLevel] ([AutoID], [LevelName], [Integral], [Discount], [LevelDesc], [Sort], [AutoTimeStamp]) VALUES (1, N'初级会员', 0, 0, N'', 999, CAST(N'2012-08-15T23:16:04.490' AS DateTime))
INSERT [cms_UserLevel] ([AutoID], [LevelName], [Integral], [Discount], [LevelDesc], [Sort], [AutoTimeStamp]) VALUES (2, N'中级会员', 100, 1, N'', 2, CAST(N'2012-08-15T23:16:04.490' AS DateTime))
INSERT [cms_UserLevel] ([AutoID], [LevelName], [Integral], [Discount], [LevelDesc], [Sort], [AutoTimeStamp]) VALUES (3, N'高级会员', 1000, 1, N'', 3, CAST(N'2012-08-15T23:16:04.490' AS DateTime))
INSERT [cms_UserLevel] ([AutoID], [LevelName], [Integral], [Discount], [LevelDesc], [Sort], [AutoTimeStamp]) VALUES (4, N'银牌会员', 10000, 1, N'', 4, CAST(N'2012-08-15T23:16:04.490' AS DateTime))
INSERT [cms_UserLevel] ([AutoID], [LevelName], [Integral], [Discount], [LevelDesc], [Sort], [AutoTimeStamp]) VALUES (5, N'金牌会员', 100000, 0.95, N'', 5, CAST(N'2012-08-15T23:16:04.490' AS DateTime))
INSERT [cms_UserLevel] ([AutoID], [LevelName], [Integral], [Discount], [LevelDesc], [Sort], [AutoTimeStamp]) VALUES (6, N'钻石会员', 1000000, 0.8, N'', 6, CAST(N'2012-08-15T23:16:04.490' AS DateTime))
SET IDENTITY_INSERT [cms_UserLevel] OFF
GO
SET IDENTITY_INSERT [sys_Account] ON 

INSERT [sys_Account] ([AutoID], [AccountName], [Password], [Roles], [Email], [Mobile], [IsSystem], [LoginCount], [LastLoginIP], [LastLoginArea], [LastLoginTime], [AutoTimeStamp]) VALUES (1, N'superadmin', N'7189511f9463534d23edb965e211f3c490a3a1c48a72d54eadeb5927096d92823b3e298d1fa7d27cc54adbf7748fb806a9d72ea414a57569fc7abdec693ed76a', N'1', N'liqiang665@163.com', N'17788760902', 1, 171, N'127.0.0.1', N'本机地址 CZ88.NET', CAST(N'2021-04-12T22:35:03.657' AS DateTime), CAST(N'2012-07-30T17:02:23.500' AS DateTime))
INSERT [sys_Account] ([AutoID], [AccountName], [Password], [Roles], [Email], [Mobile], [IsSystem], [LoginCount], [LastLoginIP], [LastLoginArea], [LastLoginTime], [AutoTimeStamp]) VALUES (2, N'admin', N'7189511f9463534d23edb965e211f3c490a3a1c48a72d54eadeb5927096d92823b3e298d1fa7d27cc54adbf7748fb806a9d72ea414a57569fc7abdec693ed76a', N'2', N'16826375@qq.com', N'17788760902', 1, 193, N'127.0.0.1', N'本机地址 CZ88.NET', CAST(N'2021-03-26T11:44:51.797' AS DateTime), CAST(N'2021-04-12T22:36:02.027' AS DateTime))
INSERT [sys_Account] ([AutoID], [AccountName], [Password], [Roles], [Email], [Mobile], [IsSystem], [LoginCount], [LastLoginIP], [LastLoginArea], [LastLoginTime], [AutoTimeStamp]) VALUES (5, N'viewer', N'0b5f51f0bb18b598503524eed851d1dbf282c4c617bc47ba6a00565ba7a6e62cd1da82fe7ed46369a55367b26998a0b0b894d1f444bcdc9f857a40d25379585d', N'6', N'', N'', 0, 10, N'127.0.0.1', N'本机地址 CZ88.NET', CAST(N'2021-03-26T12:23:36.647' AS DateTime), CAST(N'2021-04-12T22:35:48.107' AS DateTime))
SET IDENTITY_INSERT [sys_Account] OFF
GO
SET IDENTITY_INSERT [sys_BaseConfig] ON 

INSERT [sys_BaseConfig] ([AutoID], [SiteName], [SiteLogo], [SiteBanner], [SiteDomain], [CopyRight], [IcpNo], [DefaultLang], [EnabledMobile], [BrowseType], [UrlRewriteExt], [GlobalPageSize], [IsCreateStaticHTML], [HtmlNodeFileRule], [HtmlFileRule], [HtmlFileExt], [UserNameType], [UserNameRule], [SysUserName], [CertType], [RegAgreement], [RegGiveIntegral], [TgIntegral], [TryLoginTimes], [CookieTime], [VerifycodeForReg], [VerifycodeForLogin], [VerifycodeForGetPwd], [GetPwdType], [FileCapacity], [ServMailAccount], [ServMailUserName], [ServMailUserPwd], [ServMailSMTP], [ServMailPort], [ServMailIsSSL], [ReciverEMail], [SMSClass], [SMSUrl], [SMSUId], [SMSPwd], [EnableFileUpload], [EnableAliyunOSS], [EnableUploadExt], [UploadSizeLimit], [UploadLimit], [UploadSaveRule], [UploadImgWidthLimit], [UploadImgHeightLimit], [ThumbSize], [ThumbModel], [WaterMarkPosition], [WaterMarkType], [WaterMarkText], [WaterMarkTextSize], [WaterMarkTextFont], [WaterMarkTextColor], [WaterMarkImage], [WaterMarkAlpha], [AliyunOSSEnabled], [SEOKey], [SEODescription], [BadWords], [BWReplaceWord], [SiteCapacity], [VisitRec], [AllowOutPost], [IsCompressHtml], [Theme], [DefaultHtmlEditor], [STATLink]) VALUES (1, N'SinGooCMS-Demo', N'/include/theme/h5/images/login-logo.png', N'', N'http://demo.singoo.top', N'copyright @ 2013', N'赣ICP备20009447号', N'', 1, N'HtmlRewrite', N'.html', 10, 1, N'/article/${nodedir}', N'/article/detail/${id}', N'.html', N'默认的', N'^[a-zA-Z][a-zA-Z0-9@_-]{3,19}', N'游客,管理员,超级管理员,admin,superadmin', N'普通验证码', N'<p>请输入注册协议</p>', 10, 50, 5, N'一周', 0, 0, 0, N'邮箱找回', 104857600, N'16826375@qq.com', N'16826375', N'singoocms', N'smtp.qq.com', 465, 1, N'', N'AliYunSMS', N'http://api.momingsms.com/', N'LTAI3REvaq4JDLTt', N'1DnnagtroDvcka91LOuaKrSCvnkV6b', 1, 0, N'.rar|.zip|.jpg|.jpeg|.png|.gif|.doc|.xls|.ppt|.wps|.txt|.swf|.flv|.wmv|.pdf', 20480, 102400, N'${year}${month}${day}${millisecond}${rnd}', 600, 400, N'400X280', N'Cut', 5, N'文字水印', N'SinGooCMS内容管理系统', 50, N'黑体', N'#ff0000', N'', 0.60000002384185791, 0, N'SinGooCMS内容管理系统', N'SinGooCMS内容管理系统', N'', N'[根据国家相关法律不予显示]', 1073741824, 0, 0, 1, N'h5', N'/Include/Plugin/ckeditor/', N'')
SET IDENTITY_INSERT [sys_BaseConfig] OFF
GO
SET IDENTITY_INSERT [sys_Catalog] ON 

INSERT [sys_Catalog] ([AutoID], [CatalogName], [CatalogCode], [ImagePath], [IsSystem], [Remark], [Sort], [AutoTimeStamp]) VALUES (1, N'内容管理', N'ContMger', N'', 1, N'', 1, CAST(N'2017-10-08T17:11:00.567' AS DateTime))
INSERT [sys_Catalog] ([AutoID], [CatalogName], [CatalogCode], [ImagePath], [IsSystem], [Remark], [Sort], [AutoTimeStamp]) VALUES (2, N'会员管理', N'UserMger', N'', 1, N'', 2, CAST(N'2017-10-08T17:11:00.567' AS DateTime))
INSERT [sys_Catalog] ([AutoID], [CatalogName], [CatalogCode], [ImagePath], [IsSystem], [Remark], [Sort], [AutoTimeStamp]) VALUES (3, N'移动端', N'MobMger', N'', 1, N'', 3, CAST(N'2017-10-08T17:11:00.567' AS DateTime))
INSERT [sys_Catalog] ([AutoID], [CatalogName], [CatalogCode], [ImagePath], [IsSystem], [Remark], [Sort], [AutoTimeStamp]) VALUES (4, N'微信端', N'WeixinMger', N'', 1, N'', 4, CAST(N'2017-10-08T17:11:00.567' AS DateTime))
INSERT [sys_Catalog] ([AutoID], [CatalogName], [CatalogCode], [ImagePath], [IsSystem], [Remark], [Sort], [AutoTimeStamp]) VALUES (5, N'广告管理', N'ADMger', N'', 1, N'', 5, CAST(N'2017-10-08T17:11:00.567' AS DateTime))
INSERT [sys_Catalog] ([AutoID], [CatalogName], [CatalogCode], [ImagePath], [IsSystem], [Remark], [Sort], [AutoTimeStamp]) VALUES (6, N'系统配置', N'ConfMger', N'', 1, N'', 9, CAST(N'2017-10-08T17:11:00.567' AS DateTime))
INSERT [sys_Catalog] ([AutoID], [CatalogName], [CatalogCode], [ImagePath], [IsSystem], [Remark], [Sort], [AutoTimeStamp]) VALUES (7, N'系统维护', N'SysMger', N'', 1, N'', 10, CAST(N'2017-10-08T17:11:00.567' AS DateTime))
SET IDENTITY_INSERT [sys_Catalog] OFF
GO
SET IDENTITY_INSERT [sys_DictItem] ON 

INSERT [sys_DictItem] ([AutoID], [DictID], [KeyName], [KeyValue], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (6, 2, N'Cert1', N'身份证', 1, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [sys_DictItem] ([AutoID], [DictID], [KeyName], [KeyValue], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (7, 2, N'Cert2', N'军官证', 3, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [sys_DictItem] ([AutoID], [DictID], [KeyName], [KeyValue], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (8, 2, N'Cert3', N'港澳通行证', 4, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [sys_DictItem] ([AutoID], [DictID], [KeyName], [KeyValue], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (9, 2, N'Cert4', N'护照', 2, 1, CAST(N'2014-03-16T10:20:32.130' AS DateTime))
INSERT [sys_DictItem] ([AutoID], [DictID], [KeyName], [KeyValue], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (10, 2, N'Cert5', N'其它证件', 5, 1, CAST(N'2014-03-16T10:20:47.423' AS DateTime))
INSERT [sys_DictItem] ([AutoID], [DictID], [KeyName], [KeyValue], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (11, 3, N'200元以下', N'<200', 1, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [sys_DictItem] ([AutoID], [DictID], [KeyName], [KeyValue], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (12, 3, N'200 ~ 300元', N'200-300', 2, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [sys_DictItem] ([AutoID], [DictID], [KeyName], [KeyValue], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (13, 3, N'301 ~ 500元', N'301-500', 3, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [sys_DictItem] ([AutoID], [DictID], [KeyName], [KeyValue], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (14, 3, N'501 ~ 800元', N'501-800', 4, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [sys_DictItem] ([AutoID], [DictID], [KeyName], [KeyValue], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (15, 3, N'801元以上', N'>801', 5, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [sys_DictItem] OFF
GO
SET IDENTITY_INSERT [sys_Dicts] ON 

INSERT [sys_Dicts] ([AutoID], [DictName], [DictDesc], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (2, N'CertType', N'证件类型', 1, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [sys_Dicts] ([AutoID], [DictName], [DictDesc], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (3, N'PriceRang', N'价格范围', 2, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [sys_Dicts] OFF
GO
SET IDENTITY_INSERT [sys_IPStrategy] ON 

INSERT [sys_IPStrategy] ([AutoID], [IPAddress], [Strategy], [AutoTimeStamp]) VALUES (4, N'127.0.0.1', N'ALLOW', CAST(N'2021-03-26T10:43:10.847' AS DateTime))
SET IDENTITY_INSERT [sys_IPStrategy] OFF
GO
SET IDENTITY_INSERT [sys_Module] ON 

INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (1, 1, N'栏目设置', N'NodeMger', N'Node/Index', N'', N'', 1, 1, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (2, 1, N'文章列表', N'ContentMger', N'Content/Index', N'', N'', 1, 2, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (3, 1, N'模型管理', N'ContentModelMger', N'ContModel/Index', N'', N'', 1, 3, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (4, 1, N'模板管理', N'TemplateMger', N'Template/Index', N'', N'', 1, 4, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (5, 1, N'文件参数', N'FileConfigSet', N'FileConfig/Index', N'', N'', 1, 7, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (6, 1, N'文件管理', N'FileMger', N'Upfiles/Index', N'', N'', 1, 5, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (7, 1, N'文件夹管理', N'FolderMger', N'Folder/Index', N'', N'', 1, 6, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (9, 2, N'会员列表', N'UserMger', N'UserMger/Index', N'', N'', 1, 1, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (10, 2, N'会员分组', N'UserGroupMger', N'UserGroup/Index', N'', N'', 1, 2, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (11, 2, N'会员等级', N'UserLevelMger', N'UserLevel/Index', N'', N'', 1, 3, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (12, 2, N'会员设置', N'UserSet', N'UserSet/Index', N'', N'', 1, 4, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (13, 2, N'账户明细', N'AmountOrIntegralDetail', N'AccDetail/Index', N'', N'', 1, 9, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (14, 2, N'信任登录', N'ThirdLoginMger', N'ThirdLogin/Index', N'', N'', 1, 11, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (15, 3, N'移动端设置', N'MobileClientSet', N'MobileSet/Index', N'', N'', 1, 1, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (16, 3, N'短信配置', N'SMSConfig', N'SMSConfig/Index', N'', N'', 1, 2, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (17, 4, N'公众号配置', N'WXConfig', N'WeixinMger/WXConfig', N'', N'', 1, 1, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (18, 4, N'关注回复', N'GuanZhuRlyMger', N'WeixinMger/Guanzhu', N'', N'', 1, 2, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (19, 4, N'默认回复', N'DefaultRlyMger', N'WeixinMger/DefRly', N'', N'', 1, 3, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (20, 4, N'关键字回复', N'MsgkeyRlyMger', N'KeyRly/Index', N'', N'', 1, 4, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (21, 4, N'自定义菜单', N'CustomMenuMger', N'CustomMenu/Index', N'', N'', 1, 5, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (22, 5, N'广告管理', N'ADMger', N'AdPlace/Index', N'', N'', 1, 1, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (23, 5, N'留言反馈', N'Feedback', N'Feedback/Index', N'', N'', 1, 2, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (24, 5, N'友情链接', N'FriendLink', N'FriendLink/Index', N'', N'', 1, 3, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (25, 6, N'基本配置', N'BaseConfig', N'Config/Index', N'', N'', 1, 1, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (26, 6, N'邮件服务', N'EmailService', N'Config/Mail', N'', N'', 1, 2, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (27, 6, N'搜索优化', N'GlobalSEO', N'Config/SiteSeo', N'', N'', 1, 3, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (29, 6, N'其它配置', N'OtherConfig', N'Config/Other', N'', N'', 1, 5, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (30, 6, N'自定义配置', N'CustomSetting', N'SettingCate/Index', N'', N'', 1, 8, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (31, 6, N'数据字典', N'DataDictionary', N'DataDict/Index', N'', N'', 1, 9, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (32, 7, N'菜单管理', N'MenuMger', N'Menu/Index', N'', N'', 1, 1, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (33, 7, N'角色管理', N'RoleMger', N'Role/Index', N'', N'', 1, 2, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (34, 7, N'账号管理', N'AccountMger', N'AccountMger/Index', N'', N'', 1, 3, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (35, 7, N'IP策略', N'IPStrategyMger', N'IPStrategy/Index', N'', N'', 1, 4, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (36, 7, N'数据备份', N'BackupAndRestore', N'SysMger/DataBackup', N'', N'', 1, 5, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (38, 7, N'访问日志 ', N'VisitorLogMger', N'VisitorLog/Index', N'', N'', 1, 7, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (39, 7, N'系统日志 ', N'SystemLogMger', N'SysLog/Index', N'', N'', 1, 8, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (40, 3, N'短信模板', N'SMSTemplateMger', N'SMSTemplate/Index', N'', N'', 1, 3, CAST(N'2017-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (41, 1, N'标签管理', N'TagsMger', N'Tags/Index', N'', N'', 1, 10, CAST(N'2017-11-07T20:00:32.923' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (43, 1, N'评论管理', N'CommentMger', N'CommentMger/Index', N'', N'', 1, 8, CAST(N'2020-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (45, 1, N'投票管理', N'VoteMger', N'VoteMger/Index', N'', N'', 1, 9, CAST(N'2020-10-08T17:11:08.360' AS DateTime))
INSERT [sys_Module] ([AutoID], [CatalogID], [ModuleName], [ModuleCode], [FilePath], [ImagePath], [Remark], [IsSystem], [Sort], [AutoTimeStamp]) VALUES (47, 2, N'站内消息', N'MessageMger', N'MessageMger/Index', N'', N'', 1, 10, CAST(N'2021-03-25T23:46:35.873' AS DateTime))
SET IDENTITY_INSERT [sys_Module] OFF
GO
SET IDENTITY_INSERT [sys_Operate] ON 

INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (1, 1, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (2, 2, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (3, 3, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (4, 4, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (5, 5, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (6, 6, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (7, 7, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (9, 9, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (10, 10, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (11, 11, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (12, 12, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (13, 13, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (14, 14, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (15, 15, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (16, 16, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (17, 17, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (18, 18, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (19, 19, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (20, 20, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (21, 21, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (22, 22, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (23, 23, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (24, 24, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (25, 25, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (26, 26, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (27, 27, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (29, 29, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (30, 30, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (31, 31, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (32, 32, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (33, 33, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (34, 34, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (35, 35, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (36, 36, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (38, 38, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (39, 39, N'查看', N'View', N'', 1, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (40, 1, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (41, 2, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (42, 3, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (43, 4, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (46, 7, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (48, 9, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (49, 10, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (50, 11, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (53, 14, N'配置', N'Configuration', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (59, 20, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (60, 21, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (61, 22, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (62, 23, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (63, 24, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (69, 30, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (70, 31, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (71, 32, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (72, 33, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (73, 34, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (74, 35, N'增加', N'Add', N'', 2, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (79, 1, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (80, 2, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (81, 3, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (82, 4, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (83, 5, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (85, 7, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (87, 9, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (88, 10, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (89, 11, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (90, 12, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (93, 15, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (94, 16, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (95, 17, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (96, 18, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (97, 19, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (98, 20, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (99, 21, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (100, 22, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (101, 23, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (102, 24, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (103, 25, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (104, 26, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (105, 27, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (107, 29, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (108, 30, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (109, 31, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (110, 32, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (111, 33, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (112, 34, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (113, 35, N'修改', N'Modify', N'', 3, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (118, 1, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (119, 2, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (120, 3, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (121, 4, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (123, 6, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (124, 7, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (126, 9, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (127, 10, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (128, 11, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (130, 13, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (137, 20, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (138, 21, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (139, 22, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
GO
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (140, 23, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (141, 24, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (147, 30, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (148, 31, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (149, 32, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (150, 33, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (151, 34, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (152, 35, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (153, 36, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (155, 38, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (156, 39, N'删除', N'Delete', N'', 4, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (157, 33, N'查看权限', N'ViewRolePermission', N'', 10, CAST(N'2021-03-24T00:00:00.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (158, 32, N'添加操作', N'AddOperator', N'', 10, CAST(N'2017-10-09T10:31:20.723' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (159, 34, N'设置账户角色', N'SetAccountRole', N'', 10, CAST(N'2017-10-09T10:32:21.300' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (160, 36, N'备份', N'Backup', N'', 10, CAST(N'2017-10-09T12:01:02.157' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (164, 40, N'查看', N'View', NULL, 1, CAST(N'2017-11-02T18:05:00.903' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (165, 40, N'增加', N'Add', NULL, 2, CAST(N'2017-11-02T18:05:00.903' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (166, 40, N'修改', N'Modify', NULL, 3, CAST(N'2017-11-02T18:05:00.903' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (167, 40, N'删除', N'Delete', NULL, 4, CAST(N'2017-11-02T18:05:00.903' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (168, 10, N'启用字段', N'SetEnabled', N'', 10, CAST(N'2017-11-03T11:07:44.203' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (169, 10, N'停用字段', N'SetUnEnabled', N'', 10, CAST(N'2017-11-03T11:08:01.327' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (172, 3, N'启用字段', N'SetEnabled', N'', 10, CAST(N'2017-11-07T18:25:31.877' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (173, 3, N'停用字段', N'SetUnEnabled', N'', 10, CAST(N'2017-11-07T18:25:46.127' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (174, 41, N'查看', N'View', NULL, 1, CAST(N'2017-11-07T20:00:54.977' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (175, 41, N'增加', N'Add', NULL, 2, CAST(N'2017-11-07T20:00:54.977' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (176, 41, N'修改', N'Modify', NULL, 3, CAST(N'2017-11-07T20:00:54.977' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (177, 41, N'删除', N'Delete', NULL, 4, CAST(N'2017-11-07T20:00:54.977' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (190, 37, N'查看', N'View', N'', 1, CAST(N'2018-08-22T15:57:46.370' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (191, 37, N'执行SQL语句', N'Query', N'', 10, CAST(N'2018-08-22T15:58:01.780' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (192, 43, N'查看', N'View', N'', 1, CAST(N'2021-03-10T16:13:43.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (193, 43, N'增加', N'Add', N'', 2, CAST(N'2021-03-10T16:13:43.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (194, 43, N'修改', N'Modify', N'', 3, CAST(N'2021-03-10T16:13:43.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (195, 43, N'删除', N'Delete', N'', 4, CAST(N'2021-03-10T16:13:43.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (196, 45, N'查看', N'View', N'', 1, CAST(N'2021-03-10T16:13:53.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (197, 45, N'增加', N'Add', N'', 2, CAST(N'2021-03-10T16:13:53.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (198, 45, N'修改', N'Modify', N'', 3, CAST(N'2021-03-10T16:13:53.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (199, 45, N'删除', N'Delete', N'', 4, CAST(N'2021-03-10T16:13:53.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (204, 1, N'栏目移动', N'NodeMove', N'', 5, CAST(N'2017-10-08T17:37:38.597' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (205, 2, N'移动到栏目', N'MoveToNode', N'', 5, CAST(N'2021-03-24T00:00:00.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (206, 2, N'还原', N'Restore', N'', 6, CAST(N'2021-03-24T12:06:18.953' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (207, 1, N'导入', N'Import', N'', 6, CAST(N'2021-03-24T12:33:38.137' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (208, 1, N'导出', N'Export', N'', 7, CAST(N'2021-03-24T12:33:53.307' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (209, 32, N'删除操作', N'DeleteOperator', N'', 11, CAST(N'2021-03-24T00:00:00.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (210, 33, N'设置权限', N'SetRolePermission', N'', 11, CAST(N'2021-03-24T00:00:00.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (211, 36, N'还原', N'Restore', N'', 11, CAST(N'2021-03-24T00:00:00.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (212, 4, N'设置默认模板', N'SetDefTmpl', N'', 10, CAST(N'2021-03-24T00:00:00.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (213, 4, N'查看模板文件', N'ViewTmplFile', N'', 11, CAST(N'2021-03-24T16:18:54.543' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (215, 4, N'创建模板文件', N'CreateTmplFile', N'', 12, CAST(N'2021-03-24T16:18:54.543' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (216, 4, N'修改模板文件', N'ModifyTmplFile', N'', 13, CAST(N'2021-03-24T16:18:54.543' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (217, 4, N'删除模板文件', N'DeleteTmplFile', N'', 14, CAST(N'2021-03-24T16:18:54.543' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (218, 14, N'启用或关闭', N'SetEnableOrClose', N'', 3, CAST(N'2021-03-24T00:00:00.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (219, 10, N'查看字段', N'ViewField', N'', 20, CAST(N'2021-03-24T16:44:00.747' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (220, 10, N'增加字段', N'AddField', N'', 21, CAST(N'2021-03-24T16:44:00.747' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (221, 10, N'修改字段', N'ModifyField', N'', 22, CAST(N'2021-03-24T16:44:00.747' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (222, 10, N'删除字段', N'DeleteField', N'', 23, CAST(N'2021-03-24T16:44:00.747' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (235, 3, N'查看字段', N'ViewField', N'', 20, CAST(N'2021-03-24T16:47:15.497' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (236, 3, N'增加字段', N'AddField', N'', 21, CAST(N'2021-03-24T16:47:15.497' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (237, 3, N'修改字段', N'ModifyField', N'', 22, CAST(N'2021-03-24T16:47:15.497' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (238, 3, N'删除字段', N'DeleteField', N'', 23, CAST(N'2021-03-24T16:47:15.497' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (239, 9, N'导出', N'Export', N'', 10, CAST(N'2021-03-24T16:58:08.753' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (240, 9, N'充值', N'Recharge', N'', 11, CAST(N'2021-03-24T17:00:00.047' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (241, 6, N'上传文件', N'Upload', N'', 2, CAST(N'2021-03-24T17:04:57.250' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (242, 21, N'更新客户端', N'UpdateClient', N'', 10, CAST(N'2021-03-24T17:34:32.270' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (243, 2, N'置顶', N'SetTop', N'', 10, CAST(N'2021-03-25T00:00:00.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (244, 2, N'推荐', N'SetRecommend', N'', 11, CAST(N'2021-03-25T00:00:00.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (245, 2, N'最新', N'SetNew', N'', 12, CAST(N'2021-03-25T00:00:00.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (246, 21, N'更新服务端', N'UpdateServer', N'', 11, CAST(N'2021-03-24T17:34:32.270' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (247, 6, N'归档', N'MoveToFolder', N'', 3, CAST(N'2021-03-24T17:04:57.250' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (248, 47, N'查看', N'View', N'', 999, CAST(N'2021-03-25T23:46:35.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (249, 47, N'增加', N'Add', N'', 999, CAST(N'2021-03-25T23:46:35.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (251, 47, N'删除', N'Delete', N'', 999, CAST(N'2021-03-25T23:46:35.000' AS DateTime))
INSERT [sys_Operate] ([AutoID], [ModuleID], [OperateName], [OperateCode], [Remark], [Sort], [AutoTimeStamp]) VALUES (264, 34, N'设置账户密码', N'SetAccountPwd', N'', 11, CAST(N'2021-03-24T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [sys_Operate] OFF
GO
SET IDENTITY_INSERT [sys_Purview] ON 

INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1317, 2, 1, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1318, 2, 1, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1319, 2, 1, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1320, 2, 1, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1321, 2, 1, N'NodeMove', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1322, 2, 1, N'Import', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1323, 2, 1, N'Export', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1324, 2, 2, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1325, 2, 2, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1326, 2, 2, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1327, 2, 2, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1328, 2, 2, N'MoveToNode', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1329, 2, 2, N'Restore', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1330, 2, 2, N'SetTop', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1331, 2, 2, N'SetRecommend', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1332, 2, 2, N'SetNew', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1333, 2, 3, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1334, 2, 3, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1335, 2, 3, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1336, 2, 3, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1337, 2, 3, N'SetEnabled', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1338, 2, 3, N'SetUnEnabled', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1339, 2, 3, N'ViewField', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1340, 2, 3, N'AddField', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1341, 2, 3, N'ModifyField', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1342, 2, 3, N'DeleteField', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1343, 2, 4, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1344, 2, 4, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1345, 2, 4, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1346, 2, 4, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1347, 2, 4, N'SetDefTmpl', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1348, 2, 4, N'ViewTmplFile', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1349, 2, 4, N'CreateTmplFile', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1350, 2, 4, N'ModifyTmplFile', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1351, 2, 4, N'DeleteTmplFile', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1352, 2, 6, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1353, 2, 6, N'Upload', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1354, 2, 6, N'MoveToFolder', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1355, 2, 6, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1356, 2, 7, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1357, 2, 7, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1358, 2, 7, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1359, 2, 7, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1360, 2, 5, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1361, 2, 5, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1362, 2, 43, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1363, 2, 43, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1364, 2, 43, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1365, 2, 43, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1366, 2, 45, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1367, 2, 45, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1368, 2, 45, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1369, 2, 45, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1370, 2, 41, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1371, 2, 41, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1372, 2, 41, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1373, 2, 41, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1374, 2, 9, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1375, 2, 9, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1376, 2, 9, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1377, 2, 9, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1378, 2, 9, N'Export', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1379, 2, 9, N'Recharge', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1380, 2, 10, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1381, 2, 10, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1382, 2, 10, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1383, 2, 10, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1384, 2, 10, N'SetEnabled', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1385, 2, 10, N'SetUnEnabled', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1386, 2, 10, N'ViewField', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1387, 2, 10, N'AddField', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1388, 2, 10, N'ModifyField', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1389, 2, 10, N'DeleteField', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1390, 2, 11, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1391, 2, 11, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1392, 2, 11, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1393, 2, 11, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1394, 2, 12, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1395, 2, 12, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1396, 2, 13, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1397, 2, 13, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1398, 2, 47, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1399, 2, 47, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1400, 2, 47, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1401, 2, 14, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1402, 2, 14, N'Configuration', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1403, 2, 14, N'SetEnableOrClose', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1404, 2, 15, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1405, 2, 15, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1406, 2, 16, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1407, 2, 16, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1408, 2, 40, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1409, 2, 40, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1410, 2, 40, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1411, 2, 40, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1412, 2, 17, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1413, 2, 17, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1414, 2, 18, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1415, 2, 18, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
GO
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1416, 2, 19, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1417, 2, 19, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1418, 2, 20, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1419, 2, 20, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1420, 2, 20, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1421, 2, 20, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1422, 2, 21, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1423, 2, 21, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1424, 2, 21, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1425, 2, 21, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1426, 2, 21, N'UpdateClient', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1427, 2, 21, N'UpdateServer', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1428, 2, 22, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1429, 2, 22, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1430, 2, 22, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1431, 2, 22, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1432, 2, 23, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1433, 2, 23, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1434, 2, 23, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1435, 2, 23, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1436, 2, 24, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1437, 2, 24, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1438, 2, 24, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1439, 2, 24, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1440, 2, 25, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1441, 2, 25, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1442, 2, 26, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1443, 2, 26, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1444, 2, 27, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1445, 2, 27, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1446, 2, 29, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1447, 2, 29, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1448, 2, 30, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1449, 2, 30, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1450, 2, 30, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1451, 2, 30, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1452, 2, 31, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1453, 2, 31, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1454, 2, 31, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1455, 2, 31, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1456, 2, 35, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1457, 2, 35, N'Add', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1458, 2, 35, N'Modify', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1459, 2, 35, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1460, 2, 36, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1461, 2, 36, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1462, 2, 36, N'Backup', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1463, 2, 36, N'Restore', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1464, 2, 38, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1465, 2, 38, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1466, 2, 39, N'View', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1467, 2, 39, N'Delete', CAST(N'2021-03-26T10:53:13.617' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1514, 6, 1, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1515, 6, 1, N'Add', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1516, 6, 1, N'Modify', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1517, 6, 2, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1518, 6, 2, N'Add', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1519, 6, 2, N'Modify', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1520, 6, 3, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1521, 6, 4, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1522, 6, 6, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1523, 6, 7, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1524, 6, 5, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1525, 6, 43, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1526, 6, 45, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1527, 6, 41, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1528, 6, 9, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1529, 6, 9, N'Add', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1530, 6, 9, N'Modify', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1531, 6, 10, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1532, 6, 11, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1533, 6, 12, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1534, 6, 13, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1535, 6, 47, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1536, 6, 14, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1537, 6, 15, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1538, 6, 16, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1539, 6, 40, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1540, 6, 17, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1541, 6, 18, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1542, 6, 19, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1543, 6, 20, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1544, 6, 21, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1545, 6, 22, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1546, 6, 23, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1547, 6, 24, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1548, 6, 25, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1549, 6, 26, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1550, 6, 27, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1551, 6, 29, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1552, 6, 30, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1553, 6, 31, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1554, 6, 32, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1555, 6, 33, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1556, 6, 34, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1557, 6, 35, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1558, 6, 36, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1559, 6, 38, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
INSERT [sys_Purview] ([AutoID], [RoleID], [ModuleID], [OperateCode], [AutoTimeStamp]) VALUES (1560, 6, 39, N'View', CAST(N'2021-03-26T12:24:26.490' AS DateTime))
SET IDENTITY_INSERT [sys_Purview] OFF
GO
SET IDENTITY_INSERT [sys_Role] ON 

INSERT [sys_Role] ([AutoID], [RoleName], [Remark], [IsSystem], [IsManager], [Sort], [AutoTimeStamp]) VALUES (1, N'超级管理员', N'系统固有角色,不可移除', 1, 1, 1, CAST(N'2012-06-27T15:55:19.547' AS DateTime))
INSERT [sys_Role] ([AutoID], [RoleName], [Remark], [IsSystem], [IsManager], [Sort], [AutoTimeStamp]) VALUES (2, N'内容管理员', N'cms内容管理系统默认管理员', 1, 1, 2, CAST(N'2014-06-30T11:35:46.297' AS DateTime))
INSERT [sys_Role] ([AutoID], [RoleName], [Remark], [IsSystem], [IsManager], [Sort], [AutoTimeStamp]) VALUES (6, N'内容查看人员', N'', 0, 0, 3, CAST(N'2021-03-18T14:49:55.457' AS DateTime))
SET IDENTITY_INSERT [sys_Role] OFF
GO
SET IDENTITY_INSERT [sys_Setting] ON 

INSERT [sys_Setting] ([AutoID], [CateID], [KeyName], [KeyValue], [KeyDesc], [Tip], [ControlType], [DataType], [DataLength], [DefaultValue], [Setting], [Sort], [IsUsing], [IsSystem], [AutoTimeStamp]) VALUES (20, 11, N'MailTemplateForResetPwd', N'<div>尊敬的用户${username}:<br />
<br />
您申请找回密码,如果不是您本人的操作,请删除此邮件.<br />
要使用新的密码,请使用以下链接重新设置密码.<br />
<a href="${getpwdurl}" target="_blank">${getpwdurl}</a><br />
(如果无法点击该URL链接地址,请将它复制并粘帖到浏览器的地址输入框,然后单击回车即可.该链接使用后将立即失效.)<br />
注意:请您在收到邮件1个小时内(${expiretime}前)使用,否则该链接将会失效.
<hr />
<div style="text-align:right">${sitename}<br />
${send_date}</div>
</div>', N'重置密码邮件', N'', N'MultipleHtml', N'ntext', 1000, N'', N'{"ControlWidth":98,"ControlHeight":300,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 40, 1, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [sys_Setting] ([AutoID], [CateID], [KeyName], [KeyValue], [KeyDesc], [Tip], [ControlType], [DataType], [DataLength], [DefaultValue], [Setting], [Sort], [IsUsing], [IsSystem], [AutoTimeStamp]) VALUES (23, 13, N'SendSMSValidateCode', N'尊敬的用户，您的校验码：${code}，请在15分钟内完成验证，切勿泄露于他人！', N'发送手机验证码', N'', N'MultipleText', N'ntext', 1000, N'', N'{"ControlWidth":600,"ControlHeight":100,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"","DataFromType":0}', 10, 1, 1, CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [sys_Setting] ([AutoID], [CateID], [KeyName], [KeyValue], [KeyDesc], [Tip], [ControlType], [DataType], [DataLength], [DefaultValue], [Setting], [Sort], [IsUsing], [IsSystem], [AutoTimeStamp]) VALUES (25, 11, N'IsSendMailForLY', N'', N'留言时发送邮件', N'', N'CheckBox', N'nvarchar', 50, N'', N'{"ControlWidth":600,"ControlHeight":100,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 31, 1, 1, CAST(N'2014-07-02T15:14:47.470' AS DateTime))
INSERT [sys_Setting] ([AutoID], [CateID], [KeyName], [KeyValue], [KeyDesc], [Tip], [ControlType], [DataType], [DataLength], [DefaultValue], [Setting], [Sort], [IsUsing], [IsSystem], [AutoTimeStamp]) VALUES (55, 11, N'ReciverEMail', N'', N'留言接收邮箱', N'', N'SingleText', N'nvarchar', 100, N'', N'{"ControlWidth":200,"ControlHeight":0,"TextMode":"Email","IsDataType":false,"DataFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 30, 1, 1, CAST(N'2015-10-12T10:51:47.530' AS DateTime))
INSERT [sys_Setting] ([AutoID], [CateID], [KeyName], [KeyValue], [KeyDesc], [Tip], [ControlType], [DataType], [DataLength], [DefaultValue], [Setting], [Sort], [IsUsing], [IsSystem], [AutoTimeStamp]) VALUES (56, 11, N'SendMailValidateCode', N'<p>尊敬的用户，您的校验码：${code}，请在15分钟内完成验证，切勿泄露于他人！</p>

<hr />
<div style="text-align:right">${sitename}<br />
${send_date}</div>', N'发送邮件验证码', N'', N'MultipleHtml', N'ntext', 1000, N'', N'{"ControlWidth":98,"ControlHeight":150,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 10, 1, 1, CAST(N'2020-06-22T10:46:30.867' AS DateTime))
INSERT [sys_Setting] ([AutoID], [CateID], [KeyName], [KeyValue], [KeyDesc], [Tip], [ControlType], [DataType], [DataLength], [DefaultValue], [Setting], [Sort], [IsUsing], [IsSystem], [AutoTimeStamp]) VALUES (57, 7, N'SendRegWelcome', N'尊敬的用户：${username}，欢迎您成为我们的会员，如有任何疑问请联系我们的客服人员，谢谢！', N'注册成功显示欢迎消息', N'', N'MultipleText', N'ntext', 500, N'', N'{"ControlWidth":600,"ControlHeight":150,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 999, 1, 0, CAST(N'2020-06-23T18:55:43.537' AS DateTime))
SET IDENTITY_INSERT [sys_Setting] OFF
GO
SET IDENTITY_INSERT [sys_SettingCategory] ON 

INSERT [sys_SettingCategory] ([AutoID], [CateName], [CateDesc], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (7, N'UserInfo', N'会员选项', 0, 1, CAST(N'2012-08-11T18:34:34.570' AS DateTime))
INSERT [sys_SettingCategory] ([AutoID], [CateName], [CateDesc], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (11, N'EmailInfo', N'邮件信息', 0, 1, CAST(N'2015-09-26T15:49:16.627' AS DateTime))
INSERT [sys_SettingCategory] ([AutoID], [CateName], [CateDesc], [Sort], [IsUsing], [AutoTimeStamp]) VALUES (13, N'SMSInfo', N'短信配置', 0, 1, CAST(N'2020-06-08T12:20:26.110' AS DateTime))
SET IDENTITY_INSERT [sys_SettingCategory] OFF
GO
SET IDENTITY_INSERT [sys_Ver] ON 

INSERT [sys_Ver] ([AutoID], [SoftName], [LicTimeStart], [LicTimeEnd], [Ver], [VerCodeNum], [Author], [Company], [Address], [PostCode], [Mobile], [Email], [Remark], [LastUpdateTime]) VALUES (1, N'SinGooCMS内容管理平台', N'0F23B8454E31B721C1BF0107B1BBE96F', N'833EF602A6092FFB8E37FAE3A2512882', N'1.6', 16000, N'jsonlee', N'SinGooCMS', N'中国 • 赣州 • 兴国', N'342404', N'17788760902', N'16826375@qq.com', N'.Net Core 3.1（c#）', CAST(N'2020-07-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [sys_Ver] OFF
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [sys_Catalog] ADD UNIQUE NONCLUSTERED 
(
	[CatalogCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [sys_Dicts] ADD UNIQUE NONCLUSTERED 
(
	[DictName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [sys_Role] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
ALTER TABLE [sys_Setting] ADD  CONSTRAINT [UQ__sys_Sett__F0A2A3371B0907CE] UNIQUE NONCLUSTERED 
(
	[KeyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [cms_AccountDetail] ADD  DEFAULT (getdate()) FOR [OperateDate]
GO
ALTER TABLE [cms_AdPlace] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_AdPlace] ADD  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [cms_AdPlace] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_Ads] ADD  DEFAULT ((0)) FOR [Hit]
GO
ALTER TABLE [cms_Ads] ADD  DEFAULT ((0)) FOR [IsAudit]
GO
ALTER TABLE [cms_Ads] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_Ads] ADD  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [cms_Ads] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_Attachment] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_Attachment] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_BaseField] ADD  CONSTRAINT [DF__cms_BaseF__Enabl__0A338187]  DEFAULT ((1)) FOR [EnableNull]
GO
ALTER TABLE [cms_BaseField] ADD  CONSTRAINT [DF__cms_BaseF__Enabl__0B27A5C0]  DEFAULT ((0)) FOR [EnableSearch]
GO
ALTER TABLE [cms_BaseField] ADD  CONSTRAINT [DF__cms_BaseF__IsUsi__0C1BC9F9]  DEFAULT ((1)) FOR [IsUsing]
GO
ALTER TABLE [cms_BaseField] ADD  CONSTRAINT [DF__cms_BaseF__IsSys__0D0FEE32]  DEFAULT ((0)) FOR [IsSystem]
GO
ALTER TABLE [cms_BaseField] ADD  CONSTRAINT [DF__cms_BaseFi__Sort__0E04126B]  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_BaseField] ADD  CONSTRAINT [DF__cms_BaseF__AutoT__0EF836A4]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_C_Common] ADD  CONSTRAINT [DF__cms_C_Com__ContI__093F5D4E]  DEFAULT ((0)) FOR [ContID]
GO
ALTER TABLE [cms_C_FileDown] ADD  CONSTRAINT [DF__cms_C_Fil__ContI__7FB5F314]  DEFAULT ((0)) FOR [ContID]
GO
ALTER TABLE [cms_C_FileDown] ADD  CONSTRAINT [DF__cms_C_Fil__FileD__00AA174D]  DEFAULT ('') FOR [FileDownPath]
GO
ALTER TABLE [cms_C_FileDown] ADD  CONSTRAINT [DF__cms_C_File__test__019E3B86]  DEFAULT ('') FOR [test]
GO
ALTER TABLE [cms_C_Photo] ADD  CONSTRAINT [DF__cms_C_Pho__ContI__7DCDAAA2]  DEFAULT ((0)) FOR [ContID]
GO
ALTER TABLE [cms_C_Photo] ADD  CONSTRAINT [DF__cms_C_Pho__Galle__7EC1CEDB]  DEFAULT ('') FOR [Gallery]
GO
ALTER TABLE [cms_C_Product] ADD  CONSTRAINT [DF__cms_C_Pro__ContI__7AF13DF7]  DEFAULT ((0)) FOR [ContID]
GO
ALTER TABLE [cms_C_Product] ADD  CONSTRAINT [DF__cms_C_Pro__ProPh__7BE56230]  DEFAULT ('') FOR [ProPhotos]
GO
ALTER TABLE [cms_C_Product] ADD  CONSTRAINT [DF__cms_C_Pro__ProDo__7CD98669]  DEFAULT ('') FOR [ProDocument]
GO
ALTER TABLE [cms_Comment] ADD  CONSTRAINT [DF__cms_Comme__IsAud__762C88DA]  DEFAULT ((1)) FOR [IsAudit]
GO
ALTER TABLE [cms_Comment] ADD  CONSTRAINT [DF__cms_Commen__Lang__7908F585]  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [cms_Comment] ADD  CONSTRAINT [DF__cms_Comme__AutoT__79FD19BE]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_CommentActiveLog] ADD  CONSTRAINT [DF__cms_Comme__AutoT__73501C2F]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_Content] ADD  CONSTRAINT [DF__cms_Content__Hit__6ABAD62E]  DEFAULT ((0)) FOR [Hit]
GO
ALTER TABLE [cms_Content] ADD  CONSTRAINT [DF__cms_Conte__Custo__6BAEFA67]  DEFAULT ((0)) FOR [CustomRecommend]
GO
ALTER TABLE [cms_Content] ADD  CONSTRAINT [DF__cms_Conte__IsTop__6CA31EA0]  DEFAULT ((0)) FOR [IsTop]
GO
ALTER TABLE [cms_Content] ADD  CONSTRAINT [DF__cms_Conte__IsRec__6D9742D9]  DEFAULT ((0)) FOR [IsRecommend]
GO
ALTER TABLE [cms_Content] ADD  CONSTRAINT [DF__cms_Conte__IsNew__6E8B6712]  DEFAULT ((0)) FOR [IsNew]
GO
ALTER TABLE [cms_Content] ADD  CONSTRAINT [DF__cms_Conten__Lang__6F7F8B4B]  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [cms_Content] ADD  CONSTRAINT [DF__cms_Conten__Sort__7073AF84]  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_Content] ADD  CONSTRAINT [DF__cms_Conte__Statu__7167D3BD]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [cms_Content] ADD  CONSTRAINT [DF__cms_Conte__AutoT__725BF7F6]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_ContField] ADD  CONSTRAINT [DF__cms_ContF__Enabl__6501FCD8]  DEFAULT ((1)) FOR [EnableNull]
GO
ALTER TABLE [cms_ContField] ADD  CONSTRAINT [DF__cms_ContF__Enabl__65F62111]  DEFAULT ((0)) FOR [EnableSearch]
GO
ALTER TABLE [cms_ContField] ADD  CONSTRAINT [DF__cms_ContF__IsUsi__66EA454A]  DEFAULT ((1)) FOR [IsUsing]
GO
ALTER TABLE [cms_ContField] ADD  CONSTRAINT [DF__cms_ContF__IsSys__67DE6983]  DEFAULT ((0)) FOR [IsSystem]
GO
ALTER TABLE [cms_ContField] ADD  CONSTRAINT [DF__cms_ContFi__Sort__68D28DBC]  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_ContField] ADD  CONSTRAINT [DF__cms_ContF__AutoT__69C6B1F5]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_ContModel] ADD  DEFAULT ((1)) FOR [IsUsing]
GO
ALTER TABLE [cms_ContModel] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_ContModel] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_Feedback] ADD  CONSTRAINT [DF__cms_Feedba__Sort__5A846E65]  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_Feedback] ADD  CONSTRAINT [DF__cms_Feedb__IsAud__59904A2C]  DEFAULT ((1)) FOR [IsAudit]
GO
ALTER TABLE [cms_Feedback] ADD  CONSTRAINT [DF__cms_Feedba__Lang__5B78929E]  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [cms_Feedback] ADD  CONSTRAINT [DF__cms_Feedb__AutoT__5C6CB6D7]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_Links] ADD  DEFAULT ((0)) FOR [IsAudit]
GO
ALTER TABLE [cms_Links] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_Links] ADD  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [cms_Links] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_Node] ADD  CONSTRAINT [DF__cms_Node__ItemPa__4D2A7347]  DEFAULT ((10)) FOR [ItemPageSize]
GO
ALTER TABLE [cms_Node] ADD  CONSTRAINT [DF__cms_Node__IsShow__4E1E9780]  DEFAULT ((1)) FOR [IsShowOnMenu]
GO
ALTER TABLE [cms_Node] ADD  CONSTRAINT [DF__cms_Node__IsShow__4F12BBB9]  DEFAULT ((1)) FOR [IsShowOnNav]
GO
ALTER TABLE [cms_Node] ADD  CONSTRAINT [DF__cms_Node__IsTop__5006DFF2]  DEFAULT ((0)) FOR [IsTop]
GO
ALTER TABLE [cms_Node] ADD  CONSTRAINT [DF__cms_Node__IsReco__50FB042B]  DEFAULT ((0)) FOR [IsRecommend]
GO
ALTER TABLE [cms_Node] ADD  CONSTRAINT [DF__cms_Node__IsNew__51EF2864]  DEFAULT ((0)) FOR [IsNew]
GO
ALTER TABLE [cms_Node] ADD  CONSTRAINT [DF__cms_Node__Sort__52E34C9D]  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_Node] ADD  CONSTRAINT [DF__cms_Node__Lang__53D770D6]  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [cms_Node] ADD  CONSTRAINT [DF__cms_Node__AutoTi__54CB950F]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_SiteTemplate] ADD  DEFAULT ((0)) FOR [IsAudit]
GO
ALTER TABLE [cms_SiteTemplate] ADD  DEFAULT ((0)) FOR [IsExists]
GO
ALTER TABLE [cms_SiteTemplate] ADD  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [cms_SiteTemplate] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_SiteTemplate] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_Tags] ADD  DEFAULT ((0)) FOR [IsTop]
GO
ALTER TABLE [cms_Tags] ADD  DEFAULT ((0)) FOR [IsRecommend]
GO
ALTER TABLE [cms_Tags] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_Tags] ADD  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [cms_Tags] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_ThirdPartyLogin] ADD  DEFAULT (getdate()) FOR [LoginTime]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__Amount__345EC57D]  DEFAULT ((0.0)) FOR [Amount]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__Integr__3552E9B6]  DEFAULT ((0)) FOR [Integral]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__FileSp__36470DEF]  DEFAULT ((104857600)) FOR [FileSpace]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__CertTy__373B3228]  DEFAULT ('身份证') FOR [CertType]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__CertNo__382F5661]  DEFAULT ('') FOR [CertNo]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__NickNa__39237A9A]  DEFAULT ('') FOR [NickName]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__RealNa__3A179ED3]  DEFAULT ('') FOR [RealName]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__Gender__3B0BC30C]  DEFAULT ('男') FOR [Gender]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__Birthd__3BFFE745]  DEFAULT (CONVERT([datetime],'1900-1-1',(0))) FOR [Birthday]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF_cms_User_CreditLine]  DEFAULT ((0)) FOR [CreditLine]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__IsThir__3CF40B7E]  DEFAULT ((0)) FOR [IsThirdLoginReg]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__Status__3DE82FB7]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__Sort__3EDC53F0]  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__LoginC__3FD07829]  DEFAULT ((0)) FOR [LoginCount]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__LastLo__40C49C62]  DEFAULT ('') FOR [LastLoginIP]
GO
ALTER TABLE [cms_User] ADD  CONSTRAINT [DF__cms_User__AutoTi__41B8C09B]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_UserField] ADD  CONSTRAINT [DF__cms_UserF__DataL__2EA5EC27]  DEFAULT ((0)) FOR [DataLength]
GO
ALTER TABLE [cms_UserField] ADD  CONSTRAINT [DF__cms_UserF__Enabl__2F9A1060]  DEFAULT ((1)) FOR [EnableNull]
GO
ALTER TABLE [cms_UserField] ADD  CONSTRAINT [DF__cms_UserF__IsUsi__308E3499]  DEFAULT ((1)) FOR [IsUsing]
GO
ALTER TABLE [cms_UserField] ADD  CONSTRAINT [DF__cms_UserF__IsSys__318258D2]  DEFAULT ((0)) FOR [IsSystem]
GO
ALTER TABLE [cms_UserField] ADD  CONSTRAINT [DF__cms_UserFi__Sort__32767D0B]  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_UserField] ADD  CONSTRAINT [DF__cms_UserF__AutoT__336AA144]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_UserGroup] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_UserGroup] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_UserLevel] ADD  DEFAULT ((0)) FOR [Integral]
GO
ALTER TABLE [cms_UserLevel] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_UserLevel] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_Vote] ADD  CONSTRAINT [DF__cms_Vote__IsMult__251C81ED]  DEFAULT ((0)) FOR [IsMultiChoice]
GO
ALTER TABLE [cms_Vote] ADD  CONSTRAINT [DF__cms_Vote__IsAudi__2610A626]  DEFAULT ((0)) FOR [IsAudit]
GO
ALTER TABLE [cms_Vote] ADD  CONSTRAINT [DF__cms_Vote__Lang__2704CA5F]  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [cms_Vote] ADD  CONSTRAINT [DF__cms_Vote__Sort__27F8EE98]  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [cms_Vote] ADD  CONSTRAINT [DF__cms_Vote__AutoTi__28ED12D1]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [cms_VoteLog] ADD  CONSTRAINT [DF__cms_VoteLo__Lang__1F63A897]  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [cms_VoteLog] ADD  CONSTRAINT [DF__cms_VoteL__AutoT__2057CCD0]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_Account] ADD  DEFAULT ((0)) FOR [IsSystem]
GO
ALTER TABLE [sys_Account] ADD  DEFAULT (getdate()) FOR [LastLoginTime]
GO
ALTER TABLE [sys_Account] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF__sys_BaseC__CopyR__290D0E62]  DEFAULT ('SinGooCMS') FOR [CopyRight]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF__sys_BaseC__Brows__2A01329B]  DEFAULT ('Aspx') FOR [BrowseType]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF__sys_BaseC__TryLo__2AF556D4]  DEFAULT ((5)) FOR [TryLoginTimes]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF__sys_BaseC__Verif__2BE97B0D]  DEFAULT ((0)) FOR [VerifycodeForReg]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF__sys_BaseC__Verif__2CDD9F46]  DEFAULT ((0)) FOR [VerifycodeForLogin]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF__sys_BaseC__Verif__2DD1C37F]  DEFAULT ((0)) FOR [VerifycodeForGetPwd]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF__sys_BaseC__FileC__2EC5E7B8]  DEFAULT ((104857600)) FOR [FileCapacity]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF_sys_BaseConfig_EnableAliyunOSS]  DEFAULT ((0)) FOR [EnableAliyunOSS]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF_sys_BaseConfig_UploadImgWidthLimit]  DEFAULT ((0)) FOR [UploadImgWidthLimit]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF_sys_BaseConfig_UploadImgHeightLimit]  DEFAULT ((0)) FOR [UploadImgHeightLimit]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF__sys_BaseC__Thumb__2FBA0BF1]  DEFAULT ('Cut') FOR [ThumbModel]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF_sys_BaseConfig_AliyunOSSEnabled]  DEFAULT ((0)) FOR [AliyunOSSEnabled]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF_sys_BaseConfig_SiteCapacity]  DEFAULT ((0)) FOR [SiteCapacity]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF__sys_BaseC__Visit__30AE302A]  DEFAULT ((0)) FOR [VisitRec]
GO
ALTER TABLE [sys_BaseConfig] ADD  CONSTRAINT [DF__sys_BaseC__Allow__31A25463]  DEFAULT ((0)) FOR [AllowOutPost]
GO
ALTER TABLE [sys_Catalog] ADD  DEFAULT ((0)) FOR [IsSystem]
GO
ALTER TABLE [sys_Catalog] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [sys_Catalog] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_DictItem] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [sys_DictItem] ADD  DEFAULT ((1)) FOR [IsUsing]
GO
ALTER TABLE [sys_DictItem] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_Dicts] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [sys_Dicts] ADD  DEFAULT ((1)) FOR [IsUsing]
GO
ALTER TABLE [sys_Dicts] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_EventLog] ADD  CONSTRAINT [DF__sys_Event__Login__03BB8E22]  DEFAULT ((0)) FOR [LoginFailCount]
GO
ALTER TABLE [sys_EventLog] ADD  CONSTRAINT [DF__sys_EventL__Lang__04AFB25B]  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [sys_EventLog] ADD  CONSTRAINT [DF__sys_Event__AutoT__05A3D694]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_FileUpload] ADD  CONSTRAINT [DF__sys_FileU__FileS__7FEAFD3E]  DEFAULT ((0)) FOR [FileSize]
GO
ALTER TABLE [sys_FileUpload] ADD  CONSTRAINT [DF__sys_FileUp__Lang__01D345B0]  DEFAULT ('zh-cn') FOR [LocalPath]
GO
ALTER TABLE [sys_FileUpload] ADD  CONSTRAINT [DF__sys_FileU__Downl__00DF2177]  DEFAULT ((0)) FOR [DownloadCount]
GO
ALTER TABLE [sys_FileUpload] ADD  CONSTRAINT [DF__sys_FileU__AutoT__02C769E9]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_Folder] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [sys_Folder] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_IPStrategy] ADD  CONSTRAINT [DF__sys_IPStr__AutoT__7D0E9093]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_Message] ADD  CONSTRAINT [DF__sys_Messa__IsRea__76619304]  DEFAULT ((0)) FOR [IsRead]
GO
ALTER TABLE [sys_Message] ADD  CONSTRAINT [DF__sys_Messa__Recei__7B264821]  DEFAULT (getdate()) FOR [ReadTime]
GO
ALTER TABLE [sys_Message] ADD  CONSTRAINT [DF_sys_Message_IsSend]  DEFAULT ((0)) FOR [HasSend]
GO
ALTER TABLE [sys_Message] ADD  CONSTRAINT [DF__sys_Messa__SendT__7A3223E8]  DEFAULT (getdate()) FOR [SendTime]
GO
ALTER TABLE [sys_Message] ADD  CONSTRAINT [DF__sys_Messag__Lang__793DFFAF]  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [sys_Module] ADD  DEFAULT ((0)) FOR [IsSystem]
GO
ALTER TABLE [sys_Module] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [sys_Module] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_Operate] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [sys_Operate] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_Purview] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_Role] ADD  DEFAULT ((1)) FOR [IsSystem]
GO
ALTER TABLE [sys_Role] ADD  DEFAULT ((1)) FOR [IsManager]
GO
ALTER TABLE [sys_Role] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [sys_Role] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_SendRecord] ADD  CONSTRAINT [DF__sys_SMS__AutoTim__6442E2C9]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_Setting] ADD  CONSTRAINT [DF__sys_Setti__DataL__681373AD]  DEFAULT ((0)) FOR [DataLength]
GO
ALTER TABLE [sys_Setting] ADD  CONSTRAINT [DF__sys_Settin__Sort__690797E6]  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [sys_Setting] ADD  CONSTRAINT [DF__sys_Setti__IsUsi__69FBBC1F]  DEFAULT ((1)) FOR [IsUsing]
GO
ALTER TABLE [sys_Setting] ADD  CONSTRAINT [DF__sys_Setti__IsSys__6AEFE058]  DEFAULT ((0)) FOR [IsSystem]
GO
ALTER TABLE [sys_Setting] ADD  CONSTRAINT [DF__sys_Setti__AutoT__6BE40491]  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_SettingCategory] ADD  DEFAULT ((999)) FOR [Sort]
GO
ALTER TABLE [sys_SettingCategory] ADD  DEFAULT ((1)) FOR [IsUsing]
GO
ALTER TABLE [sys_SettingCategory] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_SMSTemplate] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [sys_Ver] ADD  CONSTRAINT [DF__sys_Ver__LastUpd__737017C0]  DEFAULT (getdate()) FOR [LastUpdateTime]
GO
ALTER TABLE [sys_Visitor] ADD  DEFAULT ('zh-cn') FOR [Lang]
GO
ALTER TABLE [sys_Visitor] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
ALTER TABLE [weixin_WxMenu] ADD  DEFAULT ((66)) FOR [Sort]
GO
ALTER TABLE [weixin_WxMenu] ADD  DEFAULT (getdate()) FOR [AutoTimeStamp]
GO
