using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports
{
    public class IncomeExpenditureRptModel
    {

        public String MainGroup { get; set; }
        public String accountGroup { get; set; }
        public int fundControl_id { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Amount2 { get; set; }
        public int tmpSerial { get; set; }
        public string ParentGroup { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public decimal PreBalance { get; set; }
        public string OrderGroup { get; set; }
        public decimal PriorYearAdjustMent { get; set; }
        public decimal PrePriorYearAdjustMent { get; set; }

    }
}