using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class VoucherTemplateDrCrMappingEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.VoucherTemplateDrCrMappingEditor";

        public VoucherTemplateDrCrMappingEditorAttribute()
            : base(Key)
        {
        }
    }
}

