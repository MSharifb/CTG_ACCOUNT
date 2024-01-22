
namespace VistaGL.Transaction {
    
    @Serenity.Decorators.registerClass()
    export class AccChequeReceiveRegisterGrid extends EntityGridBase<AccChequeReceiveRegisterRow, any> {
        protected getColumnsKey() { return 'Transaction.AccChequeReceiveRegister'; }
        protected getDialogType() { return AccChequeReceiveRegisterDialog; }
        protected getIdProperty() { return AccChequeReceiveRegisterRow.idProperty; }
        protected getLocalTextPrefix() { return AccChequeReceiveRegisterRow.localTextPrefix; }
        protected getService() { return AccChequeReceiveRegisterService.baseUrl; }

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