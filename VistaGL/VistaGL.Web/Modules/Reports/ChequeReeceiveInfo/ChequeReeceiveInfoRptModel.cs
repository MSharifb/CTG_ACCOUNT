using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.ChequeIssueInfo
{
    public class ChequeReeceiveInfoRptModel
    {
        public int chequeReceiveId { get; set; }
        public string bankName { get; set; }
        public string branchName { get; set; }
        public string accountName { get; set; }
        public string accountNo { get; set; }
        public string ChequeNo { get; set; }
        public string receiveType { get; set; }
        public string Description { get; set; }
        public string BankAccountNo { get; set; }     
        public decimal amount { get; set; }
        public DateTime chequeDate { get; set; }
        public DateTime chequeReceiveDate { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public int ChartOfAccountId { get; set; }
        public string ChartOfAccountName { get; set; }
        public int ZoneInfoId { get; set; }
        public string ZoneName { get; set; }
    }
}