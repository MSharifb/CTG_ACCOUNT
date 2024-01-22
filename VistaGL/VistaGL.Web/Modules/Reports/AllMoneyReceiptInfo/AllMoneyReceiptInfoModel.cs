using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports
{
    public class AllMoneyReceiptInfoModel
    {

        public int id { get; set; }
        public String SerialNo { get; set; }
        public String paytoOrReciveFrom { get; set; }
        public String amountInWords { get; set; }
        public String description { get; set; }
        public Decimal amount { get; set; }
        public Decimal HeadAmount { get; set; }
        public String accountName { get; set; }
        public String chequeNo { get; set; }
        public String receiveType { get; set; }
        public DateTime chequeDate { get; set; }
        public DateTime chequeReceiveDate { get; set; }
        public DateTime MonryReceiptDate { get; set; }
        public String bankName { get; set; }
        public String ourbank { get; set; }
        public String ourbrance { get; set; }
        public String ouraccno { get; set; }
        public String Subledger { get; set; }
        public byte[] Signature { get; set; }
        public String EmployeeName { get; set; }
        public string accountCode { get; set; }
    }
}