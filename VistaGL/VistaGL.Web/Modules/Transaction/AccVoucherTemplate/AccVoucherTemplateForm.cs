
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccVoucherTemplate")]
    [BasedOnRow(typeof(Entities.AccVoucherTemplateRow))]
    public class AccVoucherTemplateForm
    {
        public Int32 VoucherTypeId { get; set; }
        public Int32 TransactionTypeId { get; set; }

        [COAMappingEditor]
        public String TransactionMode { get; set; }
        public String TemplateName { get; set; }

        [CssClass("width6")]
        public Int32 CoaDebitHeadId { get; set; }

        [CssClass("width6")]
        public Boolean IsDebitHeadCheque { get; set; }

        [CssClass("width6")]
        public Int32 CoaCreditHeadId { get; set; }

        [CssClass("width6")]
        public Boolean IsCreditHeadCheque { get; set; }

        [CssClass("width6")]
        public Boolean IsBillReference { get; set; }

        [CssClass("width6")]
        public Boolean IsCostCenter { get; set; }

        [Category("Security Deposit Details")]
        [CssClass("width3")]
        public Boolean IsSd { get; set; }
        [CssClass("width3")]
        public Int32 CoaSdId { get; set; }

        [VoucherTemplateDrCrMappingEditor]
        [CssClass("width3")]
        public String SdType { get; set; }
        [CssClass("width3")]
        public Decimal SdRate { get; set; }

        [Category("VAT Details")]
        [CssClass("width3")]
        public Boolean IsVat { get; set; }

        [CssClass("width3")]
        public Int32 CoaVatId { get; set; }

        [CssClass("width3")]
        [VoucherTemplateDrCrMappingEditor]     
        public String VatType { get; set; }

        [CssClass("width3")]
        public Decimal VatRate { get; set; }

        [Category("TAX Details")]
        [CssClass("width3")]
        public Boolean IsTax { get; set; }

        [CssClass("width3")]
        public Int32 CoaTaxId { get; set; }

        [CssClass("width3")]

        [VoucherTemplateDrCrMappingEditor]
        public String TaxType { get; set; }

        [CssClass("width3")]
        public Decimal TaxRate { get; set; }

        [CssClass("width3")]
        [TextAreaEditor(Rows =5)]
        public String Remarks { get; set; }
    }
}