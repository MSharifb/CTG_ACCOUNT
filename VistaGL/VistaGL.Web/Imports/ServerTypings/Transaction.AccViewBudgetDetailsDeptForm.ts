namespace VistaGL.Transaction {
    export interface AccViewBudgetDetailsDeptForm {
        Id: Serenity.IntegerEditor;
        AccountName: Serenity.StringEditor;
        Quantity: Serenity.DecimalEditor;
        Amount: Serenity.DecimalEditor;
        ZoneInfoId: Serenity.IntegerEditor;
        BudgetYearId: Serenity.IntegerEditor;
        BudgetStatus: Serenity.IntegerEditor;
        BudgetDepartmentInfoId: Serenity.IntegerEditor;
        BudgetDept: Serenity.StringEditor;
        YearName: Serenity.StringEditor;
        ActualDuring: Serenity.DecimalEditor;
        Actual1stSixMonths: Serenity.DecimalEditor;
        BudgetApproved: Serenity.DecimalEditor;
        RevisedEstimate: Serenity.DecimalEditor;
        BudgetApproved1Step: Serenity.DecimalEditor;
    }

    export class AccViewBudgetDetailsDeptForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccViewBudgetDetailsDept';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccViewBudgetDetailsDeptForm.init)  {
                AccViewBudgetDetailsDeptForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = s.DecimalEditor;

                Q.initFormType(AccViewBudgetDetailsDeptForm, [
                    'Id', w0,
                    'AccountName', w1,
                    'Quantity', w2,
                    'Amount', w2,
                    'ZoneInfoId', w0,
                    'BudgetYearId', w0,
                    'BudgetStatus', w0,
                    'BudgetDepartmentInfoId', w0,
                    'BudgetDept', w1,
                    'YearName', w1,
                    'ActualDuring', w2,
                    'Actual1stSixMonths', w2,
                    'BudgetApproved', w2,
                    'RevisedEstimate', w2,
                    'BudgetApproved1Step', w2
                ]);
            }
        }
    }
}

