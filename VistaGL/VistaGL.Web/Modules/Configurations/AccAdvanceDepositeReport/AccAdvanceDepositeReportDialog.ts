
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccAdvanceDepositeReportDialog extends Serenity.EntityDialog<AccAdvanceDepositeReportRow, any> {
        protected getFormKey() { return AccAdvanceDepositeReportForm.formKey; }
        protected getIdProperty() { return AccAdvanceDepositeReportRow.idProperty; }
        protected getLocalTextPrefix() { return AccAdvanceDepositeReportRow.localTextPrefix; }
        protected getService() { return AccAdvanceDepositeReportService.baseUrl; }

        protected form = new AccAdvanceDepositeReportForm(this.idPrefix);

    }
}