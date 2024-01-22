
namespace VistaGL.Transaction{

    @Serenity.Decorators.registerClass()
    export class BudgetCreationApprovalDialog extends Serenity.EntityDialog<AccBudgetForDepartmentRow, any> {
        protected getFormKey() { return BudgetCreationApprovalForm.formKey; }
        protected getIdProperty() { return AccBudgetForDepartmentRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetForDepartmentRow.localTextPrefix; }
        protected getService() { return BudgetCreationApprovalService.baseUrl; }

        protected form = new BudgetCreationApprovalForm(this.idPrefix);

    }
}