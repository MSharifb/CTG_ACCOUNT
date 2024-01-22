

namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccCreditVoucherParametersDialog extends Serenity.EntityDialog<AccMoneyReceiptRow, any>{
        protected getFormKey() { return AccCreditVoucherParametersForm.formKey; }
        protected getIdProperty() { return AccMoneyReceiptRow.idProperty; }
        protected getLocalTextPrefix() { return AccMoneyReceiptRow.localTextPrefix; }
        protected getNameProperty() { return AccMoneyReceiptRow.nameProperty; }
        protected getService() { return AccCreditVoucherFromMoneyReceiptService.baseUrl; }

        protected form = new AccCreditVoucherParametersForm(this.idPrefix);

        private selectedItems;

        constructor() {
            super();
        }

        public SendSelected(selected) {
            this.selectedItems = selected;
        }

        protected getToolbarButtons(): Serenity.ToolButton[] {
            let buttons = super.getToolbarButtons();

            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "save-and-close-button"), 1);
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "apply-changes-button"), 1);
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "delete-button"), 1);
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "undo-delete-button"), 1);
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "localization-button"), 1);
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "clone-button"), 1);



            var linkButton = {
                title: 'Create Voucher',
                cssClass: 'save-and-close-button',
                onClick: () => {

                    if (this.form.CreditVoucherDate.value == "" || this.form.CreditVoucherNarration.value == "") {
                        Q.warning("Please fill-up necessary fields.");
                    }
                    else {
                        Q.defaultNotifyOptions.positionClass = "toast-top-center";
                        Q.defaultNotifyOptions.newestOnTop = false;
                        //Q.notifyWarning("Voucher Preparation in Progress...", "Prepare Credit Voucher");

                        var servicecall = AccCreditVoucherFromMoneyReceiptService.CreateCreditVoucher(
                            {
                                MoneyReceiptIds: this.selectedItems,
                                VoucherDate: this.form.CreditVoucherDate.value,
                                Narration: this.form.CreditVoucherNarration.value,
                                ReceiveFrom: this.form.ReceiveFrom.value
                            },
                            response => {
                                let options: ToastrOptions = Q.defaultNotifyOptions;
                                options.tapToDismiss = true;

                                this.dialogClose();

                                var message = JSON.parse(servicecall.responseText);

                                //Q.alert(message.OutoutMessage);
                                Q.notifySuccess(message.OutoutMessage, "Success", options);
                            },
                            {
                                blockUI: true,
                                onError: response => {
                                    let options: ToastrOptions = Q.defaultNotifyOptions;
                                    options.timeOut = 15000;
                                    options.extendedTimeOut = 3000;

                                    this.dialogClose();
                                    Q.notifyError("Something happened wrong!", "Prepare Credit Voucher", options);
                                    var errorcontent = JSON.parse(servicecall.responseText);

                                    var message = errorcontent["Error"]["Message"]

                                    Q.alert(message);
                                },
                                //onCleanup: () => this.serviceCallCleanup()
                            });
                    }


                }

            };

            var cancelButton = {
                title: 'Cancel',
                cssClass: 'undo-delete-button',
                onClick: () => {
                    this.dialogClose();

                }

            };

            buttons.push(linkButton);
            buttons.push(cancelButton);



            return buttons;
        }
    }
}