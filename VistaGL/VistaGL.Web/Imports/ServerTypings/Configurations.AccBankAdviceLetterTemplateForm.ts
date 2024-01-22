namespace VistaGL.Configurations {
    export interface AccBankAdviceLetterTemplateForm {
        Subject: Serenity.StringEditor;
        Body1: Serenity.TextAreaEditor;
        Body2: Serenity.TextAreaEditor;
    }

    export class AccBankAdviceLetterTemplateForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccBankAdviceLetterTemplate';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBankAdviceLetterTemplateForm.init)  {
                AccBankAdviceLetterTemplateForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;

                Q.initFormType(AccBankAdviceLetterTemplateForm, [
                    'Subject', w0,
                    'Body1', w1,
                    'Body2', w1
                ]);
            }
        }
    }
}

