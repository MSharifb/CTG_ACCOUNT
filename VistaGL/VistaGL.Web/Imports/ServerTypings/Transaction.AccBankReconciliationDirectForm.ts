namespace VistaGL.Transaction {
    export interface AccBankReconciliationDirectForm {
        VoucherDate: Serenity.DateEditor;
        VoucherNumber: Serenity.StringEditor;
        TransactionType: BRTransactionTypeEditorDDL;
        BankAccountInformationId: Serenity.LookupEditor;
        Amount: Serenity.DecimalEditor;
        PaytoOrReciveFrom: _Ext.AutoCompleteEditor;
        ChequeNo: Serenity.StringEditor;
        ChequeDate: Serenity.DateEditor;
        ClearDate: Serenity.DateEditor;
        Description: Serenity.StringEditor;
        FundControlInformationId: Serenity.LookupEditor;
    }

    export class AccBankReconciliationDirectForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccBankReconciliationDirect';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBankReconciliationDirectForm.init)  {
                AccBankReconciliationDirectForm.init = true;

                var s = Serenity;
                var w0 = s.DateEditor;
                var w1 = s.StringEditor;
                var w2 = BRTransactionTypeEditorDDL;
                var w3 = s.LookupEditor;
                var w4 = s.DecimalEditor;
                var w5 = _Ext.AutoCompleteEditor;

                Q.initFormType(AccBankReconciliationDirectForm, [
                    'VoucherDate', w0,
                    'VoucherNumber', w1,
                    'TransactionType', w2,
                    'BankAccountInformationId', w3,
                    'Amount', w4,
                    'PaytoOrReciveFrom', w5,
                    'ChequeNo', w1,
                    'ChequeDate', w0,
                    'ClearDate', w0,
                    'Description', w1,
                    'FundControlInformationId', w3
                ]);
            }
        }
    }
}

