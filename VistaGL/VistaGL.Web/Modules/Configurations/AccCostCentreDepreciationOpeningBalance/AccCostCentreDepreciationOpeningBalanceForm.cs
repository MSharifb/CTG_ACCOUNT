
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccCostCentreDepreciationOpeningBalance")]
    [BasedOnRow(typeof(Entities.AccCostCentreDepreciationOpeningBalanceRow))]
    public class AccCostCentreDepreciationOpeningBalanceForm
    {
        public Int32 CostCenterId { get; set; }
        public Decimal OpeningBalanceCost { get; set; }
        public Decimal OpeningBalanceDepreciation { get; set; }
        //public Int32 ZoneInfoId { get; set; }
        //public Int32 FundControlId { get; set; }
    }
}