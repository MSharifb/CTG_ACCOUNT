namespace VistaGL.Transaction {
    export interface selectCalculationForm {
        Type: VoucherTemplateDrCrMappingEditor;
        Amount: Serenity.DecimalEditor;
        Rate: Serenity.DecimalEditor;
    }

    export class selectCalculationForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.selectCalculationForm';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!selectCalculationForm.init)  {
                selectCalculationForm.init = true;

                var s = Serenity;
                var w0 = VoucherTemplateDrCrMappingEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(selectCalculationForm, [
                    'Type', w0,
                    'Amount', w1,
                    'Rate', w1
                ]);
            }
        }
    }
}

