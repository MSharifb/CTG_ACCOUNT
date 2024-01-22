namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherApiConfigDetailsEditor extends GridEditorBase<AccVoucherApiConfigDetailsRow> {
        protected getColumnsKey() { return 'Configurations.AccVoucherApiConfigDetails'; }
        protected getDialogType() { return AccVoucherApiConfigDetailsEditorDialog; }
                protected getLocalTextPrefix() { return AccVoucherApiConfigDetailsRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}