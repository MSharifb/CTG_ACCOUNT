
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccArDoubtfulDebtsDialog extends Serenity.EntityDialog<AccArDoubtfulDebtsRow, any> {
        protected getFormKey() { return AccArDoubtfulDebtsForm.formKey; }
        protected getIdProperty() { return AccArDoubtfulDebtsRow.idProperty; }
        protected getLocalTextPrefix() { return AccArDoubtfulDebtsRow.localTextPrefix; }
        protected getService() { return AccArDoubtfulDebtsService.baseUrl; }

        protected form = new AccArDoubtfulDebtsForm(this.idPrefix);

    }
}