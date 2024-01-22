
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherApiConfigDetailsGrid extends Serenity.EntityGrid<AccVoucherApiConfigDetailsRow, any> {
        protected getColumnsKey() { return 'Configurations.AccVoucherApiConfigDetails'; }
        protected getDialogType() { return AccVoucherApiConfigDetailsDialog; }
        protected getIdProperty() { return AccVoucherApiConfigDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherApiConfigDetailsRow.localTextPrefix; }
        protected getService() { return AccVoucherApiConfigDetailsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}