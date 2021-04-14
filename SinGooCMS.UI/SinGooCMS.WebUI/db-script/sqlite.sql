PRAGMA foreign_keys = false;

-- ----------------------------
-- Table structure for cms_AccountDetail
-- ----------------------------
DROP TABLE IF EXISTS "cms_AccountDetail";
CREATE TABLE "cms_AccountDetail" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "UserID" INTEGER NOT NULL DEFAULT 0,
  "UserName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Unit" VARCHAR(10) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Before" MONEY NOT NULL DEFAULT 0,
  "OpValue" MONEY NOT NULL DEFAULT 0,
  "OpType" TINYINT NOT NULL DEFAULT 0,
  "After" MONEY NOT NULL DEFAULT 0,
  "Remark" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "Operator" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "OperateDate" DATETIME
);

-- ----------------------------
-- Table structure for cms_AdPlace
-- ----------------------------
DROP TABLE IF EXISTS "cms_AdPlace";
CREATE TABLE "cms_AdPlace" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "PlaceName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Width" INTEGER NOT NULL DEFAULT 0,
  "Height" INTEGER NOT NULL DEFAULT 0,
  "Price" DECIMAL(12,2) DEFAULT 0,
  "TemplateFile" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "PlaceDesc" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_Ads
-- ----------------------------
DROP TABLE IF EXISTS "cms_Ads";
CREATE TABLE "cms_Ads" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "PlaceID" INTEGER NOT NULL DEFAULT 0,
  "AdName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "AdType" TINYINT NOT NULL DEFAULT 0,
  "AdLink" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "BeginDate" DATETIME NOT NULL,
  "EndDate" DATETIME NOT NULL,
  "AdText" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "AdMediaPath" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "AdDesc" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "IsNewWin" TINYINT DEFAULT 0,
  "Hit" INTEGER DEFAULT 0,
  "IsAudit" TINYINT DEFAULT 0,
  "Sort" INTEGER DEFAULT 999,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_Attachment
-- ----------------------------
DROP TABLE IF EXISTS "cms_Attachment";
CREATE TABLE "cms_Attachment" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "FilePath" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "ImgThumb" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Remark" VARCHAR(2000) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_BaseField
-- ----------------------------
DROP TABLE IF EXISTS "cms_BaseField";
CREATE TABLE "cms_BaseField" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "ModelID" INTEGER NOT NULL DEFAULT 0,
  "ModelType" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "FieldName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "FieldType" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "DataType" VARCHAR(20) DEFAULT '' COLLATE NOCASE,
  "DataLength" INTEGER DEFAULT 0,
  "FieldAlias" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "Tip" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "FieldDesc" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "DefaultValue" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "Setting" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "EnableNull" TINYINT DEFAULT 1,
  "EnableSearch" TINYINT DEFAULT 0,
  "IsUsing" TINYINT DEFAULT 1,
  "IsSystem" TINYINT DEFAULT 0,
  "Sort" INTEGER DEFAULT 999,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of cms_BaseField
-- ----------------------------
INSERT INTO "cms_BaseField" VALUES (1, 1, 'Content', 'Title', 'SingleText', 'nvarchar', 255, '标题', '请输入标题 (必填√)', '内容标题', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 1, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (2, 1, 'Content', 'SubTitle', 'SingleText', 'nvarchar', 255, '副标题', '', '内容副标题', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 2, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (3, 1, 'Content', 'Summary', 'MultipleText', 'nvarchar', 500, '摘要', '内容的简要描述', '内容摘要', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 3, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (4, 1, 'Content', 'TagKey', 'SingleText', 'nvarchar', 50, '标签', '', '标签', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 10, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (5, 1, 'Content', 'Author', 'SingleText', 'nvarchar', 50, '作者', '', '作者', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 4, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (6, 1, 'Content', 'Editor', 'SingleText', 'nvarchar', 50, '编辑', '', '编辑', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 5, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (7, 1, 'Content', 'Source', 'SingleText', 'nvarchar', 50, '来源', '', '来源', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 6, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (8, 1, 'Content', 'SourceUrl', 'SingleText', 'nvarchar', 100, '来源地址', '', '来源地址', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Url","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 7, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (10, 1, 'Content', 'Content', 'MultipleHtml', 'ntext', 50, '正文内容', '', '正文内容', '', '{"ControlWidth":98,"ControlHeight":350,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 8, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (13, 1, 'Content', 'ContentImage', 'Picture', 'nvarchar', 255, '图片地址', '', '图片地址', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 11, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (14, 1, 'Content', 'AutoTimeStamp', 'DateTime', 'datetime', 30, '添加时间', '', '添加时间', '', '{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 21, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (16, 1, 'Content', 'Hit', 'SingleText', 'nvarchar', 10, '点击率', '', '点击率', 0, '{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 18, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (17, 1, 'Content', 'Sort', 'SingleText', 'nvarchar', 10, '排序号', '', '排序号', 999, '{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 19, '2012-08-22 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (18, 1, 'Content', 'SeoKey', 'MultipleText', 'nvarchar', 255, '搜索关键字', '多个关键字用英文逗号(,)分隔', '搜索关键字', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 12, '2012-08-24 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (20, 1, 'Content', 'SeoDescription', 'MultipleText', 'nvarchar', 255, '搜索描述', '', '搜索描述', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 13, '2012-08-24 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (22, 1, 'Content', 'IsTop', 'CheckBox', 'nvarchar', 10, '是否置顶', '', '是否置顶', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 15, '2012-08-24 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (24, 1, 'Content', 'IsRecommend', 'CheckBox', 'nvarchar', 10, '是否推荐', '', '是否推荐', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 1, 1, 16, '2012-08-24 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (26, 1, 'Content', 'Attachment', 'MultiPicture', 'nvarchar', 100, '附件', '', '附件', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 14, '2014-04-07 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (28, 1, 'Content', 'IsNew', 'CheckBox', 'nvarchar', 10, '是否最新', '', '是否最新', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 17, '2012-08-24 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (52, 1, 'User', 'RealName', 'SingleText', 'nvarchar', 50, '真实姓名', '', '真实姓名', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 1, '2012-09-04 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (53, 1, 'User', 'Gender', 'RadioButton', 'nvarchar', 10, '性别', '', '性别', '男', '{"ControlWidth":100,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"男,女"}', 1, 0, 1, 1, 2, '2012-09-04 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (54, 1, 'User', 'Birthday', 'DateTime', 'datetime', 20, '出生日期', '', '出生日期', '', '{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":true,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 3, '2012-09-04 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (55, 1, 'User', 'NickName', 'SingleText', 'nvarchar', 50, '昵称', '', '昵称', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 4, '2012-09-04 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (56, 1, 'User', 'HeaderPhoto', 'Picture', 'nvarchar', 100, '头像', '', '头像', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 5, '2012-09-04 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (57, 1, 'User', 'CreditLine', 'SingleText', 'nvarchar', 20, '信用度', '', '信用度', 0, '{"ControlWidth":100,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 6, '2012-09-04 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (58, 1, 'User', 'Country', 'SingleText', 'nvarchar', 50, '国家', '', '国家', '中国', '{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 7, '2012-09-04 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (61, 1, 'User', 'Address', 'SingleText', 'nvarchar', 255, '街道地址', '', '街道地址', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 15, '2012-09-04 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (62, 1, 'User', 'PostCode', 'SingleText', 'nvarchar', 10, '邮编', '', '邮编', '', '{"ControlWidth":100,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 16, '2012-09-04 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (63, 1, 'User', 'TelePhone', 'SingleText', 'nvarchar', 30, '家庭电话', '', '家庭电话', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 17, '2012-09-04 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (64, 1, 'User', 'Remark', 'MultipleText', 'nvarchar', 1000, '备注', '', '备注', '', '{"ControlWidth":300,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 18, '2012-09-04 00:00:00.000');
INSERT INTO "cms_BaseField" VALUES (66, 1, 'Content', 'TemplateFile', 'TemplateFile', 'nvarchar', 100, '模板文件', '优先使用此模板', '模板文件', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 15, '2012-09-04 00:00:00.000');

-- ----------------------------
-- Table structure for cms_C_Common
-- ----------------------------
DROP TABLE IF EXISTS "cms_C_Common";
CREATE TABLE "cms_C_Common" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "ContID" INTEGER NOT NULL DEFAULT 0
);

-- ----------------------------
-- Table structure for cms_C_FileDown
-- ----------------------------
DROP TABLE IF EXISTS "cms_C_FileDown";
CREATE TABLE "cms_C_FileDown" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "ContID" INTEGER NOT NULL DEFAULT 0,
  "FileDownPath" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "test" VARCHAR(50) DEFAULT '' COLLATE NOCASE
);

-- ----------------------------
-- Table structure for cms_C_Photo
-- ----------------------------
DROP TABLE IF EXISTS "cms_C_Photo";
CREATE TABLE "cms_C_Photo" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "ContID" INTEGER NOT NULL DEFAULT 0,
  "Gallery" VARCHAR(50) DEFAULT '' COLLATE NOCASE
);

-- ----------------------------
-- Table structure for cms_C_Product
-- ----------------------------
DROP TABLE IF EXISTS "cms_C_Product";
CREATE TABLE "cms_C_Product" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "ContID" INTEGER NOT NULL DEFAULT 0,
  "ProPhotos" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "ProDocument" TEXT
);

-- ----------------------------
-- Table structure for cms_Comment
-- ----------------------------
DROP TABLE IF EXISTS "cms_Comment";
CREATE TABLE "cms_Comment" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "ContID" INTEGER NOT NULL DEFAULT 0,
  "ReplyID" INTEGER NOT NULL DEFAULT 0,
  "UserID" INTEGER NOT NULL DEFAULT 0,
  "UserName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Comment" VARCHAR(1000) NOT NULL DEFAULT '' COLLATE NOCASE,
  "IPAddress" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "IPArea" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "IsAudit" TINYINT NOT NULL DEFAULT 1,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_CommentActiveLog
-- ----------------------------
DROP TABLE IF EXISTS "cms_CommentActiveLog";
CREATE TABLE "cms_CommentActiveLog" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "CommentID" INTEGER NOT NULL DEFAULT 0,
  "UserID" INTEGER NOT NULL DEFAULT 0,
  "UserName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "IPAddress" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "IPArea" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "IsZan" TINYINT NOT NULL DEFAULT 0,
  "Lang" VARCHAR(20) DEFAULT '' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_ContField
-- ----------------------------
DROP TABLE IF EXISTS "cms_ContField";
CREATE TABLE "cms_ContField" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "ModelID" INTEGER NOT NULL DEFAULT 0,
  "FieldName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "FieldType" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "DataType" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "DataLength" INTEGER NOT NULL DEFAULT 0,
  "FieldAlias" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Tip" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "FieldDesc" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "DefaultValue" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "Setting" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "EnableNull" TINYINT DEFAULT 1,
  "EnableSearch" TINYINT DEFAULT 0,
  "IsUsing" TINYINT DEFAULT 1,
  "IsSystem" TINYINT DEFAULT 0,
  "Sort" INTEGER DEFAULT 999,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of cms_ContField
-- ----------------------------
INSERT INTO "cms_ContField" VALUES (1, 1, 'Title', 'SingleText', 'nvarchar', 255, '标题', '', '内容标题', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 1, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (2, 1, 'SubTitle', 'SingleText', 'nvarchar', 255, '副标题', '', '内容副标题', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 2, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (3, 1, 'Summary', 'MultipleText', 'nvarchar', 500, '摘要', '内容的简要描述', '内容摘要', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 3, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (4, 1, 'TagKey', 'SingleText', 'nvarchar', 50, '标签', '', '标签', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 10, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (5, 1, 'Author', 'SingleText', 'nvarchar', 50, '作者', '', '作者', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 4, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (6, 1, 'Editor', 'SingleText', 'nvarchar', 50, '编辑', '', '编辑', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 5, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (7, 1, 'Source', 'SingleText', 'nvarchar', 50, '来源', '', '来源', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 6, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (8, 1, 'SourceUrl', 'SingleText', 'nvarchar', 100, '来源地址', '', '来源地址', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Url","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 7, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (9, 1, 'Content', 'MultipleHtml', 'ntext', 50, '正文内容', '', '正文内容', '', '{"ControlWidth":98,"ControlHeight":350,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 8, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (10, 1, 'ContentImage', 'Picture', 'nvarchar', 100, '图片地址', '', '图片地址', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 11, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (11, 1, 'AutoTimeStamp', 'DateTime', 'datetime', 30, '添加时间', '', '添加时间', '', '{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd HH:mm:ss","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 21, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (13, 1, 'Hit', 'SingleText', 'nvarchar', 10, '点击率', '', '点击率', 0, '{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 18, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (14, 1, 'Sort', 'SingleText', 'nvarchar', 10, '排序号', '', '排序号', 999, '{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 19, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (15, 1, 'SeoKey', 'MultipleText', 'nvarchar', 255, '搜索关键字', '多个关键字用英文逗号(,)分隔', '搜索关键字', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 12, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (16, 1, 'SeoDescription', 'MultipleText', 'nvarchar', 255, '搜索描述', '', '搜索描述', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 13, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (17, 1, 'IsTop', 'CheckBox', 'nvarchar', 10, '是否置顶', '', '是否置顶', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 15, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (18, 1, 'IsRecommend', 'CheckBox', 'nvarchar', 10, '是否推荐', '', '是否推荐', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 16, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (19, 1, 'Attachment', 'MultiPicture', 'nvarchar', 255, '附件', '', '附件', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 14, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (20, 1, 'IsNew', 'CheckBox', 'nvarchar', 10, '是否最新', '', '是否最新', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 17, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (21, 2, 'Title', 'SingleText', 'nvarchar', 255, '标题', '请输入标题 (必填√)', '内容标题', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 1, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (22, 2, 'SubTitle', 'SingleText', 'nvarchar', 255, '副标题', '', '内容副标题', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 2, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (23, 2, 'Summary', 'MultipleText', 'nvarchar', 500, '地址', '', '内容摘要', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 2, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (24, 2, 'TagKey', 'SingleText', 'nvarchar', 50, '标签', '', '标签', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 10, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (25, 2, 'Author', 'SingleText', 'nvarchar', 50, '作者', '', '作者', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 4, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (26, 2, 'Editor', 'SingleText', 'nvarchar', 50, '编辑', '', '编辑', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 5, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (27, 2, 'Source', 'SingleText', 'nvarchar', 50, '来源', '', '来源', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 6, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (28, 2, 'SourceUrl', 'SingleText', 'nvarchar', 100, '来源地址', '', '来源地址', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Url","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 7, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (29, 2, 'Content', 'MultipleHtml', 'ntext', 50, '正文内容', '', '正文内容', '', '{"ControlWidth":98,"ControlHeight":350,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 4, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (30, 2, 'ContentImage', 'Picture', 'nvarchar', 100, '封面', '', '图片地址', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 3, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (31, 2, 'AutoTimeStamp', 'DateTime', 'datetime', 30, '添加时间', '', '添加时间', '', '{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 21, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (33, 2, 'Hit', 'SingleText', 'nvarchar', 10, '点击率', '', '点击率', 0, '{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 18, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (34, 2, 'Sort', 'SingleText', 'nvarchar', 10, '排序号', '', '排序号', 999, '{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 19, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (35, 2, 'SeoKey', 'MultipleText', 'nvarchar', 255, '搜索关键字', '多个关键字用英文逗号(,)分隔', '搜索关键字', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 12, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (36, 2, 'SeoDescription', 'MultipleText', 'nvarchar', 255, '搜索描述', '', '搜索描述', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 13, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (37, 2, 'IsTop', 'CheckBox', 'nvarchar', 10, '是否置顶', '', '是否置顶', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 15, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (38, 2, 'IsRecommend', 'CheckBox', 'nvarchar', 10, '是否推荐', '', '是否推荐', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 16, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (39, 2, 'Attachment', 'MultiPicture', 'nvarchar', 100, '附件', '', '附件', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 14, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (40, 2, 'IsNew', 'CheckBox', 'nvarchar', 10, '是否最新', '', '是否最新', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 17, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (41, 3, 'Title', 'SingleText', 'nvarchar', 255, '标题', '请输入标题 (必填√)', '内容标题', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 1, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (42, 3, 'SubTitle', 'SingleText', 'nvarchar', 255, '副标题', '', '内容副标题', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 2, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (43, 3, 'Summary', 'MultipleText', 'nvarchar', 500, '摘要', '内容的简要描述', '内容摘要', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 3, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (44, 3, 'TagKey', 'SingleText', 'nvarchar', 50, '标签', '', '标签', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 10, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (45, 3, 'Author', 'SingleText', 'nvarchar', 50, '作者', '', '作者', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 4, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (46, 3, 'Editor', 'SingleText', 'nvarchar', 50, '编辑', '', '编辑', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 5, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (47, 3, 'Source', 'SingleText', 'nvarchar', 50, '来源', '', '来源', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 6, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (48, 3, 'SourceUrl', 'SingleText', 'nvarchar', 100, '来源地址', '', '来源地址', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Url","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 7, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (49, 3, 'Content', 'MultipleHtml', 'ntext', 50, '正文内容', '', '正文内容', '', '{"ControlWidth":98,"ControlHeight":350,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 8, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (50, 3, 'ContentImage', 'Picture', 'nvarchar', 100, '图片地址', '', '图片地址', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 11, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (51, 3, 'AutoTimeStamp', 'DateTime', 'datetime', 30, '添加时间', '', '添加时间', '', '{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 21, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (52, 3, 'TemplateFile', 'TemplateFile', 'nvarchar', 100, '模板文件', '', '模板文件', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 15, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (53, 3, 'Hit', 'SingleText', 'nvarchar', 10, '点击率', '', '点击率', 0, '{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 18, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (54, 3, 'Sort', 'SingleText', 'nvarchar', 10, '排序号', '', '排序号', 999, '{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 19, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (55, 3, 'SeoKey', 'MultipleText', 'nvarchar', 255, '搜索关键字', '多个关键字用英文逗号(,)分隔', '搜索关键字', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 12, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (56, 3, 'SeoDescription', 'MultipleText', 'nvarchar', 255, '搜索描述', '', '搜索描述', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 13, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (57, 3, 'IsTop', 'DropDownList', 'nvarchar', 10, '是否置顶', '', '是否置顶', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 15, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (58, 3, 'IsRecommend', 'DropDownList', 'nvarchar', 10, '是否推荐', '', '是否推荐', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 16, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (59, 3, 'Attachment', 'DateTime', 'nvarchar', 100, '附件', '', '附件', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 14, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (60, 3, 'IsNew', 'DropDownList', 'nvarchar', 10, '是否最新', '', '是否最新', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 17, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (61, 4, 'Title', 'SingleText', 'nvarchar', 255, '标题', '请输入标题 (必填√)', '内容标题', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 1, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (62, 4, 'SubTitle', 'SingleText', 'nvarchar', 255, '副标题', '', '内容副标题', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 2, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (63, 4, 'Summary', 'MultipleText', 'nvarchar', 500, '摘要', '内容的简要描述', '内容摘要', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 3, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (64, 4, 'TagKey', 'SingleText', 'nvarchar', 50, '标签', '', '标签', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 10, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (65, 4, 'Author', 'SingleText', 'nvarchar', 50, '作者', '', '作者', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 4, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (66, 4, 'Editor', 'SingleText', 'nvarchar', 50, '编辑', '', '编辑', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 5, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (67, 4, 'Source', 'SingleText', 'nvarchar', 50, '来源', '', '来源', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 6, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (68, 4, 'SourceUrl', 'SingleText', 'nvarchar', 100, '来源地址', '', '来源地址', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Url","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 0, 1, 7, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (69, 4, 'Content', 'MultipleHtml', 'ntext', 50, '正文内容', '', '正文内容', '', '{"ControlWidth":98,"ControlHeight":350,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 0, 1, 1, 1, 8, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (70, 4, 'ContentImage', 'File', 'nvarchar', 100, '图片地址', '', '图片地址', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 11, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (71, 4, 'AutoTimeStamp', 'DateTime', 'datetime', 30, '添加时间', '', '添加时间', '', '{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 21, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (73, 4, 'Hit', 'SingleText', 'nvarchar', 10, '点击率', '', '点击率', 0, '{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 1, 18, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (74, 4, 'Sort', 'SingleText', 'nvarchar', 10, '排序号', '', '排序号', 999, '{"ControlWidth":60,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 19, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (75, 4, 'SeoKey', 'MultipleText', 'nvarchar', 255, '搜索关键字', '多个关键字用英文逗号(,)分隔', '搜索关键字', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 12, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (76, 4, 'SeoDescription', 'MultipleText', 'nvarchar', 255, '搜索描述', '', '搜索描述', '', '{"ControlWidth":450,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, 13, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (77, 4, 'IsTop', 'DropDownList', 'nvarchar', 10, '是否置顶', '', '是否置顶', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 15, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (78, 4, 'IsRecommend', 'DropDownList', 'nvarchar', 10, '是否推荐', '', '是否推荐', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 16, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (79, 4, 'Attachment', 'DateTime', 'nvarchar', 255, '附件', '', '附件', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 14, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (80, 4, 'IsNew', 'DropDownList', 'nvarchar', 10, '是否最新', '', '是否最新', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"是|True"}', 1, 0, 0, 1, 17, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (81, 3, 'ProPhotos', 'MultiPicture', 'nvarchar', 255, '产品相册', '', '', '', '{"ControlWidth":98,"ControlHeight":200,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 0, 15, '1900-01-01 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (82, 3, 'ProDocument', 'MultipleHtml', 'ntext', 50, '产品手册', '', '', '', '{"ControlWidth":98,"ControlHeight":200,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 0, 16, '1900-01-01 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (83, 4, 'FileDownPath', 'File', 'nvarchar', 100, '文件路径', '', '', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 0, 10, '1900-01-01 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (84, 1, 'TemplateFile', 'TemplateFile', 'nvarchar', 100, '模板文件', '优先使用此模板', '模板文件', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 15, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (85, 2, 'TemplateFile', 'TemplateFile', 'nvarchar', 100, '模板文件', '优先使用此模板', '模板文件', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 15, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (86, 4, 'TemplateFile', 'TemplateFile', 'nvarchar', 100, '模板文件', '优先使用此模板', '模板文件', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 0, 1, 15, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContField" VALUES (87, 2, 'Gallery', 'MultiPicture', 'nvarchar', 50, '相册', '', '', '', '{"ControlWidth":100,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 0, 1, 0, 5, '2020-01-13 00:00:00.000');

-- ----------------------------
-- Table structure for cms_ContModel
-- ----------------------------
DROP TABLE IF EXISTS "cms_ContModel";
CREATE TABLE "cms_ContModel" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "ModelName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "TableName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "ModelDesc" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "IsUsing" TINYINT DEFAULT 1,
  "Creator" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of cms_ContModel
-- ----------------------------
INSERT INTO "cms_ContModel" VALUES (1, '普通文章', 'cms_C_Common', '基本模型', 1, 'superadmin', 1, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContModel" VALUES (2, '图片文章', 'cms_C_Photo', '', 1, 'admin', 2, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContModel" VALUES (3, '产品展示', 'cms_C_Product', '', 1, 'admin', 3, '2014-10-29 00:00:00.000');
INSERT INTO "cms_ContModel" VALUES (4, '文件下载', 'cms_C_FileDown', '', 1, 'admin', 4, '2014-10-29 00:00:00.000');

-- ----------------------------
-- Table structure for cms_ContNodeExt
-- ----------------------------
DROP TABLE IF EXISTS "cms_ContNodeExt";
CREATE TABLE "cms_ContNodeExt" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "NodeID" INTEGER NOT NULL DEFAULT 0,
  "ContID" INTEGER NOT NULL DEFAULT 0
);

-- ----------------------------
-- Table structure for cms_Content
-- ----------------------------
DROP TABLE IF EXISTS "cms_Content";
CREATE TABLE "cms_Content" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "NodeID" INTEGER NOT NULL DEFAULT 0,
  "NodeName" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "ModelID" INTEGER NOT NULL DEFAULT 0,
  "NodeExts" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "TableName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Title" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "SubTitle" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "Summary" VARCHAR(500) DEFAULT '' COLLATE NOCASE,
  "Author" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Editor" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Source" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "SourceUrl" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "Content" TEXT,
  "ContentImage" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "Attachment" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "TagKey" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "RelateContent" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "SeoKey" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "SeoDescription" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "Hit" INTEGER DEFAULT 0,
  "TemplateFile" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "CustomRecommend" INTEGER DEFAULT 0,
  "IsTop" TINYINT DEFAULT 0,
  "IsRecommend" TINYINT DEFAULT 0,
  "IsNew" TINYINT DEFAULT 0,
  "LockPassword" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "Inputer" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "Status" INTEGER DEFAULT 0,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_Feedback
-- ----------------------------
DROP TABLE IF EXISTS "cms_Feedback";
CREATE TABLE "cms_Feedback" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "RootID" INTEGER NOT NULL DEFAULT 0,
  "ReplyID" INTEGER NOT NULL DEFAULT 0,
  "UserID" INTEGER NOT NULL DEFAULT 0,
  "UserName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Title" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Content" VARCHAR(1000) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Email" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Phone" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "IPAddress" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "IPArea" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "IsAudit" TINYINT DEFAULT 1,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_Links
-- ----------------------------
DROP TABLE IF EXISTS "cms_Links";
CREATE TABLE "cms_Links" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "LinkName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "LinkUrl" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "LinkType" VARCHAR(10) NOT NULL DEFAULT '' COLLATE NOCASE,
  "LinkText" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "LinkImage" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "LinkFlash" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "IsAudit" TINYINT DEFAULT 0,
  "Sort" INTEGER DEFAULT 999,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of cms_Links
-- ----------------------------
INSERT INTO "cms_Links" VALUES (1, 'SinGooCMS官网', 'http://www.singoo.top', '文字链接', '', '', '', 1, 1, 'zh-cn', '2021-04-12 00:00:00.000');

-- ----------------------------
-- Table structure for cms_Node
-- ----------------------------
DROP TABLE IF EXISTS "cms_Node";
CREATE TABLE "cms_Node" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "NodeName" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "NodeIdentifier" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "ModelID" INTEGER NOT NULL DEFAULT 0,
  "ParentID" INTEGER NOT NULL DEFAULT 0,
  "ParentPath" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Depth" INTEGER NOT NULL DEFAULT 0,
  "ChildList" VARCHAR(1000) NOT NULL DEFAULT '' COLLATE NOCASE,
  "NodeImage" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "NodeBanner" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "SeoKey" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "SeoDescription" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "ItemPageSize" INTEGER DEFAULT 10,
  "CustomLink" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "Setting" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "Remark" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "IsShowOnMenu" TINYINT DEFAULT 1,
  "IsShowOnNav" TINYINT DEFAULT 1,
  "IsTop" TINYINT DEFAULT 0,
  "IsRecommend" TINYINT DEFAULT 0,
  "IsNew" TINYINT DEFAULT 0,
  "Creator" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_SiteTemplate
-- ----------------------------
DROP TABLE IF EXISTS "cms_SiteTemplate";
CREATE TABLE "cms_SiteTemplate" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "TemplateName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "ShowPic" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "TemplatePath" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "HomePage" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "TemplateDesc" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "IsAudit" TINYINT DEFAULT 0,
  "IsExists" TINYINT DEFAULT 0,
  "Author" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "CopyRight" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "IsDefault" TINYINT DEFAULT 0,
  "Sort" INTEGER DEFAULT 999,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_Tags
-- ----------------------------
DROP TABLE IF EXISTS "cms_Tags";
CREATE TABLE "cms_Tags" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "TagName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "TagUrl" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "TagIndex" INTEGER DEFAULT 0,
  "Remark" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "IsTop" TINYINT DEFAULT 0,
  "IsRecommend" TINYINT DEFAULT 0,
  "Sort" INTEGER DEFAULT 999,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_ThirdPartyLogin
-- ----------------------------
DROP TABLE IF EXISTS "cms_ThirdPartyLogin";
CREATE TABLE "cms_ThirdPartyLogin" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "LoginFrom" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "UniqueCert" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "BindUserID" INTEGER NOT NULL DEFAULT 0,
  "BindUserName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "AccessToken" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "RefreshToken" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "LoginTime" DATETIME
);

-- ----------------------------
-- Table structure for cms_U_Person
-- ----------------------------
DROP TABLE IF EXISTS "cms_U_Person";
CREATE TABLE "cms_U_Person" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "UserID" INTEGER NOT NULL DEFAULT 0
);

-- ----------------------------
-- Table structure for cms_User
-- ----------------------------
DROP TABLE IF EXISTS "cms_User";
CREATE TABLE "cms_User" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "UserName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "GroupID" INTEGER NOT NULL DEFAULT 0,
  "LevelID" INTEGER NOT NULL DEFAULT 0,
  "Password" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Email" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Mobile" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Amount" DECIMAL(12,2) DEFAULT 0.0,
  "Integral" INTEGER DEFAULT 0,
  "FileSpace" INTEGER DEFAULT 104857600,
  "CertType" VARCHAR(50) DEFAULT '身份证' COLLATE NOCASE,
  "CertNo" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "NickName" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "RealName" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Gender" VARCHAR(8) DEFAULT '男' COLLATE NOCASE,
  "Birthday" DATETIME,
  "HeaderPhoto" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "CreditLine" DECIMAL(12,2) DEFAULT 0,
  "Area" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "Country" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Province" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "City" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "County" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Address" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "PostCode" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "TelePhone" VARCHAR(30) DEFAULT '' COLLATE NOCASE,
  "PayPassword" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "Remark" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "IsThirdLoginReg" TINYINT DEFAULT 0,
  "Status" TINYINT DEFAULT 0,
  "Sort" INTEGER DEFAULT 999,
  "LoginCount" INTEGER DEFAULT 0,
  "LastLoginTime" DATETIME,
  "LastLoginIP" VARCHAR(30) DEFAULT '' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_UserField
-- ----------------------------
DROP TABLE IF EXISTS "cms_UserField";
CREATE TABLE "cms_UserField" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "UserGroupID" INTEGER NOT NULL DEFAULT 0,
  "FieldName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "FieldType" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "DataType" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "DataLength" INTEGER NOT NULL DEFAULT 0,
  "FieldAlias" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Tip" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "FieldDesc" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "DefaultValue" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "Setting" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "EnableNull" TINYINT DEFAULT 1,
  "IsUsing" TINYINT DEFAULT 1,
  "IsSystem" TINYINT DEFAULT 0,
  "Sort" INTEGER DEFAULT 999,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of cms_UserField
-- ----------------------------
INSERT INTO "cms_UserField" VALUES (1, 1, 'RealName', 'SingleText', 'nvarchar', 50, '真实姓名', '', '真实姓名', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 1, '2017-11-01 00:00:00.000');
INSERT INTO "cms_UserField" VALUES (2, 1, 'Gender', 'RadioButton', 'nvarchar', 50, '性别', '', '性别', '男', '{"ControlWidth":100,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"男,女"}', 1, 1, 1, 2, '2017-11-01 00:00:00.000');
INSERT INTO "cms_UserField" VALUES (3, 1, 'Birthday', 'DateTime', 'datetime', 50, '出生日期', '', '出生日期', '', '{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":true,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 3, '2017-11-01 00:00:00.000');
INSERT INTO "cms_UserField" VALUES (4, 1, 'NickName', 'SingleText', 'nvarchar', 50, '昵称', '', '昵称', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 4, '2017-11-01 00:00:00.000');
INSERT INTO "cms_UserField" VALUES (5, 1, 'HeaderPhoto', 'Picture', 'nvarchar', 50, '头像', '', '头像', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 5, '2017-11-01 00:00:00.000');
INSERT INTO "cms_UserField" VALUES (6, 1, 'CreditLine', 'SingleText', 'nvarchar', 50, '信用度', '', '信用度', 0, '{"ControlWidth":100,"ControlHeight":30,"TextMode":"Number","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 6, '2017-11-01 00:00:00.000');
INSERT INTO "cms_UserField" VALUES (7, 1, 'Country', 'SingleText', 'nvarchar', 50, '国家', '', '国家', '中国', '{"ControlWidth":150,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 7, '2017-11-01 00:00:00.000');
INSERT INTO "cms_UserField" VALUES (8, 1, 'Area', 'SingleText', 'nvarchar', 255, '省市地区', '', '区域', '', '{"ControlWidth":300,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 8, '2017-11-01 00:00:00.000');
INSERT INTO "cms_UserField" VALUES (9, 1, 'Address', 'SingleText', 'nvarchar', 255, '街道地址', '', '街道地址', '', '{"ControlWidth":360,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 15, '2017-11-01 00:00:00.000');
INSERT INTO "cms_UserField" VALUES (10, 1, 'PostCode', 'SingleText', 'nvarchar', 10, '邮编', '', '邮编', '', '{"ControlWidth":100,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 16, '2017-11-01 00:00:00.000');
INSERT INTO "cms_UserField" VALUES (11, 1, 'TelePhone', 'SingleText', 'nvarchar', 50, '家庭电话', '', '家庭电话', '', '{"ControlWidth":200,"ControlHeight":30,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 17, '2017-11-01 00:00:00.000');
INSERT INTO "cms_UserField" VALUES (12, 1, 'Remark', 'MultipleText', 'nvarchar', 1000, '备注', '', '备注', '', '{"ControlWidth":300,"ControlHeight":60,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 1, 1, 1, 18, '2017-11-01 00:00:00.000');

-- ----------------------------
-- Table structure for cms_UserGroup
-- ----------------------------
DROP TABLE IF EXISTS "cms_UserGroup";
CREATE TABLE "cms_UserGroup" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "GroupName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "TableName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "GroupDesc" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "Creator" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of cms_UserGroup
-- ----------------------------
INSERT INTO "cms_UserGroup" VALUES (1, '个人会员', 'cms_U_Person', '个人会员组', 999, 'admin', '2017-11-01 00:00:00.000');

-- ----------------------------
-- Table structure for cms_UserLevel
-- ----------------------------
DROP TABLE IF EXISTS "cms_UserLevel";
CREATE TABLE "cms_UserLevel" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "LevelName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Integral" INTEGER NOT NULL DEFAULT 0,
  "Discount" MONEY NOT NULL DEFAULT 0,
  "LevelDesc" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of cms_UserLevel
-- ----------------------------
INSERT INTO "cms_UserLevel" VALUES (1, '初级会员', 0, 0, '', 999, '2012-08-15 00:00:00.000');
INSERT INTO "cms_UserLevel" VALUES (2, '中级会员', 100, 1, '', 2, '2012-08-15 00:00:00.000');
INSERT INTO "cms_UserLevel" VALUES (3, '高级会员', 1000, 1, '', 3, '2012-08-15 00:00:00.000');
INSERT INTO "cms_UserLevel" VALUES (4, '银牌会员', 10000, 1, '', 4, '2012-08-15 00:00:00.000');
INSERT INTO "cms_UserLevel" VALUES (5, '金牌会员', 100000, 0.95, '', 5, '2012-08-15 00:00:00.000');
INSERT INTO "cms_UserLevel" VALUES (6, '钻石会员', 1000000, 0.8, '', 6, '2012-08-15 00:00:00.000');

-- ----------------------------
-- Table structure for cms_Vote
-- ----------------------------
DROP TABLE IF EXISTS "cms_Vote";
CREATE TABLE "cms_Vote" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "Title" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Items" VARCHAR(2000) NOT NULL DEFAULT '' COLLATE NOCASE,
  "IsMultiChoice" TINYINT NOT NULL DEFAULT 0,
  "IsAnonymous" TINYINT NOT NULL DEFAULT 0,
  "IsAudit" TINYINT DEFAULT 0,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "Remark" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "Creator" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for cms_VoteLog
-- ----------------------------
DROP TABLE IF EXISTS "cms_VoteLog";
CREATE TABLE "cms_VoteLog" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "VoteID" INTEGER NOT NULL DEFAULT 0,
  "VoteItemID" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "VoteItemOption" VARCHAR(500) NOT NULL DEFAULT '' COLLATE NOCASE,
  "UserID" INTEGER NOT NULL DEFAULT 0,
  "UserName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "IpAddress" VARCHAR(30) DEFAULT '' COLLATE NOCASE,
  "IpArea" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for sqlite_sequence
-- ----------------------------
/*
DROP TABLE IF EXISTS "sqlite_sequence";
CREATE TABLE "sqlite_sequence" (
  "name",
  "seq"
);*/

-- ----------------------------
-- Records of sqlite_sequence
-- ----------------------------
INSERT INTO "sqlite_sequence" VALUES ('sys_Purview', 1560);
INSERT INTO "sqlite_sequence" VALUES ('sys_Catalog', 7);
INSERT INTO "sqlite_sequence" VALUES ('sys_Role', 6);
INSERT INTO "sqlite_sequence" VALUES ('cms_ContField', 87);
INSERT INTO "sqlite_sequence" VALUES ('cms_ContModel', 4);
INSERT INTO "sqlite_sequence" VALUES ('sys_DictItem', 15);
INSERT INTO "sqlite_sequence" VALUES ('sys_Setting', 57);
INSERT INTO "sqlite_sequence" VALUES ('cms_BaseField', 66);
INSERT INTO "sqlite_sequence" VALUES ('cms_UserField', 12);
INSERT INTO "sqlite_sequence" VALUES ('sys_SettingCategory', 13);
INSERT INTO "sqlite_sequence" VALUES ('cms_UserGroup', 1);
INSERT INTO "sqlite_sequence" VALUES ('sys_Dicts', 3);
INSERT INTO "sqlite_sequence" VALUES ('cms_Links', 1);
INSERT INTO "sqlite_sequence" VALUES ('cms_UserLevel', 6);
INSERT INTO "sqlite_sequence" VALUES ('sys_Ver', 1);
INSERT INTO "sqlite_sequence" VALUES ('sys_Account', 5);
INSERT INTO "sqlite_sequence" VALUES ('sys_IPStrategy', 4);
INSERT INTO "sqlite_sequence" VALUES ('sys_BaseConfig', 1);
INSERT INTO "sqlite_sequence" VALUES ('sys_Module', 47);
INSERT INTO "sqlite_sequence" VALUES ('sys_Operate', 264);

-- ----------------------------
-- Table structure for sys_Account
-- ----------------------------
DROP TABLE IF EXISTS "sys_Account";
CREATE TABLE "sys_Account" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "AccountName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Password" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Roles" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Email" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Mobile" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "IsSystem" TINYINT DEFAULT 0,
  "LoginCount" INTEGER DEFAULT 0,
  "LastLoginIP" VARCHAR(30) DEFAULT '' COLLATE NOCASE,
  "LastLoginArea" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "LastLoginTime" DATETIME,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of sys_Account
-- ----------------------------
INSERT INTO "sys_Account" VALUES (1, 'superadmin', '7189511f9463534d23edb965e211f3c490a3a1c48a72d54eadeb5927096d92823b3e298d1fa7d27cc54adbf7748fb806a9d72ea414a57569fc7abdec693ed76a', 1, 'liqiang665@163.com', 17788760902, 1, 171, '127.0.0.1', '本机地址 CZ88.NET', '2021-04-12 00:00:00.000', '2012-07-30 00:00:00.000');
INSERT INTO "sys_Account" VALUES (2, 'admin', '7189511f9463534d23edb965e211f3c490a3a1c48a72d54eadeb5927096d92823b3e298d1fa7d27cc54adbf7748fb806a9d72ea414a57569fc7abdec693ed76a', 2, '16826375@qq.com', 17788760902, 1, 193, '127.0.0.1', '本机地址 CZ88.NET', '2021-03-26 00:00:00.000', '2021-04-12 00:00:00.000');
INSERT INTO "sys_Account" VALUES (5, 'viewer', '0b5f51f0bb18b598503524eed851d1dbf282c4c617bc47ba6a00565ba7a6e62cd1da82fe7ed46369a55367b26998a0b0b894d1f444bcdc9f857a40d25379585d', 6, '', '', 0, 10, '127.0.0.1', '本机地址 CZ88.NET', '2021-03-26 00:00:00.000', '2021-04-12 00:00:00.000');

-- ----------------------------
-- Table structure for sys_BaseConfig
-- ----------------------------
DROP TABLE IF EXISTS "sys_BaseConfig";
CREATE TABLE "sys_BaseConfig" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "SiteName" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "SiteLogo" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "SiteBanner" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "SiteDomain" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "CopyRight" VARCHAR(100) DEFAULT 'SinGooCMS' COLLATE NOCASE,
  "IcpNo" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "DefaultLang" VARCHAR(20) DEFAULT '' COLLATE NOCASE,
  "EnabledMobile" TINYINT DEFAULT 0,
  "BrowseType" VARCHAR(20) DEFAULT 'Aspx' COLLATE NOCASE,
  "UrlRewriteExt" VARCHAR(5) DEFAULT '' COLLATE NOCASE,
  "GlobalPageSize" INTEGER DEFAULT 0,
  "IsCreateStaticHTML" TINYINT DEFAULT 0,
  "HtmlNodeFileRule" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "HtmlFileRule" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "HtmlFileExt" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "UserNameType" VARCHAR(20) DEFAULT '' COLLATE NOCASE,
  "UserNameRule" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "SysUserName" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "CertType" VARCHAR(20) DEFAULT '' COLLATE NOCASE,
  "RegAgreement" TEXT,
  "RegGiveIntegral" INTEGER DEFAULT 0,
  "TgIntegral" INTEGER DEFAULT 0,
  "TryLoginTimes" INTEGER DEFAULT 5,
  "CookieTime" VARCHAR(20) DEFAULT '' COLLATE NOCASE,
  "VerifycodeForReg" TINYINT DEFAULT 0,
  "VerifycodeForLogin" TINYINT DEFAULT 0,
  "VerifycodeForGetPwd" TINYINT DEFAULT 0,
  "GetPwdType" VARCHAR(20) DEFAULT '' COLLATE NOCASE,
  "FileCapacity" BIGINT DEFAULT 104857600,
  "ServMailAccount" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "ServMailUserName" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "ServMailUserPwd" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "ServMailSMTP" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "ServMailPort" INTEGER DEFAULT 0,
  "ServMailIsSSL" TINYINT DEFAULT 0,
  "ReciverEMail" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "SMSClass" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "SMSUrl" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "SMSUId" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "SMSPwd" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "EnableFileUpload" TINYINT DEFAULT 0,
  "EnableAliyunOSS" TINYINT DEFAULT 0,
  "EnableUploadExt" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "UploadSizeLimit" INTEGER DEFAULT 0,
  "UploadLimit" INTEGER DEFAULT 0,
  "UploadSaveRule" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "UploadImgWidthLimit" INTEGER DEFAULT 0,
  "UploadImgHeightLimit" INTEGER DEFAULT 0,
  "ThumbSize" VARCHAR(30) DEFAULT '' COLLATE NOCASE,
  "ThumbModel" VARCHAR(10) DEFAULT 'Cut' COLLATE NOCASE,
  "WaterMarkPosition" TINYINT DEFAULT 0,
  "WaterMarkType" VARCHAR(10) DEFAULT '' COLLATE NOCASE,
  "WaterMarkText" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "WaterMarkTextSize" INTEGER DEFAULT 0,
  "WaterMarkTextFont" VARCHAR(30) DEFAULT '' COLLATE NOCASE,
  "WaterMarkTextColor" VARCHAR(20) DEFAULT '' COLLATE NOCASE,
  "WaterMarkImage" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "WaterMarkAlpha" MONEY DEFAULT 0,
  "AliyunOSSEnabled" TINYINT DEFAULT 0,
  "SEOKey" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "SEODescription" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "BadWords" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "BWReplaceWord" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "SiteCapacity" BIGINT DEFAULT 0,
  "VisitRec" TINYINT DEFAULT 0,
  "AllowOutPost" TINYINT DEFAULT 0,
  "IsCompressHtml" TINYINT DEFAULT 0,
  "Theme" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "DefaultHtmlEditor" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "STATLink" VARCHAR(255) DEFAULT '' COLLATE NOCASE
);

-- ----------------------------
-- Records of sys_BaseConfig
-- ----------------------------
INSERT INTO "sys_BaseConfig" VALUES (1, 'SinGooCMS-Demo', '/include/theme/h5/images/login-logo.png', '', 'http://demo.singoo.top', 'copyright @ 2013', '赣ICP备20009447号', '', 1, 'HtmlRewrite', '.html', 10, 1, '/article/${nodedir}', '/article/detail/${id}', '.html', '默认的', '^[a-zA-Z][a-zA-Z0-9@_-]{3,19}', '游客,管理员,超级管理员,admin,superadmin', '普通验证码', '<p>请输入注册协议</p>', 10, 50, 5, '一周', 0, 0, 0, '邮箱找回', 104857600, '16826375@qq.com', 16826375, 'singoocms', 'smtp.qq.com', 465, 1, '', 'AliYunSMS', 'http://api.momingsms.com/', 'LTAI3REvaq4JDLTt', '1DnnagtroDvcka91LOuaKrSCvnkV6b', 1, 0, '.rar|.zip|.jpg|.jpeg|.png|.gif|.doc|.xls|.ppt|.wps|.txt|.swf|.flv|.wmv|.pdf', 20480, 102400, '${year}${month}${day}${millisecond}${rnd}', 600, 400, '400X280', 'Cut', 5, '文字水印', 'SinGooCMS内容管理系统', 50, '黑体', '#ff0000', '', 0.600000023841858, 0, 'SinGooCMS内容管理系统', 'SinGooCMS内容管理系统', '', '[根据国家相关法律不予显示]', 1073741824, 0, 0, 1, 'h5', '/Include/Plugin/ckeditor/', '');

-- ----------------------------
-- Table structure for sys_Catalog
-- ----------------------------
DROP TABLE IF EXISTS "sys_Catalog";
CREATE TABLE "sys_Catalog" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "CatalogName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "CatalogCode" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "ImagePath" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "IsSystem" TINYINT DEFAULT 0,
  "Remark" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of sys_Catalog
-- ----------------------------
INSERT INTO "sys_Catalog" VALUES (1, '内容管理', 'ContMger', '', 1, '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Catalog" VALUES (2, '会员管理', 'UserMger', '', 1, '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Catalog" VALUES (3, '移动端', 'MobMger', '', 1, '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Catalog" VALUES (4, '微信端', 'WeixinMger', '', 1, '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Catalog" VALUES (5, '广告管理', 'ADMger', '', 1, '', 5, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Catalog" VALUES (6, '系统配置', 'ConfMger', '', 1, '', 9, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Catalog" VALUES (7, '系统维护', 'SysMger', '', 1, '', 10, '2017-10-08 00:00:00.000');

-- ----------------------------
-- Table structure for sys_DictItem
-- ----------------------------
DROP TABLE IF EXISTS "sys_DictItem";
CREATE TABLE "sys_DictItem" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "DictID" INTEGER NOT NULL DEFAULT 0,
  "KeyName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "KeyValue" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "IsUsing" TINYINT DEFAULT 1,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of sys_DictItem
-- ----------------------------
INSERT INTO "sys_DictItem" VALUES (6, 2, 'Cert1', '身份证', 1, 1, '1900-01-01 00:00:00.000');
INSERT INTO "sys_DictItem" VALUES (7, 2, 'Cert2', '军官证', 3, 1, '1900-01-01 00:00:00.000');
INSERT INTO "sys_DictItem" VALUES (8, 2, 'Cert3', '港澳通行证', 4, 1, '1900-01-01 00:00:00.000');
INSERT INTO "sys_DictItem" VALUES (9, 2, 'Cert4', '护照', 2, 1, '2014-03-16 00:00:00.000');
INSERT INTO "sys_DictItem" VALUES (10, 2, 'Cert5', '其它证件', 5, 1, '2014-03-16 00:00:00.000');
INSERT INTO "sys_DictItem" VALUES (11, 3, '200元以下', '<200', 1, 1, '1900-01-01 00:00:00.000');
INSERT INTO "sys_DictItem" VALUES (12, 3, '200 ~ 300元', '200-300', 2, 1, '1900-01-01 00:00:00.000');
INSERT INTO "sys_DictItem" VALUES (13, 3, '301 ~ 500元', '301-500', 3, 1, '1900-01-01 00:00:00.000');
INSERT INTO "sys_DictItem" VALUES (14, 3, '501 ~ 800元', '501-800', 4, 1, '1900-01-01 00:00:00.000');
INSERT INTO "sys_DictItem" VALUES (15, 3, '801元以上', '>801', 5, 1, '1900-01-01 00:00:00.000');

-- ----------------------------
-- Table structure for sys_Dicts
-- ----------------------------
DROP TABLE IF EXISTS "sys_Dicts";
CREATE TABLE "sys_Dicts" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "DictName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "DictDesc" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "IsUsing" TINYINT DEFAULT 1,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of sys_Dicts
-- ----------------------------
INSERT INTO "sys_Dicts" VALUES (2, 'CertType', '证件类型', 1, 1, '1900-01-01 00:00:00.000');
INSERT INTO "sys_Dicts" VALUES (3, 'PriceRang', '价格范围', 2, 1, '1900-01-01 00:00:00.000');

-- ----------------------------
-- Table structure for sys_EventLog
-- ----------------------------
DROP TABLE IF EXISTS "sys_EventLog";
CREATE TABLE "sys_EventLog" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "UserType" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "UserName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "IPAddress" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "IPArea" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "EventInfo" VARCHAR(2000) NOT NULL DEFAULT '' COLLATE NOCASE,
  "EventType" INTEGER NOT NULL DEFAULT 0,
  "LoginFailCount" INTEGER DEFAULT 0,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for sys_FileUpload
-- ----------------------------
DROP TABLE IF EXISTS "sys_FileUpload";
CREATE TABLE "sys_FileUpload" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "FolderID" INTEGER NOT NULL DEFAULT 0,
  "FileName" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "FileExt" VARCHAR(10) NOT NULL DEFAULT '' COLLATE NOCASE,
  "FileSize" INTEGER NOT NULL DEFAULT 0,
  "LocalPath" VARCHAR(255) DEFAULT 'zh-cn' COLLATE NOCASE,
  "VirtualFilePath" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Thumb" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "OriginalPath" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "UserType" VARCHAR(20) NOT NULL DEFAULT '' COLLATE NOCASE,
  "UserName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "DownloadCount" INTEGER DEFAULT 0,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for sys_Folder
-- ----------------------------
DROP TABLE IF EXISTS "sys_Folder";
CREATE TABLE "sys_Folder" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "FolderName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Remark" VARCHAR(2000) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "Lang" VARCHAR(20) DEFAULT '' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for sys_IPStrategy
-- ----------------------------
DROP TABLE IF EXISTS "sys_IPStrategy";
CREATE TABLE "sys_IPStrategy" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "IPAddress" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Strategy" VARCHAR(10) NOT NULL DEFAULT '' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of sys_IPStrategy
-- ----------------------------
INSERT INTO "sys_IPStrategy" VALUES (4, '127.0.0.1', 'ALLOW', '2021-03-26 00:00:00.000');

-- ----------------------------
-- Table structure for sys_Message
-- ----------------------------
DROP TABLE IF EXISTS "sys_Message";
CREATE TABLE "sys_Message" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "Receiver" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "MsgBody" VARCHAR(1000) NOT NULL DEFAULT '' COLLATE NOCASE,
  "IsRead" TINYINT DEFAULT 0,
  "ReadTime" DATETIME,
  "HasSend" TINYINT DEFAULT 0,
  "SendTime" DATETIME,
  "Lang" VARCHAR(20) DEFAULT 'zh-cn' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for sys_Module
-- ----------------------------
DROP TABLE IF EXISTS "sys_Module";
CREATE TABLE "sys_Module" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "CatalogID" INTEGER NOT NULL DEFAULT 0,
  "ModuleName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "ModuleCode" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "FilePath" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "ImagePath" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "Remark" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "IsSystem" TINYINT DEFAULT 0,
  "Sort" INTEGER DEFAULT 999,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of sys_Module
-- ----------------------------
INSERT INTO "sys_Module" VALUES (1, 1, '栏目设置', 'NodeMger', 'Node/Index', '', '', 1, 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (2, 1, '文章列表', 'ContentMger', 'Content/Index', '', '', 1, 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (3, 1, '模型管理', 'ContentModelMger', 'ContModel/Index', '', '', 1, 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (4, 1, '模板管理', 'TemplateMger', 'Template/Index', '', '', 1, 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (5, 1, '文件参数', 'FileConfigSet', 'FileConfig/Index', '', '', 1, 7, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (6, 1, '文件管理', 'FileMger', 'Upfiles/Index', '', '', 1, 5, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (7, 1, '文件夹管理', 'FolderMger', 'Folder/Index', '', '', 1, 6, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (9, 2, '会员列表', 'UserMger', 'UserMger/Index', '', '', 1, 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (10, 2, '会员分组', 'UserGroupMger', 'UserGroup/Index', '', '', 1, 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (11, 2, '会员等级', 'UserLevelMger', 'UserLevel/Index', '', '', 1, 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (12, 2, '会员设置', 'UserSet', 'UserSet/Index', '', '', 1, 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (13, 2, '账户明细', 'AmountOrIntegralDetail', 'AccDetail/Index', '', '', 1, 9, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (14, 2, '信任登录', 'ThirdLoginMger', 'ThirdLogin/Index', '', '', 1, 11, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (15, 3, '移动端设置', 'MobileClientSet', 'MobileSet/Index', '', '', 1, 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (16, 3, '短信配置', 'SMSConfig', 'SMSConfig/Index', '', '', 1, 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (17, 4, '公众号配置', 'WXConfig', 'WeixinMger/WXConfig', '', '', 1, 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (18, 4, '关注回复', 'GuanZhuRlyMger', 'WeixinMger/Guanzhu', '', '', 1, 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (19, 4, '默认回复', 'DefaultRlyMger', 'WeixinMger/DefRly', '', '', 1, 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (20, 4, '关键字回复', 'MsgkeyRlyMger', 'KeyRly/Index', '', '', 1, 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (21, 4, '自定义菜单', 'CustomMenuMger', 'CustomMenu/Index', '', '', 1, 5, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (22, 5, '广告管理', 'ADMger', 'AdPlace/Index', '', '', 1, 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (23, 5, '留言反馈', 'Feedback', 'Feedback/Index', '', '', 1, 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (24, 5, '友情链接', 'FriendLink', 'FriendLink/Index', '', '', 1, 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (25, 6, '基本配置', 'BaseConfig', 'Config/Index', '', '', 1, 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (26, 6, '邮件服务', 'EmailService', 'Config/Mail', '', '', 1, 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (27, 6, '搜索优化', 'GlobalSEO', 'Config/SiteSeo', '', '', 1, 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (29, 6, '其它配置', 'OtherConfig', 'Config/Other', '', '', 1, 5, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (30, 6, '自定义配置', 'CustomSetting', 'SettingCate/Index', '', '', 1, 8, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (31, 6, '数据字典', 'DataDictionary', 'DataDict/Index', '', '', 1, 9, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (32, 7, '菜单管理', 'MenuMger', 'Menu/Index', '', '', 1, 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (33, 7, '角色管理', 'RoleMger', 'Role/Index', '', '', 1, 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (34, 7, '账号管理', 'AccountMger', 'AccountMger/Index', '', '', 1, 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (35, 7, 'IP策略', 'IPStrategyMger', 'IPStrategy/Index', '', '', 1, 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (36, 7, '数据备份', 'BackupAndRestore', 'SysMger/DataBackup', '', '', 1, 5, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (38, 7, '访问日志', 'VisitorLogMger', 'VisitorLog/Index', '', '', 1, 7, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (39, 7, '系统日志', 'SystemLogMger', 'SysLog/Index', '', '', 1, 8, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (40, 3, '短信模板', 'SMSTemplateMger', 'SMSTemplate/Index', '', '', 1, 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (41, 1, '标签管理', 'TagsMger', 'Tags/Index', '', '', 1, 10, '2017-11-07 00:00:00.000');
INSERT INTO "sys_Module" VALUES (43, 1, '评论管理', 'CommentMger', 'CommentMger/Index', '', '', 1, 8, '2020-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (45, 1, '投票管理', 'VoteMger', 'VoteMger/Index', '', '', 1, 9, '2020-10-08 00:00:00.000');
INSERT INTO "sys_Module" VALUES (47, 2, '站内消息', 'MessageMger', 'MessageMger/Index', '', '', 1, 10, '2021-03-25 00:00:00.000');

-- ----------------------------
-- Table structure for sys_Operate
-- ----------------------------
DROP TABLE IF EXISTS "sys_Operate";
CREATE TABLE "sys_Operate" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "ModuleID" INTEGER NOT NULL DEFAULT 0,
  "OperateName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "OperateCode" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Remark" VARCHAR(500) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of sys_Operate
-- ----------------------------
INSERT INTO "sys_Operate" VALUES (1, 1, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (2, 2, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (3, 3, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (4, 4, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (5, 5, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (6, 6, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (7, 7, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (9, 9, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (10, 10, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (11, 11, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (12, 12, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (13, 13, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (14, 14, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (15, 15, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (16, 16, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (17, 17, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (18, 18, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (19, 19, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (20, 20, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (21, 21, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (22, 22, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (23, 23, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (24, 24, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (25, 25, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (26, 26, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (27, 27, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (29, 29, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (30, 30, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (31, 31, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (32, 32, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (33, 33, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (34, 34, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (35, 35, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (36, 36, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (38, 38, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (39, 39, '查看', 'View', '', 1, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (40, 1, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (41, 2, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (42, 3, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (43, 4, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (46, 7, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (48, 9, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (49, 10, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (50, 11, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (53, 14, '配置', 'Configuration', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (59, 20, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (60, 21, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (61, 22, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (62, 23, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (63, 24, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (69, 30, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (70, 31, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (71, 32, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (72, 33, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (73, 34, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (74, 35, '增加', 'Add', '', 2, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (79, 1, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (80, 2, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (81, 3, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (82, 4, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (83, 5, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (85, 7, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (87, 9, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (88, 10, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (89, 11, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (90, 12, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (93, 15, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (94, 16, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (95, 17, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (96, 18, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (97, 19, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (98, 20, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (99, 21, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (100, 22, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (101, 23, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (102, 24, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (103, 25, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (104, 26, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (105, 27, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (107, 29, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (108, 30, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (109, 31, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (110, 32, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (111, 33, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (112, 34, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (113, 35, '修改', 'Modify', '', 3, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (118, 1, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (119, 2, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (120, 3, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (121, 4, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (123, 6, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (124, 7, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (126, 9, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (127, 10, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (128, 11, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (130, 13, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (137, 20, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (138, 21, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (139, 22, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (140, 23, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (141, 24, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (147, 30, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (148, 31, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (149, 32, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (150, 33, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (151, 34, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (152, 35, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (153, 36, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (155, 38, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (156, 39, '删除', 'Delete', '', 4, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (157, 33, '查看权限', 'ViewRolePermission', '', 10, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (158, 32, '添加操作', 'AddOperator', '', 10, '2017-10-09 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (159, 34, '设置账户角色', 'SetAccountRole', '', 10, '2017-10-09 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (160, 36, '备份', 'Backup', '', 10, '2017-10-09 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (164, 40, '查看', 'View', NULL, 1, '2017-11-02 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (165, 40, '增加', 'Add', NULL, 2, '2017-11-02 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (166, 40, '修改', 'Modify', NULL, 3, '2017-11-02 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (167, 40, '删除', 'Delete', NULL, 4, '2017-11-02 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (168, 10, '启用字段', 'SetEnabled', '', 10, '2017-11-03 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (169, 10, '停用字段', 'SetUnEnabled', '', 10, '2017-11-03 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (172, 3, '启用字段', 'SetEnabled', '', 10, '2017-11-07 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (173, 3, '停用字段', 'SetUnEnabled', '', 10, '2017-11-07 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (174, 41, '查看', 'View', NULL, 1, '2017-11-07 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (175, 41, '增加', 'Add', NULL, 2, '2017-11-07 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (176, 41, '修改', 'Modify', NULL, 3, '2017-11-07 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (177, 41, '删除', 'Delete', NULL, 4, '2017-11-07 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (190, 37, '查看', 'View', '', 1, '2018-08-22 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (191, 37, '执行SQL语句', 'Query', '', 10, '2018-08-22 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (192, 43, '查看', 'View', '', 1, '2021-03-10 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (193, 43, '增加', 'Add', '', 2, '2021-03-10 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (194, 43, '修改', 'Modify', '', 3, '2021-03-10 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (195, 43, '删除', 'Delete', '', 4, '2021-03-10 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (196, 45, '查看', 'View', '', 1, '2021-03-10 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (197, 45, '增加', 'Add', '', 2, '2021-03-10 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (198, 45, '修改', 'Modify', '', 3, '2021-03-10 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (199, 45, '删除', 'Delete', '', 4, '2021-03-10 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (204, 1, '栏目移动', 'NodeMove', '', 5, '2017-10-08 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (205, 2, '移动到栏目', 'MoveToNode', '', 5, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (206, 2, '还原', 'Restore', '', 6, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (207, 1, '导入', 'Import', '', 6, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (208, 1, '导出', 'Export', '', 7, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (209, 32, '删除操作', 'DeleteOperator', '', 11, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (210, 33, '设置权限', 'SetRolePermission', '', 11, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (211, 36, '还原', 'Restore', '', 11, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (212, 4, '设置默认模板', 'SetDefTmpl', '', 10, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (213, 4, '查看模板文件', 'ViewTmplFile', '', 11, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (215, 4, '创建模板文件', 'CreateTmplFile', '', 12, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (216, 4, '修改模板文件', 'ModifyTmplFile', '', 13, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (217, 4, '删除模板文件', 'DeleteTmplFile', '', 14, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (218, 14, '启用或关闭', 'SetEnableOrClose', '', 3, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (219, 10, '查看字段', 'ViewField', '', 20, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (220, 10, '增加字段', 'AddField', '', 21, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (221, 10, '修改字段', 'ModifyField', '', 22, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (222, 10, '删除字段', 'DeleteField', '', 23, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (235, 3, '查看字段', 'ViewField', '', 20, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (236, 3, '增加字段', 'AddField', '', 21, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (237, 3, '修改字段', 'ModifyField', '', 22, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (238, 3, '删除字段', 'DeleteField', '', 23, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (239, 9, '导出', 'Export', '', 10, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (240, 9, '充值', 'Recharge', '', 11, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (241, 6, '上传文件', 'Upload', '', 2, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (242, 21, '更新客户端', 'UpdateClient', '', 10, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (243, 2, '置顶', 'SetTop', '', 10, '2021-03-25 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (244, 2, '推荐', 'SetRecommend', '', 11, '2021-03-25 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (245, 2, '最新', 'SetNew', '', 12, '2021-03-25 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (246, 21, '更新服务端', 'UpdateServer', '', 11, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (247, 6, '归档', 'MoveToFolder', '', 3, '2021-03-24 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (248, 47, '查看', 'View', '', 999, '2021-03-25 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (249, 47, '增加', 'Add', '', 999, '2021-03-25 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (251, 47, '删除', 'Delete', '', 999, '2021-03-25 00:00:00.000');
INSERT INTO "sys_Operate" VALUES (264, 34, '设置账户密码', 'SetAccountPwd', '', 11, '2021-03-24 00:00:00.000');

-- ----------------------------
-- Table structure for sys_Purview
-- ----------------------------
DROP TABLE IF EXISTS "sys_Purview";
CREATE TABLE "sys_Purview" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "RoleID" INTEGER NOT NULL DEFAULT 0,
  "ModuleID" INTEGER NOT NULL DEFAULT 0,
  "OperateCode" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of sys_Purview
-- ----------------------------
INSERT INTO "sys_Purview" VALUES (1317, 2, 1, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1318, 2, 1, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1319, 2, 1, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1320, 2, 1, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1321, 2, 1, 'NodeMove', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1322, 2, 1, 'Import', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1323, 2, 1, 'Export', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1324, 2, 2, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1325, 2, 2, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1326, 2, 2, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1327, 2, 2, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1328, 2, 2, 'MoveToNode', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1329, 2, 2, 'Restore', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1330, 2, 2, 'SetTop', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1331, 2, 2, 'SetRecommend', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1332, 2, 2, 'SetNew', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1333, 2, 3, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1334, 2, 3, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1335, 2, 3, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1336, 2, 3, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1337, 2, 3, 'SetEnabled', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1338, 2, 3, 'SetUnEnabled', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1339, 2, 3, 'ViewField', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1340, 2, 3, 'AddField', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1341, 2, 3, 'ModifyField', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1342, 2, 3, 'DeleteField', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1343, 2, 4, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1344, 2, 4, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1345, 2, 4, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1346, 2, 4, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1347, 2, 4, 'SetDefTmpl', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1348, 2, 4, 'ViewTmplFile', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1349, 2, 4, 'CreateTmplFile', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1350, 2, 4, 'ModifyTmplFile', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1351, 2, 4, 'DeleteTmplFile', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1352, 2, 6, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1353, 2, 6, 'Upload', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1354, 2, 6, 'MoveToFolder', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1355, 2, 6, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1356, 2, 7, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1357, 2, 7, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1358, 2, 7, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1359, 2, 7, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1360, 2, 5, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1361, 2, 5, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1362, 2, 43, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1363, 2, 43, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1364, 2, 43, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1365, 2, 43, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1366, 2, 45, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1367, 2, 45, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1368, 2, 45, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1369, 2, 45, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1370, 2, 41, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1371, 2, 41, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1372, 2, 41, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1373, 2, 41, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1374, 2, 9, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1375, 2, 9, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1376, 2, 9, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1377, 2, 9, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1378, 2, 9, 'Export', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1379, 2, 9, 'Recharge', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1380, 2, 10, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1381, 2, 10, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1382, 2, 10, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1383, 2, 10, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1384, 2, 10, 'SetEnabled', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1385, 2, 10, 'SetUnEnabled', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1386, 2, 10, 'ViewField', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1387, 2, 10, 'AddField', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1388, 2, 10, 'ModifyField', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1389, 2, 10, 'DeleteField', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1390, 2, 11, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1391, 2, 11, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1392, 2, 11, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1393, 2, 11, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1394, 2, 12, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1395, 2, 12, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1396, 2, 13, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1397, 2, 13, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1398, 2, 47, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1399, 2, 47, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1400, 2, 47, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1401, 2, 14, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1402, 2, 14, 'Configuration', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1403, 2, 14, 'SetEnableOrClose', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1404, 2, 15, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1405, 2, 15, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1406, 2, 16, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1407, 2, 16, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1408, 2, 40, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1409, 2, 40, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1410, 2, 40, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1411, 2, 40, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1412, 2, 17, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1413, 2, 17, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1414, 2, 18, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1415, 2, 18, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1416, 2, 19, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1417, 2, 19, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1418, 2, 20, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1419, 2, 20, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1420, 2, 20, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1421, 2, 20, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1422, 2, 21, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1423, 2, 21, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1424, 2, 21, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1425, 2, 21, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1426, 2, 21, 'UpdateClient', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1427, 2, 21, 'UpdateServer', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1428, 2, 22, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1429, 2, 22, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1430, 2, 22, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1431, 2, 22, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1432, 2, 23, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1433, 2, 23, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1434, 2, 23, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1435, 2, 23, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1436, 2, 24, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1437, 2, 24, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1438, 2, 24, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1439, 2, 24, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1440, 2, 25, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1441, 2, 25, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1442, 2, 26, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1443, 2, 26, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1444, 2, 27, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1445, 2, 27, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1446, 2, 29, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1447, 2, 29, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1448, 2, 30, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1449, 2, 30, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1450, 2, 30, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1451, 2, 30, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1452, 2, 31, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1453, 2, 31, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1454, 2, 31, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1455, 2, 31, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1456, 2, 35, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1457, 2, 35, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1458, 2, 35, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1459, 2, 35, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1460, 2, 36, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1461, 2, 36, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1462, 2, 36, 'Backup', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1463, 2, 36, 'Restore', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1464, 2, 38, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1465, 2, 38, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1466, 2, 39, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1467, 2, 39, 'Delete', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1514, 6, 1, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1515, 6, 1, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1516, 6, 1, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1517, 6, 2, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1518, 6, 2, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1519, 6, 2, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1520, 6, 3, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1521, 6, 4, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1522, 6, 6, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1523, 6, 7, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1524, 6, 5, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1525, 6, 43, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1526, 6, 45, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1527, 6, 41, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1528, 6, 9, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1529, 6, 9, 'Add', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1530, 6, 9, 'Modify', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1531, 6, 10, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1532, 6, 11, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1533, 6, 12, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1534, 6, 13, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1535, 6, 47, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1536, 6, 14, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1537, 6, 15, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1538, 6, 16, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1539, 6, 40, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1540, 6, 17, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1541, 6, 18, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1542, 6, 19, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1543, 6, 20, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1544, 6, 21, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1545, 6, 22, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1546, 6, 23, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1547, 6, 24, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1548, 6, 25, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1549, 6, 26, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1550, 6, 27, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1551, 6, 29, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1552, 6, 30, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1553, 6, 31, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1554, 6, 32, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1555, 6, 33, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1556, 6, 34, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1557, 6, 35, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1558, 6, 36, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1559, 6, 38, 'View', '2021-03-26 00:00:00.000');
INSERT INTO "sys_Purview" VALUES (1560, 6, 39, 'View', '2021-03-26 00:00:00.000');

-- ----------------------------
-- Table structure for sys_Role
-- ----------------------------
DROP TABLE IF EXISTS "sys_Role";
CREATE TABLE "sys_Role" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "RoleName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Remark" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "IsSystem" TINYINT DEFAULT 1,
  "IsManager" TINYINT DEFAULT 1,
  "Sort" INTEGER DEFAULT 999,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of sys_Role
-- ----------------------------
INSERT INTO "sys_Role" VALUES (1, '超级管理员', '系统固有角色,不可移除', 1, 1, 1, '2012-06-27 00:00:00.000');
INSERT INTO "sys_Role" VALUES (2, '内容管理员', 'cms内容管理系统默认管理员', 1, 1, 2, '2014-06-30 00:00:00.000');
INSERT INTO "sys_Role" VALUES (6, '内容查看人员', '', 0, 0, 3, '2021-03-18 00:00:00.000');

-- ----------------------------
-- Table structure for sys_SMSTemplate
-- ----------------------------
DROP TABLE IF EXISTS "sys_SMSTemplate";
CREATE TABLE "sys_SMSTemplate" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "TemplName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "TemplTitle" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "TemplCode" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "TemplBody" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "TemplKeys" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for sys_SendRecord
-- ----------------------------
DROP TABLE IF EXISTS "sys_SendRecord";
CREATE TABLE "sys_SendRecord" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "SenderType" VARCHAR(20) NOT NULL DEFAULT '' COLLATE NOCASE,
  "MsgType" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "MsgBody" VARCHAR(2000) NOT NULL DEFAULT '' COLLATE NOCASE,
  "ValidateCode" VARCHAR(10) DEFAULT '' COLLATE NOCASE,
  "ReciverName" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "ReciverMedia" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "Status" TINYINT DEFAULT 0,
  "ReturnMsg" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for sys_Setting
-- ----------------------------
DROP TABLE IF EXISTS "sys_Setting";
CREATE TABLE "sys_Setting" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "CateID" INTEGER NOT NULL DEFAULT 0,
  "KeyName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "KeyValue" VARCHAR(2000) NOT NULL DEFAULT '' COLLATE NOCASE,
  "KeyDesc" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "Tip" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "ControlType" VARCHAR(20) DEFAULT '' COLLATE NOCASE,
  "DataType" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "DataLength" INTEGER DEFAULT 0,
  "DefaultValue" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "Setting" VARCHAR(2000) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "IsUsing" TINYINT DEFAULT 1,
  "IsSystem" TINYINT DEFAULT 0,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of sys_Setting
-- ----------------------------
INSERT INTO "sys_Setting" VALUES (20, 11, 'MailTemplateForResetPwd', '<div>尊敬的用户${username}:<br />
<br />
您申请找回密码,如果不是您本人的操作,请删除此邮件.<br />
要使用新的密码,请使用以下链接重新设置密码.<br />
<a href="${getpwdurl}" target="_blank">${getpwdurl}</a><br />
(如果无法点击该URL链接地址,请将它复制并粘帖到浏览器的地址输入框,然后单击回车即可.该链接使用后将立即失效.)<br />
注意:请您在收到邮件1个小时内(${expiretime}前)使用,否则该链接将会失效.
<hr />
<div style="text-align:right">${sitename}<br />
${send_date}</div>
</div>', '重置密码邮件', '', 'MultipleHtml', 'ntext', 1000, '', '{"ControlWidth":98,"ControlHeight":300,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 40, 1, 1, '1900-01-01 00:00:00.000');
INSERT INTO "sys_Setting" VALUES (23, 13, 'SendSMSValidateCode', '尊敬的用户，您的校验码：${code}，请在15分钟内完成验证，切勿泄露于他人！', '发送手机验证码', '', 'MultipleText', 'ntext', 1000, '', '{"ControlWidth":600,"ControlHeight":100,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":"","DataFromType":0}', 10, 1, 1, '1900-01-01 00:00:00.000');
INSERT INTO "sys_Setting" VALUES (25, 11, 'IsSendMailForLY', '', '留言时发送邮件', '', 'CheckBox', 'nvarchar', 50, '', '{"ControlWidth":600,"ControlHeight":100,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 31, 1, 1, '2014-07-02 00:00:00.000');
INSERT INTO "sys_Setting" VALUES (55, 11, 'ReciverEMail', '', '留言接收邮箱', '', 'SingleText', 'nvarchar', 100, '', '{"ControlWidth":200,"ControlHeight":0,"TextMode":"Email","IsDataType":false,"DataFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 30, 1, 1, '2015-10-12 00:00:00.000');
INSERT INTO "sys_Setting" VALUES (56, 11, 'SendMailValidateCode', '<p>尊敬的用户，您的校验码：${code}，请在15分钟内完成验证，切勿泄露于他人！</p>

<hr />
<div style="text-align:right">${sitename}<br />
${send_date}</div>', '发送邮件验证码', '', 'MultipleHtml', 'ntext', 1000, '', '{"ControlWidth":98,"ControlHeight":150,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 10, 1, 1, '2020-06-22 00:00:00.000');
INSERT INTO "sys_Setting" VALUES (57, 7, 'SendRegWelcome', '尊敬的用户：${username}，欢迎您成为我们的会员，如有任何疑问请联系我们的客服人员，谢谢！', '注册成功显示欢迎消息', '', 'MultipleText', 'ntext', 500, '', '{"ControlWidth":600,"ControlHeight":150,"TextMode":"Text","IsDateType":false,"DateFormat":"yyyy-MM-dd","DataFrom":"Text","DataSource":""}', 999, 1, 0, '2020-06-23 00:00:00.000');

-- ----------------------------
-- Table structure for sys_SettingCategory
-- ----------------------------
DROP TABLE IF EXISTS "sys_SettingCategory";
CREATE TABLE "sys_SettingCategory" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "CateName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "CateDesc" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 999,
  "IsUsing" TINYINT DEFAULT 1,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Records of sys_SettingCategory
-- ----------------------------
INSERT INTO "sys_SettingCategory" VALUES (7, 'UserInfo', '会员选项', 0, 1, '2012-08-11 00:00:00.000');
INSERT INTO "sys_SettingCategory" VALUES (11, 'EmailInfo', '邮件信息', 0, 1, '2015-09-26 00:00:00.000');
INSERT INTO "sys_SettingCategory" VALUES (13, 'SMSInfo', '短信配置', 0, 1, '2020-06-08 00:00:00.000');

-- ----------------------------
-- Table structure for sys_Ver
-- ----------------------------
DROP TABLE IF EXISTS "sys_Ver";
CREATE TABLE "sys_Ver" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "SoftName" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "LicTimeStart" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "LicTimeEnd" VARCHAR(100) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Ver" VARCHAR(10) NOT NULL DEFAULT '' COLLATE NOCASE,
  "VerCodeNum" INTEGER NOT NULL DEFAULT 0,
  "Author" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Company" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Address" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "PostCode" VARCHAR(10) DEFAULT '' COLLATE NOCASE,
  "Mobile" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Email" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "Remark" VARCHAR(50) DEFAULT '' COLLATE NOCASE,
  "LastUpdateTime" DATETIME
);

-- ----------------------------
-- Records of sys_Ver
-- ----------------------------
INSERT INTO "sys_Ver" VALUES (1, 'SinGooCMS内容管理平台', '0F23B8454E31B721C1BF0107B1BBE96F', '833EF602A6092FFB8E37FAE3A2512882', 1.6, 16000, 'jsonlee', 'SinGooCMS', '中国 • 赣州 • 兴国', 342404, 17788760902, '16826375@qq.com', '.Net Core 3.1（c#）', '2020-07-01 00:00:00.000');

-- ----------------------------
-- Table structure for sys_Visitor
-- ----------------------------
DROP TABLE IF EXISTS "sys_Visitor";
CREATE TABLE "sys_Visitor" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "IPAddress" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "OPSystem" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "CustomerLang" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "Navigator" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "Resolution" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "UserAgent" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "IsMobileDevice" TINYINT DEFAULT 0,
  "IsSupportActiveX" TINYINT DEFAULT 0,
  "IsSupportCookie" TINYINT DEFAULT 0,
  "IsSupportJavascript" TINYINT DEFAULT 0,
  "IsSupportJavaApplets" TINYINT DEFAULT 0,
  "NETVer" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "IsCrawler" TINYINT DEFAULT 0,
  "Engine" VARCHAR(100) DEFAULT '' COLLATE NOCASE,
  "KeyWord" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "ApproachUrl" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "VPage" VARCHAR(1000) DEFAULT '' COLLATE NOCASE,
  "GETParameter" VARCHAR(2000) DEFAULT '' COLLATE NOCASE,
  "POSTParameter" TEXT,
  "CookieParameter" VARCHAR(2000) DEFAULT '' COLLATE NOCASE,
  "ErrMessage" VARCHAR(2000) DEFAULT '' COLLATE NOCASE,
  "StackTrace" TEXT,
  "Lang" VARCHAR(10) DEFAULT 'zh-cn' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for weixin_AutoRly
-- ----------------------------
DROP TABLE IF EXISTS "weixin_AutoRly";
CREATE TABLE "weixin_AutoRly" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "RlyType" VARCHAR(30) NOT NULL DEFAULT '' COLLATE NOCASE,
  "MsgKey" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "MsgText" VARCHAR(2000) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Description" VARCHAR(2000) DEFAULT '' COLLATE NOCASE,
  "MediaPath" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "LinkUrl" VARCHAR(255) DEFAULT '' COLLATE NOCASE,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Table structure for weixin_WxMenu
-- ----------------------------
DROP TABLE IF EXISTS "weixin_WxMenu";
CREATE TABLE "weixin_WxMenu" (
  "AutoID" INTEGER PRIMARY KEY AUTOINCREMENT,
  "RootID" INTEGER NOT NULL DEFAULT 0,
  "ParentID" INTEGER NOT NULL DEFAULT 0,
  "Type" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Name" VARCHAR(20) NOT NULL DEFAULT '' COLLATE NOCASE,
  "EventKey" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Url" VARCHAR(255) NOT NULL DEFAULT '' COLLATE NOCASE,
  "ChildCount" INTEGER NOT NULL DEFAULT 0,
  "ChildIDs" VARCHAR(50) NOT NULL DEFAULT '' COLLATE NOCASE,
  "Sort" INTEGER DEFAULT 66,
  "AutoTimeStamp" DATETIME
);

-- ----------------------------
-- Auto increment value for cms_BaseField
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 66 WHERE name = 'cms_BaseField';

-- ----------------------------
-- Auto increment value for cms_ContField
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 87 WHERE name = 'cms_ContField';

-- ----------------------------
-- Auto increment value for cms_ContModel
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 4 WHERE name = 'cms_ContModel';

-- ----------------------------
-- Auto increment value for cms_Links
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 1 WHERE name = 'cms_Links';

-- ----------------------------
-- Auto increment value for cms_UserField
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 12 WHERE name = 'cms_UserField';

-- ----------------------------
-- Auto increment value for cms_UserGroup
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 1 WHERE name = 'cms_UserGroup';

-- ----------------------------
-- Auto increment value for cms_UserLevel
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 6 WHERE name = 'cms_UserLevel';

-- ----------------------------
-- Auto increment value for sys_Account
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 5 WHERE name = 'sys_Account';

-- ----------------------------
-- Auto increment value for sys_BaseConfig
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 1 WHERE name = 'sys_BaseConfig';

-- ----------------------------
-- Auto increment value for sys_Catalog
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 7 WHERE name = 'sys_Catalog';

-- ----------------------------
-- Indexes structure for table sys_Catalog
-- ----------------------------
CREATE INDEX "IDX_335741B434"
ON "sys_Catalog" (
  "CatalogCode" ASC
);

-- ----------------------------
-- Auto increment value for sys_DictItem
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 15 WHERE name = 'sys_DictItem';

-- ----------------------------
-- Auto increment value for sys_Dicts
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 3 WHERE name = 'sys_Dicts';

-- ----------------------------
-- Indexes structure for table sys_Dicts
-- ----------------------------
CREATE INDEX "IDX_5C456805F0"
ON "sys_Dicts" (
  "DictName" ASC
);

-- ----------------------------
-- Auto increment value for sys_IPStrategy
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 4 WHERE name = 'sys_IPStrategy';

-- ----------------------------
-- Auto increment value for sys_Module
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 47 WHERE name = 'sys_Module';

-- ----------------------------
-- Auto increment value for sys_Operate
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 264 WHERE name = 'sys_Operate';

-- ----------------------------
-- Auto increment value for sys_Purview
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 1560 WHERE name = 'sys_Purview';

-- ----------------------------
-- Auto increment value for sys_Role
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 6 WHERE name = 'sys_Role';

-- ----------------------------
-- Indexes structure for table sys_Role
-- ----------------------------
CREATE INDEX "IDX_3CCA46699E"
ON "sys_Role" (
  "RoleName" ASC
);

-- ----------------------------
-- Auto increment value for sys_Setting
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 57 WHERE name = 'sys_Setting';

-- ----------------------------
-- Indexes structure for table sys_Setting
-- ----------------------------
CREATE INDEX "IDX_7EEA040355"
ON "sys_Setting" (
  "KeyName" ASC
);

-- ----------------------------
-- Auto increment value for sys_SettingCategory
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 13 WHERE name = 'sys_SettingCategory';

-- ----------------------------
-- Auto increment value for sys_Ver
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 1 WHERE name = 'sys_Ver';

PRAGMA foreign_keys = true;
