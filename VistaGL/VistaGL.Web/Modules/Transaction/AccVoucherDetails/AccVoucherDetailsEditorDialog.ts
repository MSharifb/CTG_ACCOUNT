
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherDetailsEditorDialog extends GridEditorDialog<AccVoucherDetailsRow> {
        protected getFormKey() { return AccVoucherDetailsForm.formKey; }
        protected getLocalTextPrefix() { return AccVoucherDetailsRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherDetailsRow.nameProperty; }
        protected form = new AccVoucherDetailsForm(this.idPrefix);

        protected items_ChartofAccounts: Configurations.AccChartofAccountsRow[];// Configurations.AccChartofAccountsRow.getLookup().items;
        public _TransactionMode: string;
        public _VoucherTypeId: string;
        protected timeLoad;

        protected Amount = 0.00;

        protected onDialogClose() {
            super.onDialogClose();
            clearInterval(this.timeLoad);
        }

        protected onDialogOpen() {
            super.onDialogOpen();

            //   this.items_ChartofAccounts = this.items_ChartofAccounts.filter(f => f.IsControlhead == 0);

            //for (var i = 0; i < this.items_ChartofAccounts.length; i++) {
            //    var str = this.items_ChartofAccounts[i];

            //    //  var c = distinct_axes2.filter(p => p.CoaId == str.CoaId);

            //    //   if (c.length < 1) {
            //    //     distinct_axes2.push(str);
            //    this.form.ChartofAccountsId.addItem({ id: str.Id.toString(), text: str.AccountName, source: null, disabled: false });

            //    // }
            //}

            this.form.ConversionRate.element.hide();
            this.form.ConversionAmount.element.hide();

            let parentDialog = (this.parentEditor.parentDialog as AccVoucherInformationDialog);

            this.items_ChartofAccounts = parentDialog.items_ChartofAccounts;
            this.form.ChartofAccountsId.items = parentDialog.form.AccountHead.items;
            this._TransactionMode = parentDialog.form.TransactionMode.value;
            this._VoucherTypeId = parentDialog.form.VoucherTypeId.value;

            if (this._VoucherTypeId != VoucherType.Journal_Voucher.toString()) // added for adjustment only
                $('.AdjustedChequeRegisterId').hide();

            if (this.isNew()) {

                this.form.ChartofAccountsId.value = parentDialog.form.AccountHead.value;
                this.form.ConversionRate.value = parentDialog.form.ConversionRate.value;
                this.form.CreditAmount.value = parentDialog.form.CreditAmount.value;
                this.form.DebitAmount.value = parentDialog.form.DebitAmount.value;
                // this.entity.ChartofAccountsAccountName = parentDialog.form.AccountHead.get_text();
                this.form.Description.value = parentDialog.form.DDescription.value;
                this.form.VoucherDtlAllocation.value = parentDialog._VoucherDtlAllocation;
                this.form.ConversionAmount.value = parentDialog.form.ConversionAmount.value;
            }

            if (this.form.DebitAmount.value > 0) {
                this.form.VoucherDtlAllocation.isDrCr = "Dr";
            } else {
                this.form.VoucherDtlAllocation.isDrCr = "Cr";
            }

            var Check_AccHead = parentDialog.items_ChartofAccounts.filter(p => p.Id == +this.form.ChartofAccountsId.value)[0];

            // if (parentDialog._IsCostCenterAllocate == 1) {
            if (Check_AccHead.IsCostCenterAllocate == 1) {

                this.timeLoad = setInterval(p => {

                    this.Amount = 0.00;
                    var SDetailsPush = this.form.VoucherDtlAllocation.getItems();
                    for (var item of SDetailsPush) {
                        this.Amount = this.Amount + item.Amount;
                    }

                    if (this.form.CreditAmount.value.toString() == "" || this.form.CreditAmount.value == 0.00) {
                        this.form.DebitAmount.value = this.Amount;
                    }
                    else {
                        this.form.CreditAmount.value = this.Amount;
                    }

                }, 500);

                Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), true);
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), true);

                this.form.VoucherDtlAllocation.element.show();
                $('.VoucherDtlAllocation .caption').show();
            }
            else {
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), false);
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), false);

                this.form.VoucherDtlAllocation.element.hide();
                $('.VoucherDtlAllocation .caption').hide();
            }

            //    if (parentDialog._IsBillRef == 1)
            if (Check_AccHead.IsBillRef == 1) {
                this.form.VoucherDtlBillRef.element.show();
                $('.VoucherDtlBillRef .caption').show();
            }
            else {
                this.form.VoucherDtlBillRef.element.hide();
                $('.VoucherDtlBillRef .caption').hide();
            }

            this.FocusDrCr(parentDialog.form.VoucherTypeId.value, Check_AccHead.CoaMapping);

            if (Check_AccHead.CoaMapping == "BANK") {
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), false);
            } else {
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), true);
            }

            this.form.ChartofAccountsId.changeSelect2(p => {
                var Check_AccHead = parentDialog.items_ChartofAccounts.filter(f => f.Id == +this.form.ChartofAccountsId.value);

                if (Check_AccHead[0].CoaMapping == "BANK") {
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), false);
                    var _AccChequeRegister = parentDialog.AccChequeRegister.filter(p => p.BankAccountInformationCoaId == +this.form.ChartofAccountsId.value);

                    this.form.ChequeRegisterId.clearItems();
                    for (var item of _AccChequeRegister) {
                        //  var str = items[i];
                        this.form.ChequeRegisterId.addItem({ id: item.Id.toString(), text: item.ChequeNo, source: null, disabled: false });
                    }

                } else {
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), true);
                }

                if (Check_AccHead[0].IsCostCenterAllocate == 1) {
                    this.form.VoucherDtlAllocation.element.show();
                    $('.VoucherDtlAllocation .caption').show();
                } else {
                    this.form.VoucherDtlAllocation.element.hide();
                    $('.VoucherDtlAllocation .caption').hide();

                }

                if (Check_AccHead[0].MultiCurrencyCurrency == null) {

                    //   this.form.MultiCurrency.value = "Taka";
                    this.form.ConversionRate.value = 1;
                    //  $("#lbConversionRate").text("Taka");
                }
                else {
                    //  this.form.MultiCurrency.value = Check_AccHead[0].MultiCurrencyCurrency;

                    var MultiCurrency_amount = parentDialog.items_CurrencyConversionRate.filter(f => f.FirstCurrency == Check_AccHead[0].MultiCurrencyId);
                    this.form.ConversionRate.value = MultiCurrency_amount[0].SecondAmout;
                    //  $("#lbConversionRate").text(MultiCurrency_amount[0].SecondCurrencyCurrency);

                }

                this.FocusDrCr(parentDialog.form.VoucherTypeId.value, Check_AccHead[0].CoaMapping);

                if (parentDialog.form.VoucherTypeId.value == VoucherType.Journal_Voucher.toString()) {

                    var _AccTransactionTypeAssign = parentDialog.AccTransactionTypeAssign.filter(p => p.CoaId == +this.form.ChartofAccountsId.value && p.ParentId == +parentDialog.form.TransactionTypeEntityId.value);

                    if (_AccTransactionTypeAssign.length > 0) {
                        //
                        if (_AccTransactionTypeAssign[0].TrType == "C") {
                            this.form.CreditAmount.element.focus();
                            (this.form.CreditAmount.element[0] as any).setSelectionRange(0, 100);
                        } else {
                            this.form.DebitAmount.element.focus();
                            (this.form.DebitAmount.element[0] as any).setSelectionRange(0, 100);
                        }
                    }
                }

            });

            this.form.CreditAmount.change(p => {
                this.form.ConversionAmount.value = this.form.ConversionRate.value * this.form.CreditAmount.value;
            });

            this.form.CreditAmount.element.focusout(() => {
                //
                if (this.form.CreditAmount.value > 0) {
                    this.form.DebitAmount.value = 0;
                    this.form.VoucherDtlAllocation.isDrCr = "Cr";
                }
            });

            this.form.DebitAmount.change(p => {
                this.form.ConversionAmount.value = this.form.ConversionRate.value * this.form.DebitAmount.value;
            });

            this.form.DebitAmount.element.focusout(() => {
                //
                if (this.form.DebitAmount.value > 0) {
                    this.form.CreditAmount.value = 0;
                    this.form.VoucherDtlAllocation.isDrCr = "Dr";
                }
            });

            this.form.ConversionRate.change(p => {
                this.form.ConversionAmount.value = this.form.ConversionRate.value * (this.form.DebitAmount.value + this.form.CreditAmount.value);
            });


        }

        protected FocusDrCr(VoucherTypeId, CoaMapping) {
            if (VoucherTypeId == VoucherType.Payment_Voucher.toString()) {

                if (CoaMapping == "BANK" || CoaMapping == "CASH") {
                    //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), true);
                    //Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), false);
                    // this.form.DebitAmount.value = 0;
                    this.form.CreditAmount.element.focus();

                    (this.form.CreditAmount.element[0] as any).setSelectionRange(0, 100);
                } else {
                    //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), false);
                    //Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), true);
                    // this.form.CreditAmount.value = 0;
                    this.form.DebitAmount.element.focus();
                    (this.form.DebitAmount.element[0] as any).setSelectionRange(0, 100);
                }
            } else if (VoucherTypeId == VoucherType.Receipt_Voucher.toString()) {
                if (CoaMapping == "BANK" || CoaMapping == "CASH") {
                    //Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), true);
                    //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), false);
                    // this.form.CreditAmount.value = 0;
                    this.form.DebitAmount.element.focus();
                    (this.form.DebitAmount.element[0] as any).setSelectionRange(0, 100);
                } else {
                    //Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), false);
                    //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), true);
                    //this.form.DebitAmount.value = 0;
                    this.form.CreditAmount.element.focus();
                    (this.form.CreditAmount.element[0] as any).setSelectionRange(0, 100);
                }
            }
        }

        protected getSaveEntity() {
            var entity = super.getSaveEntity();

            let vouDtlAll = entity.VoucherDtlAllocation;
            let tempCostCenterName = '';
            for (let i = 0; i < vouDtlAll.length; i++) {
                let tempVouDtl = vouDtlAll[i];
                tempCostCenterName += tempVouDtl.CostCenterName + ', ';
            }
            //   entity.ChartofAccountsAccountName = this.form.ChartofAccountsId.itemById[this.form.ChartofAccountsId.value].text;
            entity.ChartofAccountsAccountName = this.form.ChartofAccountsId.get_text() + ' (' + tempCostCenterName + ')';

            return entity;
        }

        protected validateBeforeSave() {
            if (this._TransactionMode == "") {
                Q.warning("Please select Transaction Mode.");
                return false;
            }

            if (this.form.ChartofAccountsId.value == "") {
                Q.warning("Please select Account Head.");
                return false;
            }

            if ((this.form.DebitAmount.value.toString() == "NaN" && this.form.CreditAmount.value.toString() == "NaN")
                || (this.form.DebitAmount.value <= 0 && this.form.CreditAmount.value <= 0)) {
                Q.warning("Please enter Debit or Credit Amount 1.");
                return false;
            }

            if (this.form.DebitAmount.value > 0 && this.form.CreditAmount.value > 0) {
                Q.warning("Please enter Debit or Credit Amount 2.");
                return false;
            }

            var Check_AccHead = this.items_ChartofAccounts.filter(f => f.Id == +this.form.ChartofAccountsId.value);
            var _amount = 0;
            var _Damount = 0;
            var _Camount = 0;

            if (Check_AccHead[0].CoaMapping == undefined) {

                if (this._VoucherTypeId == VoucherType.Payment_Voucher.toString()) {
                    //if (this.form.DebitAmount.value.toString() == "NaN" || this.form.DebitAmount.value <= 0) {
                    //    Q.warning("Credit Amount for Bank or Cash Head.");
                    //    return false;
                    //}
                    //else {
                    _amount = this.form.DebitAmount.value;
                    _Damount = this.form.DebitAmount.value;
                    //}
                }
                else if (this._VoucherTypeId == VoucherType.Receipt_Voucher.toString()) {
                    //if (this.form.CreditAmount.value.toString() == "NaN" || this.form.CreditAmount.value <= 0) {
                    //    Q.warning("Debit Amount for Bank or Cash Head.");
                    //    return false;
                    //}
                    //else {
                    _amount = this.form.CreditAmount.value;
                    _Camount = this.form.CreditAmount.value;
                    //}
                }
                else if (this._VoucherTypeId == VoucherType.Journal_Voucher.toString()) {
                    _amount = this.form.DebitAmount.value;
                    if (_amount == 0) {
                        _amount = this.form.CreditAmount.value;
                        _Damount = this.form.DebitAmount.value;
                        _Camount = this.form.CreditAmount.value;
                    }

                }
                else if (this._VoucherTypeId == VoucherType.Transfer_Voucher.toString()) {
                    _amount = this.form.DebitAmount.value;
                    if (_amount == 0) {
                        _amount = this.form.CreditAmount.value;
                        _Damount = this.form.DebitAmount.value;
                        _Camount = this.form.CreditAmount.value;
                    }

                }

            }
            else {

                if (this._TransactionMode == "BANK" && Check_AccHead[0].CoaMapping != "BANK") {
                    //  if (Check_AccHead[0].CoaMapping != "BANK") {
                    Q.warning("Please select Bank Head.");
                    return false;
                    // }
                }
                if (this._TransactionMode == "BANK" && Check_AccHead[0].CoaMapping != "BANK") {
                    //  if (Check_AccHead[0].CoaMapping != "BANK") {
                    Q.warning("Please select Cash Head.");
                    return false;
                    // }
                }

                if (this._VoucherTypeId == VoucherType.Payment_Voucher.toString()) { // VoucherTypeId 1= Payment Voucher
                    //if (this.form.CreditAmount.value.toString() == "NaN" || this.form.CreditAmount.value <= 0) {
                    //    Q.warning("Credit Amount for Bank or Cash Head.");
                    //    return false;
                    //} else {
                    _amount = this.form.CreditAmount.value;
                    _Camount = this.form.CreditAmount.value;
                    //}
                }
                else if (this._VoucherTypeId == VoucherType.Receipt_Voucher.toString()) { // VoucherTypeId 2= Receive Voucher
                    //if (this.form.DebitAmount.value.toString() == "NaN" || this.form.DebitAmount.value <= 0) {
                    //    Q.warning("Debit Amount for Bank or Cash Head.");
                    //    return false;
                    //} else {
                    _amount = this.form.DebitAmount.value;
                    _Damount = this.form.DebitAmount.value;
                    //}
                }
                else if (this._VoucherTypeId == VoucherType.Journal_Voucher.toString()) {
                    _amount = this.form.DebitAmount.value;
                    if (_amount == 0) {
                        _amount = this.form.CreditAmount.value;
                        _Damount = this.form.DebitAmount.value;
                        _Camount = this.form.CreditAmount.value;
                    }

                }
                else if (this._VoucherTypeId == VoucherType.Transfer_Voucher.toString()) {
                    _amount = this.form.DebitAmount.value;
                    if (_amount == 0) {
                        _amount = this.form.CreditAmount.value;
                        _Damount = this.form.DebitAmount.value;
                        _Camount = this.form.CreditAmount.value;
                    }

                }
            }

            if (Check_AccHead[0].IsCostCenterAllocate == 1) {
                var _cItems = this.form.VoucherDtlAllocation.getItems();

                if (_cItems.length > 1) {
                    Q.alert("Only one Sub-ledger allocation is allowed!");
                    return false;
                }

                if (_cItems.length == 0) {
                    Q.alert("Please add Sub-ledger!");
                    return false;
                }
                else {
                    var _totalCostCenterAmount = 0;

                    for (var c_item of _cItems) {
                        _totalCostCenterAmount += c_item.Amount;
                    }
                }

            }
            this.form.CCreditAmount.value = this.form.CreditAmount.value * this.form.ConversionRate.value;
            this.form.CDebitAmount.value = this.form.DebitAmount.value * this.form.ConversionRate.value;


            if (Check_AccHead[0].AccountGroup == "Assets" || Check_AccHead[0].AccountGroup == "Expense") {
                this.form.EffectiveValue.value = _Damount - _Camount;
            } else { this.form.EffectiveValue.value = _Camount - _Damount; }

            return true;
        }
    }
}