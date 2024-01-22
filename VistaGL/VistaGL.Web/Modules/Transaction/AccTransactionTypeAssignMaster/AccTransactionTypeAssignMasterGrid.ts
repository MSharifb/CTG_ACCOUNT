
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccTransactionTypeAssignMasterGrid extends EntityGridBase<AccTransactionTypeAssignMasterRow, any> {
        protected getColumnsKey() { return 'Transaction.AccTransactionTypeAssignMaster'; }
        protected getDialogType() { return AccTransactionTypeAssignMasterDialog; }
        protected getIdProperty() { return AccTransactionTypeAssignMasterRow.idProperty; }
        protected getLocalTextPrefix() { return AccTransactionTypeAssignMasterRow.localTextPrefix; }
        protected getService() { return AccTransactionTypeAssignMasterService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}