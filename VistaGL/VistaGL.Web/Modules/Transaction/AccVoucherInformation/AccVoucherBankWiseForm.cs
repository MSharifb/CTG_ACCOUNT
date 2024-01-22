
using VistaGL.Transaction.Entities;

namespace VistaGL.Transaction.Forms
{
    using _Ext;
    using Serenity.ComponentModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [FormScript("Transaction.AccVoucherBankWise")]
    [BasedOnRow(typeof(Entities.AccVoucherInformationRow))]
    public class AccVoucherBankWiseForm
    {
        [Category("Approval Information")]
        #region Approval Information
        [GetRecommenderInfoByApplicantVoucherEditor, CssClass("width6")]
        public Int32 ApproverId { get; set; }

        [CssClass("width6"), DefaultValue(ApprovalStatus.Draft), ReadOnly(true)]
        public ApprovalStatus approveStatus { get; set; }

        [Visible(false), DefaultValue(false)]
        public bool IsBankWisePaymentVoucher { get; set; }

        [Visible(false), DefaultValue(false)]
        public bool IsBankWiseReceiptVoucher { get; set; }
        #endregion

        [Category("Voucher Information")]
        #region Voucher Information
        [Visible(false)]
        public Int64? Id { get; set; }

        [CssClass("width6"), ReadOnly(true), Visible(false)]
        public Int32 VoucherTypeId { get; set; }

        [CssClass("width6"), Visible(false)]
        public String TransactionMode { get; set; }

        [Hidden()]
        public Int32 PostingFinancialYearId { get; set; }

        [CssClass("width4")]
        public Int32 TransactionTypeEntityId { get; set; }

        [CssClass("width4")]
        public DateTime VoucherDate { get; set; }

        [CssClass("width4")]
        public String VoucherNo { get; set; }

        #region New Cheque Register --

        [CssClass("width6"), DisplayName("Account Bank/Cash")]
        [LookupEditor("Configurations.AccCoABank_Lookup")]
        public Int32 AccountHeadBankCash { get; set; }

        [Visible(false)]
        public Int32 BankAccountInformationId { get; set; }

        [CssClass("width6")]
        public Int32 ChequeBookId { get; set; }

        [CssClass("width4"), ChequeBookEditor]
        public Int32 ChequeNumhdn { get; set; }

        [Visible(false)]
        public String ChequeNo { get; set; }

        [CssClass("width4")]
        public DateTime ChequeDate { get; set; }

        [CssClass("width4"), ChequeTypeMappingEditor, DefaultValue("CashCheque")]
        public String ChequeType { get; set; }

        [CssClass("width6"), DefaultValue("--"), Required]
        public String ChequeRemarks { get; set; }

        [AutoCompleteEditor(LookupKey = "Transaction.AccCostCentreOrInstituteInformation_LookupForAutoComplete")]
        [CssClass("width6"), DisplayName("Pay To"), Required]
        public String PaytoOrReciveFrom { get; set; }

        [Visible(false)]
        public Boolean IsChequeFinished { get; set; }

        [CssClass("width6"), DisplayName("Bank Amount"), Required, DefaultValue(0)]
        public decimal BankAmount { get; set; }

        [CssClass("width6"), DisplayName("Pay to For Bank Advice")]
        public String PaytoForBankAdvice { get; set; }

        [CssClass("width4"), OneWay, Visible(false)]
        public Int32 ChequeRegisterId { get; set; }

        #endregion


        [HalfWidth]
        public String PowerofAttorney { get; set; }
        //public Int32? ZoneId { get; set; }

        [CssClass("width6")]
        public Int32? NOAId { get; set; }

        [OneWay, Visible(false)]
        public Int32? NOAId2 { get; set; }

        [CssClass("width12")]
        public Boolean LinkedWithAutoJV { get; set; }

        #region Auto Journal Voucher Properties
        //
        [CssClass("width9"), DisplayName("(PV) Account Head"), Visible(false)]
        [LookupEditor("Configurations.AccChartofAccountsForVoucher_Lookup")]
        public Int32 AutoPV_AccountHead { get; set; }

        [CssClass("width3"), DisplayName("Budget(COA)"), OneWay, ReadOnly(true), Visible(false)]
        public Decimal AutoBudgetAmountCOA { get; set; }


        [CssClass("width9"), DisplayName("(PV) Sub Ledger"), Visible(false)]
        [LookupEditor("Transaction.AccCostCentreOrInstituteInformation_Lookup")]
        public Int32 AutoPV_CostCentreId { get; set; }

        [CssClass("width3"), DisplayName("Budget(SUb-ledger)"), OneWay, ReadOnly(true), Visible(false)]
        public Decimal AutoBudgetAmountSUbledger { get; set; }

        [CssClass("width4"), DisplayName("Linked Journal Voucher No"), Visible(false)]
        public String AutoJVVoucherNo { get; set; }

        [Visible(false)]
        public String AutoJVVoucherNumber { get; set; }

        [Visible(false)]
        public Int32 TransactionTypeEntityIdForAutoJV { get; set; }
        //
        #endregion

        //  PAYMENT
        [Hidden]
        public String TransactionType { get; set; }

        // Debit
        [Hidden]
        public String VoucherType { get; set; }

        [Hidden]
        public String VoucherNumber { get; set; }

        #endregion

        [Category("Account Information")]
        #region Account Information

        [CssClass("width9"), DisplayName("Account Head"), OneWay]
        [LookupEditor("Configurations.AccChartofAccountsForVoucher_Lookup")]
        public Int32 AccountHead { get; set; }

        [CssClass("width3"), DisplayName("Budget(COA)"), OneWay, ReadOnly(true)]
        public Decimal BudgetAmountCOA { get; set; }

        [CssClass("width6")]
        // [LookupEditor(typeof(Configurations.Entities.AccCostCenterTypeRow))]
        public Int16 CostCenterTypeId { get; set; }

        [CssClass("width6")]
        public Int32 ParentId { get; set; }

        [CssClass("width9")]
        public Int32 CostCentreId { get; set; }

        [CssClass("width3"), DisplayName("Budget(SUb-ledger)"), OneWay, ReadOnly(true)]
        public Decimal BudgetAmountSUbledger { get; set; }

        [CssClass("width3"), DisplayName("Multiple Sub Ledger"), OneWay, Visible(false)]
        public bool MultipleCostCenter { get; set; }

        [CssClass("width3"), DisplayName("Debit"), OneWay, DefaultValue(0)]
        public decimal DebitAmount { get; set; }

        [CssClass("width3"), DisplayName("Credit"), OneWay, DefaultValue(0)]
        public decimal CreditAmount { get; set; }

        #region Calculation Rate & Amount

        [DisplayName("Calculation Rate"), OneWay, CssClass("width6")]
        public decimal CalculationRate { get; set; }

        [DisplayName("Calculation Amount"), OneWay, CssClass("width3")]
        public decimal CalculationAmount { get; set; }

        #endregion Calculation Rate & Amount

        [CssClass("width3")]
        [VoucherTemplateDrCrMappingEditor]
        public string Type { get; set; }

        [CssClass("width6"), DisplayName("Description"), OneWay]
        public String DDescription { get; set; }

        [DisplayName(""), OneWay]
        public String AddtoGrid { get; set; }

        [AccVoucherDetailsEditor]
        public List<Entities.AccVoucherDetailsRow> VoucherDetails { get; set; }
        //
        [CssClass("width6"), DisplayName("Account Bank/Cash"), ReadOnly(true)]
        public string AccountBankCash { get; set; }

        [CssClass("width6"), DisplayName("Account Bank/Cash Amount"), ReadOnly(true)]
        public decimal AccountBankCashAmount { get; set; }

        [CssClass("width6"), DisplayName("Debit Amount"), OneWay, ReadOnly(true)]
        public decimal DAmount { get; set; }

        [CssClass("width6"), DisplayName("Credit Amount"), OneWay, ReadOnly(true)]
        public decimal CAmount { get; set; }

        //   public decimal EffectiveValue { get; set; }

        [ReadOnly(true)]
        public String AmountInWords { get; set; }

        [CssClass("width6"), ReadOnly(true)]
        public decimal Amount { get; set; }

        [CssClass("width6"), Visible(false)]
        public Int32 ProjectID { get; set; }

        [Visible(false)]
        public DateTime? ClearDate { get; set; }

        [Visible(false)]
        public Int32? IsClearDate { get; set; }

        [TextAreaEditor(Rows = 3)]
        public String Description { get; set; }

        [Hidden()]
        public String PostedBy { get; set; }

        [Hidden()]
        public DateTime PostingDate { get; set; }

        [Hidden()]
        public Int32 EmpId { get; set; }

        [Hidden()]
        public Int32 TemplateStatus { get; set; }

        [Hidden()]
        public Int32 TemplateId { get; set; }

        [Hidden()]
        public Int32 TemplateCOAId { get; set; }

        [Hidden()]
        public Int32 TemplateChequeRegisterId { get; set; }

        [Hidden()]
        public decimal RemainAmount { get; set; }

        [Hidden()]
        public decimal TemplateCOAId2 { get; set; }

        //public String HeadDescription { get; set; }
        //public Int16 IsApproved { get; set; }
        //public Int16 IsAuto { get; set; }
        //public Int16 IsBankReconcile { get; set; }
        //public Int16 IsCash { get; set; }
        //public Int16 IsSubmitted { get; set; }
        //public String MenuName { get; set; }
        //public Int32 Mid { get; set; }
        //public String NoteType { get; set; }

        //public decimal PaymentAmount { get; set; }
        //public String PaymentamountInWords { get; set; }

        //public Int16 PostToLedger { get; set; }
        //public String PostedBy { get; set; }
        //public DateTime PostingDate { get; set; }
        //public String PostingNumber { get; set; }
        //public String PreparedBy { get; set; }
        //public String SubModule { get; set; }

        //    public String VoucherNumber { get; set; }
        //   public Int32 VoucherTag { get; set; }

        public string FileName { get; set; }

        [CssClass("width6"), DisplayName(""), OneWay]
        public decimal ConversionRate { get; set; }

        [CssClass("width6"), DisplayName(""), OneWay]
        public decimal ConversionAmount { get; set; }

        [CssClass("width6"), DisplayName("")]
        public String FileNo { get; set; }

        [CssClass("width6"), DisplayName("")]
        public String PageNo { get; set; }

        [CssClass("width3"), OneWay, ReadOnly(true), Visible(false)]
        public String MultiCurrency { get; set; }

        #endregion

        // -- Comments History
        [VoucherApprovalHistoryEditor]
        public List<ApvApplicationInformationRow> ApplicationInformationHistory { get; set; }


        //[VoucherAuditLogEditor]
        //public List<ApvApplicationInformationRow> VoucherAuditLog { get; set; }

    }
}