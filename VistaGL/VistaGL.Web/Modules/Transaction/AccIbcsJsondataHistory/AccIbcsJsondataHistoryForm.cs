
namespace VistaGL.Transaction.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("Transaction.AccIbcsJsondataHistory")]
    [BasedOnRow(typeof(Entities.AccIbcsJsondataHistoryRow), CheckNames = true)]
    public class AccIbcsJsondataHistoryForm
    {
        //public String VoucherNo { get; set; }
        //public DateTime VoucherDate { get; set; }
        //public Int32 ZoneId { get; set; }
        //public Int32 FundControlId { get; set; }

        [TextAreaEditor(Rows = 15), Updatable(false)]
        public String JsonData { get; set; }

        //public DateTime CreateDate { get; set; }
        //public Boolean IsSuccess { get; set; }
    }
}