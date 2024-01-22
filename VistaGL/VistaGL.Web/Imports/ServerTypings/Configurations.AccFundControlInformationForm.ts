namespace VistaGL.Configurations {
    export interface AccFundControlInformationForm {
        FundControlName: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        CurrencyId: Serenity.LookupEditor;
    }

    export class AccFundControlInformationForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccFundControlInformation';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccFundControlInformationForm.init)  {
                AccFundControlInformationForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.LookupEditor;

                Q.initFormType(AccFundControlInformationForm, [
                    'FundControlName', w0,
                    'Code', w0,
                    'CurrencyId', w1
                ]);
            }
        }
    }
}

