namespace VistaGL.Configurations {
    export interface AccBankAccountInformationForm {
        Id: Serenity.IntegerEditor;
        BankId: Serenity.LookupEditor;
        BankBranchId: Serenity.LookupEditor;
        CoaId: Serenity.LookupEditor;
        AccountName: Serenity.StringEditor;
        AccountNumber: Serenity.StringEditor;
        Code: Serenity.StringEditor;
        AccountDescription: Serenity.TextAreaEditor;
    }

    export class AccBankAccountInformationForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccBankAccountInformation';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBankAccountInformationForm.init)  {
                AccBankAccountInformationForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.LookupEditor;
                var w2 = s.StringEditor;
                var w3 = s.TextAreaEditor;

                Q.initFormType(AccBankAccountInformationForm, [
                    'Id', w0,
                    'BankId', w1,
                    'BankBranchId', w1,
                    'CoaId', w1,
                    'AccountName', w2,
                    'AccountNumber', w2,
                    'Code', w2,
                    'AccountDescription', w3
                ]);
            }
        }
    }
}

