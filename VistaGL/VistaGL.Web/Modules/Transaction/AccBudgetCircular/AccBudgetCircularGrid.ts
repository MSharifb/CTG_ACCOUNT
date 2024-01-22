
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccBudgetCircularGrid extends Serenity.EntityGrid<AccBudgetCircularRow, any> {
        protected getColumnsKey() { return 'Transaction.AccBudgetCircular'; }
        protected getDialogType() { return AccBudgetCircularDialog; }
        protected getIdProperty() { return AccBudgetCircularRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetCircularRow.localTextPrefix; }
        protected getService() { return AccBudgetCircularService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}