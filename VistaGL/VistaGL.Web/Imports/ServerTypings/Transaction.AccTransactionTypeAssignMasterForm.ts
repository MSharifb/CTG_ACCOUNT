namespace VistaGL.Transaction {
    export interface AccTransactionTypeAssignMasterForm {
        VoucherTypeId: Serenity.LookupEditor;
        TransactionTypeId: Serenity.LookupEditor;
        Remarks: Serenity.StringEditor;
        CoADebit: CoADebitEditor;
        Credit: Serenity.StringEditor;
    }

    export class AccTransactionTypeAssignMasterForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccTransactionTypeAssignMaster';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccTransactionTypeAssignMasterForm.init)  {
                AccTransactionTypeAssignMasterForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;
                var w2 = CoADebitEditor;

                Q.initFormType(AccTransactionTypeAssignMasterForm, [
                    'VoucherTypeId', w0,
                    'TransactionTypeId', w0,
                    'Remarks', w1,
                    'CoADebit', w2,
                    'Credit', w1
                ]);
            }
        }
    }
}

