namespace VistaGL.Configurations {
    export interface AccCurrencyConversionRateForm {
        FirstAmout: Serenity.DecimalEditor;
        FirstCurrency: Serenity.LookupEditor;
        SecondAmout: Serenity.DecimalEditor;
        SecondCurrency: Serenity.LookupEditor;
    }

    export class AccCurrencyConversionRateForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccCurrencyConversionRate';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccCurrencyConversionRateForm.init)  {
                AccCurrencyConversionRateForm.init = true;

                var s = Serenity;
                var w0 = s.DecimalEditor;
                var w1 = s.LookupEditor;

                Q.initFormType(AccCurrencyConversionRateForm, [
                    'FirstAmout', w0,
                    'FirstCurrency', w1,
                    'SecondAmout', w0,
                    'SecondCurrency', w1
                ]);
            }
        }
    }
}

