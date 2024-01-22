
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccBankReconciliationDirectDialog extends EntityDialogBase<AccBankReconciliationDirectRow, any> {
        protected getFormKey() { return AccBankReconciliationDirectForm.formKey; }
        protected getIdProperty() { return AccBankReconciliationDirectRow.idProperty; }
        protected getLocalTextPrefix() { return AccBankReconciliationDirectRow.localTextPrefix; }
        protected getNameProperty() { return AccBankReconciliationDirectRow.nameProperty; }
        protected getService() { return AccBankReconciliationDirectService.baseUrl; }

        protected form = new AccBankReconciliationDirectForm(this.idPrefix);
        constructor() {
            super();
        }
        protected onDialogOpen() {
            super.onDialogOpen();

            this.form.FundControlInformationId.element.hide();
        }
    }
}