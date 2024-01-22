namespace VistaGL.Transaction {
    export interface AccMoneyReceiptForm {
        SerialNo: Serenity.StringEditor;
        MonryReceiptDate: Serenity.DateEditor;
        ReceiveFrom: _Ext.AutoCompleteEditor;
        AccMoneyReceiptDatailsList: AccMoneyReceiptDatailsEditor;
        Amount: Serenity.DecimalEditor;
        Dollar: Serenity.DecimalEditor;
        AmountInWord: Serenity.StringEditor;
        Narration: Serenity.TextAreaEditor;
        ChequeType: RecChequeTypeMappingEditor;
        ChequeDate: Serenity.DateEditor;
        ChequeNo: Serenity.StringEditor;
        AccHeadBankId: Serenity.LookupEditor;
        IsCancelled: Serenity.BooleanEditor;
        IsConfirmed: Serenity.BooleanEditor;
        IsUsed: Serenity.BooleanEditor;
        VoucherNo: Serenity.StringEditor;
        MoneyReceiptNo: Serenity.StringEditor;
    }

    export class AccMoneyReceiptForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccMoneyReceipt';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccMoneyReceiptForm.init)  {
                AccMoneyReceiptForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = _Ext.AutoCompleteEditor;
                var w3 = AccMoneyReceiptDatailsEditor;
                var w4 = s.DecimalEditor;
                var w5 = s.TextAreaEditor;
                var w6 = RecChequeTypeMappingEditor;
                var w7 = s.LookupEditor;
                var w8 = s.BooleanEditor;

                Q.initFormType(AccMoneyReceiptForm, [
                    'SerialNo', w0,
                    'MonryReceiptDate', w1,
                    'ReceiveFrom', w2,
                    'AccMoneyReceiptDatailsList', w3,
                    'Amount', w4,
                    'Dollar', w4,
                    'AmountInWord', w0,
                    'Narration', w5,
                    'ChequeType', w6,
                    'ChequeDate', w1,
                    'ChequeNo', w0,
                    'AccHeadBankId', w7,
                    'IsCancelled', w8,
                    'IsConfirmed', w8,
                    'IsUsed', w8,
                    'VoucherNo', w0,
                    'MoneyReceiptNo', w0
                ]);
            }
        }
    }
}

