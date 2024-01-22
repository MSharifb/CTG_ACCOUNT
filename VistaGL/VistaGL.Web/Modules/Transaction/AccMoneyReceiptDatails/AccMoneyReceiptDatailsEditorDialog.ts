
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccMoneyReceiptDatailsEditorDialog extends GridEditorDialog<AccMoneyReceiptDatailsRow> {
        protected getFormKey() { return AccMoneyReceiptDatailsForm.formKey; }
        protected getLocalTextPrefix() { return AccMoneyReceiptDatailsRow.localTextPrefix; }
        //protected getNameProperty() { return AccMoneyReceiptDatailsRow.nameProperty; }
        protected form = new AccMoneyReceiptDatailsForm(this.idPrefix);
    }
}