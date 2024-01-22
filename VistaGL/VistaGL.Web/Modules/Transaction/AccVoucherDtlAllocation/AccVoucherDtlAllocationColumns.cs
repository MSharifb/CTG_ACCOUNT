
namespace VistaGL.Transaction.Columns
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("Transaction.AccVoucherDtlAllocation")]
    [BasedOnRow(typeof(Entities.AccVoucherDtlAllocationRow))]
    public class AccVoucherDtlAllocationColumns
    {
        [EditLink]
        public String CostCenterName { get; set; }

        [AlignRight, Width(100, Min = 100)]
        public Decimal Amount { get; set; }

        //   public Int32 VoucherDetailId { get; set; }
    }
}