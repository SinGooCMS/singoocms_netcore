using System;
using System.Text;
using System.Data;
using SinGooCMS.Utility;
using System.Threading.Tasks;
using SinGooCMS.Ado;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Control.Component
{
    public class CheckBox : FieldControl
    {
        public CheckBox(ICMSContext _context, IAttachmentRepository _attachmentRepository, IDictItemRepository _dictItemRepository)
        {
            base.context = _context;
            base.attachmentRepository = _attachmentRepository;
            base.dictItemRepository = _dictItemRepository;
        }

        public override FieldType FieldType => FieldType.CheckBox;

        public override async Task<string> Render()
        {
            string path = $"/views/platform/{context.SiteConfig.Theme}/FieldControls/CheckBoxType.cshtml";
            string txt = await FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath(path));

            //选中值
            Func<string, string, string, string> func = (defValue, fieldValue, itemValue) =>
            {
                if (!string.IsNullOrEmpty(fieldValue) && itemValue == fieldValue)
                    return "checked='checked'";
                else if (fieldValue.IsNullOrEmpty() && !string.IsNullOrEmpty(defValue) && itemValue == defValue)
                    return "checked='checked'";
                return "";
            };

            StringBuilder builder = new StringBuilder();

            switch (base.Settings.DataFrom)
            {
                case "Text":
                    {
                        /*
                         * 文本数据： 是|True,否|False 或者 男,女,保密
                         * 选项之间用英文逗号分隔 key和value之间用英文状态|分隔
                         */
                        int index = 0;
                        foreach (string str in base.Settings.DataSource.Split(','))
                        {
                            string[] items = str.Split('|');
                            if (items.Length == 2)
                                builder.Append(txt.Replace("<input", "<input id=\"" + this.FieldName + "_" + index.ToString() + "\" name=\"" + this.FieldName + "\" " + func(this.DefaultValue, this.FieldValue, items[1])).Replace("${text}", items[0]).Replace("${value}", items[1]));
                            else
                                builder.Append(txt.Replace("<input", "<input id=\"" + this.FieldName + "_" + index.ToString() + "\" name=\"" + this.FieldName + "\" " + func(this.DefaultValue, this.FieldValue, items[0])).Replace("${text}", items[0]).Replace("${value}", items[0]));

                            index++;
                        }
                    }
                    break;
                case "DataDictionary":
                    {
                        //KeyName是英文名称 KeyVaule显示的是详情 如Cert1/身份证
                        int index = 0;
                        foreach (var item in dictItemRepository.GetCacheItems(base.Settings.DataSource))
                        {
                            builder.Append(txt.Replace("<input", "<input id=\"" + this.FieldName + "_" + index.ToString() + "\" name=\"" + this.FieldName + "\" " + func(this.DefaultValue, this.FieldValue, item.KeyName)).Replace("${text}", item.KeyName).Replace("${value}", item.KeyValue));
                            index++;
                        }
                    }
                    break;
                case "SQLQuery":
                    {
                        //在构造sql语句时，需要有KeyName/KeyValue的命名
                        var source = dbAccess.GetDataTable(base.Settings.DataSource);
                        if (source != null && source.Rows.Count > 0)
                        {
                            for (int i = 0; i < source.Rows.Count; i++)
                            {
                                DataRow dr = source.Rows[i];
                                builder.Append(txt.Replace("<input", "<input id=\"" + this.FieldName + "_" + i.ToString() + "\" name=\"" + this.FieldName + "\" " + func(this.DefaultValue, this.FieldValue, dr["KeyName"].ToString())).Replace("${text}", dr["KeyValue"].ToString()).Replace("${value}", dr["KeyName"].ToString()));
                            }
                        }
                    }
                    break;
            }

            return builder.ToString();
        }
    }
}
