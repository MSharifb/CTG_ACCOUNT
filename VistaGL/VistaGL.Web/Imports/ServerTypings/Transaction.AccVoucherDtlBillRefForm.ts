namespace VistaGL.Transaction {
    export interface AccVoucherDtlBillRefForm {
        BillDate: Serenity.DateEditor;
        BillType: BillTypeEditor;
        BillRefNo: Serenity.StringEditor;
        Amount: Serenity.DecimalEditor;
        Description: Serenity.TextAreaEditor;
    }

    export class AccVoucherDtlBillRefForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccVoucherDtlBillRef';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherDtlBillRefForm.init)  {
                AccVoucherDtlBillRefForm.init = true;

                var s = Serenity;
                var w0 = s.DateEditor;
                var w1 = BillTypeEditor;
                var w2 = s.StringEditor;
                var w3 = s.DecimalEditor;
                var w4 = s.TextAreaEditor;

                Q.initFormType(AccVoucherDtlBillRefForm, [
                    'BillDate', w0,
                    'BillType', w1,
                    'BillRefNo', w2,
                    'Amount', w3,
                    'Description', w4
                ]);
            }
        }
    }
}

