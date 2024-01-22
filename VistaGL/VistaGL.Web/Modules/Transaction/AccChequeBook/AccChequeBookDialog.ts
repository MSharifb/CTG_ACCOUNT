
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccChequeBookDialog extends Serenity.EntityDialog<AccChequeBookRow, any> {
        protected getFormKey() { return AccChequeBookForm.formKey; }
        protected getIdProperty() { return AccChequeBookRow.idProperty; }
        protected getLocalTextPrefix() { return AccChequeBookRow.localTextPrefix; }
        protected getNameProperty() { return AccChequeBookRow.nameProperty; }
        protected getService() { return AccChequeBookService.baseUrl; }

        protected form = new AccChequeBookForm(this.idPrefix);

        constructor(container: JQuery) {
            super();
            this.form.BankAccountInformationId.changeSelect2(e => {
                this.BankAccountInformation_Change();
            });

            //this.form.StartingNo.change(e => {
            //    this.CalculateEndingPageNo_Change();
            //});
            //this.form.PageNo.change(e => {
            //    this.CalculateEndingPageNo_Change();
            //});

            this.form.StartingNo.element.on('change keyup blur', () => {
                this.CalculateEndingPageNo_Change();
            });

            this.form.PageNo.element.on('change keyup blur', () => {
                this.CalculateEndingPageNo_Change();
            });
        }

        protected CalculateEndingPageNo_Change() {
            var strpagNo = +this.form.StartingNo.value;
            var pagNo = this.form.PageNo.value;
            if (strpagNo != NaN && strpagNo > 0 && pagNo != NaN && pagNo > 0) {
                this.form.EndingNo.value = ((strpagNo + pagNo) - 1);
            }
        }

        protected BankAccountInformation_Change() {
            //   console.log(this.form.BankAccountInformationId.value);
            if (this.form.BankAccountInformationId.value == "") {
                this.form.AccountName.value = "";
                this.form.BankName.value = "";
                this.form.BranchName.value = "";
            }
            else {
                var selectedItem = Configurations.AccBankAccountInformationRow.getLookup().itemById[this.form.BankAccountInformationId.value];

                this.form.AccountName.value = selectedItem.AccountName;
                this.form.BankName.value = selectedItem.BankBankName;
                this.form.BranchName.value = selectedItem.BankBranchBranchName;
                //  this.form.DistrictId.value = selectedItem.DistrictId.toString();
            }
        }

        protected onDialogOpen(): void {

            if (this.isEditMode()) {
                this.BankAccountInformation_Change();
                this.CalculateEndingPageNo_Change();

                var chequeRegister = AccChequeReceiveRegisterRow.getLookup().items.filter(x => x.Id == this.entityId);
                if (chequeRegister.length > 0) {
                    Serenity.EditorUtils.setReadonly($('.BankAccountInformationId input'), true);
                }
            }
        }
    }
}