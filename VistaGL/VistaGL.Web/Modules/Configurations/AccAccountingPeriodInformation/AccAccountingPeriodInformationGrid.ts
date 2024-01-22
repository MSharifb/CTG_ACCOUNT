
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccAccountingPeriodInformationGrid extends EntityGridBase<AccAccountingPeriodInformationRow, any> {
        protected getColumnsKey() { return 'Configurations.AccAccountingPeriodInformation'; }
        protected getDialogType() { return AccAccountingPeriodInformationDialog; }
        protected getIdProperty() { return AccAccountingPeriodInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccAccountingPeriodInformationRow.localTextPrefix; }
        protected getService() { return AccAccountingPeriodInformationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}