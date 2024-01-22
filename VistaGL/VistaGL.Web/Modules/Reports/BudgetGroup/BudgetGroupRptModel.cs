using System;

namespace VistaGL.Modules.Reports
{
    public class BudgetGroupRptModel
    {
        public int? BudgetHeadId { get; set; }
        public int? ParentId { get; set; }
        public String ParentName { get; set; }
        public String BudgetHeadName { get; set; }
        public Boolean IsBudgetHead { get; set; }
        public Boolean IsCOA { get; set; }
        public Boolean IsCostCenter { get; set; }
        public int? BGSortOrder { get; set; }
        public String BudgetCode { get; set; }
        public Boolean IsHideChildrenFromThisLevel { get; set; }
    }
}