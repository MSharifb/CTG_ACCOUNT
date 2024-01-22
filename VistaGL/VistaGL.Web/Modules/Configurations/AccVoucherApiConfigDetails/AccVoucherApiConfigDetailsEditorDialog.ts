

namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherApiConfigDetailsEditorDialog extends GridEditorDialog<AccVoucherApiConfigDetailsRow> {
        protected getFormKey() { return AccVoucherApiConfigDetailsForm.formKey; }
                protected getLocalTextPrefix() { return AccVoucherApiConfigDetailsRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherApiConfigDetailsRow.nameProperty; }
        protected form = new AccVoucherApiConfigDetailsForm(this.idPrefix);
    }
}