
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccBudgetForDepartmentDetailGrid extends Serenity.EntityGrid<AccBudgetForDepartmentDetailRow, any> {
        protected getColumnsKey() { return 'Transaction.AccBudgetForDepartmentDetail'; }
        protected getDialogType() { return AccBudgetForDepartmentDetailDialog; }
        protected getIdProperty() { return AccBudgetForDepartmentDetailRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetForDepartmentDetailRow.localTextPrefix; }
        protected getService() { return AccBudgetForDepartmentDetailService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}