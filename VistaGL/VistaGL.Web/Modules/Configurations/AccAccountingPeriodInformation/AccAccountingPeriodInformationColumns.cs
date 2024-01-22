
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccAccountingPeriodInformation")]
    [BasedOnRow(typeof(Entities.AccAccountingPeriodInformationRow))]
    public class AccAccountingPeriodInformationColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"),Hidden, AlignRight]
        public Int32 Id { get; set; }

        [EditLink, DisplayName("Accounting Period")]
        public String YearName { get; set; }
        [AlignCenter]
        public DateTime PeriodStartDate { get; set; }
        [AlignCenter]
        public DateTime PeriodEndDate { get; set; }
        [AlignCenter]
        public Boolean IsActive { get; set; }
        [AlignCenter]
        public Boolean IsClosed { get; set; }
        //public String FundControlInformationFundControlName { get; set; }
    }
}