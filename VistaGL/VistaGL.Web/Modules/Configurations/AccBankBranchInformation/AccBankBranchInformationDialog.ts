
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccBankBranchInformationDialog extends EntityDialogBase<AccBankBranchInformationRow, any> {
        protected getFormKey() { return AccBankBranchInformationForm.formKey; }
        protected getIdProperty() { return AccBankBranchInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccBankBranchInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccBankBranchInformationRow.nameProperty; }
        protected getService() { return AccBankBranchInformationService.baseUrl; }

        protected form = new AccBankBranchInformationForm(this.idPrefix);

    }
}