namespace VistaGL.Transaction {
    export interface AccChequeReceiveRegisterForm {
        RecieveFrom: Serenity.StringEditor;
        ChequeReceiveDate: Serenity.DateEditor;
        AccountNo: Serenity.StringEditor;
        ReceiveType: RecChequeTypeMappingEditor;
        AccountName: Serenity.StringEditor;
        ChequeNo: Serenity.StringEditor;
        BankName: Serenity.StringEditor;
        ChequeType: ChequeTypeMappingEditor;
        BranchName: Serenity.StringEditor;
        ChequeDate: Serenity.DateEditor;
        Amount: Serenity.DecimalEditor;
        Remarks: Serenity.TextAreaEditor;
        IsCancelled: Serenity.BooleanEditor;
        IsUsed: Serenity.BooleanEditor;
    }

    export class AccChequeReceiveRegisterForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccChequeReceiveRegister';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccChequeReceiveRegisterForm.init)  {
                AccChequeReceiveRegisterForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = RecChequeTypeMappingEditor;
                var w3 = ChequeTypeMappingEditor;
                var w4 = s.DecimalEditor;
                var w5 = s.TextAreaEditor;
                var w6 = s.BooleanEditor;

                Q.initFormType(AccChequeReceiveRegisterForm, [
                    'RecieveFrom', w0,
                    'ChequeReceiveDate', w1,
                    'AccountNo', w0,
                    'ReceiveType', w2,
                    'AccountName', w0,
                    'ChequeNo', w0,
                    'BankName', w0,
                    'ChequeType', w3,
                    'BranchName', w0,
                    'ChequeDate', w1,
                    'Amount', w4,
                    'Remarks', w5,
                    'IsCancelled', w6,
                    'IsUsed', w6
                ]);
            }
        }
    }
}

