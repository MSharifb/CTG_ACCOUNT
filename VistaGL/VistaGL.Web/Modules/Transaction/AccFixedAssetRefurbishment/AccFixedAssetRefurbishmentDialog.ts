
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccFixedAssetRefurbishmentDialog extends EntityDialogBase<AccFixedAssetRefurbishmentRow, any> {
        protected getFormKey() { return AccFixedAssetRefurbishmentForm.formKey; }
        protected getIdProperty() { return AccFixedAssetRefurbishmentRow.idProperty; }
        protected getLocalTextPrefix() { return AccFixedAssetRefurbishmentRow.localTextPrefix; }
        protected getService() { return AccFixedAssetRefurbishmentService.baseUrl; }

        protected form = new AccFixedAssetRefurbishmentForm(this.idPrefix);

    }
}