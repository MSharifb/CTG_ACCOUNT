
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccBudgetForDepartmentGrid extends Serenity.EntityGrid<AccBudgetForDepartmentRow, any> {
        protected getColumnsKey() { return 'Transaction.AccBudgetForDepartment'; }
        protected getDialogType() { return AccBudgetForDepartmentDialog; }
        protected getIdProperty() { return AccBudgetForDepartmentRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetForDepartmentRow.localTextPrefix; }
        protected getService() { return AccBudgetForDepartmentService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}