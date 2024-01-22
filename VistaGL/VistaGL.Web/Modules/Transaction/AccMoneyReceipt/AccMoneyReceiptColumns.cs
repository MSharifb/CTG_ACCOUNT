
namespace VistaGL.Transaction.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("Transaction.AccMoneyReceipt")]
    [BasedOnRow(typeof(Entities.AccMoneyReceiptRow))]
    public class AccMoneyReceiptColumns
    {
        [EditLink]
        public String SerialNo { get; set; }

        [QuickFilter, AlignRight]
        public DateTime MonryReceiptDate { get; set; }

        //[QuickFilter, FilterOnly]
        //public Int32 CoaId { get; set; }

        //[EditLink]
        //public String CoaAccountName { get; set; }

        //[QuickFilter, FilterOnly]
        //public Int32 CostCenterId { get; set; }

        //[EditLink]
        //public String CostCenterName { get; set; }

        [QuickFilter, AlignRight]
        public Decimal Amount { get; set; }

        public String Narration { get; set; }

        [QuickFilter, FilterOnly]
        [LookupEditor("Configurations.AccCoABank_Lookup")]
        public Int32 AccHeadBankId { get; set; }

        public String AccHeadBankName { get; set; }
        [QuickFilter, AlignCenter]
        public Boolean IsConfirmed { get; set; }

        [QuickFilter, AlignCenter]
        public Boolean IsCancelled { get; set; }

        [QuickFilter, AlignCenter]
        [TrueFalseEditor]
        public Boolean IsUsed { get; set; }

        public String VouchervoucherNo { get; set; }
    }
}