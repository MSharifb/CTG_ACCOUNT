
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccChequePreparation")]
    [BasedOnRow(typeof(Entities.AccVoucherInformationRow))]
    public class AccChequePreparationColumns
    {
        [Visible(false)]
        public Int64 Id { get; set; }

        [Width(220)]
        public String VoucherNo { get; set; }

        [Width(100), AlignRight, QuickFilter, SortOrder(1, descending: true)]
        public DateTime VoucherDate { get; set; }

        [Width(100), AlignRight]
        public Double Amount { get; set; }

        [Width(360), DisplayName("Pay to")]
        public String PaytoOrReciveFrom { get; set; }

        [Width(150), DisplayName("Cheque No.")]
        public String ChequeRegisterChequeNo { get; set; }

        public String ChequeRemarks { get; set; }

        [Width(150), DisplayName("Bank Account No.")]
        public String BankAccountInformationAccountNumber { get; set; }

        [Width(100), QuickFilter()]
        [TrueFalseEditor]
        public Boolean IsChequePrepared { get; set; }

        //public Boolean LinkedWithAutoJv { get; set; }
    }
}