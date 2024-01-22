
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccCostCentreDepreciationOpeningBalanceGrid extends Serenity.EntityGrid<AccCostCentreDepreciationOpeningBalanceRow, any> {
        protected getColumnsKey() { return 'Configurations.AccCostCentreDepreciationOpeningBalance'; }
        protected getDialogType() { return AccCostCentreDepreciationOpeningBalanceDialog; }
        protected getIdProperty() { return AccCostCentreDepreciationOpeningBalanceRow.idProperty; }
        protected getLocalTextPrefix() { return AccCostCentreDepreciationOpeningBalanceRow.localTextPrefix; }
        protected getService() { return AccCostCentreDepreciationOpeningBalanceService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}