
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccPriorYearAdjustmentGrid extends Serenity.EntityGrid<AccPriorYearAdjustmentRow, any> {
        protected getColumnsKey() { return 'Configurations.AccPriorYearAdjustment'; }
        protected getDialogType() { return AccPriorYearAdjustmentDialog; }
        protected getIdProperty() { return AccPriorYearAdjustmentRow.idProperty; }
        protected getLocalTextPrefix() { return AccPriorYearAdjustmentRow.localTextPrefix; }
        protected getService() { return AccPriorYearAdjustmentService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}