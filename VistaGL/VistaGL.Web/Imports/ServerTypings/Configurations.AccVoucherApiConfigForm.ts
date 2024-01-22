namespace VistaGL.Configurations {
    export interface AccVoucherApiConfigForm {
        ConfigName: Serenity.StringEditor;
        ModuleId: Serenity.StringEditor;
        FormName: Serenity.StringEditor;
        VouchrTypeId: Serenity.LookupEditor;
        TransactionId: Serenity.LookupEditor;
        TransactionMode: Serenity.StringEditor;
        Narration: Serenity.StringEditor;
        FundControlId: Serenity.LookupEditor;
        VoucherApiConfigDetails: AccVoucherApiConfigDetailsEditor;
    }

    export class AccVoucherApiConfigForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccVoucherApiConfig';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherApiConfigForm.init)  {
                AccVoucherApiConfigForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.LookupEditor;
                var w2 = AccVoucherApiConfigDetailsEditor;

                Q.initFormType(AccVoucherApiConfigForm, [
                    'ConfigName', w0,
                    'ModuleId', w0,
                    'FormName', w0,
                    'VouchrTypeId', w1,
                    'TransactionId', w1,
                    'TransactionMode', w0,
                    'Narration', w0,
                    'FundControlId', w1,
                    'VoucherApiConfigDetails', w2
                ]);
            }
        }
    }
}

