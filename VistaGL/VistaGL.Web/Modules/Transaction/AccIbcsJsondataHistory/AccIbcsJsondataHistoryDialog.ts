
namespace VistaGL.Transaction {

    @Serenity.Decorators.registerClass()
    export class AccIbcsJsondataHistoryDialog extends Serenity.EntityDialog<AccIbcsJsondataHistoryRow, any> {
        protected getFormKey() { return AccIbcsJsondataHistoryForm.formKey; }
        protected getIdProperty() { return AccIbcsJsondataHistoryRow.idProperty; }
        protected getLocalTextPrefix() { return AccIbcsJsondataHistoryRow.localTextPrefix; }
        protected getNameProperty() { return AccIbcsJsondataHistoryRow.nameProperty; }
        protected getService() { return AccIbcsJsondataHistoryService.baseUrl; }

        protected form = new AccIbcsJsondataHistoryForm(this.idPrefix);

        protected getToolbarButtons(): Serenity.ToolButton[] {
            let buttons = super.getToolbarButtons();

            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "save-and-close-button"), 1);
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "apply-changes-button"), 1);
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "delete-button"), 1);

            return buttons;
        }
    }
}