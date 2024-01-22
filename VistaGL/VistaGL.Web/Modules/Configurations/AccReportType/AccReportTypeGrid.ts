
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccReportTypeGrid extends Serenity.EntityGrid<AccReportTypeRow, any> {
        protected getColumnsKey() { return 'Configurations.AccReportType'; }
        protected getDialogType() { return AccReportTypeDialog; }
        protected getIdProperty() { return AccReportTypeRow.idProperty; }
        protected getLocalTextPrefix() { return AccReportTypeRow.localTextPrefix; }
        protected getService() { return AccReportTypeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}