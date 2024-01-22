using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL.Configurations
{
    public partial class AccVoucherApiConfigEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.Configurations.AccVoucherApiConfigEditor";

        public AccVoucherApiConfigEditorAttribute()
            : base(Key)
        {
        }
    }
}

