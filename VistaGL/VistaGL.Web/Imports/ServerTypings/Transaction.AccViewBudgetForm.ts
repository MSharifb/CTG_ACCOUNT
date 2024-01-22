namespace VistaGL.Transaction {
    export interface AccViewBudgetForm {
        Id: Serenity.IntegerEditor;
        AccountName: Serenity.StringEditor;
        Quantity: Serenity.DecimalEditor;
        Amount: Serenity.DecimalEditor;
        BudgetRevisionNo: Serenity.IntegerEditor;
        BudgetDepartmentInfoId: Serenity.IntegerEditor;
        ZoneInfoId: Serenity.IntegerEditor;
        EntityId: Serenity.IntegerEditor;
        BudgetYearId: Serenity.IntegerEditor;
        BudgetStatus: Serenity.IntegerEditor;
    }

    export class AccViewBudgetForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccViewBudget';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccViewBudgetForm.init)  {
                AccViewBudgetForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = s.DecimalEditor;

                Q.initFormType(AccViewBudgetForm, [
                    'Id', w0,
                    'AccountName', w1,
                    'Quantity', w2,
                    'Amount', w2,
                    'BudgetRevisionNo', w0,
                    'BudgetDepartmentInfoId', w0,
                    'ZoneInfoId', w0,
                    'EntityId', w0,
                    'BudgetYearId', w0,
                    'BudgetStatus', w0
                ]);
            }
        }
    }
}

