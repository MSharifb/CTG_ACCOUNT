
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccVoucherDtlAllocationGrid extends EntityGridBaseNew<AccVoucherDtlAllocationRow, any> {
        protected getColumnsKey() { return 'Transaction.AccVoucherDtlAllocation'; }
        protected getDialogType() { return AccVoucherDtlAllocationDialog; }
        protected getIdProperty() { return AccVoucherDtlAllocationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherDtlAllocationRow.localTextPrefix; }
        protected getService() { return AccVoucherDtlAllocationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}