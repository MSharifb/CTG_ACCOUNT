namespace VistaGL.Configurations {
    export interface AccBankBranchInformationForm {
        BranchName: Serenity.StringEditor;
        Address: Serenity.TextAreaEditor;
        Contacts: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        Code: Serenity.StringEditor;
    }

    export class AccBankBranchInformationForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccBankBranchInformation';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBankBranchInformationForm.init)  {
                AccBankBranchInformationForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.TextAreaEditor;

                Q.initFormType(AccBankBranchInformationForm, [
                    'BranchName', w0,
                    'Address', w1,
                    'Contacts', w0,
                    'Email', w0,
                    'Code', w0
                ]);
            }
        }
    }
}

