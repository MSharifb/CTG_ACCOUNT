

namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccViewBudgetDetailsEditor extends GridEditorBase<AccViewBudgetDetailsRow> {
        protected getColumnsKey() { return 'Transaction.AccViewBudgetDetails'; }
        protected getDialogType() { return AccViewBudgetDetailsEditorDialog; }        protected getLocalTextPrefix() { return AccViewBudgetDetailsRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}