namespace VistaGL.Transaction {
    export interface AccBudgetForDepartmentDetailForm {
        BudgetForDepartmentId: Serenity.IntegerEditor;
        BudgetGroupId: Serenity.IntegerEditor;
        ParentId: Serenity.IntegerEditor;
        BudgetHeadId: Serenity.IntegerEditor;
        IsCoa: Serenity.BooleanEditor;
        IsBudgetHead: Serenity.BooleanEditor;
    }

    export class AccBudgetForDepartmentDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccBudgetForDepartmentDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBudgetForDepartmentDetailForm.init)  {
                AccBudgetForDepartmentDetailForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.BooleanEditor;

                Q.initFormType(AccBudgetForDepartmentDetailForm, [
                    'BudgetForDepartmentId', w0,
                    'BudgetGroupId', w0,
                    'ParentId', w0,
                    'BudgetHeadId', w0,
                    'IsCoa', w1,
                    'IsBudgetHead', w1
                ]);
            }
        }
    }
}

