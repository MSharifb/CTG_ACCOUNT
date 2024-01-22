
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccVoucherConfiguration")]
    [BasedOnRow(typeof(Entities.AccVoucherConfigurationRow))]
    public class AccVoucherConfigurationForm
    {

        [CssClass("width6")]
        public Int32 VoucherTypeId { get; set; }

        [CssClass("width6"), DefaultValue(true)]
        public Boolean AutoNumbering { get; set; }

        [CssClass("width6")]
        public Int32 TransactionTypeId { get; set; }

        [CssClass("width6"), DefaultValue(true)]
        public Boolean PreparedByInfo { get; set; }

        [CssClass("width6")]
        public Int32 AccountingPeriodId { get; set; }

        [CssClass("width6")]
        public Boolean IsUserFinancialAtTheEnd { get; set; }

        [CssClass("width6")]
        public Int32 StartingNumber { get; set; }

        [CssClass("width6")]
        public Boolean NewNumber { get; set; }

        [CssClass("width6")]
        public Int32 NumberLength { get; set; }

        [CssClass("width6")]
        public Boolean CommonDescription { get; set; }

        [CssClass("width6")]
        public String Prefix { get; set; }

        [CssClass("width6")]
        public Boolean EachAccounting { get; set; }

        [CssClass("width6")]
        public String Suffix { get; set; }

        [CssClass("width6")]
        public Boolean IsAutoPost { get; set; }

        [CssClass("width6")]
        public String Separators { get; set; }

        [CssClass("width6")]
        public Boolean IsUserFinancialAtStart { get; set; }

        [CssClass("width6")]
        public Boolean IsMonth { get; set; }

        [CssClass("width6")]
        public Boolean IsDate { get; set; }

        [CssClass("width6")]
        public DateTime Date { get; set; }

        [CssClass("width6")]
        public Boolean NewNumberforEveryBankAccount { get; set; }

        [CssClass("width6"), Hidden]
        public Boolean IsActive { get; set; }

        [CssClass("width6")]
        public Boolean AddZoneShortCode { get; set; }

        [CssClass("width6")]
        public Boolean AddBankACShortCode { get; set; }

        //public Int32 MaxSerialNumber { get; set; }
        //public String MaxMonthSerialNumber { get; set; }
        //public Int32 PostingNumber { get; set; }

    }
}