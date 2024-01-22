
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccCashFlowAdvTaxReport")]
    [BasedOnRow(typeof(Entities.AccCashFlowAdvTaxReportRow), CheckNames = true)]
    public class AccCashFlowAdvTaxReportColumns
    {
        [EditLink]
        public String FinancialYearYearName { get; set; }
        public Decimal AdvTaxAmount { get; set; }
        public Decimal Opening { get; set; }
    }
}