
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccAdvanceDepositeReport")]
    [BasedOnRow(typeof(Entities.AccAdvanceDepositeReportRow), CheckNames = true)]
    public class AccAdvanceDepositeReportColumns
    {
        [EditLink]
        public String FinancialYearName { get; set; }
        public String SubledgerName { get; set; }
        public Decimal OpeningBalance { get; set; }
        public Decimal During { get; set; }
    }
}