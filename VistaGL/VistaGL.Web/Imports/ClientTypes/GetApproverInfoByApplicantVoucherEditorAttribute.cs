using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class GetApproverInfoByApplicantVoucherEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.GetApproverInfoByApplicantVoucherEditor";

        public GetApproverInfoByApplicantVoucherEditorAttribute()
            : base(Key)
        {
        }
    }
}

