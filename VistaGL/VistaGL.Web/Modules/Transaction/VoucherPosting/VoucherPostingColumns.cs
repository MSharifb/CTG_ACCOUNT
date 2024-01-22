
namespace VistaGL.Transaction.Columns
{

    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("Transaction.VoucherPosting")]
    [BasedOnRow(typeof(Entities.AccVoucherInformationRow))]
    public class VoucherPostingColumns
    {
        [Width(220)]
        public String VoucherNo { get; set; }

        [AlignRight, QuickFilter, Width(100), SortOrder(1), DisplayName("Cheque No")]
        public String ChequeRegisterChequeNo { get; set; }

        [AlignRight, QuickFilter, Width(100)]
        public Double Amount { get; set; }

        [AlignRight, QuickFilter, Width(100)]
        public DateTime VoucherDate { get; set; }

        [AlignCenter]
        public Boolean LinkedWithAutoJV { get; set; }

        [FilterOnly, QuickFilter]
        public Int32 VoucherTypeId { get; set; }

        //public Int32 BankAccountInformationId { get; set; }

        //[QuickFilter, FilterOnly, Width(100), DebitCreditEditor]
        //public String VoucherType { get; set; }

        [Width(360)]
        public String PaytoOrReciveFrom { get; set; }

        [Width(360)]
        public String Description { get; set; }

        [QuickFilter, FilterOnly]
        public Int32 CostCentreId { get; set; }

        //[QuickFilter, FilterOnly]
        //public Int32 TransactionTypeEntityId { get; set; }

    }
}