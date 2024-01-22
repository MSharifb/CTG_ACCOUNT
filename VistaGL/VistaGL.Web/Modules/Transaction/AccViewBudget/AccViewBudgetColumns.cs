
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccViewBudget")]
    [BasedOnRow(typeof(Entities.AccViewBudgetRow))]
    public class AccViewBudgetColumns
    {
        //public Int32 Id { get; set; }
        //  [EditLink]
        [Width(350)]
        public String AccountName { get; set; }
        //public Decimal Quantity { get; set; }
        [Width(150), AlignRight]
        public Decimal Amount { get; set; }
        //public Int32 BudgetRevisionNo { get; set; }
        //public Int32 BudgetDepartmentInfoId { get; set; }
        //public Int32 ZoneInfoId { get; set; }
        //public Int32 EntityId { get; set; }
        //public Int32 BudgetYearId { get; set; }
        //public Int32 BudgetStatus { get; set; }
    }
}