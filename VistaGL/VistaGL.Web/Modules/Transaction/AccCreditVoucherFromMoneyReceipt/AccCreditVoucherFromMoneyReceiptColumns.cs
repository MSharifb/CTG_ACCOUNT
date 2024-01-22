
namespace VistaGL.Transaction.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("Transaction.AccCreditVoucherFromMoneyReceipt")]
    [BasedOnRow(typeof(Entities.AccMoneyReceiptRow), CheckNames = true)]
    public class AccCreditVoucherFromMoneyReceiptColumns
    {
        public String SerialNo { get; set; }

        [QuickFilter, AlignRight]
        public DateTime MonryReceiptDate { get; set; }

        //[QuickFilter, FilterOnly]
        //public Int32 CoaId { get; set; }

        //public String CoaAccountName { get; set; }

        //[QuickFilter, FilterOnly]
        //public Int32 CostCenterId { get; set; }

        //public String CostCenterName { get; set; }

        [QuickFilter, AlignRight]
        public Decimal Amount { get; set; }

        [Width(300)]
        public String Narration { get; set; }

        [QuickFilter, AlignCenter, Width(140)]
        public String ChequeType { get; set; }

        [QuickFilter, AlignRight, Width(140)]
        public DateTime ChequeDate { get; set; }

        [QuickFilter, FilterOnly]
        [LookupEditor("Configurations.AccCoABank_Lookup")]
        public Int32 AccHeadBankId { get; set; }

        public String AccHeadBankName { get; set; }
    }
}