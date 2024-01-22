
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccGovtLoanReportDialog extends Serenity.EntityDialog<AccGovtLoanReportRow, any> {
        protected getFormKey() { return AccGovtLoanReportForm.formKey; }
        protected getIdProperty() { return AccGovtLoanReportRow.idProperty; }
        protected getLocalTextPrefix() { return AccGovtLoanReportRow.localTextPrefix; }
        protected getService() { return AccGovtLoanReportService.baseUrl; }

        protected form = new AccGovtLoanReportForm(this.idPrefix);

    }
}