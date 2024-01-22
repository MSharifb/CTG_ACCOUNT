namespace VistaGL.Transaction {
    export interface AccBudgetForDepartmentForm {
        BudgetCircularId: Serenity.LookupEditor;
        ZoneId: Serenity.IntegerEditor;
        BudgetCircularFinancialYearId: Serenity.LookupEditor;
        DepartmentId: Serenity.LookupEditor;
        AccBudgetForDepartmentDetailList: AccBudgetForDepartmentDetailEditor;
    }

    export class AccBudgetForDepartmentForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccBudgetForDepartment';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBudgetForDepartmentForm.init)  {
                AccBudgetForDepartmentForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.IntegerEditor;
                var w2 = AccBudgetForDepartmentDetailEditor;

                Q.initFormType(AccBudgetForDepartmentForm, [
                    'BudgetCircularId', w0,
                    'ZoneId', w1,
                    'BudgetCircularFinancialYearId', w0,
                    'DepartmentId', w0,
                    'AccBudgetForDepartmentDetailList', w2
                ]);
            }
        }
    }
}

