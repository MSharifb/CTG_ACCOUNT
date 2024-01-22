
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.BudgetCreationApproval")]
    [BasedOnRow(typeof(Entities.AccBudgetForDepartmentRow), CheckNames = true)]
    public class BudgetCreationApprovalForm
    {
        public String FinancialYearName { get; set; }
        public String DepartmentName { get; set; }
    }
}