namespace VistaGL.Configurations {
    export interface AccVoucherApiDetailsForm {
        ConfigId: Serenity.IntegerEditor;
        AccountHeadId: Serenity.LookupEditor;
        DrCr: Serenity.StringEditor;
        Description: Serenity.StringEditor;
        Amount: Serenity.DecimalEditor;
        EmpId: Serenity.IntegerEditor;
    }

    export class AccVoucherApiDetailsForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccVoucherApiDetails';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherApiDetailsForm.init)  {
                AccVoucherApiDetailsForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.LookupEditor;
                var w2 = s.StringEditor;
                var w3 = s.DecimalEditor;

                Q.initFormType(AccVoucherApiDetailsForm, [
                    'ConfigId', w0,
                    'AccountHeadId', w1,
                    'DrCr', w2,
                    'Description', w2,
                    'Amount', w3,
                    'EmpId', w0
                ]);
            }
        }
    }
}

