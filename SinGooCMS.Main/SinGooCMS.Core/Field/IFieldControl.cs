using System.Threading.Tasks;

namespace SinGooCMS
{
    public interface IFieldControl
    {
        /// <summary>
        /// 控件名称 如 Title
        /// </summary>
        string FieldName { get; set; }

        /// <summary>
        /// 控件类型 如SingleText
        /// </summary>
        //FieldType FieldType { get; set; }
        FieldType FieldType { get; }

        /// <summary>
        /// 控件的别名 如 标题
        /// </summary>
        string FieldAlias { get; set; }

        /// <summary>
        /// 控件的晨大输入长度
        /// </summary>
        short DataLength { get; set; }

        /// <summary>
        /// 控件的值
        /// </summary>
        string FieldValue { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        string DefaultValue { get; set; }

        /// <summary>
        /// 提示
        /// </summary>
        string Tip { get; set; }

        /// <summary>
        /// 控件的表单设置 如表单的宽高、文本类型、数据来源等
        /// </summary>
        FieldSetting Settings { get; set; }

        /// <summary>
        /// 是否允许空
        /// </summary>
        bool EnableNull { get; set; }

        /// <summary>
        /// 呈现html标签
        /// </summary>
        /// <returns></returns>
        Task<string> Render();

    }
}