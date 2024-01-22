
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccMoneyReceiptDatailsDialog extends Serenity.EntityDialog<AccMoneyReceiptDatailsRow, any> {
        protected getFormKey() { return AccMoneyReceiptDatailsForm.formKey; }
        protected getIdProperty() { return AccMoneyReceiptDatailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccMoneyReceiptDatailsRow.localTextPrefix; }
        protected getService() { return AccMoneyReceiptDatailsService.baseUrl; }

        protected form = new AccMoneyReceiptDatailsForm(this.idPrefix);

    }
}