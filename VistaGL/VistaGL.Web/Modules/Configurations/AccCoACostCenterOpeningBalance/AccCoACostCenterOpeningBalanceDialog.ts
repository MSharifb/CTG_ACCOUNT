
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccCoACostCenterOpeningBalanceDialog extends Serenity.EntityDialog<AccCoACostCenterOpeningBalanceRow, any> {
        protected getFormKey() { return AccCoACostCenterOpeningBalanceForm.formKey; }
        protected getIdProperty() { return AccCoACostCenterOpeningBalanceRow.idProperty; }
        protected getLocalTextPrefix() { return AccCoACostCenterOpeningBalanceRow.localTextPrefix; }
        protected getService() { return AccCoACostCenterOpeningBalanceService.baseUrl; }

        protected form = new AccCoACostCenterOpeningBalanceForm(this.idPrefix);

    }
}