using System.Text;
using System.Threading.Tasks;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Control.Component
{
    public class Picture : FieldControl
    {
        public Picture(ICMSContext _context, IAttachmentRepository _attachmentRepository, IDictItemRepository _dictItemRepository)
        {
            base.context = _context;
            base.attachmentRepository = _attachmentRepository;
            base.dictItemRepository = _dictItemRepository;
        }

        public override FieldType FieldType => FieldType.Picture;

        public override async Task<string> Render()
        {
            string path = $"/views/platform/{context.SiteConfig.Theme}/FieldControls/PictureType.cshtml";
            string txt = await FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath(path));

            var builder = new StringBuilder();
            builder.AppendFormat(" id=\"{0}\" name=\"{0}\"", this.FieldName);

            if (this.Settings.ControlWidth > 0)
                builder.AppendFormat(" style=\"width:{0}px\"", this.Settings.ControlWidth);
            if (this.DataLength > 0)
                builder.AppendFormat(" maxlength=\"{0}\"", this.DataLength);
            if (!this.EnableNull)
                builder.Append(" required=\"required\"");
            if (!string.IsNullOrEmpty(this.Tip))
                builder.AppendFormat(" placeholder=\"{0}\"", this.Tip);

            if (!string.IsNullOrEmpty(this.FieldValue))
                builder.AppendFormat(" value=\"{0}\"", this.FieldValue);
            else if (!string.IsNullOrEmpty(this.DefaultValue))
                builder.AppendFormat(" value=\"{0}\"", this.DefaultValue);

            return txt.Replace("<input type=\"text\"", "<input type=\"text\"" + builder.ToString()).Replace("${id}", this.FieldName);
        }
    }
}
