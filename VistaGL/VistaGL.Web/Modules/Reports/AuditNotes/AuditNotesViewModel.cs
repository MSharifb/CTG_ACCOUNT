using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.AuditNotes
{
    public class AuditNotesViewModel
    {
        public decimal IncomeTax { get; set; }
        public decimal Adjustment { get; set; }
        public string PreYearName { get; set; }
        public string CurrentYear { get; set; }
        public decimal ProvisionOfTax { get; set; }
        public decimal Opening { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal Closing { get; set; }
        public string ZoneName { get; set; }
        public string accountName { get; set; }
        public decimal creditAmount { get; set; }
        public decimal debitAmount { get; set; }
        public string ParentAccountName { get; set; }
        public decimal creditAmountOpening { get; set; }
        public decimal debitAmountOpening { get; set; }
        public decimal creditAmountClosing { get; set; }
        public decimal debitAmountClosing { get; set; }
        public string ZoneCode { get; set; }
        public string ParentName { get; set;}
        public int SortOrder { get; set; }
        public decimal PeriodBalance { get; set; }
        public decimal OpeningLoan { get; set; }
        public decimal OpeningLoanRefund { get; set; }
        public int Sorting { get; set; }
    }
}