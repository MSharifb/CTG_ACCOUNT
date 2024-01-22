using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class RecChequeTypeMappingEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.RecChequeTypeMappingEditor";

        public RecChequeTypeMappingEditorAttribute()
            : base(Key)
        {
        }
    }
}

