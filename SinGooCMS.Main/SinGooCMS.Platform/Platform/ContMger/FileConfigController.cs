using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Utility;
using SinGooCMS.Application;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Plugins.OSS;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.ContMger
{
    public class FileConfigController : ManagerPageBase
    {
        const string MODULECODE = "FileConfigSet";
        private readonly IBaseConfigRepository baseConfigRepository;

        public FileConfigController(IBaseConfigRepository _baseConfigRepository)
        {
            this.baseConfigRepository = _baseConfigRepository;
        }

        #region 文件参数

        #region Post相当操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Modify)]
        public async Task<string> Index(IFormCollection form)
        {
            var config = CacheStore.CacheBaseConfig ?? new Domain.Models.BaseConfigInfo();

            //赋值
            config.EnableFileUpload = WebUtils.GetFormString("CheckBox1") == "on";
            config.EnableUploadExt = WebUtils.GetFormString("TextBox2");
            config.UploadSizeLimit = WebUtils.GetFormVal<int>("TextBox3");
            config.UploadSaveRule = WebUtils.GetFormString("TextBox4");

            config.UploadImgWidthLimit = WebUtils.GetFormVal<int>("WidthLimit"); //图片宽限制
            config.UploadImgHeightLimit = WebUtils.GetFormVal<int>("HeightLimit"); //图片高限制

            //缩略图长
            int width = WebUtils.GetFormVal<int>("TextBox5");
            //缩略图宽
            int height = WebUtils.GetFormVal<int>("TextBox6");

            config.ThumbSize = string.Format("{0}X{1}", width, height);
            config.ThumbModel = WebUtils.GetFormString("ddl_cutmode");
            config.WaterMarkText = WebUtils.GetFormString("TextBox10");
            config.WaterMarkImage = WebUtils.GetFormString("TextBox13");
            config.WaterMarkPosition = (byte)WebUtils.GetFormVal<int>("watermarkstatus");
            config.WaterMarkType = WebUtils.GetFormString("sytype", "文字水印");
            config.WaterMarkTextSize = (short)WebUtils.GetFormVal<int>("TextBox11", 12);
            config.WaterMarkAlpha = WebUtils.GetFormVal<float>("TextBox14", 0.6f);
            config.WaterMarkTextFont = WebUtils.GetFormString("watermarkfontname");
            config.WaterMarkTextColor = WebUtils.GetFormString("TextBox12");
            config.EnableAliyunOSS = WebUtils.GetFormString("CheckBox2") == "on";

            if (await baseConfigRepository.UpdateConfigAsync(config))
            {
                await LogService.AddEvent("更新文件参数成功");
                return OperateResult.successJson;
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult Index()
        {
            ViewBag.WatermarkPosition = LoadPosition(Context.SiteConfig.WaterMarkPosition);
            return View("ContMger/FileConfig.cshtml");
        }

        /// <summary>
        /// 水印位置
        /// </summary>
        /// <param name="selectid"></param>
        public string LoadPosition(int selectid)
        {
            #region 加载水印设置界面

            var builder = new StringBuilder();
            builder.Append("<table style=\"width:256px;height:207px;\" border=\"0\" background=\"/include/theme/h5/images/flower.jpg\">");
            for (int i = 1; i < 10; i++)
            {
                if (i % 3 == 1)
                    builder.Append("<tr>");
                builder.Append((selectid == i ?
                    "<td width=\"33%\" align=\"center\" style=\"vertical-align:middle;\"><label style='display:inline-block'><input class=\"common-check radio\" type=\"radio\" name=\"watermarkstatus\" value=\"" + i + "\" checked><span></span></label><b>#" + i + "</b></td>" :
                    "<td width=\"33%\" align=\"center\" style=\"vertical-align:middle;\"><label style='display:inline-block'><input class=\"common-check radio\" type=\"radio\" name=\"watermarkstatus\" value=\"" + i + "\" ><span></span></label><b>#" + i + "</b></td>"));
                if (i % 3 == 0)
                    builder.Append("</tr>");
            }

            builder.Append("</table><label><input class=\"common-check radio\" type=\"radio\" name=\"watermarkstatus\" value=\"0\" ");
            if (selectid == 0)
                builder.Append(" checked");
            builder.Append("><span></span></lable>不启用水印功能");

            return builder.ToString();

            #endregion
        }

        #endregion

        #endregion

        #region 阿里云OSS

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE,OperationType.Modify)]
        public async Task<string> AliyunOSS(IFormCollection form)
        {
            var ossConfig = new AliyunOSSConfig
            {
                EndPoint = WebUtils.GetFormString("TextBox1"),
                AccessKeyId = WebUtils.GetFormString("TextBox2"),
                AccessKeySecret = WebUtils.GetFormString("TextBox3"),
                BucketName = WebUtils.GetFormString("TextBox4"),
                CName = WebUtils.GetFormString("TextBox5")
            };

            AliyunOSSConfig.Save(ossConfig);
            await LogService.AddEvent("更新阿里云存储(oss)配置成功");
            return OperateResult.successJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE)]
        public IActionResult AliyunOSS()
        {
            return View("ContMger/AliyunOSS.cshtml", AliyunOSSConfig.Load());
        }

        #endregion

        #endregion
    }
}
