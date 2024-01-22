
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherApiConfigEditorDialog extends GridEditorDialog<AccVoucherApiConfigRow> {
        protected getFormKey() { return AccVoucherApiConfigForm.formKey; }
                protected getLocalTextPrefix() { return AccVoucherApiConfigRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherApiConfigRow.nameProperty; }
        protected form = new AccVoucherApiConfigForm(this.idPrefix);
    }
}