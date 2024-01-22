

namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccBankBranchInformationEditor extends GridEditorBase<AccBankBranchInformationRow> {
        protected getColumnsKey() { return 'Configurations.AccBankBranchInformation'; }
        protected getDialogType() { return AccBankBranchInformationEditorDialog; }
                protected getLocalTextPrefix() { return AccBankBranchInformationRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}