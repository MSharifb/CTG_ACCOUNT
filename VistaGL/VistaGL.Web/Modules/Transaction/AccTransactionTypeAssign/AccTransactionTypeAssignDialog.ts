
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccTransactionTypeAssignDialog extends Serenity.EntityDialog<AccTransactionTypeAssignRow, any> {
        protected getFormKey() { return AccTransactionTypeAssignForm.formKey; }
        protected getIdProperty() { return AccTransactionTypeAssignRow.idProperty; }
        protected getLocalTextPrefix() { return AccTransactionTypeAssignRow.localTextPrefix; }
        protected getNameProperty() { return AccTransactionTypeAssignRow.nameProperty; }
        protected getService() { return AccTransactionTypeAssignService.baseUrl; }

        protected form = new AccTransactionTypeAssignForm(this.idPrefix);

    }
}