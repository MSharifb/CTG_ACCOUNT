
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherDtlBillRefDialog extends Serenity.EntityDialog<AccVoucherDtlBillRefRow, any> {
        protected getFormKey() { return AccVoucherDtlBillRefForm.formKey; }
        protected getIdProperty() { return AccVoucherDtlBillRefRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherDtlBillRefRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherDtlBillRefRow.nameProperty; }
        protected getService() { return AccVoucherDtlBillRefService.baseUrl; }

        protected form = new AccVoucherDtlBillRefForm(this.idPrefix);

    }
}