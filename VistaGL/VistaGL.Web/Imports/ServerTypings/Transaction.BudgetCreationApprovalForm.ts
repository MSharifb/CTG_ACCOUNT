namespace VistaGL.Transaction {
    export interface BudgetCreationApprovalForm {
        FinancialYearName: Serenity.StringEditor;
        DepartmentName: Serenity.StringEditor;
    }

    export class BudgetCreationApprovalForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.BudgetCreationApproval';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!BudgetCreationApprovalForm.init)  {
                BudgetCreationApprovalForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(BudgetCreationApprovalForm, [
                    'FinancialYearName', w0,
                    'DepartmentName', w0
                ]);
            }
        }
    }
}

