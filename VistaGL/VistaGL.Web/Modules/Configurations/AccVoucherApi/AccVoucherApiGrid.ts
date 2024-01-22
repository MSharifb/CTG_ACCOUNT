
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherApiGrid extends Serenity.EntityGrid<AccVoucherApiRow, any> {
        protected getColumnsKey() { return 'Configurations.AccVoucherApi'; }
        protected getDialogType() { return AccVoucherApiDialog; }
        protected getIdProperty() { return AccVoucherApiRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherApiRow.localTextPrefix; }
        protected getService() { return AccVoucherApiService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}