using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Reports.MoneyReceiptRegister
{
    public class MoneyReceiptRegisterModel
    {
        public string ReceiveFrom { get; set; }
        public string MoneyReceiptNo { get; set; }
        public DateTime MonryReceiptDate { get; set; }
        public decimal Amount { get; set; }
        public string Narration { get; set; }
        public string voucherNo { get; set; }
        public DateTime voucherDate { get; set; }
        public string Remarks { get; set; }
    }
}