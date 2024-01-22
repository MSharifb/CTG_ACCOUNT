
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccCurrencyConversionRateDialog extends Serenity.EntityDialog<AccCurrencyConversionRateRow, any> {
        protected getFormKey() { return AccCurrencyConversionRateForm.formKey; }
        protected getIdProperty() { return AccCurrencyConversionRateRow.idProperty; }
        protected getLocalTextPrefix() { return AccCurrencyConversionRateRow.localTextPrefix; }
        protected getService() { return AccCurrencyConversionRateService.baseUrl; }

        protected form = new AccCurrencyConversionRateForm(this.idPrefix);

    }
}