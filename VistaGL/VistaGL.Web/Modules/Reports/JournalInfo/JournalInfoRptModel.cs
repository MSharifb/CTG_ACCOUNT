using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.LedgerInfo
{
    public class JournalInfoRptModel
    {

        public Int32 id { get; set; }
        public Int32 ledger_coaid { get; set; }
        public String ledger_coaname { get; set; }
        public String ledger_account_Group { get; set; }
        public String subLedgerName { get; set; }
        public String Narration { get; set; }
        public Int32 fundControl_id { get; set; }
        public Int32 voucherTypeId { get; set; }
        public String voucherType { get; set; }
        public String voucher_no { get; set; }
        public Int32 voucher_id { get; set; }
        public DateTime voucher_date { get; set; }
        public Decimal debit_balance_sum { get; set; }
        public Decimal credit_balance_sum { get; set; }
    }
}