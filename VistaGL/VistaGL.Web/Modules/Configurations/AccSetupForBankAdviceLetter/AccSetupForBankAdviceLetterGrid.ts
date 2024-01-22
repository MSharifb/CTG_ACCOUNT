
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    export class AccSetupForBankAdviceLetterGrid extends EntityGridBase<AccSetupForBankAdviceLetterRow, any> {
        protected getColumnsKey() { return 'Configurations.AccSetupForBankAdviceLetter'; }
        protected getDialogType() { return AccSetupForBankAdviceLetterDialog; }
        protected getIdProperty() { return AccSetupForBankAdviceLetterRow.idProperty; }
        protected getLocalTextPrefix() { return AccSetupForBankAdviceLetterRow.localTextPrefix; }
        protected getService() { return AccSetupForBankAdviceLetterService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}