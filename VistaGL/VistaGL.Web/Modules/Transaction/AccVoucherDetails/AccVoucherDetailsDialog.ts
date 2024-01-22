
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherDetailsDialog extends EntityDialogBase<AccVoucherDetailsRow, any> {
        protected getFormKey() { return AccVoucherDetailsForm.formKey; }
        protected getIdProperty() { return AccVoucherDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherDetailsRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherDetailsRow.nameProperty; }
        protected getService() { return AccVoucherDetailsService.baseUrl; }

        protected form = new AccVoucherDetailsForm(this.idPrefix);

        onDialogOpen(): void {
            super.onDialogOpen();
            q.initDetailEditor(this, this.form.VoucherDtlAllocation);

            this.form.VoucherDtlAllocation.parentDialog = this;

        }

    }
}