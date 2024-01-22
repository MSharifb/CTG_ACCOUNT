
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class selectCalculationDialog extends Serenity.EntityDialog<any, any>{ // Serenity.PropertyDialog<any, any> {
        protected getFormKey() { return selectCalculationForm.formKey; }

        protected form = new selectCalculationForm(this.idPrefix);

        constructor() {
            super();

            this.dialogTitle = "Calculate";
            //this.form.Type.changeSelect2(p => {
            //    Q.alert(this.form.Type.get_text());

            //});
        }

        protected getToolbarButtons() {

            var buttons = [];//super.getToolbarButtons();

            buttons.push({

                title: 'Ok',
                cssClass: 'tool-button expand-all-button',
                onClick: () => {

                    let type = this.form.Type.value;
                    let amount = this.form.Amount.value;
                    let rate = this.form.Rate.value;
                    let finalAmount = amount * (rate / 100);
                    if (type == 'Dr') {
                        $("input[name*='DebitAmount']").val(finalAmount);
                        $("input[name*='CreditAmount']").val(0);
                    }
                    else {
                        $("input[name*='CreditAmount']").val(finalAmount);
                        $("input[name*='DebitAmount']").val(0);
                    }
                    this.dialogClose();
                }
            }
            );

            return buttons;
        }
    }
}