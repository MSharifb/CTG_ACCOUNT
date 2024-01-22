using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.BudgetRequirementInfo
{
    public class BudgetRequirementInfoRptModel
    {

        public int ZoneInfoId { get; set; }
        public string ZoneInfoName { get; set; }
        public int budegetDeptId { get; set; }
        public string budegetDeptName { get; set; }
        public int itemId { get; set; }
        public string itemName { get; set; }
        public decimal budget_amount_prev { get; set; }
        public decimal actual_amount_prev { get; set; }
        public decimal budget_amount_cur { get; set; }
        public decimal actual_amount_cur { get; set; }


        public string zoneName { get; set; }

        public string budgetHead { get; set; }

    }
}