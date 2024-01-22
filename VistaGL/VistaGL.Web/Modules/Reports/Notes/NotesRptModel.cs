using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.LedgerInfo
{
    public class NotesRptModel
    {

        public String coa_id { get; set; }
        public String parent_name { get; set; }
        public String coa_name { get; set; }
        public String account_code { get; set; }   
        public String accountGroup { get; set; }
        public Decimal totalDebit { get; set; }
        public Decimal totalCredit { get; set; }
        public Decimal debitBalance { get; set; }
        public Decimal creditBalance { get; set; }
       
    }
}