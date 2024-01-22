
namespace VistaGL.Transaction.Forms
{
    using _Ext;
    using Serenity.ComponentModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [FormScript("Transaction.AccMoneyReceipt")]
    [BasedOnRow(typeof(Entities.AccMoneyReceiptRow))]
    public class AccMoneyReceiptForm
    {
        [HalfWidth, ReadOnly(true)]
        public String SerialNo { get; set; }

        [DefaultValue("now"), HalfWidth]
        public DateTime MonryReceiptDate { get; set; }

        [AutoCompleteEditor(LookupKey = "Transaction.AccCostCentreOrInstituteInformation_LookupForAutoComplete")]
        public String ReceiveFrom { get; set; }

        [Category("Money Receipt Details")]
        [AccMoneyReceiptDatailsEditor]
        public List<Entities.AccMoneyReceiptDatailsRow> AccMoneyReceiptDatailsList { get; set; }

        [ReadOnly(true),HalfWidth]
        public Decimal Amount { get; set; }
        [HalfWidth]
        public Decimal Dollar { get; set; }
        [ReadOnly(true)]
        public String AmountInWord { get; set; }

        [TextAreaEditor(Rows = 3)]
        public String Narration { get; set; }

        [CssClass("width6")]
        public String ChequeType { get; set; }

        [DefaultValue("now")]
        [CssClass("width6")]
        public DateTime ChequeDate { get; set; }

        [DefaultValue("-")]
        public String ChequeNo { get; set; }

        [LookupEditor("Configurations.AccCoABank_Lookup")]
        public Int32 AccHeadBankId { get; set; }

        [Category("Cancel/Confirm Money Receipt")]

        [CssClass("width6")]
        public Boolean IsCancelled { get; set; }

        [CssClass("width6"),]
        public Boolean IsConfirmed { get; set; }

        [Category("Used Information")]

        [CssClass("width6"), ReadOnly(true)]
        public Boolean IsUsed { get; set; }

        [CssClass("width6"), ReadOnly(true)]
        public String VoucherNo { get; set; }

        [Hidden]
        public string MoneyReceiptNo { get; set; }

    }
}