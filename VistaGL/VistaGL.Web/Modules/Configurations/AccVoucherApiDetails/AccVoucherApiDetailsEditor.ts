

namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherApiDetailsEditor extends GridEditorBase<AccVoucherApiDetailsRow> {
        protected getColumnsKey() { return 'Configurations.AccVoucherApiDetails'; }
        protected getDialogType() { return AccVoucherApiDetailsEditorDialog; }
                protected getLocalTextPrefix() { return AccVoucherApiDetailsRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}