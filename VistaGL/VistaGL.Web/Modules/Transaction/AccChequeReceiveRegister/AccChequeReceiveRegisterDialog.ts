
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccChequeReceiveRegisterDialog extends Serenity.EntityDialog<AccChequeReceiveRegisterRow, any> {
        protected getFormKey() { return AccChequeReceiveRegisterForm.formKey; }
        protected getIdProperty() { return AccChequeReceiveRegisterRow.idProperty; }
        protected getLocalTextPrefix() { return AccChequeReceiveRegisterRow.localTextPrefix; }
        protected getNameProperty() { return AccChequeReceiveRegisterRow.nameProperty; }
        protected getService() { return AccChequeReceiveRegisterService.baseUrl; }

        protected form = new AccChequeReceiveRegisterForm(this.idPrefix);
        public dig: Transaction.AccVoucherBankWiseDialog;
        public digforOnlyPayment: AccVoucherInformationDialog;

        public _isFromVoucher: boolean;
        public _isPaymentOrReceiptVoucherOnly: boolean;


        constructor() {
            super();
            this.form.ReceiveType.changeSelect2(e => {
                let chT = this.form.ReceiveType.value;
                var dd = $('.field .ChequeNo').val();

            });
        }

        //protected BankAccountInformation_Change() {
        //    //   console.log(this.form.BankAccountInformationId.value);
        //    if (this.form.BankAccountInformationId.value == "") {
        //        this.form.AccountName.value = "";
        //        this.form.BankName.value = "";
        //        this.form.BranchName.value = "";
        //    }
        //    else {
        //        var selectedItem = Configurations.AccBankAccountInformationRow.getLookup().itemById[this.form.BankAccountInformationId.value];

        //        this.form.AccountName.value = selectedItem.AccountName;
        //        this.form.BankName.value = selectedItem.BankBankName;
        //        this.form.BranchName.value = selectedItem.BankBranchBranchName;
        //        //  this.form.DistrictId.value = selectedItem.DistrictId.toString();
        //    }
        //}

        protected onDialogOpen(): void {

            if (this._isFromVoucher) {
                this.toolbar.findButton('save-and-close-button').hide()
                this.toolbar.findButton('apply-changes-button').hide()
            }
            else {
                this.toolbar.findButton('send-button').hide()
            }
            //if (this.isEditMode()) {
            //    this.BankAccountInformation_Change();
            //}
        }


        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push({
                title: "Add", cssClass: "send-button",

                onClick: (x) => {

                    this.save(p => {
                        if (this._isPaymentOrReceiptVoucherOnly) {

                            this.digforOnlyPayment.form.PaytoOrReciveFrom.value = this.form.RecieveFrom.value;

                            if (this.digforOnlyPayment.form.VoucherTypeId.value == "1")
                                this.digforOnlyPayment.form.CreditAmount.value = this.form.Amount.value;
                            else
                                this.digforOnlyPayment.form.DebitAmount.value = this.form.Amount.value;


                            Q.reloadLookup("Transaction.AccChequeReceiveRegister_Lookup");
                            let data: AccChequeReceiveRegisterRow[];
                            data = Q.getLookup('Transaction.AccChequeReceiveRegister_Lookup').items;
                            this.digforOnlyPayment.form.ChequeRegisterId.clearItems();
                            for (var i = 0; i < data.length; i++) {
                                let str = data[i];
                                this.digforOnlyPayment.form.ChequeRegisterId.addItem({ id: str.Id.toString(), text: str.ChequeNo.toString(), source: null, disabled: false })
                                let l = data.length;
                                if (l - 1 == i) {
                                    this.digforOnlyPayment.form.ChequeRegisterId.value = str.Id.toString();
                                }
                            }

                        }
                        else {
                            this.dig.form.PaytoOrReciveFrom.value = this.form.RecieveFrom.value;
                            this.dig.form.BankAmount.value = this.form.Amount.value;

                            if (this.dig.form.VoucherTypeId.value == "1")
                                this.dig.form.DebitAmount.value = this.form.Amount.value;
                            else
                                this.dig.form.CreditAmount.value = this.form.Amount.value;


                            Q.reloadLookup("Transaction.AccChequeReceiveRegister_Lookup");
                            let data: AccChequeReceiveRegisterRow[];
                            data = Q.getLookup('Transaction.AccChequeReceiveRegister_Lookup').items;
                            this.dig.form.ChequeRegisterId.clearItems();
                            for (var i = 0; i < data.length; i++) {
                                let str = data[i];
                                this.dig.form.ChequeRegisterId.addItem({ id: str.Id.toString(), text: str.ChequeNo.toString(), source: null, disabled: false })
                                let l = data.length;
                                if (l - 1 == i) {
                                    this.dig.form.ChequeRegisterId.value = str.Id.toString();
                                }
                            }
                        }
                        this.dialogClose();

                    });

                }
            });
            return buttons;
        }

    }
}