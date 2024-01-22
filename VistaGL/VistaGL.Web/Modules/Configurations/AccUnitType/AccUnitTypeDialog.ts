
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccUnitTypeDialog extends Serenity.EntityDialog<AccUnitTypeRow, any> {
        protected getFormKey() { return AccUnitTypeForm.formKey; }
        protected getIdProperty() { return AccUnitTypeRow.idProperty; }
        protected getLocalTextPrefix() { return AccUnitTypeRow.localTextPrefix; }
        protected getNameProperty() { return AccUnitTypeRow.nameProperty; }
        protected getService() { return AccUnitTypeService.baseUrl; }

        protected form = new AccUnitTypeForm(this.idPrefix);

    }
}