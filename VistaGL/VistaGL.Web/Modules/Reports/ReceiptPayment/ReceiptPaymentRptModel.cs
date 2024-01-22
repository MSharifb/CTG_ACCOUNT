using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports
{
    public class ReceiptPaymentRptModel
    {

        public String coa_name { get; set; }
        public String transactionType { get; set; }
        public Decimal sumAmount { get; set; }
        public Decimal sumAmount2 { get; set; }
        public string ZoneName { get; set; }
        public Int32 tempSerial { get; set; }
    }


    public class ReceiptPaymentDetailsRptModel
    {
        public String transactionType { get; set; }

        public String ledger_COAparent { get; set; }
        public int? ledger_coaid { get; set; }
        public String ledger_coaname { get; set; }
        public String ledger_account_Group { get; set; }
        public String coa_UserCode { get; set; }
        public String coa_mapping { get; set; }

        public String subLedger_Parent_Code { get; set; }
        public String subLedger_Parent { get; set; }
        public int? subLedger_id { get; set; }
        public String subLedger_code { get; set; }
        public String subLedger { get; set; }

        public Decimal coa_openingBalance { get; set; }
        public Decimal budget_Amount { get; set; }
        public Decimal opening_balance { get; set; }
        public Decimal amount_InDateRange { get; set; }
        public Decimal closing_balance { get; set; }
        public Decimal bank_CurrentOpening { get; set; }

        public int? tempSerial { get; set; }
        public int? SortOrder { get; set; }
        public Boolean ShowSumInReceiptPaymentReport { get; set; }
        public Decimal total_Ob_Bank { get; set; }
        public Decimal total_Payment_OpeningBalance { get; set; }
        public Decimal total_Payment_InDateRange { get; set; }
        public Decimal total_Receipt_OB { get; set; }
        public Decimal total_Receipt { get; set; }
        public Decimal total_Payment { get; set; }

        public String ZoneName { get; set; }
        public String ZoneCode { get; set; }
        public int ZoneSortOrder { get; set; }
        public String ParentHeadName { get; set; }
        public String HeadName { get; set; }
        public int ParentHeadId { get; set; }
        public int HeadId { get; set; }
        public int BGSortOrder { get; set; }
    }
}