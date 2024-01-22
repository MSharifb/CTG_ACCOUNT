
namespace VistaGL.Transaction {
    import fld = AccVoucherInformationRow.Fields;

    @Serenity.Decorators.registerClass()
    export class AccVoucherInformationSearchGrid extends EntityGridBaseNew<AccVoucherInformationRow, any> {
        protected getColumnsKey() { return 'Transaction.VoucherInformationSearch'; }
        protected getDialogType() { return AccVoucherInformationDialog; }
        protected getIdProperty() { return AccVoucherInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherInformationRow.localTextPrefix; }
        protected getService() { return AccVoucherInformationService.baseUrl; }

        protected VoucherTempId: number;
        public set_VoucherTempId(value: number): void {
            this.VoucherTempId = value == null ? 0 : value;
        }

        public OpenVoucher(id) {
        }


        constructor(container: JQuery) {
            super(container);

        }

        //protected VoucherTypeIdFilter: Serenity.LookupEditor;
        //public set_VoucherTypeId(value: number): void {
        //    this.VoucherTypeIdFilter.value = value == null ? '' : value.toString();
        //}

        //protected createQuickFilters() {
        //    super.createQuickFilters();

        //    let fld = AccVoucherInformationRow.Fields;

        //    this.VoucherTypeIdFilter = this.findQuickFilter(Serenity.LookupEditor, fld.VoucherTypeId);
        //}

        protected getColumns(): Slick.Column[] {
            var columns = super.getColumns();

            columns.unshift({
                field: 'Print Voucher',
                name: '',
                format: ctx => '<a class="inline-action Print-link" title="Print Voucher">' +
                    '<i class="fa fa-print text-blue"></i></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });

            // It is using to change backcolor of approved voucher.
            Q.first(columns, x => x.field == fld.approveStatus).cssClass += " col-Approve-Status";

            return columns;
        }

        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.frozenColumn = 3;

            return opt;
        }

        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string {
            let klass: string = "";

            if (item.approveStatus === ApprovalStatus.Approved) {
                klass += " approved-Voucher";
            }

            if (item.LinkedWithDebitVoucher) {
                klass += " linked-Journal-Voucher";
            }

            return Q.trimToNull(klass);
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number): void {

            super.onClick(e, row, cell);

            if (e.isDefaultPrevented()) {
                return;
            }

            var item = this.itemAt(row);

            var target = $(e.target);

            if (target.parent().hasClass('Print-link'))
                target = target.parent();

            //if (item.LinkedWithAutoJV == true && item.LinkedWithAutoJV != null) {
            //    if (target.hasClass("Print-link")) {
            //        e.preventDefault();
            //        var b = (new VoucherPreviewDialog());
            //        var _url = Q.resolveUrl("~/Reports/VoucherPreview/IndexCombineVoucher?id=" + item.Id + "&isCombineVoucher=" + true);
            //        b._url = _url;
            //        b.dialogOpen();
            //    }
            //}
            //else {
            //    if (target.hasClass("Print-link")) {
            //        e.preventDefault();
            //        var b = (new VoucherPreviewDialog());
            //        var _url = Q.resolveUrl("~/Reports/VoucherPreview?id=" + item.Id);
            //        b._url = _url;
            //        b.dialogOpen();
            //    }
            //}

            if (target.hasClass("Print-link")) {
                e.preventDefault();
                if (item.LinkedWithAutoJV && item.LinkedWithAutoJV != null) {
                    var _url = "~/Reports/VoucherPreview/IndexCombineVoucher?id=" + item.Id + "&isCombineVoucher=" + true;
                } else {
                    var _url = "~/Reports/VoucherPreview?id=" + item.Id;
                }
                Q.postToUrl({ url: _url, params: {}, target: "_blank" });
            }
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

        protected getButtons() {
            var b = super.getButtons();
            b.shift();

            return b;
        }

        protected getViewOptions() {
            var opt = super.getViewOptions();
            opt.rowsPerPage = 20;
            return opt;
        }
    }
}