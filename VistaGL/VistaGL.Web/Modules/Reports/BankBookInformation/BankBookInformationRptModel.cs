using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.BankBookInformation
{
    public class BankBookInformationRptModel
    {
        public Int32 id { get; set; }
        public Int32 ZoneInfoId { get; set; }
        public String ZoneInfoName { get; set; }
        public Int32 ledger_coaid { get; set; }
        public String ledger_coaname { get; set; }
        public String ledger_account_Group { get; set; }
        public Int32 fundControl_id { get; set; }
        public String voucherType { get; set; }
        public String voucher_no { get; set; }
        public Int32 voucher_id { get; set; }
        public DateTime voucher_date { get; set; }
        public decimal opening_balance { get; set; }
        public decimal debit_balance_sum { get; set; }
        public decimal credit_balance_sum { get; set; }
        public decimal closing_balance { get; set; }
        public String payOrReceive { get; set; }
        public String Narration { get; set; }
        public String transactionLedgers { get; set; }
        public string checkNo { get; set; }
        public decimal debit_balance_Sub { get; set; }
        public decimal credit_balance_Sub { get; set; }

    }
}