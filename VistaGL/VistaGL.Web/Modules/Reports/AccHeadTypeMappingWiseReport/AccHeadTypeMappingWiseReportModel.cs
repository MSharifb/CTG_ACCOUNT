using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.AccHeadTypeMappingWiseReport
{
    public class AccHeadTypeMappingWiseReportModel
    {
        public String costCenterName { get; set; }
        public String accountName { get; set; }
        public decimal amount { get; set; }
        public decimal debitAmount { get; set; }
        public decimal creditAmount { get; set; }
        public string ZoneName { get; set; }
        public string VoucherNo { get; set; }
        public DateTime voucherDate { get; set; }
        public String ChartofAccountName { get; set; }
        public String chequeNo { get; set; }
        public DateTime chequeDate { get; set; }
    }
}