
namespace VistaGL.Transaction {

    import fld = Transaction.AccVoucherInformationRow.Fields;

    @Serenity.Decorators.registerClass()
    export class AccChequePreparationGrid extends EntityGridBaseNew<AccVoucherInformationRow, any> {
        protected getColumnsKey() { return 'Transaction.AccChequePreparation'; }
        //protected getDialogType() { return AccChequePreparationDialog; }
        protected getIdProperty() { return AccVoucherInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherInformationRow.localTextPrefix; }
        protected getService() { return AccChequePreparationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            let filters = super.getQuickFilters();

            Q.tryFirst(filters, x => x.field == fld.IsChequePrepared).init = w => {
                (w as TrueFalseEditor).value = "false";
            };

            return filters;
        }

        getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();

            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"));

            return buttons;
        }

        getColumns(): Slick.Column[] {
            var columns = super.getColumns();


            columns.unshift({
                field: 'Prepare Cheque',
                name: '',
                format: ctx => '<a class="inline-action Prepare-Cheque" title="Prepare Cheque">' +
                    '<i class="fa fa-check-square-o text-green"></i></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });

            columns.splice(1, 0, {
                field: 'Print Cheque',
                name: '',
                format: ctx => '<a class="inline-action Print-Cheque" title="Print Cheque">' +
                    '<i class="fa fa-print text-red"></i></a>',
                width: 24,
                minWidth: 24,
                maxWidth: 24
            });

            return columns;
        }

        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.frozenColumn = 3;

            return opt;
        }

        onClick(e: JQueryEventObject, row: number, cell: number): void {
            super.onClick(e, row, cell);

            if (e.isDefaultPrevented())
                return;

            var item = this.itemAt(row);
            var target = $(e.target);

            if (target.parent().hasClass('inline-action'))
                target = target.parent();

            if (target.hasClass('inline-action')) {
                e.preventDefault();

                var voucher = Q.first(Transaction.AccVoucherInformationRow.getLookup().items, x => x.Id == item.Id);

                if (target.hasClass('Prepare-Cheque')) {
                    if (voucher.IsChequePrepared) {
                        Q.information('Cheque is already prepared for voucher# ' + item.VoucherNo, () => { });
                    } else {
                        Q.confirm('Prepare this cheque for voucher# ' + item.VoucherNo + '?',
                            () => {
                                Transaction.AccChequePreparationService.Update({
                                    EntityId: item.Id,
                                    Entity: voucher

                                },
                                    response => {
                                        this.refresh();
                                    });
                            });
                    }
                }
                else if (target.hasClass('Print-Cheque')) {
                    Common.ReportHelper.execute({
                        reportKey: 'Transaction.AccChequePreparation.ChequePrint',
                        params: {
                            VoucherId: item.Id
                        }
                    });

                }
            }
        }
    }
}