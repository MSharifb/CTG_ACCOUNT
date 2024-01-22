
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;
    using Entities;

    [FormScript("Transaction.AccVoucherTemplateVoucherIssue")]
    [BasedOnRow(typeof(Entities.AccVoucherTemplateRow))]
    public class AccVoucherTemplateVoucherIssueForm
    {
       // public Int32 Id { get; set; }

        [Category("Voucher Template Information")]
      
        public Int32 VoucherTypeId { get; set; }
       
        public Int32 TransactionTypeId { get; set; }

        [COAMappingEditor]
        public String TransactionMode { get; set; }

        [TemplateNameEditor]      
        public String TemplateName { get; set; }

       

        [Category("Voucher Information")]       

        [CssClass("width6")]
        public Int32 CoaDebitHeadId { get; set; }

        [CssClass("width6")]
        public Boolean IsDebitHeadCheque { get; set; }

        [CssClass("width6")]
        [DisplayName("Cheque No.(Dr.")]
        [LookupEditor("Transaction.AccChequeRegister_Lookup")]
        public Int32 DebitHeadChequeId { get; set; }

        [CssClass("width6")]
        public Int32 CoaCreditHeadId { get; set; }

        [CssClass("width6")]
        public Boolean IsCreditHeadCheque { get; set; }

        [CssClass("width6")]      
        [DisplayName("Cheque No.(Cr.)")]
        [LookupEditor("Transaction.AccChequeRegister_Lookup")]
        public Int32 CreditHeadChequeId { get; set; }

        [CssClass("width3")]
        public Boolean IsBillReference { get; set; }

        [DisplayName("Bill Reference No.")]
        [CssClass("width3")]
        public String BillReferenceNo { get; set; }

        [CssClass("width3")]
        public Boolean IsCostCenter { get; set; }

        [CssClass("width3")]
        [DisplayName("Sub Ledger")]
        [LookupEditor("Transaction.AccCostCentreOrInstituteInformation_Lookup", FilterField = nameof(AccCostCentreOrInstituteInformationRow.IsInstitute), FilterValue = false)]
        public Int32 CostCenterId { get; set; }

        [Required]
        [CssClass("width3")]
        public Decimal Amount { get; set; }

        [CssClass("width3")]
        [DisplayName("Voucher Date"),Required]
        public DateTime VoucherDate { get; set; }

        [TextAreaEditor(Rows = 5)]
        public String Remarks { get; set; }

        [Category("Security Deposit Details"), CssClass("SDInfo")]
        public Boolean IsSd { get; set; }

        [CssClass("width3")]
        public Int32 CoaSdId { get; set; }

        [VoucherTemplateDrCrMappingEditor]
        [CssClass("width3")]
        public String SdType { get; set; }

        [Width(100)]
        [CssClass("width3")]
        public Decimal SdRate { get; set; }

        [OneWay,ReadOnly(true),DisplayName("Amount")]
        [CssClass("width3")]
        public Decimal SdAmount { get; set; }

        [Category("VAT Details")]
        public Boolean IsVat { get; set; }

        [CssClass("width3")]
        public Int32 CoaVatId { get; set; }

        [VoucherTemplateDrCrMappingEditor]
        [CssClass("width3")]
        public String VatType { get; set; }

        [CssClass("width3")]
        public Decimal VatRate { get; set; }

        [OneWay, ReadOnly(true), DisplayName("Amount")]
        [CssClass("width3")]
        public Decimal VatAmount { get; set; }

        [Category("TAX Details")]
        public Boolean IsTax { get; set; }

        [CssClass("width3")]
        public Int32 CoaTaxId { get; set; }

        [VoucherTemplateDrCrMappingEditor]
        [CssClass("width3")]
        public String TaxType { get; set; }

        [CssClass("width3")]
        public Decimal TaxRate { get; set; }

        [OneWay, ReadOnly(true), DisplayName("Amount")]
        [CssClass("width3")]
        public Decimal TaxAmount { get; set; }
       
    }
}