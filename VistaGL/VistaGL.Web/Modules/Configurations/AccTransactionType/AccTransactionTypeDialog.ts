
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccTransactionTypeDialog extends EntityDialogBase<AccTransactionTypeRow, any> {
        protected getFormKey() { return AccTransactionTypeForm.formKey; }
        protected getIdProperty() { return AccTransactionTypeRow.idProperty; }
        protected getLocalTextPrefix() { return AccTransactionTypeRow.localTextPrefix; }
        protected getNameProperty() { return AccTransactionTypeRow.nameProperty; }
        protected getService() { return AccTransactionTypeService.baseUrl; }

        protected form = new AccTransactionTypeForm(this.idPrefix);


        protected validateBeforeSave() {

            let data = AccTransactionTypeRow.getLookup().items.filter(q => q.VoucherTypeId == +this.form.VoucherTypeId.value && q.IsbyDefault == true);
            //console.log(data);
            if (data.length > 0 && this.form.IsbyDefault.value == true) {
                Q.alert("Default is not valid for this Voucher Type");
                return false;
            }
            return true;
        }

    }
}