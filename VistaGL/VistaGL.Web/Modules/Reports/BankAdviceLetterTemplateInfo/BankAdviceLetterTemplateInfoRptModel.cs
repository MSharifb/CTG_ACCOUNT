using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.BankAdviceLetterTemplateInfo
{
    public class BankAdviceLetterTemplateInfoRptModel
    {
        public String payTo { get; set; }
        public String chequeNo { get; set; }
        public DateTime Date { get; set; }
        public Decimal amount { get; set; }
        public String accountNumber { get; set; }
        public String bankName { get; set; }
        public String branchName { get; set; }
        public string address { get; set; }
        public string ZoneName { get; set; }
        public string ZoneAddress { get; set; }
    }
}