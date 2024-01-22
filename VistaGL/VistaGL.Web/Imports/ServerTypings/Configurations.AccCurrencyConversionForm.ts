namespace VistaGL.Configurations {
    export interface AccCurrencyConversionForm {
        Currency: Serenity.StringEditor;
        Symbol: Serenity.StringEditor;
        Remarks: Serenity.TextAreaEditor;
    }

    export class AccCurrencyConversionForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccCurrencyConversion';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccCurrencyConversionForm.init)  {
                AccCurrencyConversionForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;

                Q.initFormType(AccCurrencyConversionForm, [
                    'Currency', w0,
                    'Symbol', w0,
                    'Remarks', w1
                ]);
            }
        }
    }
}

