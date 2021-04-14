using System.Text;
using System.Threading.Tasks;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Control.Component
{
    public class MultipleText : FieldControl
    {
        public MultipleText(ICMSContext _context, IAttachmentRepository _attachmentRepository, IDictItemRepository _dictItemRepository)
        {
            base.context = _context;
            base.attachmentRepository = _attachmentRepository;
            base.dictItemRepository = _dictItemRepository;
        }

        public override FieldType FieldType => FieldType.MultipleText;

        public override async Task<string> Render()
        {
            string path = $"/views/platform/{context.SiteConfig.Theme}/FieldControls/MultipleTextType.cshtml";
            string txt = await FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath(path));

            var builder = new StringBuilder();
            builder.AppendFormat(" id=\"{0}\" name=\"{0}\"", this.FieldName);

            if (this.Settings.ControlWidth > 0 || this.Settings.ControlHeight > 0)
            {
                builder.Append(" style=\"");

                if (this.Settings.ControlWidth > 0)
                    builder.AppendFormat(" width:{0}px;", this.Settings.ControlWidth);
                if (this.Settings.ControlHeight > 0)
                    builder.AppendFormat(" height:{0}px", this.Settings.ControlHeight);

                builder.Append("\"");
            }

            if (this.DataLength > 0)
                builder.AppendFormat(" maxlength=\"{0}\"", this.DataLength);

            string tipMsg = string.Empty;
            if (!this.EnableNull)
            {
                //请输入
                tipMsg = context.GetCaption("FieldCtrl_TextInputRequire", "请输入") + this.FieldAlias;
                builder.Append(" required=\"required\"");
            }
            if (!string.IsNullOrEmpty(this.Tip))
                tipMsg = this.Tip;
            if (!string.IsNullOrEmpty(tipMsg))
                builder.AppendFormat(" placeholder=\"{0}\"", tipMsg);

            txt = txt.Replace("<textarea", "<textarea" + builder.ToString());

            if (!string.IsNullOrEmpty(this.FieldValue))
                txt = txt.Replace("</textarea>", System.Web.HttpUtility.HtmlEncode(this.FieldValue) + "</textarea>");
            else if (!string.IsNullOrEmpty(this.DefaultValue))
                txt = txt.Replace("</textarea>", System.Web.HttpUtility.HtmlEncode(this.DefaultValue) + "</textarea>");

            return txt;
        }
    }
}
