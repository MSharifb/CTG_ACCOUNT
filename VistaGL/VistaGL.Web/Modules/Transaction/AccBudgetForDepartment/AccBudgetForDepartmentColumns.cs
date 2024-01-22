
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccBudgetForDepartment")]
    [BasedOnRow(typeof(Entities.AccBudgetForDepartmentRow), CheckNames = true)]
    public class AccBudgetForDepartmentColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight, Hidden]
        public Int32 Id { get; set; }

        [QuickFilter, FilterOnly, DisplayName("Budget Year")]
        public Int32 BudgetCircularFinancialYearId { get; set; }

        [EditLink, AlignCenter]
        public String FinancialYearName { get; set; }

        [QuickFilter, FilterOnly]
        public Int32 DepartmentId { get; set; }

        public String DepartmentName { get; set; }
    }
}