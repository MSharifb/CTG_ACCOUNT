
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccReportTypeGroupOpeningBalance")]
    [BasedOnRow(typeof(Entities.AccReportTypeGroupOpeningBalanceRow), CheckNames = true)]
    public class AccReportTypeGroupOpeningBalanceColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        public String GroupGroupName { get; set; }
        public String ZoneZoneName { get; set; }
        public Decimal OpeningBalance { get; set; }
    }
}