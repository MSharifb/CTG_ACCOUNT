
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccGovtLoanReport")]
    [BasedOnRow(typeof(Entities.AccGovtLoanReportRow), CheckNames = true)]
    public class AccGovtLoanReportForm
    {
        [LookupEditor("Configurations.AccChartofAccountsForVoucher_Lookup")]
        public Int32 CoaId { get; set; }
        public Decimal LoanOpening { get; set; }
        public Decimal LoanRefundOpening { get; set; }
        public Boolean IsInterestFree { get; set; }
    }
}