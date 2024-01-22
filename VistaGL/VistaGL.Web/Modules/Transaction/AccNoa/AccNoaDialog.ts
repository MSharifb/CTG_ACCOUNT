
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccNoaDialog extends EntityDialogBase<AccNoaRow, any> {
        protected getFormKey() { return AccNoaForm.formKey; }
        protected getIdProperty() { return AccNoaRow.idProperty; }
        protected getLocalTextPrefix() { return AccNoaRow.localTextPrefix; }
        protected getNameProperty() { return AccNoaRow.nameProperty; }
        protected getService() { return AccNoaService.baseUrl; }

        protected form = new AccNoaForm(this.idPrefix);
        protected onDialogOpen() {
            super.onDialogOpen();
            if (!this.isNew()) {
                Serenity.EditorUtils.setReadonly(this.element.find(this.form.NoaNumber.element), true);

            }

            this.form.CostCenterId.changeSelect2(p => {
                this.form.NameofContractor.value = this.form.CostCenterId.text;
            });

        }
        protected validateBeforeSave() {

            var Status = true;
            if (this.isNew() == true) {
                var data = AccNoaRow.getLookup().items.filter(f => f.NoaNumber == this.form.NoaNumber.value);
                data.forEach(d => {
                    Q.alert("Duplicate NOA Number Found.");
                    Status = false;
                });
            }

            return Status;
        }
    }


}