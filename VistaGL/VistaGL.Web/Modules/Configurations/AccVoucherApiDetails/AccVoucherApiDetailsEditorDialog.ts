
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherApiDetailsEditorDialog extends GridEditorDialog<AccVoucherApiDetailsRow> {
        protected getFormKey() { return AccVoucherApiDetailsForm.formKey; }
                protected getLocalTextPrefix() { return AccVoucherApiDetailsRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherApiDetailsRow.nameProperty; }
        protected form = new AccVoucherApiDetailsForm(this.idPrefix);
    }
}