namespace VistaGL.Configurations {
    export interface AccCommonDescriptionForm {
        VoucherTypeId: Serenity.LookupEditor;
        TransactionTypeId: Serenity.LookupEditor;
        Description: Serenity.TextAreaEditor;
    }

    export class AccCommonDescriptionForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccCommonDescription';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccCommonDescriptionForm.init)  {
                AccCommonDescriptionForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.TextAreaEditor;

                Q.initFormType(AccCommonDescriptionForm, [
                    'VoucherTypeId', w0,
                    'TransactionTypeId', w0,
                    'Description', w1
                ]);
            }
        }
    }
}

