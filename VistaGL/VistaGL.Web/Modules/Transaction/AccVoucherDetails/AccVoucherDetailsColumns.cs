
namespace VistaGL.Transaction.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("Transaction.AccVoucherDetails")]
    [BasedOnRow(typeof(Entities.AccVoucherDetailsRow))]
    public class AccVoucherDetailsColumns
    {
        [EditLink, Width(300, Min = 200)]
        public String ChartofAccountsAccountName { get; set; }

        [AlignRight, Width(200)]
        public decimal DebitAmount { get; set; }

        [AlignRight, Width(200)]
        public decimal CreditAmount { get; set; }

        public String Description { get; set; }

    }

    [ColumnsScript("Transaction.TransferDetailes")]
    [BasedOnRow(typeof(Entities.AccVoucherDetailsRow))]
    public class TransferDetailesColumns
    {
        [Width(200)]
        public String ChartofAccountsAccountName { get; set; }

        [AlignRight, Width(100)]
        public decimal DebitAmount { get; set; }

        [AlignRight, Width(100)]
        public decimal CreditAmount { get; set; }

        public String Description { get; set; }
    }
}