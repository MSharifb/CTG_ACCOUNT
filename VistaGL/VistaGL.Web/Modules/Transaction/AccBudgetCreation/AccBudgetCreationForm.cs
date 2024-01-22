
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccBudgetCreation")]
    [BasedOnRow(typeof(Entities.AccBudgetForDepartmentDetailRow), CheckNames = true)]
    public class AccBudgetCreationForm
    {
        [Hidden]
        public Int32 BudgetForDepartmentId { get; set; }
        [Hidden]
        public Int32 BudgetGroupId { get; set; }
        [Hidden]
        public Int32 ParentId { get; set; }
        [Hidden]
        public Int32 BudgetHeadId { get; set; }
        [Hidden]
        public Boolean IsCoa { get; set; }
        [Hidden]
        public Boolean IsBudgetHead { get; set; }

        public String BudgetHeadName { get; set; }
        public Decimal ProposedBudgetAmount { get; set; }
        public Decimal RevisedEstimateAmount { get; set; }

    }
}