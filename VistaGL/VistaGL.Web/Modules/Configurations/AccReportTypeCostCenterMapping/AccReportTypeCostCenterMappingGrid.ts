
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccReportTypeCostCenterMappingGrid extends Serenity.EntityGrid<AccReportTypeCostCenterMappingRow, any> {
        protected getColumnsKey() { return 'Configurations.AccReportTypeCostCenterMapping'; }
        protected getDialogType() { return AccReportTypeCostCenterMappingDialog; }
        protected getIdProperty() { return AccReportTypeCostCenterMappingRow.idProperty; }
        protected getLocalTextPrefix() { return AccReportTypeCostCenterMappingRow.localTextPrefix; }
        protected getService() { return AccReportTypeCostCenterMappingService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}