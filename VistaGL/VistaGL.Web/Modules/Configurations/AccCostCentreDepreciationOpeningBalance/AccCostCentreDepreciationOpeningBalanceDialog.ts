
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccCostCentreDepreciationOpeningBalanceDialog extends Serenity.EntityDialog<AccCostCentreDepreciationOpeningBalanceRow, any> {
        protected getFormKey() { return AccCostCentreDepreciationOpeningBalanceForm.formKey; }
        protected getIdProperty() { return AccCostCentreDepreciationOpeningBalanceRow.idProperty; }
        protected getLocalTextPrefix() { return AccCostCentreDepreciationOpeningBalanceRow.localTextPrefix; }
        protected getService() { return AccCostCentreDepreciationOpeningBalanceService.baseUrl; }

        protected form = new AccCostCentreDepreciationOpeningBalanceForm(this.idPrefix);

    }
}