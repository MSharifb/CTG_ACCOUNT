using _Ext;
using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace VistaGL.Transaction.Forms
{
    [FormScript("Transaction.AccCreditVoucherParameters")]
    [BasedOnRow(typeof(Entities.AccMoneyReceiptRow))]
    public class AccCreditVoucherParametersForm
    {
        //[GetRecommenderInfoByApplicantVoucherEditor, CssClass("width6"), OneWay]
        //[DisplayName("Send To")]
        //public Int32 ApproverId { get; set; }

        [Required]
        public DateTime CreditVoucherDate { get; set; }

        [AutoCompleteEditor(LookupKey = "Transaction.AccCostCentreOrInstituteInformation_LookupForAutoComplete")]
        public String ReceiveFrom { get; set; }

        [TextAreaEditor(Rows = 5), Required]
        public String CreditVoucherNarration { get; set; }
    }
}