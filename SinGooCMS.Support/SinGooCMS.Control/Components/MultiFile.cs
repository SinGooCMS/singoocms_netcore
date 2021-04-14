using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Control.Component
{
    public class MultiFile : FieldControl
    {
        public MultiFile(ICMSContext _context, IAttachmentRepository _attachmentRepository, IDictItemRepository _dictItemRepository)
        {
            base.context = _context;
            base.attachmentRepository = _attachmentRepository;
            base.dictItemRepository = _dictItemRepository;
        }

        public override FieldType FieldType => FieldType.MultiFile;

        public override async Task<string> Render()
        {
            string path = $"/views/platform/{context.SiteConfig.Theme}/FieldControls/MultiFileType.cshtml";
            string txt = await FileUtils.ReadFileContentAsync(SinGooBase.GetMapPath(path));

            txt = txt.Replace("${id}", this.FieldName);

            //模板
            var tmpl = txt.Substring(txt.IndexOf("<template>") + "<template>".Length);
            tmpl = tmpl.Substring(0, tmpl.LastIndexOf("</template>"));

            var builder = new StringBuilder();
            var lst = await attachmentRepository.GetMutilAsync(this.FieldValue); //FieldValue 存储的是附件的ID串
            if (lst != null && lst.Count() > 0)
            {
                foreach (var item in lst)
                {
                    tmpl = tmpl.Replace("${AutoID}", item.AutoID.ToString());
                    tmpl = tmpl.Replace("${FilePath}", item.FilePath);
                    tmpl = tmpl.Replace("${Remark}", item.Remark);
                    builder.Append(tmpl);
                }
            }

            txt = txt.Replace("${rows}", builder.ToString());

            return txt;
        }
    }
}