
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccFinancialReportsDetailsGrid extends EntityGridBase<AccFinancialReportsDetailsRow, any> {
        protected getColumnsKey() { return 'Configurations.AccFinancialReportsDetails'; }
        protected getDialogType() { return AccFinancialReportsDetailsDialog; }
        protected getIdProperty() { return AccFinancialReportsDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return AccFinancialReportsDetailsRow.localTextPrefix; }
        protected getService() { return AccFinancialReportsDetailsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}