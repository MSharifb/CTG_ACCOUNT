
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccVoucherApiConfigDetails")]
    [BasedOnRow(typeof(Entities.AccVoucherApiConfigDetailsRow))]
    public class AccVoucherApiConfigDetailsForm
    {
        [LookupEditor("Configurations.AccChartofAccountsForVoucher_Lookup")]
        public Int32 AccountHeadId { get; set; }
        public Int32 SubLedgerId { get; set; }
        public String DrCr { get; set; }
        public String Description { get; set; }
    }
}