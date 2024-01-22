
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccEmpAdvanceEditorDialog extends GridEditorDialog<AccEmpAdvanceRow> {
        protected getFormKey() { return AccEmpAdvanceForm.formKey; }
                protected getLocalTextPrefix() { return AccEmpAdvanceRow.localTextPrefix; }
        protected getNameProperty() { return AccEmpAdvanceRow.nameProperty; }
        protected form = new AccEmpAdvanceForm(this.idPrefix);
    }
}