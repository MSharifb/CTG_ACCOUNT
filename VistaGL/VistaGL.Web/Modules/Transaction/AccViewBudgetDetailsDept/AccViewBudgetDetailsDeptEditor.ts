
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccViewBudgetDetailsDeptEditor extends GridEditorBase<AccViewBudgetDetailsDeptRow> {
        protected getColumnsKey() { return 'Transaction.AccViewBudgetDetailsDept'; }
        protected getDialogType() { return AccViewBudgetDetailsDeptEditorDialog; }        protected getLocalTextPrefix() { return AccViewBudgetDetailsDeptRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}