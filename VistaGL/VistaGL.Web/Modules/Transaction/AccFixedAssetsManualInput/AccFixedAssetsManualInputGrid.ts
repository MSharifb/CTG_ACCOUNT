
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccFixedAssetsManualInputGrid extends Serenity.EntityGrid<AccFixedAssetsManualInputRow, any> {
        protected getColumnsKey() { return 'Transaction.AccFixedAssetsManualInput'; }
        protected getDialogType() { return AccFixedAssetsManualInputDialog; }
        protected getIdProperty() { return AccFixedAssetsManualInputRow.idProperty; }
        protected getLocalTextPrefix() { return AccFixedAssetsManualInputRow.localTextPrefix; }
        protected getService() { return AccFixedAssetsManualInputService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}