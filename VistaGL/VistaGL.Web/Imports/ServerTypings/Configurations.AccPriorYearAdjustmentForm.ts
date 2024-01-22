namespace VistaGL.Configurations {
    export interface AccPriorYearAdjustmentForm {
        FinancialYearId: Serenity.LookupEditor;
        IncomeTax: Serenity.DecimalEditor;
        Adjustment: Serenity.DecimalEditor;
    }

    export class AccPriorYearAdjustmentForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccPriorYearAdjustment';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccPriorYearAdjustmentForm.init)  {
                AccPriorYearAdjustmentForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(AccPriorYearAdjustmentForm, [
                    'FinancialYearId', w0,
                    'IncomeTax', w1,
                    'Adjustment', w1
                ]);
            }
        }
    }
}

