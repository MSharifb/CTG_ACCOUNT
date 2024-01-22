
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccTransactionTypeAssign")]
    [BasedOnRow(typeof(Entities.AccTransactionTypeAssignRow))]
    public class AccTransactionTypeAssignForm
    {
        public String TrType { get; set; }
        public Int32 ParentId { get; set; }
        public Int32 CoaId { get; set; }

        //[DisplayName("Debit"), CoADebitEditor, OneWay, CssClass("width6")]
        //public List<Configurations.Entities.AccChartofAccountsRow> CoADebit { get; set; }

        //[DisplayName("Credit"), CoACreditEditor, OneWay, CssClass("width6")]
        //public List<Configurations.Entities.AccChartofAccountsRow> CoACredit { get; set; }
    }
}