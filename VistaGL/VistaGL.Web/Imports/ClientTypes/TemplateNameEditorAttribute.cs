using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class TemplateNameEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.TemplateNameEditor";

        public TemplateNameEditorAttribute()
            : base(Key)
        {
        }
    }
}

