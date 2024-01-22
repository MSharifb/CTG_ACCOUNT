
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccCommonDescriptionGrid extends EntityGridBase<AccCommonDescriptionRow, any> {
        protected getColumnsKey() { return 'Configurations.AccCommonDescription'; }
        protected getDialogType() { return AccCommonDescriptionDialog; }
        protected getIdProperty() { return AccCommonDescriptionRow.idProperty; }
        protected getLocalTextPrefix() { return AccCommonDescriptionRow.localTextPrefix; }
        protected getService() { return AccCommonDescriptionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}