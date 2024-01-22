


namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccViewBudgetZoneEditor extends GridEditorBase<AccViewBudgetZoneRow> {
        protected getColumnsKey() { return 'Transaction.AccViewBudgetZone'; }
        protected getDialogType() { return AccViewBudgetZoneEditorDialog; }        protected getLocalTextPrefix() { return AccViewBudgetZoneRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}