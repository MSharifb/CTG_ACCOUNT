
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccArDoubtfulDebts")]
    [BasedOnRow(typeof(Entities.AccArDoubtfulDebtsRow), CheckNames = true)]
    public class AccArDoubtfulDebtsForm
    {
        public Int32 FinancialYearId { get; set; }
        public Decimal DoubtfulDebtsAmount { get; set; }
        public Decimal Receivable { get; set; }
        public Decimal Adjusted { get; set; }
    }
}