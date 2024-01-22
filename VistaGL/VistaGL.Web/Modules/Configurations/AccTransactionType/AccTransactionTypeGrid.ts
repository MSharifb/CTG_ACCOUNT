
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccTransactionTypeGrid extends EntityGridBase<AccTransactionTypeRow, any> {
        protected getColumnsKey() { return 'Configurations.AccTransactionType'; }
        protected getDialogType() { return AccTransactionTypeDialog; }
        protected getIdProperty() { return AccTransactionTypeRow.idProperty; }
        protected getLocalTextPrefix() { return AccTransactionTypeRow.localTextPrefix; }
        protected getService() { return AccTransactionTypeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}