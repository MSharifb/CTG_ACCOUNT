
namespace VistaGL.Transaction{

    @Serenity.Decorators.registerClass()
    export class AccBudgetDetailsEditor extends GridEditorBase<AccBudgetDetailsRow> {
        protected getColumnsKey() { return 'Transaction.AccBudgetDetails'; }
        protected getDialogType() { return AccBudgetDetailsEditorDialog; }
        protected getLocalTextPrefix() { return AccBudgetDetailsRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}