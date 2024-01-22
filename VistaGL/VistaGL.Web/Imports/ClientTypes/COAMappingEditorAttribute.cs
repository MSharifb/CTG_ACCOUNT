using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class COAMappingEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.COAMappingEditor";

        public COAMappingEditorAttribute()
            : base(Key)
        {
        }
    }
}

