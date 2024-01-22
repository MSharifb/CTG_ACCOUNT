namespace VistaGL.Transaction {
    export interface AccChequeBookForm {
        BankAccountInformationId: Serenity.LookupEditor;
        AccountName: Serenity.StringEditor;
        BankName: Serenity.StringEditor;
        BranchName: Serenity.StringEditor;
        CheckBookName: Serenity.StringEditor;
        CBDate: Serenity.DateEditor;
        StartingNo: Serenity.StringEditor;
        Prefix: Serenity.StringEditor;
        PageNo: Serenity.IntegerEditor;
        EndingNo: Serenity.IntegerEditor;
        HasFinished: Serenity.BooleanEditor;
    }

    export class AccChequeBookForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccChequeBook';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccChequeBookForm.init)  {
                AccChequeBookForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;
                var w2 = s.DateEditor;
                var w3 = s.IntegerEditor;
                var w4 = s.BooleanEditor;

                Q.initFormType(AccChequeBookForm, [
                    'BankAccountInformationId', w0,
                    'AccountName', w1,
                    'BankName', w1,
                    'BranchName', w1,
                    'CheckBookName', w1,
                    'CBDate', w2,
                    'StartingNo', w1,
                    'Prefix', w1,
                    'PageNo', w3,
                    'EndingNo', w3,
                    'HasFinished', w4
                ]);
            }
        }
    }
}

