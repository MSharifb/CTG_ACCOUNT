
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccViewBudgetDetailsEditorDialog extends GridEditorDialog<AccViewBudgetDetailsRow> {
        protected getFormKey() { return AccViewBudgetDetailsForm.formKey; }        protected getLocalTextPrefix() { return AccViewBudgetDetailsRow.localTextPrefix; }
        protected getNameProperty() { return AccViewBudgetDetailsRow.nameProperty; }
        protected form = new AccViewBudgetDetailsForm(this.idPrefix);
    }
}