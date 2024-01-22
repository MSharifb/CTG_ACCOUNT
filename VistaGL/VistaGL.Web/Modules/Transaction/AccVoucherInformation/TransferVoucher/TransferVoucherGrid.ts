namespace VistaGL.Transaction {

    import fld = AccVoucherInformationRow.Fields;

    @Serenity.Decorators.registerClass()
    export class TransferVoucherGrid extends EntityGridBase<AccVoucherInformationRow, any> {
        protected getColumnsKey() { return 'Transaction.AccVoucherInformation'; }
        protected getDialogType() { return TransferVoucherDialog; }
        protected getIdProperty() { return AccVoucherInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherInformationRow.localTextPrefix; }
        protected getService() { return AccVoucherInformationService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Contra/Transfer Voucher");
        }

        protected getAddButtonCaption(): string {
            return "New Contra/Transfer Voucher";
        }

        protected onViewSubmit() {

            if (!super.onViewSubmit()) {
                return false;
            }

            var request = this.view.params as Serenity.ListRequest;

            request.Criteria = Serenity.Criteria.and(request.Criteria,
                [['VoucherTypeId'], '=', 4]);

            return true;
        }

        getColumns(): Slick.Column[] {
            var columns = super.getColumns();

            columns = columns.filter(x => x.field != fld.TransactionMode);
            columns = columns.filter(x => x.field != fld.LinkedWithDebitVoucher);

            // It is using to change backcolor of approved voucher.
            Q.first(columns, x => x.field == fld.approveStatus).cssClass += " col-Approve-Status";

            return columns;
        }

        getItemCssClass(item: Transaction.AccVoucherInformationRow, index: number): string {
            let klass: string = "";

            if (item.approveStatus == ApprovalStatus.Approved) {
                klass += " approved-Voucher";
            }

            return Q.trimToNull(klass);
        }

        protected getViewOptions() {
            var opt = super.getViewOptions();
            opt.rowsPerPage = 20;
            return opt;
        }
    }
}