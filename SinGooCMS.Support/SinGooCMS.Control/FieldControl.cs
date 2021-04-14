using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SinGooCMS.Ado;
using SinGooCMS.Ado.Interface;
using SinGooCMS.Domain.Interface;

namespace SinGooCMS.Control
{
    public class FieldControl : IFieldControl
    {
        protected ICMSContext context;
        protected IAttachmentRepository attachmentRepository;
        protected IDictItemRepository dictItemRepository;
        protected IDbAccess dbAccess = DbProvider.DbAccess;

        public FieldControl()
        {
            //
        }

        #region 公共属性

        public string FieldName { get; set; } = "";

        public virtual FieldType FieldType => FieldType.SingleText;

        public short DataLength { get; set; } = 50;

        public bool EnableNull { get; set; } = false;

        public string FieldAlias { get; set; } = "";

        public string FieldValue { get; set; } = "";

        public FieldSetting Settings { get; set; }

        public string DefaultValue { get; set; }

        public string Tip { get; set; }

        #endregion

        public virtual async Task<string> Render()
        {
            return "singoo-create-MVC-control";
        }
    }
}
