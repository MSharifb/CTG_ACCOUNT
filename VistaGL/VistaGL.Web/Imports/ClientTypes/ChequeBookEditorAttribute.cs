using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class ChequeBookEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.ChequeBookEditor";

        public ChequeBookEditorAttribute()
            : base(Key)
        {
        }
    }
}

