/// <reference path="../accvoucherinformationgrid.ts" />
namespace VistaGL.Transaction {
    import fld = AccVoucherInformationRow.Fields;

    @Serenity.Decorators.registerClass()
    export class JournalVoucherGrid extends AccVoucherInformationGrid {

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Journal/Adjustment Voucher");
        }

        protected getAddButtonCaption(): string {
            return "New Journal Voucher";
        }

        protected addButtonClick() {
            this.editItem(<AccVoucherInformationRow>{
                VoucherTypeId: 3
            });
        }

        protected onViewSubmit() {

            if (!super.onViewSubmit()) {
                return false;
            }

            var request = this.view.params as Serenity.ListRequest;

            request.Criteria = Serenity.Criteria.and(request.Criteria,
                [['VoucherTypeId'], '=', 3]);

            return true;
        }

        getColumns(): Slick.Column[] {
            var columns = super.getColumns();

            columns = columns.filter(x => x.field != fld.TransactionMode);
            columns = columns.filter(x => x.field != fld.ChequeRegisterChequeNo);
            columns = columns.filter(x => x.field != fld.LinkedWithAutoJV);

            // It is using to change backcolor of approved voucher.
            Q.first(columns, x => x.field == fld.approveStatus).cssClass += " col-Approve-Status";


            return columns;
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

        getQuickFilters(): Serenity.QuickFilter<Serenity.Widget<any>, any>[] {
            let filters = super.getQuickFilters();

            Q.tryFirst(filters, x => x.field == fld.LinkedWithDebitVoucher).init = w => {
                (w as TrueFalseEditor).value = "false";
            };

            return filters;
        }

        protected getViewOptions() {
            var opt = super.getViewOptions();
            opt.rowsPerPage = 20;
            return opt;
        }

    }
}