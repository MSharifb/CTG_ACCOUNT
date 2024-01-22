
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherDtlBillRefEditorDialog extends GridEditorDialog<AccVoucherDtlBillRefRow> {
        protected getFormKey() { return AccVoucherDtlBillRefForm.formKey; }
                protected getLocalTextPrefix() { return AccVoucherDtlBillRefRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherDtlBillRefRow.nameProperty; }
        protected form = new AccVoucherDtlBillRefForm(this.idPrefix);

    
    }
}