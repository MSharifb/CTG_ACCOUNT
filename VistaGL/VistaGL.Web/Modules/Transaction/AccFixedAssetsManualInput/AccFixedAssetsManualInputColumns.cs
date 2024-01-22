
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccFixedAssetsManualInput")]
    [BasedOnRow(typeof(Entities.AccFixedAssetsManualInputRow), CheckNames = true)]
    public class AccFixedAssetsManualInputColumns
    {
        [EditLink]
        public String CostCenterName { get; set; }
        public String FinancialYearYearName { get; set; }
        public Decimal AdditionAmount { get; set; }
        public Decimal AdjustmentAmount { get; set; }
    }
}