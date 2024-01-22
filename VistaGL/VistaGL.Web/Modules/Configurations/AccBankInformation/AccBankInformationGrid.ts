
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccBankInformationGrid extends EntityGridBaseNew<AccBankInformationRow, any> {
        protected getColumnsKey() { return 'Configurations.AccBankInformation'; }
        protected getDialogType() { return AccBankInformationDialog; }
        protected getIdProperty() { return AccBankInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccBankInformationRow.localTextPrefix; }
        protected getService() { return AccBankInformationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}