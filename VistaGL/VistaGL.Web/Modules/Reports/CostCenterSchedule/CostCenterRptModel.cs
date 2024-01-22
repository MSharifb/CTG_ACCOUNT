using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.CostCenterSchedule
{
    public class CostCenterRptModel
    {
        public string accountName { get; set; }
        public string CostCenter { get; set; }
        public decimal CostCenterOBalance { get; set; }
        public decimal debitAmount { get; set; }
        public decimal creditAmount { get; set; }
        public decimal closing_balance { get; set; }
    }
}