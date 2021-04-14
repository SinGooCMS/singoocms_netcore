namespace SinGooCMS.Domain.Interface
{
    public interface ISiteBackup : IDependency
    {
        Result CreateDBBack(string bakFileName = "");
        Result CreateSiteBack(string zipFileName = "");
        Result CreateTmplateBack(string zipFileName = "");
        Result CreateUploadBack(string zipFileName = "");
    }

    public class DataBakFile
    {
        public int AutoID { get; set; }
        public string BakFileName { get; set; }
        public string BakFileType { get; set; }
        public string VirtualPath { get; set; } //虚拟路径
        public string EnCodeVPath { get; set; } //被加密的虚拟路径
        public string BakFilePath { get; set; } //完整路径，绝对路径
        public string BakFileSize { get; set; }
        public string Uploader { get; set; }
        public string UploadDate { get; set; }

        /// <summary>
        /// 获取备份文件类型
        /// </summary>
        /// <param name="strBakFileName"></param>
        /// <returns></returns>
        public static string GetBakFileType(string strBakFileName)
        {
            if (strBakFileName.Contains(".bak"))
                return "数据库备份";
            else if (strBakFileName.Contains("_site"))
                return "整站备份";
            else if (strBakFileName.Contains("_template"))
                return "模板备份";
            else if (strBakFileName.Contains("_upload"))
                return "上传文件备份";
            else
                return "其它备份";
        }
    }
}