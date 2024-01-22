namespace VistaGL.Configurations {
    export interface AccBankInformationForm {
        BankName: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        BankBranchInformations: AccBankBranchInformationEditor;
    }

    export class AccBankInformationForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccBankInformation';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBankInformationForm.init)  {
                AccBankInformationForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = AccBankBranchInformationEditor;

                Q.initFormType(AccBankInformationForm, [
                    'BankName', w0,
                    'Code', w0,
                    'BankBranchInformations', w1
                ]);
            }
        }
    }
}

