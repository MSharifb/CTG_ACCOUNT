namespace VistaGL.Configurations {
    export interface AccBudgetZoneApproverForm {
        ZoneId: Serenity.LookupEditor;
        EmployeeId: Serenity.LookupEditor;
        EntityId: Serenity.IntegerEditor;
    }

    export class AccBudgetZoneApproverForm extends Serenity.PrefixedContext {
        static formKey = 'Configurations.AccBudgetZoneApprover';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AccBudgetZoneApproverForm.init)  {
                AccBudgetZoneApproverForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.IntegerEditor;

                Q.initFormType(AccBudgetZoneApproverForm, [
                    'ZoneId', w0,
                    'EmployeeId', w0,
                    'EntityId', w1
                ]);
            }
        }
    }
}

