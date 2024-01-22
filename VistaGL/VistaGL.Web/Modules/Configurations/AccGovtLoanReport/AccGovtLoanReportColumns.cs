
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccGovtLoanReport")]
    [BasedOnRow(typeof(Entities.AccGovtLoanReportRow), CheckNames = true)]
    public class AccGovtLoanReportColumns
    {
        [EditLink]
        public String CoaAccountName { get; set; }
        public Decimal LoanOpening { get; set; }
        public Decimal LoanRefundOpening { get; set; }
        public Boolean IsInterestFree { get; set; }
    }
}