
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccFixedAssetsManualInputDialog extends Serenity.EntityDialog<AccFixedAssetsManualInputRow, any> {
        protected getFormKey() { return AccFixedAssetsManualInputForm.formKey; }
        protected getIdProperty() { return AccFixedAssetsManualInputRow.idProperty; }
        protected getLocalTextPrefix() { return AccFixedAssetsManualInputRow.localTextPrefix; }
        protected getService() { return AccFixedAssetsManualInputService.baseUrl; }

        protected form = new AccFixedAssetsManualInputForm(this.idPrefix);

    }
}