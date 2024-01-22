
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccBudgetDetailsDialog extends Serenity.EntityDialog<AccBudgetDetailsRow, any> {
        protected getFormKey() { return AccBudgetDetailsForm.formKey; }
        protected getIdProperty() { return AccBudgetDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetDetailsRow.localTextPrefix; }
        protected getNameProperty() { return AccBudgetDetailsRow.nameProperty; }
        protected getService() { return AccBudgetDetailsService.baseUrl; }

        protected form = new AccBudgetDetailsForm(this.idPrefix);

    }
}