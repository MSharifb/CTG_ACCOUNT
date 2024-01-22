
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccUnitTypeGrid extends EntityGridBase<AccUnitTypeRow, any> {
        protected getColumnsKey() { return 'Configurations.AccUnitType'; }
        protected getDialogType() { return AccUnitTypeDialog; }
        protected getIdProperty() { return AccUnitTypeRow.idProperty; }
        protected getLocalTextPrefix() { return AccUnitTypeRow.localTextPrefix; }
        protected getService() { return AccUnitTypeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}