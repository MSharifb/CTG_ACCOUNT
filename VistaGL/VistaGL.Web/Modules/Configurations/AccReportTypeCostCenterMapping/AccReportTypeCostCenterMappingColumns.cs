
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccReportTypeCostCenterMapping")]
    [BasedOnRow(typeof(Entities.AccReportTypeCostCenterMappingRow), CheckNames = true)]
    public class AccReportTypeCostCenterMappingColumns
    {
        [EditLink]
        public String CostCenterName { get; set; }
        [QuickFilter]
        public String GroupGroupName { get; set; }
        [QuickFilter, FilterOnly]
        public Int32 ReportTypeId { get; set; }
        public Decimal? OpeningBalance { get; set; }
    }
}