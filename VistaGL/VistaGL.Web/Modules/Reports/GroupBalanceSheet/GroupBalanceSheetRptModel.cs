using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports
{
    public class GroupBalanceSheetRptModel
    {


        public String coa_name { get; set; }
        public String parent { get; set; }
  
        public String accountGroup { get; set; }
        public Decimal Balance { get; set; }
        public String temporary_head { get; set; }
        public Decimal incomeExpenseBalance { get; set; }
        public String incomeExpenseGroup { get; set; }
   
    }
}