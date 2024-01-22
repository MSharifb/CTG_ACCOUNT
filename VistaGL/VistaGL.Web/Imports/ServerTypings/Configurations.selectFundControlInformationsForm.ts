namespace VistaGL.Configurations {
    export interface selectFundControlInformationsForm {
        FundControlInformationId: Serenity.LookupEditor;
    }

    export class selectFundControlInformationsForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.selectFundControlInformationsForm';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!selectFundControlInformationsForm.init)  {
                selectFundControlInformationsForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;

                Q.initFormType(selectFundControlInformationsForm, [
                    'FundControlInformationId', w0
                ]);
            }
        }
    }
}

