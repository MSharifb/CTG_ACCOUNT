
namespace VistaGL.Configurations {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class AccSetupForBankAdviceLetterDialog extends Serenity.EntityDialog<AccSetupForBankAdviceLetterRow, any> {
        protected getFormKey() { return AccSetupForBankAdviceLetterForm.formKey; }
        protected getIdProperty() { return AccSetupForBankAdviceLetterRow.idProperty; }
        protected getLocalTextPrefix() { return AccSetupForBankAdviceLetterRow.localTextPrefix; }
        protected getNameProperty() { return AccSetupForBankAdviceLetterRow.nameProperty; }
        protected getService() { return AccSetupForBankAdviceLetterService.baseUrl; }

        protected form = new AccSetupForBankAdviceLetterForm(this.idPrefix);

        public items_ChartofAccounts: Configurations.AccChartofAccountsRow[];

        constructor() {
            super();
            this.LoanAccountHeadBank();     
        }

        public LoanAccountHeadBank() {
            this.form.CoaId.clearItems();

            var coaMapping = "BANK";
            var _zoneWiseBankAccInfoList: Configurations.AccBankAccountInformationRow[];
            _zoneWiseBankAccInfoList = Q.getLookup("Configurations.AccBankAccountInformation_Lookup").items;

            for (var bank of _zoneWiseBankAccInfoList) {
                var coa = Configurations.AccChartofAccountsRow.getLookup().items.filter(f => f.Id == bank.CoaId);

                if (coa.length > 0) {
                    this.form.CoaId.addItem({ id: coa[0].Id.toString(), text: coa[0].AccountName, source: null, disabled: false });
                }
            }
        }
    }
}