
namespace VistaGL.Transaction.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Transaction.AccBudgetDetails")]
    [BasedOnRow(typeof(Entities.AccBudgetDetailsRow), CheckNames = true)]
    public class AccBudgetDetailsForm
    {
        [Hidden]
        public Int32 BudgetId { get; set; }
        [Hidden]
        public Int32 BudgetGroupId { get; set; }

        public Int32 BudgetHeadId { get; set; }
        [Hidden]
        public Int32 ParentId { get; set; }
        [HalfWidth, ReadOnly(true)]
        public Boolean IsCoa { get; set; }
        [Hidden]
        public Boolean IsBudgetHead { get; set; }
        [HalfWidth,ReadOnly(true)]
        public Boolean IsCostCenter { get; set; }
        [HalfWidth]
        public Decimal BudgetAmount { get; set; }
        [HalfWidth, ReadOnly(true)]
        public String BudgetCode { get; set; }
        [HalfWidth, ReadOnly(true)]
        public Int32 BgSortOrder { get; set; }
    }
}