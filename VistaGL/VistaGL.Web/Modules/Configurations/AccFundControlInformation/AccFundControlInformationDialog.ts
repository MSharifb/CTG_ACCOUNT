
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccFundControlInformationDialog extends Serenity.EntityDialog<AccFundControlInformationRow, any> {
        protected getFormKey() { return AccFundControlInformationForm.formKey; }
        protected getIdProperty() { return AccFundControlInformationRow.idProperty; }
        protected getLocalTextPrefix() { return AccFundControlInformationRow.localTextPrefix; }
        protected getNameProperty() { return AccFundControlInformationRow.nameProperty; }
        protected getService() { return AccFundControlInformationService.baseUrl; }

        protected form = new AccFundControlInformationForm(this.idPrefix);

        constructor(container: JQuery) {
            super(container);
            //this.form.ZoneInfoId.value = Authorization.userDefinition.ZoneID;

            //this.form.ZoneInfoId.value = 1;

        }

    }
}