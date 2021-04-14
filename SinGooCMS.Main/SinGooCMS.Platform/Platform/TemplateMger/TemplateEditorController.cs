using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SinGooCMS.Application;
using SinGooCMS.Domain;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Domain.Models;
using SinGooCMS.Utility;
using SinGooCMS.MVCBase.Filter;

namespace SinGooCMS.Platform.TemplateMger
{
    public class TemplateEditorController : ManagerPageBase
    {
        const string MODULECODE = "TemplateMger";
        private readonly ISiteTemplateRepository siteTemplateRepository;

        public TemplateEditorController(ISiteTemplateRepository _siteTemplateRepository)
        {
            this.siteTemplateRepository = _siteTemplateRepository;
        }

        private string TmplFolder => WebUtils.GetQueryString("folder"); //模板目录
        private string TmplFileName => WebUtils.GetQueryString("file"); //模板文件
        private string TmplFilePath => FileUtils.Combine(TmplFolder, TmplFileName); //模板文件全路径

        private readonly string[] arrEditFileExt = { ".html", ".htm", ".cshtml", ".vml", ".css", ".js", ".txt", ".xml", ".json", ".xml", ".sql", ".xls" };

        #region Post相关操作

        [HttpPost]
        [Permission(MODULECODE, OperationType.CreateTmplFile)]
        public async Task<string> Add(IFormCollection form)
        {
            return await Edit(false);
        }

        [HttpPost]
        [Permission(MODULECODE, OperationType.ModifyTmplFile)]
        public async Task<string> Modify(IFormCollection form)
        {
            return await Edit(true);
        }

        public async Task<string> Edit(bool isModify)
        {
            string partOfFolder = WebUtils.GetFormString("txtFolderPath"); //目录
            string partOfName = WebUtils.GetFormString("txtFileName"); //文件名
            string partOfExt = WebUtils.GetFormString("ddlFileType"); //扩展名
            string inputFileName = partOfName + partOfExt; //文件名
            string inputFilePath = FileUtils.Combine(partOfFolder, partOfName + partOfExt); //文件路径            

            if (string.IsNullOrEmpty(partOfName))
                return OperateResult.FailJson("OperationMainBodyRequire", "操作对象主体信息不完整");
            else if (!arrEditFileExt.Contains(partOfExt.ToLower()))
                return OperateResult.FailJson("File_FileExtFormatNotSupported", "文件格式不正确");
            else
            {
                string fileContent = Request.Form["FileContent"];
                if (!isModify)
                {
                    await FileUtils.CreateFileAsync(SinGooBase.GetMapPath(inputFilePath), fileContent);
                    await LogService.AddEvent("创建模板文件[" + inputFilePath + "]成功");
                    return OperateResult.SuccessJson("OperationSuccess", "操作成功", "reload");
                }
                if (isModify)
                {
                    //更改文件名
                    if (TmplFileName != inputFileName)
                    {
                        FileUtils.ReNameFile(SinGooBase.GetMapPath(partOfFolder), TmplFileName, inputFileName);
                    }

                    await FileUtils.WriteFileContentAsync(SinGooBase.GetMapPath(inputFilePath), fileContent, false);
                    await LogService.AddEvent("修改模板文件[" + inputFilePath + "]成功");
                    return OperateResult.SuccessJson("OperationSuccess", "操作成功", "reload");
                }
            }

            return OperateResult.failJson;
        }

        #endregion

        #region Get呈现模板

        [HttpGet]
        [Permission(MODULECODE,OperationType.ViewTmplFile)]
        public async Task<IActionResult> Index()
        {
            ViewBag.FolderPath = SinGooBase.GetMapPath(TmplFolder);
            ViewBag.FileName = System.IO.Path.GetFileNameWithoutExtension(TmplFileName);
            ViewBag.FileExt = System.IO.Path.GetExtension(TmplFileName);
            ViewBag.FileContent = IsEdit ? await FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath(TmplFilePath)) : ""; //读取模板内容

            return View("TemplateMger/TemplateEditor.cshtml", arrEditFileExt);
        }

        #endregion
    }
}
