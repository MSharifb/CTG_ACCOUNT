
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccVoucherApi")]
    [BasedOnRow(typeof(Entities.AccVoucherApiRow))]
    public class AccVoucherApiForm
    {
        public Int32 ConfigId { get; set; }
        public Int32 VouchrTypeId { get; set; }
        public Int32 TransactionId { get; set; }
        public String Narration { get; set; }
        public String TransactionMode { get; set; }
        public Int32 EmpId { get; set; }
    }
}