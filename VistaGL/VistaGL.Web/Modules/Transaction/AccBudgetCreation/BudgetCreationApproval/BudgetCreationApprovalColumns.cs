
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.BudgetCreationApproval")]
    [BasedOnRow(typeof(Entities.AccBudgetForDepartmentRow), CheckNames = true)]
    public class BudgetCreationApprovalColumns
    {
        public String ZoneName { get; set; }
        public Int32 BudgetCircularFinancialYearId { get; set; }
        public String DepartmentName { get; set; }
        public ApprovalStatus? ApprovalStatusId { get; set; }
    }
}