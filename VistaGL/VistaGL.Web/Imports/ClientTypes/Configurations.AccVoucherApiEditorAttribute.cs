using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL.Configurations
{
    public partial class AccVoucherApiEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.Configurations.AccVoucherApiEditor";

        public AccVoucherApiEditorAttribute()
            : base(Key)
        {
        }
    }
}

