
namespace VistaGL.Configurations {
    
    @Serenity.Decorators.registerClass()
    export class AccBankAdviceLetterTemplateGrid extends Serenity.EntityGrid<AccBankAdviceLetterTemplateRow, any> {
        protected getColumnsKey() { return 'Configurations.AccBankAdviceLetterTemplate'; }
        protected getDialogType() { return AccBankAdviceLetterTemplateDialog; }
        protected getIdProperty() { return AccBankAdviceLetterTemplateRow.idProperty; }
        protected getLocalTextPrefix() { return AccBankAdviceLetterTemplateRow.localTextPrefix; }
        protected getService() { return AccBankAdviceLetterTemplateService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}