using System;

namespace VistaGL.Modules.Reports.ConsolidatedProposedBudget
{
    public class ConsolidatedProposedBudgetRptModel
    {
        public int BudgetHeadId { get; set; }
        public int ParentId { get; set; }
        public String BudgetHeadName { get; set; }
        public String BudgetCode { get; set; }
        public int SortingOrder { get; set; }
        public int ProposedBudgetFYearId { get; set; }
        public String ProposedBudgetFYearName { get; set; }
        public Decimal ProposedBudgetAmount { get; set; }
        public String ZoneCode { get; set; }
        public int ZoneSortOrder { get; set; }
    }
}