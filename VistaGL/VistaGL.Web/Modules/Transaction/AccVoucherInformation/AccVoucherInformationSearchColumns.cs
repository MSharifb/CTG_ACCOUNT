namespace VistaGL.Transaction.Columns
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("Transaction.VoucherInformationSearch")]
    [BasedOnRow(typeof(Entities.AccVoucherInformationRow))]
    public class VoucherInformationSearchColumns
    {
        [Width(250, Min = 250)]
        public String VoucherNo { get; set; }

        [AlignRight, QuickFilter, Width(100), SortOrder(1), DisplayName("Cheque No")]
        public String ChequeRegisterChequeNo { get; set; }

        [AlignRight, QuickFilter, Width(100)]
        public decimal Amount { get; set; }

        [QuickFilter]
        public DateTime VoucherDate { get; set; }

        [QuickFilter]
        public ApprovalStatus? approveStatus { get; set; }

        [AlignCenter]
        public Boolean LinkedWithAutoJV { get; set; }

        [QuickFilter, TrueFalseEditor, AlignCenter]
        public Boolean LinkedWithDebitVoucher { get; set; }

        [QuickFilter, AlignCenter]
        public Boolean PostToLedgerBoolean { get; set; }
        [Width(200), QuickFilter]
        public String PostedByName { get; set; }
        [AlignRight, QuickFilter]
        public DateTime PostingDate { get; set; }

        public String createdUserName { get; set; }

        public DateTime createdUserDate { get; set; }

        [Width(360)]
        public String Description { get; set; }

        //[DisplayName("Mode"), Width(100), AlignCenter]
        //public String TransactionMode { get; set; }

        //[AlignCenter, Width(150)]
        //public String VoucherTypeName { get; set; }

        //[AlignCenter, Width(150)]
        //public String TransactionTypeEntityTransactionType { get; set; }

        //[Width(100), AlignCenter]
        //public String PostingFinancialYearYearName { get; set; }

        [FilterOnly, QuickFilter]
        public Int32 VoucherTypeId { get; set; }

        //[FilterOnly, QuickFilter]
        //public Int32 TransactionTypeEntityId { get; set; }

        [DisplayName("Account Head Bank"), FilterOnly, QuickFilter]
        [LookupEditor("Configurations.AccCoABank_Lookup")]
        public Int32? AccountHeadBankCash { get; set; }

    }
}