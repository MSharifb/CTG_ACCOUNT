
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccPartyPaymentDialog extends Serenity.EntityDialog<AccPartyPaymentRow, any> {
        protected getFormKey() { return AccPartyPaymentForm.formKey; }
        protected getIdProperty() { return AccPartyPaymentRow.idProperty; }
        protected getLocalTextPrefix() { return AccPartyPaymentRow.localTextPrefix; }
        protected getNameProperty() { return AccPartyPaymentRow.nameProperty; }
        protected getService() { return AccPartyPaymentService.baseUrl; }
             public items_ChartofAccounts: Configurations.AccChartofAccountsRow[];
        public AccChequeRegister: AccChequeRegisterRow[];


        protected form = new AccPartyPaymentForm(this.idPrefix);

               onDialogOpen(): void {
            super.onDialogOpen();

            //this.form.CoAId.clearItems();
            //this.form.ChequeRegisterId.clearItems();

            this.items_ChartofAccounts = Q.getLookup('Configurations.AccChartofAccounts_Lookup').items;
            this.AccChequeRegister = Q.getLookup('Transaction.AccChequeRegister_Lookup').items;
            //    console.log(this.items_ChartofAccounts);

            this.form.CoAId.changeSelect2(p1 => {
                //   console.log(this.form.CoAId.value);
                var _AccChequeRegister = this.AccChequeRegister.filter(p => p.BankAccountInformationCoaId == +this.form.CoAId.value);
                this.form.ChequeRegisterId.value = "";
                this.form.ChequeRegisterId.clearItems();
                for (var item of _AccChequeRegister) {
                    //  var str = items[i];
                    this.form.ChequeRegisterId.addItem({ id: item.Id.toString(), text: item.ChequeNo, source: null, disabled: false });
                }
            });

            this.form.TransactionMode.changeSelect2(p => {
                //  console.log(this.form.TransactionMode.value);
                var items = this.items_ChartofAccounts.filter(f => f.IsControlhead == 0 && f.CoaMapping == this.form.TransactionMode.value);
                this.form.CoAId.value = "";
                this.form.CoAId.clearItems();
                for (var item of items) {
                    // var str = items[i];
                    this.form.CoAId.addItem({ id: item.Id.toString(), text: item.AccountName, source: null, disabled: false });
                }
            });
            Serenity.EditorUtils.setReadonly(this.element.find(this.form.RemainAmount.element), true);
            if (!this.isNew()) {
                this.form.Amount.value = this.form.RemainAmount.value;
                this.toolbar.findButton('Process-Payment').toggleClass('disabled');
                if (this.form.RemainAmount.value == 0) {
                    this.toolbar.findButton('Process-Adjustment').toggleClass('disabled');
                      this.toolbar.findButton('Process-Receipt').toggleClass('disabled');
                } else { this.toolbar.findButton('Process-Adjustment').removeClass('disabled'); this.toolbar.findButton('Process-Receipt').removeClass('disabled');}

                if (this.entity.Status == 1) {
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.PartyId.element), true);
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.TransactionMode.element), true);
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.CoAId.element), true);
                    Serenity.EditorUtils.setReadonly(this.element.find(this.form.ChequeRegisterId.element), true);

                }
            }
            else {
                this.toolbar.findButton('Process-Adjustment').toggleClass('disabled');
                 this.toolbar.findButton('Process-Receipt').toggleClass('disabled');
                this.form.CoAId2.value = "130";
            }
        }


            protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();

            buttons.push({
                title: "Process Payment", cssClass: "send-button Process-Payment",

                onClick: (x) => {

                    //if (this.entityId != undefined) {
                    var b = (new AccVoucherInformationDialog());
                    var entity_voucher: AccVoucherInformationRow;
                    entity_voucher = {};


                    entity_voucher.VoucherTypeId = 1;

                    //
                    entity_voucher.TransactionMode = this.form.TransactionMode.value;

                    entity_voucher.TemplateId = this.entityId;
                    entity_voucher.TemplateStatus = 3;
                    entity_voucher.TemplateCOAId = +this.form.CoAId.value;
                    entity_voucher.TemplateChequeRegisterId = +this.form.ChequeRegisterId.value;
                    entity_voucher.TemplateCOAId2 = +this.form.CoAId2.value;

                    b.loadEntityAndOpenDialog(entity_voucher);

                    //   b.form.VoucherTypeId.value = "1";

                    b.form.TransactionTypeEntityId.value = b.form.TransactionTypeEntityId.items[0].id;


                    b.setNewVoucherNumber();
                    b.loadAccountHead();



                    b.form.CreditAmount.value = this.form.Amount.value;
                    b.form.AccountHead.value = this.form.CoAId.value.toString();
                    b.loadCheque();
                    b.form.ChequeRegisterId.value = this.form.ChequeRegisterId.value;
                    b.setMultiCurrencyCurrency(null, null, false);

                    b.form.ConversionAmount.value = b.form.ConversionRate.value * this.form.Amount.value;
                    b.form.PaytoOrReciveFrom.value = this.form.PartyId.get_text();
                    //  b.form.Description.value = this.form.Remarks.value;
                    b.addtoGrid();

                    b.form.CreditAmount.value = 0;
                    b.form.DebitAmount.value = this.form.Amount.value;
                    b.form.AccountHead.value = this.form.CoAId2.value;
                    b.setMultiCurrencyCurrency(null, null, false);
                    b.form.ConversionAmount.value = b.form.ConversionRate.value * this.form.Amount.value;
                    b.addtoGrid();
                   b.form.EmpId.value = +this.form.PartyId.value;
                    b.form.Description.value = this.form.Narration.value;
                    b.onAfterSaveSuccess = () => {

                        this.dialogClose();

                        Serenity.SubDialogHelper.triggerDataChange(this);

                    };
                    //  b.dialogOpen()
                    //} else {
                    //    Q.alert("Id not found.");
                    //}
                }
            });

            buttons.push({
                title: "Process Adjustment", cssClass: "send-button Process-Adjustment",

                onClick: (x) => {

                    if (this.entityId != undefined) {
                        var b = (new AccVoucherInformationDialog());
                        var entity_voucher: AccVoucherInformationRow;
                        entity_voucher = {};


                        entity_voucher.VoucherTypeId = 3;

                        //
                        entity_voucher.TransactionMode = this.form.TransactionMode.value;

                        entity_voucher.TemplateId = this.entityId;
                        entity_voucher.TemplateStatus = 4;
                        //   entity_voucher.TemplateCOAId = +this.form.CoAId.value;


                        b.loadEntityAndOpenDialog(entity_voucher);

                        //   b.form.VoucherTypeId.value = "1";

                        b.form.TransactionTypeEntityId.value = b.form.TransactionTypeEntityId.items[0].id;


                        b.setNewVoucherNumber();
                        b.loadAccountHead();



                        b.form.DebitAmount.value = this.form.Amount.value;
                        b.form.AccountHead.value = this.form.CoAId.value.toString();
                        b.loadCheque();
                        b.form.ChequeRegisterId.value = this.form.ChequeRegisterId.value;
                        b.setMultiCurrencyCurrency(null, null, false);

                        b.form.ConversionAmount.value = b.form.ConversionRate.value * this.form.Amount.value;
                        b.form.PaytoOrReciveFrom.value = this.form.PartyId.get_text();
                        //  b.form.Description.value = this.form.Remarks.value;
                        b.addtoGrid();

                        b.form.DebitAmount.value = 0;
                        b.form.CreditAmount.value = this.form.Amount.value;
                        b.form.AccountHead.value = this.form.CoAId2.value;
                        b.setMultiCurrencyCurrency(null, null, false);
                        b.form.ConversionAmount.value = b.form.ConversionRate.value * this.form.Amount.value;
                        b.addtoGrid();
                      //  b.form.EmpId.value = +this.form.PartyId.value;
                        b.form.RemainAmount.value = this.form.RemainAmount.value;
                        b.form.Description.value = this.form.Narration.value;
                        b.onAfterSaveSuccess = () => {

                            this.dialogClose();

                            Serenity.SubDialogHelper.triggerDataChange(this);

                        };

                        //  b.dialogOpen()
                    } else {
                        Q.alert("Id not found.");
                    }
                }
            });

                    buttons.push({
                title: "Process Receipt", cssClass: "send-button Process-Receipt",

                onClick: (x) => {

                    if (this.entityId != undefined) {
                        var b = (new AccVoucherInformationDialog());
                        var entity_voucher: AccVoucherInformationRow;
                        entity_voucher = {};


                        entity_voucher.VoucherTypeId = 2;

                        //
                        entity_voucher.TransactionMode = this.form.TransactionMode.value;

                        entity_voucher.TemplateId = this.entityId;
                        entity_voucher.TemplateStatus = 4;
                        //   entity_voucher.TemplateCOAId = +this.form.CoAId.value;


                        b.loadEntityAndOpenDialog(entity_voucher);

                        //   b.form.VoucherTypeId.value = "1";

                        b.form.TransactionTypeEntityId.value = b.form.TransactionTypeEntityId.items[0].id;


                        b.setNewVoucherNumber();
                        b.loadAccountHead();



                        b.form.DebitAmount.value = this.form.Amount.value;
                        b.form.AccountHead.value = this.form.CoAId.value.toString();
                        b.loadCheque();
                        b.form.ChequeRegisterId.value = this.form.ChequeRegisterId.value;
                        b.setMultiCurrencyCurrency(null, null, false);

                        b.form.ConversionAmount.value = b.form.ConversionRate.value * this.form.Amount.value;
                        b.form.PaytoOrReciveFrom.value = this.form.PartyId.get_text();
                        //  b.form.Description.value = this.form.Remarks.value;
                        b.addtoGrid();

                        b.form.DebitAmount.value = 0;
                        b.form.CreditAmount.value = this.form.Amount.value;
                        b.form.AccountHead.value = this.form.CoAId2.value;
                        b.setMultiCurrencyCurrency(null, null, false);
                        b.form.ConversionAmount.value = b.form.ConversionRate.value * this.form.Amount.value;
                        b.addtoGrid();
                       // b.form.EmpId.value = +this.form.PartyId.value;
                        b.form.RemainAmount.value = this.form.RemainAmount.value;
                        b.form.Description.value = this.form.Narration.value;
                        b.onAfterSaveSuccess = () => {

                            this.dialogClose();

                            Serenity.SubDialogHelper.triggerDataChange(this);

                        };

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