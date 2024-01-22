
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccCostCenterTypeDialog extends EntityDialogBase<AccCostCenterTypeRow, any> {
        protected getFormKey() { return AccCostCenterTypeForm.formKey; }
        protected getIdProperty() { return AccCostCenterTypeRow.idProperty; }
        protected getLocalTextPrefix() { return AccCostCenterTypeRow.localTextPrefix; }
        protected getNameProperty() { return AccCostCenterTypeRow.nameProperty; }
        protected getService() { return AccCostCenterTypeService.baseUrl; }

        protected form = new AccCostCenterTypeForm(this.idPrefix);

    }
}