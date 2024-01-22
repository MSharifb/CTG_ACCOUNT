
namespace VistaGL.Transaction {

    import fld = AccMoneyReceiptRow.Fields;

    @Serenity.Decorators.registerClass()
    export class AccMoneyReceiptGrid extends EntityGridBaseNew<AccMoneyReceiptRow, any> {
        protected getColumnsKey() { return 'Transaction.AccMoneyReceipt'; }
        protected getDialogType() { return AccMoneyReceiptDialog; }
        protected getIdProperty() { return AccMoneyReceiptRow.idProperty; }
        protected getLocalTextPrefix() { return AccMoneyReceiptRow.localTextPrefix; }
        protected getService() { return AccMoneyReceiptService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.frozenColumn = 5;

            return opt;
        }

        protected getColumns() {
            var columns = super.getColumns();

            columns.splice(1, 0, {
                field: 'Print Money Receipt',
                name: '',
                format: ctx => '<a class="inline-action Print-link" title="Print Money Receipt">' +
                    '<i class="fa fa-print text-blue"></i></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });

            return columns;
        }

        protected getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            let filters = super.getQuickFilters();

            Q.first(filters, x => x.field == fld.IsUsed).init = w => {
                (w as TrueFalseEditor).value = "false"
            };

            return filters;
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

                if (item.IsConfirmed) {
                    var _url = "~/Reports/MoneyReceipt?id=" + item.Id + "&source='FromMoneyReceiptPage'";
                    Q.postToUrl({ url: _url, params: {}, target: "_blank" });
                }
                else {
                    Q.warning("This Money Receipt is not confirm yet!");
                }

            }
            // -- ****//


        }
    }
}