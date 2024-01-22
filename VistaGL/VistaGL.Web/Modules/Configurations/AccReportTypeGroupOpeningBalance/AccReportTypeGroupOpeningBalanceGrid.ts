
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccReportTypeGroupOpeningBalanceGrid extends Serenity.EntityGrid<AccReportTypeGroupOpeningBalanceRow, any> {
        protected getColumnsKey() { return 'Configurations.AccReportTypeGroupOpeningBalance'; }
        protected getDialogType() { return AccReportTypeGroupOpeningBalanceDialog; }
        protected getIdProperty() { return AccReportTypeGroupOpeningBalanceRow.idProperty; }
        protected getLocalTextPrefix() { return AccReportTypeGroupOpeningBalanceRow.localTextPrefix; }
        protected getService() { return AccReportTypeGroupOpeningBalanceService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}