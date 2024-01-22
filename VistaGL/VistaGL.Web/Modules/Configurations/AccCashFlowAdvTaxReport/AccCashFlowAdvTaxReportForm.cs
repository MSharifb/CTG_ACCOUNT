
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccCashFlowAdvTaxReport")]
    [BasedOnRow(typeof(Entities.AccCashFlowAdvTaxReportRow), CheckNames = true)]
    public class AccCashFlowAdvTaxReportForm
    {
        public Int32 FinancialYearId { get; set; }
        public Decimal AdvTaxAmount { get; set; }
        public Decimal Opening { get; set; }
    }
}