using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class BRTransactionTypeEditorDDLAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.BRTransactionTypeEditorDDL";

        public BRTransactionTypeEditorDDLAttribute()
            : base(Key)
        {
        }
    }
}

