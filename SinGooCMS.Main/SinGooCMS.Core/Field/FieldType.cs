using System;
using System.ComponentModel;

namespace SinGooCMS
{
    /// <summary>
    /// 字段类型
    /// </summary>
    public enum FieldType
    {
        [Description("单行文本")]
        SingleText,
        [Description("多行文本")]
        MultipleText,
        [Description("在线编辑器")]
        MultipleHtml,
        [Description("单选框")]
        RadioButton,
        [Description("复选框")]
        CheckBox,
        [Description("下拉列表")]
        DropDownList,
        [Description("单图上传")]
        Picture,
        [Description("多图上传")]
        MultiPicture,
        [Description("单文件上传")]
        File,
        [Description("多文件上传")]
        MultiFile,
        [Description("日期文本")]
        DateTime,
        [Description("模板文件")]
        TemplateFile
    }
}

