

namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccViewBudgetZoneEditorDialog extends GridEditorDialog<AccViewBudgetZoneRow> {
        protected getFormKey() { return AccViewBudgetZoneForm.formKey; }        protected getLocalTextPrefix() { return AccViewBudgetZoneRow.localTextPrefix; }
        protected getNameProperty() { return AccViewBudgetZoneRow.nameProperty; }
        protected form = new AccViewBudgetZoneForm(this.idPrefix);
    }
}