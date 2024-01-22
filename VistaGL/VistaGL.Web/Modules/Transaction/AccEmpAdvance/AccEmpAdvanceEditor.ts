
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccEmpAdvanceEditor extends GridEditorBase<AccEmpAdvanceRow> {
        protected getColumnsKey() { return 'Transaction.AccEmpAdvance'; }
        protected getDialogType() { return AccEmpAdvanceEditorDialog; }
                protected getLocalTextPrefix() { return AccEmpAdvanceRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}