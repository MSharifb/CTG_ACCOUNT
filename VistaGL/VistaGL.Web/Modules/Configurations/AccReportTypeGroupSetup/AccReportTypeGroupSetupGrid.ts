
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccReportTypeGroupSetupGrid extends EntityGridBase<AccReportTypeGroupSetupRow, any> {
        protected getColumnsKey() { return 'Configurations.AccReportTypeGroupSetup'; }
        protected getDialogType() { return AccReportTypeGroupSetupDialog; }
        protected getIdProperty() { return AccReportTypeGroupSetupRow.idProperty; }
        protected getLocalTextPrefix() { return AccReportTypeGroupSetupRow.localTextPrefix; }
        protected getService() { return AccReportTypeGroupSetupService.baseUrl; }

        constructor(container: JQuery) {
            super(container);

            var tree = new Serenity.TreeGridMixin<AccReportTypeGroupSetupRow>({
                grid: this,
                getParentId: x => x.ParentId,
                toggleField: AccReportTypeGroupSetupRow.Fields.GroupName,
                initialCollapse: () => false
            });
        }
    }
}