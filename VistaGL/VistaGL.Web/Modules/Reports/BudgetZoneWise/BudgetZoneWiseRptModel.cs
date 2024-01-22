using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.BudgetZoneWise
{
    public class BudgetZoneWiseRptModel
    {
        public string BudgetHeadName { get; set; }
        public decimal BudgetAmount { get; set; }
        public int BGSortOrder { get; set; }
        public int ParentId { get; set; }
        public int BudgetHeadId { get; set; }
        public int IsBudgetHead { get; set; }
        public string BudgetCode { get; set; }
        public int IsHideChildrenFromThisLevel { get; set; }
        public string ZoneCode { get; set; }
    }
}