
namespace VistaGL.Transaction.Columns
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [ColumnsScript("Transaction.AccBudgetCircular")]
    [BasedOnRow(typeof(Entities.AccBudgetCircularRow), CheckNames = true)]
    public class AccBudgetCircularColumns
    {
        [EditLink, DisplayName("Financial Year")]
        public String FinancialYearYearName { get; set; }

        [Width(100)]
        public Boolean IsActive { get; set; }
    }
}