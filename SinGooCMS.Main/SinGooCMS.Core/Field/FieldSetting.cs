using System;

namespace SinGooCMS
{
    public enum DataFromType 
    {
        Text,
        DataDictionary,
        SQLQuery
    }

    [Serializable]
    public class FieldSetting
    {
        /// <summary>
        /// 表单宽度
        /// </summary>
        public int ControlWidth { get; set; }
        /// <summary>
        /// 表单高度
        /// </summary>
        public int ControlHeight { get; set; }
        /// <summary>
        /// 文本模式 Text Password
        /// </summary>
        public string TextMode { get; set; }
        /// <summary>
        /// 是否日期
        /// </summary>
        public bool IsDateType { get; set; }
        /// <summary>
        /// 日期格式 yyyy-MM-dd / yyyy-MM-dd hh:mm:ss
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// 数据来源 Text(文本列表),DataDictionary(数据字典),SQLQuery(SQL查询)
        /// </summary>
        public string DataFrom { get; set; }
        /// <summary>
        /// 数据信息
        /// </summary>
        public string DataSource { get; set; }
        /// <summary>
        /// 数据来源类型
        /// </summary>
        public DataFromType DataFromType => SinGooCMS.Utility.EnumUtils.StringToEnum<DataFromType>(this.DataFrom);
    }
}
