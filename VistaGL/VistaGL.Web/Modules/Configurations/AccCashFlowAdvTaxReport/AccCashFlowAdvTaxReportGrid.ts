
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccCashFlowAdvTaxReportGrid extends EntityGridBase<AccCashFlowAdvTaxReportRow, any> {
        protected getColumnsKey() { return 'Configurations.AccCashFlowAdvTaxReport'; }
        protected getDialogType() { return AccCashFlowAdvTaxReportDialog; }
        protected getIdProperty() { return AccCashFlowAdvTaxReportRow.idProperty; }
        protected getLocalTextPrefix() { return AccCashFlowAdvTaxReportRow.localTextPrefix; }
        protected getService() { return AccCashFlowAdvTaxReportService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}