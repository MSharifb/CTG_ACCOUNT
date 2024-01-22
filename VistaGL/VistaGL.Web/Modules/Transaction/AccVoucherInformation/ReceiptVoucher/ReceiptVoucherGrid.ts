/// <reference path="../accvoucherinformationgrid.ts" />
namespace VistaGL.Transaction {

    import fld = AccVoucherInformationRow.Fields;

    @Serenity.Decorators.registerClass()
    export class ReceiptVoucherGrid extends AccVoucherInformationGrid {

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Receipt Voucher");
        }

        protected getAddButtonCaption(): string {
            return "New Receipt Voucher";
        }

        /**
         * This method is called when New Item button is clicked.
         * By default, it calls EditItem with an empty entity.
         * This is a good place to fill in default values for New Item button.
         */
        //protected addButtonClick() {
        //    //this.editItem(<Northwind.OrderRow>{
        //    //    CustomerID: 'ANTON',
        //    //    RequiredDate: Q.formatDate(new Date(), 'yyyy-MM-dd'),
        //    //    EmployeeID: Northwind.EmployeeRow.getLookup().items
        //    //        .filter(x => x.FullName === 'Robert King')[0].EmployeeID,
        //    //    ShipVia: Northwind.ShipperRow.getLookup().items
        //    //        .filter(x => x.CompanyName === 'Speedy Express')[0].ShipperID
        //    //});
        //}
        protected addButtonClick() {
            this.editItem(<AccVoucherInformationRow>{
                VoucherTypeId: 2
            });
        }

        protected onViewSubmit() {

            if (!super.onViewSubmit()) {
                return false;
            }

            var request = this.view.params as Serenity.ListRequest;

            request.Criteria = Serenity.Criteria.and(request.Criteria,
                [['VoucherTypeId'], '=', 2]);

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

        protected subDialogDataChange() {
            super.subDialogDataChange();

            // Q.reloadLookup('Transaction.AccChequeRegister_Lookup');
            Q.reloadLookup('Transaction.AccChequeReceiveRegister_Lookup');
        }

        protected getViewOptions() {
            var opt = super.getViewOptions();
            opt.rowsPerPage = 20;
            return opt;
        }
    }
}