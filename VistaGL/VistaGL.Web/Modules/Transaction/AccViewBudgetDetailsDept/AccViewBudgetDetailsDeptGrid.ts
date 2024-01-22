
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccViewBudgetDetailsDeptGrid extends Serenity.EntityGrid<AccViewBudgetDetailsDeptRow, any> {
        protected getColumnsKey() { return 'Transaction.AccViewBudgetDetailsDept'; }
        protected getDialogType() { return AccViewBudgetDetailsDeptDialog; }
        protected getLocalTextPrefix() { return AccViewBudgetDetailsDeptRow.localTextPrefix; }
        protected getService() { return AccViewBudgetDetailsDeptService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}