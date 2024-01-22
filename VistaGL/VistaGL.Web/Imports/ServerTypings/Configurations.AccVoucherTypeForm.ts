namespace VistaGL.Configurations {
    export interface AccVoucherTypeForm {
        Name: Serenity.StringEditor;
        SortOrder: Serenity.IntegerEditor;
    }

    export class AccVoucherTypeForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccVoucherType';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccVoucherTypeForm.init)  {
                AccVoucherTypeForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.IntegerEditor;

                Q.initFormType(AccVoucherTypeForm, [
                    'Name', w0,
                    'SortOrder', w1
                ]);
            }
        }
    }
}

