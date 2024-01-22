using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL.Transaction
{
    public partial class VoucherApprovalHistoryEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.Transaction.VoucherApprovalHistoryEditor";

        public VoucherApprovalHistoryEditorAttribute()
            : base(Key)
        {
        }
    }
}

