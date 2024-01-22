
namespace VistaGL.Transaction {
    @Serenity.Decorators.maximizable()
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccVoucherTemplateDialog extends Serenity.EntityDialog<AccVoucherTemplateRow, any> {
        protected getFormKey() { return AccVoucherTemplateForm.formKey; }
        protected getIdProperty() { return AccVoucherTemplateRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherTemplateRow.localTextPrefix; }
        protected getNameProperty() { return AccVoucherTemplateRow.nameProperty; }
        protected getService() { return AccVoucherTemplateService.baseUrl; }

        protected form = new AccVoucherTemplateForm(this.idPrefix);

        constructor(container: JQuery) {
            super(container);
            $('.ui-dialog-titlebar-maximize').click();
            this.form.CoaDebitHeadId.changeSelect2(e => {
                // this.isCheckBankHead_Change();
            });

            //calculate SD Amout
            this.form.IsSd.changeSelect2(e => {
                if (!this.form.IsSd.value) {
                    this.form.CoaSdId.value = "";
                    this.form.SdType.value = "";
                    this.form.SdRate.value = null
                }
            });

            //calculate VAT Amout           
            this.form.IsVat.changeSelect2(e => {
                if (!this.form.IsVat.value) {
                    this.form.CoaVatId.value = "";
                    this.form.VatType.value = "";
                    this.form.VatRate.value = null
                }
            });

            //calculate TAX Amout         
            this.form.IsTax.changeSelect2(e => {
                if (!this.form.IsTax.value) {
                    this.form.CoaTaxId.value = "";
                    this.form.TaxType.value = "";
                    this.form.TaxRate.value = null
                }
            });

        }


        protected onDialogOpen(): void {
            if (this.isEditMode()) {
                if (!this.form.IsSd.value) {
                    this.form.CoaSdId.value = "";
                    this.form.SdType.value = "";
                    this.form.SdRate.value = null
                }
                if (!this.form.IsVat.value) {
                    this.form.CoaVatId.value = "";
                    this.form.VatType.value = "";
                    this.form.VatRate.value = null
                }
                if (!this.form.IsTax.value) {
                    this.form.CoaTaxId.value = "";
                    this.form.TaxType.value = "";
                    this.form.TaxRate.value = null
                }
            }

        }
    }
}