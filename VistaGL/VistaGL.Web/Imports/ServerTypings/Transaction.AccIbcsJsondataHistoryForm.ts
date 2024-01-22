namespace VistaGL.Transaction {
    export interface AccIbcsJsondataHistoryForm {
        JsonData: Serenity.TextAreaEditor;
    }

    export class AccIbcsJsondataHistoryForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccIbcsJsondataHistory';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccIbcsJsondataHistoryForm.init)  {
                AccIbcsJsondataHistoryForm.init = true;

                var s = Serenity;
                var w0 = s.TextAreaEditor;

                Q.initFormType(AccIbcsJsondataHistoryForm, [
                    'JsonData', w0
                ]);
            }
        }
    }
}

