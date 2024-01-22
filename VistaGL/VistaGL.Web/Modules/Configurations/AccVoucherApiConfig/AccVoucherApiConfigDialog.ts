
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherApiConfigDialog extends Serenity.EntityDialog<AccVoucherApiConfigRow, any> {
        protected getFormKey() { return AccVoucherApiConfigForm.formKey; }
        protected getIdProperty() { return AccVoucherApiConfigRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherApiConfigRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherApiConfigRow.nameProperty; }
        protected getService() { return AccVoucherApiConfigService.baseUrl; }

        protected form = new AccVoucherApiConfigForm(this.idPrefix);

    }
}