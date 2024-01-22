
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccFinancialReportsDetails")]
    [BasedOnRow(typeof(Entities.AccFinancialReportsDetailsRow), CheckNames = true)]
    public class AccFinancialReportsDetailsColumns
    {
        [FinancialReportEditor,EditLink, QuickFilter]
        public String ReportType { get; set; }
        [QuickFilter]
        public String ZoneInfoZoneName { get; set; }
        [QuickFilter]
        public String CoaAccountName { get; set; }
        public String CoaAccountGroup { get; set; }
        [QuickFilter]
        public String SubledgerName { get; set; }
        public Decimal Opening { get; set; }
    }
}