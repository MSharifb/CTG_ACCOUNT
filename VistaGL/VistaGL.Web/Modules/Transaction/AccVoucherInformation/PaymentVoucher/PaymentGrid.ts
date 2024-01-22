/// <reference path="../accvoucherinformationgrid.ts" />
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class PaymentGrid extends Transaction.AccVoucherBankWiseGrid {

        constructor(container: JQuery) {
            super(container);
            this.setTitle("Bank Wise Payment Voucher");
        }
        protected getAddButtonCaption(): string {
            return "New Bank Wise Payment Voucher";
        }

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

        //protected getButtons() {
        //    let buttons = super.getButtons();

        //    buttons.push({
        //        title: "Payment",
        //        cssClass: 'tool-button add-button',
        //        //icon: 'icon-lock-open text-green',
        //        onClick: () => {
        //            new AccVoucherBankWiseDialog().dialogOpen();
        //            this.editItem(<AccVoucherInformationRow>{
        //                VoucherTypeId: 1
        //            });
        //        }
        //    });

        //    return buttons;
        //}

        protected addButtonClick() {
            this.editItem(<AccVoucherInformationRow>{
                VoucherTypeId: 1 // BANK WISE PAYMENT VOUCHER
            });
        }

        protected onViewSubmit() {

            if (!super.onViewSubmit()) {
                return false;
            }

            var request = this.view.params as Serenity.ListRequest;

            request.Criteria = Serenity.Criteria.and(request.Criteria,
                [['VoucherTypeId'], '=', 1]);

            return true;
        }

        protected subDialogDataChange() {
            super.subDialogDataChange();

            Q.reloadLookup('Transaction.AccChequeRegister_Lookup');
            //  Q.reloadLookup('Transaction.AccChequeReceiveRegister_Lookup');
        }


    }
}