
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccReportTypeGroupOpeningBalanceDialog extends Serenity.EntityDialog<AccReportTypeGroupOpeningBalanceRow, any> {
        protected getFormKey() { return AccReportTypeGroupOpeningBalanceForm.formKey; }
        protected getIdProperty() { return AccReportTypeGroupOpeningBalanceRow.idProperty; }
        protected getLocalTextPrefix() { return AccReportTypeGroupOpeningBalanceRow.localTextPrefix; }
        protected getService() { return AccReportTypeGroupOpeningBalanceService.baseUrl; }

        protected form = new AccReportTypeGroupOpeningBalanceForm(this.idPrefix);

    }
}