
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherApiConfigGrid extends Serenity.EntityGrid<AccVoucherApiConfigRow, any> {
        protected getColumnsKey() { return 'Configurations.AccVoucherApiConfig'; }
        protected getDialogType() { return AccVoucherApiConfigDialog; }
        protected getIdProperty() { return AccVoucherApiConfigRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherApiConfigRow.localTextPrefix; }
        protected getService() { return AccVoucherApiConfigService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}