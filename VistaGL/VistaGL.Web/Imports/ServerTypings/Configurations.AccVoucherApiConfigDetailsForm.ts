namespace VistaGL.Configurations {
    export interface AccVoucherApiConfigDetailsForm {
        AccountHeadId: Serenity.LookupEditor;
        SubLedgerId: Serenity.LookupEditor;
        DrCr: Serenity.StringEditor;
        Description: Serenity.StringEditor;
    }

    export class AccVoucherApiConfigDetailsForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccVoucherApiConfigDetails';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherApiConfigDetailsForm.init)  {
                AccVoucherApiConfigDetailsForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;

                Q.initFormType(AccVoucherApiConfigDetailsForm, [
                    'AccountHeadId', w0,
                    'SubLedgerId', w0,
                    'DrCr', w1,
                    'Description', w1
                ]);
            }
        }
    }
}

