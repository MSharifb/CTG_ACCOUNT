
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccGovtLoanReportGrid extends EntityGridBase<AccGovtLoanReportRow, any> {
        protected getColumnsKey() { return 'Configurations.AccGovtLoanReport'; }
        protected getDialogType() { return AccGovtLoanReportDialog; }
        protected getIdProperty() { return AccGovtLoanReportRow.idProperty; }
        protected getLocalTextPrefix() { return AccGovtLoanReportRow.localTextPrefix; }
        protected getService() { return AccGovtLoanReportService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}