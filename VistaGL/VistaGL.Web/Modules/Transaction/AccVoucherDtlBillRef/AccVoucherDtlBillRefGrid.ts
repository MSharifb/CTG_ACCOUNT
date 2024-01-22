
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherDtlBillRefGrid extends Serenity.EntityGrid<AccVoucherDtlBillRefRow, any> {
        protected getColumnsKey() { return 'Transaction.AccVoucherDtlBillRef'; }
        protected getDialogType() { return AccVoucherDtlBillRefDialog; }
        protected getIdProperty() { return AccVoucherDtlBillRefRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherDtlBillRefRow.localTextPrefix; }
        protected getService() { return AccVoucherDtlBillRefService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}