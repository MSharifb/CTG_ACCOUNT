
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccBudgetApprovalHistoryGrid extends EntityGridBase<AccBudgetApprovalHistoryRow, any> {
        protected getColumnsKey() { return 'Transaction.AccBudgetApprovalHistory'; }
        protected getDialogType() { return AccBudgetApprovalHistoryDialog; }
        protected getIdProperty() { return AccBudgetApprovalHistoryRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetApprovalHistoryRow.localTextPrefix; }
        protected getService() { return AccBudgetApprovalHistoryService.baseUrl; }

        BudgetForDepartmentId = 0;

        constructor(container: JQuery) {
            super(container);
            //$('.buttons-inner').hide();
        }

        loadByBudgetForDepartmentId(budgetForDeptId) {
            this.BudgetForDepartmentId = budgetForDeptId
            this.refresh();
        }

        protected getColumns() {
            return super.getColumns().filter(x => x.field != "inline-actions")
        }

        protected onViewSubmit() {

            if (!super.onViewSubmit()) {
                return false;
            }

            var request = this.view.params as Serenity.ListRequest;

            //if (this.BudgetForDepartmentId > 0)
                request.Criteria = Serenity.Criteria.and(request.Criteria,
                    [[AccBudgetApprovalHistoryRow.Fields.BudgetForDepartmentId], '=', this.BudgetForDepartmentId]);

            return true;
        }
        protected getButtons() {
            var buttons = super.getButtons();
            buttons.shift();
            return buttons;
        }

    }
}