namespace SinGooCMS
{
    public interface IField
    {
        /// <summary>
        /// 字段名称 如Title
        /// </summary>
        System.String FieldName { get; set; }

        /// <summary>
        /// 字段类型 如 SingleText 即表单类型                   
        /// </summary>
        System.String FieldType { get; set; }

        /// <summary>
        /// 数据库的数据类型 如 varchar int datetime, 不同的数据库要实时转化
        /// </summary>
        System.String DataType { get; set; }

        /// <summary>
        /// 数据长度，字符类型需要提供长度
        /// </summary>
        System.Int16 DataLength { get; set; }

        /// <summary>
        /// 字段别名，一般是中文名，用于显示
        /// </summary>
        System.String FieldAlias { get; set; }

        /// <summary>
        /// 提示
        /// </summary>
        System.String Tip { get; set; }

        /// <summary>
        /// 字段描述
        /// </summary>
        System.String FieldDesc { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        System.String DefaultValue { get; set; }

        /// <summary>
        /// 设置（json配置），用于配置表单显示的参数（长宽等）
        /// </summary>
        System.String Setting { get; set; }

        /// <summary>
        /// 是否允许为空
        /// </summary>
        System.Boolean EnableNull { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        System.Boolean IsUsing { get; set; }

        /// <summary>
        /// 是否系统，系统字段不可删除
        /// </summary>
        System.Boolean IsSystem { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        System.String Value { get; set; }
    }
}
