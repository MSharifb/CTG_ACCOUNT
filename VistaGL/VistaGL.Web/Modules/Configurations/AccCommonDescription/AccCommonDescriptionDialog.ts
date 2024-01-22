
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccCommonDescriptionDialog extends EntityDialogBase<AccCommonDescriptionRow, any> {
        protected getFormKey() { return AccCommonDescriptionForm.formKey; }
        protected getIdProperty() { return AccCommonDescriptionRow.idProperty; }
        protected getLocalTextPrefix() { return AccCommonDescriptionRow.localTextPrefix; }
        protected getNameProperty() { return AccCommonDescriptionRow.nameProperty; }
        protected getService() { return AccCommonDescriptionService.baseUrl; }

        protected form = new AccCommonDescriptionForm(this.idPrefix);

    }
}