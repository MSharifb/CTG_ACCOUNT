
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    @Serenity.Decorators.maximizable()
    export class AccBudgetForDepartmentDialog extends Serenity.EntityDialog<AccBudgetForDepartmentRow, any> {
        protected getFormKey() { return AccBudgetForDepartmentForm.formKey; }
        protected getIdProperty() { return AccBudgetForDepartmentRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetForDepartmentRow.localTextPrefix; }
        protected getService() { return AccBudgetForDepartmentService.baseUrl; }

        protected form = new AccBudgetForDepartmentForm(this.idPrefix);

        onDialogOpen(): void {
            super.onDialogOpen();

            // Maximize the dialog
            this.element.closest('.ui-dialog').find('.ui-dialog-titlebar-maximize').click();

            if (this.isNew) {
                let activeBudgetId = AccBudgetCircularRow.getLookup().items.filter(x => x.IsActive == true)[0].Id;
                this.form.BudgetCircularId.value = activeBudgetId.toString();
            }
        }
    }
}