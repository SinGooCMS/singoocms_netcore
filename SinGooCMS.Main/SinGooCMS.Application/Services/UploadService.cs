using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Plugins;
using SinGooCMS.Utility.Extension;
using SinGooCMS.Plugins.OSS;
using SinGooCMS.MVCBase.Extension;
using SinGooCMS.Application.Interface;

namespace SinGooCMS.Application.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IFileUploadRepository fileUploadRepository;
        private readonly ILogService logService;
        private readonly IUser user;
        private readonly IManager manager;
        private readonly ICacheStore cacheStore;

        public FileUploadService(
            IFileUploadRepository _fileUploadRepository,
            ILogService _logService,
            IUser _user,
            IManager _manager,
            ICacheStore _cacheStore
            )
        {
            this.fileUploadRepository = _fileUploadRepository;
            this.logService = _logService;
            this.user = _user;
            this.manager = _manager;
            this.cacheStore = _cacheStore;
        }

        public async Task<Result> UploadByManager(IFormFile postFile, int folderId = -1) =>
            await Upload(postFile, manager.LoginAccount, null, folderId);

        public async Task<Result> UploadByUser(IFormFile postFile, int folderId = -1) =>
            await Upload(postFile, null, user.LoginUser.Value, folderId);

        public async Task<Result> Upload(IFormFile postFile, AccountInfo account, UserInfo user, int folderID = -1)
        {
            var result = Result.fail;
            var config = cacheStore.CacheBaseConfig;

            decimal userMaxSpace = user == null ? 0 : user.FileSpace; //会员分配的文件总量
            decimal userHasUpload = user == null ? 0 : await fileUploadRepository.GetUserUpTotalSize(user.UserName); //会员已上传文件总量

            if (!config.EnableFileUpload)
                return OperateResult.Fail("File_NotEnableFileUpload", "系统设置不允许文件上传");
            else if (postFile == null)
                return OperateResult.Fail("OperationDataNotFound", "操作对象不存在或者已删除");
            else if (postFile.Length == 0)
                return OperateResult.Fail("OperationDataNotFound", "操作对象不存在或者已删除");
            else if (account == null && user == null)
                return OperateResult.Fail("OperationNeedLogin", "操作要求首先登录");
            else if (postFile.Length / 1024 > config.UploadSizeLimit) //转为K再比较
                return OperateResult.Fail("File_FileSizeLimit", "文件尺寸过大");
            else if (!config.EnableUploadExt.Split('|').Contains(Path.GetExtension(postFile.FileName).ToLower()))
                return OperateResult.Fail("File_FileExtFormatNotSupported", "文件格式不支持");
            else if (user != null && userMaxSpace < userHasUpload + postFile.Length / 1024)
                return OperateResult.Fail("File_UserFileSpaceLimit", "用户空间不足");
            else
            {
                //文件名 默认配置 ${year}${month}${day}${millisecond}${rnd}
                string baseName = !config.UploadSaveRule.IsNullOrEmpty()
                    ? StringUtils.GenerateSN(config.UploadSaveRule)
                    : Path.GetFileNameWithoutExtension(postFile.FileName);
                //扩展名
                string ext = Path.GetExtension(postFile.FileName).ToLower();
                //文件名
                string fileName = baseName + ext;
                //上传文件夹
                string uploadDir = SinGooBase.UploadFolder;
                //虚拟路径
                string fileFullName = FileUtils.Combine(uploadDir, fileName);
                //文件的物理路径
                string physicalFilePath = SinGooBase.GetMapPath(fileFullName);
                //OSS文件名
                string ossFileName = string.Empty;

                var model = new FileUploadInfo
                {
                    FolderID = folderID, //文件夹ID -1表示未归类
                    FileName = fileName,
                    FileExt = ext,
                    FileSize = (int)postFile.Length,
                    LocalPath = uploadDir,
                    VirtualFilePath = fileFullName,
                    Thumb = "", //只有图片才有缩略图
                    OriginalPath = postFile.FileName, //原文件
                    UserType = account == null ? UserType.User.ToString() : UserType.Manager.ToString(),
                    UserName = account == null ? user.UserName : account.AccountName,
                    DownloadCount = 0, //下载次数
                    AutoTimeStamp = DateTime.Now
                };

                //水印图物理地址
                var watermarkPhysicalFilePath = SinGooBase.GetMapPath(model.WatermarkFileFullPath);

                #region 上传到服务器                

                if (File.Exists(physicalFilePath))
                    return OperateResult.Fail("文件已经存在");

                if (ext.IsImage())
                {
                    #region 图片处理

                    var uploadImg = Image.FromStream(postFile.OpenReadStream());
                    //图片宽高限制 将裁切
                    if (cacheStore.CacheBaseConfig.UploadImgWidthLimit > 0 && cacheStore.CacheBaseConfig.UploadImgHeightLimit > 0)
                        uploadImg = uploadImg.Compress(cacheStore.CacheBaseConfig.UploadImgWidthLimit, cacheStore.CacheBaseConfig.UploadImgHeightLimit);
                    else if (cacheStore.CacheBaseConfig.UploadImgWidthLimit > 0 && cacheStore.CacheBaseConfig.UploadImgHeightLimit == 0)
                        uploadImg = uploadImg.CompressWidth(cacheStore.CacheBaseConfig.UploadImgWidthLimit);
                    else if (cacheStore.CacheBaseConfig.UploadImgWidthLimit == 0 && cacheStore.CacheBaseConfig.UploadImgHeightLimit > 0)
                        uploadImg = uploadImg.CompressHeight(cacheStore.CacheBaseConfig.UploadImgWidthLimit);

                    //保存图片
                    uploadImg.Save(physicalFilePath);

                    //生成水印图
                    if (config.WaterMarkPosition > 0) //是否启用水印
                    {
                        if (config.WaterMarkType.Equals("文字水印") && config.WaterMarkText.Trim().Length > 0)
                            ImageUtils.AddTextWatermark(physicalFilePath, config.WaterMarkText, config.WaterMarkTextSize, config.WaterMarkTextColor, config.WaterMarkTextFont, (WatermarkPosition)config.WaterMarkPosition, (float)config.WaterMarkAlpha);
                        else if (config.WaterMarkType.Equals("图片水印") && File.Exists(SinGooBase.GetMapPath(config.WaterMarkImage)))
                            ImageUtils.AddImageWatermark(physicalFilePath, SinGooBase.GetMapPath(config.WaterMarkImage), (WatermarkPosition)config.WaterMarkPosition, (float)config.WaterMarkAlpha);
                    }

                    if (File.Exists(watermarkPhysicalFilePath))
                        model.VirtualFilePath = model.WatermarkFileFullPath; //有水印图片

                    //生成缩略图                    
                    int thumbWidth = config.ThumbSize.Split('X').Length > 0 ? config.ThumbSize.Split('X')[0].ToInt() : 100;
                    int thumbHeight = config.ThumbSize.Split('X').Length > 1 ? config.ThumbSize.Split('X')[1].ToInt() : 100;
                    if (uploadImg.Width > thumbWidth || uploadImg.Height > thumbHeight)
                    {
                        //裁切模式
                        var cutMode = config.ThumbModel.IsNullOrEmpty()
                            ? ThumbnailCutMode.Cut
                            : EnumUtils.StringToEnum<ThumbnailCutMode>(config.ThumbModel);

                        //生成缩略图
                        ImageUtils.MakeThumbnail(SinGooBase.GetMapPath(model.VirtualFilePath), thumbWidth, thumbHeight, SinGooBase.GetMapPath(model.ThumbFileFullPath), cutMode);
                        model.Thumb = model.ThumbFileFullPath;
                    }
                    else
                        model.Thumb = fileFullName; //图片太小不足于裁切时，用原图表示      

                    uploadImg.Dispose();

                    #endregion
                }
                else
                    postFile.SaveAs(physicalFilePath); //非图片                

                #endregion

                #region 上传到OSS

                var oss = new AliyunOSS(AliyunOSSConfig.Load());
                if (cacheStore.CacheBaseConfig.EnableAliyunOSS && oss != null)
                {
                    string aliyunFilePath = fileFullName.TrimStart('/'); //去掉第一个 /

                    //有水印图就上传水印图
                    var stream = File.Exists(watermarkPhysicalFilePath)
                        ? new FileStream(watermarkPhysicalFilePath, FileMode.Open)
                        : new FileStream(physicalFilePath, FileMode.Open);

                    //var ossResult = oss.PutObject(aliyunFilePath, postFile.InputStream); //存储到阿里云
                    var ossResult = oss.PutObject(aliyunFilePath, stream); //存储到阿里云
                    if (ossResult != null && ossResult.HttpStatusCode == System.Net.HttpStatusCode.OK)
                    {
                        if (!string.IsNullOrEmpty(oss.Config.CName))
                        {
                            //EndPoint 换成 CName
                            ossFileName = string.Format("http://{0}/{1}", oss.Config.CName, aliyunFilePath);
                        }
                        else
                        {
                            //文件记录为阿里云的文件 如 http://singoocms.oss-cn-shenzhen.aliyuncs.com/201708054062615.gif
                            ossFileName = string.Format("http://{0}.{1}/{2}", oss.Config.BucketName, oss.Config.EndPoint, aliyunFilePath);
                        }
                    }
                }

                #endregion                

                if (ossFileName.ToLower().StartsWith("http"))
                    model.VirtualFilePath = ossFileName; //开启了OSS

                if (await fileUploadRepository.AddAsync(model) > 0)
                {
                    await logService.AddEvent(
                        account == null
                        ? UserType.User
                        : UserType.Manager,
                        account == null
                        ? user.UserName
                        : account.AccountName,
                        $"上传文件[{model.VirtualFilePath}]成功", EventType.Manage);
                }

                return OperateResult.Success("File_UploadFileSuccess", "上传文件成功", model.VirtualFilePath);
            }

            return result;
        }
    }
}
