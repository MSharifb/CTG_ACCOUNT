
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccNoaGrid extends EntityGridBase<AccNoaRow, any> {
        protected getColumnsKey() { return 'Transaction.AccNoa'; }
        protected getDialogType() { return AccNoaDialog; }
        protected getIdProperty() { return AccNoaRow.idProperty; }
        protected getLocalTextPrefix() { return AccNoaRow.localTextPrefix; }
        protected getService() { return AccNoaService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}