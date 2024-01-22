
// ************************************
// CONTROLLER: FOR PAYMENT VOUCHER ONLY
// ************************************

namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    @Serenity.Decorators.maximizable()
    export class AccVoucherInformationDialog extends EntityDialogBase<AccVoucherInformationRow, any> {
        protected getFormKey() { return AccVoucherInformationForm.formKey; }
        protected getIdProperty() { return AccVoucherInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherInformationRow.nameProperty; }
        protected getService() { return AccVoucherInformationService.baseUrl; }

        public form = new AccVoucherInformationForm(this.idPrefix);
        public items_ChartofAccounts: Configurations.AccChartofAccountsRow[];// Configurations.AccChartofAccountsRow.getLookup().items;
        public items_CurrencyConversionRate = Configurations.AccCurrencyConversionRateRow.getLookup().items;
        public CheckAutoVoucher = false;
        public AccChequeRegister: AccChequeRegisterRow[];
        public AccChequeReceiveRegister: AccChequeReceiveRegisterRow[];

        public AccTransactionTypeAssign = AccTransactionTypeAssignRow.getLookup().items;
        public _VoucherConfiguration: AccVoucherConfigurationRow[];
        public _AccountingPeriod = Configurations.AccAccountingPeriodInformationRow.getLookup().items;
        protected nextId = 1;
        protected isFristTime = true;
        public _IsCostCenterAllocate = 0;
        public _IsBillRef = 0;
        public IsAutoPost = false;
        public _VoucherDtlAllocation: AccVoucherDtlAllocationRow[];

        protected baseCurrency: string;
        protected fundControlId: number;
        protected zoneId: number;
        protected userId: number;

        public transactionMode = "Other";
        protected selectedApproverId = 0;
        protected HeadId = 0;

        constructor() {
            super();

            var userinfo = Authorization.userDefinition;
            this.baseCurrency = userinfo.BaseCurrency;
            this.fundControlId = userinfo.FundControlInformationId;
            this.zoneId = userinfo.ZoneID;
            this.userId = userinfo.EmpId; // EmployeeId

            // Comments History //
            this.byId('ApplicationInformationHistory').closest('.field').hide().end().appendTo(this.byId('TabNotes'));
            //***

            //Generate button
            var fieldButt = $('.AddtoGrid')[0];
            fieldButt.innerHTML = `<label class="caption" title=""></label>
                <a href= "javascript:;" class="btn btn-default groupAdd"> <i class="fa fa-fw fa-plus-circle"> </i>Add to Grid</a>
            `;


            // added by Nazrul
            this.form.ChequeRegisterId.inplaceCreateClick = (() => {
                if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                    let accCheckRegDialog = new AccChequeRegisterDialog();
                    let entity_chequeRegister: AccChequeRegisterRow;
                    entity_chequeRegister = {};
                    entity_chequeRegister.ChequeIssueDate = this.form.VoucherDate.value;
                    entity_chequeRegister.ChequeDate = this.form.VoucherDate.value;
                    entity_chequeRegister.ChequeType = 'AccountPayee';
                    entity_chequeRegister.Remarks = this.form.AccountHead.value;
                    accCheckRegDialog.digforOnlyPayment = this;
                    accCheckRegDialog._isFromVoucher = true;
                    accCheckRegDialog._isPaymentOrReceiptVoucherOnly = true;
                    accCheckRegDialog.loadEntityAndOpenDialog(entity_chequeRegister);
                }
                else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                    let chequeRecRegDialog = new AccChequeReceiveRegisterDialog();
                    let entity_chequeRecRegister: AccChequeReceiveRegisterRow;
                    entity_chequeRecRegister = {};
                    entity_chequeRecRegister.ChequeReceiveDate = this.form.VoucherDate.value;
                    entity_chequeRecRegister.ChequeDate = this.form.VoucherDate.value;
                    entity_chequeRecRegister.ChequeType = 'AccountPayee';
                    chequeRecRegDialog.digforOnlyPayment = this;
                    chequeRecRegDialog._isFromVoucher = true;
                    chequeRecRegDialog._isPaymentOrReceiptVoucherOnly = true;

                    chequeRecRegDialog.loadEntityAndOpenDialog(entity_chequeRecRegister);
                }
            });


            //-- *****************************************************
            //-- Highlight caption label on focus of input control
            //-- *****************************************************

            $('input, textarea').on('blur',
                function () {
                    //
                    if ($(document.activeElement).hasClass('select2-offscreen')) {
                        // -- have written blur event for select2 below.
                    } else {
                        $("label[for='" + $(this).attr('id') + "']").removeClass('backColorofLabel');
                    }
                });

            $('input, textarea').on('focus', function () {
                //
                if ($(document.activeElement).hasClass('select2-offscreen')) {
                    // -- have written focus event for select2 below.
                } else {
                    //
                    $("label[for='" + $(document.activeElement).attr('id') + "']").addClass('backColorofLabel');

                    window.setTimeout(function () {
                        $(document.activeElement).select();
                    }, 0);
                }
            });

            $('.select2-offscreen').on('blur', function () {
                //
                $('label.backColorofLabel').each(function () {
                    $(this).removeClass('backColorofLabel');
                });

            });

            $('.select2-offscreen').on('focus', function () {
                //
                ($(this) as any).select2('open');

                if (($(this as any)).parent()[0].childNodes[0].nodeName == "LABEL") {
                    ($(this as any)).parent()[0].childNodes[0].attributes['class'].nodeValue = 'caption backColorofLabel';
                }

            });

            $('.select2-offscreen').on("select2-open",
                function () {
                    if (($(this as any)).parent()[0].childNodes[0].nodeName == "LABEL") {
                        ($(this as any)).parent()[0].childNodes[0].attributes['class'].nodeValue =
                            'caption backColorofLabel';
                    }
                });

            //----------************//


        }

        onDialogOpen(): void {
            super.onDialogOpen();

            // Maximize the dialog
            this.element.closest('.ui-dialog').find('.ui-dialog-titlebar-maximize').click();

            this.form.NOAId2.element.hide();
            this.form.NOAId.changeSelect2(e => {
                var data = AccNoaRow.getLookup().items.filter(f => f.Id = Number(this.form.NOAId.value));
                data.forEach(f => {
                    this.form.CostCentreId.value = f.CostCenterId.toString();
                });
            });
            q.initDetailEditor(this, this.form.VoucherDetails);

            this.form.VoucherDetails.parentDialog = this;

            this.form.ConversionRate.element.hide();
            this.form.ConversionAmount.element.hide();
            this.form.CostCenterTypeId.getGridField().hide();
            this.form.ParentId.getGridField().hide();
            this.form.FileNo.element.hide();
            this.form.PageNo.element.hide();

            this.items_ChartofAccounts = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;
            this._VoucherConfiguration = Q.getLookup('Transaction.AccVoucherConfiguration_Lookup').items;
            this.toolbar.findButton('MoneyReceipt').hide();
            var fieldpayToOrReceiveFrom = $('.PaytoOrReciveFrom .caption')[0];

            Serenity.EditorUtils.setReadonly(this.element.find(this.form.VoucherNo.element), true);

            // title change Voucher type wise
            if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                this.set_dialogTitle("Payment Voucher");
                this.AccChequeRegister = Q.getLookup('Transaction.AccChequeRegister_Lookup').items;
                fieldpayToOrReceiveFrom.innerHTML = `<sup title="this field is required">*</sup>Pay To`;

            } else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                this.set_dialogTitle("Receipt Voucher");
                this.AccChequeReceiveRegister = Q.getLookup('Transaction.AccChequeReceiveRegister_Lookup').items;

                fieldpayToOrReceiveFrom.innerHTML = `Receive From`;
                this.toolbar.findButton('MoneyReceipt').show();// toggleClass('disabled');
            }
            else if (this.form.VoucherTypeId.value == VoucherType.Journal_Voucher.toString()) {
                this.set_dialogTitle("Journal/Adjustment Voucher");

                this.form.PaytoOrReciveFrom.element.hide();
                $('.PaytoOrReciveFrom .caption').hide();
                this.form.NOAId.getGridField().hide();
                this.form.ChequeRegisterId.getGridField().hide();
            }

            // added by Nazrul
            //let subLedgerList = AccCostCentreOrInstituteInformationRow.getLookup().items;
            //for (var item of subLedgerList) {
            //    this.form.CostCentreId.addItem({ id: item.Id.toString(), text: item.Name, source: null, disabled: false });
            //}
            //

            $('.VoucherDetails .grid-toolbar').hide();
            $('.MultiCurrency .caption').hide();
            $('.groupAdd').click(e => this.addtoGrid());


            // $('.ConversionRate .editor').css("width", "200px !important").removeClass("editor");
            $('.ConversionRate .editor').removeClass("editor");
            var fieldButt1 = $('.ConversionRate')[0];
            var searchCreditInput: HTMLLabelElement;
            searchCreditInput = document.createElement('label');
            //  searchCreditInput.type = 'text';
            searchCreditInput.id = 'lbConversionRate';
            // searchCreditInput.style.width = '40%';
            //   var L = `<label class="caption" id="lbConversionRate" title=""></label>`;
            fieldButt1.appendChild(searchCreditInput);
            //  $("#lbConversionRate").text("fff");


            //Serenity.EditorUtils.setReadonly(this.element.find(this.form.MultipleCostCenter.element), true);
            this.form.ChequeRegisterId.clearItems();
            this.form.TransactionMode.changeSelect2(p => {
                this.transactionModeChange();
            });


            //this.form.VoucherTypeId.changeSelect2(p => {
            //    this.form.TransactionTypeEntityId.clearItems();
            //    var AccTransactionType = Configurations.AccTransactionTypeRow.getLookup().items.filter(p => p.VoucherTypeId == +this.form.VoucherTypeId.value);//.filter((v, i, a) => a.indexOf(v) === i);
            //    for (var item of AccTransactionType) {
            //        //  var str = items[i];
            //        this.form.TransactionTypeEntityId.addItem({ id: item.Id.toString(), text: item.TransactionType, source: null, disabled: false });
            //    }
            //})

            if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                this.form.TransactionType.value = "PAYMENT";
                this.form.VoucherType.value = "Debit";
            }
            else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                this.form.TransactionType.value = "RECEIPT";
                this.form.VoucherType.value = "Credit";
                //
            }
            else if (this.form.VoucherTypeId.value == VoucherType.Journal_Voucher.toString()) {
                this.form.TransactionType.value = "JOURNAL";
                this.form.VoucherType.value = "-";

                this.form.TransactionMode.value = "Other";
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.TransactionMode.element), true);
                //
            }

            this.form.AccountHead.clearItems();

            this.form.TransactionTypeEntityId.changeSelect2(p => {
                if (this.isNew()) {

                    this.setNewVoucherNumber();
                }

                this.loadAccountHead();
            });

            this.form.AccountHead.changeSelect2(p => {
                var Check_AccHead = this.items_ChartofAccounts.filter(f => f.Id == +this.form.AccountHead.value);

                if (Check_AccHead[0].IsCostCenterAllocate == 1) {
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.MultipleCostCenter.element), false);
                } else {
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.MultipleCostCenter.element), true);
                }

                this.setMultiCurrencyCurrency(Check_AccHead[0].MultiCurrencyCurrency, Check_AccHead[0].MultiCurrencyId, true);
                //var _currency = Authorization.userDefinition.BaseCurrency;
                //if (Check_AccHead[0].MultiCurrencyCurrency == _currency || Check_AccHead[0].MultiCurrencyCurrency == null) {

                //    this.form.MultiCurrency.value = _currency;
                //    this.form.ConversionRate.value = 1;
                //    $("#lbConversionRate").text(_currency);
                //    Serenity.EditorUtils.setReadonly(this.element.find(this.form.ConversionAmount.element), true);
                //    Serenity.EditorUtils.setReadonly(this.element.find(this.form.ConversionRate.element), true);
                //}
                //else {
                //    this.form.MultiCurrency.value = Check_AccHead[0].MultiCurrencyCurrency;

                //    var MultiCurrency_amount = this.items_CurrencyConversionRate.filter(f => f.FirstCurrency == Check_AccHead[0].MultiCurrencyId);
                //    this.form.ConversionRate.value = MultiCurrency_amount[0].SecondAmout;
                //    $("#lbConversionRate").text(MultiCurrency_amount[0].SecondCurrencyCurrency);

                //}

                if (Check_AccHead[0].CoaMapping == "BANK") {
                    this.form.ChequeRegisterId.value = "";
                    // this.form.PaytoOrReciveFrom.value = "";
                    this.form.CreditAmount.value = 0;
                    this.form.DebitAmount.value = 0;
                    //   this.form.Description.value = "";
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), false);
                    this.loadCheque();
                } else {
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), true);
                    this.form.ChequeRegisterId.value = "";
                    //    this.form.PaytoOrReciveFrom.value = "";
                    this.form.CreditAmount.value = 0;
                    this.form.DebitAmount.value = 0;
                    //  this.form.Description.value = "";
                }



                if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                    //
                    if (Check_AccHead[0].CoaMapping == "BANK" || Check_AccHead[0].CoaMapping == "CASH") {
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), true);
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), false);
                        this.form.CreditAmount.element.focus();
                        (this.form.CreditAmount.element[0] as any).setSelectionRange(0, 100);
                    } else {
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), false);
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), true);
                        this.form.DebitAmount.element.focus();
                        (this.form.DebitAmount.element[0] as any).setSelectionRange(0, 100);
                    }
                } else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                    //
                    if (Check_AccHead[0].CoaMapping == "BANK" || Check_AccHead[0].CoaMapping == "CASH") {
                        Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), true);
                        Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), false);
                        this.form.DebitAmount.element.focus();
                        (this.form.DebitAmount.element[0] as any).setSelectionRange(0, 100);
                    } else {
                        Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), false);
                        Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), true);
                        this.form.CreditAmount.element.focus();
                        (this.form.CreditAmount.element[0] as any).setSelectionRange(0, 100);
                    }
                }
                else if (this.form.VoucherTypeId.value == VoucherType.Journal_Voucher.toString()) {
                    //
                    var _AccTransactionTypeAssign = this.AccTransactionTypeAssign
                        .filter(p => p.CoaId == +this.form.AccountHead.value
                            && p.ParentId == +this.form.TransactionTypeEntityId.value);

                    if (_AccTransactionTypeAssign.length > 0) {
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
                this.form.DebitAmount.value = 0;
            });

            this.form.DebitAmount.change(p => {
                this.form.ConversionAmount.value = this.form.ConversionRate.value * this.form.DebitAmount.value;
                this.form.CreditAmount.value = 0;
            });
            this.form.ConversionRate.change(p => {
                this.form.ConversionAmount.value = this.form.ConversionRate.value * (this.form.DebitAmount.value + this.form.CreditAmount.value);
            });


            this.form.ChequeRegisterId.changeSelect2(p => {
                if (this.form.ChequeRegisterId.value != "") {
                    if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                        //
                        var _PayTo = this.AccChequeRegister.filter(p => p.Id == +this.form.ChequeRegisterId.value);

                        this.form.PaytoOrReciveFrom.value = _PayTo[0].PayTo;
                        this.form.CreditAmount.value = _PayTo[0].Amount;
                        this.form.Description.value = _PayTo[0].Remarks;
                        this.form.ConversionAmount.value = this.form.ConversionRate.value * this.form.CreditAmount.value;
                    }
                    else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                        //
                        var _ReceiveFrom = this.AccChequeReceiveRegister.filter(p => p.Id == +this.form.ChequeRegisterId.value);
                        this.form.PaytoOrReciveFrom.value = _ReceiveFrom[0].RecieveFrom;
                        this.form.DebitAmount.value = _ReceiveFrom[0].Amount;
                        this.form.Description.value = _ReceiveFrom[0].Remarks;
                        this.form.ConversionAmount.value = this.form.ConversionRate.value * this.form.DebitAmount.value;
                    }
                }
                else {
                    this.form.PaytoOrReciveFrom.value = "";
                    this.form.CreditAmount.value = 0;
                    this.form.DebitAmount.value = 0;
                    this.form.Description.value = "";
                }
            });

            this.form.VoucherDate.change(p => {
                this.VoucherDateChange();
                if (this.isNew()) {
                    this.setNewVoucherNumber();
                }
            });

            //--------------------
            //-- Keypress events
            //--------------------

            this.form.TransactionTypeEntityId.getGridField().keyup(e => {
                if (e.keyCode == 13) {
                    this.form.VoucherDate.element.focus();
                }
            });

            this.form.VoucherDate.element.keydown(e => {
                if (e.keyCode == 13) {
                    this.form.AccountHead.element.focus();
                    return false;
                }
            });

            this.form.AccountHead.getGridField().keyup(e => {
                if (e.keyCode == 13) {
                    this.form.CostCentreId.element.focus();
                }
            });

            this.form.CostCentreId.getGridField().keyup(e => {
                if (e.keyCode == 13) {
                    this.form.DebitAmount.element.focus();
                }
            });

            this.form.DebitAmount.element.keydown(e => {
                if (e.keyCode == 13) {
                    this.form.CreditAmount.element.focus();
                }
            });

            this.form.CreditAmount.element.keydown(e => {
                if (e.keyCode == 13) {
                    e.preventDefault();
                    $('.groupAdd').focus();
                    return false;
                }
            });

            this.form.DDescription.element.keydown(e => {
                if (e.keyCode == 13) {
                    e.preventDefault();
                    $('.groupAdd').focus();
                    return false;
                }
            });

            if (!this.isNew()) { //

                if (this.form.approveStatus.value == "") this.form.approveStatus.value = Number(ApprovalStatus.Draft).toString();

                this.toolbar.findButton('apply-changes-button').hide();
                this.toolbar.findButton('expand-all-button').hide(); // Save & Next Button
                this.toolbar.findButton('send-button').hide();
                this.toolbar.findButton('save-and-close-button').hide();

                if (this.form.approveStatus.value == ApprovalStatus.Approved.toString()) {
                    $('.ApproverId').hide();
                }

                if (this.form.approveStatus.value == ApprovalStatus.Draft.toString() ||
                    this.form.approveStatus.value == ApprovalStatus.Regret.toString()) {
                    //
                    this.toolbar.findButton('send-button').show();
                    this.toolbar.findButton('save-and-close-button').show();
                }
                if (this.form.approveStatus.value == ApprovalStatus.Submit.toString() ||
                    this.form.approveStatus.value == ApprovalStatus.Recommend.toString()) {

                    // -- IF VOUCHER SEBMITTED AND CURRENT USER IS SAME THEN
                    if (this.entity.createdUserId != this.userId.toString()) {
                        //
                        let criteria = Serenity.Criteria.and([['ApplicationId'], '=', this.entity.Id], [['ApproverId'], '=', this.userId]);

                        Transaction.ApvApplicationInformationService.List({ Criteria: criteria as any }, response => {

                            if (response.Entities != undefined && response.Entities.length > 0) {
                                this.toolbar.findButton('send-button').show();
                                this.toolbar.findButton('save-and-close-button').show();
                            }
                        });

                    } else {
                        Q.notifyWarning(
                            "This voucher is already submitted/recommended! You cannot edit at this moment!");

                        this.toolbar.findButton('send-button').hide();
                        this.toolbar.findButton('save-and-close-button').hide();
                    }
                }

                this.loadAccountHead();
                this.sumDebitCredit();
                this.transactionModeChange();

                // added by Nazrul
                let vouDtl = this.entity.VoucherDetails;

                for (let i = 0; i < vouDtl.length; i++) {
                    let vouDtlTemp = vouDtl[i];
                    let costCenterTemp = '';

                    for (let vouAllItem of vouDtlTemp.VoucherDtlAllocation) {
                        costCenterTemp += vouAllItem.CostCenterName + ', ';
                    }
                    if (vouDtlTemp.VoucherDtlAllocation.length > 0) {
                        this.entity.VoucherDetails[i].ChartofAccountsAccountName = vouDtlTemp.ChartofAccountsAccountName + ' (' + costCenterTemp + ')';
                    }
                    else {
                        this.entity.VoucherDetails[i].ChartofAccountsAccountName = vouDtlTemp.ChartofAccountsAccountName;
                    }
                    var id = (this.entity.VoucherDetails[i] as any).__id;
                    if (id == null) {
                        (this.entity.VoucherDetails[i] as any).__id = this.nextId++;
                    }
                }
                this.form.VoucherDetails.setItems(this.entity.VoucherDetails);
                // end

                Serenity.EditorUtils.setReadonly(this.element.find(this.form.TransactionMode.element), true);
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.TransactionTypeEntityId.element), true);

                $('.LinkedPaymentVoucherNo').hide();
                Transaction.AccVoucherInformationService.List({ Criteria: [['LinkedVoucherIdForAutoJV'], '=', this.entity.Id] }, r => {
                    if (r.Entities[0] != undefined) {
                        $('.LinkedPaymentVoucherNo').show();

                        this.CheckAutoVoucher = true;
                        var linkedVNo = $('.LinkedPaymentVoucherNo')[0];

                        linkedVNo.innerHTML = '<div style="padding-top: 3px; color: blue;">' +
                            '<i><span>Linked Payment Voucher No:&nbsp;&nbsp;</span><u><a href= "Payment#edit/Id" data-item-type="Transaction.PaymentVoucher" data-item-id="Id" class="LinkedPVNo">' +
                            r.Entities[0].VoucherNo +
                            '</a></u></i>' +
                            '</div>';

                        $('.LinkedPVNo').attr({
                            'href': 'Payment#edit/' + r.Entities[0].Id.toString(),
                            'data-item-id': r.Entities[0].Id.toString()
                        });

                        if (this.form.approveStatus.value == ApprovalStatus.Draft.toString()) {
                            //
                            Q.notifyWarning("Initiating auto journal voucher.");
                            this.toolbar.findButton('delete-button').hide();
                            this.toolbar.findButton('apply-changes-button').hide();
                            this.toolbar.findButton('send-button').hide();
                            $($('.s-Transaction-AccVoucherInformationDialog .category')[0]).hide();
                        }
                    }
                });


            } else {
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), true);

                this.VoucherDateChange();
            }

            this.form.TransactionTypeEntityId.element.focus();
            this.form.TransactionTypeEntityId.element.select();

        }

        public addtoGrid() {
            if (this.form.TransactionMode.value == "") {
                Q.warning("Please select Transaction Mode.");
                return;
            }

            if (this.form.AccountHead.value == "") {
                Q.warning("Please select Account Head.");
                return;
            }
            if ((this.form.DebitAmount.value.toString() == "NaN" && this.form.CreditAmount.value.toString() == "NaN")
                || (this.form.DebitAmount.value <= 0 && this.form.CreditAmount.value <= 0)) {
                Q.warning("Please enter Debit or Credit Amount 1.");
                this.form.DebitAmount.element.focus();
                return;
            }

            if (this.form.DebitAmount.value > 0 && this.form.CreditAmount.value > 0) {
                Q.warning("Please enter Debit or Credit Amount 2.");
                this.form.DebitAmount.element.focus();
                return;
            }

            var Check_AccHead = this.items_ChartofAccounts.filter(f => f.Id == +this.form.AccountHead.value);
            let _amount: number = 0;
            let _Damount: number = 0;
            let _Camount: number = 0;
            this._IsBillRef = Check_AccHead[0].IsBillRef;
            this._IsCostCenterAllocate = Check_AccHead[0].IsCostCenterAllocate;

            if (Check_AccHead[0].CoaMapping == undefined) {

                if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {

                    if (this.form.DebitAmount.value > 0) {
                        _amount = this.form.DebitAmount.value;
                        _Damount = this.form.DebitAmount.value;
                    }
                    else {
                        _amount = this.form.CreditAmount.value;
                        _Damount = this.form.CreditAmount.value;
                    }
                }
                else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                    if (this.form.CreditAmount.value.toString() == "NaN" || this.form.CreditAmount.value <= 0) {
                        Q.warning("Debit Amount for Bank or Cash Head.");
                        return;
                    }
                    else {
                        _amount = this.form.CreditAmount.value;
                        _Camount = this.form.CreditAmount.value;
                    }
                }
                else if (this.form.VoucherTypeId.value == VoucherType.Journal_Voucher.toString()) {
                    if (this.form.DebitAmount.value.toString() != "NaN" && this.form.DebitAmount.value > 0) {
                        _amount = this.form.DebitAmount.value;
                        _Damount = this.form.DebitAmount.value;
                    }
                    else {
                        _amount = this.form.CreditAmount.value;
                        _Camount = this.form.CreditAmount.value;
                    }
                }

            }
            else {

                if (this.form.TransactionMode.value == "BANK" && Check_AccHead[0].CoaMapping != "BANK") {
                    //  if (Check_AccHead[0].CoaMapping != "BANK") {
                    Q.warning("Please select Bank Head.");
                    return;
                    // }
                }
                if (this.form.TransactionMode.value == "CASH" && Check_AccHead[0].CoaMapping != "CASH") {
                    //  if (Check_AccHead[0].CoaMapping != "BANK") {
                    Q.warning("Please select Cash Head.");
                    return;
                    // }
                }

                if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {

                    if (this.form.CreditAmount.value > 0) {

                        _amount = this.form.CreditAmount.value;
                        _Damount = this.form.CreditAmount.value;
                    }
                    else {
                        _amount = this.form.DebitAmount.value;
                        _Damount = this.form.DebitAmount.value;
                    }

                }
                else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                    if (this.form.DebitAmount.value.toString() == "NaN" || this.form.DebitAmount.value <= 0) {
                        Q.warning("Debit Amount for Bank or Cash Head.");
                        return;
                    } else {
                        _amount = this.form.DebitAmount.value;
                        _Damount = this.form.DebitAmount.value;

                    }
                }
                else if (this.form.VoucherTypeId.value == VoucherType.Journal_Voucher.toString()) {
                    if (this.form.DebitAmount.value.toString() != "NaN" && this.form.DebitAmount.value > 0) {
                        _amount = this.form.DebitAmount.value;
                        _Damount = this.form.DebitAmount.value;
                    }
                    else {
                        _amount = this.form.CreditAmount.value;
                        _Camount = this.form.CreditAmount.value;
                    }
                }
            }

            var _items = this.form.VoucherDetails.getItems();

            this._VoucherDtlAllocation = [];
            if (Check_AccHead[0].IsCostCenterAllocate == 1) {
                if (this.form.CostCentreId.value != "") {
                    this._VoucherDtlAllocation.push({
                        CostCenterId: +this.form.CostCentreId.value,
                        CostCenterTypeId: +this.form.CostCenterTypeId.value,
                        CostCenterParentId: +this.form.ParentId.value,
                        Amount: _amount,
                        DebitAmount: _Damount,
                        CreditAmount: _Camount,
                        CostCenterName: this.form.CostCentreId.get_text(),
                        AdjustedChequeRegisterId: +this.form.AdjustedChequeRegisterId.value
                    });
                }
                else if (this.form.MultipleCostCenter.value) { }
                else {
                    Q.alert('Select Sub Ledger please!');
                    return;
                }
            }

            let subledger: string;

            if (this.form.CostCentreId.get_text() != '' && this.form.CostCentreId.get_text() != undefined) {
                subledger = ' (' + this.form.CostCentreId.get_text() + ')';
            }
            else {
                subledger = '';
            }


            var _details: AccVoucherDetailsRow;
            _details = {};
            _details.ChartofAccountsAccountName = this.form.AccountHead.get_text() + subledger,
                _details.ChartofAccountsId = +this.form.AccountHead.value;
            _details.CreditAmount = this.form.CreditAmount.value;
            _details.DebitAmount = this.form.DebitAmount.value;
            _details.Description = this.form.DDescription.value;
            _details.VoucherDtlAllocation = this._VoucherDtlAllocation;
            _details.ConversionAmount = this.form.ConversionAmount.value;
            _details.ConversionRate = this.form.ConversionRate.value;
            _details.AdjustedChequeRegisterId = +this.form.AdjustedChequeRegisterId.value == 0 ? null : +this.form.AdjustedChequeRegisterId.value;

            console.log(_details.AdjustedChequeRegisterId);

            if (this.form.ChequeRegisterId.value != "") {
                _details.ChequeRegisterId = +this.form.ChequeRegisterId.value;
                if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                    var _AccChequeRegister = this.AccChequeRegister.filter(p => p.Id == +this.form.ChequeRegisterId.value);

                    _details.BankAccountInformationId = _AccChequeRegister[0].BankAccountInformationId;
                }
            }

            _details.CCreditAmount = this.form.CreditAmount.value * this.form.ConversionRate.value;
            _details.CDebitAmount = this.form.DebitAmount.value * this.form.ConversionRate.value;

            if (Check_AccHead[0].AccountGroup == "Assets" || Check_AccHead[0].AccountGroup == "Expense") {
                _details.EffectiveValue = _Damount - _Camount;
            } else
            { _details.EffectiveValue = _Camount - _Damount; }

            if (Check_AccHead[0].IsCostCenterAllocate == 1 && this.form.MultipleCostCenter.value || Check_AccHead[0].IsBillRef == 1) {

                this.form.VoucherDetails.C_NewItem(_details);
            }
            else {

                _items.push(_details);

                // Start SUM Dr/Cr and Grid ID
                let dAmount: number = 0;
                let cAmount: number = 0;

                for (var item of _items) {
                    var id = (item as any).__id;
                    if (id == null) {
                        (item as any).__id = this.nextId++;
                    }

                    if (item.CreditAmount == undefined || item.CreditAmount == null) {
                    }
                    else if (item.CreditAmount.toString() != "NaN") {
                        cAmount += item.CreditAmount;
                    }

                    if (item.DebitAmount == undefined || item.DebitAmount == null) {
                    }
                    else if (item.DebitAmount.toString() != "NaN") {
                        dAmount += item.DebitAmount;
                    }

                }
                this.form.DAmount.value = dAmount;
                this.form.CAmount.value = cAmount;
                if (dAmount - cAmount == 0) {
                    this.form.Amount.value = cAmount;

                    this.form.AmountInWords.value = this.currencyToWords(this.form.Amount.value);
                } else {
                    this.form.Amount.value = 0;

                    this.form.AmountInWords.value = 'ZERO';
                }
                // End SUM Dr/Cr and Grid ID

                this.form.VoucherDetails.setItems(_items);
                this.clearData();
            }

            this.form.AccountHead.element.focus();
        }

        protected afterLoadEntity() {
            super.afterLoadEntity();
        }

        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push({

                title: 'Save & Next',
                cssClass: 'tool-button expand-all-button',
                onClick: () => {
                    this.save(() => {
                        Q.notifySuccess('Application has been Saved successfully.');

                        let ent: AccVoucherInformationRow = {};
                        ent.VoucherTypeId = Number(this.form.VoucherTypeId.value);
                        ent.PostingFinancialYearId = Number(this.form.PostingFinancialYearId.value);
                        ent.TransactionTypeEntityId = Number(this.form.TransactionTypeEntityId.value);
                        ent.VoucherDate = this.form.VoucherDate.value;
                        ent.TransactionMode = this.transactionMode.toString();

                        ent.FileNo = this.form.FileNo.value;
                        ent.PageNo = this.form.PageNo.value;
                        ent.PaytoOrReciveFrom = ""; //this.form.PaytoOrReciveFrom.value;

                        this.selectedApproverId = Number(this.form.ApproverId.value);

                        this.loadEntity(ent);
                        q.initDetailEditor(this, this.form.VoucherDetails);

                        this.items_ChartofAccounts = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;
                        this._VoucherConfiguration = Q.getLookup('Transaction.AccVoucherConfiguration_Lookup').items;
                        this.toolbar.findButton('MoneyReceipt').hide();// toggleClass('disabled');
                        var fieldpayToOrReceiveFrom = $('.PaytoOrReciveFrom .caption')[0];

                        // CHANGE TITLE - VOUCHER TYPE WISE
                        if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                            this.set_dialogTitle("Bank wise Payment Voucher");
                            Q.reloadLookup("Transaction.AccChequeRegister_Lookup");
                            // this.AccChequeRegister = Q.getLookup('Transaction.AccChequeRegister_Lookup').items;
                            fieldpayToOrReceiveFrom.innerHTML = `<sup title="this field is required">*</sup>Pay To`;
                            //Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), true);
                        } else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                            this.set_dialogTitle("Bank wise Receipt Voucher");
                            Q.reloadLookup("Transaction.AccChequeReceiveRegister_Lookup");
                            // this.AccChequeReceiveRegister = Q.getLookup('Transaction.AccChequeReceiveRegister_Lookup').items;
                            fieldpayToOrReceiveFrom.innerHTML = `Receive From`;
                            this.toolbar.findButton('MoneyReceipt').show();// toggleClass('disabled');
                            //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), true);
                        }
                        else if (this.form.VoucherTypeId.value == VoucherType.Journal_Voucher.toString()) {
                            this.set_dialogTitle("Journal/Adjustment Voucher");
                        }


                        $('.VoucherDetails .grid-toolbar').hide();
                        $('.MultiCurrency .caption').hide();
                        //$('.groupAdd').click(e => this.AddtoGrid());

                        // $('.ConversionRate .editor').css("width", "200px !important").removeClass("editor");
                        $('.ConversionRate .editor').removeClass("editor");
                        var fieldButt1 = $('.ConversionRate')[0];
                        var searchCreditInput: HTMLLabelElement;
                        searchCreditInput = document.createElement('label');
                        //  searchCreditInput.type = 'text';
                        searchCreditInput.id = 'lbConversionRate';

                        //fieldButt1.appendChild(searchCreditInput);
                        //$($('.s-Transaction-AccVoucherBankWiseDialog .category')[0]).hide();

                        this.form.VoucherDetails.parentDialog = this;
                        this.VoucherDateChange();

                        this.setNewVoucherNumberByTransactionType(this.form.TransactionTypeEntityId.value);

                        if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                            this.form.TransactionType.value = "PAYMENT";
                            this.form.VoucherType.value = "Debit";
                        } else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                            this.form.TransactionType.value = "RECEIPT";
                            this.form.VoucherType.value = "Credit";
                        }
                        else if (this.form.VoucherTypeId.value == VoucherType.Journal_Voucher.toString()) {
                            this.form.TransactionType.value = "JOURNAL";
                            this.form.VoucherType.value = "-";
                        }
                        this.loadAccountHead();

                        if (this.HeadId != 0) {
                            //this.loadAccountHeadBankCash();
                            //this.form.AccountHeadBankCash.value = this.HeadId.toString();

                            //this.populateChequeBook(+this.form.AccountHeadBankCash.value);

                            //if (!chequeBookId != null && chequeBookId != "") {
                            //    this.form.ChequeBookId.value = chequeBookId.toString();
                            //    this.populateChequeNumber(chequeBookId);
                            //}
                        }

                        if (this.selectedApproverId != 0) {
                            this.form.ApproverId.value = this.selectedApproverId.toString();
                        }

                        this.form.ChequeRegisterId.clearItems();
                        this.form.ChequeRegisterId.value = "";

                        this.form.CreditAmount.value = 0;
                        this.form.DebitAmount.value = 0;
                        this.form.DDescription.value = "";

                        Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), false);
                        this.loadCheque();
                    });

                }

            });

            buttons.push({
                title: "Print", cssClass: "print-preview-button",

                onClick: (x) => {
                    //
                    if (this.entityId != undefined) {
                        //
                        //Q.notifyInfo("Voucher print preview is opening...");
                        //var b = (new VoucherPreviewDialog());

                        //if (this.entity.LinkedWithAutoJV == true && this.entity.LinkedWithAutoJV != null) {
                        //    var _url = Q.resolveUrl("~/Reports/VoucherPreview/IndexCombineVoucher?id=" + this.entityId + "&isCombineVoucher=" + true);
                        //    b._url = _url;
                        //}
                        //else {
                        //    var _url = Q.resolveUrl("~/Reports/VoucherPreview?id=" + this.entityId);
                        //    b._url = _url;
                        //}
                        //b.dialogOpen();


                        if (this.entity.LinkedWithAutoJV && this.entity.LinkedWithAutoJV != null) {
                            var _url = "~/Reports/VoucherPreview/IndexCombineVoucher?id=" + this.entityId + "&isCombineVoucher=" + true;
                        } else {
                            var _url = "~/Reports/VoucherPreview?id=" + this.entityId;
                        }
                        Q.postToUrl({ url: _url, params: {}, target: "_blank" });
                    } else {
                        Q.alert("Sorry! Voucher Id not found!");
                    }
                }
            });

            //buttons.push({
            //    title: "Money Receipt", cssClass: "print-preview-button MoneyReceipt",

            //    onClick: (x) => {
            //        //     this._url="/css/css_colors.asp";

            //        if (this.entityId != undefined) {
            //            var b = (new VoucherPreviewDialog());
            //            var _url = Q.resolveUrl("~/Reports/MoneyReceipt?id=" + this.entityId);
            //            b._url = _url;
            //            b.dialogOpen();
            //        } else {
            //            Q.alert("Voucher Id not found.");
            //        }
            //    }
            //});

            buttons.push({
                title: "Forward for approve", cssClass: "send-button",

                onClick: (x) => {

                    let message = "Are you sure you want to Forward for approve?";

                    Q.confirm(message, () => {
                        if (this.form.ApproverId.value == "") {
                            Q.alert("Please select approver");
                            return;
                        }
                        this.sumDebitCredit();
                        this.form.approveStatus.value = ApprovalStatus.Submit.toString();
                        this.form.EmpId.value = +this.form.ApproverId.value;

                        this.save(p => { Q.notifySuccess("Voucher is submitted successfully."); this.dialogClose(); });
                    });

                }
            });

            return buttons;
        }

        protected getSaveEntity() {

            var _entity = super.getSaveEntity();

            var _vc = this._VoucherConfiguration.filter(p => p.FundControlInformationId == this.fundControlId && p.TransactionTypeId == +this.form.TransactionTypeEntityId.value && p.AccountingPeriodId == +this.form.PostingFinancialYearId.value);
            if (_vc.length > 0) {
                if (_vc[0].IsAutoPost) {
                    _entity.PostingDate = this.form.VoucherDate.value;
                    _entity.PostedBy = this.userId.toString();
                    _entity.PostToLedger = 1;
                    _entity.approveStatus = ApprovalStatus.Approved;
                    this.IsAutoPost = true;
                }
            }

            return _entity;
        }

        protected validateBeforeSave() {
            var result = super.validateBeforeSave();

            if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString() && this.form.PaytoOrReciveFrom.value == "") {
                Q.alert("Please enter Pay To.");
                result = false;

            }

            if (result) {
                if (this.form.CAmount.value - this.form.DAmount.value != 0) {
                    Q.alert("Debit Amount and Credit Amount not match.");
                    result = false;
                }
            }

            if (this.form.PostingFinancialYearId.value == "0") {
                Q.alert("Accounting Period not found.");
                result = false;
            }

            if (this.form.ApproverId.value != "") {
                this.form.approveStatus.value = ApprovalStatus.Submit.toString();
            }

            return result;
        }

        protected onSaveSuccess(response: Serenity.SaveResponse): void {

            if (this.entity.approveStatus == ApprovalStatus.Draft) {
                if (!this.IsAutoPost) {
                    this.toolbar.findButton('send-button').removeClass('disabled');

                }
                $($('.category')[0]).show();
                //this.toolbar.findButton('save-and-close-button').toggleClass('disabled');
                //this.toolbar.findButton('apply-changes-button').toggleClass('disabled');
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ApproverId.element), false);
            } else {
                this.toolbar.findButton('send-button').toggleClass('disabled');
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ApproverId.element), true);
            }

            this.onAfterSaveSuccess();
        }

        public onAfterSaveSuccess() { }

        public setMultiCurrencyCurrency(MultiCurrencyCurrency, MultiCurrencyId, thisform) {
            var _currency = this.baseCurrency;

            if (!thisform) {
                var Check_AccHead = this.items_ChartofAccounts.filter(f => f.Id == +this.form.AccountHead.value);

                MultiCurrencyCurrency = Check_AccHead[0].MultiCurrencyCurrency;
                MultiCurrencyId = Check_AccHead[0].MultiCurrencyId;
            }
            if (MultiCurrencyCurrency == _currency || MultiCurrencyCurrency == null) {

                this.form.MultiCurrency.value = _currency;
                this.form.ConversionRate.value = 1;
                $("#lbConversionRate").text(_currency);
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ConversionAmount.element), true);
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ConversionRate.element), true);
            }
            else {
                this.form.MultiCurrency.value = MultiCurrencyCurrency;

                var MultiCurrency_amount = this.items_CurrencyConversionRate.filter(f => f.FirstCurrency == MultiCurrencyId);
                this.form.ConversionRate.value = MultiCurrency_amount[0].SecondAmout;
                $("#lbConversionRate").text(MultiCurrency_amount[0].SecondCurrencyCurrency);

            }
        }

        private VoucherDateChange() {
            var _VoucherDate = this.form.VoucherDate.valueAsDate;

            var _piriod = this._AccountingPeriod.filter(j => _VoucherDate >= Q.parseISODateTime(j.PeriodStartDate) && _VoucherDate <= Q.parseISODateTime(j.PeriodEndDate));
            if (_piriod.length == 0) {
                Q.alert("Accounting Period not found.");
                this.form.VoucherNo.value = "";
            }
            else {
                this.form.PostingFinancialYearId.value = _piriod[0].Id.toString();
            }
        }

        public loadAccountHead() {
            this.form.AccountHead.clearItems();
            //  var distinct_axes2: AccTransactionTypeAssignRow[];
            var distinct_axes2 = [];
            var unique = this.AccTransactionTypeAssign.filter(p => p.ParentId == +this.form.TransactionTypeEntityId.value);//.filter((v, i, a) => a.indexOf(v) === i);
            for (var i = 0; i < unique.length; i++) {
                var str = unique[i];

                var c = distinct_axes2.filter(p => p == str.CoaId);

                if (c.length < 1) {
                    var Check_Parent = this.items_ChartofAccounts.filter(f => f.Id == str.CoaId);

                    if (Check_Parent[0].IsControlhead == 1) {
                        var Child_Items = this.items_ChartofAccounts.filter(f => f.ParentAccountId == Check_Parent[0].Id);

                        for (var _it of Child_Items.filter(p => p.IsControlhead == 0)) {
                            c = distinct_axes2.filter(p => p == _it.Id);
                            if (c.length < 1) {
                                distinct_axes2.push(_it.Id);
                                this.form.AccountHead.addItem({ id: _it.Id.toString(), text: _it.AccountName, source: null, disabled: false })
                            }
                        }

                    } else {
                        distinct_axes2.push(str.CoaId);
                        this.form.AccountHead.addItem({ id: str.CoaId.toString(), text: str.CoaAccountName, source: null, disabled: false })
                    }
                }

            }

            if (unique.length == 0) {
                var items = this.items_ChartofAccounts.filter(f => f.IsControlhead == 0);

                this.form.AccountHead.clearItems();
                for (var item of items) {
                    // var str = items[i];
                    this.form.AccountHead.addItem({ id: item.Id.toString(), text: item.AccountName, source: null, disabled: false });
                }
            }
        }

        public loadCheque() {
            if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                //
                var _AccChequeRegister = this.AccChequeRegister.filter(p => p.BankAccountInformationCoaId == +this.form.AccountHead.value);
                this.form.ChequeRegisterId.clearItems();
                for (var item of _AccChequeRegister) {
                    //  var str = items[i];
                    this.form.ChequeRegisterId.addItem({ id: item.Id.toString(), text: item.ChequeNo, source: null, disabled: false });
                }
            } else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                //
                var _AccChequeReceiveRegister = this.AccChequeReceiveRegister;

                this.form.ChequeRegisterId.clearItems();
                for (var item1 of _AccChequeReceiveRegister) {
                    //  var str = items[i];
                    //this.form.ChequeRegisterId.addItem({ id: item1.Id.toString(), text: item1.AccountName, source: null, disabled: false });
                    this.form.ChequeRegisterId.addItem({ id: item1.Id.toString(), text: item1.ChequeNo.toString() + "#" + item1.Amount + " TK.", source: null, disabled: false });

                }
            }
        }

        public sumDebitCredit() {
            let dAmount: number = 0;
            let cAmount: number = 0;

            for (var item of this.form.VoucherDetails.value) {
                if (item.CreditAmount == undefined || item.CreditAmount == null) {
                }
                else if (item.CreditAmount.toString() != "NaN") {
                    cAmount += item.CreditAmount;
                }

                if (item.DebitAmount == undefined || item.DebitAmount == null) {
                }
                else if (item.DebitAmount.toString() != "NaN") {
                    dAmount += item.DebitAmount;
                }
            }

            this.form.DAmount.value = dAmount;
            this.form.CAmount.value = cAmount;

            if (dAmount - cAmount == 0) {
                this.form.Amount.value = cAmount;

                this.form.AmountInWords.value = this.currencyToWords(this.form.Amount.value);
            } else {
                this.form.Amount.value = 0;

                this.form.AmountInWords.value = 'ZERO';
            }
            this.clearData();

        }

        protected clearData() {
            //this.form.AccountHead.value = null;
            this.form.CreditAmount.value = 0;
            this.form.DebitAmount.value = 0;
            this.form.DDescription.value = "";
            this.form.ConversionAmount.value = 0;
            this.form.ConversionRate.value = 0;
            this.form.MultiCurrency.value = "";
            this.form.MultipleCostCenter.value = false;
            //this.form.CostCentreId.value = "";
            this.form.ChequeRegisterId.value = "";
            $("#lbConversionRate").text("");
        }

        public setNewVoucherNumber() {
            //
            this.form.VoucherNo.value = "";
            this.form.VoucherNumber.value = "";

            var voucherDate = new Date(this.form.VoucherDate.value);
            var financialYearId = Number(this.form.PostingFinancialYearId.value);
            var bankAccId = 0;
            var fundControlId: number = this.fundControlId;
            var zoneId: number = this.zoneId;
            var transactionTypeId: number = +this.form.TransactionTypeEntityId.value;

            VoucherUtil.newVoucherNumberFactory(this._VoucherConfiguration, transactionTypeId, voucherDate, financialYearId, fundControlId, zoneId, bankAccId,(_voucherNo, _voucherNumber) => {

                $('.VoucherNo input').val(_voucherNo);
                $('.VoucherNumber input').val(_voucherNumber);
            });

        }

        public setNewVoucherNumberByTransactionType(transactionTypeId) {

            this.form.VoucherNo.value = "";
            this.form.VoucherNumber.value = "";

            let voucherDate = new Date(this.form.VoucherDate.value);
            let financialYearId = Number(this.form.PostingFinancialYearId.value);
            let bankAccId = null;
            let fundControlId: number = this.fundControlId;
            let zoneId: number = this.zoneId;

            VoucherUtil.newVoucherNumberFactory(this._VoucherConfiguration, transactionTypeId, voucherDate, financialYearId, fundControlId, zoneId, bankAccId, (_voucherNo, _voucherNumber) => {
                //
                $('.VoucherNo input').val(_voucherNo);
                $('.VoucherNumber input').val(_voucherNumber);
            });

        }

        protected currencyToWords(s) {

            let result: string = '';
            var data = Q.parseDecimal(s.toString()) - Math.floor(s);
            if (data > 0) {
                result = this.convertNumber(s) + " TAKA " + this.convertNumber(data * 100) + " POISA";
            }

            else {
                result = this.convertNumber(s) + " TAKA";
            }

            return result + " ONLY";
        }

        public convertNumber(num) {
            if ((num < 0) || (num > 99999999999999)) {
                return "NUMBER OUT OF RANGE!";
            }
            var Gn = Math.floor(num / 10000000);  /* Crore */
            num -= Gn * 10000000;
            var kn = Math.floor(num / 100000);     /* lakhs */
            num -= kn * 100000;
            var Hn = Math.floor(num / 1000);      /* thousand */
            num -= Hn * 1000;
            var Dn = Math.floor(num / 100);       /* Tens (deca) */
            num = num % 100;               /* Ones */
            var tn = Math.floor(num / 10);
            var one = Math.floor(num % 10);
            var res = "";

            if (Gn > 0) {
                res += (this.convertNumber(Gn) + " CRORE");
            }
            if (kn > 0) {
                res += (((res == "") ? "" : " ") +
                    this.convertNumber(kn) + " LAKH");
            }
            if (Hn > 0) {
                res += (((res == "") ? "" : " ") +
                    this.convertNumber(Hn) + " THOUSAND");
            }

            if (Dn) {
                res += (((res == "") ? "" : " ") +
                    this.convertNumber(Dn) + " HUNDRED");
            }


            var ones = Array("", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN");
            var tens = Array("", "", "TWENTY", "THIRTY", "FOURTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY");

            if (tn > 0 || one > 0) {
                if (!(res == "")) {
                    res += " AND ";
                }
                if (tn < 2) {
                    res += ones[tn * 10 + one];
                }
                else {

                    res += tens[tn];
                    if (one > 0) {
                        res += ("-" + ones[one]);
                    }
                }
            }

            if (res == "") {
                res = "ZERO";
            }
            return res;
        }

        public transactionModeChange() {
            if (this.form.TransactionMode.value == "BANK") {
                // this.form.BankAccountInformationId.value
                //    Serenity.EditorUtils.setReadonly(this.element.find(this.form.BankAccountInformationId.element), false);

                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), false);

                //  var items = this.items_ChartofAccounts.filter(f => f.CoaMapping == "BANK");
                // this.form.AccountHead.clearItems();

                //for (var item of items) {
                //    var str = item;
                //    this.form.AccountHead.addItem({ id: str.Id.toString(), text: str.AccountName, source: null, disabled: false });
                //}


            } else {

                //var items = this.items_ChartofAccounts.filter(f => f.IsControlhead == 0 && f.CoaMapping == "CASH");
                //this.form.AccountHead.clearItems();
                //for (var i = 0; i < items.length; i++) {
                //    var str = items[i];
                //    this.form.AccountHead.addItem({ id: str.Id.toString(), text: str.AccountName, source: null, disabled: false });
                //}

                // Serenity.EditorUtils.setReadonly(this.element.find(this.form.BankAccountInformationId.element), true);

                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), true);
            }
            this.isFristTime = true;
        }
    }
}