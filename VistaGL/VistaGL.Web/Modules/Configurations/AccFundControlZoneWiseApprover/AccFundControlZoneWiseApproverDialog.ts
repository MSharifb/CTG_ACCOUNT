
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccFundControlZoneWiseApproverDialog extends Serenity.EntityDialog<AccFundControlZoneWiseApproverRow, any> {
        protected getFormKey() { return AccFundControlZoneWiseApproverForm.formKey; }
        protected getIdProperty() { return AccFundControlZoneWiseApproverRow.idProperty; }
        protected getLocalTextPrefix() { return AccFundControlZoneWiseApproverRow.localTextPrefix; }
        protected getService() { return AccFundControlZoneWiseApproverService.baseUrl; }

        protected form = new AccFundControlZoneWiseApproverForm(this.idPrefix);

        onDialogOpen(): void {
            super.onDialogOpen();

            var userinfo = Authorization.userDefinition;
            this.form.FundControlId.value = userinfo.FundControlInformationId.toString();
            this.form.ZoneInfoId.value = userinfo.ZoneID.toString();

            Serenity.EditorUtils.setReadonly(this.element.find(this.form.FundControlId.element), true);
            Serenity.EditorUtils.setReadonly(this.element.find(this.form.ZoneInfoId.element), true);
        }
    }
}