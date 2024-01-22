
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccBudget")]
    [BasedOnRow(typeof(Entities.AccBudgetRow), CheckNames = true)]
    public class AccBudgetColumns
    {
        [EditLink]
        public String FinancialYearYearName { get; set; }
        public String ZoneInfoZoneName { get; set; }
        public Boolean IsApproved { get; set; }
    }
}