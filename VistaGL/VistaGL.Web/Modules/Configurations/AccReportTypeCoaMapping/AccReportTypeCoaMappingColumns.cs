
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccReportTypeCoaMapping")]
    [BasedOnRow(typeof(Entities.AccReportTypeCoaMappingRow), CheckNames = true)]
    public class AccReportTypeCoaMappingColumns
    {
        [EditLink]
        public String CoaAccountName { get; set; }
        public String CoaAccountGroup { get; set; }
        [QuickFilter]
        public String GroupGroupName { get; set; }
        [QuickFilter,FilterOnly]
        public Int32 ReportTypeId { get; set; }
        public Decimal OpeningBalance { get; set; }
    }
}