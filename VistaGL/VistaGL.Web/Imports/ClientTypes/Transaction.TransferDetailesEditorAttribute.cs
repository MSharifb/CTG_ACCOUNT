using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL.Transaction
{
    public partial class TransferDetailesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.Transaction.TransferDetailesEditor";

        public TransferDetailesEditorAttribute()
            : base(Key)
        {
        }
    }
}

