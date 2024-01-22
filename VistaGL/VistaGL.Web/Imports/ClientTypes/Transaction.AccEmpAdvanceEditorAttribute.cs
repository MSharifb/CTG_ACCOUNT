using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL.Transaction
{
    public partial class AccEmpAdvanceEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.Transaction.AccEmpAdvanceEditor";

        public AccEmpAdvanceEditorAttribute()
            : base(Key)
        {
        }
    }
}

