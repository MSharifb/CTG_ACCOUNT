
namespace VistaGL.Transaction.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("Transaction.AccVoucherDtlAllocation")]
    [BasedOnRow(typeof(Entities.AccVoucherDtlAllocationRow))]
    public class AccVoucherDtlAllocationForm
    {
        public Int32 CostCenterTypeId{ get; set; }
        public Int32 CostCenterParentId{ get; set; }
        public Int32 CostCenterId { get; set; }
        public Decimal Amount { get; set; }
        //    public Int32 VoucherDetailId { get; set; }
    }
}