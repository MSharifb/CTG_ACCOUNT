using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class ReconciliationEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.ReconciliationEditor";

        public ReconciliationEditorAttribute()
            : base(Key)
        {
        }
    }
}

