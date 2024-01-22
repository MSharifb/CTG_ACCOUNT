using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class AccHeadTypeMappingEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.AccHeadTypeMappingEditor";

        public AccHeadTypeMappingEditorAttribute()
            : base(Key)
        {
        }
    }
}

