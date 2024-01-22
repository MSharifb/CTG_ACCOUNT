
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccCurrencyConversionRateGrid extends EntityGridBase<AccCurrencyConversionRateRow, any> {
        protected getColumnsKey() { return 'Configurations.AccCurrencyConversionRate'; }
        protected getDialogType() { return AccCurrencyConversionRateDialog; }
        protected getIdProperty() { return AccCurrencyConversionRateRow.idProperty; }
        protected getLocalTextPrefix() { return AccCurrencyConversionRateRow.localTextPrefix; }
        protected getService() { return AccCurrencyConversionRateService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}