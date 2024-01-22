
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccBudgetDetails")]
    [BasedOnRow(typeof(Entities.AccBudgetDetailsRow), CheckNames = true)]
    public class AccBudgetDetailsColumns
    {
        public Int32 BudgetHeadId { get; set; }
        public Boolean IsCoa { get; set; }
        public Boolean IsCostCenter { get; set; }
        public Decimal BudgetAmount { get; set; }
        public String BudgetCode { get; set; }
    }
}