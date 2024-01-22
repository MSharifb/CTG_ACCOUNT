
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccPartyPaymentGrid extends Serenity.EntityGrid<AccPartyPaymentRow, any> {
        protected getColumnsKey() { return 'Transaction.AccPartyPayment'; }
        protected getDialogType() { return AccPartyPaymentDialog; }
        protected getIdProperty() { return AccPartyPaymentRow.idProperty; }
        protected getLocalTextPrefix() { return AccPartyPaymentRow.localTextPrefix; }
        protected getService() { return AccPartyPaymentService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}