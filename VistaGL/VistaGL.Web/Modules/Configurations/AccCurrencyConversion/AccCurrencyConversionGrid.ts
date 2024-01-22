
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccCurrencyConversionGrid extends EntityGridBase<AccCurrencyConversionRow, any> {
        protected getColumnsKey() { return 'Configurations.AccCurrencyConversion'; }
        protected getDialogType() { return AccCurrencyConversionDialog; }
        protected getIdProperty() { return AccCurrencyConversionRow.idProperty; }
        protected getLocalTextPrefix() { return AccCurrencyConversionRow.localTextPrefix; }
        protected getService() { return AccCurrencyConversionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}