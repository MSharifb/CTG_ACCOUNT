
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class selectFundControlInformationsDialog extends Serenity.PropertyDialog<any, any> {
        protected getFormKey() { return selectFundControlInformationsForm.formKey; }

        

        constructor() {
            super();

            var form = new selectFundControlInformationsForm(this.idPrefix);

            this.dialogTitle = "Please select Entity";
            //Authorization.userDefinition.FundControlInformationId
            //       console.log("1. "+ Authorization.userDefinition.FundControlInformationId);
            form.FundControlInformationId.value = Authorization.userDefinition.FundControlInformationId.toString();
            form.FundControlInformationId.changeSelect2(e => {

                var entity = AccFundControlInformationRow.getLookup().items.filter(p => p.Id == +form.FundControlInformationId.value);
                //  console.log(entity);
                Authorization.userDefinition.FundControlInformationId = +form.FundControlInformationId.value;
                Authorization.userDefinition.BaseCurrencyId = entity[0].CurrencyId;
                Authorization.userDefinition.BaseCurrency = entity[0].CurrencyCurrency;
                Authorization.userDefinition.FundControlName = entity[0].FundControlName;
                AccFundControlInformationService.SetFundControl({ EntityId: form.FundControlInformationId.value }, p => {

                    Q.notifySuccess("You selected Entity: " + form.FundControlInformationId.get_text());
                    setTimeout(function () {
                        window.location.reload();
                    }, 100);
                });

                // AccFundControlInformationService.baseUrl
                //   console.log("2. " + Authorization.userDefinition.FundControlInformationId);

                // location.reload();
                //   this.dialogClose();



            });

        }
    }
}