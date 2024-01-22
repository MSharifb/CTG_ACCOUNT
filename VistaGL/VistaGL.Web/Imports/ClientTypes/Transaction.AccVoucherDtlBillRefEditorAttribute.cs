using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL.Transaction
{
    public partial class AccVoucherDtlBillRefEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.Transaction.AccVoucherDtlBillRefEditor";

        public AccVoucherDtlBillRefEditorAttribute()
            : base(Key)
        {
        }
    }
}

