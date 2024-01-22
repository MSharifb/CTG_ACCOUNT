/// <reference path="../accvoucherinformationgrid.ts" />
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class ReceiptGrid extends Transaction.AccVoucherBankWiseGrid {

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Bank Wise Receipt Voucher");
        }
        protected getAddButtonCaption(): string {
            return "New Bank Wise Receipt Voucher";
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
            // only continue if base class returns true (didn't cancel request)
            if (!super.onViewSubmit()) {
                return false;
            }

            // view object is the data source for grid (SlickRemoteView)
            // this is an EntityGrid so its Params object is a ListRequest
            var request = this.view.params as Serenity.ListRequest;

            // list request has a Criteria parameter
            // we AND criteria here to existing one because
            // otherwise we might clear filter set by
            // an edit filter dialog if any.

            request.Criteria = Serenity.Criteria.and(request.Criteria,
                [['VoucherTypeId'], '=', 2]);

            // TypeScript doesn't support operator overloading
            // so we had to use array syntax above to build criteria.

            // Make sure you write
            // [['Field'], '>', 10] (which means field A is greater than 10)
            // not
            // ['A', '>', 10] (which means string 'A' is greater than 10

            return true;
        }
          protected subDialogDataChange() {
            super.subDialogDataChange();

           // Q.reloadLookup('Transaction.AccChequeRegister_Lookup');
            Q.reloadLookup('Transaction.AccChequeReceiveRegister_Lookup');
        }
    }
}