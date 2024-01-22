
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccBudgetForDepartment")]
    [BasedOnRow(typeof(Entities.AccBudgetForDepartmentRow), CheckNames = true)]
    public class AccBudgetForDepartmentForm
    {
        [ReadOnly(true)]
        public Int32 BudgetCircularId { get; set; }

        [Hidden]
        public Int32 ZoneId { get; set; }

        [Hidden]
        public Int32 BudgetCircularFinancialYearId { get; set; }

        [DisplayName("Department")]
        public Int32 DepartmentId { get; set; }

        [Category("Budget Heads")]
        [DisplayName("Search"), AccBudgetForDepartmentDetailEditor]
        public List<Entities.AccBudgetForDepartmentDetailRow> AccBudgetForDepartmentDetailList { get; set; }

    }
}