
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccTransactionTypeAssignMaster")]
    [BasedOnRow(typeof(Entities.AccTransactionTypeAssignMasterRow))]
    public class AccTransactionTypeAssignMasterForm
    {

        public Int32 VoucherTypeId { get; set; }
        public Int32 TransactionTypeId { get; set; }
        public String Remarks { get; set; }

        [DisplayName("Debit"), CoADebitEditor, CssClass("width6")]
        public List<Entities.AccTransactionTypeAssignRow> CoADebit { get; set; }

        [DisplayName("Credit"), CssClass("width6"), OneWay]
        public String Credit { get; set; }

        //[DisplayName("Credit"), CoACreditEditor, CssClass("width6")]
        //public List<Entities.AccTransactionTypeAssignRow> CoACredit { get; set; }
    }
}