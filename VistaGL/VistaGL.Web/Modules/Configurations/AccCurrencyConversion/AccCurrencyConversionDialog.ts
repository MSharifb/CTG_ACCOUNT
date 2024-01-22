
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccCurrencyConversionDialog extends Serenity.EntityDialog<AccCurrencyConversionRow, any> {
        protected getFormKey() { return AccCurrencyConversionForm.formKey; }
        protected getIdProperty() { return AccCurrencyConversionRow.idProperty; }
        protected getLocalTextPrefix() { return AccCurrencyConversionRow.localTextPrefix; }
        protected getNameProperty() { return AccCurrencyConversionRow.nameProperty; }
        protected getService() { return AccCurrencyConversionService.baseUrl; }

        protected form = new AccCurrencyConversionForm(this.idPrefix);

    }
}