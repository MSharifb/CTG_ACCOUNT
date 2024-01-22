namespace VistaGL.Transaction.Columns
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("Transaction.VoucherApproval")]
    [BasedOnRow(typeof(Entities.AccVoucherInformationRow))]
    public class VoucherApprovalColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 Id { get; set; }

        //[EditLink]
        //public String AmountInWords { get; set; }
        //public DateTime ClearDate { get; set; }

        // public String FundControlInformationFundControlName { get; set; }

        [EditLink, Width(200)]
        public String VoucherNo { get; set; }

        //public String FileNo { get; set; }

        [AlignRight, QuickFilter, Width(100), SortOrder(1), DisplayName("Cheque No")]
        public String ChequeRegisterChequeNo { get; set; }

        [AlignRight, QuickFilter, Width(100)]
        public Double Amount { get; set; }

        [AlignRight, QuickFilter, Width(100)]
        public DateTime VoucherDate { get; set; }

        [AlignCenter]
        public Boolean LinkedWithAutoJV { get; set; }

        [QuickFilter, AlignCenter]
        [TrueFalseEditor]
        public Boolean LinkedWithDebitVoucher { get; set; }

        [FilterOnly, QuickFilter]
        public Int32 VoucherTypeId { get; set; }

        //public Int32 BankAccountInformationId { get; set; }

        [QuickFilter, Width(100), DebitCreditEditor]
        public String VoucherType { get; set; }

        [QuickFilter, QuickFilterOption("multiple", true)]
        public string approveStatus { get; set; }

        //public String HeadDescription { get; set; }
        //public Int16 IsApproved { get; set; }
        //public Int16 IsAuto { get; set; }
        //public Int16 IsBankReconcile { get; set; }
        //public Int16 IsCash { get; set; }
        //public Int16 IsSubmitted { get; set; }
        //public String MenuName { get; set; }
        //public Int32 Mid { get; set; }
        //public String NoteType { get; set; }
        //public String PageNo { get; set; }
        //public Double PaymentAmount { get; set; }
        //public String PaymentamountInWords { get; set; }

        [Width(360)]
        public String PaytoOrReciveFrom { get; set; }

        public String createdUserName { get; set; }

        public DateTime createdUserDate { get; set; }

        //public Int16 PostToLedger { get; set; }
        //public String PostedBy { get; set; }
        //public DateTime PostingDate { get; set; }
        //public String PostingNumber { get; set; }
        //public String PreparedBy { get; set; }
        //public String SubModule { get; set; }

        //public String TransactionMode { get; set; }

        //[Width(150), AlignCenter]
        //public String TransactionTypeEntityTransactionType { get; set; }

        //  public String TransferType { get; set; }

        // public String VoucherNumber { get; set; }
        //   public Int32 VoucherTag { get; set; }

        //   public String CostCentreName { get; set; }
        //    public String VoucherTypeName { get; set; }

        //[Width(360)]
        //public String Description { get; set; }

        //[Width(110), AlignCenter]
        //public String PostingFinancialYearYearName { get; set; }

        [DisplayName("Account Head Bank"),FilterOnly, QuickFilter]
        [LookupEditor("Configurations.AccCoABank_Lookup")]
        public Int32? AccountHeadBankCash { get; set; }
    }


}