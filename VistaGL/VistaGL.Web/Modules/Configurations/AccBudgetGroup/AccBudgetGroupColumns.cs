
namespace VistaGL.Configurations.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Configurations.AccBudgetGroup")]
    [BasedOnRow(typeof(Entities.AccBudgetGroupRow))]
    public class AccBudgetGroupColumns
    {
        [EditLink]
        public String GroupName { get; set; }

        [QuickFilter(), FilterOnly()]
        public Int32 ParentId { get; set; }

        public String BudgetCode { get; set; }

        public String ParentGroupName { get; set; }

        [SortOrder(1)]
        public Int32 SortingOrder { get; set; }

        public Boolean IsActive { get; set; }

        public Boolean IsHideChildrenFromThisLevel { get; set; }
    }
}