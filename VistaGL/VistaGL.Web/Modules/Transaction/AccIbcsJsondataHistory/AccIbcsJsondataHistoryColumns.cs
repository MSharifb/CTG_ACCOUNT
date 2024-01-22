
namespace VistaGL.Transaction.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("Transaction.AccIbcsJsondataHistory")]
    [BasedOnRow(typeof(Entities.AccIbcsJsondataHistoryRow), CheckNames = true)]
    public class AccIbcsJsondataHistoryColumns
    {
        public String VoucherNo { get; set; }

        [QuickFilter, SortOrder(1, true), AlignRight]
        public DateTime VoucherDate { get; set; }

        [QuickFilter, FilterOnly]
        public Int32? FundControlId { get; set; }

        public String JsonData { get; set; }

        [QuickFilter, AlignRight]
        public DateTime CreateDate { get; set; }

        [QuickFilter]
        public Boolean IsSuccess { get; set; }
    }
}