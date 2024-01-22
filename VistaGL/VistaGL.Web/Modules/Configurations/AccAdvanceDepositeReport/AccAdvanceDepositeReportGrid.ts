
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccAdvanceDepositeReportGrid extends EntityGridBase<AccAdvanceDepositeReportRow, any> {
        protected getColumnsKey() { return 'Configurations.AccAdvanceDepositeReport'; }
        protected getDialogType() { return AccAdvanceDepositeReportDialog; }
        protected getIdProperty() { return AccAdvanceDepositeReportRow.idProperty; }
        protected getLocalTextPrefix() { return AccAdvanceDepositeReportRow.localTextPrefix; }
        protected getService() { return AccAdvanceDepositeReportService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}