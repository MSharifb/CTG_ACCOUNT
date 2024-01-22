namespace VistaGL.Transaction {
    export interface AccBudgetCreationForm {
        BudgetForDepartmentId: Serenity.IntegerEditor;
        BudgetGroupId: Serenity.IntegerEditor;
        ParentId: Serenity.IntegerEditor;
        BudgetHeadId: Serenity.IntegerEditor;
        IsCoa: Serenity.BooleanEditor;
        IsBudgetHead: Serenity.BooleanEditor;
        BudgetHeadName: Serenity.StringEditor;
        ProposedBudgetAmount: Serenity.DecimalEditor;
        RevisedEstimateAmount: Serenity.DecimalEditor;
    }

    export class AccBudgetCreationForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccBudgetCreation';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBudgetCreationForm.init)  {
                AccBudgetCreationForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.BooleanEditor;
                var w2 = s.StringEditor;
                var w3 = s.DecimalEditor;

                Q.initFormType(AccBudgetCreationForm, [
                    'BudgetForDepartmentId', w0,
                    'BudgetGroupId', w0,
                    'ParentId', w0,
                    'BudgetHeadId', w0,
                    'IsCoa', w1,
                    'IsBudgetHead', w1,
                    'BudgetHeadName', w2,
                    'ProposedBudgetAmount', w3,
                    'RevisedEstimateAmount', w3
                ]);
            }
        }
    }
}

