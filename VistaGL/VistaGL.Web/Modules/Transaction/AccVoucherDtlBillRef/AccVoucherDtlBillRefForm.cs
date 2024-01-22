
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccVoucherDtlBillRef")]
    [BasedOnRow(typeof(Entities.AccVoucherDtlBillRefRow))]
    public class AccVoucherDtlBillRefForm
    {
        [Required]
        public DateTime BillDate { get; set; }
        [BillTypeEditor, Required]
        public String BillType { get; set; }
        public String BillRefNo { get; set; }
        [Required]
        public Double Amount { get; set; }


        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }
        //public Int16 IsPaymentComplete { get; set; }
        //public Int32 VoucherDetailId { get; set; }
    }
}