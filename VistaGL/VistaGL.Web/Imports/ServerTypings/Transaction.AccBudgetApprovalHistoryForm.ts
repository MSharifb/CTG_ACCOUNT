namespace VistaGL.Transaction {
    export interface AccBudgetApprovalHistoryForm {
        BudgetForDepartmentId: Serenity.IntegerEditor;
        FromAppoverId: Serenity.IntegerEditor;
        ApprovalStatusId: Serenity.EnumEditor;
        ToApproverId: Serenity.IntegerEditor;
    }

    export class AccBudgetApprovalHistoryForm extends Serenity.PrefixedContext {
        static formKey = 'Transaction.AccBudgetApprovalHistory';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBudgetApprovalHistoryForm.init)  {
                AccBudgetApprovalHistoryForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.EnumEditor;

                Q.initFormType(AccBudgetApprovalHistoryForm, [
                    'BudgetForDepartmentId', w0,
                    'FromAppoverId', w0,
                    'ApprovalStatusId', w1,
                    'ToApproverId', w0
                ]);
            }
        }
    }
}

