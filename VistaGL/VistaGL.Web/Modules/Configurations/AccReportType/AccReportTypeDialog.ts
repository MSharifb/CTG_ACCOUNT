
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccReportTypeDialog extends Serenity.EntityDialog<AccReportTypeRow, any> {
        protected getFormKey() { return AccReportTypeForm.formKey; }
        protected getIdProperty() { return AccReportTypeRow.idProperty; }
        protected getLocalTextPrefix() { return AccReportTypeRow.localTextPrefix; }
        protected getNameProperty() { return AccReportTypeRow.nameProperty; }
        protected getService() { return AccReportTypeService.baseUrl; }

        protected form = new AccReportTypeForm(this.idPrefix);

    }
}