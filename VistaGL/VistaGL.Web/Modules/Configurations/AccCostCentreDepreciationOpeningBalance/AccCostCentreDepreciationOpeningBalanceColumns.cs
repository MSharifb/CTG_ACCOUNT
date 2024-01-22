
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccCostCentreDepreciationOpeningBalance")]
    [BasedOnRow(typeof(Entities.AccCostCentreDepreciationOpeningBalanceRow))]
    public class AccCostCentreDepreciationOpeningBalanceColumns
    {
        [EditLink,Width(400)]
        public string CostCenterUserCode { get; set; }

        public string CostCenterName { get; set; }

        [QuickFilter,FilterOnly]
        public Int32 CostCenterId { get; set; }

        [Width(200)]
        public Decimal OpeningBalanceCost { get; set; }

        [Width(200)]
        public Decimal OpeningBalanceDepreciation { get; set; }

    }
}