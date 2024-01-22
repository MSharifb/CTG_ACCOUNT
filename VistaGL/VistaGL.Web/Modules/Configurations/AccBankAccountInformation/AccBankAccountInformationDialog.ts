
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccBankAccountInformationDialog extends Serenity.EntityDialog<AccBankAccountInformationRow, any> {
        protected getFormKey() { return AccBankAccountInformationForm.formKey; }
        protected getIdProperty() { return AccBankAccountInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccBankAccountInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccBankAccountInformationRow.nameProperty; }
        protected getService() { return AccBankAccountInformationService.baseUrl; }

        protected form = new AccBankAccountInformationForm(this.idPrefix);

        validateBeforeSave(): boolean {

            if (!this.validateForm())
                return false;

            super.validateBeforeSave();

            var isValid = true;

            if (this.isNew()) {
                var data = AccBankAccountInformationRow.getLookup().items
                    .filter(f => f.CoaId == +this.form.CoaId.value);
                data.forEach(d => {
                    Q.alert("Sorry! Selected account head is already used for another bank-branch.");
                    isValid =  false;
                });
            } else {
                var data = AccBankAccountInformationRow.getLookup().items
                    .filter(f => f.CoaId == +this.form.CoaId.value && f.Id != this.form.Id.value);
                data.forEach(d => {
                    Q.alert("Sorry! Selected account head is already used for another bank-branch..");
                    isValid = false;
                });
            }

            return isValid;
        }

    }
}