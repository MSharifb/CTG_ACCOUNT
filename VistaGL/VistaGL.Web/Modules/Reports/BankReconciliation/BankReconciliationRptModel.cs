using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.BankReconciliation
{
    public class BankReconciliationRptModel
    {
        public String paytoOrReciveFrom { get; set; }
        public DateTime voucherDate { get; set; }
        public String chequeNo { get; set; }
        public decimal Amount { get; set; }

        public Int32 VoucherTypeId { get; set; }
        public String voucher_type { get; set; }
        public decimal BankBlanceAsOn { get; set; }
        public String ISSUED { get; set; }
        public String accountName { get; set; }
        public String ZoneName { get; set; }
        public String ZoneAddress { get; set; }
        public decimal BankBalanceAsPerStat { get; set; }
        public DateTime AsOnDate { get; set; }

    }


    public class BankReconciliationOption2RptModel
    {
        public String paytoOrReciveFrom { get; set; }
        public DateTime voucherDate { get; set; }
        public String chequeNo { get; set; }
        public decimal Amount { get; set; }

        public Int32 VoucherTypeId { get; set; }
        public String voucher_type { get; set; }
        public String accountName { get; set; }
        public String ZoneName { get; set; }
        public String ZoneAddress { get; set; }
        public byte postToLedger { get; set; }
        public DateTime clearDate { get; set; }
        public DateTime postingDate { get; set; }
        public bool IsDirect { get; set; }
    }
}