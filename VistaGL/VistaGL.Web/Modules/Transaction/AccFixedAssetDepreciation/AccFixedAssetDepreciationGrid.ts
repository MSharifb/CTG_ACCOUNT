
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccFixedAssetDepreciationGrid extends Serenity.EntityGrid<AccFixedAssetDepreciationRow, any> {
        protected getColumnsKey() { return 'Transaction.AccFixedAssetDepreciation'; }
        protected getDialogType() { return AccFixedAssetDepreciationDialog; }
        protected getIdProperty() { return AccFixedAssetDepreciationRow.idProperty; }
        protected getLocalTextPrefix() { return AccFixedAssetDepreciationRow.localTextPrefix; }
        protected getService() { return AccFixedAssetDepreciationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}