
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccCashFlowAdvTaxReportDialog extends Serenity.EntityDialog<AccCashFlowAdvTaxReportRow, any> {
        protected getFormKey() { return AccCashFlowAdvTaxReportForm.formKey; }
        protected getIdProperty() { return AccCashFlowAdvTaxReportRow.idProperty; }
        protected getLocalTextPrefix() { return AccCashFlowAdvTaxReportRow.localTextPrefix; }
        protected getService() { return AccCashFlowAdvTaxReportService.baseUrl; }

        protected form = new AccCashFlowAdvTaxReportForm(this.idPrefix);

    }
}