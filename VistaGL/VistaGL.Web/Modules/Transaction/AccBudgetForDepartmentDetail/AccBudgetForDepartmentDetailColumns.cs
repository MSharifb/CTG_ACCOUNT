
namespace VistaGL.Transaction.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Transaction.AccBudgetForDepartmentDetail")]
    [BasedOnRow(typeof(Entities.AccBudgetForDepartmentDetailRow), CheckNames = true)]
    public class AccBudgetForDepartmentDetailColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        public Int32 BudgetForDepartmentId { get; set; }
        public String BudgetGroupGroupName { get; set; }
        public Int32 ParentId { get; set; }
        public Int32 BudgetHeadId { get; set; }
        public Boolean IsCoa { get; set; }
        public Boolean IsBudgetHead { get; set; }
    }
}