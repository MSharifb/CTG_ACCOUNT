
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccBudgetGrid extends EntityGridBaseNew<AccBudgetRow, any> {
        protected getColumnsKey() { return 'Transaction.AccBudget'; }
        protected getDialogType() { return AccBudgetDialog; }
        protected getIdProperty() { return AccBudgetRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetRow.localTextPrefix; }
        protected getService() { return AccBudgetService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}