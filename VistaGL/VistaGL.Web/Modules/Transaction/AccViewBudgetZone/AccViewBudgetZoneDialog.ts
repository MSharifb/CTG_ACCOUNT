
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccViewBudgetZoneDialog extends Serenity.EntityDialog<AccViewBudgetZoneRow, any> {
        protected getFormKey() { return AccViewBudgetZoneForm.formKey; }
        protected getLocalTextPrefix() { return AccViewBudgetZoneRow.localTextPrefix; }
        protected getNameProperty() { return AccViewBudgetZoneRow.nameProperty; }
        protected getService() { return AccViewBudgetZoneService.baseUrl; }

        protected form = new AccViewBudgetZoneForm(this.idPrefix);

    }
}