

namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccViewBudgetDetailsDeptEditorDialog extends GridEditorDialog<AccViewBudgetDetailsDeptRow> {
        protected getFormKey() { return AccViewBudgetDetailsDeptForm.formKey; }        protected getLocalTextPrefix() { return AccViewBudgetDetailsDeptRow.localTextPrefix; }
        protected getNameProperty() { return AccViewBudgetDetailsDeptRow.nameProperty; }
        protected form = new AccViewBudgetDetailsDeptForm(this.idPrefix);
    }
}