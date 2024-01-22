
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccBudgetForDepartmentDetailDialog extends Serenity.EntityDialog<AccBudgetForDepartmentDetailRow, any> {
        protected getFormKey() { return AccBudgetForDepartmentDetailForm.formKey; }
        protected getIdProperty() { return AccBudgetForDepartmentDetailRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetForDepartmentDetailRow.localTextPrefix; }
        protected getService() { return AccBudgetForDepartmentDetailService.baseUrl; }

        protected form = new AccBudgetForDepartmentDetailForm(this.idPrefix);

    }
}