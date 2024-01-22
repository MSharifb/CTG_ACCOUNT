using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL.Configurations
{
    public partial class CoAEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.Configurations.CoAEditor";

        public CoAEditorAttribute()
            : base(Key)
        {
        }
    }
}

