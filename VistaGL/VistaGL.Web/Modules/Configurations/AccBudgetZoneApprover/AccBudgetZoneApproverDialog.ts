
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccBudgetZoneApproverDialog extends Serenity.EntityDialog<AccBudgetZoneApproverRow, any> {
        protected getFormKey() { return AccBudgetZoneApproverForm.formKey; }
        protected getIdProperty() { return AccBudgetZoneApproverRow.idProperty; }
        protected getLocalTextPrefix() { return AccBudgetZoneApproverRow.localTextPrefix; }
        protected getService() { return AccBudgetZoneApproverService.baseUrl; }

        protected form = new AccBudgetZoneApproverForm(this.idPrefix);

    }
}