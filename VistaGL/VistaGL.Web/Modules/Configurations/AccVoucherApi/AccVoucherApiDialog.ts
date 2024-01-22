
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherApiDialog extends Serenity.EntityDialog<AccVoucherApiRow, any> {
        protected getFormKey() { return AccVoucherApiForm.formKey; }
        protected getIdProperty() { return AccVoucherApiRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherApiRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherApiRow.nameProperty; }
        protected getService() { return AccVoucherApiService.baseUrl; }

        protected form = new AccVoucherApiForm(this.idPrefix);

    }
}