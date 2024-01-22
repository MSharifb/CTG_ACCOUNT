using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class ChequeTypeMappingEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.ChequeTypeMappingEditor";

        public ChequeTypeMappingEditorAttribute()
            : base(Key)
        {
        }
    }
}

