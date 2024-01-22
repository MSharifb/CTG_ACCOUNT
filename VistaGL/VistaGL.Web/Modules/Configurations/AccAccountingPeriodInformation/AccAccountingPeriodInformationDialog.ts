
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccAccountingPeriodInformationDialog extends EntityDialogBase<AccAccountingPeriodInformationRow, any> {
        protected getFormKey() { return AccAccountingPeriodInformationForm.formKey; }
        protected getIdProperty() { return AccAccountingPeriodInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccAccountingPeriodInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccAccountingPeriodInformationRow.nameProperty; }
        protected getService() { return AccAccountingPeriodInformationService.baseUrl; }

        protected form = new AccAccountingPeriodInformationForm(this.idPrefix);

        constructor() {
            super(); 

            this.form.IsActive.changeSelect2(e => {
                if (this.form.IsActive.value) {
                    this.form.IsClosed.value = false;
                }
            });

            this.form.IsClosed.changeSelect2(e => {
                if (this.form.IsClosed.value) {
                    this.form.IsActive.value = false;
                }
            });
        }

    }
}