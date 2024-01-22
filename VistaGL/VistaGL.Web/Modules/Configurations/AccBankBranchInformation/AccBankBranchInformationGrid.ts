
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccBankBranchInformationGrid extends Serenity.EntityGrid<AccBankBranchInformationRow, any> {
        protected getColumnsKey() { return 'Configurations.AccBankBranchInformation'; }
        protected getDialogType() { return AccBankBranchInformationDialog; }
        protected getIdProperty() { return AccBankBranchInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccBankBranchInformationRow.localTextPrefix; }
        protected getService() { return AccBankBranchInformationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}