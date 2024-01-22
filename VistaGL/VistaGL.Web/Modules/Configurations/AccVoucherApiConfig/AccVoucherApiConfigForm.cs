
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccVoucherApiConfig")]
    [BasedOnRow(typeof(Entities.AccVoucherApiConfigRow))]
    public class AccVoucherApiConfigForm
    {
        public String ConfigName { get; set; }
        public String ModuleId { get; set; }
        public String FormName { get; set; }
        public Int32 VouchrTypeId { get; set; }
        public Int32 TransactionId { get; set; }
        public String TransactionMode { get; set; }
        public String Narration { get; set; }
        public Int32 FundControlId { get; set; }
        [AccVoucherApiConfigDetailsEditor]
        public List<Entities.AccVoucherApiConfigDetailsRow> VoucherApiConfigDetails { get; set; }
    }
}