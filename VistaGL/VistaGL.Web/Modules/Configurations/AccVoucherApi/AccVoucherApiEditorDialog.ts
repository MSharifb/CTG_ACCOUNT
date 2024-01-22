
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherApiEditorDialog extends GridEditorDialog<AccVoucherApiRow> {
        protected getFormKey() { return AccVoucherApiForm.formKey; }
                protected getLocalTextPrefix() { return AccVoucherApiRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherApiRow.nameProperty; }
        protected form = new AccVoucherApiForm(this.idPrefix);
    }
}