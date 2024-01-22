
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccBankAdviceLetterTemplateDialog extends Serenity.EntityDialog<AccBankAdviceLetterTemplateRow, any> {
        protected getFormKey() { return AccBankAdviceLetterTemplateForm.formKey; }
        protected getIdProperty() { return AccBankAdviceLetterTemplateRow.idProperty; }
        protected getLocalTextPrefix() { return AccBankAdviceLetterTemplateRow.localTextPrefix; }
        protected getNameProperty() { return AccBankAdviceLetterTemplateRow.nameProperty; }
        protected getService() { return AccBankAdviceLetterTemplateService.baseUrl; }

        protected form = new AccBankAdviceLetterTemplateForm(this.idPrefix);

        constructor() {
            super();


            //var label = document.createElement('label');
            //label.appendChild(document.createTextNode('@@ChequeNo'));

            //$('.Subject').parentNode.insertBefore(label);


            var element = document.createElement("div");
            element.appendChild(document.createTextNode('@@ChequeNo'));
            $('.s-DialogToolbar')[0].appendChild(element);

        }
    }
}