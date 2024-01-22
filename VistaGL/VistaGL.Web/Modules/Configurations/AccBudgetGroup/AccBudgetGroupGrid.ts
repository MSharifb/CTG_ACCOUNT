
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccBudgetGroupGrid extends EntityGridBase<AccBudgetGroupRow, any> {
        protected getColumnsKey() { return 'Configurations.AccBudgetGroup'; }
        protected getDialogType() { return AccBudgetGroupDialog; }
        protected getIdProperty() { return AccBudgetGroupRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetGroupRow.localTextPrefix; }
        protected getService() { return AccBudgetGroupService.baseUrl; }

        constructor(container: JQuery) {
            super(container);

            var tree = new Serenity.TreeGridMixin<AccBudgetGroupRow>({
                grid: this,
                getParentId: x => x.ParentId,
                toggleField: AccBudgetGroupRow.Fields.GroupName,
                initialCollapse: () => false
            });
        }
    }
}