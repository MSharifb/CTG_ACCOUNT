
// ************************************
// FOR BANK WISE PAYMENT VOUCHER ONLY
// ************************************

namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    @Serenity.Decorators.maximizable()
    export class AccVoucherBankWiseDialog extends EntityDialogBase<AccVoucherInformationRow, any> {
        protected getFormKey() { return AccVoucherBankWiseForm.formKey; }
        protected getIdProperty() { return AccVoucherInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherInformationRow.nameProperty; }
        protected getService() { return AccVoucherInformationService.baseUrl; }

        public form = new AccVoucherBankWiseForm(this.idPrefix);
        public items_ChartofAccounts: Configurations.AccChartofAccountsRow[];// Configurations.AccChartofAccountsRow.getLookup().items;
        public items_CurrencyConversionRate = Configurations.AccCurrencyConversionRateRow.getLookup().items;
        public CheckAutoVoucher = false;

        public AccTransactionTypeAssign = AccTransactionTypeAssignRow.getLookup().items;
        public _VoucherConfiguration: AccVoucherConfigurationRow[];
        public _AccountingPeriod = Configurations.AccAccountingPeriodInformationRow.getLookup().items;
        protected nextId = 1;
        protected HeadId = 0;
        protected selectedApproverId = 0;

        public _IsCostCenterAllocate = 0;
        public _IsBillRef = 0;
        public IsAutoPost = false;
        public _VoucherDtlAllocation: AccVoucherDtlAllocationRow[];

        public budgetHeadList: AccBudgetDetailsRow[];

        public transactionMode = "BANK";

        protected baseCurrency: string;
        protected fundControlId: number;
        protected zoneId: number;
        protected userId: number;

        constructor() {

            super();

            var userinfo = Authorization.userDefinition;
            this.baseCurrency = userinfo.BaseCurrency;
            this.fundControlId = userinfo.FundControlInformationId;
            this.zoneId = userinfo.ZoneID;
            this.userId = userinfo.EmpId; // EmployeeId

            // Comments History //mo
            this.byId('ApplicationInformationHistory').closest('.field').hide().end().appendTo(this.byId('TabNotes'));
            //***

            this.form.BankAmount.element.css('background-color', '#ffd5c0');

            //Generate button
            var fieldButt = $('.AddtoGrid')[0];
            fieldButt.innerHTML = `<label class="caption" title=""></label>
                <a href= "javascript:;" class="btn btn-default groupAdd"> <i class="fa fa-fw fa-plus-circle"> </i>Add to Grid</a>
            `;


            this.form.ChequeRegisterId.inplaceCreateClick = (() => {
                if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {

                    //let accCheckRegDialog = new AccChequeRegisterDialog();
                    //if (this.form.ChequeRegisterId.value == "") {
                    //    let entity_chequeRegister: AccChequeRegisterRow;
                    //    entity_chequeRegister = {};
                    //    //entity_chequeRegister.Id = +this.form.ChequeRegisterId.value;
                    //    entity_chequeRegister.ChequeIssueDate = this.form.VoucherDate.value;
                    //    entity_chequeRegister.ChequeDate = this.form.VoucherDate.value;
                    //    entity_chequeRegister.ChequeType = 'AccountPayee';
                    //    entity_chequeRegister.Remarks = this.form.AccountHeadBankCash.value;
                    //    accCheckRegDialog.dig = this;
                    //    accCheckRegDialog._isFromVoucher = true;
                    //    accCheckRegDialog._isPaymentOrReceiptVoucherOnly = false;

                    //    accCheckRegDialog.loadEntityAndOpenDialog(entity_chequeRegister);
                    //}
                    //else {
                    //    accCheckRegDialog.loadByIdAndOpenDialog(this.form.ChequeRegisterId.value);
                    //}
                }
                else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                    //
                    let chequeRecRegDialog = new AccChequeReceiveRegisterDialog();
                    if (this.form.ChequeRegisterId.value == "") {
                        let entity_chequeRecRegister: AccChequeReceiveRegisterRow;
                        entity_chequeRecRegister = {};
                        entity_chequeRecRegister.ChequeReceiveDate = this.form.VoucherDate.value;
                        entity_chequeRecRegister.ChequeDate = this.form.VoucherDate.value;
                        entity_chequeRecRegister.ChequeType = 'AccountPayee';
                        chequeRecRegDialog.dig = this;
                        chequeRecRegDialog._isFromVoucher = true;
                        chequeRecRegDialog._isPaymentOrReceiptVoucherOnly = false;

                        chequeRecRegDialog.loadEntityAndOpenDialog(entity_chequeRecRegister);
                    }
                    else {
                        chequeRecRegDialog.loadByIdAndOpenDialog(this.form.ChequeRegisterId.value);
                    }
                }
            });

            //added Nazrul
            //var a = document.createElement('a');
            //var i = document.createElement('b');
            //a.appendChild(i);
            //a.title = "Calculate";
            //a.href = "javascript:;";
            //a.className = "inplace-button inplace-create";
            //a.id = "calculate";
            //$('.CreditAmount')[0].appendChild(a);
            //$("#calculate").click(function () {
            //    var dlg = new VistaGL.Transaction.selectCalculationDialog();
            //    dlg.dialogOpen();
            //});

            $('.CalculationAmount').hide();
            $('.CalculationRate').hide();
            $('.Type').hide();

            var checkbox = document.createElement('input');
            checkbox.type = "checkbox";
            checkbox.id = "calculate";

            var label = document.createElement('label');
            label.appendChild(document.createTextNode('Calculate(%)'));

            $('.CreditAmount')[0].appendChild(checkbox);
            $('.CreditAmount')[0].appendChild(label);

            $('.CreditAmount > label:nth-child(1)').width("60px");

            $('#calculate').click(function () {
                if ($('#calculate').is(":checked")) {
                    $('.CalculationAmount').show();
                    $('.CalculationRate').show();
                    $('.Type').show();
                    Serenity.EditorUtils.setReadonly($('.DebitAmount input'), true);
                    Serenity.EditorUtils.setReadonly($('.CreditAmount input'), true);
                    $('#calculate').removeAttr("disabled");
                }
                else {
                    $('.CalculationAmount').hide();
                    $('.CalculationRate').hide();
                    $('.Type').hide();

                    $('.CalculationAmount input').val('');
                    $('.CalculationRate input').val('');
                    $('.Type').val('');
                    Serenity.EditorUtils.setReadonly($('.DebitAmount input'), false);
                    Serenity.EditorUtils.setReadonly($('.CreditAmount input'), false);
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

            q.initDetailEditor(this, this.form.VoucherDetails);

            if (this.HeadId != 0) {
                this.loadAccountHeadBankCash();
                this.form.AccountHeadBankCash.value = this.HeadId.toString();
            }

            this.form.ConversionRate.element.hide();
            this.form.ConversionAmount.element.hide();
            this.form.CostCenterTypeId.getGridField().hide();
            this.form.ParentId.getGridField().hide();
            this.form.FileNo.element.hide();
            this.form.PageNo.element.hide();

            this.form.VoucherDetails.parentDialog = this;

            this.items_ChartofAccounts = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;
            this._VoucherConfiguration = Q.getLookup('Transaction.AccVoucherConfiguration_Lookup').items;
            this.toolbar.findButton('MoneyReceipt').hide();
            var fieldpayToOrReceiveFrom = $('.PaytoOrReciveFrom .caption')[0];

            Serenity.EditorUtils.setReadonly(this.element.find(this.form.VoucherNo.element), true);
            Serenity.EditorUtils.setReadonly(this.element.find(this.form.TransactionMode.element), true);

            var transactionType = Configurations.AccTransactionTypeRow.getLookup().items;

            var transactionTypeId = '';

            $('.ChequeBookId').hide();
            $('.ChequeNumhdn').hide();
            $('.ChequeType').hide();
            $('.ChequeDate').hide();

            this.form.IsBankWisePaymentVoucher.value = false;
            this.form.IsBankWiseReceiptVoucher.value = false;

            // title change Voucher type wise
            if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                this.set_dialogTitle("Bank wise Payment Voucher");

                this.form.IsBankWisePaymentVoucher.value = true;

                $('.ChequeBookId').show();
                $('.ChequeNumhdn').show();
                $('.ChequeType').show();
                $('.ChequeDate').show();

                fieldpayToOrReceiveFrom.innerHTML = `<sup title="this field is required">*</sup>Pay To`;

                //added by nazrul
                this.form.CreditAmount.element.css("background-color", "#E3B8E4");
                var tt = transactionType.filter(x => x.VoucherTypeId == VoucherType.Payment_Voucher && x.IsbyDefault == true)[0];
                transactionTypeId = tt.Id.toString();

                this.form.TransactionType.value = "PAYMENT";
                this.form.VoucherType.value = "Debit";
                //
            }
            else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                this.set_dialogTitle("Bank wise Receipt Voucher");

                this.form.IsBankWiseReceiptVoucher.value = true;

                $('.ChequeRegisterId').show();
                $('.LinkedWithAutoJV').hide();
                $('.PowerOfAttorney').hide();
                $('.BudgetAmountCOA').hide();
                $('.BudgetAmountSUbledger').hide();
                $('.NOAId').hide();

                $('.CostCentreId').removeClass('width9');
                $('.CostCentreId').addClass('width12');

                //  this.AccChequeReceiveRegister = Q.getLookup('Transaction.AccChequeReceiveRegister_Lookup').items;
                fieldpayToOrReceiveFrom.innerHTML = `Receive From`;
                $('.PaytoForBankAdvice').hide();
                this.toolbar.findButton('MoneyReceipt').show();
                //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), true);

                //added by nazrul
                this.form.DebitAmount.element.css("background-color", "#E3B8E4");
                let tt = transactionType.filter(x => x.VoucherTypeId == VoucherType.Receipt_Voucher && x.IsbyDefault == true)[0];
                transactionTypeId = tt.Id.toString();

                this.form.TransactionType.value = "RECEIPT";
                this.form.VoucherType.value = "Credit";
                //
            }

            this.form.TransactionTypeEntityId.value = transactionTypeId;

            if (this.isNew()) {
                //
                this.form.ChequeDate.value = this.form.VoucherDate.value;
                this.VoucherDateChange();
                this.setNewVoucherNumber(transactionTypeId);
            }

            this.loadAccountHead();

            this.form.TransactionMode.value = this.transactionMode.toString();

            this.loadAccountHeadBankCash();

            $('.VoucherDetails .grid-toolbar').hide();
            $('.MultiCurrency .caption').hide();
            $('.groupAdd').click(e => this.addtoGrid());

            // $('.ConversionRate .editor').css("width", "200px !important").removeClass("editor");
            $('.ConversionRate .editor').removeClass("editor");
            var fieldButt1 = $('.ConversionRate')[0];

            var searchCreditInput: HTMLLabelElement;
            searchCreditInput = document.createElement('label');
            searchCreditInput.id = 'lbConversionRate';
            fieldButt1.appendChild(searchCreditInput);

            this.form.ChequeRegisterId.clearItems();

            //--------------------
            //-- Change events
            //--------------------

            this.form.TransactionTypeEntityId.changeSelect2(p => {
                //this.form.AccountHead.clearItems();
                //this.form.AccountHeadBankCash.clearItems();

                if (this.isNew()) {
                    this.setNewVoucherNumber(transactionTypeId);
                }

                this.loadAccountHead();
            });

            this.form.VoucherDate.change(p => {
                this.VoucherDateChange();

                if (this.isNew()) {
                    this.setNewVoucherNumber(transactionTypeId);
                }
            });

            this.form.AccountHeadBankCash.changeSelect2(p => {
                this.form.ChequeRegisterId.value = "";

                this.form.CreditAmount.value = 0;
                this.form.DebitAmount.value = 0;

                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), false);

                this.loadCheque();

                this.populateChequeBook(+this.form.AccountHeadBankCash.value);
            });

            this.form.ChequeBookId.changeSelect2(p => {

                this.populateChequeNumber(+this.form.ChequeBookId.value);
            });

            this.form.ChequeNumhdn.changeSelect2(p => {
                this.form.ChequeNo.value = this.form.ChequeNumhdn.get_text();

                if (this.form.ChequeNo.value == "") {
                    console.log('populating cheque book...');
                    this.populateChequeBook(+this.form.AccountHeadBankCash.value);
                }
            });

            this.form.PaytoOrReciveFrom.change(e => {
                //
                this.changePvSubLedger();
            });

            this.form.AccountHead.changeSelect2(p => {
                var Check_AccHead = this.items_ChartofAccounts.filter(f => f.Id == +this.form.AccountHead.value);

                if (Check_AccHead[0].IsCostCenterAllocate == 1) {
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.MultipleCostCenter.element), false);
                } else {
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.MultipleCostCenter.element), true);
                }

                this.setMultiCurrencyCurrency(Check_AccHead[0].MultiCurrencyCurrency, Check_AccHead[0].MultiCurrencyId, true);

                //var _currency = this.baseCurrency;
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

                //if (Check_AccHead[0].CoaMapping == "BANK") {
                //    this.form.ChequeRegisterId.value = "";
                //    // this.form.PaytoOrReciveFrom.value = "";
                //    this.form.CreditAmount.value = 0;
                //    this.form.DebitAmount.value = 0;
                //    //   this.form.Description.value = "";
                //    Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), false);
                //    this.LoadCheque();


                //} else {
                //    Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), true);
                //    this.form.ChequeRegisterId.value = "";
                //    //    this.form.PaytoOrReciveFrom.value = "";
                //    this.form.CreditAmount.value = 0;
                //    this.form.DebitAmount.value = 0;
                //    //  this.form.Description.value = "";
                //}



                if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                    //
                    if (Check_AccHead[0].CoaMapping == "BANK" || Check_AccHead[0].CoaMapping == "CASH") {
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), true);
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), false);

                        (this.form.CreditAmount.element[0] as any).setSelectionRange(0, 100);
                    } else {
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), false);
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), true);

                        (this.form.DebitAmount.element[0] as any).setSelectionRange(0, 100);
                    }
                    //
                } else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                    //
                    if (Check_AccHead[0].CoaMapping == "BANK" || Check_AccHead[0].CoaMapping == "CASH") {
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), true);
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), false);

                        (this.form.DebitAmount.element[0] as any).setSelectionRange(0, 100);
                    } else {
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.CreditAmount.element), false);
                        //Serenity.EditorUtils.setReadonly(this.element.find(this.form.DebitAmount.element), true);

                        (this.form.CreditAmount.element[0] as any).setSelectionRange(0, 100);
                    }
                    //
                }
                else if (this.form.VoucherTypeId.value == VoucherType.Journal_Voucher.toString()) {
                    //
                    var _AccTransactionTypeAssign = this.AccTransactionTypeAssign
                        .filter(p => p.CoaId == +this.form.AccountHead.value
                            && p.ParentId == +this.form.TransactionTypeEntityId.value);

                    if (_AccTransactionTypeAssign.length > 0) {
                        if (_AccTransactionTypeAssign[0].TrType == "C") {

                            (this.form.CreditAmount.element[0] as any).setSelectionRange(0, 100);
                        } else {

                            (this.form.DebitAmount.element[0] as any).setSelectionRange(0, 100);
                        }
                    }
                    //
                }

                this.getBudgetAmount(this.form.AccountHead.value, true, false);
            });

            this.form.Type.changeSelect2(p => {
                let clAmount = this.form.CalculationAmount.value;
                let clRate = this.form.CalculationRate.value;

                if (this.form.Type.value == 'Dr' && clAmount >= 0 && clRate >= 0) {
                    this.form.DebitAmount.value = clAmount * (clRate / 100);
                    this.form.CreditAmount.value = 0;
                }
                else if (this.form.Type.value == 'Cr' && clAmount >= 0 && clRate >= 0) {
                    this.form.CreditAmount.value = clAmount * (clRate / 100);
                    this.form.DebitAmount.value = 0;
                }
            });

            this.form.DebitAmount.change(p => {
                this.form.ConversionAmount.value = this.form.ConversionRate.value * this.form.DebitAmount.value;
                this.form.CreditAmount.value = 0;
            });

            this.form.ChequeRegisterId.changeSelect2(p => {
                console.log('This ChequeRegisterId.changeSelect2 event should not call in this dialog!');
                if (this.form.ChequeRegisterId.value != "") {

                    if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                        //
                        let AccChequeReceiveRegister: AccChequeReceiveRegisterRow[];

                        Q.reloadLookup("Transaction.AccChequeReceiveRegister_Lookup");
                        AccChequeReceiveRegister = Q.getLookup('Transaction.AccChequeReceiveRegister_Lookup').items;

                        var _ReceiveFrom = AccChequeReceiveRegister.filter(p => p.Id == +this.form.ChequeRegisterId.value);

                        this.form.PaytoOrReciveFrom.value = _ReceiveFrom[0].RecieveFrom;
                        this.form.BankAmount.value = _ReceiveFrom[0].Amount;
                        //this.form.CreditAmount.value = _PayTo[0].Amount;
                        this.form.Description.value = _ReceiveFrom[0].Remarks;
                        this.form.ConversionAmount.value = this.form.ConversionRate.value * this.form.DebitAmount.value;
                        //
                    }

                }
                else {
                    //this.form.PaytoOrReciveFrom.value = "";
                    this.form.CreditAmount.value = 0;
                    this.form.DebitAmount.value = 0;
                    this.form.Description.value = "";
                }
            });

            this.form.ConversionRate.change(p => {
                this.form.ConversionAmount.value = this.form.ConversionRate.value * (this.form.DebitAmount.value + this.form.CreditAmount.value);
            });

            this.form.CostCentreId.changeSelect2(p => {
                this.getBudgetAmount(this.form.CostCentreId.value, false, false);
            })

            this.form.AutoPV_AccountHead.changeSelect2(p => {
                this.getBudgetAmount(this.form.AutoPV_AccountHead.value, true, true);
            })

            this.form.AutoPV_CostCentreId.changeSelect2(p => {
                this.getBudgetAmount(this.form.AutoPV_CostCentreId.value, false, true);
            })

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
                    this.form.AccountHeadBankCash.element.focus();
                    return false;
                }
            });

            this.form.AccountHeadBankCash.getGridField().keyup(e => {
                if (e.keyCode == 13) {
                    this.form.ChequeBookId.element.focus();
                }
            });

            this.form.ChequeBookId.getGridField().keyup(e => {
                if (e.keyCode == 13) {
                    window.setTimeout(() => { this.form.ChequeNumhdn.element.focus(); }, 500);
                }
            });

            this.form.ChequeNumhdn.getGridField().keyup(e => {
                if (e.keyCode == 13) {
                    this.form.ChequeType.element.focus();
                }
            });

            this.form.ChequeType.getGridField().keyup(e => {
                if (e.keyCode == 13) {
                    //
                    this.form.ChequeDate.element.focus();
                }
            });

            this.form.ChequeDate.element.keydown(e => {
                if (e.keyCode == 13) {
                    //
                    this.form.ChequeRemarks.element.focus();
                }
            });

            this.form.ChequeRemarks.element.keydown(e => {
                if (e.keyCode == 13) {
                    //
                    this.form.BankAmount.element.focus();
                }
            });

            this.form.BankAmount.element.keydown(e => {
                if (e.keyCode == 13) {
                    //
                    this.form.PaytoOrReciveFrom.element.focus();
                    return false;
                }
            });


            var insidePayto = 0;
            this.form.PaytoOrReciveFrom.element.keyup(e => {
                //
                if (e.keyCode == 13) {
                    if (insidePayto == 0) {
                        insidePayto = 1; return e;
                    }

                    this.form.PowerofAttorney.element.focus();
                    insidePayto = 0;
                }
            });

            this.form.PowerofAttorney.element.keydown(e => {
                if (e.keyCode == 13) {
                    this.form.NOAId.element.focus();
                    //
                }
            });

            this.form.NOAId.getGridField().keyup(e => {
                if (e.keyCode == 13) {
                    this.form.LinkedWithAutoJV.element.focus();
                }
            });

            this.form.ChequeRegisterId.getGridField().keyup(e => {
                if (e.keyCode == 13) {
                    this.form.PowerofAttorney.element.focus();
                }
            });

            this.form.LinkedWithAutoJV.element.click(e => {
                if (!this.form.LinkedWithAutoJV.value) {
                    //
                    this.form.AutoPV_CostCentreId.getGridField().hide();
                    this.form.AutoPV_AccountHead.getGridField().hide();
                    this.form.AutoBudgetAmountCOA.getGridField().hide();
                    this.form.AutoBudgetAmountSUbledger.getGridField().hide();
                    //this.form.BudgetAmountCOA.getGridField().show();
                    //this.form.BudgetAmountSUbledger.getGridField().show();                   
                    //
                } else {
                    //
                    this.form.AutoPV_CostCentreId.getGridField().show();
                    this.form.AutoPV_AccountHead.getGridField().show();
                    this.form.AutoBudgetAmountCOA.getGridField().show();
                    this.form.AutoBudgetAmountSUbledger.getGridField().show();
                    //this.form.BudgetAmountCOA.getGridField().hide();
                    //this.form.BudgetAmountSUbledger.getGridField().hide();                   
                }
            });

            this.form.LinkedWithAutoJV.element.keydown(e => {
                if (e.keyCode == 13) {
                    if (this.form.LinkedWithAutoJV.value) {
                        this.form.AutoPV_AccountHead.element.focus();
                    } else {
                        this.form.AccountHead.element.focus();
                    }
                }
            });

            this.form.AutoPV_AccountHead.getGridField().keyup(e => {
                if (e.keyCode == 13) {
                    this.form.AutoPV_CostCentreId.element.focus();
                }
            });

            this.form.AutoPV_CostCentreId.getGridField().keyup(e => {
                if (e.keyCode == 13) {
                    this.form.AccountHead.element.focus();
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


            if (!this.isNew() || this.isEditMode()) { // IF EDIT MOOD

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

                    // -- IF VOUCHER "SUBMITTED AND CURRENT" USER IS NOT SAME THEN
                    if (this.entity.createdUserId != this.userId.toString()) {
                        //
                        let criteria1 = Serenity.Criteria.and([['ApplicationId'], '=', this.entity.Id], [['ApproverId'], '=', this.userId]);
                        Transaction.ApvApplicationInformationService.List({ Criteria: criteria1 as any }, response1 => {
                            if (response1.Entities != undefined) {

                                if (response1.Entities.length > 0) {
                                    if (response1.Entities.length == 1) {
                                        this.toolbar.findButton('send-button').show();
                                        this.toolbar.findButton('save-and-close-button').show();
                                    } else {
                                        let anyPendingFound = response1.Entities.filter(f => f.ApprovalStatusId == null);
                                        if (anyPendingFound != null && anyPendingFound.length > 0) {
                                            this.toolbar.findButton('send-button').show();
                                            this.toolbar.findButton('save-and-close-button').show();
                                        }
                                    }
                                }
                            }
                        });

                    } else {
                        Q.notifyWarning(
                            "This voucher is already submitted/recommended! You cannot edit at this moment!");

                        this.toolbar.findButton('send-button').hide();
                        this.toolbar.findButton('save-and-close-button').hide();
                    }
                }

                $('.LinkedWithAutoJV').hide();

                if (this.entity.LinkedWithAutoJV) {
                    this.loadAccountHead();
                    this.sumDebitCredit();

                    $('.AutoJVVoucherNo').hide();

                    Transaction.AccVoucherInformationService.List({ Criteria: [['Id'], '=', this.entity.LinkedVoucherIdForAutoJV] }, response => {
                        this.CheckAutoVoucher = true;
                        $('.AutoJVVoucherNo').show();

                        var linkedVNo = $('.AutoJVVoucherNo')[0];

                        linkedVNo.innerHTML = '<div style="padding-top: 3px; color: blue;">' +
                            '<i><span>Linked Journal Voucher No:&nbsp;&nbsp;</span><u><a href= "JournalVoucher#edit/Id" data-item-type="Transaction.JournalVoucher" data-item-id="Id" class="LinkedJVNo">' + response.Entities[0].VoucherNo + '</a></u></i>' +
                            '</div>';

                        $('.LinkedJVNo').attr({
                            'href': 'JournalVoucher#edit/' + this.entity.LinkedVoucherIdForAutoJV.toString(),
                            'data-item-id': this.entity.LinkedVoucherIdForAutoJV.toString()
                        });

                    });
                    this.form.LinkedWithAutoJV.value = this.entity.LinkedWithAutoJV;

                    $('.AccountHead').hide();
                    $('.CostCenterTypeId').hide();
                    $('.ParentId').hide();
                    $('.CostCentreId').hide();
                    $('.MultipleCostCenter').hide();
                    $('.DebitAmount').hide();
                    $('.CreditAmount').hide();
                    $('.CalculationRate').hide();
                    $('.CalculationAmount').hide();
                    $('.DDescription').hide();
                    $('.AddtoGrid').hide();

                }

                // POPULATE CHEQUE INFO IN EDIT MODE
                if (this.entity.ChequeRegisterId != null) {
                    VistaGL.Transaction.AccChequeRegisterService.List({ Criteria: [['id'], '=', this.entity.ChequeRegisterId] },
                        r => {
                            var chqReg: Transaction.AccChequeRegisterRow[];
                            chqReg = r.Entities;

                            if (chqReg.length > 0) {
                                //this.form.AccountHeadBankCash.value =
                                var lstEntity = chqReg[chqReg.length - 1];
                                this.form.ChequeBookId.value = lstEntity.ChequeBookId.toString();
                                this.form.ChequeType.value = lstEntity.ChequeType;
                                this.form.BankAmount.value = lstEntity.Amount;
                                this.form.ChequeDate.value = lstEntity.ChequeDate;
                                this.form.PaytoForBankAdvice.value = lstEntity.PayTo;

                                //this.PopulateChequeNumber();
                                this.form.ChequeNumhdn.addItem({
                                    id: lstEntity.ChequeNumhdn.toString(),
                                    text: lstEntity.ChequeNo.toString(),
                                    source: null,
                                    disabled: false
                                });
                                this.form.ChequeNo.value = lstEntity.ChequeNo.toString();
                                this.form.ChequeNumhdn.value = lstEntity.ChequeNumhdn.toString();
                            }
                        });
                }
                // END

                Serenity.EditorUtils.setReadonly(this.element.find(this.form.TransactionTypeEntityId.element), true);

                this.form.ClearDate.value = this.entity.VoucherDetails.filter(vd => vd.IsAccountHeadBankCash == true)[0].ClearDate;
                this.form.IsClearDate.value = this.entity.VoucherDetails.filter(vd => vd.IsAccountHeadBankCash == true)[0].IsClearDate;

                // SHOW COST CENTER WITH CHART OF ACCOUNT
                this.entity.VoucherDetails = this.entity.VoucherDetails.filter(vd => vd.IsAccountHeadBankCash == false);
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
                // END

                this.form.Amount.value = this.entity.Amount;
                this.form.BankAmount.value = this.entity.Amount;
                this.form.AccountBankCashAmount.value = this.entity.Amount;
                this.form.AccountBankCash.value = this.form.AccountHeadBankCash.get_text();
                this.form.AmountInWords.value = this.entity.AmountInWords;
                //

            } // END OF EDIT MOOD
            else {
                this.VoucherDateChange();

                //this.toolbar.findButton('send-button').hide();

                this.form.ChequeBookId.clearItems();
                this.form.ChequeBookId.value = "";
            }

            this.form.VoucherDate.element.focus();
            this.form.VoucherDate.element.select();
        }

        public addtoGrid() {

            if (this.transactionMode.toString() == "") {
                Q.warning("Please select Transaction Mode.");
                return;
            }

            if (this.form.AccountHeadBankCash.value == "") {
                Q.warning("Please select Bank Head!");
                return;
            }

            if (this.form.AccountHead.value == "") {
                Q.warning("Please select Account Head.");
                return;
            }

            if ((this.form.DebitAmount.value.toString() == "NaN" && this.form.CreditAmount.value.toString() == "NaN")
                || (this.form.DebitAmount.value <= 0 && this.form.CreditAmount.value <= 0)) {
                this.form.DebitAmount.element.focus();
                this.form.DebitAmount.element.select();
                Q.warning("Please enter Debit or Credit Amount 1.");
                return;
            }

            if (this.form.DebitAmount.value > 0 && this.form.CreditAmount.value > 0) {
                this.form.DebitAmount.element.focus();
                this.form.DebitAmount.element.select();
                Q.warning("Please enter Debit or Credit Amount 2.");
                return;
            }

            var Check_AccHead = this.items_ChartofAccounts.filter(f => f.Id == +this.form.AccountHead.value);
            var _amount = 0;
            var _Damount = 0;
            var _Camount = 0;
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
                        _Camount = this.form.CreditAmount.value;
                    }
                }
                else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                    if (this.form.CreditAmount.value > 0) {
                        _amount = this.form.CreditAmount.value;
                        _Camount = this.form.CreditAmount.value;
                    }
                    else {
                        _amount = this.form.DebitAmount.value;
                        _Damount = this.form.DebitAmount.value;
                    }
                }
            }
            else {

                if (Check_AccHead[0].CoaMapping != "BANK") {
                    Q.warning("Please select Bank Head.");
                    return;
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
                    if (this.form.DebitAmount.value > 0) {
                        _amount = this.form.DebitAmount.value;
                        _Camount = this.form.DebitAmount.value;
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
                        CostCenterName: this.form.CostCentreId.get_text()
                    });
                }
                else if (this.form.MultipleCostCenter.value) { }
                else {
                    Q.alert('Please select Sub Ledger!');
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

            _details.CalculationRate = this.form.CalculationRate.value;
            _details.CalculationAmount = this.form.CalculationAmount.value;

            if (this.form.ChequeRegisterId.value != "") {
                _details.ChequeRegisterId = +this.form.ChequeRegisterId.value;
            }

            _details.BankAccountInformationId = +this.form.BankAccountInformationId.value;
            _details.CCreditAmount = this.form.CreditAmount.value * this.form.ConversionRate.value;
            _details.CDebitAmount = this.form.DebitAmount.value * this.form.ConversionRate.value;

            _details.IsAccountHeadBankCash = false;

            //if (Check_AccHead[0].AccountGroup == "Assets" || Check_AccHead[0].AccountGroup == "Expense") {
            //    _details.EffectiveValue = _Damount - _Camount;
            //}
            //else {
            //    _details.EffectiveValue = _Camount - _Damount;
            //}

            if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString() && this.form.CreditAmount.value > 0) {
                _details.EffectiveValue = - this.form.CreditAmount.value;
            }
            else if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString() && this.form.DebitAmount.value > 0) {
                _details.EffectiveValue = this.form.DebitAmount.value;
            }
            else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString() && this.form.DebitAmount.value > 0) {
                _details.EffectiveValue = - this.form.DebitAmount.value;
            }
            else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString() && this.form.CreditAmount.value > 0) {
                _details.EffectiveValue = this.form.CreditAmount.value;
            }


            if (Check_AccHead[0].IsCostCenterAllocate == 1 && this.form.MultipleCostCenter.value || Check_AccHead[0].IsBillRef == 1) {

                this.form.VoucherDetails.C_NewItem(_details);
            }
            else {
                _items.push(_details);

                // Start SUM Dr/Cr and Grid ID
                var dAmount = 0;
                var cAmount = 0;

                for (var item of _items) {
                    var id = (item as any).__id;
                    if (id == null) {
                        (item as any).__id = this.nextId++;
                    }
                }

                this.form.VoucherDetails.setItems(_items);

                // End SUM Dr/Cr and Grid ID
                this.sumDebitCredit();

            }

            this.form.AccountHead.element.focus();
        }

        protected afterLoadEntity() {
            super.afterLoadEntity();

            this.form.NOAId.filterValue = String(this.zoneId);

            if (!this.isNew()) {
                this.form.NOAId.value = String(this.entity.NOAId);
            }
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

                        this.HeadId = Number(this.form.AccountHeadBankCash.value);
                        this.selectedApproverId = Number(this.form.ApproverId.value);
                        var chequeBookId = this.form.ChequeBookId.value;

                        this.loadEntity(ent);
                        q.initDetailEditor(this, this.form.VoucherDetails);

                        this.form.ChequeBookId.clearItems();
                        this.form.ChequeBookId.value = "";

                        this.form.ChequeNumhdn.clearItems();
                        this.form.ChequeNumhdn.value = "";

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
                            $('.PaytoForBankAdvice').hide();
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
                        this.setNewVoucherNumber(this.form.TransactionTypeEntityId.value);

                        this.form.IsBankWisePaymentVoucher.value = false;
                        this.form.IsBankWiseReceiptVoucher.value = false;

                        if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                            this.form.TransactionType.value = "PAYMENT";
                            this.form.VoucherType.value = "Debit";

                            this.form.IsBankWisePaymentVoucher.value = true;
                        } else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                            this.form.TransactionType.value = "RECEIPT";
                            this.form.VoucherType.value = "Credit";

                            this.form.IsBankWiseReceiptVoucher.value = true;
                        }

                        this.loadAccountHead();

                        if (this.HeadId != 0) {
                            this.loadAccountHeadBankCash();
                            this.form.AccountHeadBankCash.value = this.HeadId.toString();

                            this.populateChequeBook(+this.form.AccountHeadBankCash.value);

                            if (!chequeBookId != null && chequeBookId != "") {
                                this.form.ChequeBookId.value = chequeBookId.toString();
                                this.populateChequeNumber(chequeBookId);
                            }
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

                        window.setTimeout(() => { this.form.ChequeNumhdn.element.focus(); }, 500);

                    });

                }

            });

            buttons.push({
                title: "Print", cssClass: "print-preview-button",

                onClick: (x) => {
                    //
                    if (this.entityId != undefined) {
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

            buttons.push({
                title: "Money Receipt", cssClass: "print-preview-button MoneyReceipt",

                onClick: (x) => {
                    if (this.entityId != undefined) {
                        //var b = (new VoucherPreviewDialog());
                        //var _url = Q.resolveUrl("~/Reports/MoneyReceipt?id=" + this.entityId);
                        //b._url = _url;
                        //b.dialogOpen();
                        //var _url = "~/Reports/MoneyReceipt?id=" + this.entityId;
                        var _url = "~/Reports/MoneyReceipt?id=" + this.entityId + "&source='FromReceiptVoucher'";
                        Q.postToUrl({ url: _url, params: {}, target: "_blank" });
                    } else {
                        Q.alert("Sorry! Voucher Id not found!");
                    }
                }
            });

            buttons.push({
                title: "Forward for approve", cssClass: "send-button",

                onClick: (x) => {

                    let message = "Are you sure you want to Forward for approve?";

                    Q.confirm(message, () => {
                        if (this.form.ApproverId.value == "") {
                            Q.alert("Please select Approver!");
                            return;
                        }

                        this.form.approveStatus.value = ApprovalStatus.Submit.toString();
                        this.form.EmpId.value = +this.form.ApproverId.value;

                        this.save(p => { Q.notifySuccess("Voucher is submitted successfully."); this.dialogClose(); });
                    }
                    );
                }
            });

            return buttons;
        }

        protected getSaveEntity() {

            var voucherInformation = super.getSaveEntity();

            voucherInformation.LinkedWithAutoJV = this.form.LinkedWithAutoJV.value;

            //-- Journal voucher amount and amount in word
            if (voucherInformation.LinkedWithAutoJV) {
                if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                    voucherInformation.JVAmount = this.form.DAmount.value;
                    voucherInformation.JVAmountInWords = VoucherUtil.currencyToWords(voucherInformation.JVAmount);
                }

                if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                    voucherInformation.JVAmount = this.form.CAmount.value;
                    voucherInformation.JVAmountInWords = VoucherUtil.currencyToWords(voucherInformation.JVAmount);
                }
            }

            var _vc = this._VoucherConfiguration.filter(p => p.FundControlInformationId == this.fundControlId && p.TransactionTypeId == +this.form.TransactionTypeEntityId.value && p.AccountingPeriodId == +this.form.PostingFinancialYearId.value);
            if (_vc.length > 0) {
                if (_vc[0].IsAutoPost) {
                    voucherInformation.PostingDate = this.form.VoucherDate.value;
                    voucherInformation.PostedBy = this.userId.toString();
                    voucherInformation.PostToLedger = 1;
                    voucherInformation.approveStatus = ApprovalStatus.Approved;
                    this.IsAutoPost = true;
                    // this.form.approveStatus.value=ApprovalStatus.Approved.toString();
                }
            }

            return voucherInformation;
        }

        protected validateBeforeSave() {

            if (!this.validateForm()) return false;

            var result = super.validateBeforeSave();

            if (!result) return false;

            if (this.form.PostingFinancialYearId.value == "0") {
                Q.alert("Accounting Period not found!");
                return false;
            }

            if (this.form.AccountHeadBankCash.value == "") {
                Q.alert("Please Select Bank Head!");
                return false;
            }

            if (this.form.Description.value == "") {
                this.form.Description.element.focus();
                Q.alert("Enter Narration!");
                return false;
            }

            if (this.form.VoucherDetails.getItems().length == 0) {
                Q.alert("Please add voucher details.");
                return false;
            }

            if (this.form.IsBankWisePaymentVoucher.value == true && this.form.ChequeBookId.value != "") {
                if (this.form.ChequeNumhdn.value == "") {
                    Q.alert("Please Select Cheque Number!");
                    return false;
                }

                if (this.form.ChequeType.value == "") {
                    Q.alert("Please Select Cheque Type!");
                    return false;
                }

                if (this.form.ChequeDate.value == "") {
                    Q.alert("Please Select Cheque Date!");
                    return false;
                }

                if (this.form.PaytoForBankAdvice.value == "") {
                    Q.alert("Please Select Pay to For Bank Advice!");
                    return false;
                }
            }

            if (this.form.LinkedWithAutoJV.value) {
                //
                if (this.isNew()) {
                    if (this.form.AutoPV_AccountHead.value == "") {
                        Q.alert("Please select Account Head for auto voucher!");
                        return false;
                    }

                    if (this.form.AutoPV_CostCentreId.value == "") {
                        Q.alert("Please select Sub ledger for auto voucher!");
                        return false;
                    }
                }
            } else {
                //--
                if (this.isNew()) {
                    if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                        let totalCreditAmount = 0;
                        this.form.VoucherDetails.value.forEach(f => totalCreditAmount += f.CreditAmount);

                        if (totalCreditAmount > 0) {
                            //
                            this.form.LinkedWithAutoJV.value = true;
                            this.form.AutoPV_CostCentreId.getGridField().show();
                            this.form.AutoPV_AccountHead.getGridField().show();

                            if (this.form.AutoPV_AccountHead.value == "") {
                                Q.alert("You are supposed to create an auto jv! Please select Account Head for auto voucher!");
                                return false;
                            }

                            if (this.form.AutoPV_CostCentreId.value == "") {
                                Q.alert("You are supposed to create an auto jv! Please select Sub ledger for auto voucher!");
                                return false;
                            }
                        }
                    }
                }

            }

            if (this.form.FileName.value.length == 0) {
                let message = "Are you sure want to save data without attachment?";
                if (confirm(message)) {
                    result = true;
                } else {
                    result = false;
                    return false;
                }
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
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ApproverId.element), false);
            } else {
                this.toolbar.findButton('send-button').toggleClass('disabled');
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.ApproverId.element), true);
            }

            this.onAfterSaveSuccess();
        }

        public onAfterSaveSuccess() {
            //
        }

        public loadAccountHead() {
            //this.form.AccountHead.clearItems();
            //this.form.AutoPV_AccountHead.clearItems();
            ////  var distinct_axes2: AccTransactionTypeAssignRow[];
            //var distinct_axes2 = [];
            //var unique = this.AccTransactionTypeAssign.filter(p => p.ParentId == +this.form.TransactionTypeEntityId.value);//.filter((v, i, a) => a.indexOf(v) === i);
            //for (var i = 0; i < unique.length; i++) {
            //    var str = unique[i];

            //    var c = distinct_axes2.filter(p => p == str.CoaId);

            //    if (c.length < 1) {
            //        var Check_Parent = this.items_ChartofAccounts.filter(f => f.Id == str.CoaId);

            //        if (Check_Parent[0].IsControlhead == 1) {
            //            var Child_Items = this.items_ChartofAccounts.filter(f => f.ParentAccountId == Check_Parent[0].Id);

            //            for (var _it of Child_Items.filter(p => p.IsControlhead == 0)) {
            //                c = distinct_axes2.filter(p => p == _it.Id);
            //                if (c.length < 1) {
            //                    distinct_axes2.push(_it.Id);
            //                    this.form.AccountHead.addItem({
            //                        id: _it.Id.toString(),
            //                        text: _it.AccountName,
            //                        source: null,
            //                        disabled: false
            //                    });
            //                    this.form.AutoPV_AccountHead.addItem({
            //                        id: _it.Id.toString(),
            //                        text: _it.AccountName,
            //                        source: null,
            //                        disabled: false
            //                    });
            //                }
            //            }

            //        } else {
            //            distinct_axes2.push(str.CoaId);
            //            this.form.AccountHead.addItem({
            //                id: str.CoaId.toString(),
            //                text: str.CoaAccountName,
            //                source: null,
            //                disabled: false
            //            });
            //            this.form.AutoPV_AccountHead.addItem({
            //                id: str.CoaId.toString(),
            //                text: str.CoaAccountName,
            //                source: null,
            //                disabled: false
            //            });
            //        }
            //    }

            //}

            //if (unique.length == 0) {
            //    var items = this.items_ChartofAccounts.filter(f => f.IsControlhead == 0);

            //    this.form.AccountHead.clearItems();
            //    this.form.AutoPV_AccountHead.clearItems();
            //    for (var item of items) {
            //        // var str = items[i];
            //        this.form.AccountHead.addItem({ id: item.Id.toString(), text: item.AccountName, source: null, disabled: false });
            //        this.form.AutoPV_AccountHead.addItem({ id: item.Id.toString(), text: item.AccountName, source: null, disabled: false });
            //    }
            //}
        }

        public loadAccountHeadBankCash() {
            //this.form.AccountHeadBankCash.clearItems();

            //var coaMapping = "BANK";
            //var _zoneWiseBankAccInfoList: Configurations.AccBankAccountInformationRow[];
            //_zoneWiseBankAccInfoList = Q.getLookup("Configurations.AccBankAccountInformation_Lookup").items;

            //var distinct_axes2 = [];
            //var unique = this.AccTransactionTypeAssign
            //    .filter(p => p.ParentId == +this.form.TransactionTypeEntityId.value
            //        && p.CoaCoaMapping == coaMapping);//.filter((v, i, a) => a.indexOf(v) === i);


            //if (unique.length == 0) {

            //    for (var bank of _zoneWiseBankAccInfoList) {
            //        var coa = this.items_ChartofAccounts.filter(f => f.Id == bank.CoaId);

            //        if (coa.length > 0) {
            //            this.form.AccountHeadBankCash.addItem({ id: coa[0].Id.toString(), text: coa[0].AccountName, source: null, disabled: false });
            //        }
            //    }
            //}
            //else {
            //    for (var i = 0; i < unique.length; i++) {
            //        var str = unique[i];

            //        var c = distinct_axes2.filter(p => p == str.CoaId);

            //        if (c.length < 1) {
            //            var Check_Parent = this.items_ChartofAccounts.filter(f => f.Id == str.CoaId);

            //            if (Check_Parent[0].IsControlhead == 1) {
            //                var Child_Items = this.items_ChartofAccounts.filter(f => f.ParentAccountId == Check_Parent[0].Id);

            //                for (var _it of Child_Items.filter(p => p.IsControlhead == 0 && p.CoaMapping == coaMapping)) {
            //                    c = distinct_axes2.filter(p => p == _it.Id);
            //                    if (c.length < 1) {
            //                        distinct_axes2.push(_it.Id);
            //                        this.form.AccountHeadBankCash.addItem({
            //                            id: _it.Id.toString(),
            //                            text: _it.AccountName,
            //                            source: null,
            //                            disabled: false
            //                        });

            //                    }
            //                }

            //            } else {
            //                distinct_axes2.push(str.CoaId);
            //                this.form.AccountHeadBankCash.addItem({
            //                    id: str.CoaId.toString(),
            //                    text: str.CoaAccountName,
            //                    source: null,
            //                    disabled: false
            //                });
            //            }
            //        }

            //    }
            //}


            this.loadCheque();
        }

        public loadCheque() {
            if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                //
                let AccChequeRegister: AccChequeRegisterRow[];
                AccChequeRegister = Q.getLookup('Transaction.AccChequeRegister_Lookup').items;

                let _AccChequeRegister = AccChequeRegister
                    .filter(p => p.BankAccountInformationCoaId == +this.form.AccountHeadBankCash.value);

                this.form.ChequeRegisterId.clearItems();
                for (var item of _AccChequeRegister) {

                    this.form.ChequeRegisterId.addItem({
                        id: item.Id.toString(), text: item.ChequeNo, source: null, disabled: false
                    });
                }
                //
            } else if (this.form.VoucherTypeId.value == VoucherType.Receipt_Voucher.toString()) {
                //
                let AccChequeReceiveRegister: AccChequeReceiveRegisterRow[];
                AccChequeReceiveRegister = Q.getLookup('Transaction.AccChequeReceiveRegister_Lookup').items;

                let _AccChequeReceiveRegister = AccChequeReceiveRegister;

                this.form.ChequeRegisterId.clearItems();
                for (var item1 of _AccChequeReceiveRegister) {

                    this.form.ChequeRegisterId.addItem({
                        id: item1.Id.toString(), text: item1.ChequeNo.toString() + "#" + item1.Amount + " TK.", source: null, disabled: false
                    });
                }
                //
            }
        }

        public populateChequeBook(accountHeadBank) {
            //--
            //if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
            //    this.form.ChequeBookId.clearItems();
            //    this.form.ChequeBookId.value = "";
            //    this.form.ChequeNumhdn.clearItems();
            //    this.form.ChequeNumhdn.value = "";
            //}

            if (accountHeadBank == 0) return;

            let _bankAccInfoList =
                Configurations.AccBankAccountInformationRow
                    .getLookup()
                    .items
                    .filter(b => b.CoaId == accountHeadBank);

            if (_bankAccInfoList.length > 0) {
                //
                // Lets assume, Only one bank account is mapped with one account head
                let accInfo = _bankAccInfoList[0];
                //var _chequeBookList: AccChequeBookRow[];

                //if (this.form.VoucherTypeId.value == VoucherType.Payment_Voucher.toString()) {
                //    //
                //    _chequeBookList =
                //        Transaction.AccChequeBookRow.getLookup().items
                //            .filter(b => b.BankAccountInformationId == accInfo.Id && b.HasFinished == false);

                //    if (_chequeBookList.length > 0) {
                //        //
                //        for (var item of _chequeBookList) {
                //            //
                //            this.form.ChequeBookId.addItem({
                //                id: item.Id.toString(),
                //                text: item.CheckBookName + ' {' + accInfo.AccountNumber + '}',
                //                source: null,
                //                disabled: false
                //            }); //
                //        } //
                //    } //
                //} //


                this.form.BankAccountInformationId.value = accInfo.Id.toString();

                if (this.isNew()) {
                    this.setNewVoucherNumber(this.form.TransactionTypeEntityId.value);
                }
                //
            }
        }

        public populateChequeNumber(chequeBookId) {

            this.form.ChequeNumhdn.clearItems();
            this.form.ChequeNumhdn.value = "";

            this.form.IsChequeFinished.value = false;
            let LastChqNo: number = 0;

            let chequeRegisterCriteria = Serenity.Criteria.and([['ChequeBookId'], '=', chequeBookId.toString()], [['IsCancelled'], '<', 1]);

            //{ Criteria: [['ChequeBookId'], '=', chequeBookId.toString()] }
            Transaction.AccChequeRegisterService.List({ Criteria: chequeRegisterCriteria as any }, r => {
                let chqReg: Transaction.AccChequeRegisterRow[];
                chqReg = r.Entities;

                if (chqReg.length > 0) {
                    var lstEntity = chqReg[chqReg.length - 1];
                    LastChqNo = lstEntity.ChequeNumhdn;
                }
            });

            //generate cheque no
            Transaction.AccChequeBookService.List({ Criteria: [['Id'], '=', chequeBookId.toString()] }, r => {
                let _Unionitems = r.Entities;

                this.form.BankAccountInformationId.value = r.Entities[0].BankAccountInformationId.toString();

                //var declare
                let prefix: string = "";
                let strNo: number = 0;
                let endNo: number = 0;
                let strNoLength: number = 0;

                strNoLength = _Unionitems[0].StartingNo.length;
                prefix = _Unionitems[0].Prefix;
                strNo = +_Unionitems[0].StartingNo;
                endNo = _Unionitems[0].EndingNo;

                let strNumberPerfix = _Unionitems[0].StartingNo.toString();

                let genChqNoWithPrefix: string = "";
                let genNoWithOutPrefix: number;

                if (LastChqNo > 0 && LastChqNo < endNo) {
                    if (prefix == undefined) {
                        genChqNoWithPrefix = (LastChqNo + 1).toString();
                    }
                    else {
                        genChqNoWithPrefix = prefix + (LastChqNo + 1);
                    }
                    genNoWithOutPrefix = LastChqNo + 1;

                    if (genNoWithOutPrefix == endNo) {
                        this.form.IsChequeFinished.value = true;
                    }
                }
                else if (LastChqNo == 0) {
                    if (prefix == undefined) {
                        genChqNoWithPrefix = strNo.toString();
                    }
                    else {
                        genChqNoWithPrefix = prefix + strNo;
                    }
                    genNoWithOutPrefix = strNo;
                }


                if (endNo == LastChqNo) {
                    Q.notifyWarning("There are no remaing cheque no.");
                }

                function pad(n, width, z) { while (n.length < width) n = '' + z + n; return n; }

                let ChequeNoList = [];
                for (strNo; strNo <= endNo; strNo++) {
                    var tempChequeNo: string = "";

                    if (prefix == undefined) {
                        tempChequeNo = pad(strNo.toString(), strNoLength, "0").toString();
                    }
                    else {
                        tempChequeNo = prefix + pad(strNo.toString(), strNoLength, "0");
                    }
                    let newChequeNo = {
                        text: tempChequeNo,
                        id: strNo.toString()
                    };
                    ChequeNoList.push(newChequeNo);
                }


                let data: AccChequeRegisterRow[];
                Q.reloadLookup("Transaction.AccChequeRegister_Lookup_ALL");
                data = Q.getLookup("Transaction.AccChequeRegister_Lookup_ALL").items;
                data = data.filter(p => p.ChequeBookId == chequeBookId);

                //data = AccChequeRegisterRow.getLookup().items;
                //data = data.filter(p => p.ChequeBookId == chequeBookId);
                for (var i = 0, l = ChequeNoList.length; i < l; i++) {

                    let ddloption = ChequeNoList[i];

                    if (Q.count(data, o => o.ChequeNo == ddloption.text) == 0) {
                        this.form.ChequeNumhdn.addItem({
                            id: ddloption.id.toString(), text: ddloption.text.toString(), source: null, disabled: false
                        });
                    }
                }
            });
        }

        public changePvSubLedger() {
            var selectedPayto = this.form.PaytoOrReciveFrom.value;
            //var indexofFirstHighphen = selectedPayto.indexOf('-');
            //if (indexofFirstHighphen > 0) indexofFirstHighphen = indexofFirstHighphen + 1;
            //var onlyNamePart = selectedPayto.substring(indexofFirstHighphen, selectedPayto.length).trim();

            var costCentersByPayTo =
                AccCostCentreOrInstituteInformationRow.getLookup().items.filter(f => f.Name == selectedPayto);

            if (costCentersByPayTo.length > 0) {
                //var data = AccNoaRow.getLookup().items.filter(f => f.CostCenterId = costCentersByPayTo[0].Id);
                //this.form.NOAId.value = data[0].Id.toString();

                if (costCentersByPayTo[0].Id.toString() != 'undefined')
                    this.form.AutoPV_CostCentreId.value = costCentersByPayTo[0].Id.toString();
                if (costCentersByPayTo[0].NameForBankAdviceLetter != 'undefined')
                    this.form.PaytoForBankAdvice.value = costCentersByPayTo[0].NameForBankAdviceLetter.toString();
            }
        }

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

        public sumDebitCredit() {
            var dAmount = 0;
            var cAmount = 0;

            for (var item of this.form.VoucherDetails.value) {
                if (item.CreditAmount == undefined || item.CreditAmount == null) { }
                else if (item.CreditAmount.toString() != "NaN") {
                    cAmount += item.CreditAmount;
                }

                if (item.DebitAmount == undefined || item.DebitAmount == null) { }
                else if (item.DebitAmount.toString() != "NaN") {
                    dAmount += item.DebitAmount;
                }
            }

            this.form.AccountBankCash.value = this.form.AccountHeadBankCash.get_text();

            switch (this.form.VoucherTypeId.value) {
                case VoucherType.Payment_Voucher.toString():
                    this.form.AccountBankCashAmount.value = dAmount - cAmount;
                    this.form.DAmount.value = dAmount;
                    this.form.CAmount.value = cAmount + this.form.AccountBankCashAmount.value;
                    break;

                case VoucherType.Receipt_Voucher.toString():
                    this.form.AccountBankCashAmount.value = cAmount - dAmount;
                    this.form.CAmount.value = cAmount;
                    this.form.DAmount.value = dAmount + this.form.AccountBankCashAmount.value;
                    break;

                default:
            }


            this.form.BankAmount.value = this.form.AccountBankCashAmount.value;
            this.form.Amount.value = this.form.AccountBankCashAmount.value;
            this.form.AmountInWords.value = VoucherUtil.currencyToWords(this.form.AccountBankCashAmount.value);


            this.clearData();
        }

        public setNewVoucherNumber(transactionTypeId) {

            this.form.VoucherNo.value = "";
            this.form.VoucherNumber.value = "";
            this.form.AutoJVVoucherNo.value = '';
            this.form.AutoJVVoucherNumber.value = '';

            let voucherDate = new Date(this.form.VoucherDate.value);
            let financialYearId = Number(this.form.PostingFinancialYearId.value);
            let bankAccId = Number(this.form.BankAccountInformationId.value);
            let fundControlId: number = this.fundControlId;
            let zoneId: number = this.zoneId;

            VoucherUtil.newVoucherNumberFactory(this._VoucherConfiguration, transactionTypeId, voucherDate, financialYearId, fundControlId, zoneId, bankAccId, (_voucherNo, _voucherNumber) => {
                //
                $('.VoucherNo input').val(_voucherNo);
                $('.VoucherNumber input').val(_voucherNumber);
            });

        }

        private VoucherDateChange() {
            var _VoucherDate = this.form.VoucherDate.valueAsDate;

            var _piriod = this._AccountingPeriod.filter(j => _VoucherDate >= Q.parseISODateTime(j.PeriodStartDate) && _VoucherDate <= Q.parseISODateTime(j.PeriodEndDate));

            if (_piriod.length == 0) {
                Q.alert("Sorry, Accounting period not found.");
            }
            else {
                if (_piriod[0].IsClosed == true) {
                    Q.alert("This accounting period - " + _piriod[0].YearName + " is closed! You cannot create/modify voucher.");
                    this.form.VoucherNo.value = "";
                }
                else {
                    this.form.PostingFinancialYearId.value = _piriod[0].Id.toString();
                }
            }
        }

        protected clearData() {
            //this.form.AccountHead.value = null;
            //this.form.AccountHeadBankCash.value = null;

            this.form.CreditAmount.value = 0;
            this.form.DebitAmount.value = 0;
            this.form.DDescription.value = "";
            this.form.ConversionAmount.value = 0;
            this.form.ConversionRate.value = 0;
            this.form.MultiCurrency.value = "";
            this.form.MultipleCostCenter.value = false;

            $("#lbConversionRate").text("");
        }

        public getBudgetAmount(headId, IsCoa: boolean, IsAutoJV: boolean) {

            let budgetAmount = 0;
            this.budgetHeadList = Q.getLookup("Transaction.AccBudgetDetails_Lookup").items;
            budgetAmount = this.budgetHeadList.filter(x => x.BudgetHeadId == headId)[0] == undefined ? 0 : this.budgetHeadList.filter(x => x.BudgetHeadId == headId)[0].BudgetAmount;

            if (IsAutoJV) {
                if (IsCoa) {
                    this.form.AutoBudgetAmountCOA.value = budgetAmount;
                }
                else {
                    this.form.AutoBudgetAmountSUbledger.value = budgetAmount;
                }
            }
            else {
                if (IsCoa) {
                    this.form.BudgetAmountCOA.value = budgetAmount;
                }
                else {
                    this.form.BudgetAmountSUbledger.value = budgetAmount;
                }
            }
        }

    }
}