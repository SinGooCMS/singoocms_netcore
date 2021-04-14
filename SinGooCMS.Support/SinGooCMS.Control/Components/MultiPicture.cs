using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SinGooCMS.Utility;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Control.Component
{
    public class MultiPicture : FieldControl
    {
        public MultiPicture(ICMSContext _context, IAttachmentRepository _attachmentRepository, IDictItemRepository _dictItemRepository)
        {
            base.context = _context;
            base.attachmentRepository = _attachmentRepository;
            base.dictItemRepository = _dictItemRepository;
        }

        public override FieldType FieldType => FieldType.MultiPicture;

        public override async Task<string> Render()
        {
            string path = $"/views/platform/{context.SiteConfig.Theme}/FieldControls/MultiPictureType.cshtml";
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
                    string tmplRender = tmpl;
                    tmplRender = tmplRender.Replace("${AutoID}", item.AutoID.ToString());
                    tmplRender = tmplRender.Replace("${FilePath}", item.FilePath);
                    tmplRender = tmplRender.Replace("${Remark}", item.Remark);
                    builder.Append(tmplRender);
                }
            }

            txt = txt.Replace("${rows}", builder.ToString());

            return txt;
        }
    }
}
