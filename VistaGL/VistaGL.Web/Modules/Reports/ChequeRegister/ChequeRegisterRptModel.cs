using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.ChequeRegister
{
    public class ChequeRegisterRptModel
    {
        public int VoucherTypeId { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherNumber { get; set; }
        public string Particulars { get; set; }
        public int? ChequeRegisterId { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string ChequeRemarks { get; set; }
        public decimal Amount { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string ZoneName { get; set; }
        public string AccountName { get; set; }
        public string ChequeBookNo { get; set; }
    }
}