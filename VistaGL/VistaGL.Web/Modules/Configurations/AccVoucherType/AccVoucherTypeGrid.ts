
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccVoucherTypeGrid extends Serenity.EntityGrid<AccVoucherTypeRow, any> {
        protected getColumnsKey() { return 'Configurations.AccVoucherType'; }
        protected getDialogType() { return AccVoucherTypeDialog; }
        protected getIdProperty() { return AccVoucherTypeRow.idProperty; }
        protected getLocalTextPrefix() { return AccVoucherTypeRow.localTextPrefix; }
        protected getService() { return AccVoucherTypeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getButtons() {
            var b = super.getButtons();
            b.shift();

            return b;
        }
    }
}