
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class ImportCoADialog extends Serenity.EntityDialog<any, any> {
        protected getFormKey() { return ImportCoAForm.formKey; }
        //  protected getFormKey() { return AccFundControlInformationForm.formKey; }
        protected getIdProperty() { return AccFundControlInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccFundControlInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccFundControlInformationRow.nameProperty; }
        protected getService() { return AccFundControlInformationService.baseUrl; }

        protected form = new ImportCoAForm(this.idPrefix);

        constructor() {
            super();

            Q.reloadLookup('Configurations.AccChartofAccounts_Lookup');
            this.dialogTitle = "Please select Entity";
            //Authorization.userDefinition.FundControlInformationId

            //   this.form.FundControlInformationId.value = Authorization.userDefinition.FundControlInformationId.toString();


        }

        protected getToolbarButtons(): Serenity.ToolButton[] {
            let buttons = [];

            buttons.push({
                title: 'Import',
                onClick: () => {

                    AccChartofAccountsService.SaveCoAList({ List: this.form.CoADebit.value }, response => {
                        Q.reloadLookup('Configurations.AccChartofAccounts_Lookup');
                        Q.notifySuccess('Save Success');
                    });
                }
            });
            return buttons;
        }
    }
}