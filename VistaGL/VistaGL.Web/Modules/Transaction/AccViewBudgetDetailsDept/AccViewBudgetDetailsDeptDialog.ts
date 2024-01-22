
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccViewBudgetDetailsDeptDialog extends Serenity.EntityDialog<AccViewBudgetDetailsDeptRow, any> {
        protected getFormKey() { return AccViewBudgetDetailsDeptForm.formKey; }
        protected getLocalTextPrefix() { return AccViewBudgetDetailsDeptRow.localTextPrefix; }
        protected getNameProperty() { return AccViewBudgetDetailsDeptRow.nameProperty; }
        protected getService() { return AccViewBudgetDetailsDeptService.baseUrl; }

        protected form = new AccViewBudgetDetailsDeptForm(this.idPrefix);

    }
}