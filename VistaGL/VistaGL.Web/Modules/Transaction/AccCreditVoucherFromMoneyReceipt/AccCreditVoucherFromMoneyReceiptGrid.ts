
namespace VistaGL.Transaction {

    import fld = AccMoneyReceiptRow.Fields;

    @Serenity.Decorators.registerClass()
    export class AccCreditVoucherFromMoneyReceiptGrid extends Serenity.EntityGrid<AccMoneyReceiptRow, any> {
        protected getColumnsKey() { return 'Transaction.AccCreditVoucherFromMoneyReceipt'; }
        protected getIdProperty() { return AccMoneyReceiptRow.idProperty; }
        protected getLocalTextPrefix() { return AccMoneyReceiptRow.localTextPrefix; }
        protected getService() { return AccCreditVoucherFromMoneyReceiptService.baseUrl; }

        private rowSelection: Serenity.GridRowSelectionMixin;

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Prepare Credit Voucher from Money Receipts");
        }

        protected createToolbarExtensions() {
            super.createToolbarExtensions();
            this.rowSelection = new Serenity.GridRowSelectionMixin(this);
        }

        protected getButtons() {
            var buttons = super.getButtons();
            buttons.shift();

            buttons.push({
                title: 'Prepare Credit Voucher',
                cssClass: 'send-button',
                onClick: () => {
                    if (!this.onViewSubmit()) {
                        return;
                    }

                    var selected = this.rowSelection.getSelectedKeys();

                    if (selected.length == 0) {
                        var rv = Q.warning("No row is selected!");
                    }
                    else {
                        var selectedOutput = [];
                        var items;
                        let bankAccId: number = 0;
                        for (var i = 0; i < selected.length; i++) {

                            let id = selected[i];
                            items = AccMoneyReceiptRow.getLookup().items.filter(x => x.Id == +id)[0];

                            if(i==0)
                                bankAccId = items.AccHeadBankId;

                            if (i > 0 && bankAccId != items.AccHeadBankId) {
                                Q.warning("Account Head Bank must be same in case of multiple money receipts setection!");
                                return;
                            }


                            selectedOutput.push(+selected[i]);
                        }

                        var dialog = new AccCreditVoucherParametersDialog();
                        dialog.SendSelected(selectedOutput);

                        dialog.element.bind('dialogclose', () => {
                            this.rowSelection.resetCheckedAndRefresh();
                        });

                        dialog.loadNewAndOpenDialog();
                    }

                    //var action = new AccCreditVoucherFromMoneyReceiptBulkAction();
                    //action.done = () => this.rowSelection.resetCheckedAndRefresh();
                    //action.execute(this.rowSelection.getSelectedKeys());

                } // *** End onClick() ***

            }); // *** End Button.push ***


            return buttons;
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

            //var request = this.view.params as Serenity.ListRequest;

            //request.Criteria = Serenity.Criteria.and(request.Criteria,
            //    [['IsUsed'], '=', 0]);

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
                var _url = "~/Reports/MoneyReceipt?id=" + item.Id + "&source='FromMoneyReceiptPage'";
                Q.postToUrl({ url: _url, params: {}, target: "_blank" });
            }
            // -- ****//


        }

    }
}