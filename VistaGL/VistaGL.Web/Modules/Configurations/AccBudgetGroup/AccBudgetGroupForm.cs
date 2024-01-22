
namespace VistaGL.Configurations.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Configurations.AccBudgetGroup")]
    [BasedOnRow(typeof(Entities.AccBudgetGroupRow))]
    public class AccBudgetGroupForm
    {
        [Category("Budget Group Settings")]

        public Int32 ParentId { get; set; }
        public String BudgetCode { get; set; }
        public String GroupName { get; set; }
        public Int32 SortingOrder { get; set; }
        public Boolean IsHideChildrenFromThisLevel { get; set; }
        [DefaultValue(true)]
        public Boolean IsActive { get; set; }
        [VoucherTemplateDrCrMappingEditor, Required]
        public string Type { get; set; }
    }
}