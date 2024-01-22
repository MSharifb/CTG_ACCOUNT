namespace VistaGL.Configurations {
    export interface VoucherPreviewForm {
        FundControlInformationId: Serenity.LookupEditor;
    }

    export class VoucherPreviewForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.VoucherPreviewForm';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!VoucherPreviewForm.init)  {
                VoucherPreviewForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;

                Q.initFormType(VoucherPreviewForm, [
                    'FundControlInformationId', w0
                ]);
            }
        }
    }
}

