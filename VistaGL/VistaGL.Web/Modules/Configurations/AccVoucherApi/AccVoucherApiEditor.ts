
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherApiEditor extends GridEditorBase<AccVoucherApiRow> {
        protected getColumnsKey() { return 'Configurations.AccVoucherApi'; }
        protected getDialogType() { return AccVoucherApiEditorDialog; }
                protected getLocalTextPrefix() { return AccVoucherApiRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}