
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherConfigurationGrid extends EntityGridBase<AccVoucherConfigurationRow, any> {
        protected getColumnsKey() { return 'Transaction.AccVoucherConfiguration'; }
        protected getDialogType() { return AccVoucherConfigurationDialog; }
        protected getIdProperty() { return AccVoucherConfigurationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherConfigurationRow.localTextPrefix; }
        protected getService() { return AccVoucherConfigurationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}