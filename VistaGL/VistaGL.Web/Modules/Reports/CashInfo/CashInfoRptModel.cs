using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.CashInfo
{
    public class CashInfoRptModel
    {
        public int id { get; set; }
        public int ledger_coaid { get; set; }
        public string ledger_coaname { get; set; }
        public string ledger_account_Group { get; set; }
        public string Narration { get; set; }
        public int fundControl_id { get; set; }
        public int voucherTypeId { get; set; }
        public string voucherType { get; set; }
        public string voucher_no { get; set; }
        public int voucher_id { get; set; }
        public DateTime voucher_date { get; set; }
        public decimal opening_balance { get; set; }
        public decimal debit_balance_sum { get; set; }
        public decimal credit_balance_sum { get; set; }
        public decimal closing_balance { get; set; }   
        public string transactionLedgers { get; set; }      
    }
}