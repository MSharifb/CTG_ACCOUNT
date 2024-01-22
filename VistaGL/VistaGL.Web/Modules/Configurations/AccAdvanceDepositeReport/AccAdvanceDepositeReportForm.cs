
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccAdvanceDepositeReport")]
    [BasedOnRow(typeof(Entities.AccAdvanceDepositeReportRow), CheckNames = true)]
    public class AccAdvanceDepositeReportForm
    {
        public Int32 FinancialId { get; set; }
        public Int32 SubledgerId { get; set; }
        public Decimal OpeningBalance { get; set; }
        public Decimal During { get; set; }
    }
}