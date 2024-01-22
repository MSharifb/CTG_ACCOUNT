
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.BankReconciliationColumns")]
    [BasedOnRow(typeof(Entities.AccBankReconciliationDirectRow))]
    public class BankReconciliationColumns
    {
        public decimal CreditAmount { get; set; }
        public decimal DebitAmount { get; set; }

        public String VoucherNumber { get; set; }
        public DateTime VoucherDate { get; set; }
        public DateTime ClearDate { get; set; }
        public decimal Amount { get; set; }
        public String Description { get; set; }

        [QuickFilter, FilterOnly]
        public Int32 BankAccountInformationId { get; set; }
    }
}