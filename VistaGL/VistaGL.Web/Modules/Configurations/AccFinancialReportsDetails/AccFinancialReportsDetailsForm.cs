
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccFinancialReportsDetails")]
    [BasedOnRow(typeof(Entities.AccFinancialReportsDetailsRow), CheckNames = true)]
    public class AccFinancialReportsDetailsForm
    {
        [FinancialReportEditor]
        public String ReportType { get; set; }
        public Int32 ZoneInfoId { get; set; }
        [Hidden]
        public Int32 EntityId { get; set; }
        [LookupEditor("Configurations.AccChartofAccountsForVoucher_Lookup")]
        public Int32 CoaId { get; set; }
        public Int32 SubledgerId { get; set; }
        public Decimal Opening { get; set; }
    }
}