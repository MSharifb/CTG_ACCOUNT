
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccTransactionTypeAssignGrid extends Serenity.EntityGrid<AccTransactionTypeAssignRow, any> {
        protected getColumnsKey() { return 'Transaction.AccTransactionTypeAssign'; }
        protected getDialogType() { return AccTransactionTypeAssignDialog; }
        protected getIdProperty() { return AccTransactionTypeAssignRow.idProperty; }
        protected getLocalTextPrefix() { return AccTransactionTypeAssignRow.localTextPrefix; }
        protected getService() { return AccTransactionTypeAssignService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}