using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace VistaGL
{
    public partial class GetRecommenderInfoByApplicantVoucherEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "VistaGL.GetRecommenderInfoByApplicantVoucherEditor";

        public GetRecommenderInfoByApplicantVoucherEditorAttribute()
            : base(Key)
        {
        }
    }
}

