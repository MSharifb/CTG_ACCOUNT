using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.ChequeIssueInfo
{
    public class ChequIssueInfoRptModel
    {
        public int ChequeIssueId { get; set; }       
        public int BankAccountId { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNo { get; set; }
        public string ChequeNo { get; set; }
        public string payTo { get; set; }
        public string Description { get; set; }
        public decimal amount { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }

        public int ZoneInfoId { get; set; }
        public string ZoneName { get; set; }


    }
}