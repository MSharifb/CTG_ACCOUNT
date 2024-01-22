using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class FinancialReportEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.FinancialReportEditor";

        public FinancialReportEditorAttribute()
            : base(Key)
        {
        }
    }
}

