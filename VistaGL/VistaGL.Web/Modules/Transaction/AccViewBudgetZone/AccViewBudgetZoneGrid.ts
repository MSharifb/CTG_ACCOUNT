
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccViewBudgetZoneGrid extends Serenity.EntityGrid<AccViewBudgetZoneRow, any> {
        protected getColumnsKey() { return 'Transaction.AccViewBudgetZone'; }
        protected getDialogType() { return AccViewBudgetZoneDialog; }
        protected getLocalTextPrefix() { return AccViewBudgetZoneRow.localTextPrefix; }
        protected getService() { return AccViewBudgetZoneService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}