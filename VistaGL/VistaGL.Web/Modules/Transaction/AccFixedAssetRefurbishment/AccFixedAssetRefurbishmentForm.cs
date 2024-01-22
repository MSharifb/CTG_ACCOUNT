
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccFixedAssetRefurbishment")]
    [BasedOnRow(typeof(Entities.AccFixedAssetRefurbishmentRow), CheckNames = true)]
    public class AccFixedAssetRefurbishmentForm
    {
        [HalfWidth(UntilNext =true)]
        [LookupEditor("Configurations.AccChartofAccountsForVoucher_Lookup")]
        public Int32 CoaId { get; set; }
        public Int32 FinancialYearId { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99"), DefaultValue(0),Required]
        public Decimal CostOpening { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99"), DefaultValue(0), Required]
        public Decimal CostAddition { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99"), DefaultValue(0), Required]
        public Decimal CostAdjustment { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99"), DefaultValue(0), Required]
        public Decimal CostClosing { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99"), DefaultValue(0), Required]
        public Decimal DepOpening { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99"), DefaultValue(0), Required]
        public Decimal DepCharge { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99"), DefaultValue(0), Required]
        public Decimal DepAdjustment { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99"), DefaultValue(0), Required]
        public Decimal DepClosing { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99"), DefaultValue(0), Required]
        public Decimal BookValue { get; set; }
    }
}