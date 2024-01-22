using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaGL.Modules.Transaction.AccBankReconciliationDirect
{
    public class IsClearModel
    {
        public string EffectiveValue { get; set; }
        public string VoucherInformationVoucherTypeId { get; set; }
        public string ChartofAccountsId { get; set; }
        public string IsClearDate { get; set; }
    }
}