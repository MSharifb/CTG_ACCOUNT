
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccArDoubtfulDebts")]
    [BasedOnRow(typeof(Entities.AccArDoubtfulDebtsRow), CheckNames = true)]
    public class AccArDoubtfulDebtsColumns
    {
        [EditLink]
        public String FinancialYearYearName { get; set; }
        public Decimal DoubtfulDebtsAmount { get; set; }
        public Decimal Receivable { get; set; }
        public Decimal Adjusted { get; set; }
    }
}