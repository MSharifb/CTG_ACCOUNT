namespace VistaGL.Transaction {
    export interface AccChequeRegisterForm {
        ChequeIssueDate: Serenity.DateEditor;
        PayTo: _Ext.AutoCompleteEditor;
        BankAccountInformationId: Serenity.LookupEditor;
        ChequeBookId: Serenity.LookupEditor;
        AccountName: Serenity.StringEditor;
        ChequeNo: ChequeBookEditor;
        BankName: Serenity.StringEditor;
        ChequeType: ChequeTypeMappingEditor;
        BranchName: Serenity.StringEditor;
        ChequeDate: Serenity.DateEditor;
        Amount: Serenity.DecimalEditor;
        Remarks: Serenity.TextAreaEditor;
        IsBankAdvice: Serenity.BooleanEditor;
        BankAdviceDate: Serenity.DateEditor;
        IsFinished: Serenity.BooleanEditor;
        ChequeNumhdn: Serenity.DecimalEditor;
        ChequeNoTemp: Serenity.StringEditor;
        IsCancelled: Serenity.BooleanEditor;
        isAdjusted: Serenity.BooleanEditor;
    }

    export class AccChequeRegisterForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccChequeRegister';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccChequeRegisterForm.init)  {
                AccChequeRegisterForm.init = true;

                var s = Serenity;
                var w0 = s.DateEditor;
                var w1 = _Ext.AutoCompleteEditor;
                var w2 = s.LookupEditor;
                var w3 = s.StringEditor;
                var w4 = ChequeBookEditor;
                var w5 = ChequeTypeMappingEditor;
                var w6 = s.DecimalEditor;
                var w7 = s.TextAreaEditor;
                var w8 = s.BooleanEditor;

                Q.initFormType(AccChequeRegisterForm, [
                    'ChequeIssueDate', w0,
                    'PayTo', w1,
                    'BankAccountInformationId', w2,
                    'ChequeBookId', w2,
                    'AccountName', w3,
                    'ChequeNo', w4,
                    'BankName', w3,
                    'ChequeType', w5,
                    'BranchName', w3,
                    'ChequeDate', w0,
                    'Amount', w6,
                    'Remarks', w7,
                    'IsBankAdvice', w8,
                    'BankAdviceDate', w0,
                    'IsFinished', w8,
                    'ChequeNumhdn', w6,
                    'ChequeNoTemp', w3,
                    'IsCancelled', w8,
                    'isAdjusted', w8
                ]);
            }
        }
    }
}

