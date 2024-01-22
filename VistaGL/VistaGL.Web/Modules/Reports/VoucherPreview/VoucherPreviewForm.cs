using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serenity.ComponentModel;
using System.ComponentModel;

namespace VistaGL.Configurations.Forms
{
    [FormScript("Configurations.VoucherPreviewForm")]

    public class VoucherPreviewForm
    {
        [DisplayName("Fund Control")]
        [LookupEditor(typeof(Configurations.Entities.AccFundControlInformationRow))]
        public Int32 FundControlInformationId { get; set; }
    }
}