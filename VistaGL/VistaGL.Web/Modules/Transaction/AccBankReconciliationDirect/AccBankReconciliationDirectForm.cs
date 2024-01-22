
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;
    using _Ext;

    [FormScript("Transaction.AccBankReconciliationDirect")]
    [BasedOnRow(typeof(Entities.AccBankReconciliationDirectRow))]
    public class AccBankReconciliationDirectForm
    {
        [CssClass("width6")]
        public DateTime VoucherDate { get; set; }

        [CssClass("width6")]
        public String VoucherNumber { get; set; }

        [CssClass("width6"), BRTransactionTypeEditorDDL]
        public String TransactionType { get; set; }

        [CssClass("width6")]
        public Int32 BankAccountInformationId { get; set; }

        [CssClass("width6")]
        public decimal Amount { get; set; }

        [AutoCompleteEditor(LookupKey = "Transaction.AccCostCentreOrInstituteInformation_LookupForAutoComplete")]
        [CssClass("width6"), DisplayName("Pay To Or Recive From"), Required]
        public String PaytoOrReciveFrom { get; set; }
        [CssClass("width6")]
        public String ChequeNo { get; set; }

        [CssClass("width6")]
        public DateTime ChequeDate { get; set; }

        [CssClass("width6")]
        public DateTime ClearDate { get; set; }

        [CssClass("width6")]
        public String Description { get; set; }

        //[CssClass("width6")]
        //public Boolean IsCash { get; set; }

        [CssClass("width6"),Hidden]
        public Int32 FundControlInformationId { get; set; }


    }
}