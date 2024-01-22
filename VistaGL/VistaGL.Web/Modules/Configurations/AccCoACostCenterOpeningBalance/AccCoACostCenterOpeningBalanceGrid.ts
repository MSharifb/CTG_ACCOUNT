
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccCoACostCenterOpeningBalanceGrid extends EntityGridBase<AccCoACostCenterOpeningBalanceRow, any> {
        protected getColumnsKey() { return 'Configurations.AccCoACostCenterOpeningBalance'; }
        protected getDialogType() { return AccCoACostCenterOpeningBalanceDialog; }
        protected getIdProperty() { return AccCoACostCenterOpeningBalanceRow.idProperty; }
        protected getLocalTextPrefix() { return AccCoACostCenterOpeningBalanceRow.localTextPrefix; }
        protected getService() { return AccCoACostCenterOpeningBalanceService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

    }
}