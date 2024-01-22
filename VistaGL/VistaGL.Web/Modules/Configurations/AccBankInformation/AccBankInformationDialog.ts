
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccBankInformationDialog extends EntityDialogBase<AccBankInformationRow, any> {
        protected getFormKey() { return AccBankInformationForm.formKey; }
        protected getIdProperty() { return AccBankInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccBankInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccBankInformationRow.nameProperty; }
        protected getService() { return AccBankInformationService.baseUrl; }

        protected form = new AccBankInformationForm(this.idPrefix);

    }
}