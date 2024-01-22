
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccVoucherDetailsGrid extends Serenity.EntityGrid<AccVoucherDetailsRow, any> {
        protected getColumnsKey() { return 'Transaction.AccVoucherDetails'; }
        protected getDialogType() { return AccVoucherDetailsDialog; }
        protected getIdProperty() { return AccVoucherDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherDetailsRow.localTextPrefix; }
        protected getService() { return AccVoucherDetailsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);

            //new Serenity.TreeGridMixin<AccVoucherDetailsRow>({
            //    grid: this,
            //    getParentId: x => x.Id,
            //    toggleField: AccVoucherDetailsRow.Fields.ChartofAccountsAccountName,
            //    initialCollapse: () => true
            //});


        }

        //protected usePager() {
        //    return false;
        //}
    }
}