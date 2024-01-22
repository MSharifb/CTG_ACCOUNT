
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccBudgetDialog extends EntityDialogBase<AccBudgetRow, any> {
        protected getFormKey() { return AccBudgetForm.formKey; }
        protected getIdProperty() { return AccBudgetRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetRow.localTextPrefix; }
        protected getNameProperty() { return AccBudgetRow.nameProperty; }
        protected getService() { return AccBudgetService.baseUrl; }

        protected form = new AccBudgetForm(this.idPrefix);
    }
}