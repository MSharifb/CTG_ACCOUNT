
namespace VistaGL.Transaction {
    @Serenity.Decorators.maximizable()
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherTemplateVoucherIssueDialog extends _Ext.DialogBase<AccVoucherTemplateRow, any> {
        protected getFormKey() { return AccVoucherTemplateVoucherIssueForm.formKey; }
        protected getIdProperty() { return AccVoucherTemplateRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherTemplateRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherTemplateRow.nameProperty; }
        protected getService() { return AccVoucherTemplateService.baseUrl; }
        public items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        protected form = new AccVoucherTemplateVoucherIssueForm(this.idPrefix);

        protected items_VoucherTemplate = Transaction.AccVoucherTemplateRow.getLookup().items;

        constructor() {
            super();
            $('.ui-dialog-titlebar-maximize').click();
            this.form.VoucherTypeId.changeSelect2(e => {
                this.form.TemplateName.value = "";
                this.form.TemplateName.clearItems();
                this.hide_VoucherTypeId_TransactionTypeId_Change();
            });

            this.form.TransactionTypeId.changeSelect2(e => {
                this.form.TemplateName.value = "";
                this.hide_VoucherTypeId_TransactionTypeId_Change();
                var items = this.items_VoucherTemplate.filter(f => f.TransactionTypeId.toString() == this.form.TransactionTypeId.value);
                this.form.TemplateName.clearItems();
                for (var item of items) {
                    this.form.TemplateName.addItem({ id: item.TemplateName, text: item.TemplateName, source: null, disabled: false });
                }
            });

            //
            this.form.TemplateName.changeSelect2(e => {
                var id = Q.first(Transaction.AccVoucherTemplateRow.getLookup().items, x => x.TemplateName == this.form.TemplateName.value).Id;
                if (id != null && id > 0) {
                    Transaction.AccVoucherTemplateService.Retrieve({
                        EntityId: id
                    }, response => {
                        this.setTemplateDetails(response.Entity);
                    });
                }
            });

            //calculate SD/VAT/TAX Amount
            this.form.Amount.element.on('change keyup blur', () => {
                this.calculate_SDAmount();
                this.calculate_VATAmount();
                this.calculate_TAXAmount();
            });

            //calculate SD Amount
            this.form.SdRate.element.on('change keyup blur', () => {
                this.calculate_SDAmount();
            });

            //calculate VAT Amount
            this.form.VatRate.element.on('change keyup blur', () => {
                this.calculate_VATAmount();
            });

            //calculate TAX Amount
            this.form.TaxRate.element.on('change keyup blur', () => {
                this.calculate_TAXAmount();
            });

        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();
            buttons.shift();
            buttons.shift();
            buttons.shift();
            buttons.push({
                title: "Process", cssClass: "send-button",

                onClick: (x) => {

                    if (this.form.IsDebitHeadCheque.value && this.form.DebitHeadChequeId.value == '') {
                        Q.warning("Please select Cheque No.(Dr.)");
                        return;
                    }

                    if (this.form.IsCreditHeadCheque.value && this.form.CreditHeadChequeId.value == '') {
                        Q.warning("Please select Cheque No.(Cr.)");
                        return;
                    }

                    if (this.form.IsCostCenter.value && this.form.CostCenterId.value == '') {
                        Q.warning("Please select Sub Ledger.");
                        return;
                    }
                    if (this.form.IsBillReference.value && this.form.BillReferenceNo.value == '') {
                        Q.warning("Please enter Bill Reference No.");
                        return;
                    }

                    if (this.form.Amount.value.toString() == "NaN" || this.form.Amount.value == 0) {
                        // Q.warning("Credit Amount only Bank or Cash Head.");
                        Q.alert("Amount must be greater than 0;");
                        return;
                    }

                    if (this.form.VoucherDate.value =='' || this.form.VoucherDate.value == null) {
                        Q.warning("Please enter Voucher Date.");
                        return;
                    }


                    if (this.entityId != undefined) {
                        var b = (new AccVoucherInformationDialog());
                        var entity_voucher: AccVoucherInformationRow;
                        entity_voucher = {};

                        entity_voucher.VoucherTypeId = +this.form.VoucherTypeId.value;
                        entity_voucher.TransactionMode = this.form.TransactionMode.value;
                        entity_voucher.VoucherDate = this.form.VoucherDate.value;

                        b.loadEntityAndOpenDialog(entity_voucher);

                        b.form.TransactionTypeEntityId.value = this.form.TransactionTypeId.value;

                        b.setNewVoucherNumber();
                        b.loadAccountHead();

                        b.form.DebitAmount.value = 0;
                        b.form.CreditAmount.value = 0;

                        b.form.AccountHead.value = this.form.CoaCreditHeadId.value;
                        b.form.CreditAmount.value = this.form.Amount.value;
                        if (this.form.IsSd.value && this.form.SdType.value == "Cr") {
                            b.form.CreditAmount.value = (b.form.CreditAmount.value - this.form.SdAmount.value);
                        }
                        if (this.form.IsVat.value && this.form.VatType.value == "Cr") {
                            b.form.CreditAmount.value = (b.form.CreditAmount.value - this.form.VatAmount.value);
                        }

                        if (this.form.IsTax.value && this.form.TaxType.value == "Cr") {
                            b.form.CreditAmount.value = (b.form.CreditAmount.value - this.form.TaxAmount.value);
                        }

                        b.loadCheque();
                        b.form.ChequeRegisterId.value = this.form.CreditHeadChequeId.value;
                        b.setMultiCurrencyCurrency(null, null, false);
                        b.form.ConversionRate.value = 1;
                        b.form.ConversionAmount.value = b.form.ConversionRate.value * b.form.CreditAmount.value;

                        var Check_AccHead = this.items_ChartofAccounts.filter(f => f.Id == +this.form.CoaCreditHeadId.value);
                        if (Check_AccHead[0].IsCostCenterAllocate == 1) {
                            if (this.form.CostCenterId.value != "") {
                                b.form.CostCentreId.value = this.form.CostCenterId.value;
                            }
                        }
                        b.addtoGrid();

                        b.form.DebitAmount.value = 0;
                        b.form.CreditAmount.value = 0;

                        b.form.AccountHead.value = this.form.CoaDebitHeadId.value;
                        b.form.DebitAmount.value = this.form.Amount.value;
                        if (this.form.IsSd.value && this.form.SdType.value == "Dr") {
                            b.form.DebitAmount.value = (b.form.DebitAmount.value - this.form.SdAmount.value);
                        }
                        if (this.form.IsVat.value && this.form.VatType.value == "Dr") {
                            b.form.DebitAmount.value = (b.form.DebitAmount.value - this.form.VatAmount.value);
                        }

                        if (this.form.IsTax.value && this.form.TaxType.value == "Dr") {
                            b.form.DebitAmount.value = (b.form.DebitAmount.value - this.form.TaxAmount.value);
                        }

                        b.loadCheque();
                        b.form.ChequeRegisterId.value = this.form.DebitHeadChequeId.value;
                        b.setMultiCurrencyCurrency(null, null, false);
                        b.form.ConversionRate.value = 1;
                        b.form.ConversionAmount.value = b.form.ConversionRate.value * b.form.DebitAmount.value;
                        var Check_AccHead2 = this.items_ChartofAccounts.filter(f => f.Id == +this.form.CoaDebitHeadId.value);
                        if (Check_AccHead2[0].IsCostCenterAllocate == 1) {
                            if (this.form.CostCenterId.value != "") {
                                b.form.CostCentreId.value = this.form.CostCenterId.value;
                            }
                        }
                        b.addtoGrid();

                        //SD
                        if (this.form.IsSd.value) {
                            b.form.DebitAmount.value = 0;
                            b.form.CreditAmount.value = 0;
                            b.form.AccountHead.value = this.form.CoaSdId.value;
                            if (this.form.SdType.value == "Dr") {
                                b.form.DebitAmount.value = this.form.SdAmount.value;
                            } else {
                                b.form.CreditAmount.value = this.form.SdAmount.value;

                            }
                            b.setMultiCurrencyCurrency(null, null, false);
                            b.form.ConversionRate.value = 1;
                            b.form.ConversionAmount.value = b.form.ConversionRate.value * this.form.SdAmount.value;

                            var Check_AccHead3 = this.items_ChartofAccounts.filter(f => f.Id == +this.form.CoaSdId.value);
                            if (Check_AccHead3[0].IsCostCenterAllocate == 1) {
                                if (this.form.CostCenterId.value != "") {
                                    b.form.CostCentreId.value = this.form.CostCenterId.value;
                                }
                            }

                            b.addtoGrid();
                        }


                        //VAT
                        if (this.form.IsVat.value) {
                            b.form.DebitAmount.value = 0;
                            b.form.CreditAmount.value = 0;
                            b.form.AccountHead.value = this.form.CoaVatId.value;
                            if (this.form.VatType.value == "Dr") {
                                b.form.DebitAmount.value = this.form.VatAmount.value;
                            } else {
                                b.form.CreditAmount.value = this.form.VatAmount.value;
                            }
                            b.setMultiCurrencyCurrency(null, null, false);
                            b.form.ConversionRate.value = 1;
                            b.form.ConversionAmount.value = b.form.ConversionRate.value * this.form.VatAmount.value;

                            var Check_AccHead4 = this.items_ChartofAccounts.filter(f => f.Id == +this.form.CoaVatId.value);
                            if (Check_AccHead4[0].IsCostCenterAllocate == 1) {
                                if (this.form.CostCenterId.value != "") {
                                    b.form.CostCentreId.value = this.form.CostCenterId.value;
                                }
                            }

                            b.addtoGrid();
                        }

                        //Tax
                        if (this.form.IsTax.value) {
                            b.form.DebitAmount.value = 0;
                            b.form.CreditAmount.value = 0;
                            b.form.AccountHead.value = this.form.CoaTaxId.value;
                            if (this.form.TaxType.value == "Dr") {
                                b.form.DebitAmount.value = this.form.TaxAmount.value;
                            } else {
                                b.form.CreditAmount.value = this.form.TaxAmount.value;
                            }
                            b.setMultiCurrencyCurrency(null, null, false);
                            b.form.ConversionRate.value = 1;
                            b.form.ConversionAmount.value = b.form.ConversionRate.value * this.form.TaxAmount.value;

                            var Check_AccHead5 = this.items_ChartofAccounts.filter(f => f.Id == +this.form.CoaTaxId.value);
                            if (Check_AccHead5[0].IsCostCenterAllocate == 1) {
                                if (this.form.CostCenterId.value != "") {
                                    b.form.CostCentreId.value = this.form.CostCenterId.value;
                                }
                            }

                            b.addtoGrid();
                        }

                        b.form.Description.value = this.form.Remarks.value;
                    }

                }
            });
            return buttons;

        }

        //DebitAmount

        protected hide_VoucherTypeId_TransactionTypeId_Change() {

            //reset
            this.form.CoaDebitHeadId.value = "";
            // this.form.CoaDebitHeadId.clearItems();
            this.form.CoaCreditHeadId.value = "";
            //this.form.CoaCreditHeadId.clearItems();
            this.form.Remarks.value = "";
            //hide
            this.form.CostCenterId.element.closest(".field").hide();
            this.form.BillReferenceNo.element.closest(".field").hide();
            //SD hide
            this.form.CoaSdId.element.closest(".field").hide();
            this.form.SdType.element.closest(".field").hide();
            this.form.SdRate.element.closest(".field").hide();
            this.form.SdAmount.element.closest(".field").hide();

            //VAT hide
            this.form.CoaVatId.element.closest(".field").hide();
            this.form.VatType.element.closest(".field").hide();
            this.form.VatRate.element.closest(".field").hide();
            this.form.VatAmount.element.closest(".field").hide();

            //TAX hide
            this.form.CoaTaxId.element.closest(".field").hide();
            this.form.TaxType.element.closest(".field").hide();
            this.form.TaxRate.element.closest(".field").hide();
            this.form.TaxAmount.element.closest(".field").hide();
        }

        protected isCheckBankHead_Change() {
            //console.log(this.form.CoaDebitHeadId.value);
            if (this.form.CoaDebitHeadId.value == "") {
                //console.log(this.form.CoaDebitHeadId.value);
            }
            else {
                var selectedItem = Configurations.AccChartofAccountsRow.getLookup().itemById[this.form.CoaDebitHeadId.value];

                //console.log('change keyup blur');
            }
        }

        //SD amount
        protected calculate_SDAmount() {
            this.form.SdAmount.value = null;
            if (this.form.Amount.value > 0 && this.form.SdRate.value > 0) {
                this.form.SdAmount.value = (this.form.Amount.value * this.form.SdRate.value) / 100;
            }
        }

        //VAT amount
        protected calculate_VATAmount() {
            this.form.VatAmount.value = null;
            if (this.form.Amount.value > 0 && this.form.VatRate.value > 0) {
                this.form.VatAmount.value = (this.form.Amount.value * this.form.VatRate.value) / 100;
            }
        }

        //TAX amount
        protected calculate_TAXAmount() {
            this.form.TaxAmount.value = null;
            if (this.form.Amount.value > 0 && this.form.TaxRate.value > 0) {
                this.form.TaxAmount.value = (this.form.Amount.value * this.form.TaxRate.value) / 100;
            }
        }

        protected onDialogOpen(): void {
            //  var id = Q.first(Transaction.AccVoucherTemplateRow.getLookup().items, x => x.Id == this.entityId).Id;
            this.dialogTitle = "Voucher Issue Using Template";
            Transaction.AccVoucherTemplateService.Retrieve({
                EntityId: this.entityId
            }, response => {
                this.setTemplateDetails(response.Entity);
            });
            this.items_ChartofAccounts = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;
        }

        private setTemplateDetails(details: Transaction.AccVoucherTemplateRow) {

            //load Template by transationtypeId
            var items = this.items_VoucherTemplate.filter(f => f.TransactionTypeId == details.TransactionTypeId);
            this.form.TemplateName.clearItems();
            for (var item of items) {
                this.form.TemplateName.addItem({ id: item.TemplateName, text: item.TemplateName, source: null, disabled: false });
            }
            this.form.CoaDebitHeadId.value = details.CoaDebitHeadId.toString();
            this.form.CoaCreditHeadId.value = details.CoaCreditHeadId.toString();

            //Dr. Cheque No.
            if (details.IsDebitHeadCheque) {
                this.form.IsDebitHeadCheque.element.closest(".field").hide();
                this.form.DebitHeadChequeId.element.closest(".field").show();
            }
            else {
                this.form.IsDebitHeadCheque.element.closest(".field").hide();
                this.form.DebitHeadChequeId.element.closest(".field").hide();
            }

            //Cr. Cheque No.
            if (details.IsCreditHeadCheque) {
                this.form.IsCreditHeadCheque.element.closest(".field").hide();
                this.form.CreditHeadChequeId.element.closest(".field").show();
            }
            else {
                this.form.IsCreditHeadCheque.element.closest(".field").hide();
                this.form.CreditHeadChequeId.element.closest(".field").hide();
            }

            //bill ref no
            if (details.IsBillReference) {
                this.form.IsBillReference.element.closest(".field").hide();
                this.form.BillReferenceNo.element.closest(".field").show();
            }
            else {
                this.form.IsBillReference.element.closest(".field").hide();
                this.form.BillReferenceNo.element.closest(".field").hide();
            }

            //hide/show costcenter
            if (details.IsCostCenter) {
                this.form.IsCostCenter.element.closest(".field").hide();
                this.form.CostCenterId.element.closest(".field").show();
            }
            else {
                this.form.IsCostCenter.element.closest(".field").hide();
                this.form.CostCenterId.element.closest(".field").hide();
            }

            //hide/show security Depoist
            if (details.IsSd) {
                this.form.IsSd.element.closest(".field").hide();
                this.form.CoaSdId.element.closest(".field").show();
                this.form.SdType.element.closest(".field").show();
                this.form.SdRate.element.closest(".field").show();
            }
            else {
                this.form.IsSd.element.closest(".field").hide();
                this.form.CoaSdId.element.closest(".field").hide();
                this.form.SdType.element.closest(".field").hide();
                this.form.SdRate.element.closest(".field").hide();
                this.form.SdAmount.element.closest(".field").hide();
                $($('.s-Transaction-AccVoucherTemplateVoucherIssueDialog .category')[2]).hide();
            }

            //hide/show vat
            if (details.IsVat) {
                this.form.IsVat.element.closest(".field").hide();
                this.form.CoaVatId.element.closest(".field").show();
                this.form.VatType.element.closest(".field").show();
                this.form.VatRate.element.closest(".field").show();
            }
            else {
                this.form.IsVat.element.closest(".field").hide();
                this.form.CoaVatId.element.closest(".field").hide();
                this.form.VatType.element.closest(".field").hide();
                this.form.VatRate.element.closest(".field").hide();
                this.form.VatAmount.element.closest(".field").hide();
                $($('.s-Transaction-AccVoucherTemplateVoucherIssueDialog .category')[3]).hide();
            }

            //hide/show TAX
            if (details.IsTax) {
                this.form.IsTax.element.closest(".field").hide();
                this.form.CoaTaxId.element.closest(".field").show();
                this.form.TaxType.element.closest(".field").show();
                this.form.TaxRate.element.closest(".field").show();
            }
            else {
                this.form.IsTax.element.closest(".field").hide();
                this.form.CoaTaxId.element.closest(".field").hide();
                this.form.TaxType.element.closest(".field").hide();
                this.form.TaxRate.element.closest(".field").hide();
                this.form.TaxAmount.element.closest(".field").hide();
                $($('.s-Transaction-AccVoucherTemplateVoucherIssueDialog .category')[4]).hide();
            }

        }

    }
}