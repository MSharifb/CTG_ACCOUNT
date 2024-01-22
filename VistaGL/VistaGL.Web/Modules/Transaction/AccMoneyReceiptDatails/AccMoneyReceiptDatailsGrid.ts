
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccMoneyReceiptDatailsGrid extends Serenity.EntityGrid<AccMoneyReceiptDatailsRow, any> {
        protected getColumnsKey() { return 'Transaction.AccMoneyReceiptDatails'; }
        protected getDialogType() { return AccMoneyReceiptDatailsDialog; }
        protected getIdProperty() { return AccMoneyReceiptDatailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccMoneyReceiptDatailsRow.localTextPrefix; }
        protected getService() { return AccMoneyReceiptDatailsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}