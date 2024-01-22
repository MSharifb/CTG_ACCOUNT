using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class ApprovalStatusEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.ApprovalStatusEditor";

        public ApprovalStatusEditorAttribute()
            : base(Key)
        {
        }

        public String EmptyOptionText
        {
            get { return GetOption<String>("emptyOptionText"); }
            set { SetOption("emptyOptionText", value); }
        }

        public object Items
        {
            get { return GetOption<object>("items"); }
            set { SetOption("items", value); }
        }
    }
}

