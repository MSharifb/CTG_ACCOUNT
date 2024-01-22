

namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class TransferDetailesEditor extends GridEditorBase<AccVoucherDetailsRow> {
        protected getColumnsKey() { return 'Transaction.TransferDetailes'; }
          protected getDialogType() { return null; }
        protected getLocalTextPrefix() { return AccVoucherDetailsRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);

        }


    }
}