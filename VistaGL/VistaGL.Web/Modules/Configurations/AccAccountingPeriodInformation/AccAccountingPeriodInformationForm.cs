
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccAccountingPeriodInformation")]
    [BasedOnRow(typeof(Entities.AccAccountingPeriodInformationRow))]
    public class AccAccountingPeriodInformationForm
    {

        [DisplayName("Accounting Period")]
        public String YearName { get; set; }

        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }

        public Boolean IsActive { get; set; }
        public Boolean IsClosed { get; set; }
        //public Int32 FundControlInformationId { get; set; }
    }
}