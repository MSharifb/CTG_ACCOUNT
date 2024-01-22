
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccFixedAssetsManualInput")]
    [BasedOnRow(typeof(Entities.AccFixedAssetsManualInputRow), CheckNames = true)]
    public class AccFixedAssetsManualInputForm
    {
        public Int32 CostCenterId { get; set; }
        public Int32 FinancialYearId { get; set; }
        [Hidden]
        public Int32 ZoneInfoId { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99")]
        public Decimal AdditionAmount { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99")]
        public Decimal AdjustmentAmount { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99")]
        public Decimal DepCharge { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99")]
        public Decimal DepAdjustment { get; set; }

        [Hidden]
        public Int32 FundControlId { get; set; }
    }
}