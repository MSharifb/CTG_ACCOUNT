
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccBankReconciliationDirect")]
    [BasedOnRow(typeof(Entities.AccBankReconciliationDirectRow))]
    public class AccBankReconciliationDirectColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), Hidden, AlignRight]
        public Int32 Id { get; set; }

        [EditLink]
        public String VoucherNumber { get; set; }

        [AlignRight, QuickFilter]
        public DateTime VoucherDate { get; set; }

        [Width(360)]
        public String PaytoOrReciveFrom { get; set; }

        //public String Description { get; set; }

        [Width(100), QuickFilter]
        public String ChequeNo { get; set; }

        [Width(100), AlignRight, QuickFilter]
        public DateTime ChequeDate { get; set; }

        [Width(100), AlignRight, QuickFilter]
        public decimal Amount { get; set; }

        [AlignRight, QuickFilter]
        public DateTime ClearDate { get; set; }

        [QuickFilter, FilterOnly]
        [TrueFalseEditor]
        public Boolean IsBankReconcile { get; set; }

        //public Boolean IsCash { get; set; }

        //public String TransactionMode { get; set; }
        //public String TransactionType { get; set; }
        //public Int32 CostCentreId { get; set; }
        //public Int32 FundControlInformationId { get; set; }
        //public Int32 BankAccountInformationId { get; set; }
    }
}