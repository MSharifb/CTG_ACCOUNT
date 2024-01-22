
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherApiDetailsDialog extends Serenity.EntityDialog<AccVoucherApiDetailsRow, any> {
        protected getFormKey() { return AccVoucherApiDetailsForm.formKey; }
        protected getIdProperty() { return AccVoucherApiDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherApiDetailsRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherApiDetailsRow.nameProperty; }
        protected getService() { return AccVoucherApiDetailsService.baseUrl; }

        protected form = new AccVoucherApiDetailsForm(this.idPrefix);

    }
}