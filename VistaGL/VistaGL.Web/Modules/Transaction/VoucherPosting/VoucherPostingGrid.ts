
namespace VistaGL.Transaction {

    import fld = AccVoucherInformationRow.Fields;

    @Serenity.Decorators.registerClass()
    export class VoucherPostingGrid extends EntityGridBaseNew<AccVoucherInformationRow, any> {
        protected getColumnsKey() { return 'Transaction.VoucherPosting'; }
        protected getIdProperty() { return AccVoucherInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherInformationRow.localTextPrefix; }
        protected getService() { return VoucherPostingService.baseUrl; }

        private rowSelection: Serenity.GridRowSelectionMixin;

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Voucher Posting");
        }

        protected createToolbarExtensions() {
            super.createToolbarExtensions();
            this.rowSelection = new Serenity.GridRowSelectionMixin(this);
        }

        protected getButtons() {
            var b = super.getButtons();
            b.shift();

            b.push({
                title: 'Perform Voucher Posting',
                cssClass: 'send-button',
                onClick: () => {
                    if (!this.onViewSubmit()) {
                        return;
                    }
                    //console.log(this.rowSelection);
                    var action = new VoucherPostingBulkAction();
                    action.done = () => this.rowSelection.resetCheckedAndRefresh();
                    action.execute(this.rowSelection.getSelectedKeys());
                }
            });
            return b;
        }

        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.frozenColumn = 5;

            return opt;
        }

        protected getColumns() {
            var columns = super.getColumns();

            columns.splice(0, 0, Serenity.GridRowSelectionMixin.createSelectColumn(() => this.rowSelection));

            columns.splice(1, 0, {
                field: 'Print Voucher',
                name: '',
                format: ctx => '<a class="inline-action Print-link" title="Print Voucher">' +
                    '<i class="fa fa-print text-blue"></i></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });

            //columns.splice(Q.indexOf(columns, x => x.name == "Voucher No"), 0, {
            //    field: 'View',
            //    name: '',
            //    format: ctx => '<a href="javascript:;" class="view-action" title="View">' +
            //        '<i class="fa fa-eye" aria-hidden="true"></i></a>',
            //    width: 24,
            //    minWidth: 24,
            //    maxWidth: 24
            //});

            return columns;
        }

        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string {
            let klass: string = "";

            if (item.LinkedWithAutoJV) {
                klass += " backColorForLinkedWithAutoJV";
            }

            return Q.trimToNull(klass);
        }

        protected getViewOptions() {
            var opt = super.getViewOptions();
            opt.rowsPerPage = 2500;
            return opt;
        }

        protected onViewSubmit() {
            if (!super.onViewSubmit()) {
                return false;
            }

            var request = this.view.params as Serenity.ListRequest;

            request.Criteria = Serenity.Criteria.and(request.Criteria,
                [['postToLedger'], '=', 0]);

            return true;
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number) {
            super.onClick(e, row, cell);

            if (e.isDefaultPrevented())
                return;

            var item = this.itemAt(row);
            var target = $(e.target);

            // -- ****
            if (target.parent().hasClass('Print-link'))
                target = target.parent();

            if (target.hasClass("Print-link")) {
                e.preventDefault();
                if (item.LinkedWithAutoJV && item.LinkedWithAutoJV != null) {
                    var _url = "~/Reports/VoucherPreview/IndexCombineVoucher?id=" + item.Id + "&isCombineVoucher=" + true;
                } else {
                    var _url = "~/Reports/VoucherPreview?id=" + item.Id;
                }
                Q.postToUrl({ url: _url, params: {}, target: "_blank" });
            }
            // -- ****//

            // -- ****
            if (target.parent().hasClass('view-action'))
                target = target.parent();

            if (target.hasClass('view-action')) {
                var dlg = new AccVoucherInformationDialog();
                this.initDialog(dlg);
                dlg.loadByIdAndOpenDialog(item.Id);
                $($('.s-Transaction-AccVoucherInformationDialog .category')[0]).hide();
            }
            // -- ****//
        }


        getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            let filters = super.getQuickFilters();

            // --
            let filterByChequeNo = Q.tryFirst(filters, x => x.field == fld.ChequeRegisterChequeNo);
            if (filterByChequeNo != null) {
                filterByChequeNo.title = "Cheque No..";
                filterByChequeNo.type = Serenity.StringEditor;
                filterByChequeNo.handler = h => {
                    if (h.active) {
                        h.request.Criteria = Serenity.Criteria.and(h.request.Criteria,
                            [[fld.ChequeRegisterChequeNo], 'like', '%' + h.value + '%']);
                    }
                };
            }

            // --
            let filterByAmount = Q.tryFirst(filters, x => x.field == fld.Amount);
            if (filterByAmount != null) {
                filterByAmount.title = "Amount (Exactly)";
                //filterByAmount.type = Serenity.StringEditor;
                //filterByAmount.handler = h => {
                //    if (h.active) {
                //        console.log(h.value);
                //        h.request.Criteria = Serenity.Criteria.and(h.request.Criteria,
                //            [[fld.Amount], 'like', h.value + '%']);
                //    }
                //};
            }
            // --

            return filters;
        }


        getQuickSearchFields(): Serenity.QuickSearchField[] {
            let txt = (s) => Q.text("Db." + AccVoucherInformationRow.localTextPrefix + "." + s).toLowerCase();

            return [
                { name: "", title: "all" },
                { name: fld.VoucherNo, title: txt(fld.VoucherNo) },
                { name: fld.Description, title: txt(fld.Description) },
                { name: fld.PaytoOrReciveFrom, title: txt(fld.PaytoOrReciveFrom) },
                { name: fld.ChequeRegisterChequeNo, title: txt(fld.ChequeRegisterChequeNo) },
                { name: fld.Amount, title: txt(fld.Amount) }
            ];

        }
    }
}