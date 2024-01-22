
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccBudgetApprovalHistoryDialog extends Serenity.EntityDialog<AccBudgetApprovalHistoryRow, any> {
        protected getFormKey() { return AccBudgetApprovalHistoryForm.formKey; }
        protected getIdProperty() { return AccBudgetApprovalHistoryRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetApprovalHistoryRow.localTextPrefix; }
        protected getService() { return AccBudgetApprovalHistoryService.baseUrl; }

        protected form = new AccBudgetApprovalHistoryForm(this.idPrefix);

    }
}