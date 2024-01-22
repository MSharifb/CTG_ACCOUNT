
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccReportTypeCoaMappingGrid extends Serenity.EntityGrid<AccReportTypeCoaMappingRow, any> {
        protected getColumnsKey() { return 'Configurations.AccReportTypeCoaMapping'; }
        protected getDialogType() { return AccReportTypeCoaMappingDialog; }
        protected getIdProperty() { return AccReportTypeCoaMappingRow.idProperty; }
        protected getLocalTextPrefix() { return AccReportTypeCoaMappingRow.localTextPrefix; }
        protected getService() { return AccReportTypeCoaMappingService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}