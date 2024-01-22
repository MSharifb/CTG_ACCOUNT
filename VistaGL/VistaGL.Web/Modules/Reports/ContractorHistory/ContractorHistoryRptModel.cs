using System;

namespace VistaGL.Modules.Reports
{
    public class ContractorHistoryRptModel
    {

        public Int32 id { get; set; }
        public Int32 ZoneInfoId { get; set; }
        public String ZoneInfoName { get; set; }
        public Int32 ledger_coaid { get; set; }
        public String ledger_coaname { get; set; }
        public String ledger_account_Group { get; set; }
        public Int32 fundControl_id { get; set; }
        public String voucherType { get; set; }
        public String voucherNo { get; set; }
        public Int32 voucher_id { get; set; }
        public DateTime chequeDate { get; set; }
        public Decimal amount { get; set; }
        public Decimal debitSD { get; set; }
        public Decimal creditSD { get; set; }
        public Decimal creditIT { get; set; }
        public String name { get; set; }
        public String Narration { get; set; }
        public String transactionLedgers { get; set; }
        public string chequeNo { get; set; }
        public Decimal creditVAT { get; set; }
        public Decimal PaidAmount { get; set; }
        public Decimal creditOther { get; set; }
        public Decimal ChequeAmount { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public int ZoneSortOrder { get; set; }
    }
}