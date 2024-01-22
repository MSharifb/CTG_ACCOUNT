
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherDtlAllocationDialog extends Serenity.EntityDialog<AccVoucherDtlAllocationRow, any> {
        protected getFormKey() { return AccVoucherDtlAllocationForm.formKey; }
        protected getIdProperty() { return AccVoucherDtlAllocationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherDtlAllocationRow.localTextPrefix; }
        protected getService() { return AccVoucherDtlAllocationService.baseUrl; }

        protected form = new AccVoucherDtlAllocationForm(this.idPrefix);

    }
}