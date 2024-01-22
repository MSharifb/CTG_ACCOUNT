
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.TransferVoucher")]
    [BasedOnRow(typeof(Entities.AccVoucherInformationRow))]
    public class TransferVoucherForm
    {
        [Category("Transfer Type")]

        [RadioButtonEditor(EnumKey = "RTransferType"), DefaultValue(0)]
        public String TransferType { get; set; }

        [Category("Voucher Information")]

        [CssClass("width6"), Hidden()]
        public Int32 VoucherTypeId { get; set; }

        [Hidden()]
        public Int32 PostingFinancialYearId { get; set; }

        [CssClass("width6"), Hidden()]
        public Int32 TransactionTypeEntityId { get; set; }

        [CssClass("width6")]
        public String VoucherNo { get; set; }


        [CssClass("width6")]
        public DateTime VoucherDate { get; set; }

        //   [CssClass("width6"), COAMappingEditor]
        [Hidden()]
        public String TransactionMode { get; set; }


        [CssClass("width6")]
        public String FileNo { get; set; }

        [CssClass("width6")]
        public String PageNo { get; set; }


        //[DisplayName("Pay To"), CssClass("width6")]
        //public String PaytoOrReciveFrom { get; set; }

        //  PAYMENT
        [Hidden]
        public String TransactionType { get; set; }
        
        // Debit
        [Hidden]
        public String VoucherType { get; set; }

        [Hidden]
        public String VoucherNumber { get; set; }

        [TextAreaEditor(Rows = 4)]
        public String Description { get; set; }
        // public String TransferType { get; set; }


        [Category("Account Information")]


        [DisplayName("Bank Acc. (From)"), OneWay]

        [LookupEditor("Configurations.AccChartofAccounts_Lookup", FilterField = nameof(Configurations.Entities.AccChartofAccountsRow.CoaMapping), FilterValue = "BANK")]

        public Int32 AccountHeadFrom { get; set; }

        [DisplayName("Bank Acc. (To)"), OneWay]
        [LookupEditor("Configurations.AccChartofAccounts_Lookup", FilterField = nameof(Configurations.Entities.AccChartofAccountsRow.CoaMapping), FilterValue = "BANK")]
        public Int32 AccountHeadTo { get; set; }


        [DisplayName("Transfer Amount"), OneWay, DefaultValue(0)]
        public Double TransferAmount { get; set; }
        [Hidden()]
        public Double Amount { get; set; }

        [DisplayName("Description"), OneWay, TextAreaEditor(Rows = 2)]
        public String DDescription { get; set; }
        [DisplayName(""), OneWay]
        public String AddtoGrid { get; set; }



        [TransferDetailesEditor]
        public List<Entities.AccVoucherDetailsRow> VoucherDetails { get; set; }

        [DisplayName("Debit Amount"), OneWay, CssClass("width6"), ReadOnly(true)]
        public Double DAmount { get; set; }
        [DisplayName("Credit Amount"), OneWay, CssClass("width6"), ReadOnly(true)]
        public Double CAmount { get; set; }

        [ReadOnly(true)]
        public String AmountInWords { get; set; }

        [Hidden()]
        public String PostedBy { get; set; }

        [Hidden()]
        public DateTime PostingDate { get; set; }


    }
}