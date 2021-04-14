using System;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility;

namespace SinGooCMS.Control.Component
{
    public class DropDownList : FieldControl
    {
        public DropDownList(ICMSContext _context, IAttachmentRepository _attachmentRepository, IDictItemRepository _dictItemRepository)
        {
            base.context = _context;
            base.attachmentRepository = _attachmentRepository;
            base.dictItemRepository = _dictItemRepository;
        }

        public override FieldType FieldType => FieldType.DropDownList;

        public override async Task<string> Render()
        {
            string path = $"/views/platform/{context.SiteConfig.Theme}/FieldControls/DropDownListType.cshtml";
            string txt = await FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath(path));

            //选中值
            Func<string, string, string, string> func = (defValue, fieldValue, itemValue) =>
            {
                if (!string.IsNullOrEmpty(fieldValue) && itemValue == fieldValue)
                    return "selected='selected'";
                else if (string.IsNullOrEmpty(fieldValue) && !string.IsNullOrEmpty(defValue) && itemValue == defValue)
                    return "selected='selected'";
                return "";
            };

            var builder = new StringBuilder();
            switch (base.Settings.DataFrom)
            {
                case "Text":
                    {
                        /*
                         * 文本数据： 是|True,否|False 或者 男,女,保密
                         * 选项之间用英文逗号分隔 key和value之间用英文状态|分隔
                         */
                        foreach (string str in base.Settings.DataSource.Split(','))
                        {
                            string[] items = str.Split('|');
                            if (items.Length == 2)
                                builder.Append("<option value=\"" + items[1] + "\" " + func(this.DefaultValue, this.FieldValue, items[1]) + ">" + items[0] + "</option>");
                            else
                                builder.Append("<option value=\"" + items[0] + "\" " + func(this.DefaultValue, this.FieldValue, items[0]) + ">" + items[0] + "</option>");
                        }
                    }
                    break;
                case "DataDictionary":
                    {
                        //KeyName是英文名称 KeyVaule显示的是详情 如Cert1/身份证
                        foreach (var item in dictItemRepository.GetCacheItems(base.Settings.DataSource))
                            builder.Append("<option value=\"" + item.KeyName + "\" " + func(this.DefaultValue, this.FieldValue, item.KeyName) + ">" + item.KeyValue + "</option>");
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
                                builder.Append("<option value=\"" + dr["KeyName"].ToString() + "\" " + func(this.DefaultValue, this.FieldValue, dr["KeyName"].ToString()) + ">" + dr["KeyValue"].ToString() + "</option>");
                            }
                        }
                    }
                    break;
            }

            txt = txt.Replace("<select", "<select id=\"" + this.FieldName + "\" name=\"" + this.FieldName + "\"");
            return txt.Replace("</select>", builder.ToString() + "</select>");
        }
    }
}
