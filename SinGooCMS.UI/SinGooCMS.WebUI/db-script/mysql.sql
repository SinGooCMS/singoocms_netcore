SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for cms_accountdetail
-- ----------------------------
DROP TABLE IF EXISTS `cms_accountdetail`;
CREATE TABLE `cms_accountdetail`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL DEFAULT 0,
  `UserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Unit` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Before` double NOT NULL DEFAULT 0,
  `OpValue` double NOT NULL DEFAULT 0,
  `OpType` tinyint(4) NOT NULL DEFAULT 0,
  `After` double NOT NULL DEFAULT 0,
  `Remark` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Operator` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `OperateDate` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_adplace
-- ----------------------------
DROP TABLE IF EXISTS `cms_adplace`;
CREATE TABLE `cms_adplace`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `PlaceName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Width` int(11) NOT NULL DEFAULT 0,
  `Height` int(11) NOT NULL DEFAULT 0,
  `Price` decimal(12, 2) NULL DEFAULT 0.00,
  `TemplateFile` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `PlaceDesc` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_ads
-- ----------------------------
DROP TABLE IF EXISTS `cms_ads`;
CREATE TABLE `cms_ads`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `PlaceID` int(11) NOT NULL DEFAULT 0,
  `AdName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `AdType` tinyint(4) NOT NULL DEFAULT 0,
  `AdLink` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `BeginDate` datetime(0) NOT NULL,
  `EndDate` datetime(0) NOT NULL,
  `AdText` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `AdMediaPath` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `AdDesc` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsNewWin` tinyint(4) NULL DEFAULT 0,
  `Hit` int(11) NULL DEFAULT 0,
  `IsAudit` tinyint(4) NULL DEFAULT 0,
  `Sort` int(11) NULL DEFAULT 999,
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_attachment
-- ----------------------------
DROP TABLE IF EXISTS `cms_attachment`;
CREATE TABLE `cms_attachment`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `FilePath` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ImgThumb` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Remark` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_basefield
-- ----------------------------
DROP TABLE IF EXISTS `cms_basefield`;
CREATE TABLE `cms_basefield`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `ModelID` int(11) NOT NULL DEFAULT 0,
  `ModelType` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `FieldName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `FieldType` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `DataType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `DataLength` int(11) NULL DEFAULT 0,
  `FieldAlias` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Tip` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `FieldDesc` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `DefaultValue` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Setting` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `EnableNull` tinyint(4) NULL DEFAULT 1,
  `EnableSearch` tinyint(4) NULL DEFAULT 0,
  `IsUsing` tinyint(4) NULL DEFAULT 1,
  `IsSystem` tinyint(4) NULL DEFAULT 0,
  `Sort` int(11) NULL DEFAULT 999,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 67 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cms_basefield
-- ----------------------------
INSERT INTO `cms_basefield` VALUES (1, 1, 'Content', 'Title', 'SingleText', 'nvarchar', 255, '标题', '请输入标题 (必填√)', '内容标题', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 0, 1, 1, 1, 1, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (2, 1, 'Content', 'SubTitle', 'SingleText', 'nvarchar', 255, '副标题', '', '内容副标题', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 2, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (3, 1, 'Content', 'Summary', 'MultipleText', 'nvarchar', 500, '摘要', '内容的简要描述', '内容摘要', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 3, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (4, 1, 'Content', 'TagKey', 'SingleText', 'nvarchar', 50, '标签', '', '标签', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 10, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (5, 1, 'Content', 'Author', 'SingleText', 'nvarchar', 50, '作者', '', '作者', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 4, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (6, 1, 'Content', 'Editor', 'SingleText', 'nvarchar', 50, '编辑', '', '编辑', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 5, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (7, 1, 'Content', 'Source', 'SingleText', 'nvarchar', 50, '来源', '', '来源', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 6, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (8, 1, 'Content', 'SourceUrl', 'SingleText', 'nvarchar', 100, '来源地址', '', '来源地址', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Url\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 7, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (10, 1, 'Content', 'Content', 'MultipleHtml', 'ntext', 50, '正文内容', '', '正文内容', '', '{\"ControlWidth\":98,\"ControlHeight\":350,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 8, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (13, 1, 'Content', 'ContentImage', 'Picture', 'nvarchar', 255, '图片地址', '', '图片地址', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 11, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (14, 1, 'Content', 'AutoTimeStamp', 'DateTime', 'datetime', 30, '添加时间', '', '添加时间', '', '{\"ControlWidth\":150,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 21, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (16, 1, 'Content', 'Hit', 'SingleText', 'nvarchar', 10, '点击率', '', '点击率', '0', '{\"ControlWidth\":60,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 18, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (17, 1, 'Content', 'Sort', 'SingleText', 'nvarchar', 10, '排序号', '', '排序号', '999', '{\"ControlWidth\":60,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 19, '2012-08-22 22:00:50');
INSERT INTO `cms_basefield` VALUES (18, 1, 'Content', 'SeoKey', 'MultipleText', 'nvarchar', 255, '搜索关键字', '多个关键字用英文逗号(,)分隔', '搜索关键字', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 12, '2012-08-24 12:50:35');
INSERT INTO `cms_basefield` VALUES (20, 1, 'Content', 'SeoDescription', 'MultipleText', 'nvarchar', 255, '搜索描述', '', '搜索描述', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 13, '2012-08-24 12:50:39');
INSERT INTO `cms_basefield` VALUES (22, 1, 'Content', 'IsTop', 'CheckBox', 'nvarchar', 10, '是否置顶', '', '是否置顶', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 15, '2012-08-24 12:53:00');
INSERT INTO `cms_basefield` VALUES (24, 1, 'Content', 'IsRecommend', 'CheckBox', 'nvarchar', 10, '是否推荐', '', '是否推荐', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 1, 1, 16, '2012-08-24 12:53:03');
INSERT INTO `cms_basefield` VALUES (26, 1, 'Content', 'Attachment', 'MultiPicture', 'nvarchar', 100, '附件', '', '附件', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 14, '2014-04-07 15:37:02');
INSERT INTO `cms_basefield` VALUES (28, 1, 'Content', 'IsNew', 'CheckBox', 'nvarchar', 10, '是否最新', '', '是否最新', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 17, '2012-08-24 12:53:03');
INSERT INTO `cms_basefield` VALUES (52, 1, 'User', 'RealName', 'SingleText', 'nvarchar', 50, '真实姓名', '', '真实姓名', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 1, '2012-09-04 09:54:06');
INSERT INTO `cms_basefield` VALUES (53, 1, 'User', 'Gender', 'RadioButton', 'nvarchar', 10, '性别', '', '性别', '男', '{\"ControlWidth\":100,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"男,女\"}', 1, 0, 1, 1, 2, '2012-09-04 09:54:30');
INSERT INTO `cms_basefield` VALUES (54, 1, 'User', 'Birthday', 'DateTime', 'datetime', 20, '出生日期', '', '出生日期', '', '{\"ControlWidth\":150,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":true,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 3, '2012-09-04 09:55:10');
INSERT INTO `cms_basefield` VALUES (55, 1, 'User', 'NickName', 'SingleText', 'nvarchar', 50, '昵称', '', '昵称', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 4, '2012-09-04 09:55:37');
INSERT INTO `cms_basefield` VALUES (56, 1, 'User', 'HeaderPhoto', 'Picture', 'nvarchar', 100, '头像', '', '头像', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 5, '2012-09-04 09:56:02');
INSERT INTO `cms_basefield` VALUES (57, 1, 'User', 'CreditLine', 'SingleText', 'nvarchar', 20, '信用度', '', '信用度', '0', '{\"ControlWidth\":100,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 6, '2012-09-04 09:56:19');
INSERT INTO `cms_basefield` VALUES (58, 1, 'User', 'Country', 'SingleText', 'nvarchar', 50, '国家', '', '国家', '中国', '{\"ControlWidth\":150,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 7, '2012-09-04 09:57:34');
INSERT INTO `cms_basefield` VALUES (61, 1, 'User', 'Address', 'SingleText', 'nvarchar', 255, '街道地址', '', '街道地址', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 15, '2012-09-04 09:58:04');
INSERT INTO `cms_basefield` VALUES (62, 1, 'User', 'PostCode', 'SingleText', 'nvarchar', 10, '邮编', '', '邮编', '', '{\"ControlWidth\":100,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 16, '2012-09-04 09:58:13');
INSERT INTO `cms_basefield` VALUES (63, 1, 'User', 'TelePhone', 'SingleText', 'nvarchar', 30, '家庭电话', '', '家庭电话', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 17, '2012-09-04 09:58:25');
INSERT INTO `cms_basefield` VALUES (64, 1, 'User', 'Remark', 'MultipleText', 'nvarchar', 1000, '备注', '', '备注', '', '{\"ControlWidth\":300,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 18, '2012-09-04 09:58:53');
INSERT INTO `cms_basefield` VALUES (66, 1, 'Content', 'TemplateFile', 'TemplateFile', 'nvarchar', 100, '模板文件', '优先使用此模板', '模板文件', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 15, '2012-09-04 00:00:00');

-- ----------------------------
-- Table structure for cms_c_common
-- ----------------------------
DROP TABLE IF EXISTS `cms_c_common`;
CREATE TABLE `cms_c_common`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `ContID` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Fixed;

-- ----------------------------
-- Table structure for cms_c_filedown
-- ----------------------------
DROP TABLE IF EXISTS `cms_c_filedown`;
CREATE TABLE `cms_c_filedown`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `ContID` int(11) NOT NULL DEFAULT 0,
  `FileDownPath` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `test` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_c_photo
-- ----------------------------
DROP TABLE IF EXISTS `cms_c_photo`;
CREATE TABLE `cms_c_photo`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `ContID` int(11) NOT NULL DEFAULT 0,
  `Gallery` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_c_product
-- ----------------------------
DROP TABLE IF EXISTS `cms_c_product`;
CREATE TABLE `cms_c_product`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `ContID` int(11) NOT NULL DEFAULT 0,
  `ProPhotos` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ProDocument` mediumtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_comment
-- ----------------------------
DROP TABLE IF EXISTS `cms_comment`;
CREATE TABLE `cms_comment`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `ContID` int(11) NOT NULL DEFAULT 0,
  `ReplyID` int(11) NOT NULL DEFAULT 0,
  `UserID` int(11) NOT NULL DEFAULT 0,
  `UserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Comment` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `IPAddress` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `IPArea` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `IsAudit` tinyint(4) NOT NULL DEFAULT 1,
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_commentactivelog
-- ----------------------------
DROP TABLE IF EXISTS `cms_commentactivelog`;
CREATE TABLE `cms_commentactivelog`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `CommentID` int(11) NOT NULL DEFAULT 0,
  `UserID` int(11) NOT NULL DEFAULT 0,
  `UserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `IPAddress` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `IPArea` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `IsZan` tinyint(4) NOT NULL DEFAULT 0,
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_content
-- ----------------------------
DROP TABLE IF EXISTS `cms_content`;
CREATE TABLE `cms_content`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `NodeID` int(11) NOT NULL DEFAULT 0,
  `NodeName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ModelID` int(11) NOT NULL DEFAULT 0,
  `NodeExts` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `TableName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `SubTitle` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Summary` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Author` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Editor` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Source` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SourceUrl` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Content` mediumtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `ContentImage` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Attachment` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `TagKey` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `RelateContent` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SeoKey` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SeoDescription` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Hit` int(11) NULL DEFAULT 0,
  `TemplateFile` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `CustomRecommend` int(11) NULL DEFAULT 0,
  `IsTop` tinyint(4) NULL DEFAULT 0,
  `IsRecommend` tinyint(4) NULL DEFAULT 0,
  `IsNew` tinyint(4) NULL DEFAULT 0,
  `LockPassword` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `Inputer` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `Status` int(11) NULL DEFAULT 0,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_contfield
-- ----------------------------
DROP TABLE IF EXISTS `cms_contfield`;
CREATE TABLE `cms_contfield`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `ModelID` int(11) NOT NULL DEFAULT 0,
  `FieldName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `FieldType` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `DataType` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `DataLength` int(11) NOT NULL DEFAULT 0,
  `FieldAlias` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Tip` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `FieldDesc` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `DefaultValue` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Setting` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `EnableNull` tinyint(4) NULL DEFAULT 1,
  `EnableSearch` tinyint(4) NULL DEFAULT 0,
  `IsUsing` tinyint(4) NULL DEFAULT 1,
  `IsSystem` tinyint(4) NULL DEFAULT 0,
  `Sort` int(11) NULL DEFAULT 999,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 88 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cms_contfield
-- ----------------------------
INSERT INTO `cms_contfield` VALUES (1, 1, 'Title', 'SingleText', 'nvarchar', 255, '标题', '', '内容标题', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 0, 1, 1, 1, 1, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (2, 1, 'SubTitle', 'SingleText', 'nvarchar', 255, '副标题', '', '内容副标题', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 2, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (3, 1, 'Summary', 'MultipleText', 'nvarchar', 500, '摘要', '内容的简要描述', '内容摘要', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 3, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (4, 1, 'TagKey', 'SingleText', 'nvarchar', 50, '标签', '', '标签', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 10, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (5, 1, 'Author', 'SingleText', 'nvarchar', 50, '作者', '', '作者', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 4, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (6, 1, 'Editor', 'SingleText', 'nvarchar', 50, '编辑', '', '编辑', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 5, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (7, 1, 'Source', 'SingleText', 'nvarchar', 50, '来源', '', '来源', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 6, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (8, 1, 'SourceUrl', 'SingleText', 'nvarchar', 100, '来源地址', '', '来源地址', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Url\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 7, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (9, 1, 'Content', 'MultipleHtml', 'ntext', 50, '正文内容', '', '正文内容', '', '{\"ControlWidth\":98,\"ControlHeight\":350,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 8, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (10, 1, 'ContentImage', 'Picture', 'nvarchar', 100, '图片地址', '', '图片地址', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 11, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (11, 1, 'AutoTimeStamp', 'DateTime', 'datetime', 30, '添加时间', '', '添加时间', '', '{\"ControlWidth\":150,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd HH:mm:ss\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 21, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (13, 1, 'Hit', 'SingleText', 'nvarchar', 10, '点击率', '', '点击率', '0', '{\"ControlWidth\":60,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 18, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (14, 1, 'Sort', 'SingleText', 'nvarchar', 10, '排序号', '', '排序号', '999', '{\"ControlWidth\":60,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 19, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (15, 1, 'SeoKey', 'MultipleText', 'nvarchar', 255, '搜索关键字', '多个关键字用英文逗号(,)分隔', '搜索关键字', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 12, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (16, 1, 'SeoDescription', 'MultipleText', 'nvarchar', 255, '搜索描述', '', '搜索描述', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 13, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (17, 1, 'IsTop', 'CheckBox', 'nvarchar', 10, '是否置顶', '', '是否置顶', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 15, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (18, 1, 'IsRecommend', 'CheckBox', 'nvarchar', 10, '是否推荐', '', '是否推荐', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 16, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (19, 1, 'Attachment', 'MultiPicture', 'nvarchar', 255, '附件', '', '附件', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 14, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (20, 1, 'IsNew', 'CheckBox', 'nvarchar', 10, '是否最新', '', '是否最新', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 17, '2014-10-29 16:00:31');
INSERT INTO `cms_contfield` VALUES (21, 2, 'Title', 'SingleText', 'nvarchar', 255, '标题', '请输入标题 (必填√)', '内容标题', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 0, 1, 1, 1, 1, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (22, 2, 'SubTitle', 'SingleText', 'nvarchar', 255, '副标题', '', '内容副标题', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 2, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (23, 2, 'Summary', 'MultipleText', 'nvarchar', 500, '地址', '', '内容摘要', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 2, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (24, 2, 'TagKey', 'SingleText', 'nvarchar', 50, '标签', '', '标签', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 10, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (25, 2, 'Author', 'SingleText', 'nvarchar', 50, '作者', '', '作者', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 4, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (26, 2, 'Editor', 'SingleText', 'nvarchar', 50, '编辑', '', '编辑', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 5, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (27, 2, 'Source', 'SingleText', 'nvarchar', 50, '来源', '', '来源', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 6, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (28, 2, 'SourceUrl', 'SingleText', 'nvarchar', 100, '来源地址', '', '来源地址', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Url\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 7, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (29, 2, 'Content', 'MultipleHtml', 'ntext', 50, '正文内容', '', '正文内容', '', '{\"ControlWidth\":98,\"ControlHeight\":350,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 0, 1, 1, 1, 4, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (30, 2, 'ContentImage', 'Picture', 'nvarchar', 100, '封面', '', '图片地址', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 3, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (31, 2, 'AutoTimeStamp', 'DateTime', 'datetime', 30, '添加时间', '', '添加时间', '', '{\"ControlWidth\":150,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 21, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (33, 2, 'Hit', 'SingleText', 'nvarchar', 10, '点击率', '', '点击率', '0', '{\"ControlWidth\":60,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 18, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (34, 2, 'Sort', 'SingleText', 'nvarchar', 10, '排序号', '', '排序号', '999', '{\"ControlWidth\":60,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 19, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (35, 2, 'SeoKey', 'MultipleText', 'nvarchar', 255, '搜索关键字', '多个关键字用英文逗号(,)分隔', '搜索关键字', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 12, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (36, 2, 'SeoDescription', 'MultipleText', 'nvarchar', 255, '搜索描述', '', '搜索描述', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 13, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (37, 2, 'IsTop', 'CheckBox', 'nvarchar', 10, '是否置顶', '', '是否置顶', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 15, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (38, 2, 'IsRecommend', 'CheckBox', 'nvarchar', 10, '是否推荐', '', '是否推荐', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 16, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (39, 2, 'Attachment', 'MultiPicture', 'nvarchar', 100, '附件', '', '附件', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 14, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (40, 2, 'IsNew', 'CheckBox', 'nvarchar', 10, '是否最新', '', '是否最新', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 17, '2014-10-29 16:05:57');
INSERT INTO `cms_contfield` VALUES (41, 3, 'Title', 'SingleText', 'nvarchar', 255, '标题', '请输入标题 (必填√)', '内容标题', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 0, 1, 1, 1, 1, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (42, 3, 'SubTitle', 'SingleText', 'nvarchar', 255, '副标题', '', '内容副标题', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 2, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (43, 3, 'Summary', 'MultipleText', 'nvarchar', 500, '摘要', '内容的简要描述', '内容摘要', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 3, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (44, 3, 'TagKey', 'SingleText', 'nvarchar', 50, '标签', '', '标签', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 10, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (45, 3, 'Author', 'SingleText', 'nvarchar', 50, '作者', '', '作者', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 4, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (46, 3, 'Editor', 'SingleText', 'nvarchar', 50, '编辑', '', '编辑', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 5, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (47, 3, 'Source', 'SingleText', 'nvarchar', 50, '来源', '', '来源', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 6, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (48, 3, 'SourceUrl', 'SingleText', 'nvarchar', 100, '来源地址', '', '来源地址', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Url\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 7, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (49, 3, 'Content', 'MultipleHtml', 'ntext', 50, '正文内容', '', '正文内容', '', '{\"ControlWidth\":98,\"ControlHeight\":350,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 0, 1, 1, 1, 8, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (50, 3, 'ContentImage', 'Picture', 'nvarchar', 100, '图片地址', '', '图片地址', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 11, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (51, 3, 'AutoTimeStamp', 'DateTime', 'datetime', 30, '添加时间', '', '添加时间', '', '{\"ControlWidth\":150,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 21, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (52, 3, 'TemplateFile', 'TemplateFile', 'nvarchar', 100, '模板文件', '', '模板文件', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 15, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (53, 3, 'Hit', 'SingleText', 'nvarchar', 10, '点击率', '', '点击率', '0', '{\"ControlWidth\":60,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 18, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (54, 3, 'Sort', 'SingleText', 'nvarchar', 10, '排序号', '', '排序号', '999', '{\"ControlWidth\":60,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 19, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (55, 3, 'SeoKey', 'MultipleText', 'nvarchar', 255, '搜索关键字', '多个关键字用英文逗号(,)分隔', '搜索关键字', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 12, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (56, 3, 'SeoDescription', 'MultipleText', 'nvarchar', 255, '搜索描述', '', '搜索描述', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 13, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (57, 3, 'IsTop', 'DropDownList', 'nvarchar', 10, '是否置顶', '', '是否置顶', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 15, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (58, 3, 'IsRecommend', 'DropDownList', 'nvarchar', 10, '是否推荐', '', '是否推荐', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 16, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (59, 3, 'Attachment', 'DateTime', 'nvarchar', 100, '附件', '', '附件', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 14, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (60, 3, 'IsNew', 'DropDownList', 'nvarchar', 10, '是否最新', '', '是否最新', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 17, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (61, 4, 'Title', 'SingleText', 'nvarchar', 255, '标题', '请输入标题 (必填√)', '内容标题', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 0, 1, 1, 1, 1, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (62, 4, 'SubTitle', 'SingleText', 'nvarchar', 255, '副标题', '', '内容副标题', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 2, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (63, 4, 'Summary', 'MultipleText', 'nvarchar', 500, '摘要', '内容的简要描述', '内容摘要', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 3, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (64, 4, 'TagKey', 'SingleText', 'nvarchar', 50, '标签', '', '标签', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 10, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (65, 4, 'Author', 'SingleText', 'nvarchar', 50, '作者', '', '作者', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 4, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (66, 4, 'Editor', 'SingleText', 'nvarchar', 50, '编辑', '', '编辑', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 5, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (67, 4, 'Source', 'SingleText', 'nvarchar', 50, '来源', '', '来源', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 6, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (68, 4, 'SourceUrl', 'SingleText', 'nvarchar', 100, '来源地址', '', '来源地址', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Url\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 0, 1, 7, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (69, 4, 'Content', 'MultipleHtml', 'ntext', 50, '正文内容', '', '正文内容', '', '{\"ControlWidth\":98,\"ControlHeight\":350,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 0, 1, 1, 1, 8, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (70, 4, 'ContentImage', 'File', 'nvarchar', 100, '图片地址', '', '图片地址', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 11, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (71, 4, 'AutoTimeStamp', 'DateTime', 'datetime', 30, '添加时间', '', '添加时间', '', '{\"ControlWidth\":150,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 21, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (73, 4, 'Hit', 'SingleText', 'nvarchar', 10, '点击率', '', '点击率', '0', '{\"ControlWidth\":60,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 1, 18, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (74, 4, 'Sort', 'SingleText', 'nvarchar', 10, '排序号', '', '排序号', '999', '{\"ControlWidth\":60,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 19, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (75, 4, 'SeoKey', 'MultipleText', 'nvarchar', 255, '搜索关键字', '多个关键字用英文逗号(,)分隔', '搜索关键字', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 12, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (76, 4, 'SeoDescription', 'MultipleText', 'nvarchar', 255, '搜索描述', '', '搜索描述', '', '{\"ControlWidth\":450,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, 13, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (77, 4, 'IsTop', 'DropDownList', 'nvarchar', 10, '是否置顶', '', '是否置顶', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 15, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (78, 4, 'IsRecommend', 'DropDownList', 'nvarchar', 10, '是否推荐', '', '是否推荐', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 16, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (79, 4, 'Attachment', 'DateTime', 'nvarchar', 255, '附件', '', '附件', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 14, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (80, 4, 'IsNew', 'DropDownList', 'nvarchar', 10, '是否最新', '', '是否最新', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"是|True\"}', 1, 0, 0, 1, 17, '2014-10-29 16:06:46');
INSERT INTO `cms_contfield` VALUES (81, 3, 'ProPhotos', 'MultiPicture', 'nvarchar', 255, '产品相册', '', '', '', '{\"ControlWidth\":98,\"ControlHeight\":200,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 0, 15, '1900-01-01 00:00:00');
INSERT INTO `cms_contfield` VALUES (82, 3, 'ProDocument', 'MultipleHtml', 'ntext', 50, '产品手册', '', '', '', '{\"ControlWidth\":98,\"ControlHeight\":200,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 0, 16, '1900-01-01 00:00:00');
INSERT INTO `cms_contfield` VALUES (83, 4, 'FileDownPath', 'File', 'nvarchar', 100, '文件路径', '', '', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 0, 10, '1900-01-01 00:00:00');
INSERT INTO `cms_contfield` VALUES (84, 1, 'TemplateFile', 'TemplateFile', 'nvarchar', 100, '模板文件', '优先使用此模板', '模板文件', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 15, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (85, 2, 'TemplateFile', 'TemplateFile', 'nvarchar', 100, '模板文件', '优先使用此模板', '模板文件', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 15, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (86, 4, 'TemplateFile', 'TemplateFile', 'nvarchar', 100, '模板文件', '优先使用此模板', '模板文件', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 0, 1, 15, '2014-10-29 16:06:27');
INSERT INTO `cms_contfield` VALUES (87, 2, 'Gallery', 'MultiPicture', 'nvarchar', 50, '相册', '', '', '', '{\"ControlWidth\":100,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 0, 1, 0, 5, '2020-01-13 15:25:44');

-- ----------------------------
-- Table structure for cms_contmodel
-- ----------------------------
DROP TABLE IF EXISTS `cms_contmodel`;
CREATE TABLE `cms_contmodel`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `ModelName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `TableName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ModelDesc` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsUsing` tinyint(4) NULL DEFAULT 1,
  `Creator` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cms_contmodel
-- ----------------------------
INSERT INTO `cms_contmodel` VALUES (1, '普通文章', 'cms_C_Common', '基本模型', 1, 'superadmin', 1, '2014-10-29 16:00:31');
INSERT INTO `cms_contmodel` VALUES (2, '图片文章', 'cms_C_Photo', '', 1, 'admin', 2, '2014-10-29 16:05:57');
INSERT INTO `cms_contmodel` VALUES (3, '产品展示', 'cms_C_Product', '', 1, 'admin', 3, '2014-10-29 16:06:27');
INSERT INTO `cms_contmodel` VALUES (4, '文件下载', 'cms_C_FileDown', '', 1, 'admin', 4, '2014-10-29 16:06:46');

-- ----------------------------
-- Table structure for cms_contnodeext
-- ----------------------------
DROP TABLE IF EXISTS `cms_contnodeext`;
CREATE TABLE `cms_contnodeext`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `NodeID` int(11) NOT NULL DEFAULT 0,
  `ContID` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Fixed;

-- ----------------------------
-- Table structure for cms_feedback
-- ----------------------------
DROP TABLE IF EXISTS `cms_feedback`;
CREATE TABLE `cms_feedback`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `RootID` int(11) NOT NULL DEFAULT 0,
  `ReplyID` int(11) NOT NULL DEFAULT 0,
  `UserID` int(11) NOT NULL DEFAULT 0,
  `UserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Title` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Content` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Phone` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IPAddress` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IPArea` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `IsAudit` tinyint(4) NULL DEFAULT 1,
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_links
-- ----------------------------
DROP TABLE IF EXISTS `cms_links`;
CREATE TABLE `cms_links`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `LinkName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `LinkUrl` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `LinkType` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `LinkText` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `LinkImage` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `LinkFlash` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsAudit` tinyint(4) NULL DEFAULT 0,
  `Sort` int(11) NULL DEFAULT 999,
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cms_links
-- ----------------------------
INSERT INTO `cms_links` VALUES (1, 'SinGooCMS官网', 'http://www.singoo.top', '文字链接', '', '', '', 1, 1, 'zh-cn', '2021-04-12 22:38:21');

-- ----------------------------
-- Table structure for cms_node
-- ----------------------------
DROP TABLE IF EXISTS `cms_node`;
CREATE TABLE `cms_node`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `NodeName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `NodeIdentifier` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ModelID` int(11) NOT NULL DEFAULT 0,
  `ParentID` int(11) NOT NULL DEFAULT 0,
  `ParentPath` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Depth` int(11) NOT NULL DEFAULT 0,
  `ChildList` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `NodeImage` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `NodeBanner` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SeoKey` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SeoDescription` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ItemPageSize` int(11) NULL DEFAULT 10,
  `CustomLink` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Setting` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Remark` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsShowOnMenu` tinyint(4) NULL DEFAULT 1,
  `IsShowOnNav` tinyint(4) NULL DEFAULT 1,
  `IsTop` tinyint(4) NULL DEFAULT 0,
  `IsRecommend` tinyint(4) NULL DEFAULT 0,
  `IsNew` tinyint(4) NULL DEFAULT 0,
  `Creator` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_sitetemplate
-- ----------------------------
DROP TABLE IF EXISTS `cms_sitetemplate`;
CREATE TABLE `cms_sitetemplate`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `TemplateName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ShowPic` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `TemplatePath` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `HomePage` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `TemplateDesc` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsAudit` tinyint(4) NULL DEFAULT 0,
  `IsExists` tinyint(4) NULL DEFAULT 0,
  `Author` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `CopyRight` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsDefault` tinyint(4) NULL DEFAULT 0,
  `Sort` int(11) NULL DEFAULT 999,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_tags
-- ----------------------------
DROP TABLE IF EXISTS `cms_tags`;
CREATE TABLE `cms_tags`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `TagName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `TagUrl` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `TagIndex` int(11) NULL DEFAULT 0,
  `Remark` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsTop` tinyint(4) NULL DEFAULT 0,
  `IsRecommend` tinyint(4) NULL DEFAULT 0,
  `Sort` int(11) NULL DEFAULT 999,
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_thirdpartylogin
-- ----------------------------
DROP TABLE IF EXISTS `cms_thirdpartylogin`;
CREATE TABLE `cms_thirdpartylogin`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `LoginFrom` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `UniqueCert` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `BindUserID` int(11) NOT NULL DEFAULT 0,
  `BindUserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `AccessToken` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `RefreshToken` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `LoginTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_u_person
-- ----------------------------
DROP TABLE IF EXISTS `cms_u_person`;
CREATE TABLE `cms_u_person`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Fixed;

-- ----------------------------
-- Table structure for cms_user
-- ----------------------------
DROP TABLE IF EXISTS `cms_user`;
CREATE TABLE `cms_user`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `GroupID` int(11) NOT NULL DEFAULT 0,
  `LevelID` int(11) NOT NULL DEFAULT 0,
  `Password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Mobile` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Amount` decimal(12, 2) NULL DEFAULT 0.00,
  `Integral` int(11) NULL DEFAULT 0,
  `FileSpace` int(11) NULL DEFAULT 104857600,
  `CertType` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '身份证',
  `CertNo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `NickName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `RealName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Gender` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '男',
  `Birthday` datetime(0) NULL DEFAULT NULL,
  `HeaderPhoto` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `CreditLine` decimal(12, 2) NULL DEFAULT 0.00,
  `Area` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Country` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Province` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `City` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `County` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `PostCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `TelePhone` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `PayPassword` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Remark` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsThirdLoginReg` tinyint(4) NULL DEFAULT 0,
  `Status` tinyint(4) NULL DEFAULT 0,
  `Sort` int(11) NULL DEFAULT 999,
  `LoginCount` int(11) NULL DEFAULT 0,
  `LastLoginTime` datetime(0) NULL DEFAULT NULL,
  `LastLoginIP` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_userfield
-- ----------------------------
DROP TABLE IF EXISTS `cms_userfield`;
CREATE TABLE `cms_userfield`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `UserGroupID` int(11) NOT NULL DEFAULT 0,
  `FieldName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `FieldType` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `DataType` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `DataLength` int(11) NOT NULL DEFAULT 0,
  `FieldAlias` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Tip` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `FieldDesc` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `DefaultValue` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Setting` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `EnableNull` tinyint(4) NULL DEFAULT 1,
  `IsUsing` tinyint(4) NULL DEFAULT 1,
  `IsSystem` tinyint(4) NULL DEFAULT 0,
  `Sort` int(11) NULL DEFAULT 999,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 13 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cms_userfield
-- ----------------------------
INSERT INTO `cms_userfield` VALUES (1, 1, 'RealName', 'SingleText', 'nvarchar', 50, '真实姓名', '', '真实姓名', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 1, '2017-11-01 16:33:29');
INSERT INTO `cms_userfield` VALUES (2, 1, 'Gender', 'RadioButton', 'nvarchar', 50, '性别', '', '性别', '男', '{\"ControlWidth\":100,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"男,女\"}', 1, 1, 1, 2, '2017-11-01 16:33:29');
INSERT INTO `cms_userfield` VALUES (3, 1, 'Birthday', 'DateTime', 'datetime', 50, '出生日期', '', '出生日期', '', '{\"ControlWidth\":150,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":true,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 3, '2017-11-01 16:33:29');
INSERT INTO `cms_userfield` VALUES (4, 1, 'NickName', 'SingleText', 'nvarchar', 50, '昵称', '', '昵称', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 4, '2017-11-01 16:33:29');
INSERT INTO `cms_userfield` VALUES (5, 1, 'HeaderPhoto', 'Picture', 'nvarchar', 50, '头像', '', '头像', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 5, '2017-11-01 16:33:29');
INSERT INTO `cms_userfield` VALUES (6, 1, 'CreditLine', 'SingleText', 'nvarchar', 50, '信用度', '', '信用度', '0', '{\"ControlWidth\":100,\"ControlHeight\":30,\"TextMode\":\"Number\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 6, '2017-11-01 16:33:29');
INSERT INTO `cms_userfield` VALUES (7, 1, 'Country', 'SingleText', 'nvarchar', 50, '国家', '', '国家', '中国', '{\"ControlWidth\":150,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 7, '2017-11-01 16:33:29');
INSERT INTO `cms_userfield` VALUES (8, 1, 'Area', 'SingleText', 'nvarchar', 255, '省市地区', '', '区域', '', '{\"ControlWidth\":300,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 8, '2017-11-01 16:33:29');
INSERT INTO `cms_userfield` VALUES (9, 1, 'Address', 'SingleText', 'nvarchar', 255, '街道地址', '', '街道地址', '', '{\"ControlWidth\":360,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 15, '2017-11-01 16:33:29');
INSERT INTO `cms_userfield` VALUES (10, 1, 'PostCode', 'SingleText', 'nvarchar', 10, '邮编', '', '邮编', '', '{\"ControlWidth\":100,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 16, '2017-11-01 16:33:29');
INSERT INTO `cms_userfield` VALUES (11, 1, 'TelePhone', 'SingleText', 'nvarchar', 50, '家庭电话', '', '家庭电话', '', '{\"ControlWidth\":200,\"ControlHeight\":30,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 17, '2017-11-01 16:33:29');
INSERT INTO `cms_userfield` VALUES (12, 1, 'Remark', 'MultipleText', 'nvarchar', 1000, '备注', '', '备注', '', '{\"ControlWidth\":300,\"ControlHeight\":60,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 1, 1, 1, 18, '2017-11-01 16:33:29');

-- ----------------------------
-- Table structure for cms_usergroup
-- ----------------------------
DROP TABLE IF EXISTS `cms_usergroup`;
CREATE TABLE `cms_usergroup`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `GroupName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `TableName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `GroupDesc` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `Creator` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cms_usergroup
-- ----------------------------
INSERT INTO `cms_usergroup` VALUES (1, '个人会员', 'cms_U_Person', '个人会员组', 999, 'admin', '2017-11-01 16:33:28');

-- ----------------------------
-- Table structure for cms_userlevel
-- ----------------------------
DROP TABLE IF EXISTS `cms_userlevel`;
CREATE TABLE `cms_userlevel`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `LevelName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Integral` int(11) NOT NULL DEFAULT 0,
  `Discount` double NOT NULL DEFAULT 0,
  `LevelDesc` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 7 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of cms_userlevel
-- ----------------------------
INSERT INTO `cms_userlevel` VALUES (1, '初级会员', 0, 0, '', 999, '2012-08-15 23:16:04');
INSERT INTO `cms_userlevel` VALUES (2, '中级会员', 100, 1, '', 2, '2012-08-15 23:16:04');
INSERT INTO `cms_userlevel` VALUES (3, '高级会员', 1000, 1, '', 3, '2012-08-15 23:16:04');
INSERT INTO `cms_userlevel` VALUES (4, '银牌会员', 10000, 1, '', 4, '2012-08-15 23:16:04');
INSERT INTO `cms_userlevel` VALUES (5, '金牌会员', 100000, 0.95, '', 5, '2012-08-15 23:16:04');
INSERT INTO `cms_userlevel` VALUES (6, '钻石会员', 1000000, 0.8, '', 6, '2012-08-15 23:16:04');

-- ----------------------------
-- Table structure for cms_vote
-- ----------------------------
DROP TABLE IF EXISTS `cms_vote`;
CREATE TABLE `cms_vote`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Items` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `IsMultiChoice` tinyint(4) NOT NULL DEFAULT 0,
  `IsAnonymous` tinyint(4) NOT NULL DEFAULT 0,
  `IsAudit` tinyint(4) NULL DEFAULT 0,
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `Remark` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `Creator` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cms_votelog
-- ----------------------------
DROP TABLE IF EXISTS `cms_votelog`;
CREATE TABLE `cms_votelog`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `VoteID` int(11) NOT NULL DEFAULT 0,
  `VoteItemID` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `VoteItemOption` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `UserID` int(11) NOT NULL DEFAULT 0,
  `UserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `IpAddress` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IpArea` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_account
-- ----------------------------
DROP TABLE IF EXISTS `sys_account`;
CREATE TABLE `sys_account`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `AccountName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Password` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Roles` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Mobile` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsSystem` tinyint(4) NULL DEFAULT 0,
  `LoginCount` int(11) NULL DEFAULT 0,
  `LastLoginIP` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `LastLoginArea` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `LastLoginTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 6 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_account
-- ----------------------------
INSERT INTO `sys_account` VALUES (1, 'superadmin', '7189511f9463534d23edb965e211f3c490a3a1c48a72d54eadeb5927096d92823b3e298d1fa7d27cc54adbf7748fb806a9d72ea414a57569fc7abdec693ed76a', '1', 'liqiang665@163.com', '17788760902', 1, 171, '127.0.0.1', '本机地址 CZ88.NET', '2021-04-12 22:35:04', '2012-07-30 17:02:24');
INSERT INTO `sys_account` VALUES (2, 'admin', '7189511f9463534d23edb965e211f3c490a3a1c48a72d54eadeb5927096d92823b3e298d1fa7d27cc54adbf7748fb806a9d72ea414a57569fc7abdec693ed76a', '2', '16826375@qq.com', '17788760902', 1, 194, '127.0.0.1', '本机地址 CZ88.NET', '2021-04-13 10:05:19', '2021-04-12 22:36:02');
INSERT INTO `sys_account` VALUES (5, 'viewer', '0b5f51f0bb18b598503524eed851d1dbf282c4c617bc47ba6a00565ba7a6e62cd1da82fe7ed46369a55367b26998a0b0b894d1f444bcdc9f857a40d25379585d', '6', '', '', 0, 10, '127.0.0.1', '本机地址 CZ88.NET', '2021-03-26 12:23:37', '2021-04-12 22:35:48');

-- ----------------------------
-- Table structure for sys_baseconfig
-- ----------------------------
DROP TABLE IF EXISTS `sys_baseconfig`;
CREATE TABLE `sys_baseconfig`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `SiteName` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `SiteLogo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SiteBanner` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SiteDomain` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `CopyRight` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'SinGooCMS',
  `IcpNo` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `DefaultLang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `EnabledMobile` tinyint(4) NULL DEFAULT 0,
  `BrowseType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'Aspx',
  `UrlRewriteExt` varchar(5) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `GlobalPageSize` int(11) NULL DEFAULT 0,
  `IsCreateStaticHTML` tinyint(4) NULL DEFAULT 0,
  `HtmlNodeFileRule` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `HtmlFileRule` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `HtmlFileExt` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `UserNameType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `UserNameRule` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SysUserName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `CertType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `RegAgreement` mediumtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `RegGiveIntegral` int(11) NULL DEFAULT 0,
  `TgIntegral` int(11) NULL DEFAULT 0,
  `TryLoginTimes` int(11) NULL DEFAULT 5,
  `CookieTime` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `VerifycodeForReg` tinyint(4) NULL DEFAULT 0,
  `VerifycodeForLogin` tinyint(4) NULL DEFAULT 0,
  `VerifycodeForGetPwd` tinyint(4) NULL DEFAULT 0,
  `GetPwdType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `FileCapacity` bigint(20) NULL DEFAULT 104857600,
  `ServMailAccount` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ServMailUserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ServMailUserPwd` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ServMailSMTP` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ServMailPort` int(11) NULL DEFAULT 0,
  `ServMailIsSSL` tinyint(4) NULL DEFAULT 0,
  `ReciverEMail` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SMSClass` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SMSUrl` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SMSUId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SMSPwd` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `EnableFileUpload` tinyint(4) NULL DEFAULT 0,
  `EnableAliyunOSS` tinyint(4) NULL DEFAULT 0,
  `EnableUploadExt` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `UploadSizeLimit` int(11) NULL DEFAULT 0,
  `UploadLimit` int(11) NULL DEFAULT 0,
  `UploadSaveRule` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `UploadImgWidthLimit` int(11) NULL DEFAULT 0,
  `UploadImgHeightLimit` int(11) NULL DEFAULT 0,
  `ThumbSize` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ThumbModel` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'Cut',
  `WaterMarkPosition` tinyint(4) NULL DEFAULT 0,
  `WaterMarkType` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `WaterMarkText` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `WaterMarkTextSize` int(11) NULL DEFAULT 0,
  `WaterMarkTextFont` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `WaterMarkTextColor` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `WaterMarkImage` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `WaterMarkAlpha` double NULL DEFAULT 0,
  `AliyunOSSEnabled` tinyint(4) NULL DEFAULT 0,
  `SEOKey` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SEODescription` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `BadWords` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `BWReplaceWord` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `SiteCapacity` bigint(20) NULL DEFAULT 0,
  `VisitRec` tinyint(4) NULL DEFAULT 0,
  `AllowOutPost` tinyint(4) NULL DEFAULT 0,
  `IsCompressHtml` tinyint(4) NULL DEFAULT 0,
  `Theme` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `DefaultHtmlEditor` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `STATLink` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  PRIMARY KEY (`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_baseconfig
-- ----------------------------
INSERT INTO `sys_baseconfig` VALUES (1, 'SinGooCMS-Demo', '/include/theme/h5/images/login-logo.png', '', 'http://demo.singoo.top', 'copyright @ 2013', '赣ICP备20009447号', '', 1, 'HtmlRewrite', '.html', 10, 1, '/article/${nodedir}', '/article/detail/${id}', '.html', '默认的', '^[a-zA-Z][a-zA-Z0-9@_-]{3,19}', '游客,管理员,超级管理员,admin,superadmin', '普通验证码', '<p>请输入注册协议</p>', 10, 50, 5, '一周', 0, 0, 0, '邮箱找回', 104857600, '16826375@qq.com', '16826375', 'singoocms', 'smtp.qq.com', 465, 1, '', 'AliYunSMS', 'http://api.momingsms.com/', 'LTAI3REvaq4JDLTt', '1DnnagtroDvcka91LOuaKrSCvnkV6b', 1, 0, '.rar|.zip|.jpg|.jpeg|.png|.gif|.doc|.xls|.ppt|.wps|.txt|.swf|.flv|.wmv|.pdf', 20480, 102400, '${year}${month}${day}${millisecond}${rnd}', 600, 400, '400X280', 'Cut', 5, '文字水印', 'SinGooCMS内容管理系统', 50, '黑体', '#ff0000', '', 0.600000023841858, 0, 'SinGooCMS内容管理系统', 'SinGooCMS内容管理系统', '', '[根据国家相关法律不予显示]', 1073741824, 0, 0, 1, 'h5', '/Include/Plugin/ckeditor/', '');

-- ----------------------------
-- Table structure for sys_catalog
-- ----------------------------
DROP TABLE IF EXISTS `sys_catalog`;
CREATE TABLE `sys_catalog`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `CatalogName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `CatalogCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ImagePath` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsSystem` tinyint(4) NULL DEFAULT 0,
  `Remark` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE,
  INDEX `UQ__sys_Cata__5BD51BA60CC90F58`(`CatalogCode`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 8 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_catalog
-- ----------------------------
INSERT INTO `sys_catalog` VALUES (1, '内容管理', 'ContMger', '', 1, '', 1, '2017-10-08 17:11:01');
INSERT INTO `sys_catalog` VALUES (2, '会员管理', 'UserMger', '', 1, '', 2, '2017-10-08 17:11:01');
INSERT INTO `sys_catalog` VALUES (3, '移动端', 'MobMger', '', 1, '', 3, '2017-10-08 17:11:01');
INSERT INTO `sys_catalog` VALUES (4, '微信端', 'WeixinMger', '', 1, '', 4, '2017-10-08 17:11:01');
INSERT INTO `sys_catalog` VALUES (5, '广告管理', 'ADMger', '', 1, '', 5, '2017-10-08 17:11:01');
INSERT INTO `sys_catalog` VALUES (6, '系统配置', 'ConfMger', '', 1, '', 9, '2017-10-08 17:11:01');
INSERT INTO `sys_catalog` VALUES (7, '系统维护', 'SysMger', '', 1, '', 10, '2017-10-08 17:11:01');

-- ----------------------------
-- Table structure for sys_dictitem
-- ----------------------------
DROP TABLE IF EXISTS `sys_dictitem`;
CREATE TABLE `sys_dictitem`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `DictID` int(11) NOT NULL DEFAULT 0,
  `KeyName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `KeyValue` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `IsUsing` tinyint(4) NULL DEFAULT 1,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 16 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_dictitem
-- ----------------------------
INSERT INTO `sys_dictitem` VALUES (6, 2, 'Cert1', '身份证', 1, 1, '1900-01-01 00:00:00');
INSERT INTO `sys_dictitem` VALUES (7, 2, 'Cert2', '军官证', 3, 1, '1900-01-01 00:00:00');
INSERT INTO `sys_dictitem` VALUES (8, 2, 'Cert3', '港澳通行证', 4, 1, '1900-01-01 00:00:00');
INSERT INTO `sys_dictitem` VALUES (9, 2, 'Cert4', '护照', 2, 1, '2014-03-16 10:20:32');
INSERT INTO `sys_dictitem` VALUES (10, 2, 'Cert5', '其它证件', 5, 1, '2014-03-16 10:20:47');
INSERT INTO `sys_dictitem` VALUES (11, 3, '200元以下', '<200', 1, 1, '1900-01-01 00:00:00');
INSERT INTO `sys_dictitem` VALUES (12, 3, '200 ~ 300元', '200-300', 2, 1, '1900-01-01 00:00:00');
INSERT INTO `sys_dictitem` VALUES (13, 3, '301 ~ 500元', '301-500', 3, 1, '1900-01-01 00:00:00');
INSERT INTO `sys_dictitem` VALUES (14, 3, '501 ~ 800元', '501-800', 4, 1, '1900-01-01 00:00:00');
INSERT INTO `sys_dictitem` VALUES (15, 3, '801元以上', '>801', 5, 1, '1900-01-01 00:00:00');

-- ----------------------------
-- Table structure for sys_dicts
-- ----------------------------
DROP TABLE IF EXISTS `sys_dicts`;
CREATE TABLE `sys_dicts`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `DictName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `DictDesc` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `IsUsing` tinyint(4) NULL DEFAULT 1,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE,
  INDEX `UQ__sys_Dict__276F963FD8510368`(`DictName`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 4 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_dicts
-- ----------------------------
INSERT INTO `sys_dicts` VALUES (2, 'CertType', '证件类型', 1, 1, '1900-01-01 00:00:00');
INSERT INTO `sys_dicts` VALUES (3, 'PriceRang', '价格范围', 2, 1, '1900-01-01 00:00:00');

-- ----------------------------
-- Table structure for sys_eventlog
-- ----------------------------
DROP TABLE IF EXISTS `sys_eventlog`;
CREATE TABLE `sys_eventlog`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `UserType` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `UserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `IPAddress` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `IPArea` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `EventInfo` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `EventType` int(11) NOT NULL DEFAULT 0,
  `LoginFailCount` int(11) NULL DEFAULT 0,
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_eventlog
-- ----------------------------
INSERT INTO `sys_eventlog` VALUES (1, 'Manager', 'admin', '127.0.0.1', '本机地址', '登录管理平台成功', 0, 0, 'zh-cn', '2021-04-13 10:05:19');

-- ----------------------------
-- Table structure for sys_fileupload
-- ----------------------------
DROP TABLE IF EXISTS `sys_fileupload`;
CREATE TABLE `sys_fileupload`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `FolderID` int(11) NOT NULL DEFAULT 0,
  `FileName` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `FileExt` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `FileSize` int(11) NOT NULL DEFAULT 0,
  `LocalPath` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `VirtualFilePath` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Thumb` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `OriginalPath` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `UserType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `UserName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `DownloadCount` int(11) NULL DEFAULT 0,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_folder
-- ----------------------------
DROP TABLE IF EXISTS `sys_folder`;
CREATE TABLE `sys_folder`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `FolderName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Remark` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_ipstrategy
-- ----------------------------
DROP TABLE IF EXISTS `sys_ipstrategy`;
CREATE TABLE `sys_ipstrategy`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `IPAddress` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Strategy` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_ipstrategy
-- ----------------------------
INSERT INTO `sys_ipstrategy` VALUES (4, '127.0.0.1', 'ALLOW', '2021-03-26 10:43:11');

-- ----------------------------
-- Table structure for sys_message
-- ----------------------------
DROP TABLE IF EXISTS `sys_message`;
CREATE TABLE `sys_message`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `Receiver` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `MsgBody` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `IsRead` tinyint(4) NULL DEFAULT 0,
  `ReadTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  `HasSend` tinyint(4) NULL DEFAULT 0,
  `SendTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  `Lang` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `AutoTimeStamp` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_module
-- ----------------------------
DROP TABLE IF EXISTS `sys_module`;
CREATE TABLE `sys_module`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `CatalogID` int(11) NOT NULL DEFAULT 0,
  `ModuleName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ModuleCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `FilePath` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ImagePath` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Remark` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsSystem` tinyint(4) NULL DEFAULT 0,
  `Sort` int(11) NULL DEFAULT 999,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 48 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_module
-- ----------------------------
INSERT INTO `sys_module` VALUES (1, 1, '栏目设置', 'NodeMger', 'Node/Index', '', '', 1, 1, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (2, 1, '文章列表', 'ContentMger', 'Content/Index', '', '', 1, 2, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (3, 1, '模型管理', 'ContentModelMger', 'ContModel/Index', '', '', 1, 3, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (4, 1, '模板管理', 'TemplateMger', 'Template/Index', '', '', 1, 4, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (5, 1, '文件参数', 'FileConfigSet', 'FileConfig/Index', '', '', 1, 7, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (6, 1, '文件管理', 'FileMger', 'Upfiles/Index', '', '', 1, 5, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (7, 1, '文件夹管理', 'FolderMger', 'Folder/Index', '', '', 1, 6, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (9, 2, '会员列表', 'UserMger', 'UserMger/Index', '', '', 1, 1, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (10, 2, '会员分组', 'UserGroupMger', 'UserGroup/Index', '', '', 1, 2, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (11, 2, '会员等级', 'UserLevelMger', 'UserLevel/Index', '', '', 1, 3, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (12, 2, '会员设置', 'UserSet', 'UserSet/Index', '', '', 1, 4, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (13, 2, '账户明细', 'AmountOrIntegralDetail', 'AccDetail/Index', '', '', 1, 9, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (14, 2, '信任登录', 'ThirdLoginMger', 'ThirdLogin/Index', '', '', 1, 11, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (15, 3, '移动端设置', 'MobileClientSet', 'MobileSet/Index', '', '', 1, 1, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (16, 3, '短信配置', 'SMSConfig', 'SMSConfig/Index', '', '', 1, 2, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (17, 4, '公众号配置', 'WXConfig', 'WeixinMger/WXConfig', '', '', 1, 1, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (18, 4, '关注回复', 'GuanZhuRlyMger', 'WeixinMger/Guanzhu', '', '', 1, 2, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (19, 4, '默认回复', 'DefaultRlyMger', 'WeixinMger/DefRly', '', '', 1, 3, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (20, 4, '关键字回复', 'MsgkeyRlyMger', 'KeyRly/Index', '', '', 1, 4, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (21, 4, '自定义菜单', 'CustomMenuMger', 'CustomMenu/Index', '', '', 1, 5, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (22, 5, '广告管理', 'ADMger', 'AdPlace/Index', '', '', 1, 1, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (23, 5, '留言反馈', 'Feedback', 'Feedback/Index', '', '', 1, 2, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (24, 5, '友情链接', 'FriendLink', 'FriendLink/Index', '', '', 1, 3, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (25, 6, '基本配置', 'BaseConfig', 'Config/Index', '', '', 1, 1, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (26, 6, '邮件服务', 'EmailService', 'Config/Mail', '', '', 1, 2, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (27, 6, '搜索优化', 'GlobalSEO', 'Config/SiteSeo', '', '', 1, 3, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (29, 6, '其它配置', 'OtherConfig', 'Config/Other', '', '', 1, 5, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (30, 6, '自定义配置', 'CustomSetting', 'SettingCate/Index', '', '', 1, 8, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (31, 6, '数据字典', 'DataDictionary', 'DataDict/Index', '', '', 1, 9, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (32, 7, '菜单管理', 'MenuMger', 'Menu/Index', '', '', 1, 1, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (33, 7, '角色管理', 'RoleMger', 'Role/Index', '', '', 1, 2, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (34, 7, '账号管理', 'AccountMger', 'AccountMger/Index', '', '', 1, 3, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (35, 7, 'IP策略', 'IPStrategyMger', 'IPStrategy/Index', '', '', 1, 4, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (36, 7, '数据备份', 'BackupAndRestore', 'SysMger/DataBackup', '', '', 1, 5, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (38, 7, '访问日志', 'VisitorLogMger', 'VisitorLog/Index', '', '', 1, 7, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (39, 7, '系统日志', 'SystemLogMger', 'SysLog/Index', '', '', 1, 8, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (40, 3, '短信模板', 'SMSTemplateMger', 'SMSTemplate/Index', '', '', 1, 3, '2017-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (41, 1, '标签管理', 'TagsMger', 'Tags/Index', '', '', 1, 10, '2017-11-07 20:00:33');
INSERT INTO `sys_module` VALUES (43, 1, '评论管理', 'CommentMger', 'CommentMger/Index', '', '', 1, 8, '2020-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (45, 1, '投票管理', 'VoteMger', 'VoteMger/Index', '', '', 1, 9, '2020-10-08 17:11:08');
INSERT INTO `sys_module` VALUES (47, 2, '站内消息', 'MessageMger', 'MessageMger/Index', '', '', 1, 10, '2021-03-25 23:46:36');

-- ----------------------------
-- Table structure for sys_operate
-- ----------------------------
DROP TABLE IF EXISTS `sys_operate`;
CREATE TABLE `sys_operate`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `ModuleID` int(11) NOT NULL DEFAULT 0,
  `OperateName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `OperateCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Remark` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 265 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_operate
-- ----------------------------
INSERT INTO `sys_operate` VALUES (1, 1, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (2, 2, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (3, 3, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (4, 4, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (5, 5, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (6, 6, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (7, 7, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (9, 9, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (10, 10, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (11, 11, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (12, 12, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (13, 13, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (14, 14, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (15, 15, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (16, 16, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (17, 17, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (18, 18, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (19, 19, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (20, 20, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (21, 21, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (22, 22, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (23, 23, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (24, 24, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (25, 25, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (26, 26, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (27, 27, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (29, 29, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (30, 30, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (31, 31, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (32, 32, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (33, 33, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (34, 34, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (35, 35, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (36, 36, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (38, 38, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (39, 39, '查看', 'View', '', 1, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (40, 1, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (41, 2, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (42, 3, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (43, 4, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (46, 7, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (48, 9, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (49, 10, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (50, 11, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (53, 14, '配置', 'Configuration', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (59, 20, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (60, 21, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (61, 22, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (62, 23, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (63, 24, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (69, 30, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (70, 31, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (71, 32, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (72, 33, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (73, 34, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (74, 35, '增加', 'Add', '', 2, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (79, 1, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (80, 2, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (81, 3, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (82, 4, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (83, 5, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (85, 7, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (87, 9, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (88, 10, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (89, 11, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (90, 12, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (93, 15, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (94, 16, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (95, 17, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (96, 18, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (97, 19, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (98, 20, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (99, 21, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (100, 22, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (101, 23, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (102, 24, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (103, 25, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (104, 26, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (105, 27, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (107, 29, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (108, 30, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (109, 31, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (110, 32, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (111, 33, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (112, 34, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (113, 35, '修改', 'Modify', '', 3, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (118, 1, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (119, 2, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (120, 3, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (121, 4, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (123, 6, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (124, 7, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (126, 9, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (127, 10, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (128, 11, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (130, 13, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (137, 20, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (138, 21, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (139, 22, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (140, 23, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (141, 24, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (147, 30, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (148, 31, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (149, 32, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (150, 33, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (151, 34, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (152, 35, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (153, 36, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (155, 38, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (156, 39, '删除', 'Delete', '', 4, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (157, 33, '查看权限', 'ViewRolePermission', '', 10, '2021-03-24 00:00:00');
INSERT INTO `sys_operate` VALUES (158, 32, '添加操作', 'AddOperator', '', 10, '2017-10-09 10:31:21');
INSERT INTO `sys_operate` VALUES (159, 34, '设置账户角色', 'SetAccountRole', '', 10, '2017-10-09 10:32:21');
INSERT INTO `sys_operate` VALUES (160, 36, '备份', 'Backup', '', 10, '2017-10-09 12:01:02');
INSERT INTO `sys_operate` VALUES (164, 40, '查看', 'View', NULL, 1, '2017-11-02 18:05:01');
INSERT INTO `sys_operate` VALUES (165, 40, '增加', 'Add', NULL, 2, '2017-11-02 18:05:01');
INSERT INTO `sys_operate` VALUES (166, 40, '修改', 'Modify', NULL, 3, '2017-11-02 18:05:01');
INSERT INTO `sys_operate` VALUES (167, 40, '删除', 'Delete', NULL, 4, '2017-11-02 18:05:01');
INSERT INTO `sys_operate` VALUES (168, 10, '启用字段', 'SetEnabled', '', 10, '2017-11-03 11:07:44');
INSERT INTO `sys_operate` VALUES (169, 10, '停用字段', 'SetUnEnabled', '', 10, '2017-11-03 11:08:01');
INSERT INTO `sys_operate` VALUES (172, 3, '启用字段', 'SetEnabled', '', 10, '2017-11-07 18:25:32');
INSERT INTO `sys_operate` VALUES (173, 3, '停用字段', 'SetUnEnabled', '', 10, '2017-11-07 18:25:46');
INSERT INTO `sys_operate` VALUES (174, 41, '查看', 'View', NULL, 1, '2017-11-07 20:00:55');
INSERT INTO `sys_operate` VALUES (175, 41, '增加', 'Add', NULL, 2, '2017-11-07 20:00:55');
INSERT INTO `sys_operate` VALUES (176, 41, '修改', 'Modify', NULL, 3, '2017-11-07 20:00:55');
INSERT INTO `sys_operate` VALUES (177, 41, '删除', 'Delete', NULL, 4, '2017-11-07 20:00:55');
INSERT INTO `sys_operate` VALUES (190, 37, '查看', 'View', '', 1, '2018-08-22 15:57:46');
INSERT INTO `sys_operate` VALUES (191, 37, '执行SQL语句', 'Query', '', 10, '2018-08-22 15:58:02');
INSERT INTO `sys_operate` VALUES (192, 43, '查看', 'View', '', 1, '2021-03-10 16:13:43');
INSERT INTO `sys_operate` VALUES (193, 43, '增加', 'Add', '', 2, '2021-03-10 16:13:43');
INSERT INTO `sys_operate` VALUES (194, 43, '修改', 'Modify', '', 3, '2021-03-10 16:13:43');
INSERT INTO `sys_operate` VALUES (195, 43, '删除', 'Delete', '', 4, '2021-03-10 16:13:43');
INSERT INTO `sys_operate` VALUES (196, 45, '查看', 'View', '', 1, '2021-03-10 16:13:53');
INSERT INTO `sys_operate` VALUES (197, 45, '增加', 'Add', '', 2, '2021-03-10 16:13:53');
INSERT INTO `sys_operate` VALUES (198, 45, '修改', 'Modify', '', 3, '2021-03-10 16:13:53');
INSERT INTO `sys_operate` VALUES (199, 45, '删除', 'Delete', '', 4, '2021-03-10 16:13:53');
INSERT INTO `sys_operate` VALUES (204, 1, '栏目移动', 'NodeMove', '', 5, '2017-10-08 17:37:39');
INSERT INTO `sys_operate` VALUES (205, 2, '移动到栏目', 'MoveToNode', '', 5, '2021-03-24 00:00:00');
INSERT INTO `sys_operate` VALUES (206, 2, '还原', 'Restore', '', 6, '2021-03-24 12:06:19');
INSERT INTO `sys_operate` VALUES (207, 1, '导入', 'Import', '', 6, '2021-03-24 12:33:38');
INSERT INTO `sys_operate` VALUES (208, 1, '导出', 'Export', '', 7, '2021-03-24 12:33:53');
INSERT INTO `sys_operate` VALUES (209, 32, '删除操作', 'DeleteOperator', '', 11, '2021-03-24 00:00:00');
INSERT INTO `sys_operate` VALUES (210, 33, '设置权限', 'SetRolePermission', '', 11, '2021-03-24 00:00:00');
INSERT INTO `sys_operate` VALUES (211, 36, '还原', 'Restore', '', 11, '2021-03-24 00:00:00');
INSERT INTO `sys_operate` VALUES (212, 4, '设置默认模板', 'SetDefTmpl', '', 10, '2021-03-24 00:00:00');
INSERT INTO `sys_operate` VALUES (213, 4, '查看模板文件', 'ViewTmplFile', '', 11, '2021-03-24 16:18:55');
INSERT INTO `sys_operate` VALUES (215, 4, '创建模板文件', 'CreateTmplFile', '', 12, '2021-03-24 16:18:55');
INSERT INTO `sys_operate` VALUES (216, 4, '修改模板文件', 'ModifyTmplFile', '', 13, '2021-03-24 16:18:55');
INSERT INTO `sys_operate` VALUES (217, 4, '删除模板文件', 'DeleteTmplFile', '', 14, '2021-03-24 16:18:55');
INSERT INTO `sys_operate` VALUES (218, 14, '启用或关闭', 'SetEnableOrClose', '', 3, '2021-03-24 00:00:00');
INSERT INTO `sys_operate` VALUES (219, 10, '查看字段', 'ViewField', '', 20, '2021-03-24 16:44:01');
INSERT INTO `sys_operate` VALUES (220, 10, '增加字段', 'AddField', '', 21, '2021-03-24 16:44:01');
INSERT INTO `sys_operate` VALUES (221, 10, '修改字段', 'ModifyField', '', 22, '2021-03-24 16:44:01');
INSERT INTO `sys_operate` VALUES (222, 10, '删除字段', 'DeleteField', '', 23, '2021-03-24 16:44:01');
INSERT INTO `sys_operate` VALUES (235, 3, '查看字段', 'ViewField', '', 20, '2021-03-24 16:47:15');
INSERT INTO `sys_operate` VALUES (236, 3, '增加字段', 'AddField', '', 21, '2021-03-24 16:47:15');
INSERT INTO `sys_operate` VALUES (237, 3, '修改字段', 'ModifyField', '', 22, '2021-03-24 16:47:15');
INSERT INTO `sys_operate` VALUES (238, 3, '删除字段', 'DeleteField', '', 23, '2021-03-24 16:47:15');
INSERT INTO `sys_operate` VALUES (239, 9, '导出', 'Export', '', 10, '2021-03-24 16:58:09');
INSERT INTO `sys_operate` VALUES (240, 9, '充值', 'Recharge', '', 11, '2021-03-24 17:00:00');
INSERT INTO `sys_operate` VALUES (241, 6, '上传文件', 'Upload', '', 2, '2021-03-24 17:04:57');
INSERT INTO `sys_operate` VALUES (242, 21, '更新客户端', 'UpdateClient', '', 10, '2021-03-24 17:34:32');
INSERT INTO `sys_operate` VALUES (243, 2, '置顶', 'SetTop', '', 10, '2021-03-25 00:00:00');
INSERT INTO `sys_operate` VALUES (244, 2, '推荐', 'SetRecommend', '', 11, '2021-03-25 00:00:00');
INSERT INTO `sys_operate` VALUES (245, 2, '最新', 'SetNew', '', 12, '2021-03-25 00:00:00');
INSERT INTO `sys_operate` VALUES (246, 21, '更新服务端', 'UpdateServer', '', 11, '2021-03-24 17:34:32');
INSERT INTO `sys_operate` VALUES (247, 6, '归档', 'MoveToFolder', '', 3, '2021-03-24 17:04:57');
INSERT INTO `sys_operate` VALUES (248, 47, '查看', 'View', '', 999, '2021-03-25 23:46:35');
INSERT INTO `sys_operate` VALUES (249, 47, '增加', 'Add', '', 999, '2021-03-25 23:46:35');
INSERT INTO `sys_operate` VALUES (251, 47, '删除', 'Delete', '', 999, '2021-03-25 23:46:35');
INSERT INTO `sys_operate` VALUES (264, 34, '设置账户密码', 'SetAccountPwd', '', 11, '2021-03-24 00:00:00');

-- ----------------------------
-- Table structure for sys_purview
-- ----------------------------
DROP TABLE IF EXISTS `sys_purview`;
CREATE TABLE `sys_purview`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `RoleID` int(11) NOT NULL DEFAULT 0,
  `ModuleID` int(11) NOT NULL DEFAULT 0,
  `OperateCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1561 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_purview
-- ----------------------------
INSERT INTO `sys_purview` VALUES (1317, 2, 1, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1318, 2, 1, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1319, 2, 1, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1320, 2, 1, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1321, 2, 1, 'NodeMove', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1322, 2, 1, 'Import', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1323, 2, 1, 'Export', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1324, 2, 2, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1325, 2, 2, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1326, 2, 2, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1327, 2, 2, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1328, 2, 2, 'MoveToNode', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1329, 2, 2, 'Restore', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1330, 2, 2, 'SetTop', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1331, 2, 2, 'SetRecommend', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1332, 2, 2, 'SetNew', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1333, 2, 3, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1334, 2, 3, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1335, 2, 3, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1336, 2, 3, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1337, 2, 3, 'SetEnabled', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1338, 2, 3, 'SetUnEnabled', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1339, 2, 3, 'ViewField', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1340, 2, 3, 'AddField', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1341, 2, 3, 'ModifyField', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1342, 2, 3, 'DeleteField', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1343, 2, 4, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1344, 2, 4, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1345, 2, 4, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1346, 2, 4, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1347, 2, 4, 'SetDefTmpl', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1348, 2, 4, 'ViewTmplFile', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1349, 2, 4, 'CreateTmplFile', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1350, 2, 4, 'ModifyTmplFile', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1351, 2, 4, 'DeleteTmplFile', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1352, 2, 6, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1353, 2, 6, 'Upload', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1354, 2, 6, 'MoveToFolder', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1355, 2, 6, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1356, 2, 7, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1357, 2, 7, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1358, 2, 7, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1359, 2, 7, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1360, 2, 5, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1361, 2, 5, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1362, 2, 43, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1363, 2, 43, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1364, 2, 43, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1365, 2, 43, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1366, 2, 45, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1367, 2, 45, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1368, 2, 45, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1369, 2, 45, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1370, 2, 41, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1371, 2, 41, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1372, 2, 41, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1373, 2, 41, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1374, 2, 9, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1375, 2, 9, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1376, 2, 9, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1377, 2, 9, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1378, 2, 9, 'Export', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1379, 2, 9, 'Recharge', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1380, 2, 10, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1381, 2, 10, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1382, 2, 10, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1383, 2, 10, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1384, 2, 10, 'SetEnabled', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1385, 2, 10, 'SetUnEnabled', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1386, 2, 10, 'ViewField', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1387, 2, 10, 'AddField', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1388, 2, 10, 'ModifyField', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1389, 2, 10, 'DeleteField', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1390, 2, 11, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1391, 2, 11, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1392, 2, 11, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1393, 2, 11, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1394, 2, 12, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1395, 2, 12, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1396, 2, 13, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1397, 2, 13, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1398, 2, 47, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1399, 2, 47, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1400, 2, 47, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1401, 2, 14, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1402, 2, 14, 'Configuration', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1403, 2, 14, 'SetEnableOrClose', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1404, 2, 15, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1405, 2, 15, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1406, 2, 16, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1407, 2, 16, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1408, 2, 40, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1409, 2, 40, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1410, 2, 40, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1411, 2, 40, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1412, 2, 17, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1413, 2, 17, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1414, 2, 18, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1415, 2, 18, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1416, 2, 19, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1417, 2, 19, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1418, 2, 20, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1419, 2, 20, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1420, 2, 20, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1421, 2, 20, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1422, 2, 21, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1423, 2, 21, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1424, 2, 21, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1425, 2, 21, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1426, 2, 21, 'UpdateClient', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1427, 2, 21, 'UpdateServer', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1428, 2, 22, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1429, 2, 22, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1430, 2, 22, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1431, 2, 22, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1432, 2, 23, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1433, 2, 23, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1434, 2, 23, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1435, 2, 23, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1436, 2, 24, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1437, 2, 24, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1438, 2, 24, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1439, 2, 24, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1440, 2, 25, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1441, 2, 25, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1442, 2, 26, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1443, 2, 26, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1444, 2, 27, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1445, 2, 27, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1446, 2, 29, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1447, 2, 29, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1448, 2, 30, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1449, 2, 30, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1450, 2, 30, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1451, 2, 30, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1452, 2, 31, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1453, 2, 31, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1454, 2, 31, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1455, 2, 31, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1456, 2, 35, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1457, 2, 35, 'Add', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1458, 2, 35, 'Modify', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1459, 2, 35, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1460, 2, 36, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1461, 2, 36, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1462, 2, 36, 'Backup', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1463, 2, 36, 'Restore', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1464, 2, 38, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1465, 2, 38, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1466, 2, 39, 'View', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1467, 2, 39, 'Delete', '2021-03-26 10:53:14');
INSERT INTO `sys_purview` VALUES (1514, 6, 1, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1515, 6, 1, 'Add', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1516, 6, 1, 'Modify', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1517, 6, 2, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1518, 6, 2, 'Add', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1519, 6, 2, 'Modify', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1520, 6, 3, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1521, 6, 4, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1522, 6, 6, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1523, 6, 7, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1524, 6, 5, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1525, 6, 43, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1526, 6, 45, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1527, 6, 41, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1528, 6, 9, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1529, 6, 9, 'Add', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1530, 6, 9, 'Modify', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1531, 6, 10, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1532, 6, 11, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1533, 6, 12, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1534, 6, 13, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1535, 6, 47, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1536, 6, 14, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1537, 6, 15, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1538, 6, 16, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1539, 6, 40, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1540, 6, 17, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1541, 6, 18, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1542, 6, 19, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1543, 6, 20, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1544, 6, 21, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1545, 6, 22, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1546, 6, 23, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1547, 6, 24, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1548, 6, 25, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1549, 6, 26, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1550, 6, 27, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1551, 6, 29, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1552, 6, 30, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1553, 6, 31, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1554, 6, 32, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1555, 6, 33, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1556, 6, 34, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1557, 6, 35, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1558, 6, 36, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1559, 6, 38, 'View', '2021-03-26 12:24:26');
INSERT INTO `sys_purview` VALUES (1560, 6, 39, 'View', '2021-03-26 12:24:26');

-- ----------------------------
-- Table structure for sys_role
-- ----------------------------
DROP TABLE IF EXISTS `sys_role`;
CREATE TABLE `sys_role`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Remark` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsSystem` tinyint(4) NULL DEFAULT 1,
  `IsManager` tinyint(4) NULL DEFAULT 1,
  `Sort` int(11) NULL DEFAULT 999,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE,
  INDEX `UQ__sys_Role__8A2B6160F4DCE99D`(`RoleName`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 7 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_role
-- ----------------------------
INSERT INTO `sys_role` VALUES (1, '超级管理员', '系统固有角色,不可移除', 1, 1, 1, '2012-06-27 15:55:20');
INSERT INTO `sys_role` VALUES (2, '内容管理员', 'cms内容管理系统默认管理员', 1, 1, 2, '2014-06-30 11:35:46');
INSERT INTO `sys_role` VALUES (6, '内容查看人员', '', 0, 0, 3, '2021-03-18 14:49:55');

-- ----------------------------
-- Table structure for sys_sendrecord
-- ----------------------------
DROP TABLE IF EXISTS `sys_sendrecord`;
CREATE TABLE `sys_sendrecord`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `SenderType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `MsgType` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `MsgBody` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ValidateCode` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ReciverName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ReciverMedia` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Status` tinyint(4) NULL DEFAULT 0,
  `ReturnMsg` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_setting
-- ----------------------------
DROP TABLE IF EXISTS `sys_setting`;
CREATE TABLE `sys_setting`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `CateID` int(11) NOT NULL DEFAULT 0,
  `KeyName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `KeyValue` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `KeyDesc` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Tip` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ControlType` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `DataType` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `DataLength` int(11) NULL DEFAULT 0,
  `DefaultValue` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Setting` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `IsUsing` tinyint(4) NULL DEFAULT 1,
  `IsSystem` tinyint(4) NULL DEFAULT 0,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE,
  INDEX `UQ__sys_Sett__F0A2A3371B0907CE`(`KeyName`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 58 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_setting
-- ----------------------------
INSERT INTO `sys_setting` VALUES (20, 11, 'MailTemplateForResetPwd', '<div>尊敬的用户${username}:<br />\r\n<br />\r\n您申请找回密码,如果不是您本人的操作,请删除此邮件.<br />\r\n要使用新的密码,请使用以下链接重新设置密码.<br />\r\n<a href=\"${getpwdurl}\" target=\"_blank\">${getpwdurl}</a><br />\r\n(如果无法点击该URL链接地址,请将它复制并粘帖到浏览器的地址输入框,然后单击回车即可.该链接使用后将立即失效.)<br />\r\n注意:请您在收到邮件1个小时内(${expiretime}前)使用,否则该链接将会失效.\r\n<hr />\r\n<div style=\"text-align:right\">${sitename}<br />\r\n${send_date}</div>\r\n</div>', '重置密码邮件', '', 'MultipleHtml', 'ntext', 1000, '', '{\"ControlWidth\":98,\"ControlHeight\":300,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 40, 1, 1, '1900-01-01 00:00:00');
INSERT INTO `sys_setting` VALUES (23, 13, 'SendSMSValidateCode', '尊敬的用户，您的校验码：${code}，请在15分钟内完成验证，切勿泄露于他人！', '发送手机验证码', '', 'MultipleText', 'ntext', 1000, '', '{\"ControlWidth\":600,\"ControlHeight\":100,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\",\"DataFromType\":0}', 10, 1, 1, '1900-01-01 00:00:00');
INSERT INTO `sys_setting` VALUES (25, 11, 'IsSendMailForLY', '', '留言时发送邮件', '', 'CheckBox', 'nvarchar', 50, '', '{\"ControlWidth\":600,\"ControlHeight\":100,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 31, 1, 1, '2014-07-02 15:14:47');
INSERT INTO `sys_setting` VALUES (55, 11, 'ReciverEMail', '', '留言接收邮箱', '', 'SingleText', 'nvarchar', 100, '', '{\"ControlWidth\":200,\"ControlHeight\":0,\"TextMode\":\"Email\",\"IsDataType\":false,\"DataFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 30, 1, 1, '2015-10-12 10:51:48');
INSERT INTO `sys_setting` VALUES (56, 11, 'SendMailValidateCode', '<p>尊敬的用户，您的校验码：${code}，请在15分钟内完成验证，切勿泄露于他人！</p>\r\n\r\n<hr />\r\n<div style=\"text-align:right\">${sitename}<br />\r\n${send_date}</div>', '发送邮件验证码', '', 'MultipleHtml', 'ntext', 1000, '', '{\"ControlWidth\":98,\"ControlHeight\":150,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 10, 1, 1, '2020-06-22 10:46:31');
INSERT INTO `sys_setting` VALUES (57, 7, 'SendRegWelcome', '尊敬的用户：${username}，欢迎您成为我们的会员，如有任何疑问请联系我们的客服人员，谢谢！', '注册成功显示欢迎消息', '', 'MultipleText', 'ntext', 500, '', '{\"ControlWidth\":600,\"ControlHeight\":150,\"TextMode\":\"Text\",\"IsDateType\":false,\"DateFormat\":\"yyyy-MM-dd\",\"DataFrom\":\"Text\",\"DataSource\":\"\"}', 999, 1, 0, '2020-06-23 18:55:44');

-- ----------------------------
-- Table structure for sys_settingcategory
-- ----------------------------
DROP TABLE IF EXISTS `sys_settingcategory`;
CREATE TABLE `sys_settingcategory`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `CateName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `CateDesc` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 999,
  `IsUsing` tinyint(4) NULL DEFAULT 1,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 14 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_settingcategory
-- ----------------------------
INSERT INTO `sys_settingcategory` VALUES (7, 'UserInfo', '会员选项', 0, 1, '2012-08-11 18:34:35');
INSERT INTO `sys_settingcategory` VALUES (11, 'EmailInfo', '邮件信息', 0, 1, '2015-09-26 15:49:17');
INSERT INTO `sys_settingcategory` VALUES (13, 'SMSInfo', '短信配置', 0, 1, '2020-06-08 12:20:26');

-- ----------------------------
-- Table structure for sys_smstemplate
-- ----------------------------
DROP TABLE IF EXISTS `sys_smstemplate`;
CREATE TABLE `sys_smstemplate`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `TemplName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `TemplTitle` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `TemplCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `TemplBody` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `TemplKeys` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for sys_ver
-- ----------------------------
DROP TABLE IF EXISTS `sys_ver`;
CREATE TABLE `sys_ver`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `SoftName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `LicTimeStart` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `LicTimeEnd` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Ver` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `VerCodeNum` int(11) NOT NULL DEFAULT 0,
  `Author` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Company` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Address` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `PostCode` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Mobile` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Remark` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `LastUpdateTime` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of sys_ver
-- ----------------------------
INSERT INTO `sys_ver` VALUES (1, 'SinGooCMS内容管理平台', '0F23B8454E31B721C1BF0107B1BBE96F', '833EF602A6092FFB8E37FAE3A2512882', '1.6', 16000, 'jsonlee', 'SinGooCMS', '中国 • 赣州 • 兴国', '342404', '17788760902', '16826375@qq.com', '.Net Core 3.1（c#）', '2020-07-01 00:00:00');

-- ----------------------------
-- Table structure for sys_visitor
-- ----------------------------
DROP TABLE IF EXISTS `sys_visitor`;
CREATE TABLE `sys_visitor`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `IPAddress` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `OPSystem` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `CustomerLang` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Navigator` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `Resolution` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `UserAgent` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsMobileDevice` tinyint(4) NULL DEFAULT 0,
  `IsSupportActiveX` tinyint(4) NULL DEFAULT 0,
  `IsSupportCookie` tinyint(4) NULL DEFAULT 0,
  `IsSupportJavascript` tinyint(4) NULL DEFAULT 0,
  `IsSupportJavaApplets` tinyint(4) NULL DEFAULT 0,
  `NETVer` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `IsCrawler` tinyint(4) NULL DEFAULT 0,
  `Engine` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `KeyWord` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ApproachUrl` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `VPage` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `GETParameter` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `POSTParameter` mediumtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `CookieParameter` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `ErrMessage` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `StackTrace` mediumtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL,
  `Lang` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT 'zh-cn',
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for weixin_autorly
-- ----------------------------
DROP TABLE IF EXISTS `weixin_autorly`;
CREATE TABLE `weixin_autorly`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `RlyType` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `MsgKey` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `MsgText` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Description` varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `MediaPath` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `LinkUrl` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT '',
  `AutoTimeStamp` datetime(0) NULL DEFAULT NULL,
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for weixin_wxmenu
-- ----------------------------
DROP TABLE IF EXISTS `weixin_wxmenu`;
CREATE TABLE `weixin_wxmenu`  (
  `AutoID` int(11) NOT NULL AUTO_INCREMENT,
  `RootID` int(11) NOT NULL DEFAULT 0,
  `ParentID` int(11) NOT NULL DEFAULT 0,
  `Type` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Name` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `EventKey` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Url` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `ChildCount` int(11) NOT NULL DEFAULT 0,
  `ChildIDs` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL DEFAULT '',
  `Sort` int(11) NULL DEFAULT 66,
  `AutoTimeStamp` datetime(0) NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`AutoID`) USING BTREE,
  INDEX `IDX_AUTOFIELD`(`AutoID`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
