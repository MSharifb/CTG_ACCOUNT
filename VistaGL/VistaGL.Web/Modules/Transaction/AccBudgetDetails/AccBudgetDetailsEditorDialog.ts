
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccBudgetDetailsEditorDialog extends GridEditorDialog<AccBudgetDetailsRow> {
        protected getFormKey() { return AccBudgetDetailsForm.formKey; }
        protected getLocalTextPrefix() { return AccBudgetDetailsRow.localTextPrefix; }
        protected getNameProperty() { return AccBudgetDetailsRow.nameProperty; }
        protected form = new AccBudgetDetailsForm(this.idPrefix);

        protected budgetHeadList: AccBudgetDetailsRow[];
        public items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        public items_CostCenter: AccCostCentreOrInstituteInformationRow[];

        protected onDialogOpen() {
            super.onDialogOpen();

            this.form.BudgetHeadId.changeSelect2(p => {
                console.log(this.form.BudgetHeadId.value);
                this.budgetHeadList = Q.getLookup("Transaction.AccBudgetHeads_Lookup").items;
                var budgetDetail = this.budgetHeadList.filter(x => x.BudgetHeadId == +this.form.BudgetHeadId.value)[0];

                this.form.BudgetHeadId.value = String(budgetDetail.BudgetHeadId);
                this.form.IsCoa.value = budgetDetail.IsCoa;
                this.form.IsCostCenter.value = budgetDetail.IsCostCenter;
                this.form.IsBudgetHead.value = budgetDetail.IsBudgetHead;
                this.form.BudgetCode.value = budgetDetail.BudgetCode;
                this.form.BgSortOrder.value = budgetDetail.BgSortOrder;
                this.form.ParentId.value = budgetDetail.ParentId;
                if (budgetDetail.IsCoa) {
                    this.items_ChartofAccounts = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;
                    let groupId = this.items_ChartofAccounts.filter(x => x.Id == budgetDetail.BudgetHeadId)[0].BudgetGroupId;
                    this.form.BudgetGroupId.value = groupId;
                }
                else {
                    this.items_CostCenter = Q.getLookup('Transaction.AccCostCentreOrInstituteInformation_Lookup').items;
                    let groupId = this.items_CostCenter.filter(x => x.Id == budgetDetail.BudgetHeadId)[0].BudgetGroupId;
                    this.form.BudgetGroupId.value = groupId;
                }

            });

        }
    }
}