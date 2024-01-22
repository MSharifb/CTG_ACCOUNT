namespace VistaGL.Configurations {
    export interface ImportCoAForm {
        CoADebit: CoAEditor;
    }

    export class ImportCoAForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.ImportCoAForm';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ImportCoAForm.init)  {
                ImportCoAForm.init = true;

                var s = Serenity;
                var w0 = CoAEditor;

                Q.initFormType(ImportCoAForm, [
                    'CoADebit', w0
                ]);
            }
        }
    }
}

