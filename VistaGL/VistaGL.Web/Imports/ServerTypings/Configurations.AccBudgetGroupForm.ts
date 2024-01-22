namespace VistaGL.Configurations {
    export interface AccBudgetGroupForm {
        ParentId: Serenity.LookupEditor;
        BudgetCode: Serenity.StringEditor;
        GroupName: Serenity.StringEditor;
        SortingOrder: Serenity.IntegerEditor;
        IsHideChildrenFromThisLevel: Serenity.BooleanEditor;
        IsActive: Serenity.BooleanEditor;
        Type: VoucherTemplateDrCrMappingEditor;
    }

    export class AccBudgetGroupForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccBudgetGroup';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBudgetGroupForm.init)  {
                AccBudgetGroupForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;
                var w2 = s.IntegerEditor;
                var w3 = s.BooleanEditor;
                var w4 = VoucherTemplateDrCrMappingEditor;

                Q.initFormType(AccBudgetGroupForm, [
                    'ParentId', w0,
                    'BudgetCode', w1,
                    'GroupName', w1,
                    'SortingOrder', w2,
                    'IsHideChildrenFromThisLevel', w3,
                    'IsActive', w3,
                    'Type', w4
                ]);
            }
        }
    }
}

