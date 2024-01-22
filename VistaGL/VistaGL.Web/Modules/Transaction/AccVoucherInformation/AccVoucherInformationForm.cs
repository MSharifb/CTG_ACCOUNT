// ***************************
// MODEL: FOR PAYMENT VOUCHER
// ***************************

using VistaGL.Transaction.Entities;

namespace VistaGL.Transaction.Forms
{
    using _Ext;
    using Serenity.ComponentModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [FormScript("Transaction.AccVoucherInformation")]
    [BasedOnRow(typeof(Entities.AccVoucherInformationRow))]
    public class AccVoucherInformationForm
    {
        [Category("Approval Information")]
        #region Approval Info
        [GetRecommenderInfoByApplicantVoucherEditor, CssClass("width6")]
        public Int32 ApproverId { get; set; }

        [DefaultValue(ApprovalStatus.Draft), CssClass("width6"), ReadOnly(true)]
        public ApprovalStatus approveStatus { get; set; }
        #endregion Approval Info

        [Category("Voucher Information")]
        #region Voucher Info

        [Visible(false)]
        public Int64? Id { get; set; }

        // public Int32 FundControlInformationId { get; set; }
        [CssClass("width6"), ReadOnly(true)]
        public Int32 VoucherTypeId { get; set; }

        [Hidden()]
        public Int32 PostingFinancialYearId { get; set; }

        [CssClass("width6")]
        public Int32 TransactionTypeEntityId { get; set; }

        [CssClass("width6"), COAMappingEditor]
        public String TransactionMode { get; set; }


        [CssClass("width6")]
        public DateTime VoucherDate { get; set; }

        [CssClass("width6")]
        public String VoucherNo { get; set; }

        [AutoCompleteEditor(LookupKey = "Transaction.AccCostCentreOrInstituteInformation_LookupForAutoComplete")]
        [CssClass("width6"), DisplayName("Pay To")]
        public String PaytoOrReciveFrom { get; set; }

        [CssClass("width6")]
        public Int32? NOAId { get; set; }

        [OneWay, Visible(false)]
        public Int32? NOAId2 { get; set; }

        [CssClass("width6"), OneWay]
        public Int32 ChequeRegisterId { get; set; }

        [Visible(false)]
        public Boolean LinkedWithAutoJV { get; set; }

        [Visible(false), CssClass("width4"), DisplayName("Linked Payment Voucher No"), OneWay]
        public String LinkedPaymentVoucherNo { get; set; }

        //  PAYMENT
        [Hidden]
        public String TransactionType { get; set; }

        // Debit
        [Hidden]
        public String VoucherType { get; set; }

        [Hidden]
        public String VoucherNumber { get; set; }

        // public String TransferType { get; set; }
        #endregion Voucher Info

        [Category("Account Information")]
        #region Account Info

        [CssClass("width9"), DisplayName("Account Head"), OneWay]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup")]
        public Int32 AccountHead { get; set; }

        [CssClass("width6")]
        // [LookupEditor(typeof(Configurations.Entities.AccCostCenterTypeRow))]
        public Int16 CostCenterTypeId { get; set; }

        [CssClass("width6")]
        public Int32 ParentId { get; set; }

        [CssClass("width12")]
        public Int32 CostCentreId { get; set; }

        [CssClass("width3"), DisplayName("Multiple Sub Ledger"), OneWay, Visible(false)]
        public bool MultipleCostCenter { get; set; }

        [Visible(false), CssClass("width3"), OneWay, ReadOnly(true)]
        public String MultiCurrency { get; set; }

        //[CssClass("width6")]
        //public Int32 BankAccountInformationId { get; set; }

        [CssClass("width3"), DisplayName("Debit"), OneWay, DefaultValue(0)]
        public decimal DebitAmount { get; set; }

        [CssClass("width3"), DisplayName("Credit"), OneWay, DefaultValue(0)]
        public decimal CreditAmount { get; set; }

        [CssClass("width6"), DisplayName("Description"), OneWay]
        public String DDescription { get; set; }

        [LookupEditor("Transaction.AccChequeRegisterForAdjust_Lookup"), HalfWidth, DisplayName("Adjust With"), OneWay]
        public Int64 AdjustedChequeRegisterId { get; set; }

        [DisplayName(""), OneWay]
        public String AddtoGrid { get; set; }

        [AccVoucherDetailsEditor]
        public List<Entities.AccVoucherDetailsRow> VoucherDetails { get; set; }

        [CssClass("width6"), DisplayName("Debit Amount"), OneWay,ReadOnly(true)]
        public decimal DAmount { get; set; }

        [CssClass("width6"), DisplayName("Credit Amount"), OneWay, ReadOnly(true)]
        public decimal CAmount { get; set; }

        //   public Double EffectiveValue { get; set; }

        [ReadOnly(true)]
        public String AmountInWords { get; set; }

        [CssClass("width6"), ReadOnly(true)]
        public decimal Amount { get; set; }

        [CssClass("width6"), Visible(false)]
        public Int32 ProjectID { get; set; }

        // public DateTime ClearDate { get; set; }

        [TextAreaEditor(Rows = 2)]
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

        //public Double PaymentAmount { get; set; }
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

        [DisplayName(""), OneWay, CssClass("width6")]
        public decimal ConversionRate { get; set; }

        [DisplayName(""), OneWay, CssClass("width6")]
        public decimal ConversionAmount { get; set; }

        [DisplayName(""), CssClass("width6")]
        public String FileNo { get; set; }

        [DisplayName(""), CssClass("width6")]
        public String PageNo { get; set; }
        #endregion Account Info

        // -- Comments History
        [VoucherApprovalHistoryEditor]
        public List<ApvApplicationInformationRow> ApplicationInformationHistory { get; set; }
    }
}