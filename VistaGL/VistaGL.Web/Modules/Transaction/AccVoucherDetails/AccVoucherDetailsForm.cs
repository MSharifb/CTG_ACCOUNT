
namespace VistaGL.Transaction.Forms
{
    using Entities;
    using Serenity.ComponentModel;
    using System;
    using System.Collections.Generic;

    [FormScript("Transaction.AccVoucherDetails")]
    [BasedOnRow(typeof(Entities.AccVoucherDetailsRow))]
    public class AccVoucherDetailsForm
    {
        public Int32 ChartofAccountsId { get; set; }

        [CssClass("width6")]
        [DecimalEditor(MinValue = "-999999999999.99", MaxValue = "999999999999.99")]
        public Decimal DebitAmount { get; set; }

        [CssClass("width6")]
        [DecimalEditor(MinValue = "-999999999999.99", MaxValue = "999999999999.99")]
        public Decimal CreditAmount { get; set; }

        #region Calculation Amount

        [Hidden]
        public Decimal CalculationAmount { get; set; }

        #endregion Calculation Amount

        #region Calculation Rate

        [Hidden]
        public Decimal CalculationRate { get; set; }

        #endregion Calculation Rate

        public Int32 ChequeRegisterId { get; set; }

        [Hidden]
        [DecimalEditor(MinValue = "-999999999999.99", MaxValue = "999999999999.99")]
        public decimal EffectiveValue { get; set; }

        [Hidden]
        public decimal CCreditAmount { get; set; }

        [Hidden]
        public decimal CDebitAmount { get; set; }

        [TextAreaEditor(Rows = 2)]
        public String Description { get; set; }

        [LookupEditor("Transaction.AccChequeRegisterForAdjust_Lookup")]
        public Int64 AdjustedChequeRegisterId { get; set; }

        [AccVoucherDtlAllocationEditor]
        public List<AccVoucherDtlAllocationRow> VoucherDtlAllocation { get; set; }

        [AccVoucherDtlBillRefEditor]
        public List<AccVoucherDtlBillRefRow> VoucherDtlBillRef { get; set; }

        //[CssClass("width6")]
        //public Boolean PaymentVoucherHead { get; set; }

        [CssClass("width6"), Visible(false)]
        public decimal ConversionRate { get; set; }

        [CssClass("width6"), Visible(false)]
        public decimal ConversionAmount { get; set; }
    }
}