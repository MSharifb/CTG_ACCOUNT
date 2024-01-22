
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherTypeDialog extends EntityDialogBase<AccVoucherTypeRow, any> {
        protected getFormKey() { return AccVoucherTypeForm.formKey; }
        protected getIdProperty() { return AccVoucherTypeRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherTypeRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherTypeRow.nameProperty; }
        protected getService() { return AccVoucherTypeService.baseUrl; }

        protected form = new AccVoucherTypeForm(this.idPrefix);

    }
}