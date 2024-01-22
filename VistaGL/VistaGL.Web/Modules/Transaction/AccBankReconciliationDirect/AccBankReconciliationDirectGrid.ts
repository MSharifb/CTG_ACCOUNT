
namespace VistaGL.Transaction {
    import fld = AccBankReconciliationDirectRow.Fields;
    @Serenity.Decorators.registerClass()
    export class AccBankReconciliationDirectGrid extends EntityGridBase<AccBankReconciliationDirectRow, any> {
        protected getColumnsKey() { return 'Transaction.AccBankReconciliationDirect'; }
        protected getDialogType() { return AccBankReconciliationDirectDialog; }
        protected getIdProperty() { return AccBankReconciliationDirectRow.idProperty; }
        protected getLocalTextPrefix() { return AccBankReconciliationDirectRow.localTextPrefix; }
        protected getService() { return AccBankReconciliationDirectService.baseUrl; }

        //private rowSelection: Serenity.GridRowSelectionMixin;

        constructor(container: JQuery) {
            super(container);
        }

        //usePager(): boolean { return false; }

        //protected createToolbarExtensions() {
        //    super.createToolbarExtensions();
        //    this.rowSelection = new Serenity.GridRowSelectionMixin(this);
        //}

        //protected getButtons() {
        //    var b = super.getButtons();
        //    b.shift();

        //    b.push({
        //        title: 'Perform Voucher Posting',
        //        cssClass: 'send-button',
        //        onClick: () => {
        //            if (!this.onViewSubmit()) {
        //                return;
        //            }

        //            var action = new BankReconciliationBulkAction();
        //            action.done = () => this.rowSelection.resetCheckedAndRefresh();
        //            action.execute(this.rowSelection.getSelectedKeys());
        //        }
        //    });
        //    return b;
        //}

        //protected getColumns() {
        //    var columns = super.getColumns();
        //    columns.splice(0, 0, Serenity.GridRowSelectionMixin.createSelectColumn(() => this.rowSelection));
        //    return columns;
        //}

        //protected getViewOptions() {
        //    var opt = super.getViewOptions();
        //    opt.rowsPerPage = 100;
        //    return opt;
        //}


        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            let filters = super.getQuickFilters();

            Q.first(filters, x => x.field == fld.IsBankReconcile).init = w => {
                (w as TrueFalseEditor).value = "false";
            };

            // --
            let filterByChequeNo = Q.tryFirst(filters, x => x.field == fld.ChequeNo);
            if (filterByChequeNo != null) {
                filterByChequeNo.title = "Cheque No..";
                filterByChequeNo.type = Serenity.StringEditor;
                filterByChequeNo.handler = h => {
                    if (h.active) {
                        h.request.Criteria = Serenity.Criteria.and(h.request.Criteria,
                            [[fld.ChequeNo], 'like', '%' + h.value + '%']);
                    }
                };
            }

            return filters;
        }

        getSlickOptions(): Slick.GridOptions {
            //
            let opt = super.getSlickOptions();

            opt.enableTextSelectionOnCells = true;
            opt.selectedCellCssClass = "slick-row-selected";
            opt.enableCellNavigation = true;

            return opt;
        }
    }
}