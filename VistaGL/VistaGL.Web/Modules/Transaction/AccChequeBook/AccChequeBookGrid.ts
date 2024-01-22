
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccChequeBookGrid extends EntityGridBaseNew<AccChequeBookRow, any> {
        protected getColumnsKey() { return 'Transaction.AccChequeBook'; }
        protected getDialogType() { return AccChequeBookDialog; }
        protected getIdProperty() { return AccChequeBookRow.idProperty; }
        protected getLocalTextPrefix() { return AccChequeBookRow.localTextPrefix; }
        protected getService() { return AccChequeBookService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getViewOptions() {
            var opt = super.getViewOptions();
            opt.rowsPerPage = 20;
            return opt;
        }
    }
}