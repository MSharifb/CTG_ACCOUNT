
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccArDoubtfulDebtsGrid extends EntityGridBase<AccArDoubtfulDebtsRow, any> {
        protected getColumnsKey() { return 'Configurations.AccArDoubtfulDebts'; }
        protected getDialogType() { return AccArDoubtfulDebtsDialog; }
        protected getIdProperty() { return AccArDoubtfulDebtsRow.idProperty; }
        protected getLocalTextPrefix() { return AccArDoubtfulDebtsRow.localTextPrefix; }
        protected getService() { return AccArDoubtfulDebtsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}