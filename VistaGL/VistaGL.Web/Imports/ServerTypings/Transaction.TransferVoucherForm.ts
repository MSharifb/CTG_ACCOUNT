namespace VistaGL.Transaction {
    export interface TransferVoucherForm {
        TransferType: Serenity.RadioButtonEditor;
        VoucherTypeId: Serenity.LookupEditor;
        PostingFinancialYearId: Serenity.LookupEditor;
        TransactionTypeEntityId: Serenity.LookupEditor;
        VoucherNo: Serenity.StringEditor;
        VoucherDate: Serenity.DateEditor;
        TransactionMode: Serenity.StringEditor;
        FileNo: Serenity.StringEditor;
        PageNo: Serenity.StringEditor;
        TransactionType: Serenity.StringEditor;
        VoucherType: Serenity.StringEditor;
        VoucherNumber: Serenity.StringEditor;
        Description: Serenity.TextAreaEditor;
        AccountHeadFrom: Serenity.LookupEditor;
        AccountHeadTo: Serenity.LookupEditor;
        TransferAmount: Serenity.DecimalEditor;
        Amount: Serenity.DecimalEditor;
        DDescription: Serenity.TextAreaEditor;
        AddtoGrid: Serenity.StringEditor;
        VoucherDetails: TransferDetailesEditor;
        DAmount: Serenity.DecimalEditor;
        CAmount: Serenity.DecimalEditor;
        AmountInWords: Serenity.StringEditor;
        PostedBy: Serenity.StringEditor;
        PostingDate: Serenity.DateEditor;
    }

    export class TransferVoucherForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.TransferVoucher';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!TransferVoucherForm.init)  {
                TransferVoucherForm.init = true;

                var s = Serenity;
                var w0 = s.RadioButtonEditor;
                var w1 = s.LookupEditor;
                var w2 = s.StringEditor;
                var w3 = s.DateEditor;
                var w4 = s.TextAreaEditor;
                var w5 = s.DecimalEditor;
                var w6 = TransferDetailesEditor;

                Q.initFormType(TransferVoucherForm, [
                    'TransferType', w0,
                    'VoucherTypeId', w1,
                    'PostingFinancialYearId', w1,
                    'TransactionTypeEntityId', w1,
                    'VoucherNo', w2,
                    'VoucherDate', w3,
                    'TransactionMode', w2,
                    'FileNo', w2,
                    'PageNo', w2,
                    'TransactionType', w2,
                    'VoucherType', w2,
                    'VoucherNumber', w2,
                    'Description', w4,
                    'AccountHeadFrom', w1,
                    'AccountHeadTo', w1,
                    'TransferAmount', w5,
                    'Amount', w5,
                    'DDescription', w4,
                    'AddtoGrid', w2,
                    'VoucherDetails', w6,
                    'DAmount', w5,
                    'CAmount', w5,
                    'AmountInWords', w2,
                    'PostedBy', w2,
                    'PostingDate', w3
                ]);
            }
        }
    }
}

