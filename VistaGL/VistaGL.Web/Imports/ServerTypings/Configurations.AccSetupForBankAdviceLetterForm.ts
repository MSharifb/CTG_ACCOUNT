namespace VistaGL.Configurations {
    export interface AccSetupForBankAdviceLetterForm {
        CoaId: Serenity.LookupEditor;
        MemorandumNo: Serenity.StringEditor;
        Duplication: Serenity.TextAreaEditor;
        IsAutoBankAdvice: Serenity.BooleanEditor;
        ZoneInfoId: Serenity.IntegerEditor;
        FundControlId: Serenity.IntegerEditor;
    }

    export class AccSetupForBankAdviceLetterForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccSetupForBankAdviceLetter';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccSetupForBankAdviceLetterForm.init)  {
                AccSetupForBankAdviceLetterForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;
                var w2 = s.TextAreaEditor;
                var w3 = s.BooleanEditor;
                var w4 = s.IntegerEditor;

                Q.initFormType(AccSetupForBankAdviceLetterForm, [
                    'CoaId', w0,
                    'MemorandumNo', w1,
                    'Duplication', w2,
                    'IsAutoBankAdvice', w3,
                    'ZoneInfoId', w4,
                    'FundControlId', w4
                ]);
            }
        }
    }
}

