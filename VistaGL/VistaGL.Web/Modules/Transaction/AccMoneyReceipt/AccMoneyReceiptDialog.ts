
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccMoneyReceiptDialog extends EntityDialogBase<AccMoneyReceiptRow, any> {
        protected getFormKey() { return AccMoneyReceiptForm.formKey; }
        protected getIdProperty() { return AccMoneyReceiptRow.idProperty; }
        protected getLocalTextPrefix() { return AccMoneyReceiptRow.localTextPrefix; }
        protected getNameProperty() { return AccMoneyReceiptRow.nameProperty; }
        protected getService() { return AccMoneyReceiptService.baseUrl; }

        protected form = new AccMoneyReceiptForm(this.idPrefix);

        constructor() {
            super();

            (this.form.AccMoneyReceiptDatailsList.view as any).onDataChanged.subscribe(() => {
                var total = 0;
                for (var k of this.form.AccMoneyReceiptDatailsList.getItems()) {
                    total += k.Amount || 0;
                }
                this.form.Amount.value = total;
                this.form.AmountInWord.value = VoucherUtil.currencyToWords(total);
            });

            this.form.AccMoneyReceiptDatailsList.onItemsChanged = () => {
                var total = 0;
                for (var k of this.form.AccMoneyReceiptDatailsList.getItems()) {
                    total += k.Amount || 0;
                }
                this.form.Amount.value = total;
                this.form.AmountInWord.value = VoucherUtil.currencyToWords(total);
            };
        }

        onDialogOpen(): void {
            super.onDialogOpen();
            var userinfo = Authorization.userDefinition;

            this.toolbar.findButton('MoneyReceipt').hide();

            if (this.isEditMode()) {
                if (this.form.IsConfirmed.value == true) {
                    this.toolbar.findButton('MoneyReceipt').show();
                    this.toolbar.findButton('delete-button').hide();
                    this.toolbar.findButton('apply-changes-button').hide();
                    this.toolbar.findButton('save-and-close-button').hide();
                }
                if (this.form.IsUsed.value == true)
                {
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.IsCancelled.element), true);
                }
            }
            else {
                Transaction.AccMoneyReceiptService.GetNewMoneyReceiptNo({ ZoneId: userinfo.ZoneID, FundControlId: userinfo.FundControlInformationId }, r => {
                    this.form.SerialNo.value = r.MoneyReceiptNo;
                    this.form.MoneyReceiptNo.value = r.MoneyReceiptNumber;
                })
            }

            //this.form.CostCenterId.changeSelect2(p => {
            //    this.form.CostCenterName.value = this.form.CostCenterId.get_text();
            //});
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push({
                title: "Money Receipt", cssClass: "print-preview-button MoneyReceipt",

                onClick: (x) => {
                    if (this.entityId != undefined) {
                        var _url = "~/Reports/MoneyReceipt?id=" + this.entityId + "&source='FromMoneyReceiptPage'";
                        Q.postToUrl({ url: _url, params: {}, target: "_blank" });
                    } else {
                        Q.alert("Sorry! Money Receipt Id not found!");
                    }
                }
            });

            return buttons;
        }
    }
}