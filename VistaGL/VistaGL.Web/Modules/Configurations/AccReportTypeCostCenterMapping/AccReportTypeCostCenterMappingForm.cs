
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccReportTypeCostCenterMapping")]
    [BasedOnRow(typeof(Entities.AccReportTypeCostCenterMappingRow), CheckNames = true)]
    public class AccReportTypeCostCenterMappingForm
    {
        public Int32 ReportTypeId { get; set; }
        public Int32 GroupId { get; set; }
        public Int32 CostCenterId { get; set; }
        [DecimalEditor(MinValue = "-999999999.99", MaxValue = "9999999999.99")]
        public Decimal OpeningBalance { get; set; }
    }
}