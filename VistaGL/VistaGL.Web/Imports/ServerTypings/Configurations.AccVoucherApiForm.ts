namespace VistaGL.Configurations {
    export interface AccVoucherApiForm {
        ConfigId: Serenity.LookupEditor;
        VouchrTypeId: Serenity.IntegerEditor;
        TransactionId: Serenity.IntegerEditor;
        Narration: Serenity.StringEditor;
        TransactionMode: Serenity.StringEditor;
        EmpId: Serenity.LookupEditor;
    }

    export class AccVoucherApiForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccVoucherApi';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherApiForm.init)  {
                AccVoucherApiForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.IntegerEditor;
                var w2 = s.StringEditor;

                Q.initFormType(AccVoucherApiForm, [
                    'ConfigId', w0,
                    'VouchrTypeId', w1,
                    'TransactionId', w1,
                    'Narration', w2,
                    'TransactionMode', w2,
                    'EmpId', w0
                ]);
            }
        }
    }
}

