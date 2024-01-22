using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class BillTypeEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.BillTypeEditor";

        public BillTypeEditorAttribute()
            : base(Key)
        {
        }
    }
}

