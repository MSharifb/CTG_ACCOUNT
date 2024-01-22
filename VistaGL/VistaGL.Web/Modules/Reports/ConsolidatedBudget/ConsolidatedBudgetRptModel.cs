using System;

namespace VistaGL.Modules.Reports
{
    public class ConsolidatedBudgetRptModel
    {
        public Int32 id { get; set; }
        public Int32 BudgetForDepartmentId { get; set; }
        public Int32 BudgetYearId { get; set; }
        public String BudgetYearName { get; set; }
        public Int32 BudgetGroupId { get; set; }
        public Int32 BudgetHeadId { get; set; }
        public Int32 ParentId { get; set; }
        public bool IsBudgetHead { get; set; }
        public bool IsCoa { get; set; }
        public bool IsCostCenter { get; set; }

        public String BudgetHeadName { get; set; }
        public String BudgetCode { get; set; }
        public Int32 SortingOrder { get; set; }

        public Int32 ProposedBudgetFYearId { get; set; }
        public String ProposedBudgetFYearName { get; set; }
        public Decimal ProposedBudgetAmount { get; set; }

        public Decimal RevisedEstimateAmount { get; set; }
        public Decimal ActualFirstSixMonths { get; set; }
        public Decimal BudgetApproved { get; set; }

        public Decimal ActualDuring { get; set; }
        public String ActualDuringYear { get; set; }

        public bool CircularIsActive { get; set; }
    }
}