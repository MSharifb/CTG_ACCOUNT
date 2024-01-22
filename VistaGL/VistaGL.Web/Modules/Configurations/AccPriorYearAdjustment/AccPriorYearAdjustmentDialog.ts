
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccPriorYearAdjustmentDialog extends Serenity.EntityDialog<AccPriorYearAdjustmentRow, any> {
        protected getFormKey() { return AccPriorYearAdjustmentForm.formKey; }
        protected getIdProperty() { return AccPriorYearAdjustmentRow.idProperty; }
        protected getLocalTextPrefix() { return AccPriorYearAdjustmentRow.localTextPrefix; }
        protected getService() { return AccPriorYearAdjustmentService.baseUrl; }

        protected form = new AccPriorYearAdjustmentForm(this.idPrefix);

    }
}