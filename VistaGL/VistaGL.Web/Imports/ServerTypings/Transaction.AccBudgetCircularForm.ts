namespace VistaGL.Transaction {
    export interface AccBudgetCircularForm {
        FinancialYearId: Serenity.LookupEditor;
        IsActive: Serenity.BooleanEditor;
    }

    export class AccBudgetCircularForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccBudgetCircular';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBudgetCircularForm.init)  {
                AccBudgetCircularForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.BooleanEditor;

                Q.initFormType(AccBudgetCircularForm, [
                    'FinancialYearId', w0,
                    'IsActive', w1
                ]);
            }
        }
    }
}

