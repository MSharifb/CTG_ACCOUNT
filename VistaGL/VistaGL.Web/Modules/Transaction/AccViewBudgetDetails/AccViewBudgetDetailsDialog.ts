
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccViewBudgetDetailsDialog extends Serenity.EntityDialog<AccViewBudgetDetailsRow, any> {
        protected getFormKey() { return AccViewBudgetDetailsForm.formKey; }
        protected getLocalTextPrefix() { return AccViewBudgetDetailsRow.localTextPrefix; }
        protected getNameProperty() { return AccViewBudgetDetailsRow.nameProperty; }
        protected getService() { return AccViewBudgetDetailsService.baseUrl; }

        protected form = new AccViewBudgetDetailsForm(this.idPrefix);

    }
}