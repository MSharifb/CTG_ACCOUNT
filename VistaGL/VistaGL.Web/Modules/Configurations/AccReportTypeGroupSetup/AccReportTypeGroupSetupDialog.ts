
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccReportTypeGroupSetupDialog extends Serenity.EntityDialog<AccReportTypeGroupSetupRow, any> {
        protected getFormKey() { return AccReportTypeGroupSetupForm.formKey; }
        protected getIdProperty() { return AccReportTypeGroupSetupRow.idProperty; }
        protected getLocalTextPrefix() { return AccReportTypeGroupSetupRow.localTextPrefix; }
        protected getNameProperty() { return AccReportTypeGroupSetupRow.nameProperty; }
        protected getService() { return AccReportTypeGroupSetupService.baseUrl; }

        protected form = new AccReportTypeGroupSetupForm(this.idPrefix);

    }
}