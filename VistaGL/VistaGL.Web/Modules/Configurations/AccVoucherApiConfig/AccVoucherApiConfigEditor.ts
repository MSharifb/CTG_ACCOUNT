
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherApiConfigEditor extends GridEditorBase<AccVoucherApiConfigRow> {
        protected getColumnsKey() { return 'Configurations.AccVoucherApiConfig'; }
        protected getDialogType() { return AccVoucherApiConfigEditorDialog; }
                protected getLocalTextPrefix() { return AccVoucherApiConfigRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}