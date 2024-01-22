namespace VistaGL.Configurations {
    export interface AccArDoubtfulDebtsForm {
        FinancialYearId: Serenity.LookupEditor;
        DoubtfulDebtsAmount: Serenity.DecimalEditor;
        Receivable: Serenity.DecimalEditor;
        Adjusted: Serenity.DecimalEditor;
    }

    export class AccArDoubtfulDebtsForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccArDoubtfulDebts';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccArDoubtfulDebtsForm.init)  {
                AccArDoubtfulDebtsForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.DecimalEditor;

                Q.initFormType(AccArDoubtfulDebtsForm, [
                    'FinancialYearId', w0,
                    'DoubtfulDebtsAmount', w1,
                    'Receivable', w1,
                    'Adjusted', w1
                ]);
            }
        }
    }
}

