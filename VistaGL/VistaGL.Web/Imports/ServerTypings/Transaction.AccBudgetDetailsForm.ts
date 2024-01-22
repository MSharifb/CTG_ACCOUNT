namespace VistaGL.Transaction {
    export interface AccBudgetDetailsForm {
        BudgetId: Serenity.IntegerEditor;
        BudgetGroupId: Serenity.IntegerEditor;
        BudgetHeadId: Serenity.LookupEditor;
        ParentId: Serenity.IntegerEditor;
        IsCoa: Serenity.BooleanEditor;
        IsBudgetHead: Serenity.BooleanEditor;
        IsCostCenter: Serenity.BooleanEditor;
        BudgetAmount: Serenity.DecimalEditor;
        BudgetCode: Serenity.StringEditor;
        BgSortOrder: Serenity.IntegerEditor;
    }

    export class AccBudgetDetailsForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccBudgetDetails';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBudgetDetailsForm.init)  {
                AccBudgetDetailsForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.LookupEditor;
                var w2 = s.BooleanEditor;
                var w3 = s.DecimalEditor;
                var w4 = s.StringEditor;

                Q.initFormType(AccBudgetDetailsForm, [
                    'BudgetId', w0,
                    'BudgetGroupId', w0,
                    'BudgetHeadId', w1,
                    'ParentId', w0,
                    'IsCoa', w2,
                    'IsBudgetHead', w2,
                    'IsCostCenter', w2,
                    'BudgetAmount', w3,
                    'BudgetCode', w4,
                    'BgSortOrder', w0
                ]);
            }
        }
    }
}

