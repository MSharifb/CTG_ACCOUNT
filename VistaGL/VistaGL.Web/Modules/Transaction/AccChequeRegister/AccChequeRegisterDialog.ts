
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccChequeRegisterDialog extends Serenity.EntityDialog<AccChequeRegisterRow, any> {
        protected getFormKey() { return AccChequeRegisterForm.formKey; }
        protected getIdProperty() { return AccChequeRegisterRow.idProperty; }
        protected getLocalTextPrefix() { return AccChequeRegisterRow.localTextPrefix; }
        protected getNameProperty() { return AccChequeRegisterRow.nameProperty; }
        protected getService() { return AccChequeRegisterService.baseUrl; }

        protected form = new AccChequeRegisterForm(this.idPrefix);
        public dig: Transaction.AccVoucherBankWiseDialog;
        public digforOnlyPayment: AccVoucherInformationDialog;

        public _isFromVoucher: boolean;
        public _isPaymentOrReceiptVoucherOnly: boolean;


        constructor() {
            super();
            //get bank account Info
            this.form.BankAccountInformationId.changeSelect2(e => {
                this.BankAccountInformation_Change();

            });

            //get checkbook no
            this.form.ChequeBookId.changeSelect2(e => {
                this.ChequeBookInformation_Change();
            });

            //Set ChequeNumhdn
            this.form.ChequeNo.changeSelect2(e => {
                this.form.ChequeNoTemp.value = "";
                this.form.ChequeNumhdn.value = null;

                this.form.ChequeNumhdn.value = +this.form.ChequeNo.value;
                this.form.ChequeNoTemp.value = this.form.ChequeNo.get_text();
            });
        }

        protected onDialogOpen(): void {

            //  let parentDialog = (this.parentEditor.parentDialog as AccVoucherInformationDialog);
            if (this._isFromVoucher) {
                let data = Configurations.AccBankAccountInformationRow.getLookup().items;
                if (this.form.Remarks.value != '' && this.form.Remarks.value != undefined) {
                    data = data.filter(x => x.CoaId == +this.form.Remarks.value);
                }
                this.form.BankAccountInformationId.clearItems();
                this.form.Remarks.value = '';
                for (var i = 0; i < data.length; i++) {
                    var str = data[i];
                    this.form.BankAccountInformationId.addItem({ id: str.Id.toString(), text: str.AccountNumber, source: null, disabled: false })

                    let l = data.length;
                    if (i == 0) {
                        this.form.BankAccountInformationId.value = str.Id.toString();
                    }
                }
                this.toolbar.findButton('save-and-close-button').hide();
                this.toolbar.findButton('apply-changes-button').hide();
                this.toolbar.findButton('print-preview-button').hide();

                this.BankAccountInformation_Change();
                this.ChequeBookInformation_Change();
            }
            else {
                this.toolbar.findButton('send-button').hide();
            }

            if (this.isEditMode()) {
                this.BankAccountInformation_Change();
                this.ChequeBookInformation_Change();

                if (this.entity.IsBankAdvice) {
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.IsCancelled.element), true);
                }
            }
        }

        //bank account Info
        protected BankAccountInformation_Change() {
            //   console.log(this.form.BankAccountInformationId.value);
            if (this.form.BankAccountInformationId.value == "") {
                this.form.AccountName.value = "";
                this.form.BankName.value = "";
                this.form.BranchName.value = "";
                this.form.ChequeNo.clearItems();
                this.form.ChequeNoTemp.value = "";
                this.form.ChequeNumhdn.value = null;
            }
            else {
                var selectedItem = Configurations.AccBankAccountInformationRow.getLookup().itemById[this.form.BankAccountInformationId.value];

                this.form.AccountName.value = selectedItem.AccountName;
                this.form.BankName.value = selectedItem.BankBankName;
                this.form.BranchName.value = selectedItem.BankBranchBranchName;
            }
        }

        //get checkbook info
        protected ChequeBookInformation_Change() {

            this.form.ChequeNo.clearItems();

            this.form.IsFinished.value = false;
            //this.form.ChequeNo.value = '';

            var LastChqNo: number = 0;
            VistaGL.Transaction.AccChequeRegisterService.List({ Criteria: [['ChequeBookId'], '=', this.form.ChequeBookId.value] }, r => {
                var chqReg: Transaction.AccChequeRegisterRow[];
                chqReg = r.Entities;

                if (chqReg.length > 0) {
                    var lstEntity = chqReg[chqReg.length - 1];
                    LastChqNo = lstEntity.ChequeNumhdn;
                    // console.log(LastChqNo);
                }
            });

            //generate cheque no
            VistaGL.Transaction.AccChequeBookService.List({ Criteria: [['Id'], '=', this.form.ChequeBookId.value] }, r => {
                var _Unionitems = r.Entities;

                //var declare
                var prefix: string = "";
                var strNo: number = 0;
                var endNo: number = 0;
                var strNoLength: number = 0;

                strNoLength = _Unionitems[0].StartingNo.length;
                prefix = _Unionitems[0].Prefix;
                strNo = +_Unionitems[0].StartingNo;
                endNo = _Unionitems[0].EndingNo;

                let strNumberPerfix = _Unionitems[0].StartingNo.toString();

                //console.log("prefix: " + prefix);
                //console.log("strNo: " + strNo);
                //console.log("endNo: " + endNo);
                //console.log("LastChqNo: " + LastChqNo);

                var genChqNoWithPrefix: string = "";
                var genNoWithOutPrefix: number;

                if (LastChqNo > 0 && LastChqNo < endNo) {
                    if (prefix == undefined) {
                        genChqNoWithPrefix = (LastChqNo + 1).toString();
                    }
                    else {
                        genChqNoWithPrefix = prefix + (LastChqNo + 1);
                    }
                    genNoWithOutPrefix = LastChqNo + 1;

                    if (genNoWithOutPrefix == endNo) {
                        this.form.IsFinished.value = true;
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
                    Q.notifyWarning("there is no remaing cheque no.");
                }
                //this.form.ChequeNo.value = genChqNoWithPrefix;
                //this.form.ChequeNumhdn.value = genNoWithOutPrefix;
                //console.log("with= "+genChqNoWithPrefix);
                //console.log("without= "+genNoWithOutPrefix);

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

                //Q.reloadLookup("Transaction.AccChequeRegister_Lookup");
                let data: AccChequeRegisterRow[];
                //data = Q.getLookup('Transaction.AccChequeRegister_Lookup').items;
                data = AccChequeRegisterRow.getLookup().items;
                if (!this.isNew()) {
                    this.form.ChequeNoTemp.value = this.entity.ChequeNo;
                    data = data.filter(p => p.ChequeBookId == +this.form.ChequeBookId.value && p.ChequeNo != this.entity.ChequeNo);

                    for (var i = 0, l = ChequeNoList.length; i < l; i++) {

                        let ddloption = ChequeNoList[i];
                        if (Q.count(data, o => o.ChequeNo == ddloption.text) == 0) {

                            this.form.ChequeNo.addItem({ id: ddloption.id.toString(), text: ddloption.text.toString(), source: null, disabled: false });
                        }
                    }
                    this.form.ChequeNo.value = this.entity.ChequeNumhdn.toString();
                }
                else {
                    //var data = AccChequeRegisterRow.getLookup().items.filter(p => p.ChequeBookId == +this.form.ChequeBookId.value);
                    //console.log(data);
                    data = data.filter(p => p.ChequeBookId == +this.form.ChequeBookId.value);
                    //console.log(data);
                    for (var i = 0, l = ChequeNoList.length; i < l; i++) {

                        let ddloption = ChequeNoList[i];

                        if (Q.count(data, o => o.ChequeNo == ddloption.text) == 0) {

                            this.form.ChequeNo.addItem({ id: ddloption.id.toString(), text: ddloption.text.toString(), source: null, disabled: false });
                        }
                    }
                }

            });

        }

        protected validateBeforeSave() {

            if (this.form.Amount.value <= 0 && this.form.IsCancelled.value == false) {
                Q.alert("Amount must be greather than zero.");
                return false;
            }
            return true;
        }


        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push({
                title: "Add", cssClass: "send-button",

                onClick: (x) => {

                    this.save(p => {

                        if (this._isPaymentOrReceiptVoucherOnly) {

                            this.digforOnlyPayment.form.PaytoOrReciveFrom.value = this.form.PayTo.value;

                            if (this.digforOnlyPayment.form.VoucherTypeId.value == "1")
                                this.digforOnlyPayment.form.CreditAmount.value = this.form.Amount.value;
                            else
                                this.digforOnlyPayment.form.DebitAmount.value = this.form.Amount.value;

                            Q.reloadLookup("Transaction.AccChequeRegister_Lookup");
                            let data: AccChequeRegisterRow[];
                            data = Q.getLookup('Transaction.AccChequeRegister_Lookup').items;
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
                            this.dig.form.PaytoOrReciveFrom.value = this.form.PayTo.value;
                            this.dig.form.BankAmount.value = this.form.Amount.value;

                            if (this.dig.form.VoucherTypeId.value == "1")
                                this.dig.form.DebitAmount.value = this.form.Amount.value;
                            else
                                this.dig.form.CreditAmount.value = this.form.Amount.value;


                            Q.reloadLookup("Transaction.AccChequeRegister_Lookup");
                            let data: AccChequeRegisterRow[];
                            data = Q.getLookup('Transaction.AccChequeRegister_Lookup').items;
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

            buttons.push({
                title: "Process", cssClass: "print-preview-button",

                onClick: (x) => {

                    //            this.editItem(<AccVoucherInformationRow>{
                    //    VoucherTypeId: 1
                    //});
                    // console.log(this.entity.BankAccountInformationCoaId);
                    if (this.entity.IsUsed) {
                        Q.alert("used.");
                        return;
                    }
                    if (this.entityId != undefined) {
                        var b = (new AccVoucherInformationDialog());
                        var entity_voucher: AccVoucherInformationRow;
                        entity_voucher = {};


                        entity_voucher.VoucherTypeId = 1;

                        //
                        entity_voucher.TransactionMode = "BANK";


                        b.loadEntityAndOpenDialog(entity_voucher);

                        //   b.form.VoucherTypeId.value = "1";

                        b.form.TransactionTypeEntityId.value = b.form.TransactionTypeEntityId.items[0].id;


                        b.setNewVoucherNumber();
                        b.loadAccountHead();


                        b.form.AccountHead.value = this.entity.BankAccountInformationCoaId.toString();
                        b.form.CreditAmount.value = this.form.Amount.value;
                        b.loadCheque();
                        b.form.ChequeRegisterId.value = this.entityId;
                        b.setMultiCurrencyCurrency(null, null, false);

                        b.form.ConversionAmount.value = b.form.ConversionRate.value * this.form.Amount.value;
                        b.form.PaytoOrReciveFrom.value = this.form.PayTo.value;
                        b.form.Description.value = this.form.Remarks.value;
                        b.addtoGrid();
                        //  b.dialogOpen()
                    } else {
                        Q.alert("Id not found.");
                    }
                }
            });

            return buttons;
        }
    }
}