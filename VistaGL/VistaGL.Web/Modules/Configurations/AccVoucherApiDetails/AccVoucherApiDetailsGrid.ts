
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherApiDetailsGrid extends Serenity.EntityGrid<AccVoucherApiDetailsRow, any> {
        protected getColumnsKey() { return 'Configurations.AccVoucherApiDetails'; }
        protected getDialogType() { return AccVoucherApiDetailsDialog; }
        protected getIdProperty() { return AccVoucherApiDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherApiDetailsRow.localTextPrefix; }
        protected getService() { return AccVoucherApiDetailsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}