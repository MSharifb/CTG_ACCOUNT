namespace VistaGL.Transaction {
    export interface AccCreditVoucherParametersForm {
        CreditVoucherDate: Serenity.DateEditor;
        ReceiveFrom: _Ext.AutoCompleteEditor;
        CreditVoucherNarration: Serenity.TextAreaEditor;
    }

    export class AccCreditVoucherParametersForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccCreditVoucherParameters';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccCreditVoucherParametersForm.init)  {
                AccCreditVoucherParametersForm.init = true;

                var s = Serenity;
                var w0 = s.DateEditor;
                var w1 = _Ext.AutoCompleteEditor;
                var w2 = s.TextAreaEditor;

                Q.initFormType(AccCreditVoucherParametersForm, [
                    'CreditVoucherDate', w0,
                    'ReceiveFrom', w1,
                    'CreditVoucherNarration', w2
                ]);
            }
        }
    }
}

