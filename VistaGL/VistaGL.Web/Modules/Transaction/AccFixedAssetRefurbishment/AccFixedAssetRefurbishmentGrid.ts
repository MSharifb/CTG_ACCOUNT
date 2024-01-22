
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccFixedAssetRefurbishmentGrid extends EntityGridBaseNew<AccFixedAssetRefurbishmentRow, any> {
        protected getColumnsKey() { return 'Transaction.AccFixedAssetRefurbishment'; }
        protected getDialogType() { return AccFixedAssetRefurbishmentDialog; }
        protected getIdProperty() { return AccFixedAssetRefurbishmentRow.idProperty; }
        protected getLocalTextPrefix() { return AccFixedAssetRefurbishmentRow.localTextPrefix; }
        protected getService() { return AccFixedAssetRefurbishmentService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}