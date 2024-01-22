
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccBudgetZoneApproverGrid extends EntityGridBase<AccBudgetZoneApproverRow, any> {
        protected getColumnsKey() { return 'Configurations.AccBudgetZoneApprover'; }
        protected getDialogType() { return AccBudgetZoneApproverDialog; }
        protected getIdProperty() { return AccBudgetZoneApproverRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetZoneApproverRow.localTextPrefix; }
        protected getService() { return AccBudgetZoneApproverService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}