namespace VistaGL.Configurations {
    export interface AccTransactionTypeForm {
        VoucherTypeId: Serenity.LookupEditor;
        TransactionType: Serenity.StringEditor;
        TransactionMode: COAMappingEditor;
        SortOrder: Serenity.IntegerEditor;
        IsbyDefault: Serenity.BooleanEditor;
        Remarks: Serenity.TextAreaEditor;
    }

    export class AccTransactionTypeForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccTransactionType';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccTransactionTypeForm.init)  {
                AccTransactionTypeForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;
                var w2 = COAMappingEditor;
                var w3 = s.IntegerEditor;
                var w4 = s.BooleanEditor;
                var w5 = s.TextAreaEditor;

                Q.initFormType(AccTransactionTypeForm, [
                    'VoucherTypeId', w0,
                    'TransactionType', w1,
                    'TransactionMode', w2,
                    'SortOrder', w3,
                    'IsbyDefault', w4,
                    'Remarks', w5
                ]);
            }
        }
    }
}

