
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccReportTypeCoaMappingDialog extends Serenity.EntityDialog<AccReportTypeCoaMappingRow, any> {
        protected getFormKey() { return AccReportTypeCoaMappingForm.formKey; }
        protected getIdProperty() { return AccReportTypeCoaMappingRow.idProperty; }
        protected getLocalTextPrefix() { return AccReportTypeCoaMappingRow.localTextPrefix; }
        protected getService() { return AccReportTypeCoaMappingService.baseUrl; }

        protected form = new AccReportTypeCoaMappingForm(this.idPrefix);

    }
}