
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccFinancialReportsDetailsDialog extends EntityDialogBase<AccFinancialReportsDetailsRow, any> {
        protected getFormKey() { return AccFinancialReportsDetailsForm.formKey; }
        protected getIdProperty() { return AccFinancialReportsDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccFinancialReportsDetailsRow.localTextPrefix; }
        protected getService() { return AccFinancialReportsDetailsService.baseUrl; }

        protected form = new AccFinancialReportsDetailsForm(this.idPrefix);

    }
}