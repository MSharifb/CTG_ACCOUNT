namespace VistaGL.Transaction {
    export interface AccBudgetForm {
        FinancialYearId: Serenity.LookupEditor;
        ZoneInfoId: Serenity.IntegerEditor;
        EntityId: Serenity.IntegerEditor;
        IsApproved: Serenity.BooleanEditor;
        BudgetDetails: AccBudgetDetailsEditor;
        Attachment: Serenity.MultipleImageUploadEditor;
    }

    export class AccBudgetForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccBudget';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBudgetForm.init)  {
                AccBudgetForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.IntegerEditor;
                var w2 = s.BooleanEditor;
                var w3 = AccBudgetDetailsEditor;
                var w4 = s.MultipleImageUploadEditor;

                Q.initFormType(AccBudgetForm, [
                    'FinancialYearId', w0,
                    'ZoneInfoId', w1,
                    'EntityId', w1,
                    'IsApproved', w2,
                    'BudgetDetails', w3,
                    'Attachment', w4
                ]);
            }
        }
    }
}

