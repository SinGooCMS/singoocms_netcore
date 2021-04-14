using System.Text;
using System.Threading.Tasks;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Control.Component
{
    public class SingleText : FieldControl
    {
        public SingleText(ICMSContext _context, IAttachmentRepository _attachmentRepository, IDictItemRepository _dictItemRepository)
        {
            base.context = _context;
            base.attachmentRepository = _attachmentRepository;
            base.dictItemRepository = _dictItemRepository;
        }

        public override FieldType FieldType => FieldType.SingleText;

        public override async Task<string> Render()
        {
            string path = $"/views/platform/{context.SiteConfig.Theme}/FieldControls/SingleTextType.cshtml";
            string txt = await FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath(path));

            var builder = new StringBuilder();
            builder.AppendFormat(" type=\"{0}\"", this.Settings.TextMode.ToLower());
            builder.AppendFormat(" id=\"{0}\" name=\"{0}\"", this.FieldName);

            string tipMsg = string.Empty;
            if (this.Settings.ControlWidth > 0)
                builder.AppendFormat(" style=\"width:{0}px\"", this.Settings.ControlWidth);
            if (this.DataLength > 0)
                builder.AppendFormat(" maxlength=\"{0}\"", this.DataLength);

            //点位符
            if (!this.EnableNull)
            {
                //请输入
                tipMsg = context.GetCaption("FieldCtrl_TextInputRequire", "请输入") + this.FieldAlias;
                //tipMsg = "请输入" + this.FieldAlias;
                builder.Append(" required=\"required\"");
            }
            else
            {
                switch (EnumUtils.StringToEnum<TextMode>(this.Settings.TextMode))
                {
                    case TextMode.Email:
                        tipMsg = "yourmail@example.com";
                        break;
                    case TextMode.Url:
                        tipMsg = context.GetCaption("FieldCtrl_UrlFormatTip", "http(s):// 或者 虚拟路径");
                        break;
                    case TextMode.Password:
                        tipMsg = context.GetCaption("FieldCtrl_NothingToChange", "不填写表示不修改");
                        break;
                }
            }

            if (!string.IsNullOrEmpty(this.Tip))
                tipMsg = this.Tip;
            if (!string.IsNullOrEmpty(tipMsg))
                builder.AppendFormat(" placeholder=\"{0}\"", tipMsg);

            if (!string.IsNullOrEmpty(this.FieldValue))
                builder.AppendFormat(" value=\"{0}\"", System.Web.HttpUtility.HtmlEncode(this.FieldValue));
            else if (!string.IsNullOrEmpty(this.DefaultValue))
                builder.AppendFormat(" value=\"{0}\"", System.Web.HttpUtility.HtmlEncode(this.DefaultValue));

            return txt.Replace("<input", "<input" + builder.ToString());
        }
    }
}
