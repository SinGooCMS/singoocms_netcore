using System.Text;
using System.Threading.Tasks;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Interface;
using SinGooCMS.Utility.Extension;

namespace SinGooCMS.Control.Component
{
    public class DateTime : FieldControl
    {
        public DateTime(ICMSContext _context, IAttachmentRepository _attachmentRepository, IDictItemRepository _dictItemRepository)
        {
            base.context = _context;
            base.attachmentRepository = _attachmentRepository;
            base.dictItemRepository = _dictItemRepository;
        }

        public override FieldType FieldType => FieldType.DateTime;

        public override async Task<string> Render()
        {
            string path = $"/views/platform/{context.SiteConfig.Theme}/FieldControls/DateTimeType.cshtml";
            string txt = await FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath(path));

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(" id=\"{0}\" name=\"{0}\"", this.FieldName);

            if (this.Settings.ControlWidth > 0)
                builder.AppendFormat(" style=\"width:{0}px\"", this.Settings.ControlWidth);
            if (this.DataLength > 0)
                builder.AppendFormat(" maxlength=\"{0}\"", this.DataLength);
            if (!this.EnableNull)
                builder.Append(" required=\"required\"");
            if (!string.IsNullOrEmpty(this.Tip))
                builder.AppendFormat(" placeholder=\"{0}\"", this.Tip);
            if (!string.IsNullOrEmpty(this.Settings.DateFormat))
                builder.AppendFormat(" singoo-date-format=\"{0}\"", this.Settings.DateFormat);
            else
                builder.AppendFormat(" singoo-date-format=\"{0}\"", "yyyy-MM-dd");

            string dateFormat = this.Settings.DateFormat;
            if (string.IsNullOrEmpty(dateFormat))
                dateFormat = "yyyy-MM-dd";
            if (!string.IsNullOrEmpty(this.FieldValue))
                builder.AppendFormat(" value=\"{0}\"", this.FieldValue.ToDateTime().ToString(dateFormat));
            else if (!string.IsNullOrEmpty(this.DefaultValue))
                builder.AppendFormat(" value=\"{0}\"", this.DefaultValue.ToDateTime().ToString(dateFormat));
            else
                builder.AppendFormat(" value=\"{0}\"", System.DateTime.Now.ToString(dateFormat)); //默认当前日期时间

            return txt.Replace("<input", "<input" + builder.ToString());
        }
    }
}
