
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccVoucherTemplate")]
    [BasedOnRow(typeof(Entities.AccVoucherTemplateRow))]
    public class AccVoucherTemplateColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), Hidden, AlignRight]
        public Int32 Id { get; set; }
        [EditLink]
        public String TemplateName { get; set; }
        public String VoucherTypeName { get; set; }
        public String TransactionType { get; set; }
        public String CoaDebitHeadAccountName { get; set; }
        public String CoaCreditHeadAccountName { get; set; }
        //public Boolean IsBillReference { get; set; }
        //public Boolean IsCostCenter { get; set; }
        //public Boolean IsSd { get; set; }
        //public Int32 CoaSdId { get; set; }
        //public String SdType { get; set; }
        //public Decimal SdRate { get; set; }
        //public Boolean IsVat { get; set; }
        //public Int32 CoaVatId { get; set; }
        //public String VatType { get; set; }
        //public Decimal VatRate { get; set; }
        //public Boolean IsTax { get; set; }
        //public Int32 CoaTaxId { get; set; }
        //public String TaxType { get; set; }
        //public Decimal TaxRate { get; set; }
        //public String Remarks { get; set; }
    }
}