
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccBankBranchInformationEditorDialog extends GridEditorDialog<AccBankBranchInformationRow> {
        protected getFormKey() { return AccBankBranchInformationForm.formKey; }
                protected getLocalTextPrefix() { return AccBankBranchInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccBankBranchInformationRow.nameProperty; }
     protected form = new AccBankBranchInformationForm(this.idPrefix);
    }
}