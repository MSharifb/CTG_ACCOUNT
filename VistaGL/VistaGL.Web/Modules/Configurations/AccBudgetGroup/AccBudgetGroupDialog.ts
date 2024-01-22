
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccBudgetGroupDialog extends Serenity.EntityDialog<AccBudgetGroupRow, any> {
        protected getFormKey() { return AccBudgetGroupForm.formKey; }
        protected getIdProperty() { return AccBudgetGroupRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetGroupRow.localTextPrefix; }
        protected getNameProperty() { return AccBudgetGroupRow.nameProperty; }
        protected getService() { return AccBudgetGroupService.baseUrl; }

        protected form = new AccBudgetGroupForm(this.idPrefix);

    }
}