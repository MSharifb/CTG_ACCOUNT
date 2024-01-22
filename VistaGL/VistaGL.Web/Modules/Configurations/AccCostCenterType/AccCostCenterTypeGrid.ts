
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccCostCenterTypeGrid extends EntityGridBase<AccCostCenterTypeRow, any> {
        protected getColumnsKey() { return 'Configurations.AccCostCenterType'; }
        protected getDialogType() { return AccCostCenterTypeDialog; }
        protected getIdProperty() { return AccCostCenterTypeRow.idProperty; }
        protected getLocalTextPrefix() { return AccCostCenterTypeRow.localTextPrefix; }
        protected getService() { return AccCostCenterTypeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}