
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherDtlBillRefEditor extends GridEditorBase<AccVoucherDtlBillRefRow> {
        protected getColumnsKey() { return 'Transaction.AccVoucherDtlBillRef'; }
        protected getDialogType() { return AccVoucherDtlBillRefEditorDialog; }
                protected getLocalTextPrefix() { return AccVoucherDtlBillRefRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}