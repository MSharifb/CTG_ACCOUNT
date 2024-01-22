using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL.Configurations
{
    public partial class AccVoucherApiConfigDetailsEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.Configurations.AccVoucherApiConfigDetailsEditor";

        public AccVoucherApiConfigDetailsEditorAttribute()
            : base(Key)
        {
        }
    }
}

