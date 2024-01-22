
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccFundControlInformationGrid extends EntityGridBase<AccFundControlInformationRow, any> {
        protected getColumnsKey() { return 'Configurations.AccFundControlInformation'; }
        protected getDialogType() { return AccFundControlInformationDialog; }
        protected getIdProperty() { return AccFundControlInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccFundControlInformationRow.localTextPrefix; }
        protected getService() { return AccFundControlInformationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}