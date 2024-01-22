
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccBudgetDetailsGrid extends Serenity.EntityGrid<AccBudgetDetailsRow, any> {
        protected getColumnsKey() { return 'Transaction.AccBudgetDetails'; }
        protected getDialogType() { return AccBudgetDetailsDialog; }
        protected getIdProperty() { return AccBudgetDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetDetailsRow.localTextPrefix; }
        protected getService() { return AccBudgetDetailsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}