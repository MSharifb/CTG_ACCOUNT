namespace VistaGL.Transaction {
    export interface AccTransactionTypeAssignForm {
        TrType: Serenity.StringEditor;
        ParentId: Serenity.LookupEditor;
        CoaId: Serenity.LookupEditor;
    }

    export class AccTransactionTypeAssignForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccTransactionTypeAssign';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccTransactionTypeAssignForm.init)  {
                AccTransactionTypeAssignForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.LookupEditor;

                Q.initFormType(AccTransactionTypeAssignForm, [
                    'TrType', w0,
                    'ParentId', w1,
                    'CoaId', w1
                ]);
            }
        }
    }
}

