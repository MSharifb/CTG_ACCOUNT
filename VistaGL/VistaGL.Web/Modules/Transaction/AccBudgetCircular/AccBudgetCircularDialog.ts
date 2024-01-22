
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccBudgetCircularDialog extends Serenity.EntityDialog<AccBudgetCircularRow, any> {
        protected getFormKey() { return AccBudgetCircularForm.formKey; }
        protected getIdProperty() { return AccBudgetCircularRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetCircularRow.localTextPrefix; }
        protected getService() { return AccBudgetCircularService.baseUrl; }

        protected form = new AccBudgetCircularForm(this.idPrefix);

    }
}