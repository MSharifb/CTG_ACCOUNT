
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccReportTypeCostCenterMappingDialog extends Serenity.EntityDialog<AccReportTypeCostCenterMappingRow, any> {
        protected getFormKey() { return AccReportTypeCostCenterMappingForm.formKey; }
        protected getIdProperty() { return AccReportTypeCostCenterMappingRow.idProperty; }
        protected getLocalTextPrefix() { return AccReportTypeCostCenterMappingRow.localTextPrefix; }
        protected getService() { return AccReportTypeCostCenterMappingService.baseUrl; }

        protected form = new AccReportTypeCostCenterMappingForm(this.idPrefix);

    }
}