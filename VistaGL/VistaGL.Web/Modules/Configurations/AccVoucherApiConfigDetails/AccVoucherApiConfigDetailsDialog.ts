
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherApiConfigDetailsDialog extends Serenity.EntityDialog<AccVoucherApiConfigDetailsRow, any> {
        protected getFormKey() { return AccVoucherApiConfigDetailsForm.formKey; }
        protected getIdProperty() { return AccVoucherApiConfigDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherApiConfigDetailsRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherApiConfigDetailsRow.nameProperty; }
        protected getService() { return AccVoucherApiConfigDetailsService.baseUrl; }

        protected form = new AccVoucherApiConfigDetailsForm(this.idPrefix);

    }
}