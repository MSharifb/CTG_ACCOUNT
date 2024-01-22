using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.LedgerSubLedgerInfo
{

    public class ConsolidatedScheduleRptModel
    {
        public Int32 id { get; set; }
        public Int32 ledger_coaid { get; set; }
        public String ledger_coaname { get; set; }
        public String ledger_account_Group { get; set; }
        public String coa_UserCode { get; set; }
        public String subLedger_Parent_Code { get; set; }
        public String subLedger_Parent { get; set; }
        public Int32 subLedger_id { get; set; }
        public String subLedger_code { get; set; }
        public String subLedger { get; set; }
        public Decimal opening_balance { get; set; }
        public Decimal debit_balance_sum { get; set; }

        public Decimal credit_balance_sum { get; set; }

        private decimal _closingBalance;
        public Decimal closing_balance
        {
            get
            {
                this._closingBalance = (opening_balance + debit_balance_sum) - credit_balance_sum;
                return _closingBalance;
            }
            set
            {
                this._closingBalance = value;
            }
        }
        public String zoneInfoName { get; set; }
        public Int32 zoneSortOrder { get; set; }
    }

    public class LedgerSubLedgerInfoRptModel
    {

        public Int32 id { get; set; }
        public Int32 ledger_coaid { get; set; }
        public String ledger_coaname { get; set; }
        public String ledger_account_Group { get; set; }
        public String Narration { get; set; }
        public Int32 fundControl_id { get; set; }
        public Int32 voucherTypeId { get; set; }
        public String voucherType { get; set; }
        public String voucher_no { get; set; }
        public Int32 voucher_id { get; set; }
        public DateTime voucher_date { get; set; }
        public decimal opening_balance { get; set; }
        public decimal costCenter_OB_Debit { get; set; }
        public decimal costCenter_OB_Credit { get; set; }
        public decimal debit_balance_sum { get; set; }
        public decimal credit_balance_sum { get; set; }
        public decimal closing_balance { get; set; }
        public String payOrReceive { get; set; }
        public String transactionLedgers { get; set; }
        public String costCenter { get; set; }
        public String billRef { get; set; }
        public String ChequeNo { get; set; }
        public String checkNo { get; set; }
        public String subLedger_Parent_Code { get; set; }
        public String subLedger_Parent { get; set; }
        public Int32 subLedger_id { get; set; }
        public String subLedger_code { get; set; }
        public String subLedger { get; set; }
        public String zoneInfoName { get; set; }
        public String zoneSortOrder { get; set; }
    }


    public class LedgerByCoaRptModel
    {
        public String voucherNo { get; set; }
        public DateTime voucherDate { get; set; }
        public String ledger_coaname { get; set; }
        public String subLedger { get; set; }
        public Decimal debitAmount { get; set; }
        public Decimal creditAmount { get; set; }
        public String description { get; set; }
        public String chequeNo { get; set; }
        public DateTime chequeDate { get; set; }
        public String combinedChequeNoChequeDate
        {
            get
            {
                if (String.IsNullOrEmpty(chequeNo))
                {
                    return "";
                }
                else
                {
                    String cd = String.Empty;
                    if (chequeDate == DateTime.MinValue)
                    {
                        cd = "";
                    }
                    else
                    {
                        cd = " DT:" + chequeDate.ToString("dd/MM/yyyy");
                    }
                    return chequeNo + cd;
                }
            }
        }
        public String paytoOrReciveFrom { get; set; }

    }
}