
using VistaGL.Transaction.Entities;

namespace VistaGL.Transaction.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [FormScript("Transaction.VoucherApproval")]
    [BasedOnRow(typeof(Entities.AccVoucherInformationRow))]
    public class VoucherApprovalForm
    {
        [Category("Approval Information")]

        #region Approval Info

        [DefaultValue(ApprovalStatus.Draft), CssClass("width6"), ReadOnly(true)]
        public ApprovalStatus approveStatus { get; set; }

        [GetApproverInfoByApplicantVoucherEditor]
        [CssClass("width6"), DisplayName("Forward for Recommendation")]
        public Int32 ApproverId { get; set; }

        [LookupEditor(typeof(Configurations.Entities.PrmEmploymentInfoRow))]
        [CssClass("width6"), DisplayName("Send for Posting")]
        public Int32 postingSendTo { get; set; }

        [LookupEditor(typeof(Configurations.Entities.PrmEmploymentInfoRow))]
        [CssClass("width6"), DisplayName("Regret Voucher To")]
        public Int32 RegretSendTo { get; set; }

        [Hidden()]
        public String ApprovalAction { get; set; }

        [TextAreaEditor(Rows = 2)]
        public String ApprovalComments { get; set; }

        #endregion Approval Info

        [Category("Voucher Information")]

        #region Voucher Info

        // public Int32 FundControlInformationId { get; set; }

        [CssClass("width6"), Updatable(false)]
        public Int32 VoucherTypeId { get; set; }

        // public Int32 PostingFinancialYearId { get; set; }

        [CssClass("width6"), Updatable(false)]
        public Int32 TransactionTypeEntityId { get; set; }

        [CssClass("width6"), Updatable(false)]
        public DateTime VoucherDate { get; set; }
        [CssClass("width6"), COAMappingEditor, Updatable(false)]

        public String TransactionMode { get; set; }

        [CssClass("width6"), Updatable(false)]
        public String VoucherNo { get; set; }

        [DisplayName("Pay To"), CssClass("width6"), Updatable(false)]
        public String PaytoOrReciveFrom { get; set; }

        [CssClass("width6"), ReadOnly(true)]
        public Int32 ChequeRegisterChequeNo { get; set; }

        [CssClass("width6"), ReadOnly(true)]
        public DateTime ChequeRegisterChequeDate { get; set; }

        [CssClass("width4"), DisplayName("Linked Journal Voucher No"), Visible(false)]
        public String AutoJVVoucherNo { get; set; }

        //  PAYMENT
        [Hidden, Updatable(false)]
        public String TransactionType { get; set; }

        // Debit
        [Hidden, Updatable(false)]
        public String VoucherType { get; set; }

        [Hidden, Updatable(false)]
        public String VoucherNumber { get; set; }

        [AccVoucherDetailsEditor, Updatable(false)]
        public List<Entities.AccVoucherDetailsRow> VoucherDetails { get; set; }

        [DisplayName("Debit Amount"), OneWay, CssClass("width6"), ReadOnly(true)]
        public Double DAmount { get; set; }
        [DisplayName("Credit Amount"), OneWay, CssClass("width6"), ReadOnly(true)]
        public Double CAmount { get; set; }

        //   public Double EffectiveValue { get; set; }
        [Updatable(false)]
        public Double Amount { get; set; }
        [Updatable(false)]
        public String AmountInWords { get; set; }

        // public DateTime ClearDate { get; set; }
        [TextAreaEditor(Rows = 2), Updatable(false)]
        public String Description { get; set; }

        [Hidden()]
        public String PostedBy { get; set; }

        [Hidden()]
        public DateTime PostingDate { get; set; }

        [Hidden()]
        public Int16 PostToLedger { get; set; }

        [Hidden()]
        public Int32? EmpId { get; set; }

        public string FileName { get; set; }

        [VoucherApprovalHistoryEditor]
        public List<ApvApplicationInformationRow> ApplicationInformationHistory { get; set; }

        #endregion Voucher Info
    }
}