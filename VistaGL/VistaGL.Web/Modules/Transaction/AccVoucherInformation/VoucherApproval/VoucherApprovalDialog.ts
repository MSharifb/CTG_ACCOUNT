
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class VoucherApprovalDialog extends EntityDialogBase<AccVoucherInformationRow, any> {
        protected getFormKey() { return VoucherApprovalForm.formKey; }
        protected getIdProperty() { return AccVoucherInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherInformationRow.nameProperty; }
        protected getService() { return VoucherApprovalService.baseUrl; }

        public form = new VoucherApprovalForm(this.idPrefix);
        public items_ChartofAccounts: Configurations.AccChartofAccountsRow[];// Configurations.AccChartofAccountsRow.getLookup().items;
        public items_CurrencyConversionRate = Configurations.AccCurrencyConversionRateRow.getLookup().items;
        public AccChequeRegister = Q.getLookup('Transaction.AccChequeRegister_Lookup').items; // AccChequeRegisterRow.getLookup().items;
        public AccTransactionTypeAssign = AccTransactionTypeAssignRow.getLookup().items;
        public _VoucherConfiguration = Transaction.AccVoucherConfigurationRow.getLookup().items;
        protected nextId = 1;
        protected isFristTime = true;
        public _IsCostCenterAllocate = 0;
        public _IsBillRef = 0;
        public _VoucherDtlAllocation: AccVoucherDtlAllocationRow[];

        constructor() {
            super();
            $('.ui-dialog-titlebar-maximize').click();

            this.byId('ApplicationInformationHistory').closest('.field').hide().end().appendTo(this.byId('TabNotes'));
        }

        onDialogOpen(): void {
            super.onDialogOpen();
            q.initDetailEditor(this, this.form.VoucherDetails);

            this.form.VoucherDetails.parentDialog = this;

            this.items_ChartofAccounts = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;
            $('.VoucherDetails .grid-toolbar').hide();


            if (!this.isNew()) {

                var dAmount = 0;
                var cAmount = 0;

                for (let item of this.form.VoucherDetails.value) {
                    if (item.CreditAmount == undefined || item.CreditAmount == null) { }
                    else if (item.CreditAmount.toString() != "NaN") {
                        cAmount += item.CreditAmount;
                    }

                    if (item.DebitAmount == undefined || item.DebitAmount == null) { }
                    else if (item.DebitAmount.toString() != "NaN") {
                        dAmount += item.DebitAmount;
                    }
                }

                this.form.DAmount.value = dAmount;
                this.form.CAmount.value = cAmount;

                this.form.Amount.value = this.entity.Amount;
                this.form.AmountInWords.value = this.entity.AmountInWords;

                Serenity.EditorUtils.setReadonly(this.element.find(this.form.TransactionMode.element), true);
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.TransactionTypeEntityId.element), true);


                $('.AutoJVVoucherNo').hide();

                if (this.entity.LinkedWithAutoJV) {

                    Transaction.AccVoucherInformationService.List({ Criteria: [['Id'], '=', this.entity.LinkedVoucherIdForAutoJV] }, r => {
                        $('.AutoJVVoucherNo').show();

                        var linkedVNo = $('.AutoJVVoucherNo')[0];

                        linkedVNo.innerHTML = '<div style="padding-top: 3px; color: blue;">' +
                            '<i><span>Linked Journal Voucher No:&nbsp;&nbsp;</span><u><a href= "JournalVoucher#edit/Id" data-item-type="Transaction.JournalVoucher" data-item-id="Id" class="LinkedJVNo">' + r.Entities[0].VoucherNo + '</a></u></i>' +
                            '</div>';

                        $('.LinkedJVNo').attr({
                            'href': 'JournalVoucher#edit/' + this.entity.LinkedVoucherIdForAutoJV.toString(),
                            'data-item-id': this.entity.LinkedVoucherIdForAutoJV.toString()
                        });

                    });
                }
                else {
                    Transaction.AccVoucherInformationService.List({ Criteria: [['LinkedVoucherIdForAutoJV'], '=', this.entity.Id] }, r => {
                        if (r.Entities[0] != undefined) {
                            $('.LinkedPaymentVoucherNo').show();

                            let linkedVNo = $('.LinkedPaymentVoucherNo')[0];

                            linkedVNo.innerHTML = '<div style="padding-top: 3px; color: blue;">' +
                                '<i><span>Linked Payment Voucher No:&nbsp;&nbsp;</span><u><a href= "Payment#edit/Id" data-item-type="Transaction.PaymentVoucher" data-item-id="Id" class="LinkedPVNo">' +
                                r.Entities[0].VoucherNo +
                                '</a></u></i>' +
                                '</div>';

                            $('.LinkedPVNo').attr({
                                'href': 'Payment#edit/' + r.Entities[0].Id.toString(),
                                'data-item-id': r.Entities[0].Id.toString()
                            });
                        }
                    });
                }
            }

            Transaction.VoucherApprovalService.GetAmountByApprover({ Id: this.entity.Id }, r => {

                var items = r.Entities;

                for (let item of items) {
                    if (item.StepTypeName == "Recommendation") {
                        if (item.MaxAmount >= this.entity.Amount) {
                            //$('.ApproverId').hide();
                        }
                        else {
                            $('.postingSendTo').hide();
                            this.toolbar.findButton('approve-button').hide();
                        }
                    }
                }
            });

            Transaction.VoucherApprovalService.GetPostingSendTo({ Id: this.entity.Id }, r => {
                //
                var items = r.Entities;

                this.form.postingSendTo.clearItems();
                //
                let userInfo = Authorization.userDefinition;
                let fundcontrolAprover = Configurations.AccFundControlZoneWiseApproverRow.getLookup().items.filter(x => x.ZoneInfoId == userInfo.ZoneID && x.FundControlId == userInfo.FundControlInformationId);
                if (fundcontrolAprover.length > 0) {
                    for (let item of items) {
                        // var str = items[i];
                        this.form.postingSendTo.addItem({ id: item.Id.toString(), text: item.FullName, source: null, disabled: false });
                    }
                    this.form.postingSendTo.value = fundcontrolAprover[0].PostingById.toString();
                    // default approver
                    this.form.ApproverId.value = fundcontrolAprover[0].ApproverId.toString();
                }
                else {
                    for (let item of items) {
                        // var str = items[i];
                        this.form.postingSendTo.addItem({ id: item.Id.toString(), text: item.FullName, source: null, disabled: false });
                        if (item.ApproverTypeName == "Main") {
                            this.form.postingSendTo.value = item.Id.toString();
                        }
                    }
                }

            });

            Transaction.VoucherApprovalService.GetRegretList({ Id: this.entity.Id }, r => {
                //
                var items = r.Entities;

                this.form.RegretSendTo.clearItems();
                for (let item of items) {
                    // var str = items[i];
                    this.form.RegretSendTo.addItem({ id: item.Id.toString(), text: item.FullName, source: null, disabled: false });
                    if (item.ApproverTypeName == "Main") {
                        this.form.RegretSendTo.value = item.Id.toString();
                    }
                }
            });

            // title change Voucher type wise
            if (this.form.VoucherTypeId.value == "1") {
                this.set_dialogTitle("Payment Voucher");
            } else if (this.form.VoucherTypeId.value == "2") {
                this.set_dialogTitle("Receipt Voucher");
            } else if (this.form.VoucherTypeId.value == "3") {
                this.set_dialogTitle("Journal/Adjustment Voucher ");
            }

            Transaction.VoucherApprovalService.GetNextApprover({ Id: this.entity.Id }, r => {

                var items = r.Entities;

                this.form.ApproverId.clearItems();
                for (let item of items) {
                    // var str = items[i];
                    this.form.ApproverId.addItem({ id: item.Id.toString(), text: item.FullName, source: null, disabled: false });
                }

            });
        }

        protected validateBeforeSave() {
            var result = super.validateBeforeSave();

            if (this.form.VoucherTypeId.value == "1" && this.form.PaytoOrReciveFrom.value == "") {
                Q.alert("Enter Pay To Please!");
                result = false;

            }

            if (result) {
                if (this.form.CAmount.value - this.form.DAmount.value != 0) {
                    Q.alert("Debit Amount and Credit Amount not match.");
                    result = false;
                }
            }

            return result;
        }

        protected afterLoadEntity() {
            super.afterLoadEntity();
        }

        protected getToolbarButtons() {
            var buttons = []; //super.getToolbarButtons();
            //buttons.shift();
            //buttons.shift();
            buttons.push({
                title: "Recommend", cssClass: "send-button",

                onClick: (x) => {

                    let message = "Are you sure you want to Recommend?";

                    Q.confirm(message, () => {
                        if (this.form.ApproverId.value == "") {
                            Q.alert("Select Approver Please!");
                            return;
                        }

                        this.form.approveStatus.value = ApprovalStatus.Recommend.toString();
                        this.form.ApprovalAction.value = ApprovalStatus.Recommend.toString();
                        this.form.EmpId.value = +this.form.ApproverId.value;

                        //  this.form.PostingDate.value = this.form.VoucherDate.value;
                        //    this.form.PostedBy.value = Authorization.userDefinition.EmpId.toString();
                        // this.form.PostToLedger.value = 1;
                        this.save(p => { Q.notifySuccess("success"); this.dialogClose(); });
                    }
                    );
                }
            });

            buttons.push({
                title: "Approve", cssClass: "approve-button",

                onClick: (x) => {

                    let message = "Are you sure you want to Approve?";

                    Q.confirm(message, () => {

                        if (this.form.postingSendTo.value == "") {
                            Q.alert("Select Send To Please!");
                            return;
                        }
                        this.form.approveStatus.value = ApprovalStatus.Approved.toString();
                        this.form.ApprovalAction.value = ApprovalStatus.Approved.toString();

                        //  this.form.PostingDate.value = this.form.VoucherDate.value;
                        //    this.form.PostedBy.value = Authorization.userDefinition.EmpId.toString();
                        // this.form.PostToLedger.value = 1;
                        this.save(p => { Q.notifySuccess("success"); this.dialogClose(); });
                    }
                    );
                }
            });


            buttons.push({
                title: "Cancel", cssClass: "reject",

                onClick: (x) => {
                    let message = 'Are you sure you want to Cancel?';
                    Q.confirm(message, () => {
                        if (this.form.ApprovalComments.value == "") {
                            Q.notifyWarning("Enter Comments Please!");
                            return;
                        }
                        this.form.approveStatus.value = ApprovalStatus.Cancel.toString();
                        this.form.ApprovalAction.value = ApprovalStatus.Cancel.toString();
                        this.save(p => { Q.notifySuccess("Cancel"); this.dialogClose(); });
                    }
                    );
                }
            });

            buttons.push({
                title: "Regret", cssClass: "send-button",

                onClick: (x) => {
                    let message = 'Are you sure you want to Regret?';
                    Q.confirm(message, () => {
                        if (this.form.RegretSendTo.value == "") {
                            Q.notifyWarning("Select Regret To Please!");
                            return;
                        }
                        if (this.form.ApprovalComments.value == "") {
                            Q.notifyWarning("Enter Comments Please!");
                            return;
                        }
                        this.form.approveStatus.value = ApprovalStatus.Regret.toString();
                        this.form.ApprovalAction.value = ApprovalStatus.Regret.toString();
                        this.form.EmpId.value = +this.form.ApproverId.value;
                        this.save(p => { Q.notifySuccess("Regret"); this.dialogClose(); });
                    }
                    );
                }
            });

            return buttons;
        }

        protected toWords(s) {

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
            for (let i = 0; i < x; i++) {
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
    }
}