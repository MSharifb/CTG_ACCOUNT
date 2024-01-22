
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccBankAccountInformationGrid extends EntityGridBase<AccBankAccountInformationRow, any> {
        protected getColumnsKey() { return 'Configurations.AccBankAccountInformation'; }
        protected getDialogType() { return AccBankAccountInformationDialog; }
        protected getIdProperty() { return AccBankAccountInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccBankAccountInformationRow.localTextPrefix; }
        protected getService() { return AccBankAccountInformationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}