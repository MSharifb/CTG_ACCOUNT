
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccFundControlZoneWiseApproverGrid extends Serenity.EntityGrid<AccFundControlZoneWiseApproverRow, any> {
        protected getColumnsKey() { return 'Configurations.AccFundControlZoneWiseApprover'; }
        protected getDialogType() { return AccFundControlZoneWiseApproverDialog; }
        protected getIdProperty() { return AccFundControlZoneWiseApproverRow.idProperty; }
        protected getLocalTextPrefix() { return AccFundControlZoneWiseApproverRow.localTextPrefix; }
        protected getService() { return AccFundControlZoneWiseApproverService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}