using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SinGooCMS.MVCBase.Extension
{
    public static class FormFileExtension
    {
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="postFile">表单提交的文件</param>
        /// <param name="physicalPath">物理路径</param>
        public static void SaveAs(this IFormFile postFile, string physicalPath)
        {
            using FileStream fs = File.Create(physicalPath);
            postFile.CopyTo(fs);
            fs.Flush();
        }
    }
}
