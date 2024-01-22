
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccFixedAssetRefurbishment")]
    [BasedOnRow(typeof(Entities.AccFixedAssetRefurbishmentRow), CheckNames = true)]
    public class AccFixedAssetRefurbishmentColumns
    {
        [EditLink]
        public String CoaAccountName { get; set; }
        public String FinancialYearYearName { get; set; }
        public Decimal CostOpening { get; set; }
        public Decimal CostAddition { get; set; }
        public Decimal CostAdjustment { get; set; }
        public Decimal CostClosing { get; set; }
        public Decimal DepOpening { get; set; }
        public Decimal DepCharge { get; set; }
        public Decimal DepAdjustment { get; set; }
        public Decimal DepClosing { get; set; }
        public Decimal BookValue { get; set; }
    }
}