
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccReportTypeGroupOpeningBalance")]
    [BasedOnRow(typeof(Entities.AccReportTypeGroupOpeningBalanceRow), CheckNames = true)]
    public class AccReportTypeGroupOpeningBalanceForm
    {
        public Int32 ReportTypeId { get; set; }

        public Int32 GroupId { get; set; }
        [Hidden]
        public Int32 ZoneId { get; set; }
        [Hidden]
        public Int32 FundControlId { get; set; }
        [DecimalEditor(MinValue = "-99999999999.99", MaxValue = "999999999999.99")]
        public Decimal OpeningBalance { get; set; }
    }
}