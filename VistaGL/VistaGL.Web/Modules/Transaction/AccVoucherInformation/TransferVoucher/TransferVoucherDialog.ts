
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TransferVoucherDialog extends EntityDialogBase<AccVoucherInformationRow, any> {
        protected getFormKey() { return TransferVoucherForm.formKey; }
        protected getIdProperty() { return AccVoucherInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherInformationRow.nameProperty; }
        protected getService() { return AccVoucherInformationService.baseUrl; }

        public form = new TransferVoucherForm(this.idPrefix);
        public items_ChartofAccounts: Configurations.AccChartofAccountsRow[];// Configurations.AccChartofAccountsRow.getLookup().items;
        //public items_CurrencyConversionRate = Configurations.AccCurrencyConversionRateRow.getLookup().items;
        //public AccChequeRegister = AccChequeRegisterRow.getLookup().items;
        //public AccTransactionTypeAssign = AccTransactionTypeAssignRow.getLookup().items;
        public _VoucherConfiguration = Transaction.AccVoucherConfigurationRow.getLookup().items;
        public _AccountingPeriod = Configurations.AccAccountingPeriodInformationRow.getLookup().items;
        protected nextId = 1;
        protected isFristTime = true;
        public _IsCostCenterAllocate = 0;
        public _IsBillRef = 0;
        //public _VoucherDtlAllocation: AccVoucherDtlAllocationRow[];
        constructor() {
            super();
            $('.ui-dialog-titlebar-maximize').click();
            //Generate button
            var fieldButt = $('.AddtoGrid')[0];
            fieldButt.innerHTML = `<label class="caption" title=""></label>
                <a href= "javascript:;" class="btn btn-default groupAdd"> <i class="fa fa-fw fa-plus-circle"> </i>Add to Grid</a>
            `;

            //var _fieldButt = $('#ga0')[0];
            //fieldButt.appendChild(_fieldButt);

            // var fieldButt1 = $('.MultiCurrency')[0];
            //fieldButt1.innerHTML = `<label class="caption" id="lbMultiCurrency" title=""></label>`;
            //$("#lbMultiCurrency").text("fff");

            //this.form.VoucherNo.element.on('keyup', (e) => {
            //    // only auto number when a key between 'A' and 'Z' is pressed
            //    if (e.which >= 65 && e.which <= 90)
            //        this.setNewVoucherNumber();
            //});

        }

        protected AddtoGrid() {
            //if (this.form.TransactionMode.value == "") {
            //    //   Q.alert("Please select Transaction Mode.");
            //    Q.warning("Please select Transaction Mode.");
            //    return;
            //}

            if (this.form.AccountHeadFrom.value == "") {
                Q.warning("Please select Account From Head.");
                return;
            }
            if (this.form.AccountHeadTo.value == "") {
                Q.warning("Please select Account To Head.");
                return;
            }
            //if ((this.form.DebitAmount.value.toString() == "NaN" && this.form.CreditAmount.value.toString() == "NaN")
            //    || (this.form.DebitAmount.value <= 0 && this.form.CreditAmount.value <= 0)) {
            //    Q.warning("Please enter Debit or Credit Amount 1.");
            //    return;
            //}

            if (this.form.TransferAmount.value < 1) {
                Q.warning("Please Transfer Amount.");
                return;
            }

            //var Check_AccHead = this.items_ChartofAccounts.filter(f => f.Id == +this.form.AccountHead.value);
            //var _amount = 0;
            //var _Damount = 0;
            //var _Camount = 0;
            //this._IsBillRef = Check_AccHead[0].IsBillRef;
            //this._IsCostCenterAllocate = Check_AccHead[0].IsCostCenterAllocate;


            if (this.form.AccountHeadFrom.value == this.form.AccountHeadTo.value) {
                Q.alert('duplicate!');
                return;
            }
            var _items = this.form.VoucherDetails.getItems();

            //var sameProduct = Q.tryFirst(_items, x => x.ChartofAccountsId === +this.form.AccountHead.value);
            //if (sameProduct) {
            //    Q.alert('This Chart of Accounts is already in voucher!');
            //    return;
            //}


            //this._VoucherDtlAllocation = [];



            var _details: AccVoucherDetailsRow;
            _details = {};
            _details.ChartofAccountsAccountName = this.form.AccountHeadFrom.get_text(),
                _details.ChartofAccountsId = +this.form.AccountHeadFrom.value;
            _details.CreditAmount = this.form.TransferAmount.value;
            _details.DebitAmount = 0;
            _details.CCreditAmount = this.form.TransferAmount.value;
            _details.CDebitAmount = 0;
            _details.Description = this.form.DDescription.value;

            _items.push(_details);

            _details = {};
            _details.ChartofAccountsAccountName = this.form.AccountHeadTo.get_text(),
                _details.ChartofAccountsId = +this.form.AccountHeadTo.value;
            _details.CreditAmount = 0;
            _details.DebitAmount = this.form.TransferAmount.value;
            _details.CCreditAmount = 0;
            _details.CDebitAmount = this.form.TransferAmount.value;
            _details.Description = this.form.DDescription.value;
            _items.push(_details);

            for (var item of _items) {
                var id = (item as any).__id;
                if (id == null) {
                    (item as any).__id = this.nextId++;
                }
            }
            this.form.DAmount.value = this.form.TransferAmount.value;
            this.form.CAmount.value = this.form.TransferAmount.value;
            this.form.VoucherDetails.setItems(_items);
            this.form.Amount.value = this.form.TransferAmount.value;
            this.form.AmountInWords.value = this.toWords(this.form.TransferAmount.value);
            this.ClearData();
            $('.groupAdd').toggleClass("disabled");
        }

        onDialogOpen(): void {
            super.onDialogOpen();
            //q.initDetailEditor(this, this.form.VoucherDetails);

            //this.form.VoucherDetails.parentDialog = this;

            this.items_ChartofAccounts = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;
            $('.VoucherDetails .grid-toolbar').hide();
            //  $('.MultiCurrency .caption').hide();
            $('.groupAdd').click(e => this.AddtoGrid());


            var fieldAccountHeadFrom = $('.AccountHeadFrom .caption')[0];
            var fieldAccountHeadTo = $('.AccountHeadTo .caption')[0];
            fieldAccountHeadTo.innerHTML = `<sup title="this field is required">*</sup>Bank Acc. (To)`;
            fieldAccountHeadFrom.innerHTML = `<sup title="this field is required">*</sup>Bank Acc. (From)`;

            this.form.TransactionType.value = "PAYMENT";
            this.form.TransactionMode.value = "Other";
            this.form.VoucherType.value = "Debit";
            this.form.VoucherTypeId.value = "4";
            this.form.TransactionTypeEntityId.value = this.form.TransactionTypeEntityId.items[0].id;
            this.getNextNumber();

            this.form.TransferType.change(p => {
                var fieldAccountHeadFrom = $('.AccountHeadFrom .caption')[0];
                var fieldAccountHeadTo = $('.AccountHeadTo .caption')[0];
                var CoaMappingF = "BANK";
                var CoaMappingT = "BANK";
                if (this.form.TransferType.value == "1") {
                    CoaMappingF = "BANK";
                    CoaMappingT = "CASH";
                    fieldAccountHeadTo.innerHTML = `<sup title="this field is required">*</sup>Cash (To)`;
                    fieldAccountHeadFrom.innerHTML = `<sup title="this field is required">*</sup>Bank Acc. (From)`;

                } else if (this.form.TransferType.value == "2") {
                    CoaMappingF = "CASH";
                    CoaMappingT = "BANK";
                    fieldAccountHeadTo.innerHTML = `<sup title="this field is required">*</sup>Bank Acc. (To)`;
                    fieldAccountHeadFrom.innerHTML = `<sup title="this field is required">*</sup>Cash (From)`;
                } else {
                    fieldAccountHeadTo.innerHTML = `<sup title="this field is required">*</sup>Bank Acc. (To)`;
                    fieldAccountHeadFrom.innerHTML = `<sup title="this field is required">*</sup>Bank Acc. (From)`;
                }
                var itemsFrom = this.items_ChartofAccounts.filter(f => f.IsControlhead == 0 && f.CoaMapping == CoaMappingF);
                var itemsTo = this.items_ChartofAccounts.filter(f => f.IsControlhead == 0 && f.CoaMapping == CoaMappingT);
                this.form.AccountHeadFrom.value = "";
                this.form.AccountHeadFrom.clearItems();
                for (var itemFrom of itemsFrom) {
                    this.form.AccountHeadFrom.addItem({ id: itemFrom.Id.toString(), text: itemFrom.AccountName, source: null, disabled: false });
                }
                this.form.AccountHeadTo.value = "";
                this.form.AccountHeadTo.clearItems();
                for (var itemTo of itemsTo) {
                    this.form.AccountHeadTo.addItem({ id: itemTo.Id.toString(), text: itemTo.AccountName, source: null, disabled: false });
                }

            });

            if (!this.isNew()) {
                $('.groupAdd').toggleClass("disabled");

                var dAmount = 0;
                var cAmount = 0;

                for (var i of this.form.VoucherDetails.value) {

                    if (i.CreditAmount != undefined)
                        cAmount += i.CreditAmount;
                    if (i.DebitAmount != undefined)
                        dAmount += i.DebitAmount;
                }

                this.form.DAmount.value = dAmount;
                this.form.CAmount.value = cAmount;

            }
            this.set_dialogTitle("Contra/Transfer Voucher");
        }

        protected ClearData() {
            this.form.AccountHeadFrom.value = null;
            this.form.AccountHeadTo.value = null;

            this.form.TransferAmount.value = 0;
            this.form.DDescription.value = "";

        }

        protected getSaveEntity() {

            var _entity = super.getSaveEntity();

            var _vc = this._VoucherConfiguration.filter(p => p.FundControlInformationId == Authorization.userDefinition.FundControlInformationId && p.TransactionTypeId == +this.form.TransactionTypeEntityId.value);
            if (_vc.length > 0) {
                if (_vc[0].IsAutoPost) {
                    _entity.PostingDate = this.form.VoucherDate.value;
                    _entity.PostedBy = Authorization.userDefinition.EmpId.toString();
                    _entity.PostToLedger = 1;
                }
            }
            //  var entites = this.form.VoucherDetails.getItems;
            var entites = _entity.VoucherDetails;
            _entity.VoucherDetails = [];
            //   console.log(entites);

            var items = entites.map<AccVoucherDetailsRow>((v, i, a) => {
                return {
                    ChartofAccountsId: v.ChartofAccountsId,
                    DebitAmount: v.DebitAmount,
                    CreditAmount: v.CreditAmount,
                    Description: v.Description,
                    EffectiveValue: v.EffectiveValue,
                    CCreditAmount: v.CCreditAmount,
                    CDebitAmount: v.CDebitAmount,

                };
            })
            // console.log(items);
            _entity.VoucherDetails = items;

            return _entity;
        }

        private getNextNumber() {


            this.form.VoucherNo.value = "";
            this.form.VoucherNumber.value = "";

            let fundControlId: number;
            let zoneId: number;
            var userinfo = Authorization.userDefinition;
            fundControlId = userinfo.FundControlInformationId;
            zoneId = userinfo.ZoneID;

            var voucherDate = new Date(this.form.VoucherDate.value);
            var _VoucherDate = this.form.VoucherDate.valueAsDate;
            var _piriod = this._AccountingPeriod.filter(j => _VoucherDate >= Q.parseISODateTime(j.PeriodStartDate)
                                                            && _VoucherDate <= Q.parseISODateTime(j.PeriodEndDate));

            if (_piriod.length == 0) {
                Q.alert("Accounting Period not found.");
            }
            else {
                this.form.PostingFinancialYearId.value = _piriod[0].Id.toString();
                var financialYearId: number = +this.form.PostingFinancialYearId.value;
                var transactionTypeId: number = +this.form.TransactionTypeEntityId.value;

                var bankAccId = 0;

                VoucherUtil.newVoucherNumberFactory(this._VoucherConfiguration, transactionTypeId, voucherDate, financialYearId, fundControlId, zoneId, bankAccId, (_voucherNo, _voucherNumber) => {
                    //
                    $('.VoucherNo input').val(_voucherNo);
                    $('.VoucherNumber input').val(_voucherNumber);
                });
            }


            ////   var val = Q.trimToNull(this.form.VoucherNo.value);


            //// we will only get next number when customer ID is empty or 1 character in length
            //// if (!val || val.length <= 1) {
            //this.form.VoucherNo.value = "";
            //this.form.VoucherNumber.value = "";
            //var _vc = this._VoucherConfiguration.filter(p => p.FundControlInformationId == Authorization.userDefinition.FundControlInformationId && p.TransactionTypeId == +this.form.TransactionTypeEntityId.value);
            ////  console.log(_vc);
            //if (_vc.length > 0) {
            //    // if no customer ID yet (new record mode probably) use 'C' as a prefix
            //    var prefix = '';//(val || 'C').toUpperCase();

            //    // call our service, see CustomerEndpoint.cs and CustomerRepository.cs
            //    AccVoucherInformationService.GetNextNumber({
            //        Prefix: prefix,
            //        TransactionTypeId: +this.form.TransactionTypeEntityId.value,
            //        Length: _vc[0].NumberLength, // we want service to search for and return serials of 5 in length
            //        StartingNumber: _vc[0].StartingNumber,
            //        FundControlInformationId: fundControlId,
            //        ZoneID: zoneId,
            //        IsMonthWiseNewNumber: _vc[0].NewNumber
            //    }, response => {
            //        var _Prefix = '';
            //        if (_vc[0].Prefix != undefined)
            //            _Prefix = _vc[0].Prefix + _vc[0].Separators

            //        var _Suffix = '';
            //        if (_vc[0].Suffix != undefined)
            //            _Suffix = _vc[0].Separators + _vc[0].Suffix;

            //        var _AccountingPeriodYearName = '';
            //        if (_vc[0].AccountingPeriodYearName != undefined)
            //            _AccountingPeriodYearName = _vc[0].Separators + _vc[0].AccountingPeriodYearName;

            //        this.form.VoucherNo.value = _Prefix + response.Serial + _Suffix + _AccountingPeriodYearName;

            //        this.form.VoucherNumber.value = response.Serial;
            //        // this is to mark numerical part after prefix
            //        //  (this.form.VoucherNo.element[0] as any).setSelectionRange(prefix.length, response.Serial.length);
            //    });
            //}
            //else {
            //    Q.alert("Voucher Configuration not found.");
            //}
            ////  }
        }

        protected toWords(s) {

            //var th = ['', 'thousand', 'million', 'billion', 'trillion'];

            //var dg = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];

            //var tn = ['ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];

            //var tw = ['twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];
            var th = ['', 'Thousand', 'Million', 'Billion', 'Trillion'];

            var dg = ['Zero', 'One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine'];

            var tn = ['Ten', 'Eleven', 'Twelve', 'Thirteen', 'Fourteen', 'Fifteen', 'Sixteen', 'Seventeen', 'Eighteen', 'Nineteen'];

            var tw = ['Twenty', 'Thirty', 'Forty', 'Fifty', 'Sixty', 'Seventy', 'Eighty', 'Ninety'];

            s = s.toString();
            s = s.replace(/[\, ]/g, '');
            if (s != parseFloat(s)) return 'not a number';
            var x = s.indexOf('.');
            if (x == -1) x = s.length;
            if (x > 15) return 'too big';
            var n = s.split('');
            var str = '';
            var sk = 0;
            for (var i = 0; i < x; i++) {
                if ((x - i) % 3 == 2) {
                    if (n[i] == '1') {
                        str += tn[Number(n[i + 1])] + ' ';
                        i++;
                        sk = 1;
                    } else if (n[i] != 0) {
                        str += tw[n[i] - 2] + ' ';
                        sk = 1;
                    }
                } else if (n[i] != 0) {
                    str += dg[n[i]] + ' ';
                    if ((x - i) % 3 == 0) str += 'hundred ';
                    sk = 1;
                }
                if ((x - i) % 3 == 1) {
                    if (sk) str += th[(x - i - 1) / 3] + ' ';
                    sk = 0;
                }
            }
            if (x != s.length) {
                var y = s.length;
                str += 'point ';
                for (var i1 = x + 1; i1 < y; i1++) str += dg[n[i1]] + ' ';
            }
            return str.replace(/\s+/g, ' ');

        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push({
                title: "print", cssClass: "print-preview-button",

                onClick: (x) => {
                    if (this.entityId != undefined) {
                        //var b = (new VoucherPreviewDialog());
                        //var _url = Q.resolveUrl("~/Reports/VoucherPreview?id=" + this.entityId);
                        //b._url = _url;
                        //b.dialogOpen();

                        if (this.entity.LinkedWithAutoJV && this.entity.LinkedWithAutoJV != null) {
                            var _url = "~/Reports/VoucherPreview/IndexCombineVoucher?id=" + this.entityId + "&isCombineVoucher=" + true;
                        } else {
                            var _url = "~/Reports/VoucherPreview?id=" + this.entityId;
                        }
                        Q.postToUrl({ url: _url, params: {}, target: "_blank" });

                    } else {
                        Q.alert("Id not found.");
                    }
                }
            });

            return buttons;
        }
    }
}