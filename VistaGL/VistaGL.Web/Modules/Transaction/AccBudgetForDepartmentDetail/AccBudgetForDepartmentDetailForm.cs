
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccBudgetForDepartmentDetail")]
    [BasedOnRow(typeof(Entities.AccBudgetForDepartmentDetailRow), CheckNames = true)]
    public class AccBudgetForDepartmentDetailForm
    {
        public Int32 BudgetForDepartmentId { get; set; }
        public Int32 BudgetGroupId { get; set; }
        public Int32 ParentId { get; set; }
        public Int32 BudgetHeadId { get; set; }
        public Boolean IsCoa { get; set; }
        public Boolean IsBudgetHead { get; set; }
    }
}